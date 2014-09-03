using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Windows.Forms;

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
            //DriveInfo[] allDrives = DriveInfo.GetDrives();

            //foreach (DriveInfo d in allDrives)
            //{
            //    Console.WriteLine("Drive {0}", d.Name);

            //    if ((d.Name).Contains("z"))
            //    {

            //        return true;

            //    }
              
            //} // efi partition not found

            return true;

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


        public static void LaunchUEFITool()
        {
            try
            {
                // create process instance
                Process myprocess = new Process();
                // set the file path which you want in process
                string startupPath =  Application.StartupPath;
              // myprocess.StartInfo.Arguments = "-s {8be4df61-93ca-11d2-aa0d-00e098032b8c} BootNext 0";
                myprocess.StartInfo.FileName = startupPath + @"\UEFIVariableTool.bat";
                // take the administrator permision to run process
                myprocess.StartInfo.Verb = "runas";
                // start process
                myprocess.Start();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                //Console.ReadKey();
            }

        }

        public static void LaunchDsikPart()
        {
            try
            {
                // create process instance
                Process myprocess = new Process();
                // set the file path which you want in process
                string startupPath = Application.StartupPath;
                // myprocess.StartInfo.Arguments = "-s {8be4df61-93ca-11d2-aa0d-00e098032b8c} BootNext 0";
                myprocess.StartInfo.FileName = startupPath + @"\UEFIVariableTool.bat";
                // take the administrator permision to run process
                myprocess.StartInfo.Verb = "runas";
                // start process
                myprocess.Start();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                //Console.ReadKey();
            }

        }
    }
}
