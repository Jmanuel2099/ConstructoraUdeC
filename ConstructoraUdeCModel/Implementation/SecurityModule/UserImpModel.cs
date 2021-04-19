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
    public class UserImplModel
    {
        /// <summary>
        /// se agrega un nuevo registro a los roles
        /// </summary>
        /// <param name="dbModel">representa un objeto con la informacion del rol</param>
        /// <returns>entero con respuesta 1:ok, 2:ko, 3:ya existe</returns>
        public int RecordCreation(UserDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try { 
                
                    UserModelMapper mapper = new UserModelMapper();
                    SEC_USER record = mapper.MapperT2T1(dbModel);

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
                    record.LASTNAME = dbModel.Lastname;
                    record.CELLPHONE = dbModel.Cellphone;
                    record.EMAIL = dbModel.Email;
                    record.ACTIONCITY = dbModel.Actioncity;
                    record.REMOVED = dbModel.Removed;


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
                    db.SaveChanges();
                    return 1;

                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<UserDbModel> RecordList(string filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLinq = from user in db.SEC_USER
                                where user.REMOVED ==false && user.NAME.ToUpper().Contains(filter)
                                select user;

                UserModelMapper mapper = new UserModelMapper();
                var listaFinal = mapper.MapperT1T2(listaLinq).ToList();
                return listaFinal;
            }

        }

        //public UserDbModel Login(UserDbModel dbModel)
        //{
        //    using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
        //    {
        //        var login = (from user in db.SEC_USER
        //                     where user.EMAIL.ToUpper().Equals(dbModel.Email.ToUpper()) && user.USER_PASSWORD.Equals(dbModel.Password)
        //                     select user).FirstOrDefault();
        //        if (login == null)
        //        {
        //            return null;
        //        }

             
        //        SEC_SESSION session = new SEC_SESSION()
        //        {
        //            USERID = login.ID,
        //            LOGIN_DATE = date,
        //            TOKEN_STATUS = true,
        //            TOKEN = this.GetToken(String.Concat(login.ID, date)),
        //            IP_ADDRESS = this.GetIpAddress()
        //        };

        //        db.SEC_SESSION.Add(session);
        //        db.SaveChanges();

        //        UserModelMapper mapper = new UserModelMapper();
        //        return mapper.MapperT1T2(login);
        //    }
        //}
        private string GetToken(string key)
        {
            int HashCode = key.GetHashCode();
            return HashCode.ToString();
        }

        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            string myIp = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            return myIp;
        }

        public int PasswordReset(string email, string newPassword)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.EMAIL.Equals(email)).FirstOrDefault();
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
        public bool AssignRoles(List<int> roles, int userId)
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
                    foreach (var rolId in roles)
                    {
                        db.SEC_USER_ROLE.Add(new SEC_USER_ROLE()
                        {
                            USERID = userId,
                            ROLEID = rolId
                        });

                    }

                    db.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
    }
}
