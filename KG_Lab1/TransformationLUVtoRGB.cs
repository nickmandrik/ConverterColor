using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_Lab1
{
    class TransformationLUVtoRGB
    {
        private int red;
        private int green;
        private int blue;

        private double L;
        private double u;
        private double v;

        // sRGB, Reference White - D65
        public static double[,] KoffsXYZ = {
                {0.4124564, 0.3575761, 0.1804375},
                {0.2126729, 0.7151522, 0.0721750},
                {0.0193339, 0.1191920, 0.9503041}
        };

        public static double[,] KoffsObrXYZ = {
                { 3.2404542, -1.5371385, -0.4985314},
                {-0.9692660,  1.8760108,  0.0415560},
                { 0.0556434, -0.2040259,  1.0572252}
        };

        public TransformationLUVtoRGB(String L_t, String U_t, String V_t)
        {
            L = Convert.ToDouble(L_t);
            u = Convert.ToDouble(U_t);
            v = Convert.ToDouble(V_t);

            double[] XYZn = new double[3];
            calcWhitePoint(XYZn);

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

            double uk = un;
            double vk = vn;
            if (L != 0)
            {
                uk += u / (13 * L);
                vk += v / (13 * L);
            }
            

            double[] XYZ = new double[3];
            if (L <= 8)
            {
                XYZ[1] = XYZn[1] * L * Math.Pow(3.0 / 29, 3);
            }
            else
            {
                XYZ[1] = XYZn[1] * Math.Pow((L + 16) / 116, 3);
            }
            XYZ[0] = XYZ[1] * 9 * uk / (4 * vk);
            XYZ[2] = XYZ[1] * (12.0 - 3 * uk - 20 * vk) / (4 * vk);

            double[] RGB = new double[3];
            calcRGB(XYZ, RGB);

            red = (int) (RGB[0]*255);
            green = (int)(RGB[1]*255);
            blue = (int)(RGB[2]*255);
        }

        private void calcRGB(double[] XYZ, double[] RGB)
        {
            for (int j = 0; j < 3; j++)
            {
                RGB[j] = 0;
                for (int i = 0; i < 3; i++)
                {
                    RGB[j] += XYZ[i] * KoffsObrXYZ[j, i];
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

        public int getRed()
        {
            return red;
        }

        public int getGreen()
        {
            return green;
        }

        public int getBlue()
        {
            return blue;
        }
    }
}
