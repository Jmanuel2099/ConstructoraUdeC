using System.Collections.Generic;

namespace ConstructoraUdeCModel.DbModel.ParametersModule
{
    public class CityDbModel
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

        private CountryDbModel country;

        public CountryDbModel Country
        {
            get { return country; }
            set { country = value; }
        }

        private int countryId;

        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private IEnumerable<CountryDbModel> countryList;

        public IEnumerable<CountryDbModel> CountryList
        {
            get { return countryList; }
            set { countryList = value; }
        }

    }
}
