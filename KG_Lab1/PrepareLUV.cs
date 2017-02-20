using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_Lab1
{
    class PrepareLUV
    {
        public static bool prepareLUV(String L, String u, String v)
        {
            TransformationLUVtoRGB trans = new TransformationLUVtoRGB(L, u, v);
            bool flag = true;
            int red = trans.getRed();
            int green = trans.getGreen();
            int blue = trans.getBlue();
            if (trans.getRed() < 0)
            {
                red = 0;
                flag = false;
            }
            if (trans.getGreen() < 0)
            {
                green = 0;
                flag = false;
            }
            if (trans.getBlue() < 0)
            {
                blue = 0;
                flag = false;
            }
            if (trans.getRed() > 255)
            {
                red = 255;
                flag = false;
            }
            if (trans.getGreen() > 255)
            {
                green = 255;
                flag = false;
            }
            if (trans.getBlue() > 255)
            {
                blue = 255;
                flag = false;
            }
            return flag;
        }
    }
}
