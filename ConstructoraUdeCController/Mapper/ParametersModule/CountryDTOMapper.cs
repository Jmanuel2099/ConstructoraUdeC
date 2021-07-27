using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCModel.DbModel.ParametersModule;
using System.Collections.Generic;

namespace ConstructoraUdeCController.Mapper.ParametersModule
{
    class CountryDTOMapper : GeneralMapper<CountryDbModel, CountryDTO>
    {
        public override CountryDTO MapperT1T2(CountryDbModel input)
        {
            return new CountryDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Removed = input.Removed
            };
        }

        public override IEnumerable<CountryDTO> MapperT1T2(IEnumerable<CountryDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CountryDbModel MapperT2T1(CountryDTO input)
        {
            return new CountryDbModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Removed = input.Removed
            };
        }

        public override IEnumerable<CountryDbModel> MapperT2T1(IEnumerable<CountryDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
