using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi_Project
{
    class RunProcess : RandPoints
    {
        static RandPoints randPoint = new RandPoints();

        protected Point[] GetPoints = randPoint.GetRandPoints();
        protected Color[] GetColor = randPoint.GetRandomColor();
        

        
        public void RunProcessing()
        {
            Bitmap bitmap = new Bitmap(1024, 1024);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    double[] allDistanse = new double[GetPoints.Length];

                    for (int i = 0; i < GetPoints.Length; i++)
                    {
                        allDistanse[i] = Math.Sqrt(Math.Pow((x - GetPoints[i].X), 2) + Math.Pow((y - GetPoints[i].Y),2));                        
                    }

                    double[] copied = (double[])allDistanse.Clone();
                    Array.Sort(copied);

                    double minVValue = allDistanse.Min();
                    int index = Array.IndexOf(allDistanse, minVValue);

                    int border = 1;
                    if (copied[1] - copied[0] <= border)
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, GetColor[index]);
                    }
                }
            }
            bitmap.Save("C:\\Voronoi Project\\Voronoi Project\\myVoronoi.png", System.Drawing.Imaging.ImageFormat.Png);

        }

    }
}
