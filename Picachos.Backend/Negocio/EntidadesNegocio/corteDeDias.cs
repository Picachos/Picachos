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
    
    public partial class corteDeDias
    {
        public corteDeDias()
        {
            this.pagoes = new HashSet<pagoes>();
            this.salidaDeEfectivoes = new HashSet<salidaDeEfectivoes>();
        }
    
        public int corteID { get; set; }
        public Nullable<int> ventaID { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<double> total { get; set; }
        public string lecturaInicial { get; set; }
        public string lecturaFinal { get; set; }
    
        public virtual ICollection<pagoes> pagoes { get; set; }
        public virtual ICollection<salidaDeEfectivoes> salidaDeEfectivoes { get; set; }
        public virtual ventas ventas { get; set; }
    }
}
