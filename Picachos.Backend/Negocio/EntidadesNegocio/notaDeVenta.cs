//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Picachos.Backend.Negocio.EntidadesNegocio
{
    using System;
    using System.Collections.Generic;
    
    public partial class notaDeVenta
    {
        public int notaDeVentaID { get; set; }
        public Nullable<int> deudaID { get; set; }
        public Nullable<int> agendaID { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual agenda agenda { get; set; }
        public virtual deuda deuda { get; set; }
    }
}