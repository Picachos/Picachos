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
    
    public partial class equipo
    {
        public int equipoID { get; set; }
        public Nullable<int> prestamoEquipoID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> ultimaFechaDeMantenimiento { get; set; }
        public string estatus { get; set; }
    
        public virtual prestamoEquipo prestamoEquipo { get; set; }
    }
}