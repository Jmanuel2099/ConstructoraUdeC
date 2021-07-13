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
    public class BlockController : BaseController
    {
        private ProjectImpController capaNegocioProject = new ProjectImpController();
        private BlockImpController capaNegocio = new BlockImpController();

        // GET: Block
        public ActionResult Index(string filter = "")
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            BlockModelMapper mapper = new BlockModelMapper();
            IEnumerable<BlockModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }


        // GET: Block/Create
        public ActionResult Create()
        {
            if (!this.verificarSesion())
            {
                return RedirectToAction("Index", "Home");
            }
            BlockModel blockModel = new BlockModel();
            IEnumerable<ProjectDTO> dtoList = capaNegocioProject.RecordList(string.Empty);
            ProjectModelMapper mapper = new ProjectModelMapper();
            blockModel.ProjectList = mapper.MapperT1T2(dtoList);
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
            IEnumerable<ProjectDTO> dtoList = capaNegocioProject.RecordList(string.Empty);
            ProjectModelMapper mapperProject = new ProjectModelMapper();
            BlockModelMapper mapper = new BlockModelMapper();
            BlockModel model = mapper.MapperT1T2(dto);

            blockModel.Code = model.Code;
            blockModel.Name = model.Name;
            blockModel.Description = model.Description;
            blockModel.ProjectList = mapperProject.MapperT1T2(dtoList);
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
