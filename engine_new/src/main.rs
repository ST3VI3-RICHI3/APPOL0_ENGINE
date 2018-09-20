#[macro_use]
extern crate gfx;

extern crate gfx_window_glutin;
extern crate glutin;
extern crate image;

use gfx::traits::FactoryExt;
use gfx::Device;
use gfx_window_glutin as gfx_glutin;
use glutin::{GlContext, GlRequest};
use glutin::Api::OpenGl;

pub type ColorFormat = gfx::format::Srgba8;
pub type DepthFormat = gfx::format::DepthStencil;


const BLACK: [f32; 4] = [0.0, 0.0, 0.0, 1.0];

gfx_defines!{

    vertex Vertex {
        pos: [f32; 4] = "a_Pos",
        uv: [f32; 2] = "a_Uv",
	tl: [f32; 3] = "a_Translation",
	rt: [f32; 3] = "a_Rotation",
	sc: [f32; 3] = "a_Scale",
    }

    constant Transform {
        transform: [[f32; 4];4] = "u_Transform",
    }

    pipeline pipe {
        vbuf: gfx::VertexBuffer<Vertex> = (),
        tex: gfx::TextureSampler<[f32; 4]> = "t_Texture",
        transform: gfx::ConstantBuffer<Transform> = "Transform",
        out: gfx::BlendTarget<ColorFormat> = ("Target0", gfx::state::ColorMask::all(), gfx::preset::blend::ALPHA),
    }
}

fn gfx_load_texture<F, R>(id: u16, factory: &mut F) -> gfx::handle::ShaderResourceView<R, [f32; 4]>
    where F: gfx::Factory<R>,
          R: gfx::Resources
{
    use gfx::format::Rgba8;
    let path = format!("resources/{}.png", id);
    let mut img = image::open(path).unwrap().to_rgba();
    img = image::imageops::flip_vertical(&img);
    let (width, height) = img.dimensions();
    let kind = gfx::texture::Kind::D2(width as u16, height as u16, gfx::texture::AaMode::Single);
    let (_, view) = factory.create_texture_immutable_u8::<Rgba8>(kind, gfx::texture::Mipmap::Provided, &[&img]).unwrap();
    view
}



pub struct Triangle {
    v1: Vertex,
    v2: Vertex,
    v3: Vertex,
    tex: u16,
}

pub struct Quad {
    v1: Vertex,
    v2: Vertex,
    v3: Vertex,
    v4: Vertex,
    tex: u16,
}

pub fn mktri(vrt1: [f32; 3], vrt2: [f32; 3], vrt3: [f32; 3], tm: [[f32; 3]; 3], te: u16) -> Triangle {
	let translation = tm[0];
	let rot = tm[1];
	let scale = tm[2];
    let mut tri = Triangle {
        v1: Vertex { pos: [vrt1[0], vrt1[1], vrt1[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [0.0, 0.0] },
        v2: Vertex { pos: [vrt2[0], vrt2[1], vrt2[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [1.0, 0.0] },
        v3: Vertex { pos: [vrt3[0], vrt3[1], vrt3[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [0.0, 1.0] },
	tex: te
    };
    return tri;
}

pub fn mkquad(vrt1: [f32; 3], vrt2: [f32; 3], vrt3: [f32; 3], vrt4: [f32; 3], tm: [[f32; 3]; 3], te: u16) -> Quad {
	let translation = tm[0];
	let rot = tm[1];
	let scale = tm[2];
    let mut quad = Quad {
        v1: Vertex { pos: [vrt1[0], vrt1[1], vrt1[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [0.0, 0.0] },
        v2: Vertex { pos: [vrt2[0], vrt2[1], vrt2[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [1.0, 0.0] },
        v3: Vertex { pos: [vrt3[0], vrt3[1], vrt3[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [0.0, 1.0] },
        v4: Vertex { pos: [vrt4[0], vrt4[1], vrt4[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [1.0, 1.0] },
	tex: te
    };
    return quad;
}

pub fn main() {
    let mut events_loop = glutin::EventsLoop::new();
    let windowbuilder = glutin::WindowBuilder::new()
        .with_title("Triangle Example".to_string())
        .with_dimensions(glutin::dpi::LogicalSize::new(512.0, 512.0));
    let contextbuilder = glutin::ContextBuilder::new()
        .with_gl(GlRequest::Specific(OpenGl,(3,2)))
        .with_vsync(false);
    let (window, mut device, mut factory, color_view, depth_view) =
        gfx_glutin::init::<ColorFormat, DepthFormat>(windowbuilder, contextbuilder, &events_loop);
    let pso = factory.create_pipeline_simple(
        include_bytes!("../shader/myshader_150.glslv"),
        include_bytes!("../shader/myshader_150.glslf"),
        pipe::new()
    ).unwrap();
    let mut encoder: gfx::Encoder<_, _> = factory.create_command_buffer().into();
    let texture = gfx_load_texture(0, &mut factory);
    let mut testTriangle = mktri(
        [ -0.5, -0.5, 0.0 ],
        [ 0.5, -0.5, 0.0 ],
        [ 0.0, 0.5, 0.0 ],
        [[0.0, 0.0, -0.5],
        [15.0, 75.0, 45.0],
        [1.0, 1.0, 1.0]],
	0);
//Identity Matrix
    const TRANSFORM: Transform = Transform {
        transform: [[1.0, 0.0, 0.0, 0.0],
                    [0.0, 1.0, 0.0, 0.0],
                    [0.0, 0.0, 1.0, 0.0],
                    [0.0, 0.0, 0.0, 1.0]]
    };
    let verts: [Vertex; 3] = [testTriangle.v1, testTriangle.v2, testTriangle.v3];
    let (vertex_buffer, slice) = factory.create_vertex_buffer_with_slice(&verts, ());
    let transform_buffer = factory.create_constant_buffer(1);
    let sampler = factory.create_sampler_linear();
    let texture = gfx_load_texture(testTriangle.tex, &mut factory);
    let data = pipe::Data {
        vbuf: vertex_buffer,
        transform: transform_buffer,
        tex: (texture, sampler),
        out: color_view.clone(),
    };
    let mut running = true;
    while running {
        events_loop.poll_events(|event| {
            if let glutin::Event::WindowEvent { event, .. } = event {
                match event {
                    glutin::WindowEvent::CloseRequested |
                    glutin::WindowEvent::KeyboardInput {
                        input: glutin::KeyboardInput {
                            virtual_keycode: Some(glutin::VirtualKeyCode::Escape), ..
                        }, ..
                    } => running = false,
                    _ => {}
                }
            }
        });
	encoder.clear(&color_view, BLACK); //clear the framebuffer with a color(color needs to be an array of 4 f32s, RGBa)
	encoder.update_buffer(&data.transform, &[TRANSFORM], 0); //update buffers
	encoder.draw(&slice, &pso, &data); // draw commands with buffer data and attached pso
	encoder.flush(&mut device); // execute draw commands
        window.swap_buffers().unwrap();
        device.cleanup();
    }
}
