using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Implemented via: Tools > NuGet Package Manager > Manage NuGet Packages for Solution... > Browse > Newtonsoft.Json
using Repository;

namespace IO
{
    /// <summary>
    /// Denne class indeholder de members som skal benyttes for at løse de opgaver der knytter sig specifikt til denne applikation i forhold til Web API.
    /// 
    /// Members:
    /// 1 - Constructors
    /// 2 - Fields
    /// 3 - Properties
    /// 4 - Interfaces
    /// 5 - Methods
    /// </summary>
    public class CurrencyAPICall : APICall
    {
        public CurrencyAPICall()
        {

        }

        /// <summary>
        /// Denne metode står for at lave det specifikke kald til en given Web API.
        /// Denne metode vil kun være brugbar i dette projekt.
        /// Strukturen vil kunne anvendes i andre projekter.
        /// 'apiResponse' vil efter at have kaldt metoden GetDataFromWebAPIAsync, indeholde en text string med svaret fra Web API.
        /// Dette svar bliver omdannet (deseraliseret) til et objekt ved at benytte Newtonsoft.Json.
        /// Herved får man adgang til 'JsonConvert.DeserializeObject<T>(string)' som kan modtage svaret fra Web API og omsætte det til en simpel datatype med passende indhold og struktur i forhold til svaret fra Web API.
        /// I dette tilfælde, er den simple datatype 'ExchangeRates'.
        /// </summary>
        /// <returns>Task(ExchangeRates)</returns>
        public async Task<ExchangeRates> GetAPIDataAsync()
        {
            string strUrl = $"https://openexchangerates.org/api/latest.json?app_id=3737daa413d14a59bf5738d0e6707c21&base=USD";

            string apiResponse = await GetDataFromWebAPIAsync(strUrl);

            ExchangeRates cer = JsonConvert.DeserializeObject<ExchangeRates>(apiResponse);

            return cer;
        }
    }
}
