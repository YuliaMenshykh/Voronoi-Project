using System;
using System.Threading;



namespace Voronoi_Project
{

    class Program
    {
       
        static void Main(string[] args)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            RunProcess runProcess = new RunProcess();
            
            runProcess.RunProcessing();
            Thread thread = new Thread(runProcess.Saver);
            thread.Start();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
           



        }    
    }
}
