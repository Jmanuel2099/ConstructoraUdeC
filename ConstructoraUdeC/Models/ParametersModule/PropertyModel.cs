using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.ParametersModule
{
    public class PropertyModel
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

        private string identification;
        [DisplayName("Identificacion")]
        [Required()]
        [MaxLength(30)]
        public string Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        private int val;
        [DisplayName("Valor")]
        [Required()]
        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        private bool status;
        [DisplayName("Vendido")]
        [Required()]
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private bool removed;
        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private int blockId;
        [DisplayName("Bloque")]
        [Required()]
        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        private BlockModel block;

        public BlockModel Block
        {
            get { return block; }
            set { block = value; }
        }

        private IEnumerable<BlockModel> blockList;

        public IEnumerable<BlockModel> BlockList
        {
            get { return blockList; }
            set { blockList = value; }
        }

        private int projectId;
        [DisplayName("Proyecto ")]
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
        [DisplayName("Pais")]
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