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
        private UserImpModel model;
        private RoleImpModel roleModel;

        public UserImpController()
        {
            model = new UserImpModel();
            roleModel = new RoleImpModel();
        }

        public int RecordCreation(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            Encrypt encrypt = new Encrypt();
            string ramdonPassword = encrypt.RandomString(15);
            var newpass = encrypt.CreateMD5(ramdonPassword);
            dbModel.Password = newpass;
            int response = model.RecordCreation(dbModel);
            //verify if ther user was save to send email
            if (response == 1)
            {
                String content = String.Format("Hola {0}," +
                    " <br />Usted se ha sido registrado en la plataforma ConstructoraUdeC. " +
                    "Sus credenciales de acceso son: <br />" +
                    " <ul>" +
                    "<li>Usuario: {1}</li>" +
                    "<li>Contraseña: {2}</li>" +
                    "</ul>" +
                    "<br /> Cordial saludo. ", dto.Name, dto.Email, ramdonPassword);
                new Notifications().SendEmail("User Registration", content, dto.Name, dto.Email);
            }
            return response;
        }

        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
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

        public UserDTO Login(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
            var obj = model.Login(dbModel);
            if (obj == null) {

                return null;
            }
            return mapper.MapperT1T2(obj);
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

        public bool AssingRoles(List<int> roleList, int userId)
        {
            return model.AssingRoles(roleList, userId);
        }

        public IEnumerable<RoleDTO> RecordListByUser(int userId)
        {
            var list = roleModel.RecordListByUser(userId);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public int ChangePassword(string currentPassword, string newPassword, string toname, string toemail, int userId)
        {
            string email = string.Empty;
            Encrypt encrypt = new Encrypt();

            var response = model.ChangePassword(currentPassword, encrypt.CreateMD5(newPassword), userId, out email);
            if (response == 1)
            {
                String content = String.Format("Hola,{0}" +
                " <br />Se realizo el cambio de su contraseña. " +
                "Sus credenciales de acceso son: <br />" +
                " <ul>" +
                "<li>Usuario: {1}</li>" +
                "<li>Contraseña: {2}</li>" +
                "</ul>" +
                "<br /> Cordial saludo. ", toname ,toemail, newPassword);
                new Notifications().SendEmail("Password changed", content, toname, email);
            }
            return response;
        }

        public int PasswordResset(string email)
        {
            Encrypt encrypt = new Encrypt();
            string ramdonString = encrypt.RandomString(15);
            var newpass = encrypt.CreateMD5(ramdonString);
            var response = model.PasswordResset(email, newpass);
            if (response == 1)
            {
                String content = String.Format("Hola {0}," +
                " <br />Se ha cambiado la contraseña en ConstructoraUdeC. " +
                "Su nueva contraseña es: <br />" +
                " <ul>" +
                "<li>Nueva contraseña: {1}</li>" +
                "</ul>" +
                "<br /> Cordial saludo. ", email, ramdonString);
                new Notifications().SendEmail("Recover password", content, email, email);
            }
            return response;
        }
    }
}
