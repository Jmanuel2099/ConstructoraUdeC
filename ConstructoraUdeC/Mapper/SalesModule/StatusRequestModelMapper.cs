using ConstructoraUdeC.Models.SalesModule;
using ConstructoraUdeCController.DTO.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.SalesModule
{
    public class StatusRequestModelMapper :GeneralMapper<StatusRequestDTO, StatusRequestModel>
    {
        public override StatusRequestModel MapperT1T2(StatusRequestDTO input)
        {
            return new StatusRequestModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }
        public override IEnumerable<StatusRequestModel> MapperT1T2(IEnumerable<StatusRequestDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override StatusRequestDTO MapperT2T1(StatusRequestModel input)
        {
            return new StatusRequestDTO
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }
        public override IEnumerable<StatusRequestDTO> MapperT2T1(IEnumerable<StatusRequestModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}