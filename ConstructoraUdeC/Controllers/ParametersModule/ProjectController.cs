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
using PagedList;

namespace ConstructoraUdeC.Controllers.ParametersModule
{
    public class ProjectController : BaseController
    {
        private ProjectImpController capaNegocio = new ProjectImpController();
        private CityImpController capaNegocioCity = new CityImpController();
        private CountryImpController capaNegocioCountry = new CountryImpController();

        // GET: Project
        public ActionResult Index(string Sorting_Order, string Search_Country,string Search_City, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            if (Search_Country != null || Search_City != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Country = Filter_Value;
                Search_City = Filter_Value;
            }
            ViewBag.FilterValueCountry = Search_Country;
            ViewBag.FilterValueCity = Search_City;

            ProjectModelMapper mapper = new ProjectModelMapper();
            IEnumerable<ProjectModel> projectList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            if (!String.IsNullOrEmpty(Search_Country) || !String.IsNullOrEmpty(Search_City))
            {
                if (!String.IsNullOrEmpty(Search_Country) || String.IsNullOrEmpty(Search_City))
                {
                    projectList = mapper.MapperT1T2(capaNegocio.RecordListByCountry(Search_Country).ToList());
                }
                if (String.IsNullOrEmpty(Search_Country) || !String.IsNullOrEmpty(Search_City))
                {
                    projectList = mapper.MapperT1T2(capaNegocio.RecordListByCity(Search_City).ToList());
                }
            }
            switch (Sorting_Order)
            {
                case "Name_Description":
                    projectList = projectList.OrderByDescending(project => project.City.Name);
                    break;
                default:
                    projectList = projectList.OrderBy(project => project.City.Name);
                    break;
            }
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(projectList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        [HttpPost]
        public JsonResult LoadProjectsByCity(int cityId)
        {
            ProjectModelMapper mapper = new ProjectModelMapper();
            IEnumerable<ProjectModel> ProjectList = mapper.MapperT1T2(capaNegocio.RecordListByCity(cityId).ToList());
            return new JsonResult { Data = ProjectList };
        }
        // GET: Project/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ProjectModel projectModel = new ProjectModel();
            CountryModelMapper mapperCountry = new CountryModelMapper();
            IEnumerable<CountryDTO> dtoCountryList = capaNegocioCountry.RecordList(string.Empty);
            projectModel.CountryList = mapperCountry.MapperT1T2(dtoCountryList);
            CityModelMapper mapperCity = new CityModelMapper();
            IEnumerable<CityDTO> dtoCitiesList = new List<CityDTO>();
            if(dtoCountryList.Count() > 0)
            {
                dtoCitiesList = capaNegocioCity.RecordListByCountry(dtoCountryList.First().Id);
            }
            projectModel.CityList = mapperCity.MapperT1T2(dtoCitiesList);
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
            CountryModelMapper mapperCountry = new CountryModelMapper();
            IEnumerable<CountryDTO> dtoCountryList = capaNegocioCountry.RecordList(string.Empty);
            projectModel.CountryList = mapperCountry.MapperT1T2(dtoCountryList);
            CityModelMapper mapperCity = new CityModelMapper();
            IEnumerable<CityDTO> dtoCitiesList = capaNegocioCity.RecordList(string.Empty);
            if (dtoCountryList.Count() > 0)
            {
                dtoCitiesList = capaNegocioCity.RecordListByCountry(dtoCountryList.First().Id);
            }
            
            
            ProjectModelMapper mapper = new ProjectModelMapper();
            ProjectModel model = mapper.MapperT1T2(dto);

            projectModel.Code = model.Code;
            projectModel.Name = model.Name;
            projectModel.Description = model.Description;
            projectModel.Image = model.Image;
            projectModel.CityList = mapperCity.MapperT1T2(dtoCitiesList);
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
