using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    /// <summary>
    /// Denne calss har til formål at holde en samling af generelle metoder til at kommunikere med en WEB Api.
    /// </summary>
    public class APICall
    {
        public APICall()
        {

        }

        /// <summary>
        /// Denne asynkrone metode skal modtage en URL med alle relevante data som gør det muligt at lave en forespørgsel til en WEB Api.
        /// Svaret den modtager køres igennem en Encoding.
        /// UTF-8 sikrer at alle nordiske tegn vil blive vist korrekt (ÆØÅ).
        /// </summary>
        /// <param name="URL"></param>
        /// <returns>Task(string)</returns>
        protected async Task<string> GetDataFromWebAPIAsync(string URL)
        {
            var content = new MemoryStream(); // MemoryStream benyttes, da data bliver leveret i klumper, hvilket MemoryStream er egnet til.

            var webReq = (HttpWebRequest)WebRequest.Create(URL); // webReq er en HttpWebRequest.
                                                                 // Årsagen til at man caster WebRequest til datatypen HttpWebRequest er, at WebRequest vil automatisk udløse, at                         compileren vil skulle undersøge hvilken datatype der skal castes til. Ved at angive HttpWebRequest som                                datatypen som der skal castes til belaster man compileren mindre.

            // Her benyttes using, da man derved udnytter GarbageCollrctoren i styresystem til at nulstille de ressourcer som angives i using.
            using (WebResponse response = await webReq.GetResponseAsync()) // Opretter forbindelse til Web API.
            {
                using (Stream responseStream = response.GetResponseStream()) // Modtager data fra Web API.
                {
                    await responseStream.CopyToAsync(content); // Her overføres svaret til MemoryStream.
                }
            }

            return Encoding.UTF8.GetString(content.ToArray()); // Her sikres det, at teksten er i UTF-8 format, som sikrer at alle de nordiske tegn vises korrekt.
        }
    }
}
