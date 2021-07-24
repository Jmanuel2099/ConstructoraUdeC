using ConstructoraUdeCModel.DbModel.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.DbModel.SalesModule
{
    public class RequestDbModel
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

        private StatusRequestDbModel statusRequest;

        public StatusRequestDbModel StatusRequest
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

        private PropertyDbModel property;

        public PropertyDbModel Property
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

        private CustomerDbModel customer;

        public CustomerDbModel Customer
        {
            get { return customer; }
            set { customer = value; }
        }

    }
}
