using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models;
using VentasOrganosCortes.Models.ViewModels;

namespace VentasOrganosCortes.Controllers
{
    public class SangreController : Controller
    {
        // GET: Sangre
        public ActionResult Index()
        {
            List<ListSangreViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Sangre
                       select new ListSangreViewModel
                       {
                           Id = d.sang_id,
                           Tipo = d.sang_tipo,
                           Cant = d.sang_cant,
                           Infectada = d.sang_infec,
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel8 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Sangre();
                        oTabla.sang_id = model.Id;
                        oTabla.sang_tipo = model.Tipo;
                        oTabla.sang_cant = model.Cant;
                        oTabla.sang_infec = model.Infectada;

                        db.Sangre.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Sangre/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModel8 model = new TablaViewModel8();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Sangre.Find(Id);
                model.Id = oTabla.sang_id;
                model.Tipo = oTabla.sang_tipo;
                model.Cant = oTabla.sang_cant;
                model.Infectada = oTabla.sang_infec;

            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel8 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Sangre.Find(model.Id);
                        model.Id = oTabla.sang_id;
                        model.Tipo = oTabla.sang_tipo;
                        model.Cant = oTabla.sang_cant;
                        model.Infectada = oTabla.sang_infec;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Sangre/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Eliminar(int Id)
        {
            TablaViewModel8 model = new TablaViewModel8();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Sangre.Find(Id);
                db.Sangre.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Sangre/Index");
            }
        }
    }
}