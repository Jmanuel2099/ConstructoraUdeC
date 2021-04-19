using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Mapper.ParametersModule
{
    public class CountryModelMapper : GeneralMapper<COUNTRY, CountryDbModel>
    {

        public override CountryDbModel MapperT1T2(COUNTRY input)
        {
            return new CountryDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Removed = input.REMOVED
            };
        }

        public override IEnumerable<CountryDbModel> MapperT1T2(IEnumerable<COUNTRY> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override COUNTRY MapperT2T1(CountryDbModel input)
        {
            return new COUNTRY
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                REMOVED = input.Removed
            };
        }

        public override IEnumerable<COUNTRY> MapperT2T1(IEnumerable<CountryDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
