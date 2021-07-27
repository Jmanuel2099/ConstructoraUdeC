using ConstructoraUdeCController.DTO.ParametersModule;
using System.Collections.Generic;

namespace ConstructoraUdeCController.DTO.SecurityModule
{
    public class UserDTO : DTOBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string cellphone;

        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }
        private string email;

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

        private int cityActionId;

        public int CityActionId
        {
            get { return cityActionId; }
            set { cityActionId = value; }
        }

        private CityDTO cityAction;

        public CityDTO CityAction
        {
            get { return cityAction; }
            set { cityAction = value; }
        }

        private IEnumerable<CityDTO> cityActionList;

        public IEnumerable<CityDTO> CityActionList
        {
            get { return cityActionList; }
            set { cityActionList = value; }
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
    }
}
