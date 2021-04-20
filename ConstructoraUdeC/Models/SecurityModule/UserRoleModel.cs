using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.SecurityModule
{
    public class UserRoleModel
    {
        private int userID;

        public int UserId
        {
            get { return userID; }
            set { userID = value; }
        }

        private IEnumerable<RoleModel> roleList;

        public IEnumerable<RoleModel> RoleList
        {
            get { return roleList; }
            set { roleList = value; }
        }
        private string selectedRoles;

        public string SelectedRoles
        {
            get { return selectedRoles; }
            set { selectedRoles = value; }
        }
    }
}