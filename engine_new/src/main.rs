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

pub fn mktri(vrt1: [f32; 3], vrt2: [f32; 3], vrt3: [f32; 3], tm: [[f32; 3]; 3], te: u16, uvflip: bool) -> Triangle {
	let translation = tm[0];
	let rot = tm[1];
	let scale = tm[2];
    let mut tri = Triangle {
        v1: Vertex { pos: [vrt1[0], vrt1[1], vrt1[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [0.0, 0.0] },
        v2: Vertex { pos: [vrt2[0], vrt2[1], vrt2[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [1.0, 0.0] },
        v3: Vertex { pos: [vrt3[0], vrt3[1], vrt3[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [0.0, 1.0] },
	tex: te
    };
    if uvflip
    {
        let mut tri = Triangle {
            v1: Vertex { pos: [vrt1[0], vrt1[1], vrt1[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [1.0, 1.0] },
            v2: Vertex { pos: [vrt2[0], vrt2[1], vrt2[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [0.0, 1.0] },
            v3: Vertex { pos: [vrt3[0], vrt3[1], vrt3[2], 1.0], tl: translation, rt: rot, sc: scale, uv: [1.0, 0.0] },
	    tex: te
        };
        return tri;
    }
    return tri;
}

pub fn septri(tri: &Triangle) -> [Vertex; 3]
{
    return [tri.v1, tri.v2, tri.v3];
}

pub fn main() {
    let mut events_loop = glutin::EventsLoop::new();
    let windowbuilder = glutin::WindowBuilder::new()
        .with_title("Triangle Example".to_string())
        .with_dimensions(glutin::dpi::LogicalSize::new(640.0, 360.0));
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
    //Identity Matrix
    const TRANSFORM: Transform = Transform {
        transform: [[1.0, 0.0, 0.0, 0.0],
                    [0.0, 1.0, 0.0, 0.0],
                    [0.0, 0.0, 1.0, 0.0],
                    [0.0, 0.0, 0.0, 1.0]]
    };
    let tex0 = gfx_load_texture(0, &mut factory);
    let mut running = true;
    let mut timerunning : f32 = 0.0;
    while running {
        timerunning = timerunning + 0.01;
        events_loop.poll_events(|event| {
            if let glutin::Event::WindowEvent { event, .. } = event {
                match event {
                    glutin::WindowEvent::CloseRequested => running = false,
                    _ => {}
                }
            }
        });
    let tri1 = mktri(
        [ -1.0, -1.0, -1.0 ],
        [ 1.0, -1.0, -1.0 ],
        [ -1.0, 1.0, -1.0 ],
        [[0.0, 0.0, -2.0],
        [0.0, timerunning.sin() * 3.14, 0.0],
        [1.0, 1.0, 1.0]],
	0, false);

    let tri2 = mktri(
        [ 1.0, 1.0, -1.0 ],
        [ -1.0, 1.0, -1.0 ],
        [ 1.0, -1.0, -1.0 ],
        [[0.0, 0.0, -2.0],
        [0.0, timerunning.sin() * 3.14, 0.0],
        [1.0, 1.0, 1.0]],
	0, true);

    let tri3 = mktri(
        [ -1.0, -1.0, -1.0 ],
        [ 1.0, -1.0, -1.0 ],
        [ -1.0, -1.0, 1.0 ],
        [[0.0, 0.0, -2.0],
        [0.0, timerunning.sin() * 3.14, 0.0],
        [1.0, 1.0, 1.0]],
	0, false);

    let tri4 = mktri(
        [ 1.0, -1.0, 1.0 ],
        [ -1.0, -1.0, 1.0 ],
        [ 1.0, -1.0, -1.0 ],
        [[0.0, 0.0, -2.0],
        [0.0, timerunning.sin() * 3.14, 0.0],
        [1.0, 1.0, 1.0]],
	0, true);

    let tri5 = mktri(
        [ -1.0, -1.0, -1.0 ],
        [ -1.0, 1.0, -1.0 ],
        [ -1.0, -1.0, 1.0 ],
        [[0.0, 0.0, -2.0],
        [0.0, timerunning.sin() * 3.14, 0.0],
        [1.0, 1.0, 1.0]],
	0, false);

    let tri6 = mktri(
        [ -1.0, 1.0, 1.0 ],
        [ -1.0, -1.0, 1.0 ],
        [ -1.0, 1.0, -1.0 ],
        [[0.0, 0.0, -2.0],
        [0.0, timerunning.sin() * 3.14, 0.0],
        [1.0, 1.0, 1.0]],
	0, true);

    let shape0: [Vertex; 3] = septri(&tri1);
    let (vb1, s1) = factory.create_vertex_buffer_with_slice(&shape0, ());
    let tb1 = factory.create_constant_buffer(1);
    let smp1 = factory.create_sampler_linear();
    let vd1 = pipe::Data {
        vbuf: vb1,
        transform: tb1,
        tex: (tex0.clone(), smp1),
        out: color_view.clone(),
    };
    let shape1: [Vertex; 3] = septri(&tri2);
    let (vb2, s2) = factory.create_vertex_buffer_with_slice(&shape1, ());
    let tb2 = factory.create_constant_buffer(1);
    let smp2 = factory.create_sampler_linear();
    let vd2 = pipe::Data {
        vbuf: vb2,
        transform: tb2,
        tex: (tex0.clone(), smp2),
        out: color_view.clone(),
    };

    let shape2: [Vertex; 3] = septri(&tri3);
    let (vb3, s3) = factory.create_vertex_buffer_with_slice(&shape2, ());
    let tb3 = factory.create_constant_buffer(1);
    let smp3 = factory.create_sampler_linear();
    let vd3 = pipe::Data {
        vbuf: vb3,
        transform: tb3,
        tex: (tex0.clone(), smp3),
        out: color_view.clone(),
    };
    let shape3: [Vertex; 3] = septri(&tri4);
    let (vb4, s4) = factory.create_vertex_buffer_with_slice(&shape3, ());
    let tb4 = factory.create_constant_buffer(1);
    let smp4 = factory.create_sampler_linear();
    let vd4 = pipe::Data {
        vbuf: vb4,
        transform: tb4,
        tex: (tex0.clone(), smp4),
        out: color_view.clone(),
    };

    let shape4: [Vertex; 3] = septri(&tri5);
    let (vb5, s5) = factory.create_vertex_buffer_with_slice(&shape4, ());
    let tb5 = factory.create_constant_buffer(1);
    let smp5 = factory.create_sampler_linear();
    let vd5 = pipe::Data {
        vbuf: vb5,
        transform: tb5,
        tex: (tex0.clone(), smp5),
        out: color_view.clone(),
    };
    let shape5: [Vertex; 3] = septri(&tri6);
    let (vb6, s6) = factory.create_vertex_buffer_with_slice(&shape5, ());
    let tb6 = factory.create_constant_buffer(1);
    let smp6 = factory.create_sampler_linear();
    let vd6 = pipe::Data {
        vbuf: vb6,
        transform: tb6,
        tex: (tex0.clone(), smp6),
        out: color_view.clone(),
    };

	encoder.clear(&color_view, BLACK); //clear the framebuffer with a color(color needs to be an array of 4 f32s, RGBa)
	encoder.update_buffer(&vd1.transform, &[TRANSFORM], 0); //update buffers
	encoder.draw(&s1, &pso, &vd1); // draw commands with buffer data and attached pso
	encoder.update_buffer(&vd2.transform, &[TRANSFORM], 0); //update buffers
    encoder.draw(&s2, &pso, &vd2);
	encoder.update_buffer(&vd3.transform, &[TRANSFORM], 0); //update buffers
	encoder.draw(&s3, &pso, &vd3); // draw commands with buffer data and attached pso
	encoder.update_buffer(&vd4.transform, &[TRANSFORM], 0); //update buffers
    encoder.draw(&s4, &pso, &vd4);
	encoder.update_buffer(&vd5.transform, &[TRANSFORM], 0); //update buffers
	encoder.draw(&s5, &pso, &vd5); // draw commands with buffer data and attached pso
	encoder.update_buffer(&vd6.transform, &[TRANSFORM], 0); //update buffers
    encoder.draw(&s6, &pso, &vd6);
	encoder.flush(&mut device); // execute draw commands
        window.swap_buffers().unwrap();
        device.cleanup();
    }
}
