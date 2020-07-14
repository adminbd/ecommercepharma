using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommercepharma.Models.DBmodels
{
    public class PaqueteModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}