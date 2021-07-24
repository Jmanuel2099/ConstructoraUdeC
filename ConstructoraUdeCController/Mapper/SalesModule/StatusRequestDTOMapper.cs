using ConstructoraUdeCController.DTO.SalesModule;
using ConstructoraUdeCModel.DbModel.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Mapper.SalesModule
{
    public class StatusRequestDTOMapper: GeneralMapper<StatusRequestDbModel, StatusRequestDTO>
    {
        public override StatusRequestDTO MapperT1T2(StatusRequestDbModel input)
        {
            return new StatusRequestDTO
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }
        public override IEnumerable<StatusRequestDTO> MapperT1T2(IEnumerable<StatusRequestDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override StatusRequestDbModel MapperT2T1(StatusRequestDTO input)
        {
            return new StatusRequestDbModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }
        public override IEnumerable<StatusRequestDbModel> MapperT2T1(IEnumerable<StatusRequestDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
