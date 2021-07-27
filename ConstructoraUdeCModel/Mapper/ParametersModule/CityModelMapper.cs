using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Implementation.ParametersModule;
using ConstructoraUdeCModel.Model;
using System.Collections.Generic;

namespace ConstructoraUdeCModel.Mapper.ParametersModule
{
    public class CityModelMapper : GeneralMapper<CITY, CityDbModel>
    {
        private CountryImpModel model = new CountryImpModel();

        public override CityDbModel MapperT1T2(CITY input)
        {
            var country = input.COUNTRY1;
            CountryModelMapper countryMapper = new CountryModelMapper();

            //IEnumerable<CountryDbModel> countries = model.RecordList("");

            return new CityDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Country = countryMapper.MapperT1T2(country),
                Removed = (bool)input.REMOVED
            };
        }

        public override IEnumerable<CityDbModel> MapperT1T2(IEnumerable<CITY> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CITY MapperT2T1(CityDbModel input)
        {
            return new CITY
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                REMOVED = input.Removed,
                COUNTRY = input.CountryId
            };
        }

        public override IEnumerable<CITY> MapperT2T1(IEnumerable<CityDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
