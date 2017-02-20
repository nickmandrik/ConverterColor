using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_Lab1
{
    class TransformationHLStoRGB
    {
        private int red;
        private int green;
        private int blue;

        private double L;
        private double H;
        private double S;

        public TransformationHLStoRGB(String H_t, String L_t, String S_t)
        {
            H = Convert.ToDouble(H_t) / 360;
            L = Convert.ToDouble(L_t) / 100;
            S = Convert.ToDouble(S_t) / 100;

            if ( S == 0 )                                //HSL from 0 to 1
            {
                red = (int)(L * 255);                    //RGB results from 0 to 255
                green = (int)(L * 255);
                blue = (int)(L * 255);
            }
            else
            {
                double temp2;
                if ( L < 0.5 ) {
                    temp2 = L * ( 1 + S );
                }
                else  {
                    temp2 = ( L + S ) - ( S * L );
                }

                double temp1 = 2 * L - temp2;

                red = (int)(255 * Hue_2_RGB( temp1, temp2, H + ( 1.0 / 3 ) ));
                green = (int)(255 * Hue_2_RGB(temp1, temp2, H));
                blue = (int)(255 * Hue_2_RGB(temp1, temp2, H - (1.0 / 3)));
            }
        }

        private double Hue_2_RGB( double v1, double v2, double vH )             //Function Hue_2_RGB
        {
           if ( vH < 0 ) {
               vH += 1;
           }
           if ( vH > 1 ) {
               vH -= 1;
           }
           if ( ( 6 * vH ) < 1 ) {
               return ( v1 + ( v2 - v1 ) * 6 * vH );
           }
           if ( ( 2 * vH ) < 1 ) {
               return ( v2 );
           }
           if ( ( 3 * vH ) < 2 ) {
               return ( v1 + ( v2 - v1 ) * ( ( 2.0 / 3 ) - vH ) * 6 );
           }
           return (v1);
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
