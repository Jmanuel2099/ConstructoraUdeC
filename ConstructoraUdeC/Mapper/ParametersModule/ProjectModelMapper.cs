using ConstructoraUdeC.Models.ParametersModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ConstructoraUdeC.Models.ParametersModule.ProjectModel;

namespace ConstructoraUdeC.Mapper.ParametersModule
{
    public class ProjectModelMapper: GeneralMapper<ProjectDTO,ProjectModel>
    {
        public override ProjectModel MapperT1T2(ProjectDTO input)
        {
            CityModelMapper countryMapper = new CityModelMapper();

            return new ProjectModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Image = input.Image,
                City = countryMapper.MapperT1T2(input.City),
                Removed = input.Removed
            };
        }

        public override IEnumerable<ProjectModel> MapperT1T2(IEnumerable<ProjectDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override ProjectDTO MapperT2T1(ProjectModel input)
        {
            return new ProjectDTO
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

        public override IEnumerable<ProjectDTO> MapperT2T1(IEnumerable<ProjectModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}