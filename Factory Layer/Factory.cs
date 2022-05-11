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
        public static IPositionCollectionDAL CreateIPositionCollectionDAL(bool test)
        {
            return new Queries(test);
        }

        public static IJourneyCollectionDAL CreateIJourneyCollectionDAL(bool test)
        {
            return new Queries(test);
        }
    }
}
