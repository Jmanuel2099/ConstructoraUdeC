using ConstructoraUdeCController.DTO.SecurityModule;
using ConstructoraUdeCController.Mapper.SecurityModule;
using ConstructoraUdeCController.Services;
using ConstructoraUdeCModel.DbModel.SecurityModel;
using ConstructoraUdeCModel.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Implementation.SecurityModule
{
    public class UserImpController
    {
        private UserImplModel model;
        public UserImpController()
        {
            model = new UserImplModel();
        }
        public int RecordCreation(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);
            dbModel.Password = newPassword;
            int response = model.RecordCreation(dbModel);
            if (response == 1)

            {
                String content = String.Format("Hola {0}, <br />" +
                    " Usted ha sido registrado exitosamente. <br />" +
                    " <ul>" +
                    "   <li>Usuario : {1}</li>" +
                    "   <li>Contraseña : {2}</li>" +
                    "</ul>" +
                    "<br /> Cordial saludo, <br />" , dto.Name, dto.Email,randomPassword);
                new Notifications().SendEmail("User Registration", content,dto.Name, dto.Email);
            }
            return response;

        }

        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
            return model.RecordUpdate(dbModel);

        }
        public int RecordRemove(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);

        }
        public IEnumerable<UserDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(list);
        }

        //public UserDTO Login(UserDTO dto)
        //{
        //    UserDTOMapper mapper = new UserDTOMapper();
        //    UserDbModel dbModel = mapper.MapperT2T1(dto);
        //    dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
        //    var obj = model.Login(dbModel);
        //    return mapper.MapperT1T2(obj);
        //}

        public int PasswordReset(string email)
        {
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);

            var response = model.PasswordReset(email, newPassword);
            if (response == 1)
            {
                new Notifications().SendEmail("Password reset", "Content...", email, "test@caldas.edu");
            }
            return response;

        }



        public int ChangePassword(string currentPassword, string newPassword, int userId)
        {
            string email = string.Empty;
            var response = model.ChangePassword(currentPassword, newPassword, userId, out email);
            if (response == 1)
            {
                new Notifications().SendEmail("Password changed", "Content...", email, "test@caldas.edu");
            }
            return response;

        }
        public UserDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(record);
        }



    }
}

