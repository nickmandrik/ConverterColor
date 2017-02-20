using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_Lab1
{
    class TransformationRGBtoLUV
    {
        private double red;
        private double green;
        private double blue;

        private double L;
        private double u;
        private double v;

        // sRGB, Reference White - D65
        public static double[,] KoffsXYZ = {
                {0.4124564, 0.3575761, 0.1804375},
                {0.2126729, 0.7151522, 0.0721750},
                {0.0193339, 0.1191920, 0.9503041}
        };

        public TransformationRGBtoLUV(String red_t, String green_t, String blue_t)
        {
            if (red_t.Length == 0)
            {
                red_t = "0";
            }
            if (green_t.Length == 0)
            {
                green_t = "0";
            }
            if (blue_t.Length == 0)
            {
                blue_t = "0";
            }
            red = (double) Convert.ToInt32(red_t) / 255;     //RGB from 0 to 255
            green = (double) Convert.ToInt32(green_t) / 255;
            blue = (double) Convert.ToInt32(blue_t) / 255;

            double[] XYZ = new double[3];
            double[] rgb = {red, green, blue};
            calcXYZ(rgb, XYZ);
            
            double[] XYZn = new double [3];
            calcWhitePoint(XYZn);

            double Yn = XYZn[1]; 

            if (XYZ[1] / Yn > 0.008856)
            {
                L = 116 * Math.Pow(XYZ[1] / Yn, 1.0 / 3) - 16;
            }
            else
            {
                L = 903.3 * XYZ[1] / Yn;
            }

            double uk = 0;
            if (XYZ[0] != 0)
            {
                uk = 4 * XYZ[0] / (XYZ[0] + 15 * XYZ[1] + 3 * XYZ[2]);
            }

            double vk = 0;
            if (XYZ[1] != 0) 
            {
                vk = 9 * XYZ[1] / (XYZ[0] + 15 * XYZ[1] + 3 * XYZ[2]);
            }


            double un = 0;
            if (XYZn[0] != 0)
            {
                un = 4 * XYZn[0] / (XYZn[0] + 15 * XYZn[1] + 3 * XYZn[2]);
            }

            double vn = 0;
            if (XYZn[1] != 0)
            {
                vn = 9 * XYZn[1] / (XYZn[0] + 15 * XYZn[1] + 3 * XYZn[2]);
            }

            u = 13 * L * (uk - un);
            v = 13 * L * (vk - vn);
        }

        private void calcXYZ(double[] RGB, double[] XYZ)
        {
            for (int j = 0; j < 3; j++)
            {
                XYZ[j] = 0;
                for (int i = 0; i < 3; i++)
                {
                    XYZ[j] += RGB[i] * KoffsXYZ[j, i];
                }
            }
        }

        public static void calcWhitePoint(double[] XYZn)
        {
            double[] whitePointRGB = { 1, 1, 1 };

            for (int j = 0; j < 3; j++)
            {
                XYZn[j] = 0;
                for (int i = 0; i < 3; i++)
                {
                    XYZn[j] += whitePointRGB[i] * KoffsXYZ[j, i];
                }
            }
        }

        public double getL()
        {
            return (double) (L);
        }

        public double getU()
        {
            return (double) (u);
        }

        public double getV()
        {
            return (double) (v);
        }
    }
}
