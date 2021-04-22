using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Mapper.ParametersModule
{
    public class ProjectModelMapper: GeneralMapper<PROJECT, ProjectDbModel>
    {
        public override ProjectDbModel MapperT1T2(PROJECT input)
        {
            CityModelMapper countryMapper = new CityModelMapper();

            return new ProjectDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Image = input.IMAGE,
                City = countryMapper.MapperT1T2(input.CITY1),
                Removed = input.REMOVED
            };
        }

        public override IEnumerable<ProjectDbModel> MapperT1T2(IEnumerable<PROJECT> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PROJECT MapperT2T1(ProjectDbModel input)
        {
            return new PROJECT
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                IMAGE = input.Image,
                CITY = input.CityId,
                REMOVED = input.Removed,
            };
        }

        public override IEnumerable<PROJECT> MapperT2T1(IEnumerable<ProjectDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }

}

