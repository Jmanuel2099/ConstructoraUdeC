using ConstructoraUdeCModel.DbModel.SecurityModel;
using ConstructoraUdeCModel.Mapper.SecurityModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Implementation.SecurityModule
{
    public class UserImpModel
    {
        public int RecordCreation(UserDbModel dbModel)
        {

            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                try
                {
                    UserModelMapper mapper = new UserModelMapper();
                    SEC_USER record = mapper.MapperT2T1(dbModel);

                    record.CREATE_DATE = dbModel.CurrentDate;
                    record.CREATE_USER_ID = dbModel.UserInSessionId;
                    db.SEC_USER.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(UserDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.NAME = dbModel.Name;
                    record.LASTNAME = dbModel.LastName;
                    record.CELLPHONE = dbModel.Cellphone;
                    record.EMAIL = dbModel.Email;
                    record.ACTIONCITY = dbModel.CityActionId;
                    //record.USER_PASSWORD = dbModel.Password;
                    record.UPDATE_USER_ID = dbModel.UserInSessionId;
                    record.UPDATE_DATE = dbModel.CurrentDate;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }
        public int RecordRemove(UserDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.REMOVED = true;
                    record.REMOVED_DATE = dbModel.CurrentDate;
                    record.REMOVE_USER_ID = dbModel.UserInSessionId;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<UserDbModel> RecordList(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                var listLINQ = from user in db.SEC_USER
                               where user.REMOVED == false && user.NAME.ToUpper().Contains(filter)
                               select user;
                UserModelMapper mapper = new UserModelMapper();
                var listFinal = mapper.MapperT1T2(listLINQ).ToList();

                return listFinal;
            }
        }

        public UserDbModel RecordSearch(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.SEC_USER.Where(x => x.REMOVED == false && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    UserModelMapper mapper = new UserModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }

        public UserDbModel Login(UserDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                
                var login = (from user in db.SEC_USER
                             where user.EMAIL.ToUpper().Equals(dbModel.Email.ToUpper()) && user.USER_PASSWORD.Equals(dbModel.Password)
                             select user).FirstOrDefault();

                if (login == null)
                {
                    return null;
                }

                var date = dbModel.CurrentDate;
                SEC_SESSION session = new SEC_SESSION()
                {
                    USERID = login.ID,
                    LOGIN_DATE = date,
                    TOKEN_STATUS = true,
                    TOKEN = this.getToken(String.Concat(login.ID, date)),
                    IP_ADDRESS = this.getIpAddress()

                };
                db.SEC_SESSION.Add(session);
                db.SaveChanges();

                UserModelMapper mapper = new UserModelMapper();
                return mapper.MapperT1T2(login);

            }
        }

        public bool AssingRoles(List<int> roles, int userId)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    IList<SEC_USER_ROLE> userRoleList = db.SEC_USER_ROLE.Where(x => x.USERID == userId).ToList();
                    foreach (var userRole in userRoleList)
                    {
                        db.SEC_USER_ROLE.Remove(userRole);

                    }
                    foreach (int roleId in roles)
                    {
                        db.SEC_USER_ROLE.Add(new SEC_USER_ROLE()
                        {
                            USERID = userId,
                            ROLEID = roleId
                        });
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception )
                {
                    return false;
                }
            }
        }

        private string getToken(string key)
        {
            int hashCode = key.GetHashCode();
            return hashCode.ToString();
        }

        private string getIpAddress()
        {
            string hostname = Dns.GetHostName();
            Console.WriteLine(hostname);
            //GET IP ADDRESS
            string myIP = Dns.GetHostEntry(hostname).AddressList[0].ToString();
            return myIP;
        }
        public int ChangePassword(string currentPassword, string newPassword, int userId, out string email)
        {
            email = string.Empty;
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.ID == userId && x.USER_PASSWORD.Equals(currentPassword)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }
                    user.USER_PASSWORD = newPassword;
                    db.SaveChanges();
                    email = user.EMAIL;
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int PasswordResset(string email, string newPass)
        {

            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.REMOVED == false && x.EMAIL.Equals(email)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }

                    user.USER_PASSWORD = newPass;
                    db.SaveChanges();
                    email = user.EMAIL;
                    return 1;
                }
                catch
                {
                    return 2;
                }

            }
        }

    }
}
