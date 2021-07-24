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
    public class RequestController : BaseController
    {
        private RequestImpController capaNegocio = new RequestImpController();
        private CustomerImpController capaNegocioCustomer = new CustomerImpController();
        private PropertyImpController capaNegocioProperty = new PropertyImpController();

        // GET: Request
        public ActionResult Index(string Sorting_Order, string Search_Customer, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Customer_Name" : "";
            if (Search_Customer != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Customer = Filter_Value;
            }
            ViewBag.FilterValueCustomer = Search_Customer;
            RequestModelMapper mapper = new RequestModelMapper();
            IEnumerable<RequestModel> RequestList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            if (!String.IsNullOrEmpty(Search_Customer))
            {
                RequestList = mapper.MapperT1T2(capaNegocio.RecordList(Search_Customer).ToList());
            }
            switch (Sorting_Order)
            {
                case "Customer_Name":
                    RequestList = RequestList.OrderByDescending(req => req.Customer.Name);
                    break;
                default:
                    RequestList = RequestList.OrderBy(req => req.Customer.Name);
                    break;
            }
            int Size_Of_Page = 8;
            int No_Of_Page = (Page_No ?? 1);
            return View(RequestList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            RequestModel modelRequest = new RequestModel();
            StatusRequestModelMapper statusMapper = new StatusRequestModelMapper();
            IEnumerable<StatusRequestDTO> dtoStatusList = capaNegocio.RecordListStatus(string.Empty);
            modelRequest.StatusRequestList = statusMapper.MapperT1T2(dtoStatusList);
            CustomerModelMapper customerMapper = new CustomerModelMapper();
            IEnumerable<CustomerDTO> dtoCustomerList = capaNegocioCustomer.RecordList(string.Empty);
            modelRequest.CustomerList = customerMapper.MapperT1T2(dtoCustomerList);
            PropertyModelMapper propertyMapper = new PropertyModelMapper();
            IEnumerable<PropertyDTO> dtoPropertyList = capaNegocioProperty.RecordList(string.Empty);
            modelRequest.PropertyList = propertyMapper.MapperT1T2(dtoPropertyList);
            return View(modelRequest);
        }

        // POST: Request/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestDate,Offer,StatusRequestId,PropertyId,CustomerId")] RequestModel model)
        {
            if (ModelState.IsValid)
            {
                RequestModelMapper mapper = new RequestModelMapper();
                RequestDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // GET: Request/Edit/5
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
            RequestDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RequestModel requestModel = new RequestModel();
            StatusRequestModelMapper statusMapper = new StatusRequestModelMapper();
            IEnumerable<StatusRequestDTO> dtoStatusList = capaNegocio.RecordListStatus(string.Empty);
            requestModel.StatusRequestList = statusMapper.MapperT1T2(dtoStatusList);
            CustomerModelMapper customerMapper = new CustomerModelMapper();
            IEnumerable<CustomerDTO> dtoCustomerList = capaNegocioCustomer.RecordList(string.Empty);
            requestModel.CustomerList = customerMapper.MapperT1T2(dtoCustomerList);
            PropertyModelMapper propertyMapper = new PropertyModelMapper();
            IEnumerable<PropertyDTO> dtoPropertyList = capaNegocioProperty.RecordList(string.Empty);
            requestModel.PropertyList = propertyMapper.MapperT1T2(dtoPropertyList);
            RequestModelMapper mapperRequest = new RequestModelMapper();
            RequestModel model = mapperRequest.MapperT1T2(dto);
            requestModel.RequestDate = model.RequestDate;
            requestModel.Offer = model.Offer;
            return View(requestModel);
        }
        // POST: Request/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RequestDate,Offer,StatusRequestId,PropertyId,CustomerId")] RequestModel model)
        {
            if (ModelState.IsValid)
            {
                RequestModelMapper mapper = new RequestModelMapper();
                RequestDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // GET: Request/Delete/5
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
            RequestDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RequestModelMapper mapper = new RequestModelMapper();
            RequestModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,RequestDate,Offer,StatusRequestId,PropertyId,CustomerId")] RequestModel model)
        {
            RequestModelMapper mapper = new RequestModelMapper();
            RequestDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, RequestModel model)
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
