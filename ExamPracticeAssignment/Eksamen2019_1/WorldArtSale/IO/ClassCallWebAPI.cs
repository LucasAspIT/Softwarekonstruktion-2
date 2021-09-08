using System.Threading.Tasks;
using System;
using System.IO;
using System.Net;

namespace IO
{
    public class ClassCallWebAPI
    {

        public async Task<string> GetURLContentsAsync(string url)
        {
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                // Send the request to the Internet resource and wait for the response.
                // Note: You can't use HttpWebRequest.GetResponse in a Windows Store app.
                using (WebResponse response = await webReq.GetResponseAsync())
                {
                    // Get the data stream that is associated with the specified URL.
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        // Read the bytes in responseStream and copy them to content.
                        await responseStream.CopyToAsync(content);
                        // The downloaded resource ends up in the variable named content.
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Return the result as a byte array.
            return System.Text.Encoding.UTF8.GetString(content.ToArray());
        }
    }
}
