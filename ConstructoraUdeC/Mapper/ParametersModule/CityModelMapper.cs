using ConstructoraUdeC.Models.ParametersModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.ParametersModule
{
    public class CityModelMapper: GeneralMapper<CityDTO, CityModel>
    {
        public override CityModel MapperT1T2(CityDTO input)
        {
            return new CityModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Country = input.Country,
                Removed = input.Removed
            };
        }

        public override IEnumerable<CityModel> MapperT1T2(IEnumerable<CityDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CityDTO MapperT2T1(CityModel input)
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

        public override IEnumerable<CityDTO> MapperT2T1(IEnumerable<CityModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }

    }
}