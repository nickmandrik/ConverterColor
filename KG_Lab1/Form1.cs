using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_Lab1
{
    public partial class ChooserColor : Form
    {
        public ChooserColor()
        {
            InitializeComponent();
        }

        // For HLS
        private void setHLS()
        {
            TransformationRGBtoHLS trans = new TransformationRGBtoHLS(textBoxRed.Text, 
                textBoxGreen.Text, textBoxBlue.Text);
            textBoxHue.Text = Convert.ToString(trans.getH());
            textBoxLightness.Text = Convert.ToString(trans.getL());
            textBoxSaturation.Text = Convert.ToString(trans.getS());
            trackBarHue.Value = (int) Convert.ToDouble(textBoxHue.Text);
            trackBarSaturation.Value = (int) Convert.ToDouble(textBoxSaturation.Text);
            trackBarLightness.Value = (int) Convert.ToDouble(textBoxLightness.Text);
        }

        // For HLS
        private void setRGBFromHLS()
        {
            TransformationHLStoRGB trans = new TransformationHLStoRGB(textBoxHue.Text,
                textBoxLightness.Text, textBoxSaturation.Text);

            textBoxRed.TextChanged -= textBoxRed_TextChanged;
            textBoxGreen.TextChanged -= textBoxGreen_TextChanged;
            textBoxBlue.TextChanged -= textBoxBlue_TextChanged;
            trackBarRed.Scroll -= trackBarRed_Scroll;
            trackBarGreen.Scroll -= trackBarGreen_Scroll;
            trackBarBlue.Scroll -= trackBarBlue_Scroll;

            textBoxRed.Text = Convert.ToString(trans.getRed());
            textBoxGreen.Text = Convert.ToString(trans.getGreen());
            textBoxBlue.Text = Convert.ToString(trans.getBlue());
            trackBarRed.Value = trans.getRed();
            trackBarGreen.Value = trans.getGreen();
            trackBarBlue.Value = trans.getBlue();

            textBoxRed.TextChanged += textBoxRed_TextChanged;
            textBoxGreen.TextChanged += textBoxGreen_TextChanged;
            textBoxBlue.TextChanged += textBoxBlue_TextChanged;
            trackBarRed.Scroll += trackBarRed_Scroll;
            trackBarGreen.Scroll += trackBarGreen_Scroll;
            trackBarBlue.Scroll += trackBarBlue_Scroll;
        }

        // For CMY
        private void setCMYFromRGB()
        {
            TransformationHLStoRGB trans = new TransformationHLStoRGB(textBoxHue.Text,
                textBoxLightness.Text, textBoxSaturation.Text);

            trackBarCyan.Scroll -= trackBarCyan_Scroll;
            trackBarMagenta.Scroll -= trackBarMagenta_Scroll;
            trackBarYellow.Scroll -= trackBarYellow_Scroll;

            textBoxCyan.Text = TransformationCMY.getCMYbyRGB(textBoxRed.Text);
            textBoxMagenta.Text = TransformationCMY.getCMYbyRGB(textBoxGreen.Text);
            textBoxYellow.Text = TransformationCMY.getCMYbyRGB(textBoxBlue.Text);
            trackBarCyan.Value = TransformationCMY.reSizeCMY(textBoxCyan.Text);
            trackBarMagenta.Value = TransformationCMY.reSizeCMY(textBoxMagenta.Text);
            trackBarYellow.Value = TransformationCMY.reSizeCMY(textBoxYellow.Text);

            trackBarCyan.Scroll += trackBarCyan_Scroll;
            trackBarMagenta.Scroll += trackBarMagenta_Scroll;
            trackBarYellow.Scroll += trackBarYellow_Scroll;
        }

        // For HLS
        private void setRGBFromLUV(TransformationLUVtoRGB trans)
        {
            textBoxRed.TextChanged -= textBoxRed_TextChanged;
            textBoxGreen.TextChanged -= textBoxGreen_TextChanged;
            textBoxBlue.TextChanged -= textBoxBlue_TextChanged;
            trackBarRed.Scroll -= trackBarRed_Scroll;
            trackBarGreen.Scroll -= trackBarGreen_Scroll;
            trackBarBlue.Scroll -= trackBarBlue_Scroll;

            textBoxRed.Text = Convert.ToString(trans.getRed());
            textBoxGreen.Text = Convert.ToString(trans.getGreen());
            textBoxBlue.Text = Convert.ToString(trans.getBlue());
            trackBarRed.Value = trans.getRed();
            trackBarGreen.Value = trans.getGreen();
            trackBarBlue.Value = trans.getBlue();

            textBoxRed.TextChanged += textBoxRed_TextChanged;
            textBoxGreen.TextChanged += textBoxGreen_TextChanged;
            textBoxBlue.TextChanged += textBoxBlue_TextChanged;
            trackBarRed.Scroll += trackBarRed_Scroll;
            trackBarGreen.Scroll += trackBarGreen_Scroll;
            trackBarBlue.Scroll += trackBarBlue_Scroll;
        }

        // For Lu'v'
        private void setLUV()
        {
            TransformationRGBtoLUV trans = new TransformationRGBtoLUV(textBoxRed.Text,
                textBoxGreen.Text, textBoxBlue.Text);
            textBoxL.Text = Convert.ToString(trans.getL());
            textBoxU.Text = Convert.ToString(trans.getU());
            textBoxV.Text = Convert.ToString(trans.getV());
            trackBarL.Value = (int) Convert.ToDouble(textBoxL.Text);
            trackBarU.Value = (int) Convert.ToDouble(textBoxU.Text) + 200;
            trackBarV.Value = (int)Convert.ToDouble(textBoxV.Text) + 200;
            LastValueTrackBarL = trackBarL.Value;
            LastValueTrackBarU = trackBarU.Value;
            LastValueTrackBarV = trackBarV.Value;
        }

        // For Lu'v'
        private void setLUV(String red, String green, String blue)
        {
            TransformationRGBtoLUV trans = new TransformationRGBtoLUV(red, green, blue);
            textBoxL.Text = Convert.ToString(trans.getL());
            textBoxU.Text = Convert.ToString(trans.getU());
            textBoxV.Text = Convert.ToString(trans.getV());
            trackBarL.Value = (int)Convert.ToDouble(textBoxL.Text);
            trackBarU.Value = (int)Convert.ToDouble(textBoxU.Text) + 200;
            trackBarV.Value = (int)Convert.ToDouble(textBoxV.Text) + 200;
            LastValueTrackBarL = trackBarL.Value;
            LastValueTrackBarU = trackBarU.Value;
            LastValueTrackBarV = trackBarV.Value;
        }

        // For RGB
        private void trackBarRed_Scroll(object sender, EventArgs e)
        {
            //RGB
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            textBoxRed.Text = trackBarRed.Value.ToString();
            //CMY
            textBoxCyan.Text = TransformationCMY.getCMYbyRGB(textBoxRed.Text);
            trackBarCyan.Value = TransformationCMY.reSizeCMY(textBoxCyan.Text);
            //HLS
            setHLS();
            //Lu'v'
            setLUV();
        }

        // For RGB
        private void trackBarGreen_Scroll(object sender, EventArgs e)
        {
            //RGB
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            textBoxGreen.Text = trackBarGreen.Value.ToString();
            //CMY
            textBoxMagenta.Text = TransformationCMY.getCMYbyRGB(textBoxGreen.Text);
            trackBarMagenta.Value = TransformationCMY.reSizeCMY(textBoxMagenta.Text);
            //HLS
            setHLS();
            //Lu'v'
            setLUV();
        }

        // For RGB
        private void trackBarBlue_Scroll(object sender, EventArgs e)
        {
            //RGB
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            textBoxBlue.Text = trackBarBlue.Value.ToString();
            //CMY
            textBoxYellow.Text = TransformationCMY.getCMYbyRGB(textBoxBlue.Text);
            trackBarYellow.Value = TransformationCMY.reSizeCMY(textBoxYellow.Text);
            //HLS
            setHLS();
            //Lu'v'
            setLUV();
        }

        // For RGB
        public String getSimpleStringRGB(String text)
        {
            String answ = "";
            String preperedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text.ElementAt(i) < 61 && text.ElementAt(i) > 40)
                {
                    preperedText += text.ElementAt(i);
                }
            }
            int value = 0;
            if (preperedText.Length != 0)
            {
                value = Convert.ToInt32(preperedText);
                answ = preperedText;
                if (value > 255)
                {
                    answ = "255";
                }
            }
            return answ;
        }

        // For RGB
        private void textBoxRed_TextChanged(object sender, EventArgs e)
        {
            //RGB
            String count = getSimpleStringRGB(textBoxRed.Text);
            int value = 0;
            if (count.Length != 0)
            {
                value = Convert.ToInt32(count);
            }
            textBoxRed.Text = count;
            trackBarRed.Value = value;
            panel1.BackColor = System.Drawing.Color.FromArgb
                    (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);

            //CMY
            textBoxCyan.Text = TransformationCMY.getCMYbyRGB(textBoxRed.Text);
            trackBarCyan.Value = TransformationCMY.reSizeCMY(textBoxCyan.Text);
            //HLS
            setHLS();
            //Lu'v'
            setLUV();
        }

        // For RGB
        private void textBoxGreen_TextChanged(object sender, EventArgs e)
        {
            String count = getSimpleStringRGB(textBoxGreen.Text);
            int value = 0;
            if (count.Length != 0)
            {
                value = Convert.ToInt32(count);
            }
            textBoxGreen.Text = count;
            trackBarGreen.Value = value;
            panel1.BackColor = System.Drawing.Color.FromArgb
                    (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);

            //CMY
            textBoxMagenta.Text = TransformationCMY.getCMYbyRGB(textBoxGreen.Text);
            trackBarMagenta.Value = TransformationCMY.reSizeCMY(textBoxMagenta.Text);
            //HLS
            setHLS();
            //Lu'v'
            setLUV();
        }

        // For RGB
        private void textBoxBlue_TextChanged(object sender, EventArgs e)
        {
            String count = getSimpleStringRGB(textBoxBlue.Text);
            int value = 0;
            if (count.Length != 0)
            {
                value = Convert.ToInt32(count);
            }
            textBoxBlue.Text = count;
            trackBarBlue.Value = value;
            panel1.BackColor = System.Drawing.Color.FromArgb
                    (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);

            //CMY
            textBoxYellow.Text = TransformationCMY.getCMYbyRGB(textBoxBlue.Text);
            trackBarYellow.Value = TransformationCMY.reSizeCMY(textBoxYellow.Text);
            //HLS
            setHLS();
            //Lu'v'
            setLUV();
        }

        //CMY
        private void trackBarCyan_Scroll(object sender, EventArgs e)
        {
            //CMY
            textBoxCyan.Text = TransformationCMY.reSizeCMY(trackBarCyan.Value);
            //RGB
            trackBarRed.Value = Convert.ToInt32(TransformationCMY.getRGBbyCMY(textBoxCyan.Text));
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            textBoxRed.Text = trackBarRed.Value.ToString();
            //HLS
            setHLS();
        }

        //CMY
        private void trackBarMagenta_Scroll(object sender, EventArgs e)
        {
            //CMY
            textBoxMagenta.Text = TransformationCMY.reSizeCMY(trackBarMagenta.Value);
            //RGB
            trackBarGreen.Value = Convert.ToInt32(TransformationCMY.getRGBbyCMY(textBoxMagenta.Text));
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            textBoxGreen.Text = trackBarGreen.Value.ToString();
            //HLS
            setHLS();
        }

        //CMY
        private void trackBarYellow_Scroll(object sender, EventArgs e)
        {
            //CMY
            textBoxYellow.Text = TransformationCMY.reSizeCMY(trackBarYellow.Value);
            //RGB
            trackBarBlue.Value = Convert.ToInt32(TransformationCMY.getRGBbyCMY(textBoxYellow.Text));
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            textBoxBlue.Text = trackBarBlue.Value.ToString();
            //HLS
            setHLS();
        }

        //HLS
        private void trackBarHue_Scroll(object sender, EventArgs e)
        {
            textBoxHue.Text = Convert.ToString(trackBarHue.Value);
            setRGBFromHLS();
            setCMYFromRGB();
            setLUV();
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
        }

        //HLS
        private void trackBarSaturation_Scroll(object sender, EventArgs e)
        {
            textBoxSaturation.Text = Convert.ToString(trackBarSaturation.Value);
            setRGBFromHLS();
            setCMYFromRGB();
            setLUV();
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
        }

        //HLS
        private void trackBarLightness_Scroll(object sender, EventArgs e)
        {
            textBoxLightness.Text = Convert.ToString(trackBarLightness.Value);
            setRGBFromHLS();
            setCMYFromRGB();
            setLUV();
            panel1.BackColor = System.Drawing.Color.FromArgb
                (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
        }

        int LastValueTrackBarL = 0;
        int LastValueTrackBarU = 200;
        int LastValueTrackBarV = 200;

        private void trackBarL_Scroll(object sender, EventArgs e)
        {
            if (PrepareLUV.prepareLUV(Convert.ToString(trackBarL.Value), textBoxU.Text, textBoxV.Text))
            {
                LastValueTrackBarL = trackBarL.Value;
                textBoxL.Text = Convert.ToString(trackBarL.Value);
                TransformationLUVtoRGB trans = new TransformationLUVtoRGB(textBoxL.Text,
                    textBoxU.Text, textBoxV.Text);
                setRGBFromLUV(trans);
                setCMYFromRGB();
                setHLS();
                panel1.BackColor = System.Drawing.Color.FromArgb
                    (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            }
            else
            {
                trackBarL.Value = LastValueTrackBarL;
            }
        }

        private void trackBarU_Scroll(object sender, EventArgs e)
        {
            if (PrepareLUV.prepareLUV(textBoxL.Text, Convert.ToString(trackBarU.Value - 200), textBoxV.Text))
            {
                LastValueTrackBarU = trackBarU.Value;
                textBoxU.Text = Convert.ToString(trackBarU.Value - 200);
                TransformationLUVtoRGB trans = new TransformationLUVtoRGB(textBoxL.Text,
                    textBoxU.Text, textBoxV.Text);
                setRGBFromLUV(trans);
                setCMYFromRGB();
                setHLS();
                panel1.BackColor = System.Drawing.Color.FromArgb
                    (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            }
            else
            {
                trackBarU.Value = LastValueTrackBarU;
            }
        }

        private void trackBarV_Scroll(object sender, EventArgs e)
        {
            if (PrepareLUV.prepareLUV(textBoxL.Text, textBoxU.Text, Convert.ToString(trackBarV.Value - 200)))
            {
                LastValueTrackBarV = trackBarV.Value;
                textBoxV.Text = Convert.ToString(trackBarV.Value - 200);
                TransformationLUVtoRGB trans = new TransformationLUVtoRGB(textBoxL.Text,
                    textBoxU.Text, textBoxV.Text);
                setRGBFromLUV(trans);
                setCMYFromRGB();
                setHLS();
                panel1.BackColor = System.Drawing.Color.FromArgb
                    (trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            }
            else
            {
                trackBarV.Value = LastValueTrackBarV;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxRed.Text = Convert.ToString(colorDialog1.Color.R);
                textBoxGreen.Text = Convert.ToString(colorDialog1.Color.G);
                textBoxBlue.Text = Convert.ToString(colorDialog1.Color.B);
                trackBarRed.Value = colorDialog1.Color.R;
                trackBarGreen.Value = colorDialog1.Color.G;
                trackBarBlue.Value = colorDialog1.Color.B;
            }
        }



    }
}
