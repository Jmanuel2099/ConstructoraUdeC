using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCModel.DbModel.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Mapper.ParametersModule
{
    public class ProjectDTOMapper : GeneralMapper<ProjectDbModel, ProjectDTO>
    {
        public override ProjectDTO MapperT1T2(ProjectDbModel input)
        {
            CityDTOMapper cityMapper = new CityDTOMapper();

            return new ProjectDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Image = input.Image,
                City = cityMapper.MapperT1T2(input.City),
                Removed = input.Removed
            };
        }

        public override IEnumerable<ProjectDTO> MapperT1T2(IEnumerable<ProjectDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override ProjectDbModel MapperT2T1(ProjectDTO input)
        {
            return new ProjectDbModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Image = input.Image,
                CityId = input.CityId,
                Removed = input.Removed,
            };
        }

        public override IEnumerable<ProjectDbModel> MapperT2T1(IEnumerable<ProjectDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
