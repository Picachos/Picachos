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
    
    public partial class pago
    {
        public int pagoID { get; set; }
        public Nullable<int> corteID { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<double> monto { get; set; }
        public Nullable<int> deudaID { get; set; }
    
        public virtual corteDeDia corteDeDia { get; set; }
        public virtual deuda deuda { get; set; }
    }
}