using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace BIZ
{
    public class ClassCountDrawAndRegister : ClassNotify
    {

        protected string[,] strSignPlacement = new string[3, 3];
        protected int intX { get; set; }
        protected int intO { get; set; }
        protected int intScoreX { get; set; }
        protected int intScoreO { get; set; }

        public ClassCountDrawAndRegister()
        {
            intX = 0;
            intO = 0;
            intScoreO = 0;
            intScoreX = 0;
            InitialiseArray();
        }

        protected void InitialiseArray()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    strSignPlacement[i, y] = "";
                }
            }
        }
    }
}
