using System;
using System.Diagnostics;
using System.IO;

namespace ImageResizer
{
    class Program
    {
        static void Main()
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output");

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            var before = 0D;
            var after = 0D;
            var diff = 0D;

            for (int i = 1; i <= 5; i++)
            {
                sw.Restart();
                imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
                sw.Stop();
                before = sw.ElapsedMilliseconds;
                Console.WriteLine($"花費時間: {before} ms");

                sw.Restart();
                imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
                sw.Stop();
                after = sw.ElapsedMilliseconds;
                diff = (before - after) / before * 100;
                Console.WriteLine($"Async花費時間:  {after} ms, {diff:N2}% ... {i}");
            }
        }
    }
}
