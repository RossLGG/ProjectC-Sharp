using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models;
using VentasOrganosCortes.Models.ViewModels;
namespace VentasOrganosCortes.Controllers
{
    public class ComunaController : Controller
    {
        // GET: Comuna
        public ActionResult Index()
        {
            List<ListComunaViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Comuna
                       select new ListComunaViewModel
                       {
                           Id = d.comu_id,
                           Nombre = d.comu_nomb
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel2 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Comuna();
                        oTabla.comu_id = model.Id;
                        oTabla.comu_nomb = model.Nombre;

                        db.Comuna.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Comuna/Index");
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
            TablaViewModel2 model = new TablaViewModel2();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Comuna.Find(Id);
                model.Id = oTabla.comu_id;
                model.Nombre = oTabla.comu_nomb;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel2 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Comuna.Find(model.Id);
                        oTabla.comu_id = model.Id;
                        oTabla.comu_nomb = model.Nombre;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Comuna/Index");
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
            TablaViewModel2 model = new TablaViewModel2();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Comuna.Find(Id);
                db.Comuna.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Comuna/Index");
            }
        }
    }
    
}