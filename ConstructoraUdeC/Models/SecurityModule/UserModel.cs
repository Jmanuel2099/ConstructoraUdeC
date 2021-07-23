using ConstructoraUdeC.Models.ParametersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.SecurityModule
{
    public class UserModel : ModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        [DisplayName("Nombre")]
        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener una longitud maxima de {1} caracteres")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastname;
        [DisplayName("Apellidos")]
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener una longitud maxima de {1} caracteres")]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string cellphone;
        [DisplayName("Celular")]
        [Required]
        [MaxLength(30, ErrorMessage = "El campo {0} puede tener una longitud maxima de {1} caracteres")]
        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }
        private string email;
        [DisplayName("Email")]
        [Required]
        [MaxLength(110, ErrorMessage = "El campo {0} puede tener una longitud maxima de {1} caracteres")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;
        [DisplayName("Contraseña")]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener una longitud maxima de {1} caracteres")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string newpassword;
        [DisplayName("Nueva contraseña")]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener una longitud maxima de {1} caracteres")]
        public string NewPassword
        {
            get { return newpassword; }
            set { newpassword = value; }
        }

        private int cityActionId;
        [DisplayName("Ciudad de accion")]
        [Required()]
        public int CityActionId
        {
            get { return cityActionId; }
            set { cityActionId = value; }
        }

        private CityModel cityAction;

        public CityModel CityAction
        {
            get { return cityAction; }
            set { cityAction = value; }
        }

        private IEnumerable<CityModel> cityActionList;

        public IEnumerable<CityModel> CityActionList
        {
            get { return cityActionList; }
            set { cityActionList = value; }
        }

        private int countryId;
        [DisplayName("Pais de accion")]
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

        private IEnumerable<RoleModel> roles;

        public IEnumerable<RoleModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}