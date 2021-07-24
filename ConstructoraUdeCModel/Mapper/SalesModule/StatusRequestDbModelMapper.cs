using ConstructoraUdeCModel.DbModel.SalesModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Mapper.SalesModule
{
    public class StatusRequestDbModelMapper : GeneralMapper<STATUS_REQUEST, StatusRequestDbModel>
    {
        public override StatusRequestDbModel MapperT1T2(STATUS_REQUEST input)
        {
            return new StatusRequestDbModel
            {
                Id = input.ID,
                Name = input.NAME,
                Description = input.DESCRIPTION
            };
        }
        public override IEnumerable<StatusRequestDbModel> MapperT1T2(IEnumerable<STATUS_REQUEST> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override STATUS_REQUEST MapperT2T1(StatusRequestDbModel input)
        {
            return new STATUS_REQUEST
            {
                ID = input.Id,
                NAME = input.Name,
                DESCRIPTION = input.Description
            };
        }
        public override IEnumerable<STATUS_REQUEST> MapperT2T1(IEnumerable<StatusRequestDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
