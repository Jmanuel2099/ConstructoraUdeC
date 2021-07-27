using System.Collections.Generic;

namespace ConstructoraUdeCController.DTO.ParametersModule
{
    public class ProjectDTO
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

        private CityDTO city;

        public CityDTO City
        {
            get { return city; }
            set { city = value; }
        }

        private IEnumerable<CityDTO> cityList;

        public IEnumerable<CityDTO> CityList
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
