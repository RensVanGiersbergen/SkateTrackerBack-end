using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer.dto;

namespace Interface_Layer
{
    public interface IJourneyCollectionDAL
    {
        int AddJourney(DTOJourney dto);
        public List<DTOJourney> GetJourneysBySkater(int SkaterID);
    }
}
