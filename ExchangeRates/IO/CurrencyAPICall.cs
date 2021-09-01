using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Repository;

namespace IO
{
    public class CurrencyAPICall : APICall
    {
        public CurrencyAPICall()
        {

        }

        public async Task<ExchangeRates> GetAPIDataAsync()
        {
            string strUrl = $"https://openexchangerates.org/api/latest.json?app_id=3737daa413d14a59bf5738d0e6707c21&base=USD";

            string apiResponse = await GetDataFromWebAPIAsync(strUrl);

            ExchangeRates cer = JsonConvert.DeserializeObject<ExchangeRates>(apiResponse);

            return cer;
        }
    }
}
