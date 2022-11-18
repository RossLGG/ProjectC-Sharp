using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentasOrganosCortes.Models;
using VentasOrganosCortes.Models.ViewModels;

namespace VentasOrganosCortes.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListClienteViewModel> lst;
            using (VentaOrganosEntities db = new VentaOrganosEntities())
            {
                lst = (from d in db.Cliente
                       select new ListClienteViewModel
                       {
                           Id = d.clie_id,
                           Nick = d.clie_nick,
                           Email = d.clie_email,
                           Clave = d.clie_clave
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VentaOrganosEntities db = new VentaOrganosEntities())
                    {
                        var oTabla = new Cliente();
                        oTabla.clie_id = model.Id;
                        oTabla.clie_nick = model.Nick;
                        oTabla.clie_email = model.Email;
                        oTabla.clie_clave = model.Clave;

                        db.Cliente.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index");
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
                var oTabla = db.Cliente.Find(Id);
                model.Id = oTabla.clie_id;
                model.Nick = oTabla.clie_nick;
                model.Email = oTabla.clie_email;
                model.Clave = oTabla.clie_clave;
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
                        var oTabla = db.Cliente.Find(model.Id);
                        oTabla.clie_id = model.Id;
                        oTabla.clie_nick = model.Nick;
                        oTabla.clie_email = model.Email;
                        oTabla.clie_clave = model.Clave;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index");
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

                var oTabla = db.Cliente.Find(Id);
                db.Cliente.Remove(oTabla);
                db.SaveChanges();
                return Redirect("~/Cliente/Index");
            }
        }
    }
}