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
        IPositionCollectionDAL positionCollectionDAL = Factory.CreateIPositionCollectionDAL();
        public void Add(Position position)
        {
            positionCollectionDAL.AddPosition((DTOPosition)position);
        }
    }
}
