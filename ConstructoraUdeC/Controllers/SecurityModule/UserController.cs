using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructoraUdeC.Helpers;
using ConstructoraUdeC.Mapper.ParametersModule;
using ConstructoraUdeC.Mapper.SecurityModule;
using ConstructoraUdeC.Models.SecurityModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.DTO.SecurityModule;
using ConstructoraUdeCController.Implementation.ParametersModule;
using ConstructoraUdeCController.Implementation.SecurityModule;
using ConstructoraUdeCModel.Model;
using Newtonsoft.Json.Linq;

namespace ConstructoraUdeC.Controllers.SecurityModule
{
    public class UserController : BaseController
    {
        private UserImpController capaNegocio = new UserImpController();
        private RoleImpController capaNegocioRol = new RoleImpController();
        private CityImpController capaNegocioCity = new CityImpController();

        // GET: User
        public ActionResult Index(string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            UserModelMapper mapper = new UserModelMapper();
            IEnumerable<UserModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            UserModel userModel = new UserModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(string.Empty);
            CityModelMapper mapper = new CityModelMapper();
            userModel.CityActionList = mapper.MapperT1T2(dtoList);
            return View(userModel);
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,LastName,Cellphone,Email,CityActionId")] UserModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserInSessionId = 1;
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private ActionResult ProcessResponse(int response, UserModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.exceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage + model.Name;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModel userModel = new UserModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(String.Empty);
            CityModelMapper mapperCity = new CityModelMapper();
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapperT1T2(dto);

            userModel.Name = model.Name;
            userModel.LastName = model.LastName;
            userModel.Cellphone = model.Cellphone;
            userModel.Email = model.Email;
            userModel.CityActionList = mapperCity.MapperT1T2(dtoList);

            return View(userModel);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Cellphone,Email,CityActionId")] UserModel model)
        {
            if (ModelState.IsValid)
            {
                //controller.Entry(sEC_ROLE).State = EntityState.Modified;
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Name,Removed,Description,CityAction")] UserModel model)
        {
            UserModelMapper mapper = new UserModelMapper();
            UserDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        public ActionResult Roles(int? id)
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<RoleDTO> dtoList = capaNegocio.RecordListByUser(id.Value);
            if (dtoList == null)
            {
                return HttpNotFound();
            }
            RoleModelMapper mapper = new RoleModelMapper();
            IEnumerable<RoleModel> roleList = mapper.MapperT1T2(dtoList);
            var selectedList = roleList.Where(x => x.IsSelectedByUser).Select(x => x.Id).ToList();
            UserRoleModel model = new UserRoleModel()
            {
                UserId = id.Value,
                RoleList = roleList,
                SelectedRoles = String.Join(",", selectedList)
            };
            return View(model);
        }

        [HttpPost, ActionName("Roles")]
        [ValidateAntiForgeryToken]
        public ActionResult Roles([Bind(Include = "UserId, SelectedRoles")] UserRoleModel model)
        {
            List<int> roleList = new List<int>();
            foreach (string roleId in model.SelectedRoles.Split(','))
            {
                roleList.Add(int.Parse(roleId));
            }
            bool response = capaNegocio.AssingRoles(roleList, model.UserId);
            if (response)
            {
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public ActionResult Login()
        {
            if (this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LfLgrYaAAAAAKkdQhIArWU0WSvJmdqP4_tcWWxb";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
            return View();
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult IdentifyUser([Bind(Include = "UserName,Password")] LoginModel model)
        {
            UserDTO dto = new UserDTO()
            {
                Email = model.UserName,
                Password = model.Password,
                CurrentDate = DateTime.Now
            };
            UserDTO login = capaNegocio.Login(dto);

            if (login == null)
            {
                ViewBag.ErrorMessage = "Datos invalidos";
                return View(model);
            }
            else
            {
                var username = login.Name + " " + login.LastName;
                Session["username"] = username;
                Session["userId"] = login.Id;
                Session["token"] = login.Token;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Password()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            int id = int.Parse(Session["userId"].ToString());
            UserDTO dto = capaNegocio.RecordSearch(id);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapperT1T2(dto);

            return View(model);
        }
        [HttpPost, ActionName("Password")]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPass([Bind(Include = "Id,Password,NewPassword")] UserModel model)
        {
            UserDTO dto = capaNegocio.RecordSearch(model.Id);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel modelo = mapper.MapperT1T2(dto);

            capaNegocio.GetHashCode();
            int result = capaNegocio.ChangePassword(modelo.Password, model.NewPassword, modelo.Name, modelo.Email, modelo.Id);
            if (result==1)
            {
                ViewBag.SuccesSendMessage = "Contraseña actualizada";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult RecoverPassword()
        {
            if (this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ActionName("RecoverPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverPasswordConfirmed([Bind(Include = "Email")] UserModel model)
        {
            int result = capaNegocio.PasswordResset(model.Email);
            if (result == 1)
            {
                ViewBag.SuccesRecoverMessage = "Se ha enviado un mail al correo especificado con la nueva contraseña";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}
