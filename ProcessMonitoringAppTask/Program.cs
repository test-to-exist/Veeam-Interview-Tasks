using System.Diagnostics;
//using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> log = new List<string>();
        DateTime start = DateTime.UtcNow, end = DateTime.UtcNow;
        TimeSpan timeToKill = new TimeSpan(0, 0, 20); // By default it should be in minutes
        TimeSpan monitoringFrequency = new TimeSpan(0, 0, 5); // By default it should be in minutes
        string processName = "notepad";

        while (true)
        {
            //Process.GetProcesses()
            Process[] processesList = Process.GetProcessesByName(processName);
            if (processesList.Length == 0)
                Console.WriteLine("nothing");
            else
                Console.WriteLine("run");
            
            Thread.Sleep(monitoringFrequency);
            foreach (Process process in processesList)
            {
                Console.WriteLine("Process: {0} ID: {1}", process.ProcessName, process.Id);
            }

            end = DateTime.UtcNow;
            TimeSpan monitorRunningTime = end - start;
            if (monitorRunningTime >= timeToKill && processesList.Length >0)
            {
                Process? runningProcess = processesList.FirstOrDefault(p => p.ProcessName == processName);
                if(runningProcess != null)
                {
                    Console.WriteLine($"Killing process: {runningProcess.ProcessName}");
                    //processesList = processesList.Where(p => p.Id != runningProcess.Id).ToArray();
                    log.Add($"Process: {runningProcess.ProcessName} killed at {DateTime.Now}");
                    runningProcess.Kill();            
                }
                start = DateTime.UtcNow;
            }
        }
    }
}