using System;

namespace AppStarter {
  public class program {
    public static void Main() {
      Console.WriteLine("ST3VI3 STUDIOS 2018, All rights reserved");
      Console.WriteLine(" ");
      Console.WriteLine("Warning: The Rust language must be installed along with cargo (cargo comes with rust), if theese are not installed please install by pushing 2");
      Console.WriteLine(" ");
      Console.WriteLine("Please select an option:");
      Console.WriteLine("1) Start the game (default)");
      Console.WriteLine("2) Install rust");
      Console.WriteLine("");
      Console.Write("Press [ENTER] to confirm ");
      string option = "0";
      option = Console.ReadLine();

      if (option == "" | option == "1") {
        System.Diagnostics.Process StartProcess = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/c cargo run";
        StartProcess.StartInfo = startInfo;
        StartProcess.Start();
      }
      if (option == "2"){
        System.Diagnostics.Process RustInstall = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo RuststartInfo = new System.Diagnostics.ProcessStartInfo();
        RuststartInfo.FileName = "rustup-init.exe";
        RustInstall.StartInfo = RuststartInfo;
        RustInstall.Start();
      }
    }
  }
}
