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
    public class BlockController : BaseController
    {
        private CityImpController capaNegocioCity = new CityImpController();
        private CountryImpController capaNegocioCountry = new CountryImpController();
        private ProjectImpController capaNegocioProject = new ProjectImpController();
        private BlockImpController capaNegocio = new BlockImpController();

        // GET: Block
        public ActionResult Index(string Sorting_Order, string Search_Country, string Search_City, string Search_project, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Project_Name" : "";
            if (Search_Country != null || Search_City != null || Search_project != null )
            {
                Page_No = 1;
            }
            else
            {
                Search_Country = Filter_Value;
                Search_City = Filter_Value;
                Search_project = Filter_Value;
            }
            ViewBag.FilterValueCountry = Search_Country;
            ViewBag.FilterValueCity = Search_City;
            ViewBag.FilterValueProject = Search_project;

            BlockModelMapper mapper = new BlockModelMapper();
            IEnumerable<BlockModel> blockList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            if (!String.IsNullOrEmpty(Search_Country) || !String.IsNullOrEmpty(Search_City) || !String.IsNullOrEmpty(Search_project))
            {
                if (!String.IsNullOrEmpty(Search_Country))
                {
                    blockList = mapper.MapperT1T2(capaNegocio.RecordListByCountry(Search_Country).ToList());
                }
                if (!String.IsNullOrEmpty(Search_City))
                {
                    blockList = mapper.MapperT1T2(capaNegocio.RecordListByCity(Search_City).ToList());
                }
                if (!String.IsNullOrEmpty(Search_project))
                {
                    blockList = mapper.MapperT1T2(capaNegocio.RecordListByProject(Search_project).ToList());
                }
            }
            switch (Sorting_Order)
            {
                case "Project_Name":
                    blockList = blockList.OrderByDescending(block => block.Project.Name);
                    break;
                default:
                    blockList = blockList.OrderBy(block => block.Project.Name);
                    break;
            }

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(blockList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        [HttpPost]
        public JsonResult LoadBlockByProject(int blockId)
        {
            BlockModelMapper mapper = new BlockModelMapper();
            IEnumerable<BlockModel> blockList = mapper.MapperT1T2(capaNegocio.RecordListByProject(blockId).ToList());
            return new JsonResult { Data = blockList };
        }

        // GET: Block/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }

            BlockModel blockModel = new BlockModel();
            CountryModelMapper mapperCountry = new CountryModelMapper();
            IEnumerable<CountryDTO> dtoCountryList = capaNegocioCountry.RecordList(string.Empty);
            blockModel.CountryList = mapperCountry.MapperT1T2(dtoCountryList);
            CityModelMapper mapperCity = new CityModelMapper();
            IEnumerable<CityDTO> dtoCitiesList = new List<CityDTO>();
            if (dtoCountryList.Count() > 0)
            {
                dtoCitiesList = capaNegocioCity.RecordListByCountry(dtoCountryList.First().Id);
            }
            blockModel.CityList = mapperCity.MapperT1T2(dtoCitiesList);
            
            ProjectModelMapper mapper = new ProjectModelMapper();
            IEnumerable<ProjectDTO> dtoProjectList = capaNegocioProject.RecordList(string.Empty);
            if (dtoCitiesList.Count() > 0)
            {
                dtoProjectList = capaNegocioProject.RecordListByCity(dtoCitiesList.First().Id);
            }
            blockModel.ProjectList = mapper.MapperT1T2(dtoProjectList);
            return View(blockModel);
        }

        // POST: Block/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Description,ProjectId")] BlockModel model)
        {
            if (ModelState.IsValid)
            {
                BlockModelMapper mapper = new BlockModelMapper();
                BlockDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        // GET: Block/Edit/5
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
            BlockDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            BlockModel blockModel = new BlockModel();
            CountryModelMapper mapperCountry = new CountryModelMapper();
            IEnumerable<CountryDTO> dtoCountryList = capaNegocioCountry.RecordList(string.Empty);
            blockModel.CountryList = mapperCountry.MapperT1T2(dtoCountryList);
            CityModelMapper mapperCity = new CityModelMapper();
            IEnumerable<CityDTO> dtoCitiesList = new List<CityDTO>();
            if (dtoCountryList.Count() > 0)
            {
                dtoCitiesList = capaNegocioCity.RecordListByCountry(dtoCountryList.First().Id);
            }
            blockModel.CityList = mapperCity.MapperT1T2(dtoCitiesList);
            ProjectModelMapper mapperProject = new ProjectModelMapper();
            IEnumerable<ProjectDTO> dtoProjectList = capaNegocioProject.RecordList(string.Empty);
            if (dtoCitiesList.Count() > 0)
            {
                dtoProjectList = capaNegocioProject.RecordListByCity(dtoCitiesList.First().Id);
            }
            blockModel.ProjectList = mapperProject.MapperT1T2(dtoProjectList);

            BlockModelMapper mapper = new BlockModelMapper();
            BlockModel model = mapper.MapperT1T2(dto);
            blockModel.Code = model.Code;
            blockModel.Name = model.Name;
            blockModel.Description = model.Description;
            blockModel.Removed = model.Removed;
            return View(blockModel);
        }

        // POST: Block/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Description,ProjectId,Removed")] BlockModel model)
        {
            if (ModelState.IsValid)
            {
                BlockModelMapper mapper = new BlockModelMapper();
                BlockDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Block/Delete/5
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
            BlockDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            BlockModelMapper mapper = new BlockModelMapper();
            BlockModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Block/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Description,ProjectId,Removed")] BlockModel model)
        {
            BlockModelMapper mapper = new BlockModelMapper();
            BlockDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, BlockModel model)
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
