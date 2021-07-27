using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Model;
using System.Collections.Generic;

namespace ConstructoraUdeCModel.Mapper.ParametersModule
{
    public class BlockModelMapper : GeneralMapper<BLOCK, BlockDbModel>
    {
        public override BlockDbModel MapperT1T2(BLOCK input)
        {
            ProjectModelMapper projectMapper = new ProjectModelMapper();

            return new BlockDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Project = projectMapper.MapperT1T2(input.PROJECT1),
                Removed = input.REMOVED
            };
        }

        public override IEnumerable<BlockDbModel> MapperT1T2(IEnumerable<BLOCK> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override BLOCK MapperT2T1(BlockDbModel input)
        {
            return new BLOCK
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                PROJECT = input.ProjectId,
                REMOVED = input.Removed,
            };
        }

        public override IEnumerable<BLOCK> MapperT2T1(IEnumerable<BlockDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
