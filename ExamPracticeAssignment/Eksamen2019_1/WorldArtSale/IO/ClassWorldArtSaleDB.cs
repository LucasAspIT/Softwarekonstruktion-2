using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    class ClassWorldArtSaleDB : ClassDbCon
    {

        public List<ClassCustomer> GetAllCustomerFromDB(ClassCurrency inCurrency)
        {
            List<ClassCustomer> res = new List<ClassCustomer>();

            return res;
        }

        public List<ClassArt> GetAllArtFromDB()
        {
            List<ClassArt> res = new List<ClassArt>();

            return res;
        }
    }
}
