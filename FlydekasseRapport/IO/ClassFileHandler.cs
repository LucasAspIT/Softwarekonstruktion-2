using System;
using System.Collections.Generic;
using System.IO;
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
            // _path = @"..\RapportResultater";
            _path = "";
        }

        /// <summary>
        /// Overlaoded constructor that uses the parameter to set a new path to save files to.
        /// </summary>
        /// <param name="newPath"></param>
        public ClassFileHandler(string newPath)
        {
            _path = newPath;
        }

        public void SetPath(string newPath)
        {
            _path = newPath;
        }

        /// <summary>
        /// Writes the report to a .txt file and opens it.
        /// <br>Returns the path to the saved file, so it can be used to automatically open the file.</br>
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public string WriteTextToFile(string text)
        {
            _path = @"..\..\..\RapportResultater\" + DateTime.Now.ToString("yyyy MM dd - HH-mm-ss") + "_Rapport.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(File.Create(_path), Encoding.GetEncoding("UTF-8")))
                {
                    writer.WriteLine(text);
                }
            }
            catch (IOException ex)
            {

                throw ex;
            }

            return _path;
        }
    }
}
