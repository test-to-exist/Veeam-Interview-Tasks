using System;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> log = new List<string>();
        DateTime start = DateTime.UtcNow, end = DateTime.UtcNow, monitoringFrequencyStart = DateTime.UtcNow;
        TimeSpan timeToKill = new TimeSpan(0, 0, 69); // By default it should be in minutes
        TimeSpan monitoringFrequency = new TimeSpan(0, 0, 7); // By default it should be in minutes
        string processName = "notepad";
        Process[] processesList = new Process[0];

        bool appRunning = true;
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

            if (monitoringFrequency <= (DateTime.UtcNow - monitoringFrequencyStart))
            {
                processesList = Process.GetProcessesByName(processName);
                if (processesList.Length == 0)
                    Console.WriteLine("nothing");
                else
                    Console.WriteLine("run");
                monitoringFrequencyStart = DateTime.UtcNow;
            }

            end = DateTime.UtcNow;
            TimeSpan monitorRunningTime = end - start;
            if (monitorRunningTime >= timeToKill && processesList.Length > 0)
            {
                Process? runningProcess = processesList.FirstOrDefault(p => p.ProcessName == processName);
                if (runningProcess != null)
                {
                    Console.WriteLine($"Killing process: {runningProcess.ProcessName}");
                    log.Add($"Process: {runningProcess.ProcessName} killed at {DateTime.Now}");
                    runningProcess.Kill();
                }
                start = DateTime.UtcNow;
            }
        }
        while (appRunning);
    }
}