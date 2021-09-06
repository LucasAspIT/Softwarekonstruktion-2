using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassArt : ClassNotify
    {
        public ClassArt()
        {
            _artID = "";
            _picturePath  = "";
            _pictureDescription = "";
            _pictureTitle = "";
        }


        private string _artID;
        private string _picturePath;
        private string _pictureDescription;
        private string _pictureTitle;

        public string artID
        {
            get { return _artID; }
            set
            {
                if (_artID != value)
                {
                    _artID = value;
                }
                Notify("artID");
            }
        }


        public string picturePath
        {
            get { return _picturePath; }
            set
            {
                if (_picturePath != value)
                {
                    _picturePath = value;
                }
                Notify("picturePath");
            }
        }


        public string pictureDescription
        {
            get { return _pictureDescription; }
            set
            {
                if (_pictureDescription != value)
                {
                    _pictureDescription = value;
                }
                Notify("pictureDescription");
            }
        }


        public string pictureTitle
        {
            get { return _pictureTitle; }
            set
            {
                if (_pictureTitle != value)
                {
                    _pictureTitle = value;
                }
                Notify("pictureTitle");
            }
        }

    }
}
