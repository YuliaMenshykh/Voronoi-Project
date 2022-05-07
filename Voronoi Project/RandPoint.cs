using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi_Project
{
    class RandPoints
    {
        //Planing image size = 1280 x 720
        //Test image size = 256 x 256

        const int imageSizeX = 1024;
        const int imageSizeY = 1024;

        static Random random = new Random();

        static int RandCount = random.Next(60,80);
    

        public Point[] GetRandPoints()
        {
            Point[] NewPoint = new Point[RandCount];
            for (int i = 0; i < RandCount; i++)
            {
                int MyX = random.Next(0, imageSizeX - 1);
                int MyY = random.Next(0, imageSizeY - 1);
                NewPoint[i] = new Point(MyX, MyY);
                Console.WriteLine(NewPoint[i]);
                
            }
            return NewPoint;

        }



       
        public Color[] GetRandomColor()
        {
            Color[] colorArray = { Color.Azure, Color.Beige, Color.DarkKhaki, Color.Gray, Color.FloralWhite,
                Color.Bisque, Color.Cornsilk, Color.FromArgb(255, 125, 50, 70), Color.FromArgb(255, 93, 138, 168),
                Color.FromArgb(255, 255, 191, 0), Color.FromArgb(255, 153, 102, 204), Color.FromArgb(255, 205, 149, 117), 
                Color.FromArgb(255,162,162,208) ,Color.FromArgb(255,204,85,0), Color.FromArgb(255,95,158,160) };
            Color[] NewArray = new Color[RandCount];

            for (int i = 0; i < RandCount; i++)
            {
                NewArray[i] = colorArray[random.Next(colorArray.Length)];
                Console.WriteLine(NewArray[i]);

            }
            return NewArray;
        }



    }
}
