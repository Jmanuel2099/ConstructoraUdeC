using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.DTO.ParametersModule
{
    public class CityDTO
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

        private int countryId;

        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        private CountryDTO country;

        public CountryDTO Country
        {
            get { return country; }
            set { country = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private IEnumerable<CountryDTO> countryList;

        public IEnumerable<CountryDTO> CountryList
        {
            get { return countryList; }
            set { countryList = value; }
        }

    }
}
