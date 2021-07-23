using ConstructoraUdeCModel.DbModel.SalesModule;
using ConstructoraUdeCModel.Mapper.ParametersModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Mapper.SalesModule
{
    public class CustomerDbModelMapper : GeneralMapper<CUSTOMER, CustomerDbModel>
    {
        public override CustomerDbModel MapperT1T2(CUSTOMER input)
        {
            //var cityAction = input.CITY;
            CityModelMapper cityMapper = new CityModelMapper();

            return new CustomerDbModel
            {
                Id = input.ID,
                Document = input.DOCUMENT,
                Name = input.NAME,
                LastName = input.LASTNAME,
                Photo = input.PHOTO,
                Phone = input.PHONE,
                Date = input.BIRTHDATE,
                Email = input.EMAIL,
                Address = input.ADDRESS,
                City = cityMapper.MapperT1T2(input.CITY1),
                Removed = input.REMOVED
            };
        }
        public override IEnumerable<CustomerDbModel> MapperT1T2(IEnumerable<CUSTOMER> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CUSTOMER MapperT2T1(CustomerDbModel input)
        {
            return new CUSTOMER
            {
                ID = input.Id,
                DOCUMENT = input.Document,
                NAME = input.Name,
                LASTNAME = input.LastName,
                PHOTO = input.Photo,
                PHONE = input.Phone,
                BIRTHDATE = input.Date,
                EMAIL = input.Email,
                ADDRESS = input.Address,
                CITY = input.CityId,
                REMOVED = input.Removed
            };
        }
        public override IEnumerable<CUSTOMER> MapperT2T1(IEnumerable<CustomerDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
