using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DotSpace {
    class Program {

        static void StartProcess(string command, string args, string dir) {
            var ps = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = command,
                    Arguments = args,
                    UseShellExecute = false,
                    WorkingDirectory = dir
                }
            };
            ps.Start();
            ps.WaitForExit();
        }

        static void Main(string[] args) {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var dirInfo = new DirectoryInfo(home).GetDirectories(".*");
            var joined = dirInfo.Select(x => x.Name).Aggregate((a, b) => a + " " + b);
            StartProcess("du", "-hcs " + joined, home);
        }
    }
}
