using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.DbModel.ParametersModule
{
    public class ProjectDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
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

        private int countryId;

        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        private CountryDbModel country;

        public CountryDbModel Country
        {
            get { return country; }
            set { country = value; }
        }


        private IEnumerable<CountryDbModel> conutryList;

        public IEnumerable<CountryDbModel> ConutryList
        {
            get { return conutryList; }
            set { conutryList = value; }
        }

    }
}
