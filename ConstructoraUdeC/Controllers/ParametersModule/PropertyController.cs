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
    public class PropertyController : BaseController
    {
        private BlockImpController capaNegocioBlock = new BlockImpController();
        private PropertyImpController capaNegocio = new PropertyImpController();

        // GET: PROPERTies
        public ActionResult Index(string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            PropertyModelMapper mapper = new PropertyModelMapper();
            IEnumerable<PropertyModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
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
