using System;

namespace ConstructoraUdeCModel.DbModel
{
    public class DbModelBase
    {
        private DateTime currentDate;

        public DateTime CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }
        }

        private int userInSessionId;

        public int UserInSessionId
        {
            get { return userInSessionId; }
            set { userInSessionId = value; }
        }
    }
}
