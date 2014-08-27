using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Collections;

namespace HadesTestLauncher
{
    class UtitlityFunctions
    {
        public static ArrayList TestList;

        public static bool RunBatchFile(string Batchfile)
        {
            int exitCode;
            System.Diagnostics.ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + Batchfile);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();

            return true;

        }

        public static bool CheckEfi()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);

                if ((d.Name).Contains("b"))
                {

                    return true;

                }
              
            } // efi partition not found

            return false;

        }


        public static void LoadTestFiles(String FileName)
        {
            int counter = 0;
            string line;
            TestList = new ArrayList();
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(FileName);
            
            //populate the test list on the form
            while ((line = file.ReadLine()) != null)
            {
                TestList.Add(line);
            }

            file.Close();


        }
    }
}
