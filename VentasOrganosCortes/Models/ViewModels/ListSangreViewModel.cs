using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VentasOrganosCortes.Models.ViewModels
{
    public class ListSangreViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Cant { get; set; }
        public bool Infectada { get; set; }

    }
}