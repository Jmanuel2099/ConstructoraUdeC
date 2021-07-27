using ConstructoraUdeCController.DTO.SalesModule;
using ConstructoraUdeCController.Mapper.ParametersModule;
using ConstructoraUdeCModel.DbModel.SalesModule;
using System.Collections.Generic;

namespace ConstructoraUdeCController.Mapper.SalesModule
{
    public class CustomerDTOMapper : GeneralMapper<CustomerDbModel, CustomerDTO>
    {
        public override CustomerDTO MapperT1T2(CustomerDbModel input)
        {
            //var cityAction = input.CITY;
            CityDTOMapper cityMapper = new CityDTOMapper();

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
                City = cityMapper.MapperT1T2(input.City),
                Removed = input.Removed
            };
        }
        public override IEnumerable<CustomerDTO> MapperT1T2(IEnumerable<CustomerDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override CustomerDbModel MapperT2T1(CustomerDTO input)
        {
            return new CustomerDbModel
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
        public override IEnumerable<CustomerDbModel> MapperT2T1(IEnumerable<CustomerDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
