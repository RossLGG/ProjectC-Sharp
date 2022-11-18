using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VentasOrganosCortes.Models.ViewModels
{
    public class ListClienteViewModel
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}