using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCModel.DbModel.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Mapper.ParametersModule
{
    public class PropertyDTOMapper : GeneralMapper<PropertyDbModel, PropertyDTO>
    {
        public override PropertyDTO MapperT1T2(PropertyDbModel input)
        {
            BlockDTOMapper BlockMapper = new BlockDTOMapper();

            return new PropertyDTO
            {
                Id = input.Id,
                Code = input.Code,
                Identification = input.Identification,
                Val = input.Val,
                Status = input.Status,
                Block = BlockMapper.MapperT1T2(input.Block),
                Removed = input.Removed
            };
        }

        public override IEnumerable<PropertyDTO> MapperT1T2(IEnumerable<PropertyDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PropertyDbModel MapperT2T1(PropertyDTO input)
        {
            return new PropertyDbModel
            {
                Id = input.Id,
                Code = input.Code,
                Identification = input.Identification,
                Val = input.Val,
                Status = input.Status,
                BlockId = input.BlockId,
                Removed = input.Removed
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT2T1(IEnumerable<PropertyDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
