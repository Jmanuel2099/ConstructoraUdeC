using ConstructoraUdeC.Models.ParametersModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.ParametersModule
{
    public class CountryModelMapper : GeneralMapper<CountryDTO, CountryModel>
    {
        public override CountryModel MapperT1T2(CountryDTO input)
        {
            return new CountryModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Removed = input.Removed
            };
        }

        public override IEnumerable<CountryModel> MapperT1T2(IEnumerable<CountryDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CountryDTO MapperT2T1(CountryModel input)
        {
            return new CountryDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Removed = input.Removed
            };
        }

        public override IEnumerable<CountryDTO> MapperT2T1(IEnumerable<CountryModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}