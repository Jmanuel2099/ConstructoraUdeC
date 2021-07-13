using ConstructoraUdeC.Models.ParametersModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.ParametersModule
{
    public class BlockModelMapper : GeneralMapper<BlockDTO, BlockModel>
    {
        public override BlockModel MapperT1T2(BlockDTO input)
        {
            ProjectModelMapper projectMapper = new ProjectModelMapper();

            return new BlockModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Project = projectMapper.MapperT1T2(input.Project),
                Removed = input.Removed
            };
        }

        public override IEnumerable<BlockModel> MapperT1T2(IEnumerable<BlockDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override BlockDTO MapperT2T1(BlockModel input)
        {
            return new BlockDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                ProjectId = input.ProjectId,
                Removed = input.Removed,
            };
        }

        public override IEnumerable<BlockDTO> MapperT2T1(IEnumerable<BlockModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}