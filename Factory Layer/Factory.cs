using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer;
using Data_Access;
using Interface_Layer.dto;

namespace Factory_Layer
{
    public class Factory
    {
        public static IJourneyCollectionDAL journeyDAL = new Queries();
        public static IPositionCollectionDAL positionDAL = new Queries();
        public static IPositionCollectionDAL CreateIPositionCollectionDAL()
        {
            return positionDAL;
        }
        public static IPositionCollectionDAL CreateIPositionCollectionDAL(string name)
        {
            return new Queries(name);
        }

        public static IJourneyCollectionDAL CreateIJourneyCollectionDAL()
        {
            return journeyDAL;
        }
        public static IJourneyCollectionDAL CreateIJourneyCollectionDAL(string name)
        {
            return new Queries(name);
        }
        public static void SetMockDAL()
        {
            //Setting up MockDAL in logic layer for tests
            positionDAL = new Queries("integrationTest");
            journeyDAL = new Queries("integrationTest");

            //Setting up mockdata for tests
            journeyDAL.AddJourney(new DTOJourney() { Name = "journey1", SkaterID = 1 });
            positionDAL.AddPosition(new DTOPosition() { JourneyID = 1, Speed = 5 });
            positionDAL.AddPosition(new DTOPosition() { JourneyID = 1, Speed = 6 });
        }
    }
}
