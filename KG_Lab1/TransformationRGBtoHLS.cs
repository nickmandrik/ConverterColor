using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_Lab1
{
    class TransformationRGBtoHLS
    {
        private double red;
        private double green;
        private double blue;

        private double L;
        private double H;
        private double S;

        public TransformationRGBtoHLS(String red_t, String green_t, String blue_t)
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

            double min = Math.Min(Math.Min(red, green), blue);      //Min. value of RGB
            double max = Math.Max(Math.Max(red, green), blue);      //Max. value of RGB
            double del_Max = max - min;                             //Delta RGB value

            L = ( max + min ) / 2;

            //This is a gray, no chroma...
            H = 0;
            S = 1;                                                  //HSL results from 0 to 1
            
            if ( del_Max != 0 )                                     //Chromatic data...
            {     
                if ( L < 0.5 ) {
                    S = del_Max / ( max + min );
                }
                else {
                    S = del_Max / ( 2 - max - min );
                }

                double del_R = ( ( ( max - red ) / 6 ) + ( del_Max / 2 ) ) / del_Max;
                double del_G = ( ( ( max - green ) / 6 ) + ( del_Max / 2 ) ) / del_Max;
                double del_B = ( ( ( max - blue ) / 6 ) + ( del_Max / 2 ) ) / del_Max;

                if( red == max ) {
                    H = del_B - del_G;
                }
                else if ( green == max ) {
                    H = ( 1.0 / 3 ) + del_R - del_B;
                }
                else if ( blue == max ) {
                    H = ( 2.0 / 3 ) + del_G - del_R;
                }

                if ( H < 0 )  {
                    H += 1;
                }
                if ( H > 1 ) {
                    H -= 1;
                }
            }
        }

        public double getH()
        {
            return (360*H);
        }

        public double getS()
        {
            return (100*S);
        }

        public double getL()
        {
            return (100 * L);
        }
    }
}
