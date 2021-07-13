using ConstructoraUdeC.Models.ParametersModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.Mapper.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.ParametersModule
{
    public class PropertyModelMapper : GeneralMapper<PropertyDTO, PropertyModel>
    {
        public override PropertyModel MapperT1T2(PropertyDTO input)
        {
            BlockModelMapper blockMapper = new BlockModelMapper();
            return new PropertyModel
            {
                Id = input.Id,
                Code = input.Code,
                Identification = input.Identification,
                Val = input.Val,
                Status = input.Status,
                Block = blockMapper.MapperT1T2(input.Block),
                Removed = input.Removed
            };
        }

        public override IEnumerable<PropertyModel> MapperT1T2(IEnumerable<PropertyDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PropertyDTO MapperT2T1(PropertyModel input)
        {
            return new PropertyDTO
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

        public override IEnumerable<PropertyDTO> MapperT2T1(IEnumerable<PropertyModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}