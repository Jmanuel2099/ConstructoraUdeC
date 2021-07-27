using ConstructoraUdeCModel.DbModel.ParametersModule;
using System;
using System.Collections.Generic;

namespace ConstructoraUdeCModel.DbModel.SalesModule
{
    public class CustomerDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string document;

        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string photo;

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int cityId;

        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        private CityDbModel city;

        public CityDbModel City
        {
            get { return city; }
            set { city = value; }
        }

        private IEnumerable<CityDbModel> cityList;

        public IEnumerable<CityDbModel> CityList
        {
            get { return cityList; }
            set { cityList = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }
    }
}
