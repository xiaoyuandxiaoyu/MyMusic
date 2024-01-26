using System;
using System.Diagnostics;
namespace MyMusic.Resource
{
    public class Performance
    {
        
        public static void Get()
        {
                // 获取系统CPU利用率
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                float cpuUsage = cpuCounter.NextValue();
                Thread.Sleep(1000);
                cpuUsage = cpuCounter.NextValue();

                Console.WriteLine("CPU 使用率: {0}%", cpuUsage);

                // 获取系统内存使用情况
                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                float availableMB = ramCounter.NextValue();

                Console.WriteLine("系统可用内存：{0} MB", availableMB);

                // 获取硬盘使用情况
                /*foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        //Console.WriteLine("{0} 硬盘使用情况：", drive.Name);
                        //Console.WriteLine("总容量：{0} GB", drive.TotalSize / 1024 / 1024 / 1024);
                        //Console.WriteLine("已使用容量：{0} GB", (drive.TotalSize - drive.AvailableFreeSpace) / 1024 / 1024 / 1024);
                        //Console.WriteLine("可用容量：{0} GB", drive.AvailableFreeSpace / 1024 / 1024 / 1024);
                    }
                }*/
        }
    }    
}
