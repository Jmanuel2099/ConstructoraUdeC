using ConstructoraUdeCController.DTO.SecurityModule;
using ConstructoraUdeCController.Mapper.ParametersModule;
using ConstructoraUdeCModel.DbModel.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Mapper.SecurityModule
{
    public class UserDTOMapper : GeneralMapper<UserDbModel, UserDTO>
    {
        public override UserDTO MapperT1T2(UserDbModel input)
        {
            CityDTOMapper cityMapper = new CityDTOMapper();
            RoleDTOMapper roleMapper = new RoleDTOMapper();
            return new UserDTO
            {
                Id = input.Id,
                Name = input.Name,
                LastName = input.LastName,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                CityAction = cityMapper.MapperT1T2(input.CityAction),
                Roles = roleMapper.MapperT1T2(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserDTO> MapperT1T2(IEnumerable<UserDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override UserDbModel MapperT2T1(UserDTO input)
        {
            return new UserDbModel
            {
                Id = input.Id,
                Name = input.Name,
                LastName = input.LastName,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                CityActionId = input.CityActionId,
                UserInSessionId = input.UserInSessionId,
                CurrentDate = input.CurrentDate
            };
        }

        public override IEnumerable<UserDbModel> MapperT2T1(IEnumerable<UserDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
