using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_Lab1
{
    class TransformationCMY
    {
        // For CMY
        public static String getCMYbyRGB(String color)
        {
            int colRGB = 0;
            if (color.Length != 0)
            {
                colRGB = Convert.ToInt32(color);
            }
            double colCMY = 1 - ((double)colRGB / 255);
            return Convert.ToString(colCMY);
        }

        // For CMY
        public static String getRGBbyCMY(String color)
        {
            double colCMY = 0;
            if (color.Length != 0)
            {
                colCMY = Convert.ToDouble(color);
            }
            int colRGB = (int)((1 - colCMY) * 255);
            return Convert.ToString(colRGB);
        }

        // For CMY
        public static int reSizeCMY(String color)
        {
            double colCMY = Convert.ToDouble(color);
            int col = (int)(colCMY * 255);
            return col;
        }

        // For CMY
        public static String reSizeCMY(int col)
        {
            double colCMY = (double)col / 255;
            return Convert.ToString(colCMY);
        }
    }
}
