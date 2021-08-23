using System.Windows.Media;

namespace Repository
{
    public class ClassBackgrundColor : ClassNotify
    {
        // Fields that hold the value of properties
        private string _hexValue;
        private int _redValue;
        private int _greenValue;
        private int _blueValue;
        private int _trnsValue;

        public ClassBackgrundColor()
        {
            // Sets initial (default) values
            hexValue = "808080";
            redValue = 128;
            greenValue = 128;
            blueValue = 128;
            trnsValue = 255;
        }

        public int trnsValue
        {
            get { return _trnsValue; }
            set
            {
                if (_trnsValue != value)
                {
                    // If the value goes below zero, set it back to zero
                    if (value < 0)
                    {
                        value = 0;
                    }
                    // If the value goes above 255, set it back to 255
                    if (value > 255)
                    {
                        value = 255;
                    }
                    _trnsValue = value;
                    ConvertToHex();
                }
                Notify("trnsValue");
            }
        }
        public int blueValue
        {
            get { return _blueValue; }
            set
            {
                if (_blueValue != value)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (value > 255)
                    {
                        value = 255;
                    }
                    _blueValue = value;
                    ConvertToHex();
                }
                Notify("blueValue");
            }
        }
        public int greenValue
        {
            get { return _greenValue; }
            set
            {
                if (_greenValue != value)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (value > 255)
                    {
                        value = 255;
                    }
                    _greenValue = value;
                    ConvertToHex();
                }
                Notify("greenValue");
            }
        }
        public int redValue
        {
            get { return _redValue; }
            set
            {
                if (_redValue != value)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (value > 255)
                    {
                        value = 255;
                    }
                    _redValue = value;
                    ConvertToHex();
                }
                Notify("redValue");
            }
        }


        public string hexValue
        {
            get { return "#" + _hexValue; }
            set
            {
                if (_hexValue != value)
                {
                    _hexValue = value;
                }
                Notify("hexValue");
            }
        }

        /// <summary>
        /// Takes the 4 values (trnsValue, redValue, greenValue, blueValue) and returns a color with the specified values
        /// <br>Sets the hexValue with the concatenated string of [A, R, G, B] formatted as hexadecimal ("X2")</br>
        /// </summary>
        private void ConvertToHex()
        {
            Color myColor = Color.FromArgb((byte)trnsValue, (byte)redValue, (byte)greenValue, (byte)blueValue);
            hexValue = myColor.A.ToString("X2") + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
        }
    }
}
