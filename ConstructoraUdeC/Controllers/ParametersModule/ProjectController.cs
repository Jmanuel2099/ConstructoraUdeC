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
using ConstructoraUdeC.Models.ParametersModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.Implementation.ParametersModule;
using ConstructoraUdeCModel.Model;

namespace ConstructoraUdeC.Controllers.ParametersModule
{
    public class ProjectController : BaseController
    {
        private ProjectImpController capaNegocio = new ProjectImpController();
        private CityImpController capaNegocioCity = new CityImpController();

        // GET: Project
        public ActionResult Index(string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ProjectModelMapper mapper = new ProjectModelMapper();
            IEnumerable<ProjectModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ProjectModel projectModel = new ProjectModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(string.Empty);
            CityModelMapper mapper = new CityModelMapper();
            projectModel.CityList = mapper.MapperT1T2(dtoList);
            return View(projectModel);
        }

        // POST: Project/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Description,Image,CityId")] ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectModelMapper mapper = new ProjectModelMapper();
                ProjectDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Project/Edit/5
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
            ProjectDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            ProjectModel projectModel = new ProjectModel();
            IEnumerable<CityDTO> dtoList = capaNegocioCity.RecordList(string.Empty);
            CityModelMapper mapperCity = new CityModelMapper();
            ProjectModelMapper mapper = new ProjectModelMapper();
            ProjectModel model = mapper.MapperT1T2(dto);

            projectModel.Code = model.Code;
            projectModel.Name = model.Name;
            projectModel.Description = model.Description;
            projectModel.Image = model.Image;
            projectModel.CityList = mapperCity.MapperT1T2(dtoList);
            projectModel.Removed = model.Removed;
            return View(projectModel);
        }

        // POST: Project/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Description,Image,CityId,Removed")] ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectModelMapper mapper = new ProjectModelMapper();
                ProjectDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Project/Delete/5
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
            ProjectDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            ProjectModelMapper mapper = new ProjectModelMapper();
            ProjectModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Description,Image,CityId,Removed")] ProjectModel model)
        {
            ProjectModelMapper mapper = new ProjectModelMapper();
            ProjectDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }
        private ActionResult ProcessResponse(int response, ProjectModel model)
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
    }
}
