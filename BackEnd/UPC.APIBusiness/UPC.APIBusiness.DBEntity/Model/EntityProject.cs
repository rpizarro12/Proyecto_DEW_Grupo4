using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityProject : EntityBase
    {
        //1
        //Datos del json
        public int idproducto { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string detalle { get; set; }
        public int unidades { get; set; }
        public EntityImage images { get; set; }        
    }
    
}
