using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.SecurityModule
{
    public class LoginModel
    {
        private string userName;
        [DisplayName("Correo electronico")]
        [Required()]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password;
        [DisplayName("Contraseña")]
        [Required()]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}