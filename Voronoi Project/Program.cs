using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;


namespace Voronoi_Project
{
    class Program
    {
        static string DBfilePath { get; set; }
        static void Main(string[] args)
        {
            //Planing image size = 1280 x 720
            //Test image size = 256 x 256



            //RandPoints randPoint = new RandPoints();
            //var res = randPoint.GetRandomColor();
            //var res2 = randPoint.GetRandPoints();
            //Console.WriteLine(res);
            //Console.WriteLine(res2);



            //string FileDBName = "myVoron.jpg";
            //string fileFolder = Path.GetFullPath(@"C:\Voronoi Project\Voronoi Project");
            //DBfilePath = fileFolder + "\\" + FileDBName;


            //if (File.Exists(DBfilePath) == false)
            //{
            //    var file = File.Create(DBfilePath);
            //    file.Close();
            //}


            RunProcess runProcess = new RunProcess();
            runProcess.RunProcessing();

        }    
    }
}
