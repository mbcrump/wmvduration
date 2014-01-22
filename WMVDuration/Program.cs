using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace WMVDuration
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalSeconds = TimeSpan.Zero;

            if (args.Length == 0)
                Console.WriteLine("No Path Entered");
            else
            {
                foreach (var file in Directory.EnumerateFiles(args[0], "*.wmv", SearchOption.AllDirectories))
                {
                    WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();
                    IWMPMedia mediaInfo = wmp.newMedia(file);
                    TimeSpan ts = TimeSpan.FromSeconds(mediaInfo.duration);
                    totalSeconds = totalSeconds.Add(ts);
                }

                string totalTime = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                    totalSeconds.Hours,
                    totalSeconds.Minutes,
                    totalSeconds.Seconds,
                    totalSeconds.Milliseconds);

                Console.WriteLine(totalTime);
            }
            Console.ReadKey();
        }
    }
}