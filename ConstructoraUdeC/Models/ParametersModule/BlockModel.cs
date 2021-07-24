using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.ParametersModule
{
    public class BlockModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;
        [DisplayName("Codigo")]
        [Required()]
        [MaxLength(50)]
        public string Code
        {
            get { return code; }
            set { code = value; }
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

        private string description;
        [DisplayName("Descripcion")]
        [Required()]
        [MaxLength(100)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private int projectId;
        [DisplayName("Proyecto")]
        [Required()]
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        private ProjectModel project;

        public ProjectModel Project
        {
            get { return project; }
            set { project = value; }
        }

        private IEnumerable<ProjectModel> projectList;

        public IEnumerable<ProjectModel> ProjectList
        {
            get { return projectList; }
            set { projectList = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
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
    }
}