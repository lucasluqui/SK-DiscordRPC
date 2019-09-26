using SK_DiscordRPC.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SK_DiscordRPC.Util
{
    class Parser
    {
        private static string logFile = Directory.GetCurrentDirectory() + "\\projectx.log";
        public static Whereabout parseWhereabout()
        {
            Whereabout w = new Whereabout();

            FileStream fs = new FileStream(logFile, FileMode.Open,
                    FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
            {
                string line = String.Empty;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Contains("moveTo"))
                    {
                        string rawWhereabout = line.Split('(')[1].Replace(')', '\0').Replace(' ', '\0').Replace('.', '\0');
                        string[] arrWhereabout = rawWhereabout.Split(',');
                        w.setIdent(arrWhereabout[0]);
                        //w.setLocId(arrWhereabout[1]);
                        //w.setSceneId(arrWhereabout[2]);
                    }
                }
            }
            return w;
        }

        public static string parseKnightName()
        {
            string knightName = null;
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle) && process.MainWindowTitle.Contains("Spiral"))
                {
                    knightName = process.MainWindowTitle.Split(new string[] {" - "}, StringSplitOptions.None)[1].Trim();
                }
            }
            return knightName;
        }

    }
}
