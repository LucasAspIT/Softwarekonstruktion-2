using Repository;

namespace BIZ
{
    public class ClassBIZ
    {
        private ClassBackgrundColor _colorData;

        public ClassBIZ()
        {
            colorData = new ClassBackgrundColor();
        }

        /// <summary>
        /// Used to receive data from and modify the instantiated ClassBackgroundColor class (colorData), which in turns updates the GUI via binding
        /// </summary>
        public ClassBackgrundColor colorData
        {
            get { return _colorData; }
            set
            {
                if (_colorData != value)
                {
                    _colorData = value;
                }
            }
        }
    }
}
