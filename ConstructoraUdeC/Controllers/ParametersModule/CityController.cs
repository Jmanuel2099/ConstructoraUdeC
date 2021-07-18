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
    public class CityController : BaseController
    {
        private CityImpController capaNegocio = new CityImpController();
        private CountryImpController capaNegocioCountry = new CountryImpController();

        // GET: City
        public ActionResult Index(string Sorting_Order, string Search_Country, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Country" : "";

            if (Search_Country != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Country = Filter_Value;
            }
            ViewBag.FilterValueCountry = Search_Country;
            CityModelMapper mapper = new CityModelMapper();
            IEnumerable<CityModel> cityList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());

            if (!String.IsNullOrEmpty(Search_Country))
            {
                cityList = mapper.MapperT1T2(capaNegocio.RecordListByCountry(Search_Country).ToList());
            }

            switch (Sorting_Order)
            {
                case "Name_Country":
                    cityList = cityList.OrderByDescending(city => city.Country.Name);
                    break;
                default:
                    cityList = cityList.OrderBy(city => city.Country.Name);
                    break;
            }
            int Size_Of_Page = 8;
            int No_Of_Page = (Page_No ?? 1);
            return View(cityList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        [HttpPost]
        public JsonResult LoadCitiesByCountry(int countryId)
        {
            CityModelMapper mapper = new CityModelMapper();
            IEnumerable<CityModel> cityList = mapper.MapperT1T2(capaNegocio.RecordListByCountry(countryId).ToList());
            return new JsonResult { Data = cityList };
        }

        // GET: City/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            CityModel cityModel = new CityModel();
            IEnumerable<CountryDTO> dtoList =  capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapper = new CountryModelMapper();
            cityModel.CountryList = mapper.MapperT1T2(dtoList);
            return View(cityModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,CountryId")] CityModel model)
        {
            if (ModelState.IsValid)
            {
                CityModelMapper mapper = new CityModelMapper();
                CityDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: City/Edit/5
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
            CityDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CityModel cityModel = new CityModel();
            IEnumerable<CountryDTO> dtoList = capaNegocioCountry.RecordList(string.Empty);
            CountryModelMapper mapperCountry = new CountryModelMapper();
            CityModelMapper mapper = new CityModelMapper();
            CityModel model = mapper.MapperT1T2(dto);

            cityModel.Code = model.Code;
            cityModel.Name = model.Name;
            cityModel.CountryList = mapperCountry.MapperT1T2(dtoList);
            cityModel.Removed = model.Removed;
            return View(cityModel);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,CountryId,Removed")] CityModel model)
        {

            if (ModelState.IsValid)
            {
                CityModelMapper mapper = new CityModelMapper();
                CityDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: City/Delete/5
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
            CityDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CityModelMapper mapper = new CityModelMapper();
            CityModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Country,Removed")] CityModel model)
        {
            CityModelMapper mapper = new CityModelMapper();
             CityDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, CityModel model)
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
