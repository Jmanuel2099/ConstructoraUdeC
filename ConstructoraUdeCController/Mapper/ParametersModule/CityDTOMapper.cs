using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.Implementation.ParametersModule;
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
        private CountryImpController modelCountry = new CountryImpController();

        public override CityDTO MapperT1T2(CityDbModel input)
        {
            CountryDTOMapper countryMapper = new CountryDTOMapper();

            return new CityDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Country = countryMapper.MapperT1T2(input.Country),
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
                Removed = input.Removed,
                CountryId = input.CountryId
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
