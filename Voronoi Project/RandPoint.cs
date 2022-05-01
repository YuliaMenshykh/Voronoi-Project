using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi_Project
{
    class RandPoint
    {
        //Planing image size = 1280 x 720
        //Test image size = 256 x 256

        const int imageSizeX = 256;
        const int imageSizeY = 256;

        static Random randomX = new Random();
        int MyX = randomX.Next(0, imageSizeX - 1);

        static Random randomY = new Random();
        int MyY = randomY.Next(0, imageSizeY - 1);

        static Random randomPointCount = new Random();
        int Count = randomPointCount.Next(3, 5);

        public Point[] GetRandPoints()
        {

            Point[] NewPoint = new Point[Count];
            for (int i = 0; i < Count; i++)
            {
                NewPoint[i] = new Point(MyX, MyY);
                Console.WriteLine(NewPoint[i]);
                
            }
            return NewPoint;

        }



        static Color[] colorArray = { Color.Azure, Color.Beige, Color.Blue,Color.Gray,Color.FloralWhite };
        public Color[] GetRandomColor()
        {
            var random = new Random();
            Color[] NewArray = new Color[Count];

            for (int i = 0; i < Count; i++)
            {
                NewArray[i] = colorArray[random.Next(colorArray.Length)];
                Console.WriteLine(NewArray[i]);
                // зробити сет піксель тут і додати сюди ж колір

            }
            return NewArray;
        }



       




    }
}
