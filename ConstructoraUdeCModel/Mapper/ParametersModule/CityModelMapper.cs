using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Mapper.ParametersModule
{
    public class CityModelMapper : GeneralMapper<CITY, CityDbModel>
    {

        public override CityDbModel MapperT1T2(CITY input)
        {
            return new CityDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Country = input.COUNTRY,
                Removed = input.REMOVED
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
                COUNTRY = input.Country,
                REMOVED = input.Removed
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
