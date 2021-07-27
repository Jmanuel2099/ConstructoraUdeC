using ConstructoraUdeCModel.DbModel.SecurityModel;
using ConstructoraUdeCModel.Mapper.ParametersModule;
using ConstructoraUdeCModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace ConstructoraUdeCModel.Mapper.SecurityModule
{
    public class UserModelMapper : GeneralMapper<SEC_USER, UserDbModel>
    {
        public override UserDbModel MapperT1T2(SEC_USER input)
        {
            //var cityAction = input.CITY;
            CityModelMapper cityMapper = new CityModelMapper();
            var roles = input.SEC_USER_ROLE.Select(x => x.SEC_ROLE);
            RoleModelMapper roleMapper = new RoleModelMapper();

            return new UserDbModel
            {
                Id = input.ID,
                Name = input.NAME,
                LastName = input.LASTNAME,
                Cellphone = input.CELLPHONE,
                Email = input.EMAIL,
                Password = input.USER_PASSWORD,
                CityAction = cityMapper.MapperT1T2(input.CITY),
                Roles = roleMapper.MapperT1T2(roles),
                Token = input.SEC_SESSION.Where(x => x.TOKEN_STATUS).OrderByDescending(d => d.LOGIN_DATE).Select(z => z.TOKEN).FirstOrDefault()
            };
        }

        public override IEnumerable<UserDbModel> MapperT1T2(IEnumerable<SEC_USER> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override SEC_USER MapperT2T1(UserDbModel input)
        {
            return new SEC_USER
            {
                ID = input.Id,
                NAME = input.Name,
                LASTNAME = input.LastName,
                CELLPHONE = input.Cellphone,
                EMAIL = input.Email,
                USER_PASSWORD = input.Password,
                ACTIONCITY = input.CityActionId
            };
        }

        public override IEnumerable<SEC_USER> MapperT2T1(IEnumerable<UserDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
