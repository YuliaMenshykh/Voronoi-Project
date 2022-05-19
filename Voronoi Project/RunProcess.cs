using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;


namespace Voronoi_Project
{
    class RunProcess : RandPoints
    {
        static Random random = new Random();


        private static int _imageSizeX =300;
        private static int _imageSizeY = 300;
        static int RandCountOFPoint = random.Next(60, 80);

        static RandPoints randPoint = new RandPoints(_imageSizeX, _imageSizeY, RandCountOFPoint);

        protected System.Windows.Point[] GetPoints = randPoint.GetRandPoints();
        protected Color[] GetColor = randPoint.GetRandomColor();

        int moveCount = 20;
        int border = 8;

        Bitmap bitmap = new Bitmap(_imageSizeX, _imageSizeY);
        System.Windows.Point MidPoint = new System.Windows.Point(_imageSizeX / 2, _imageSizeY / 2);
        

        public void RunProcessing()
        {
            Vector[] vector = new Vector[GetPoints.Length];
            System.Windows.Point[] pointsResult = new System.Windows.Point[GetPoints.Length];
            double[] allDistanse = new double[GetPoints.Length];
           

            for (int g = 0; g < moveCount; g++)
            {
                for (int i = 0; i < GetPoints.Length; i++)
                {
                    vector[i] = new Vector(GetPoints[i].X - MidPoint.X, GetPoints[i].Y - MidPoint.Y);
                    vector[i].Normalize();
                    vector[i].Negate();
                    vector[i] = vector[i] * g * 10;
                }
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int i = 0; i < GetPoints.Length; i++)
                        {
                            allDistanse[i] = Math.Sqrt(Math.Pow((x - GetPoints[i].X+vector[i].X), 2) + Math.Pow((y - GetPoints[i].Y + vector[i].Y), 2));

                            pointsResult[i] = Vector.Add( vector[i] , GetPoints[i]);

                        }
                        double[] copied = (double[])allDistanse.Clone();
                        
                        Array.Sort(copied);

                        double minVValue = allDistanse.Min();

                        int index = Array.IndexOf(allDistanse, minVValue);

                        if (copied[1] - copied[0] <= border)
                        {
                            bitmap.SetPixel(x, y, Color.White);
                        }
                        else
                        {
                            bitmap.SetPixel(x, y, GetColor[index]);
                        }
                    }
                
                }

                //bitmap.Save($"C:\\Voronoi Project\\Voronoi Project\\myVoronoi{g}.png", ImageFormat.Png);
                bitmap.Save($"C:\\Voronoi Project\\Voronoi Project\\myVoronoi{g}.Gif", ImageFormat.Gif);

               
            }

  

        }
        public void Saver()
        {
            Bitmap[] gifImageArray = new Bitmap[moveCount];

            for (int i = 0; i < moveCount; i++)
            {
                gifImageArray[i] = (Bitmap)Image.FromFile($"C:\\Voronoi Project\\Voronoi Project\\myVoronoi{i}.gif");
            }

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
                const int PropertyTagFrameDelay = 0x5100;
                const int propertyTagFrameloop = 0x5101;
                int unitBybtes = 4;

                PropertyItem frameDelay = gifImageArray[1].GetPropertyItem(PropertyTagFrameDelay);
                PropertyItem loopPropertyItem = gifImageArray[1].GetPropertyItem(propertyTagFrameloop);

                var encoderParams1 = new EncoderParameters(1)
                {
                    Param = { [0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame) }
                };

                Bitmap animatedGif = gifImageArray[1];

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


                for (int i = 0; i < moveCount; i++)
                {
                    animatedGif.SaveAdd(gifImageArray[i], encoderParamsN);
                }


                var encoderParamsFlush = new EncoderParameters(1)
                {
                    Param = { [0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush) }
                };

                animatedGif.SaveAdd(encoderParamsFlush);
            }

        }

    }
}
