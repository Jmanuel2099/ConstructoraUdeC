using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Mapper.ParametersModule
{
    public class PropertyModelMapper : GeneralMapper<PROPERTY, PropertyDbModel>
    {
        public override PropertyDbModel MapperT1T2(PROPERTY input)
        {
            BlockModelMapper BlockMapper = new BlockModelMapper();

            return new PropertyDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Identification = input.IDENTIFICATION,
                Val = input.VALUE,
                Status = input.STATUS,
                Block = BlockMapper.MapperT1T2(input.BLOCK1),
                Removed = input.REMOVED
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT1T2(IEnumerable<PROPERTY> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PROPERTY MapperT2T1(PropertyDbModel input)
        {
            return new PROPERTY
            {
                ID = input.Id,
                CODE = input.Code,
                IDENTIFICATION = input.Identification,
                VALUE = input.Val,
                STATUS = input.Status,
                BLOCK = input.BlockId,
                REMOVED = input.Removed
            };
        }

        public override IEnumerable<PROPERTY> MapperT2T1(IEnumerable<PropertyDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
