using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.ParametersModule
{
    public class CityModel
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

        private int country;

        [DisplayName("Pais")]
        [Required()]
        public int Country
        {
            get { return country; }
            set { country = value; }
        }


        private bool removed;
        [DisplayName("Eliminado")]
        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }
    }
}