using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer.dto;

namespace Interface_Layer
{
    public interface IPositionCollectionDAL
    {
        public List<DTOPosition> GetPositionsByJourney(int ID);
        void AddPosition(DTOPosition dto);
    }
}
