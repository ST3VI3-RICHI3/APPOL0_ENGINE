using System;

namespace AppStarter {
  public class program {
    public static void Main() {
      Console.WriteLine("Warning: The Rust language must be installed along with cargo (cargo comes with rust), if theese are not installed please install them at http://rust-lang.org");
      Console.Write("Press any key to continue.");
      Console.ReadLine();
      System.Diagnostics.Process process = new System.Diagnostics.Process();
      System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
      startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
      startInfo.FileName = "cmd.exe";
      startInfo.Arguments = "/c cargo run";
      process.StartInfo = startInfo;
      process.Start();
    }
  }
}
