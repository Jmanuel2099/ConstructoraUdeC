using ConstructoraUdeCController.DTO.SalesModule;
using ConstructoraUdeCController.Mapper.ParametersModule;
using ConstructoraUdeCModel.DbModel.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Mapper.SalesModule
{
    public class RequestDTOMapper: GeneralMapper<RequestDbModel, RequestDTO>
    {
        public override RequestDTO MapperT1T2(RequestDbModel input)
        {
            StatusRequestDTOMapper statusMapper = new StatusRequestDTOMapper();
            CustomerDTOMapper customerMapper = new CustomerDTOMapper();
            PropertyDTOMapper propertyMapper = new PropertyDTOMapper();
            return new RequestDTO
            {
                Id = input.Id,
                RequestDate = input.RequestDate,
                Offer = input.Offer,
                StatusRequest = statusMapper.MapperT1T2(input.StatusRequest),
                Customer = customerMapper.MapperT1T2(input.Customer),
                Property = propertyMapper.MapperT1T2(input.Property)
            };
        }
        public override IEnumerable<RequestDTO> MapperT1T2(IEnumerable<RequestDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override RequestDbModel MapperT2T1(RequestDTO input)
        {
            return new RequestDbModel
            {
                Id = input.Id,
                RequestDate = input.RequestDate,
                Offer = input.Offer,
                StatusRequestId = input.StatusRequestId,
                CustomerId = input.CustomerId,
                PropertyId = input.PropertyId
            };
        }
        public override IEnumerable<RequestDbModel> MapperT2T1(IEnumerable<RequestDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
