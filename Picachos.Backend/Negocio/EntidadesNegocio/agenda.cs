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
    
    public partial class agenda
    {
        public agenda()
        {
            this.notaDeVenta = new HashSet<notaDeVenta>();
            this.pedido = new HashSet<pedido>();
        }
    
        public int agendaID { get; set; }
        public Nullable<System.DateTime> fechaEntrega { get; set; }
    
        public virtual ICollection<notaDeVenta> notaDeVenta { get; set; }
        public virtual ICollection<pedido> pedido { get; set; }
    }
}
