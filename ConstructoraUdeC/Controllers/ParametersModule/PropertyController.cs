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
    public class PropertyController : BaseController
    {
        private BlockImpController capaNegocioBlock = new BlockImpController();
        private PropertyImpController capaNegocio = new PropertyImpController();

        // GET: PROPERTies
        public ActionResult Index(string Sorting_Order, string Search_Country, string Search_City, string Search_Project, string Search_Block, string Filter_Value, int? Page_No, string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Property_Name" : "";
            if (Search_Country != null || Search_City != null || Search_Project != null || Search_Block != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Country = Filter_Value;
                Search_City = Filter_Value;
                Search_Project = Filter_Value;
                Search_Block = Filter_Value;
            }
            ViewBag.FilterValueCountry = Search_Country;
            ViewBag.FilterValueCity = Search_City;
            ViewBag.FilterValueProject = Search_Project;
            ViewBag.FilterValueBlock = Search_Block;

            PropertyModelMapper mapper = new PropertyModelMapper();
            IEnumerable<PropertyModel> propertyList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());

            if (!String.IsNullOrEmpty(Search_Country) || !String.IsNullOrEmpty(Search_City) ||
                !String.IsNullOrEmpty(Search_Project) || !String.IsNullOrEmpty(Search_Block))
            {
                if (!String.IsNullOrEmpty(Search_Country))
                {
                    propertyList = mapper.MapperT1T2(capaNegocio.RecordListByCountry(Search_Country).ToList());
                }
                if (!String.IsNullOrEmpty(Search_City))
                {
                    propertyList = mapper.MapperT1T2(capaNegocio.RecordListByCity(Search_City).ToList());
                }
                if (!String.IsNullOrEmpty(Search_Project))
                {
                    propertyList = mapper.MapperT1T2(capaNegocio.RecordListByProject(Search_Project).ToList());
                }
                if (!String.IsNullOrEmpty(Search_Block))
                {
                    propertyList = mapper.MapperT1T2(capaNegocio.RecordListByBlock(Search_Block).ToList());
                }
            }

            switch (Sorting_Order)
            {
                case "Property_Name":
                    propertyList = propertyList.OrderByDescending(proper => proper.Block.Name);
                    break;
                default:
                    propertyList = propertyList.OrderBy(proper => proper.Block.Name);
                    break;
            }
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(propertyList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: PROPERTies/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            PropertyModel propertyModel = new PropertyModel();
            IEnumerable<BlockDTO> dtoList = capaNegocioBlock.RecordList(string.Empty);
            BlockModelMapper mapper = new BlockModelMapper();
            propertyModel.BlockList = mapper.MapperT1T2(dtoList);
            return View(propertyModel);
        }
        // POST: PROPERTies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Identification,Val,Status,BlockId")] PropertyModel model)
        {
            if (ModelState.IsValid)
            {
                PropertyModelMapper mapper = new PropertyModelMapper();
                PropertyDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: PROPERTies/Edit/5
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
            PropertyDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            PropertyModel propertyModel = new PropertyModel();
            IEnumerable<BlockDTO> dtoList = capaNegocioBlock.RecordList(string.Empty);
            BlockModelMapper mapperBlock = new BlockModelMapper();
            PropertyModelMapper mapper = new PropertyModelMapper();
            PropertyModel model = mapper.MapperT1T2(dto);

            propertyModel.Code = model.Code;
            propertyModel.Identification = model.Identification;
            propertyModel.Val = model.Val;
            propertyModel.Status = model.Status;
            propertyModel.BlockList = mapperBlock.MapperT1T2(dtoList);
            propertyModel.Removed = model.Removed;
            return View(propertyModel);
        }

        // POST: PROPERTies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Identification,Val,Status,BlockId,Removed")] PropertyModel model)
        {
            if (ModelState.IsValid)
            {
                PropertyModelMapper mapper = new PropertyModelMapper();
                PropertyDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                this.ProcessResponse(response, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: PROPERTies/Delete/5
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
            PropertyDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            PropertyModelMapper mapper = new PropertyModelMapper();
            PropertyModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: PROPERTies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Identification,Val,Status,BlockId,Removed")] PropertyModel model)
        {
            PropertyModelMapper mapper = new PropertyModelMapper();
            PropertyDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        private ActionResult ProcessResponse(int response, PropertyModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.exceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage + model.Identification;
                    return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
