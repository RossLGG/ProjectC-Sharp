using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models.ViewModels;
using VentasOrganosCortes.Models;

namespace VentasOrganosCortes.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            List<ListCompraViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Orden_Compra
                       select new ListCompraViewModel
                       {
                           Id = d.orde_compra,
                           Fecha = d.orde_fecha,
                           Id_Clie = d.orde_clie_id,
                           Id_Medio = d.orde_medi_id
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel7 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Orden_Compra();
                        oTabla.orde_compra = model.Id;
                        oTabla.orde_fecha = model.Fecha;
                        oTabla.orde_clie_id= model.Id_Clie;
                        oTabla.orde_medi_id = model.Id_Medio;

                        db.Orden_Compra.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Compra/Index");
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
            TablaViewModel7 model = new TablaViewModel7();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Orden_Compra.Find(Id);
                model.Id = oTabla.orde_compra;
                model.Fecha = oTabla.orde_fecha;
                model.Id_Clie = oTabla.orde_clie_id;
                model.Id_Medio = oTabla.orde_medi_id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel7 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Orden_Compra.Find(model.Id);
                        model.Id = oTabla.orde_compra;
                        model.Fecha = oTabla.orde_fecha;
                        model.Id_Clie = oTabla.orde_clie_id;
                        model.Id_Medio = oTabla.orde_medi_id;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Compra/Index");
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
            TablaViewModel7 model = new TablaViewModel7();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Orden_Compra.Find(Id);
                db.Orden_Compra.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Compra/Index");
            }
        }
    }
}