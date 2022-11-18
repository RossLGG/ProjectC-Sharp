using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models.ViewModels;
using VentasOrganosCortes.Models;


namespace VentasOrganosCortes.Controllers
{
    public class MedioController : Controller
    {
        // GET: Medio
        public ActionResult Index()
        {
            List<ListMedioViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Medio_Pago
                       select new ListMedioViewModel
                       {
                           Id = d.medi_id,
                           Tipo = d.medi_tipo
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel9 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Medio_Pago();
                        oTabla.medi_id = model.Id;
                        oTabla.medi_tipo = model.Tipo;

                        db.Medio_Pago.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Medio/Index");
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
            TablaViewModel9 model = new TablaViewModel9();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Medio_Pago.Find(model.Id);
                model.Id = oTabla.medi_id;
                model.Tipo = oTabla.medi_tipo;

            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel9 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Medio_Pago.Find(model.Id);
                        model.Id = oTabla.medi_id;
                        model.Tipo = oTabla.medi_tipo;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Medio/Index");
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
            TablaViewModel9 model = new TablaViewModel9();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Medio_Pago.Find(Id);
                db.Medio_Pago.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Medio/Index");
            }
        }
    
    }
}