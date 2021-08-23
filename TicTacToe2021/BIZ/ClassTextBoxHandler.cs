using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace BIZ
{
    public class ClassTextBoxHandler : ClassCheckForWinner
    {

        public ClassTextBoxHandler()
        {
            classTextBoxCollection = new ClassTextBoxCollection();
            gridColor = "Blue";
        }
        public ClassTextBoxCollection classTextBoxCollection { get; set; }

        private string _gridColor;
        private string _actualSign;

        public string actualSign
        {
            get { return _actualSign; }
            private set
            {
                if (_actualSign != value)
                {
                    _actualSign = value;
                }
                Notify("actualSign");
            }
        }


        public string gridColor
        {
            get { return _gridColor; }
            set
            {
                if (_gridColor != value)
                {
                    _gridColor = value;
                    if (value == "Blue")
                    {
                        actualSign = "X";
                    }
                    else
                    {
                        actualSign = "O";
                    }
                }
                Notify("gridColor");
            }
        }

        public bool RegTextBoxClick(string boxID)
        {
            bool bolRes = false;
            string[] arrayKey = boxID.Split(',');
            int xCord = Convert.ToInt32(arrayKey[0]);
            int yCord = Convert.ToInt32(arrayKey[1]);

            if (strSignPlacement[xCord, yCord] == "" && CheckNumberOfSigns() < 3)
            {
                strSignPlacement[xCord, yCord] = actualSign;
                UpdateNumberOfSignsAdd();
                classTextBoxCollection.SetSign(boxID, actualSign);


                if (CheckNumberOfSigns() == 3)
                {
                    if (CheckNewDraw(actualSign) == true)
                    {
                        bolRes = true;
                    }
                }

                if (bolRes == false)
                {
                    SetColor();
                }
            }
            else
            {
                if (CheckNumberOfSigns() == 3)
                {
                    if (strSignPlacement[xCord, yCord] == actualSign)
                    {
                        strSignPlacement[xCord, yCord] = "";
                        UpdateNumberOfSignsRemove();
                        classTextBoxCollection.SetSign(boxID, "");
                    }
                }
            }
            return bolRes;
        }

        public void ResetAll()
        {
            InitialiseArray();
            classTextBoxCollection.InitialiseTextBox();
            gridColor = "Blue";
            intO = 0;
            intX = 0;
        }

        public void SetColor()
        {
            if (gridColor == "Blue")
            {
                gridColor = "Red";
            }
            else
            {
                gridColor = "Blue";
            }
        }

        public void UpdateNumberOfSignsAdd()
        {
            if (actualSign == "X")
            {
                intX++;
            }
            else
            {
                intO++;
            }
        }

        public void UpdateNumberOfSignsRemove()
        {
            if (actualSign == "X")
            {
                intX--;
            }
            else
            {
                intO--;
            }
        }

        private int CheckNumberOfSigns()
        {
            int res = 0;
            if (actualSign == "X")
            {
                res = intX;
            }
            else
            {
                res = intO;
            }
            return res;
        }
    }
}
