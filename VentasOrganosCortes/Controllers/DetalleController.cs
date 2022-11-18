using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models;
using VentasOrganosCortes.Models.ViewModels;

namespace VentasOrganosCortes.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Detalle
        public ActionResult Index()
        {
            List<ListDetalleViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Detalle
                       select new ListDetalleViewModel
                       {
                           Id = d.detal_prod,
                           Id_Compra = d.detal_comp_id,
                           Id_Prod = d.detal_prod_id,
                           Id_Serv = d.detal_serv_id,
                           Id_Sangre = d.detal_sang_id
                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel6 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Detalle();
                        oTabla.detal_prod = model.Id;
                        oTabla.detal_comp_id = model.Id_Compra;
                        oTabla.detal_prod_id = model.Id_Prod;
                        oTabla.detal_serv_id = model.Id_Serv;
                        oTabla.detal_sang_id = model.Id_Sangre;

                        db.Detalle.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Detalle/Index");
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
            TablaViewModel6 model = new TablaViewModel6();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Detalle.Find(Id);
                model.Id = oTabla.detal_prod;
                model.Id_Compra = oTabla.detal_comp_id;
                model.Id_Prod = oTabla.detal_prod_id;
                model.Id_Serv = oTabla.detal_serv_id;
                model.Id_Sangre = oTabla.detal_sang_id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel6 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Detalle.Find(model.Id);
                        model.Id = oTabla.detal_prod;
                        model.Id_Compra = oTabla.detal_comp_id;
                        model.Id_Prod = oTabla.detal_prod_id;
                        model.Id_Serv = oTabla.detal_serv_id;
                        model.Id_Sangre = oTabla.detal_sang_id;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Detalle/Index");
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
            TablaViewModel6 model = new TablaViewModel6();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Detalle.Find(Id);
                db.Detalle.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Detalle/Index");
            }
        }
    }
}