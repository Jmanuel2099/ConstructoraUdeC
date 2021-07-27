﻿using ConstructoraUdeCModel.DbModel.SecurityModel;
using ConstructoraUdeCModel.Model;
using System.Collections.Generic;

namespace ConstructoraUdeCModel.Mapper.SecurityModule
{
    public class RoleModelMapper : GeneralMapper<SEC_ROLE, RoleDbModel>
    {
        public override RoleDbModel MapperT1T2(SEC_ROLE input)
        {
            return new RoleDbModel
            {
                Id = input.ID,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Removed = input.REMOVED
            };
        }

        public override IEnumerable<RoleDbModel> MapperT1T2(IEnumerable<SEC_ROLE> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override SEC_ROLE MapperT2T1(RoleDbModel input)
        {
            return new SEC_ROLE
            {
                ID = input.Id,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                REMOVED = input.Removed
            };
        }

        public override IEnumerable<SEC_ROLE> MapperT2T1(IEnumerable<RoleDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
