using ConstructoraUdeC.Models.SecurityModule;
using ConstructoraUdeCController.DTO.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.SecurityModule
{
    public class UserModelMapper : GeneralMapper<UserDTO, UserModel>
    {
        public override UserModel MapperT1T2(UserDTO input)
        {
            RoleModelMapper roleMapper = new RoleModelMapper();
            return new UserModel()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                Actioncity = input.Actioncity,
                Removed = input.Removed,
                Roles = input.Roles,
                Token = input.Token
            };
        }

        public override IEnumerable<UserModel> MapperT1T2(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDTO MapperT2T1(UserModel input)
        {

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
                UserInSessionId = input.UserInSessionId


            };
        }

        public override IEnumerable<UserDTO> MapperT2T1(IEnumerable<UserModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }


    }
}