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
using ConstructoraUdeC.Mapper.SalesModule;
using ConstructoraUdeC.Models.SalesModule;
using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.DTO.SalesModule;
using ConstructoraUdeCController.Implementation.ParametersModule;
using ConstructoraUdeCController.Implementation.SalesModule;
using ConstructoraUdeCModel.Model;
using PagedList;
namespace ConstructoraUdeC.Controllers.SalesModule
{
    public class CustomerController : BaseController
    {
        private CustomerImpController capaNegocio = new CustomerImpController();
        private CityImpController capaNegocioCity = new CityImpController();
        private CountryImpController capaNegocioCountry = new CountryImpController();

        // GET: Customer
        public ActionResult Index(string Sorting_Order, string Search_Country, string Search_City, string Filter_Value, int? Page_No, string filter = "")
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

            CustomerModelMapper mapper = new CustomerModelMapper();
            IEnumerable<CustomerModel> customertList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            if (!String.IsNullOrEmpty(Search_Country) || !String.IsNullOrEmpty(Search_City))
            {
                if (!String.IsNullOrEmpty(Search_Country) || String.IsNullOrEmpty(Search_City))
                {
                    customertList = mapper.MapperT1T2(capaNegocio.RecordListByCountry(Search_Country).ToList());
                }
                if (String.IsNullOrEmpty(Search_Country) || !String.IsNullOrEmpty(Search_City))
                {
                    customertList = mapper.MapperT1T2(capaNegocio.RecordListByCity(Search_City).ToList());
                }
            }
            switch (Sorting_Order)
            {
                case "Name_Description":
                    customertList = customertList.OrderByDescending(project => project.City.Name);
                    break;
                default:
                    customertList = customertList.OrderBy(project => project.City.Name);
                    break;
            }
            int Size_Of_Page = 8;
            int No_Of_Page = (Page_No ?? 1);
            return View(customertList.ToPagedList(No_Of_Page, Size_Of_Page));
        }
        // GET: Customer/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            CustomerModel customertModel = new CustomerModel();
            CountryModelMapper mapperCountry = new CountryModelMapper();
            IEnumerable<CountryDTO> dtoCountryList = capaNegocioCountry.RecordList(string.Empty);
            customertModel.CountryList = mapperCountry.MapperT1T2(dtoCountryList);
            CityModelMapper mapperCity = new CityModelMapper();
            IEnumerable<CityDTO> dtoCitiesList = new List<CityDTO>();
            if (dtoCountryList.Count() > 0)
            {
                dtoCitiesList = capaNegocioCity.RecordListByCountry(dtoCountryList.First().Id);
            }
            customertModel.CityList = mapperCity.MapperT1T2(dtoCitiesList);
            return View(customertModel);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Document,Name,LastName,Photo,Phone,Date,Email,Address,CityId")] CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerModelMapper mapper = new CustomerModelMapper();
                CustomerDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Customer/Edit/5
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
            CustomerDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CustomerModel customerModel = new CustomerModel();
            CountryModelMapper mapperCountry = new CountryModelMapper();
            IEnumerable<CountryDTO> dtoCountryList = capaNegocioCountry.RecordList(string.Empty);
            customerModel.CountryList = mapperCountry.MapperT1T2(dtoCountryList);
            CityModelMapper mapperCity = new CityModelMapper();
            IEnumerable<CityDTO> dtoCitiesList = capaNegocioCity.RecordList(string.Empty);
            if (dtoCountryList.Count() > 0)
            {
                dtoCitiesList = capaNegocioCity.RecordListByCountry(dtoCountryList.First().Id);
            }


            CustomerModelMapper mapper = new CustomerModelMapper();
            CustomerModel model = mapper.MapperT1T2(dto);

            customerModel.Document = model.Document;
            customerModel.Name = model.Name;
            customerModel.LastName = model.LastName;
            customerModel.Phone = model.Phone;
            customerModel.Photo = model.Photo;
            customerModel.Date = model.Date;
            customerModel.Address = model.Address;
            customerModel.Email = model.Email;
            customerModel.CityList = mapperCity.MapperT1T2(dtoCitiesList);
            customerModel.Removed = model.Removed;
            return View(customerModel);
        }

        // POST: Customer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Document,Name,LastName,Photo,Phone,Date,Email,Address,CityId,Removed")] CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerModelMapper mapper = new CustomerModelMapper();
                CustomerDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        // GET: Customer/Delete/5
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
            CustomerDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            CustomerModelMapper mapper = new CustomerModelMapper();
            CustomerModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Document,Name,LastName,Photo,Phone,Date,Email,Address,CityId,Removed")] CustomerModel model)
        {
            CustomerModelMapper mapper = new CustomerModelMapper();
            CustomerDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        public ActionResult InfoFinancial(int? id)
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoFinancialDTO dto = capaNegocio.RecordSearchInfoFinancial(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            InfoFinancialModelMapper mapper = new InfoFinancialModelMapper();
            InfoFinancialModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        public ActionResult IndexInfoFinancial(string Sorting_Order, string Search_Customer, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Customer" : "";
            if (Search_Customer != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Customer = Filter_Value;
            }
            ViewBag.FilterValue = Search_Customer;
            InfoFinancialModelMapper mapperInfo = new InfoFinancialModelMapper();
            IEnumerable<InfoFinancialModel> infoModelList = mapperInfo.MapperT1T2(capaNegocio.RecordListInfoFinancial(filter).ToList());
            if (!String.IsNullOrEmpty(Search_Customer))
            {
                infoModelList = mapperInfo.MapperT1T2(capaNegocio.RecordListInfoFinancial(Search_Customer).ToList());
            }
            switch (Sorting_Order)
            {
                case "Name_Customer":
                    infoModelList = infoModelList.OrderByDescending(info => info.Customer.Name);
                    break;
                default:
                    infoModelList = infoModelList.OrderBy(info => info.Customer.Name);
                    break;
            }
            int Size_Of_Page = 8;
            int No_Of_Page = (Page_No ?? 1);
            return View(infoModelList.ToPagedList(No_Of_Page, Size_Of_Page));
            
        }
        
        public ActionResult EditInfoFinancial(int? id)
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoFinancialDTO dto = capaNegocio.RecordSearchInfoFinancial(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            InfoFinancialModel infoModel = new InfoFinancialModel();
            InfoFinancialModelMapper mapper = new InfoFinancialModelMapper();
            InfoFinancialModel infoModelMap = mapper.MapperT1T2(dto);

            infoModel.IncommeTotal = infoModelMap.IncommeTotal;
            infoModel.WorkDate = infoModelMap.WorkDate;
            infoModel.TimeCurrentJob = infoModelMap.TimeCurrentJob;
            infoModel.FamiliyRefName = infoModelMap.FamiliyRefName;
            infoModel.FamilyRefPhone = infoModelMap.FamilyRefPhone;
            infoModel.PersonalRefName = infoModelMap.PersonalRefName;
            infoModel.PersonalRefPhone = infoModelMap.PersonalRefPhone;
            infoModel.CustomerId = infoModelMap.Customer.Id;
            return View(infoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfoFinancial([Bind(Include = "Id,IncommeTotal,WorkDate,TimeCurrentJob,FamiliyRefName,FamilyRefPhone,PersonalRefName,PersonalRefPhone,CustomerId")] InfoFinancialModel model)
        {
            if (ModelState.IsValid)
            {
                InfoFinancialModelMapper mapper = new InfoFinancialModelMapper();
                InfoFinancialDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdateInfoFinancial(dto);
                this.ProcessResponseInfoFinan(response, model);
                return RedirectToAction("IndexInfoFinancial");
            }
            return View(model);
        }

        private ActionResult ProcessResponse(int response, CustomerModel model)
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

        private ActionResult ProcessResponseInfoFinan(int response, InfoFinancialModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.exceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage + model.Id;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}
