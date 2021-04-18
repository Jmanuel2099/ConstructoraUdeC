using ConstructoraUdeCController.DTO.SecurityModule;
using ConstructoraUdeCModel.DbModel.SecurityModel;
using ConstructoraUdeCModel.Mapper.SecurityModule;
using ConstructoraUdeCModel.Model;
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
            RoleDTOMapper roleMapper = new RoleDTOMapper();
            return new UserDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                Actioncity = input.Actioncity,
                Removed = input.Removed,
                Roles = roleMapper.MapperT1T2(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserDTO> MapperT1T2(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDbModel MapperT2T1(UserDTO input)
        {

            return new UserDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                Actioncity = input.Actioncity,
                Removed = input.Removed,
                
                UserInSessionId = input.UserInSessionId

            };
        }

        public override IEnumerable<UserDbModel> MapperT2T1(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}

