//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Picachos.Backend.Negocio.EntidadesNegocio
{
    using System;
    using System.Collections.Generic;
    
    public partial class convenios
    {
        public int convenioID { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string formato { get; set; }
        public Nullable<int> fk_ClienteIDcon { get; set; }
    
        public virtual clientes clientes { get; set; }
    }
}
