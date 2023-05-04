using System.Globalization;
using System.Text.RegularExpressions;

namespace SeleniumFramework.Helpers;

/// <summary>
/// Color conversion support class.
/// </summary>
public class ColorHelper
{
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }
    public double Alpha { get; set; }

    public string Rgb => $"rgb({Red}, {Green}, {Blue})";
    public string Rgba => $"rgba({Red}, {Green}, {Blue}, {Alpha.ToString(CultureInfo.InvariantCulture)})";
    public string Hex => $"#{Red:X2}{Green:X2}{Blue:X2}".ToLower();
    public System.Drawing.Color GetColor => System.Drawing.Color.FromArgb((int)(Alpha * 255), Red, Green, Blue);

    private static Dictionary<string, ColorHelper> Colors = new()
    {
        { "TRANSPARENT", new ColorHelper(0, 0, 0, 0d) },
        { "ALICEBLUE", new ColorHelper(240, 248, 255, 1d) },
        { "ANTIQUEWHITE", new ColorHelper(250, 235, 215, 1d) },
        { "AQUA", new ColorHelper(0, 255, 255, 1d) },
        { "AQUAMARINE", new ColorHelper(127, 255, 212, 1d) },
        { "AZURE", new ColorHelper(240, 255, 255, 1d) },
        { "BEIGE", new ColorHelper(245, 245, 220, 1d) },
        { "BISQUE", new ColorHelper(255, 228, 196, 1d) },
        { "BLACK", new ColorHelper(0, 0, 0, 1d) },
        { "BLANCHEDALMOND", new ColorHelper(255, 235, 205, 1d) },
        { "BLUE", new ColorHelper(0, 0, 255, 1d) },
        { "BLUEVIOLET", new ColorHelper(138, 43, 226, 1d) },
        { "BROWN", new ColorHelper(165, 42, 42, 1d) },
        { "BURLYWOOD", new ColorHelper(222, 184, 135, 1d) },
        { "CADETBLUE", new ColorHelper(95, 158, 160, 1d) },
        { "CHARTREUSE", new ColorHelper(127, 255, 0, 1d) },
        { "CHOCOLATE", new ColorHelper(210, 105, 30, 1d) },
        { "CORAL", new ColorHelper(255, 127, 80, 1d) },
        { "CORNFLOWERBLUE", new ColorHelper(100, 149, 237, 1d) },
        { "CORNSILK", new ColorHelper(255, 248, 220, 1d) },
        { "CRIMSON", new ColorHelper(220, 20, 60, 1d) },
        { "CYAN", new ColorHelper(0, 255, 255, 1d) },
        { "DARKBLUE", new ColorHelper(0, 0, 139, 1d) },
        { "DARKCYAN", new ColorHelper(0, 139, 139, 1d) },
        { "DARKGOLDENROD", new ColorHelper(184, 134, 11, 1d) },
        { "DARKGRAY", new ColorHelper(169, 169, 169, 1d) },
        { "DARKGREEN", new ColorHelper(0, 100, 0, 1d) },
        { "DARKGREY", new ColorHelper(169, 169, 169, 1d) },
        { "DARKKHAKI", new ColorHelper(189, 183, 107, 1d) },
        { "DARKMAGENTA", new ColorHelper(139, 0, 139, 1d) },
        { "DARKOLIVEGREEN", new ColorHelper(85, 107, 47, 1d) },
        { "DARKORANGE", new ColorHelper(255, 140, 0, 1d) },
        { "DARKORCHID", new ColorHelper(153, 50, 204, 1d) },
        { "DARKRED", new ColorHelper(139, 0, 0, 1d) },
        { "DARKSALMON", new ColorHelper(233, 150, 122, 1d) },
        { "DARKSEAGREEN", new ColorHelper(143, 188, 143, 1d) },
        { "DARKSLATEBLUE", new ColorHelper(72, 61, 139, 1d) },
        { "DARKSLATEGRAY", new ColorHelper(47, 79, 79, 1d) },
        { "DARKSLATEGREY", new ColorHelper(47, 79, 79, 1d) },
        { "DARKTURQUOISE", new ColorHelper(0, 206, 209, 1d) },
        { "DARKVIOLET", new ColorHelper(148, 0, 211, 1d) },
        { "DEEPPINK", new ColorHelper(255, 20, 147, 1d) },
        { "DEEPSKYBLUE", new ColorHelper(0, 191, 255, 1d) },
        { "DIMGRAY", new ColorHelper(105, 105, 105, 1d) },
        { "DIMGREY", new ColorHelper(105, 105, 105, 1d) },
        { "DODGERBLUE", new ColorHelper(30, 144, 255, 1d) },
        { "FIREBRICK", new ColorHelper(178, 34, 34, 1d) },
        { "FLORALWHITE", new ColorHelper(255, 250, 240, 1d) },
        { "FORESTGREEN", new ColorHelper(34, 139, 34, 1d) },
        { "FUCHSIA", new ColorHelper(255, 0, 255, 1d) },
        { "GAINSBORO", new ColorHelper(220, 220, 220, 1d) },
        { "GHOSTWHITE", new ColorHelper(248, 248, 255, 1d) },
        { "GOLD", new ColorHelper(255, 215, 0, 1d) },
        { "GOLDENROD", new ColorHelper(218, 165, 32, 1d) },
        { "GRAY", new ColorHelper(128, 128, 128, 1d) },
        { "GREY", new ColorHelper(128, 128, 128, 1d) },
        { "GREEN", new ColorHelper(0, 128, 0, 1d) },
        { "GREENYELLOW", new ColorHelper(173, 255, 47, 1d) },
        { "HONEYDEW", new ColorHelper(240, 255, 240, 1d) },
        { "HOTPINK", new ColorHelper(255, 105, 180, 1d) },
        { "INDIANRED", new ColorHelper(205, 92, 92, 1d) },
        { "INDIGO", new ColorHelper(75, 0, 130, 1d) },
        { "IVORY", new ColorHelper(255, 255, 240, 1d) },
        { "KHAKI", new ColorHelper(240, 230, 140, 1d) },
        { "LAVENDER", new ColorHelper(230, 230, 250, 1d) },
        { "LAVENDERBLUSH", new ColorHelper(255, 240, 245, 1d) },
        { "LAWNGREEN", new ColorHelper(124, 252, 0, 1d) },
        { "LEMONCHIFFON", new ColorHelper(255, 250, 205, 1d) },
        { "LIGHTBLUE", new ColorHelper(173, 216, 230, 1d) },
        { "LIGHTCORAL", new ColorHelper(240, 128, 128, 1d) },
        { "LIGHTCYAN", new ColorHelper(224, 255, 255, 1d) },
        { "LIGHTGOLDENRODYELLOW", new ColorHelper(250, 250, 210, 1d) },
        { "LIGHTGRAY", new ColorHelper(211, 211, 211, 1d) },
        { "LIGHTGREEN", new ColorHelper(144, 238, 144, 1d) },
        { "LIGHTGREY", new ColorHelper(211, 211, 211, 1d) },
        { "LIGHTPINK", new ColorHelper(255, 182, 193, 1d) },
        { "LIGHTSALMON", new ColorHelper(255, 160, 122, 1d) },
        { "LIGHTSEAGREEN", new ColorHelper(32, 178, 170, 1d) },
        { "LIGHTSKYBLUE", new ColorHelper(135, 206, 250, 1d) },
        { "LIGHTSLATEGRAY", new ColorHelper(119, 136, 153, 1d) },
        { "LIGHTSLATEGREY", new ColorHelper(119, 136, 153, 1d) },
        { "LIGHTSTEELBLUE", new ColorHelper(176, 196, 222, 1d) },
        { "LIGHTYELLOW", new ColorHelper(255, 255, 224, 1d) },
        { "LIME", new ColorHelper(0, 255, 0, 1d) },
        { "LIMEGREEN", new ColorHelper(50, 205, 50, 1d) },
        { "LINEN", new ColorHelper(250, 240, 230, 1d) },
        { "MAGENTA", new ColorHelper(255, 0, 255, 1d) },
        { "MAROON", new ColorHelper(128, 0, 0, 1d) },
        { "MEDIUMAQUAMARINE", new ColorHelper(102, 205, 170, 1d) },
        { "MEDIUMBLUE", new ColorHelper(0, 0, 205, 1d) },
        { "MEDIUMORCHID", new ColorHelper(186, 85, 211, 1d) },
        { "MEDIUMPURPLE", new ColorHelper(147, 112, 219, 1d) },
        { "MEDIUMSEAGREEN", new ColorHelper(60, 179, 113, 1d) },
        { "MEDIUMSLATEBLUE", new ColorHelper(123, 104, 238, 1d) },
        { "MEDIUMSPRINGGREEN", new ColorHelper(0, 250, 154, 1d) },
        { "MEDIUMTURQUOISE", new ColorHelper(72, 209, 204, 1d) },
        { "MEDIUMVIOLETRED", new ColorHelper(199, 21, 133, 1d) },
        { "MIDNIGHTBLUE", new ColorHelper(25, 25, 112, 1d) },
        { "MINTCREAM", new ColorHelper(245, 255, 250, 1d) },
        { "MISTYROSE", new ColorHelper(255, 228, 225, 1d) },
        { "MOCCASIN", new ColorHelper(255, 228, 181, 1d) },
        { "NAVAJOWHITE", new ColorHelper(255, 222, 173, 1d) },
        { "NAVY", new ColorHelper(0, 0, 128, 1d) },
        { "OLDLACE", new ColorHelper(253, 245, 230, 1d) },
        { "OLIVE", new ColorHelper(128, 128, 0, 1d) },
        { "OLIVEDRAB", new ColorHelper(107, 142, 35, 1d) },
        { "ORANGE", new ColorHelper(255, 165, 0, 1d) },
        { "ORANGERED", new ColorHelper(255, 69, 0, 1d) },
        { "ORCHID", new ColorHelper(218, 112, 214, 1d) },
        { "PALEGOLDENROD", new ColorHelper(238, 232, 170, 1d) },
        { "PALEGREEN", new ColorHelper(152, 251, 152, 1d) },
        { "PALETURQUOISE", new ColorHelper(175, 238, 238, 1d) },
        { "PALEVIOLETRED", new ColorHelper(219, 112, 147, 1d) },
        { "PAPAYAWHIP", new ColorHelper(255, 239, 213, 1d) },
        { "PEACHPUFF", new ColorHelper(255, 218, 185, 1d) },
        { "PERU", new ColorHelper(205, 133, 63, 1d) },
        { "PINK", new ColorHelper(255, 192, 203, 1d) },
        { "PLUM", new ColorHelper(221, 160, 221, 1d) },
        { "POWDERBLUE", new ColorHelper(176, 224, 230, 1d) },
        { "PURPLE", new ColorHelper(128, 0, 128, 1d) },
        { "REBECCAPURPLE", new ColorHelper(102, 51, 153, 1d) },
        { "RED", new ColorHelper(255, 0, 0, 1d) },
        { "ROSYBROWN", new ColorHelper(188, 143, 143, 1d) },
        { "ROYALBLUE", new ColorHelper(65, 105, 225, 1d) },
        { "SADDLEBROWN", new ColorHelper(139, 69, 19, 1d) },
        { "SALMON", new ColorHelper(250, 128, 114, 1d) },
        { "SANDYBROWN", new ColorHelper(244, 164, 96, 1d) },
        { "SEAGREEN", new ColorHelper(46, 139, 87, 1d) },
        { "SEASHELL", new ColorHelper(255, 245, 238, 1d) },
        { "SIENNA", new ColorHelper(160, 82, 45, 1d) },
        { "SILVER", new ColorHelper(192, 192, 192, 1d) },
        { "SKYBLUE", new ColorHelper(135, 206, 235, 1d) },
        { "SLATEBLUE", new ColorHelper(106, 90, 205, 1d) },
        { "SLATEGRAY", new ColorHelper(112, 128, 144, 1d) },
        { "SLATEGREY", new ColorHelper(112, 128, 144, 1d) },
        { "SNOW", new ColorHelper(255, 250, 250, 1d) },
        { "SPRINGGREEN", new ColorHelper(0, 255, 127, 1d) },
        { "STEELBLUE", new ColorHelper(70, 130, 180, 1d) },
        { "TAN", new ColorHelper(210, 180, 140, 1d) },
        { "TEAL", new ColorHelper(0, 128, 128, 1d) },
        { "THISTLE", new ColorHelper(216, 191, 216, 1d) },
        { "TOMATO", new ColorHelper(255, 99, 71, 1d) },
        { "TURQUOISE", new ColorHelper(64, 224, 208, 1d) },
        { "VIOLET", new ColorHelper(238, 130, 238, 1d) },
        { "WHEAT", new ColorHelper(245, 222, 179, 1d) },
        { "WHITE", new ColorHelper(255, 255, 255, 1d) },
        { "WHITESMOKE", new ColorHelper(245, 245, 245, 1d) },
        { "YELLOW", new ColorHelper(255, 255, 0, 1d) },
        { "YELLOWGREEN", new ColorHelper(154, 205, 50, 1d) }
    };

    public ColorHelper(int red, int green, int blue, double alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public override string ToString()
    {
        return "Color: " + Rgba;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ColorHelper)
        {
            return false;
        }
        return Rgba.Equals(((ColorHelper)obj).Rgba);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Red, Green, Blue, Alpha);
    }

    /// <summary>
    /// Guesses what format the input color is in.
    /// </summary>
    /// <param name="value">A string representation of the color.</param>
    /// <returns>An instance of the <see cref="ColorHelper"/> class.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static ColorHelper FromString(string value)
    {
        List<Converter> converters = new()
        {
            new RgbConverter(),
            new RgbPctConverter(),
            new RgbaConverter(),
            new RgbaPctConverter(),
            new NamedColorConverter(),
            new HexConverter(),
            new Hex3Converter(),
            new HslConverter(),
            new HslaConverter()
        };

        foreach (var converter in converters)
        {
            ColorHelper? color = converter.GetColor(value);
            if (color != null)
            {
                return color;
            }
        }
        throw new ArgumentException($"Did not know how to convert {value} into color");
    }
    
    private abstract class Converter
    {
        public virtual ColorHelper? GetColor(string value)
        {
            Match match = GetRegex().Match(value);
            if (match.Success)
            {
                double alpha = 1.0;
                if (match.Groups.Count == 5)
                {
                    alpha = double.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture);
                }
                return CreateColor(match, alpha);
            }
            return null;
        }

        protected virtual ColorHelper CreateColor(Match match, double alpha)
        {
            return new ColorHelper(
                FromMatchGroup(match, 1),
                FromMatchGroup(match, 2),
                FromMatchGroup(match, 3),
                alpha);
        }
        
        protected virtual int FromMatchGroup(Match match, int index)
        {
            return int.Parse(match.Groups[index].Value);
        }

        protected abstract Regex GetRegex();
    }

    private class RgbConverter : Converter
    {
        protected override Regex GetRegex()
        {
            Regex rgbRegex = new(@"^\s*rgb\(\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*\)\s*$");
            return rgbRegex;
        }
    }

    private class RgbPctConverter : Converter
    {
        protected override Regex GetRegex()
        {
            Regex rgbPctRegex = new(@"^\s*rgb\(\s*(\d{1,3}|\d{1,2}\.\d+)%\s*,\s*(\d{1,3}|\d{1,2}\.\d+)%\s*,\s*(\d{1,3}|\d{1,2}\.\d+)%\s*\)\s*$");           
            return rgbPctRegex;
        }
        
        protected override int FromMatchGroup(Match match, int index)
        {
            double n = double.Parse(match.Groups[index].Value) / 100 * 255;
            return (int)n;
        }
    }

    private class RgbaConverter : RgbConverter
    {
        protected override Regex GetRegex()
        {
            Regex rgbaRegex = new(@"^\s*rgba\(\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(0|1|0\.\d+)\s*\)\s*$");         
            return rgbaRegex;
        }
    }

    private class RgbaPctConverter : RgbPctConverter
    {
        protected override Regex GetRegex()
        {
            Regex rgbaPctRegex = new(@"^\s*rgba\(\s*(\d{1,3}|\d{1,2}\.\d+)%\s*,\s*(\d{1,3}|\d{1,2}\.\d+)%\s*,\s*(\d{1,3}|\d{1,2}\.\d+)%\s*,\s*(0|1|0\.\d+)\s*\)\s*$");       
            return rgbaPctRegex;
        }
    }

    private class HexConverter : Converter
    {
        protected override Regex GetRegex()
        {
            Regex hexRegex = new(@"#([A-Fa-f0-9]{2})([A-Fa-f0-9]{2})([A-Fa-f0-9]{2})");
            return hexRegex;
        }

        protected override int FromMatchGroup(Match match, int index)
        {
            return int.Parse(match.Groups[index].Value, NumberStyles.HexNumber);
        }
    }

    private class Hex3Converter : Converter
    {
        protected override Regex GetRegex()
        {
            Regex hex3Regex = new(@"#([A-Fa-f0-9])([A-Fa-f0-9])([A-Fa-f0-9])");
            return hex3Regex;
        }

        protected override int FromMatchGroup(Match match, int index)
        {          
            return int.Parse(match.Groups[index].Value + match.Groups[index].Value, NumberStyles.HexNumber);            
        }
    }

    private class HslConverter : Converter
    {
        protected override Regex GetRegex()
        {
            Regex hslRegex = new(@"^\s*hsl\(\s*(\d{1,3})\s*,\s*(\d{1,3})%\s*,\s*(\d{1,3})%\s*\)\s*$");
            return hslRegex;
        }

        protected override ColorHelper CreateColor(Match match, double alpha)
        {
            double h = double.Parse(match.Groups[1].Value) / 360;
            double s = double.Parse(match.Groups[2].Value) / 100;
            double l = double.Parse(match.Groups[3].Value) / 100;
            double r, g, b;

            if (s == 0)
            {
                r = l;
                g = r;
                b = r;
            }
            else
            {
                double luminocity2 = (l < 0.5) ? l * (1 + s) : l + s - l * s;
                double luminocity1 = 2 * l - luminocity2;
                r = HueToRgb(luminocity1, luminocity2, h + 1.0 / 3.0);
                g = HueToRgb(luminocity1, luminocity2, h);
                b = HueToRgb(luminocity1, luminocity2, h - 1.0 / 3.0);
            }

            return new ColorHelper(
                (int)Math.Round(r * 255), 
                (int)Math.Round(g * 255), 
                (int)Math.Round(b * 255),
                alpha);
        }

        private double HueToRgb(double luminocity1, double luminocity2, double hue)
        {
            if (hue < 0.0)
            {
                hue += 1;
            }
            if (hue > 1.0)
            {
                hue -= 1;
            }
            if (hue < 1.0 / 6.0)
            {
                return (luminocity1 + (luminocity2 - luminocity1) * 6.0 * hue);
            }
            if (hue < 1.0 / 2.0)
            {
                return luminocity2;
            }
            if (hue < 2.0 / 3.0)
            {
                return (luminocity1 + (luminocity2 - luminocity1) * ((2.0 / 3.0) - hue) * 6.0);
            }
            return luminocity1;
        }
    }

    private class HslaConverter : HslConverter
    {
        protected override Regex GetRegex()
        {
            Regex hslaRegex = new(@"^\s*hsla\(\s*(\d{1,3})\s*,\s*(\d{1,3})%\s*,\s*(\d{1,3})%\s*,\s*(0|1|0\.\d+)\s*\)\s*$");
            return hslaRegex;
        }
    }

    private class NamedColorConverter : Converter
    {
        public override ColorHelper? GetColor(string value)
        {
            var valueUpper = value.ToUpper();
            if (Colors.ContainsKey(valueUpper))
            {
                return Colors[valueUpper];
            }
            return null;
        }

        protected override Regex GetRegex()
        {
            throw new NotSupportedException("GetRegex is not supported");
        }
    }
}
