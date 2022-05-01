using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Voronoi_Project
{
    class RunProcess : RandPoint
    {
        protected RandPoint randPoint = new RandPoint();
        
        public void RunProcessing()
        {
            Bitmap bitmap = new Bitmap(256, 256);
            bitmap.SetPixel();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {

                }
            }
            

        }


    }
}
