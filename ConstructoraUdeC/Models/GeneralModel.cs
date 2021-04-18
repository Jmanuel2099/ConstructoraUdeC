using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models
{
    public class GeneralModel
    {
        private int userInSessionId;

        public int UserInSessionId
        {
            get { return userInSessionId; }
            set { userInSessionId = value; }
        }
    }
}