using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VentasOrganosCortes.Models.ViewModels
{
    public class ListDireccionViewModel
    {
        public int Id { get; set; }
        public string Calle1 { get; set; }
        public string Calle2 { get; set; }
        public int Id_Cli { get; set; }
        public int Id_Comu { get; set; }
    }
}