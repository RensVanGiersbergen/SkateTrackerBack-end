using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer;
using Interface_Layer.dto;
using Factory_Layer;

namespace Logic_Layer
{
    public class PositionCollection
    {
        IPositionCollectionDAL positionCollectionDAL;
        public PositionCollection()
        {
            positionCollectionDAL = Factory.CreateIPositionCollectionDAL();
        }
        public PositionCollection(string name)
        {
            positionCollectionDAL = Factory.CreateIPositionCollectionDAL(name);
        }
        
        public List<Position> GetAllByJourney(int ID)
        {
            List<Position> positions = new List<Position>();
            foreach(DTOPosition dto in positionCollectionDAL.GetPositionsByJourney(ID))
            {
                positions.Add((Position)dto);
            }
            return positions;
        }

        public void Add(Position position)
        {
            positionCollectionDAL.AddPosition((DTOPosition)position);
        }
    }
}
