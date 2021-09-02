using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repository;

namespace BIZ
{
    /// <summary>
    /// Her er forretningslogikken placeret, sammen med properties der danner grundlag for binding til GUI.
    /// 
    /// ClassNotify nedarves, da alle properties der benytter metoden 'Notify' i ClassNotify skal implementere interfacet INotifyPropertyChanged, som gør det muligt at opdatere objekterne via binding der er knyttet til et property.
    /// </summary>
    public class ClassBIZ : ClassNotify
    {
        // Simpel instans af CurrencyAPICall som gør det muligt at kalde de public metoder denne class stiller til rådighed.
        CurrencyAPICall CAC = new CurrencyAPICall();


        /// <summary>
        /// Default constructor som initialisere de properties der findes i denne class.
        /// Foretager et kald til metoden GetData(), som starter et kald til en WebAPIog indsætter svaret i den rette property.
        /// Derved får man data i ListView så snart man starter programmet.
        /// </summary>
        public ClassBIZ()
        {
            exRates = new ExchangeRates();
            rate = new ClassRates();
            GetData();
        }

        private ClassRates _rate;
        private ExchangeRates _exRates;
        private List<ClassRates> _listRates;

        public ClassRates rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                }
                Notify("rate");
            }
        }

        public ExchangeRates exRates
        {
            get { return _exRates; }
            set
            {
                if (_exRates != value)
                {
                    _exRates = value;
                }
                Notify("exRates");
            }
        }

        public List<ClassRates> listRates
        {
            get { return _listRates; }
            set
            {
                if (_listRates != value)
                {
                    _listRates = value;
                }
                Notify("listRates");
            }
        }

        /// <summary>
        /// Denne metode starter et asynkront kald til en metode i 'CAC' som er en instans af CurrencyAPICall. Metoden i CurrencyAPICall er asynkron, men denne metode er ikke asynkron og kan derfor ikke kalde metoden direkte.
        /// Der benyttes Lambda i kombination med Task.Run til at muliggøre kaldet fra en synkron metode til en asynkron metode.
        /// Da resultatet som modtages er abstrakt, benyttes casting til at transformere resultatet til datatypen ExchangeRates som gemmes i propertiet 'exRates'.
        /// 
        /// Herefter foretages et kald til metoden SetupListRates().
        /// </summary>
        private void GetData()
        {
            var task = Task.Run(async () => await CAC.GetAPIDataAsync());
            exRates = (ExchangeRates)task.Result;
            SetupListRates();
        }

        /// <summary>
        /// Denne metode har til formål at generere en ny samling af data, baseret på det datasæt som er hentet fra en Web API og lagret i 'exRates'.
        /// Resultatet af denne metode skal gemmes i 'listRates' som er en List (collection) af ClassRates.
        /// For rhvert element i 'exRates' oprettes der en ny instans af ClassRates. Denne nye instans oprettes via en overloaded constructor. Denne constructor får 3 parameter overført.
        /// 1 - datatype: ExchangeRates med alle data
        /// 2 - datatype: string som er en Key der angiver valutakoden som skal benyttes.
        /// 3 - datatype: long som angiver den valutakurs for den aktuelle valuta (Key).
        /// Ved at benytte denn overloaded constructor, kan der oprettes en instans af ClassRates hvor yderligere properties bliver initialiseret med data der knytter sig til denne valutakode.
        /// </summary>
        private void SetupListRates()
        {
            List<ClassRates> temp = new List<ClassRates>();

            foreach (var item in exRates.rates)
            {
                ClassRates cr = new ClassRates(exRates, item.Key, item.Value);
                temp.Add(cr);
            }
            listRates = temp;
        }
    }
}
