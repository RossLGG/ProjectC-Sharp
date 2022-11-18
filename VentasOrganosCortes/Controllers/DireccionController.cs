using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models.ViewModels;
using VentasOrganosCortes.Models;

namespace VentasOrganosCortes.Controllers
{
    public class DireccionController : Controller
    {
        // GET: Direccion
        public ActionResult Index()
        {

            List<ListDireccionViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Direccion
                       select new ListDireccionViewModel
                       {
                           Id = d.dire_id,
                           Calle1 = d.dire_calle1,
                           Calle2 = d.dire_calle2,
                           Id_Cli = d.dire_clie_id,
                           Id_Comu = d.dire_comu_id
                       }).ToList();
            }
            return View(lst);

        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel3 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Direccion();
                        oTabla.dire_id = model.Id;
                        oTabla.dire_calle1 = model.Calle1;
                        oTabla.dire_calle2 = model.Calle2;
                        oTabla.dire_clie_id = model.Id_Cli;
                        oTabla.dire_comu_id = model.Id_Comu;

                        db.Direccion.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Direccion/Index");
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
            TablaViewModel3 model = new TablaViewModel3();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Direccion.Find(Id);
                model.Id = oTabla.dire_id;
                model.Calle1 = oTabla.dire_calle1;
                model.Calle2 = oTabla.dire_calle2;
                model.Id_Cli = oTabla.dire_clie_id;
                model.Id_Comu = oTabla.dire_comu_id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel3 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Direccion.Find(model.Id);
                        model.Id = oTabla.dire_id;
                        model.Calle1 = oTabla.dire_calle1;
                        model.Calle2 = oTabla.dire_calle2;
                        model.Id_Cli = oTabla.dire_clie_id;
                        model.Id_Comu = oTabla.dire_comu_id;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Direccion/Index");
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
            TablaViewModel3 model = new TablaViewModel3();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Direccion.Find(Id);
                db.Direccion.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Direccion/Index");
            }
        }

    }
}