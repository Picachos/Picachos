﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PicachosEntidades : DbContext
    {
        public PicachosEntidades()
            : base("name=PicachosEntidades")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<agenda> agenda { get; set; }
        public DbSet<cliente> cliente { get; set; }
        public DbSet<convenio> convenio { get; set; }
        public DbSet<corteDeDia> corteDeDia { get; set; }
        public DbSet<deuda> deuda { get; set; }
        public DbSet<entradasalidaMateriaprima> entradasalidaMateriaprima { get; set; }
        public DbSet<equipo> equipo { get; set; }
        public DbSet<materiaPrima> materiaPrima { get; set; }
        public DbSet<notaDeVenta> notaDeVenta { get; set; }
        public DbSet<pago> pago { get; set; }
        public DbSet<pedido> pedido { get; set; }
        public DbSet<prestamoEquipo> prestamoEquipo { get; set; }
        public DbSet<productoTerminado> productoTerminado { get; set; }
        public DbSet<productoTerminadoES> productoTerminadoES { get; set; }
        public DbSet<salidaDeEfectivo> salidaDeEfectivo { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<venta> venta { get; set; }
    }
}