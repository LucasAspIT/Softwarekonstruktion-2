using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    public class ClassFileHandler : ClassNotify
    {
        private string _path;

        /// <summary>
        /// Default constructor which sets the default path to save files to.
        /// </summary>
        public ClassFileHandler()
        {
            // _path = "C:\CodingFolder\S2\FlydekasseRapport\RapportResultater"
            _path = @"..\RapportResultater";
        }

        /// <summary>
        /// Overlaoded constructor that uses the parameter to set a new path to save files to.
        /// </summary>
        /// <param name="newPath"></param>
        public ClassFileHandler(string newPath)
        {
            _path = newPath;
        }

        private string WriteTextToFile(string inText)
        {
            string res = "";

            return res;
        }
    }
}
