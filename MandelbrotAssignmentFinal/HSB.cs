using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotAssignmentFinal
{
    class HSB
    {
        public float rChan, gChan, bChan;

        public HSB()
        {
            rChan = gChan = bChan = 0;
        }

        public void fromHSB(float h, float s, float b)
        {
            float red = b;
            float green = b;
            float blue = b;
            if (s != 0)
            {
                float max = b;
                float dif = b * s / 255f;
                float min = b - dif;

                float h2 = h * 360f / 255f;

                if (h2 < 60f)
                {
                    red = max;
                    green = h2 * dif / 60f + min;
                    blue = min;
                }
                else if (h2 < 120f)
                {
                    red = -(h2 - 120f) * dif / 60f + min;
                    green = max;
                    blue = min;
                }
                else if (h2 < 180f)
                {
                    red = min;
                    green = max;
                    blue = (h2 - 120f) * dif / 60f + min;
                }
                else if (h2 < 240f)
                {
                    red = min;
                    green = -(h2 - 240f) * dif / 60f + min;
                    blue = max;
                }
                else if (h2 < 300f)
                {
                    red = (h2 - 240f) * dif / 60f + min;
                    green = min;
                    blue = max;
                }
                else if (h2 <= 360f)
                {
                    red = max;
                    green = min;
                    blue = -(h2 - 360f) * dif / 60 + min;
                }
                else
                {
                    red = 0;
                    green = 0;
                    blue = 0;
                }
            }

            rChan = (float)Math.Round(Math.Min(Math.Max(red, 0f), 255));
            gChan = (float)Math.Round(Math.Min(Math.Max(green, 0), 255));
            bChan = (float)Math.Round(Math.Min(Math.Max(blue, 0), 255));

        }

        //public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        //{
        //    int max = Math.Max(color.R, Math.Max(color.G, color.B));
        //    int min = Math.Min(color.R, Math.Min(color.G, color.B));

        //    hue = color.GetHue();
        //    saturation = (max == 0) ? 0 : 1d - (1d * min / max);
        //    value = max / 255d;
        //}

        public static Color HSBtoRGB(float hue, float saturation, float brightness)
        {
            int r = 0, g = 0, b = 0;
            if (saturation == 0)
            {
                r = g = b = (int)(brightness * 255.0f + 0.5f);
            }
            else
            {
                float h = (hue - (float)Math.Floor(hue)) * 6.0f;
                float f = h - (float)Math.Floor(h);
                float p = brightness * (1.0f - saturation);
                float q = brightness * (1.0f - saturation * f);
                float t = brightness * (1.0f - (saturation * (1.0f - f)));
                switch ((int)h)
                {
                    case 0:
                        Color tempColor0 = Fractal.palette[0];
                        r = (int)(brightness * (tempColor0.R * 1.0f) + 0.5f);
                        g = (int)(t * (tempColor0.G * 1.0f) + 0.5f);
                        b = (int)(p * (tempColor0.B * 1.0f) + 0.5f);
                        break;
                    case 1:
                        Color tempColor1 = Fractal.palette[1];
                        r = (int)(q * (tempColor1.R * 1.0F) + 0.5f);
                        g = (int)(brightness * (tempColor1.G * 1.0F) + 0.5f);
                        b = (int)(p * (tempColor1.B * 1.0F) + 0.5f);
                        break;
                    case 2:
                        Color tempColor2 = Fractal.palette[2];
                        r = (int)(p * (tempColor2.R * 1.0f) + 0.5f);
                        g = (int)(brightness * (tempColor2.G * 1.0f) + 0.5f);
                        b = (int)(t * (tempColor2.B * 1.0f) + 0.5f);
                        break;
                    case 3:
                        Color tempColor3 = Fractal.palette[3];
                        r = (int)(p * (tempColor3.R * 1.0f) + 0.5f);
                        g = (int)(q * (tempColor3.G * 1.0f) + 0.5f);
                        b = (int)(brightness * (tempColor3.B * 1.0f) + 0.5f);
                        break;
                    case 4:
                        Color tempColor4 = Fractal.palette[4];
                        r = (int)(t * (tempColor4.R * 1.0f) + 0.5f);
                        g = (int)(p * (tempColor4.G * 1.0f) + 0.5f);
                        b = (int)(brightness * (tempColor4.B * 1.0f) + 0.5f);
                        break;
                    case 5:
                        Color tempColor5 = Fractal
                            
                            .palette[5];
                        r = (int)(brightness * (tempColor5.R * 1.0f) + 0.5f);
                        g = (int)(p * (tempColor5.G * 1.0f) + 0.5f);
                        b = (int)(q * (tempColor5.B * 1.0f) + 0.5f);
                        break;
                }
            }
            return Color.FromArgb(Convert.ToByte(255), Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
        }
    }

}

