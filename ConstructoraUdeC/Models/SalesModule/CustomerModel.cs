using ConstructoraUdeC.Models.ParametersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.SalesModule
{
    public class CustomerModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string document;
        [DisplayName("Documento")]
        [Required()]
        [MaxLength(11)]
        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        private string name;
        [DisplayName("Nombre")]
        [Required()]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastName;
        [DisplayName("Apellidos")]
        [Required()]
        [MaxLength(100)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string photo;
        [DisplayName("Foto")]
        [Required()]
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private string phone;
        [DisplayName("Celular")]
        [Required()]
        [MaxLength(10)]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private DateTime date;
        [DisplayName("Cumpleaños")]
        [Required()]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string email;
        [DisplayName("Correo")]
        [Required()]
        [MaxLength(100)]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;
        [DisplayName("Direccio")]
        [Required()]
        [MaxLength(100)]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int cityId;
        [DisplayName("Ciudad")]
        [Required()]
        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        private CityModel city;

        public CityModel City
        {
            get { return city; }
            set { city = value; }
        }

        private IEnumerable<CityModel> cityList;

        public IEnumerable<CityModel> CityList
        {
            get { return cityList; }
            set { cityList = value; }
        }
        private int countryId;
        [DisplayName("Pais ")]
        [Required()]
        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        private CountryModel country;

        public CountryModel Country
        {
            get { return country; }
            set { country = value; }
        }


        private IEnumerable<CountryModel> countryList;

        public IEnumerable<CountryModel> CountryList
        {
            get { return countryList; }
            set { countryList = value; }
        }
        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private string maxDate;

        public string MaxDate
        {
            get { return DateTime.Now.AddYears(-18).ToString("yyyy-MM-dd"); }
        }

    }
}