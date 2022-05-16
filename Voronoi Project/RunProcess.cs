using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Voronoi_Project
{
    class RunProcess : RandPoints
    {

        private static int _imageSizeX = 520;
        private static int _imageSizeY = 520;

        static RandPoints randPoint = new RandPoints(_imageSizeX, _imageSizeY);

        protected Point[] GetPoints = randPoint.GetRandPoints();
        protected Color[] GetColor = randPoint.GetRandomColor();
        

        
        public void RunProcessing()
        {
            Bitmap bitmap = new Bitmap(_imageSizeX, _imageSizeY);


            int moveCount = 9;
            for (int g = 0; g < moveCount; g++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        double[] allDistanse = new double[GetPoints.Length];

                        for (int i = 0; i < GetPoints.Length; i++)
                        {
                            allDistanse[i] = Math.Sqrt(Math.Pow((x - GetPoints[i].X+g), 2) + Math.Pow((y - GetPoints[i].Y), 2));
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

                //bitmap.Save($"C:\\Voronoi Project\\Voronoi Project\\myVoronoi{g}.png", System.Drawing.Imaging.ImageFormat.Png);
                bitmap.Save($"C:\\Voronoi Project\\Voronoi Project\\myVoronoi{g}.Gif", System.Drawing.Imaging.ImageFormat.Gif);

               
            }




            Bitmap gifImage = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi0.gif");
            Bitmap gifImage1 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi1.gif");
            Bitmap gifImage2 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi2.gif");
            Bitmap gifImage3 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi3.gif");
            Bitmap gifImage4 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi4.gif");
            Bitmap gifImage5 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi5.gif");
            Bitmap gifImage6 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi6.gif");
            Bitmap gifImage7 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi7.gif");
            Bitmap gifImage8 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi8.gif");
            Bitmap gifImage9 = (Bitmap)Image.FromFile(@"C:\\Voronoi Project\\Voronoi Project\\myVoronoi9.gif");
            ImageCodecInfo gifEncroder = null;
            foreach (ImageCodecInfo item in ImageCodecInfo.GetImageEncoders())
            {
                if (item.MimeType == "image/gif")
                {
                    gifEncroder = item;

                    break;
                }
            }

            if (gifEncroder == null)
            {
                Console.WriteLine("Gif encoder is null!");

                return;
            }


            using (var stream = new FileStream(@"C:\Voronoi Project\Voronoi Project\animation.gif", FileMode.Create))
            {
                int PropertyTagFrameDelay = 0x5100;
                int propertyTagFrameloop = 0x5101;
                int unitBybtes = 4;

                PropertyItem frameDelay = gifImage.GetPropertyItem(PropertyTagFrameDelay);
                PropertyItem loopPropertyItem = gifImage.GetPropertyItem(propertyTagFrameloop);

                var encoderParams1 = new EncoderParameters(1)
                {
                    Param = { [0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame) }
                };

                Bitmap animatedGif = gifImage;

                frameDelay.Len = 3 * unitBybtes;
                frameDelay.Value = new byte[3 * unitBybtes];
                loopPropertyItem.Value = BitConverter.GetBytes((ushort)0);

                animatedGif.SetPropertyItem(frameDelay);
                animatedGif.SetPropertyItem(loopPropertyItem);

                animatedGif.Save(stream, gifEncroder, encoderParams1);

                var encoderParamsN = new EncoderParameters(1)
                {
                    Param = { [0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionTime) }
                };

                animatedGif.SaveAdd(gifImage1, encoderParamsN);
                animatedGif.SaveAdd(gifImage2, encoderParamsN);

                var encoderParamsFlush = new EncoderParameters(1)
                {
                    Param = { [0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush) }
                };

                animatedGif.SaveAdd(encoderParamsFlush);
            }

            var test = ImageAnimator.CanAnimate(new Bitmap(@"C:\Voronoi Project\Voronoi Project\animation.gif"));

        }

       
    }
}
