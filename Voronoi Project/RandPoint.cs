using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Color[] colorArray = {Color.FromArgb(255, 227, 167,167), Color.FromArgb(255, 173, 31, 52), Color.FromArgb(255, 240, 113, 98),
            Color.FromArgb(255, 198, 55,45), Color.FromArgb(255, 200, 59,102), Color.FromArgb(255, 212, 118,110),
            Color.FromArgb(255, 200, 89,157), Color.FromArgb(255, 228, 200,220), Color.FromArgb(255, 247, 194,126),
            Color.FromArgb(255, 244, 169,114), Color.FromArgb(255, 243, 232,204), Color.FromArgb(255, 177, 194,126),
            Color.FromArgb(255, 97, 107,47), Color.FromArgb(255, 155, 183,168), Color.FromArgb(255, 97, 131,117)};
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
