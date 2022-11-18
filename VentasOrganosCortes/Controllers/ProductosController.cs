using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models;
using VentasOrganosCortes.Models.ViewModels;
namespace VentasOrganosCortes.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {

            List<ListProductosViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Productos
                       select new ListProductosViewModel
                       {
                           Id = d.prod_id,
                           Cora = d.prod_cora,
                           Pulmon = d.prod_pulm,
                           Rinon = d.prod_rinon,
                           Cornea = d.prod_corn,
                           Id_Clie = d.prod_clie_id
                       }).ToList();
            }
            return View(lst);

        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel4 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Productos();
                        oTabla.prod_id = model.Id;
                        oTabla.prod_cora = model.Cora;
                        oTabla.prod_pulm = model.Pulmon;
                        oTabla.prod_rinon = model.Rinon;
                        oTabla.prod_corn = model.Cornea;
                        oTabla.prod_clie_id = model.Id_Clie;
                        db.Productos.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Productos/Index");
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
            TablaViewModel4 model = new TablaViewModel4();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Productos.Find(Id);
                  model.Id = oTabla.prod_id;
                  model.Cora = oTabla.prod_cora;
                  model.Pulmon = oTabla.prod_pulm;
                  model.Rinon = oTabla.prod_rinon;
                  model.Cornea = oTabla.prod_corn;
                  model.Id_Clie = oTabla.prod_clie_id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel4 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Productos.Find(Id);
                        model.Id = oTabla.prod_id;
                        model.Cora = oTabla.prod_cora;
                        model.Pulmon = oTabla.prod_pulm;
                        model.Rinon = oTabla.prod_rinon;
                        model.Cornea = oTabla.prod_corn;
                        model.Id_Clie = oTabla.prod_clie_id;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Productos/Index");
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
            TablaViewModel4 model = new TablaViewModel4();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Productos.Find(Id);
                db.Productos.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Productos/Index");
            }
        }

    }
}