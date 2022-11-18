using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VentasOrganosCortes.Models.ViewModels
{
    public class ListCompraViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Clie { get; set; }
        public int Id_Medio { get; set; }

    }
}