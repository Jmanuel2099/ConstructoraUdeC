using ConstructoraUdeCController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.DTO.SalesModule
{
    public class RequestDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime requestDate;

        public DateTime RequestDate
        {
            get { return requestDate; }
            set { requestDate = value; }
        }

        private int offer;

        public int Offer
        {
            get { return offer; }
            set { offer = value; }
        }
        private int statusRequestId;

        public int StatusRequestId
        {
            get { return statusRequestId; }
            set { statusRequestId = value; }
        }

        private StatusRequestDTO statusRequest;

        public StatusRequestDTO StatusRequest
        {
            get { return statusRequest; }
            set { statusRequest = value; }
        }


        private int propertyId;

        public int PropertyId
        {
            get { return propertyId; }
            set { propertyId = value; }
        }

        private PropertyDTO property;

        public PropertyDTO Property
        {
            get { return property; }
            set { property = value; }
        }

        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private CustomerDTO customer;

        public CustomerDTO Customer
        {
            get { return customer; }
            set { customer = value; }
        }
    }
}
