﻿using SK_DiscordRPC.Data;
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
                        
                        // Checks for guild halls
                        if (arrWhereabout[0].Contains("4:"))
                        {
                            w.setIdent("4:4");
                        }
                       
                        else
                        {
                            w.setIdent(arrWhereabout[0]);
                        }
                    }

                    if (line.Contains("ArenaSceneConfig"))
                    { 
                        string rawArenaWhereabout = line.Split('%')[1].Split('/')[0];
                        Console.WriteLine(rawArenaWhereabout);
                        w.setIdent(rawArenaWhereabout);
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
                    try
                    {
                        knightName = process.MainWindowTitle.Split(new string[] { " - " }, StringSplitOptions.None)[1].Trim();
                    }
                    catch { }
                    
                }
            }
            return knightName;
        }

        public static bool isGameRunning()
        {
            bool running = false;
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle) && process.MainWindowTitle.Contains("Spiral Knights"))
                {
                    running = true;
                }
            }
            return running;
        }
    }
}
