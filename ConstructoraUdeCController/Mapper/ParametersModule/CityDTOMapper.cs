using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCModel.DbModel.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Mapper.ParametersModule
{
    public class CityDTOMapper: GeneralMapper<CityDbModel, CityDTO>
    {

        public override CityDTO MapperT1T2(CityDbModel input)
        {
            return new CityDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Country = input.Country,
                Removed = input.Removed
            };
        }

        public override IEnumerable<CityDTO> MapperT1T2(IEnumerable<CityDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CityDbModel MapperT2T1(CityDTO input)
        {
            return new CityDbModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Country = input.Country,
                Removed = input.Removed
            };
        }

        public override IEnumerable<CityDbModel> MapperT2T1(IEnumerable<CityDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
