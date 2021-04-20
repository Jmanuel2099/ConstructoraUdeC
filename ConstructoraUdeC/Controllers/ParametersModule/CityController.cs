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
    public class CityController : Controller
    {
        private CityImpController capaNegocio = new CityImpController();

        // GET: City
        public ActionResult Index(string filter = "")
        {
            CityModelMapper mapper = new CityModelMapper();
            IEnumerable<CityModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter).ToList());
            return View(roleList);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Country")] CityModel model)
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
        /*
        // POST: City/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CODE,NAME,COUNTRY,REMOVED")] CITY cITY)
        {
            if (ModelState.IsValid)
            {
                db.CITY.Add(cITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COUNTRY = new SelectList(db.COUNTRY, "ID", "CODE", cITY.COUNTRY);
            return View(cITY);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITY cITY = db.CITY.Find(id);
            if (cITY == null)
            {
                return HttpNotFound();
            }
            ViewBag.COUNTRY = new SelectList(db.COUNTRY, "ID", "CODE", cITY.COUNTRY);
            return View(cITY);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CODE,NAME,COUNTRY,REMOVED")] CITY cITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COUNTRY = new SelectList(db.COUNTRY, "ID", "CODE", cITY.COUNTRY);
            return View(cITY);
        }
        */

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
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

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Code,Name,Country,Removed")] CityModel model)
        {
            CityModelMapper mapper = new CityModelMapper();
            CityDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);


        }

    }
}
