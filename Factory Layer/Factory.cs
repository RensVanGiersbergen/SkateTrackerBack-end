using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer;
using Data_Access;

namespace Factory_Layer
{
    public class Factory
    {
        public static IPositionCollectionDAL CreateIPositionCollectionDAL()
        {
            return new Queries();
        }
        public static IPositionCollectionDAL CreateIPositionCollectionDAL(string name)
        {
            return new Queries(name);
        }

        public static IJourneyCollectionDAL CreateIJourneyCollectionDAL()
        {
            return new Queries();
        }
        public static IJourneyCollectionDAL CreateIJourneyCollectionDAL(string name)
        {
            return new Queries(name);
        }
    }
}
