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
    public class RequestDbModelMapper : GeneralMapper<REQUEST, RequestDbModel>
    {
        public override RequestDbModel MapperT1T2(REQUEST input)
        {
            StatusRequestDbModelMapper statusMapper = new StatusRequestDbModelMapper();
            CustomerDbModelMapper customerMapper = new CustomerDbModelMapper();
            PropertyModelMapper propertyMapper = new PropertyModelMapper();
            return new RequestDbModel
            {
                Id = input.ID,
                RequestDate = input.REQUEST_DATE,
                Offer = input.OFFER,
                StatusRequest = statusMapper.MapperT1T2(input.STATUS_REQUEST1),
                Customer = customerMapper.MapperT1T2(input.CUSTOMER1),
                Property = propertyMapper.MapperT1T2(input.PROPERTY1)
            };
        }
        public override IEnumerable<RequestDbModel> MapperT1T2(IEnumerable<REQUEST> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }
        public override REQUEST MapperT2T1(RequestDbModel input)
        {
            return new REQUEST
            {
                ID = input.Id,
                REQUEST_DATE = input.RequestDate,
                OFFER = input.Offer,
                STATUS_REQUEST = input.StatusRequestId,
                CUSTOMER = input.CustomerId,
                PROPERTY = input.PropertyId
            };
        }
        public override IEnumerable<REQUEST> MapperT2T1(IEnumerable<RequestDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
