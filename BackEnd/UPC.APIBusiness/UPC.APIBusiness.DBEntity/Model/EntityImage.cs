using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityImage :EntityBase
    {
        public int idimagen { get; set; }
        public string nombre { get; set; }
        public string ruta { get; set; }
        public int idproducto { get; set; }  
    }
}
