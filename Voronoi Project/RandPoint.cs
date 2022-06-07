using System;
using System.Drawing;
using System.Windows;

namespace Voronoi_Project
{
    class RandPoints
    {
        private int imageSizeX;
        private int imageSizeY;
        private int countOfPoint;
        static Random random = new Random();
        public RandPoints()
        {

        }
        public RandPoints(int _imageSizeX, int _imageSizeY, int _countOfPoint)
        {
            imageSizeX = _imageSizeX;
            imageSizeY = _imageSizeY;
            countOfPoint = _countOfPoint;
        }


        public System.Windows.Point[] GetRandPoints()
        {
            System.Windows.Point[] NewPoint = new System.Windows.Point[countOfPoint];
            for (int i = 0; i < countOfPoint; i++)
            {
                int MyX = random.Next(0, imageSizeX - 1);
                int MyY = random.Next(0, imageSizeY - 1);
                NewPoint[i] = new System.Windows.Point(MyX, MyY);
                Console.WriteLine(NewPoint[i]);
                
            }
            return NewPoint;

        }



       
        public Color[] GetRandomColor()
        {
            Color[] colorArray = {Color.FromArgb(255, 248, 178,188), Color.FromArgb(255, 245, 198, 178),Color.FromArgb(255, 241, 223, 199),
            Color.FromArgb(255, 242, 236,222), Color.FromArgb(255, 185, 189, 166), Color.FromArgb(255, 241, 194, 202),
            Color.FromArgb(255, 221, 179,163), Color.FromArgb(255, 243, 204, 145), Color.FromArgb(255, 232, 237, 197),
            Color.FromArgb(255, 199, 225,224), Color.FromArgb(255, 250, 209, 215), Color.FromArgb(255, 224, 150, 111),
            Color.FromArgb(255, 214, 164,91), Color.FromArgb(255, 185, 189, 166), Color.FromArgb(255, 157, 207, 206),
            Color.FromArgb(255, 253, 227,236), Color.FromArgb(255, 237, 173, 145), Color.FromArgb(255, 214, 167, 51),
            Color.FromArgb(255, 152, 160,136), Color.FromArgb(255, 194, 219, 215), Color.FromArgb(255, 246, 225, 220),
            Color.FromArgb(255, 236, 147,107), Color.FromArgb(255, 182, 128, 64), Color.FromArgb(255, 98, 103, 62),
            Color.FromArgb(255, 72, 136, 138), Color.FromArgb(255, 242, 207, 185),Color.FromArgb(255, 242, 226, 190),
            Color.FromArgb(255, 185, 160, 80), Color.FromArgb(255, 198, 202, 151), Color.FromArgb(255, 146, 193, 183),
            Color.FromArgb(255, 227, 167,167), Color.FromArgb(255, 173, 31, 52), Color.FromArgb(255, 240, 113, 98),
            Color.FromArgb(255, 198, 55,45), Color.FromArgb(255, 200, 59,102), Color.FromArgb(255, 212, 118,110),
            Color.FromArgb(255, 200, 89,157), Color.FromArgb(255, 228, 200,220), Color.FromArgb(255, 247, 194,126),
            Color.FromArgb(255, 244, 169,114), Color.FromArgb(255, 243, 232,204), Color.FromArgb(255, 177, 194,126),
            Color.FromArgb(255, 97, 107,47), Color.FromArgb(255, 155, 183,168), Color.FromArgb(255, 97, 131,117)
            };
            Color[] NewArray = new Color[countOfPoint];

            for (int i = 0; i < countOfPoint; i++)
            {
                NewArray[i] = colorArray[random.Next(colorArray.Length)];
                Console.WriteLine(NewArray[i]);

            }
            return NewArray;
        }



    }
}
