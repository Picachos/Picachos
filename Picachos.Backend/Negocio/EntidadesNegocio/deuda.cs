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
    
    public partial class deuda
    {
        public deuda()
        {
            this.notaDeVenta = new HashSet<notaDeVenta>();
            this.pago = new HashSet<pago>();
        }
    
        public int deudaID { get; set; }
        public Nullable<double> sumatoriatotal { get; set; }
        public Nullable<double> montotal { get; set; }
    
        public virtual ICollection<notaDeVenta> notaDeVenta { get; set; }
        public virtual ICollection<pago> pago { get; set; }
    }
}
