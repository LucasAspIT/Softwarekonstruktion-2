using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassCheckForWinner : ClassCountDrawAndRegister
    {

        protected bool CheckNewDraw(string strSign)
        {
            bool bolRes = false;
            string strWinner = strSign + strSign + strSign;
            string[] strFacit = new string[8];

            strFacit[0] = strSignPlacement[0, 0] + strSignPlacement[0, 1] + strSignPlacement[0, 2];
            strFacit[1] = strSignPlacement[1, 0] + strSignPlacement[1, 1] + strSignPlacement[1, 2];
            strFacit[2] = strSignPlacement[2, 0] + strSignPlacement[2, 1] + strSignPlacement[2, 2];
            strFacit[3] = strSignPlacement[0, 0] + strSignPlacement[1, 0] + strSignPlacement[2, 0];
            strFacit[4] = strSignPlacement[0, 1] + strSignPlacement[1, 1] + strSignPlacement[2, 1];
            strFacit[5] = strSignPlacement[0, 2] + strSignPlacement[1, 2] + strSignPlacement[2, 2];
            strFacit[6] = strSignPlacement[0, 0] + strSignPlacement[1, 1] + strSignPlacement[2, 2];
            strFacit[7] = strSignPlacement[0, 2] + strSignPlacement[1, 1] + strSignPlacement[2, 0];

            for (int i = 0; i <= 7; i++)
            {
                if (strFacit[i] == strWinner)
                {
                    bolRes = true;
                    UpdateScore(strSign);
                }
            }
            return bolRes;
        }

        private void UpdateScore(string inSign)
        {
            if (inSign == "X")
            {
                intScoreX++;
            }
            else
            {
                intScoreO++;
            }
        }
    }
}
