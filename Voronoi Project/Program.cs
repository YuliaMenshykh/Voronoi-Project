using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi_Project
{
    class Program
    {

        static void Main(string[] args)
        {
            //Planing image size = 1280 x 720
            //Test image size = 256 x 256

            Bitmap bitmap = new Bitmap(256, 256);


            RandPoint randPoint = new RandPoint();
            var res = randPoint.GetRandomColor();
            var res2 = randPoint.GetRandPoints();
            Console.WriteLine(res);
            Console.WriteLine(res2);


        }    
    }
}
