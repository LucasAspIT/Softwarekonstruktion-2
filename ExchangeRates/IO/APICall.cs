using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class APICall
    {
        public APICall()
        {

        }

        protected async Task<string> GetDataFromWebAPIAsync(string URL)
        {
            var content = new MemoryStream();

            var webReq = (HttpWebRequest)WebRequest.Create(URL);

            using (WebResponse response = await webReq.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }

            return Encoding.UTF8.GetString(content.ToArray());
        }
    }
}
