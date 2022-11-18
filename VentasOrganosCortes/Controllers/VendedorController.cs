using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models;
using VentasOrganosCortes.Models.ViewModels;
namespace VentasOrganosCortes.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public ActionResult Index()
        {

            List<ListVendedorViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Vendedor
                       select new ListVendedorViewModel
                       {
                           Id = d.vend_id,
                           Nick = d.vend_nick,
                           Email = d.vend_email,
                           Clave = d.vend_clave
                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel1 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Vendedor();
                        oTabla.vend_id = model.Id;
                        oTabla.vend_nick = model.Nick;
                        oTabla.vend_email = model.Email;
                        oTabla.vend_clave = model.Clave;

                        db.Vendedor.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Vendedor/Index");
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
            TablaViewModel model = new TablaViewModel();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                var oTabla = db.Vendedor.Find(Id);
                model.Id = oTabla.vend_id;
                model.Nick = oTabla.vend_nick;
                model.Email = oTabla.vend_email;
                model.Clave = oTabla.vend_clave;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = db.Vendedor.Find(model.Id);
                        oTabla.vend_id = model.Id;
                        oTabla.vend_nick = model.Nick;
                        oTabla.vend_email = model.Email;
                        oTabla.vend_clave = model.Clave;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Vendedor/Index");
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
            TablaViewModel model = new TablaViewModel();
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {

                var oTabla = db.Vendedor.Find(Id);
                db.Vendedor.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Vendedor/Index");
            }
        }
    }
}