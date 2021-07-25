using ConstructoraUdeC.Models.ParametersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.SalesModule
{
    public class RequestModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime requestDate;
        [DisplayName("Fecha de solicitud")]
        public DateTime RequestDate
        {
            get { return requestDate; }
            set { requestDate = value; }
        }

        private int offer;
        [DisplayName("Oferta")]
        public int Offer
        {
            get { return offer; }
            set { offer = value; }
        }
        private int statusRequestId;
        [DisplayName("Estado")]
        public int StatusRequestId
        {
            get { return statusRequestId; }
            set { statusRequestId = value; }
        }

        private StatusRequestModel statusRequest;

        public StatusRequestModel StatusRequest
        {
            get { return statusRequest; }
            set { statusRequest = value; }
        }
        private IEnumerable<StatusRequestModel> statusRequestList;

        public IEnumerable<StatusRequestModel> StatusRequestList
        {
            get { return statusRequestList; }
            set { statusRequestList = value; }
        }



        private int propertyId;
        [DisplayName("Propiedad")]
        public int PropertyId
        {
            get { return propertyId; }
            set { propertyId = value; }
        }

        private PropertyModel property;

        public PropertyModel Property
        {
            get { return property; }
            set { property = value; }
        }

        private IEnumerable<PropertyModel> propertyList;

        public IEnumerable<PropertyModel> PropertyList
        {
            get { return propertyList; }
            set { propertyList = value; }
        }


        private int customerId;
        [DisplayName("Cliente")]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private CustomerModel customer;

        public CustomerModel Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private IEnumerable<CustomerModel> customerList;

        public IEnumerable<CustomerModel> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }

    }
}