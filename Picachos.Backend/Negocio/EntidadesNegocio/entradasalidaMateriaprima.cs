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
    
    public partial class entradasalidaMateriaprima
    {
        public int EntSalID { get; set; }
        public Nullable<int> materiaPrimaID { get; set; }
        public string observacion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> cantidadES { get; set; }
    
        public virtual materiaPrima materiaPrima { get; set; }
    }
}