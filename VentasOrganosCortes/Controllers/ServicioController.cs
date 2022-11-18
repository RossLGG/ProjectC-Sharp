using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models.ViewModels;
using VentasOrganosCortes.Models;
namespace VentasOrganosCortes.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        public ActionResult Index()
        {
            List<ListServicioViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Servicio
                       select new ListServicioViewModel
                       {
                           Id = d.serv_id,
                           Precio = d.serv_prec,
                           Id_Vend = d.serv_vend_id,
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel5 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Servicio();
                        oTabla.serv_id= model.Id;
                        oTabla.serv_prec = model.Precio;
                        oTabla.serv_vend_id = model.Id_Vend;
                       
                        db.Servicio.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Servicio/Index");
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
            TablaViewModel5 model = new TablaViewModel5();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Servicio.Find(model.Id);
                model.Id = oTabla.serv_id;
                model.Precio = oTabla.serv_prec;
                model.Id_Vend = oTabla.serv_vend_id;

            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel5 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Servicio.Find(model.Id);
                        model.Id = oTabla.serv_id;
                        model.Precio = oTabla.serv_prec;
                        model.Id_Vend = oTabla.serv_vend_id;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Servicio/Index");
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
            TablaViewModel5 model = new TablaViewModel5();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Servicio.Find(Id);
                db.Servicio.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Servicio/Index");
            }
        }


    }
}