using ConstructoraUdeC.Mapper.ParametersModule;
using ConstructoraUdeC.Models.SalesModule;
using ConstructoraUdeCController.DTO.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.SalesModule
{
    public class RequestModelMapper: GeneralMapper<RequestDTO, RequestModel>
    {
        public override RequestModel MapperT1T2(RequestDTO input)
        {
            StatusRequestModelMapper statusMapper = new StatusRequestModelMapper();
            CustomerModelMapper customerMapper = new CustomerModelMapper();
            PropertyModelMapper propertyMapper = new PropertyModelMapper();
            return new RequestModel
            {
                Id = input.Id,
                RequestDate = input.RequestDate,
                Offer = input.Offer,
                StatusRequest = statusMapper.MapperT1T2(input.StatusRequest),
                Customer = customerMapper.MapperT1T2(input.Customer),
                Property = propertyMapper.MapperT1T2(input.Property)
            };
        }
        public override IEnumerable<RequestModel> MapperT1T2(IEnumerable<RequestDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override RequestDTO MapperT2T1(RequestModel input)
        {
            return new RequestDTO
            {
                Id = input.Id,
                RequestDate = input.RequestDate,
                Offer = input.Offer,
                //StatusRequestId = input.StatusRequestId,
                CustomerId = input.CustomerId,
                PropertyId = input.PropertyId
            };
        }
        public override IEnumerable<RequestDTO> MapperT2T1(IEnumerable<RequestModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}