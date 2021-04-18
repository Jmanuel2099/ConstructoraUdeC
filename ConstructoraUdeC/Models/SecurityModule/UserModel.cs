using ConstructoraUdeCController.DTO.SecurityModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.SecurityModule
{
    public class UserModel : GeneralModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        private string lastname;
        [DisplayName("Apellidos")]
        [Required()]
        [MaxLength(100)]

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string cellphone;
        [DisplayName("Celular")]
        [MaxLength(30)]
        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }

        private string email;
        [DisplayName("Email")]
        [Required()]
        [MaxLength(100)]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private IEnumerable<RoleDTO> roles;

        public IEnumerable<RoleDTO> Roles
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

        private string actioncity;
        [DisplayName("Ciudad de accion")]
        [MaxLength(100)]

        public string Actioncity
        {
            get { return actioncity; }
            set { actioncity = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }











    }
}