using System;
using System.Diagnostics;
using System.Management;

internal class Program
{
    private static void Main(string[] args)
    {
        string processName = args.Length < 1 ? "notepad" : args[0];
        TimeSpan timeToKill =
            args.Length < 2 ? new TimeSpan(0, 5, 0) : new TimeSpan(0, int.Parse(args[1]), 0);
        TimeSpan monitoringFrequency =
            args.Length < 3 ? new TimeSpan(0, 1, 7) : new TimeSpan(0, int.Parse(args[2]), 0);

        List<string> log = new List<string>();
        DateTime start = DateTime.UtcNow, end = DateTime.UtcNow, monitoringFrequencyStart = DateTime.UtcNow;
        Process[] processesList = new Process[0];
        bool appRunning = true;
        bool firstRun = true;
        Console.WriteLine($"Starting to monitor process: {processName}");
        do
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == 'q' || key.KeyChar == 'Q')
                {
                    Console.WriteLine("The Master has decided to terminate the program, exiting");
                    appRunning = false;
                    break;
                }
            }

            if (firstRun || monitoringFrequency <= (DateTime.UtcNow - monitoringFrequencyStart))
            {
                processesList = Process.GetProcessesByName(processName);
                if (processesList.Length == 0)
                    Console.WriteLine("nothing");
                else
                    Console.WriteLine("run");
                monitoringFrequencyStart = DateTime.UtcNow;
                firstRun = false;
            }

            end = DateTime.UtcNow;
            TimeSpan monitorRunningTime = end - start;
            if (monitorRunningTime >= timeToKill && processesList.Length > 0)
            {
                Process[] runningProcesses = processesList.Where(p => p.ProcessName == processName).ToArray();
                if(runningProcesses.Length > 0)
                {
                    Console.WriteLine($"Killing process: {processName}");
                }

                foreach (Process process in runningProcesses)
                {
                    try
                    {
                        process.Kill(true);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Exception occurred {ex.Message} and stack trace: {ex.StackTrace}");
                    }
                }
                Console.WriteLine($"Process: {processName} terminated at {DateTime.Now} Rest in Peace");
                log.Add($"Process: {processName} terminated at {DateTime.Now} Rest in Peace");
                start = DateTime.UtcNow;
            }
        }
        while (appRunning);
    }
}