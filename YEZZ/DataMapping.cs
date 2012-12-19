using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace YEZZ
{
    public class DataMapping
    {
        public static Color HexToColor(string strHex)
        {
            return Color.FromArgb(int.Parse(strHex, System.Globalization.NumberStyles.HexNumber));
        }

        public static string ColorToHex(Color color)
        {
            return color.ToArgb().ToString("X");
        }
    }
}
