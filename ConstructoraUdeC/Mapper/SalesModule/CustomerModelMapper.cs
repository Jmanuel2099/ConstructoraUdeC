using ConstructoraUdeC.Mapper.ParametersModule;
using ConstructoraUdeC.Models.SalesModule;
using ConstructoraUdeCController.DTO.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.SalesModule
{
    public class CustomerModelMapper : GeneralMapper<CustomerDTO, CustomerModel>
    {
        public override CustomerModel MapperT1T2(CustomerDTO input)
        {
            //var cityAction = input.CITY;
            CityModelMapper cityMapper = new CityModelMapper();

            return new CustomerModel
            {
                Id = input.Id,
                Document = input.Document,
                Name = input.Name,
                LastName = input.LastName,
                Photo = input.Photo,
                Phone = input.Phone,
                Date = input.Date,
                Email = input.Email,
                Address = input.Address,
                City = cityMapper.MapperT1T2(input.City),
                Removed = input.Removed
            };
        }
        public override IEnumerable<CustomerModel> MapperT1T2(IEnumerable<CustomerDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override CustomerDTO MapperT2T1(CustomerModel input)
        {
            return new CustomerDTO
            {
                Id = input.Id,
                Document = input.Document,
                Name = input.Name,
                LastName = input.LastName,
                Photo = input.Photo,
                Phone = input.Phone,
                Date = input.Date,
                Email = input.Email,
                Address = input.Address,
                CityId = input.CityId,
                Removed = input.Removed
            };
        }
        public override IEnumerable<CustomerDTO> MapperT2T1(IEnumerable<CustomerModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}