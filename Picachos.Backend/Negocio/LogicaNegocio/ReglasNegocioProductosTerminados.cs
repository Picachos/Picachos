/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  */

/*liberias que se utilizaran */
using Picachos.Backend.Negocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Nombre del namespace con su ruta*/
namespace Picachos.Backend.Negocio.LogicaNegocio
{/*abre namespace*/
    public class ReglasNegocioProductosTerminados
    {/*abre clase ReglasNegocioProductosTerminados*/
        #region Singleton


        private static ReglasNegocioProductosTerminados instancia;

        public static ReglasNegocioProductosTerminados GetInstancia()
        {
            if (instancia == null)
                instancia = new ReglasNegocioProductosTerminados();
            return instancia;
        }

        #endregion

        #region Metodos CRUD

        public void AgregarProducto(productoTerminado objProdutoTerm)
        {
            using (var en = new PicachosEntidades())
            {
                en.productoTerminado.Add(objProdutoTerm);
                en.SaveChanges();

            }
        }

        public void EliminarProducto(int materiaPrimaID)
        {
            using (var en = new PicachosEntidades())
            {
                var cantidadIDBorrado = (from x in en.materiaPrima
                                         where x.materiaPrimaID == materiaPrimaID
                                         select x).Count();

                var materiaPrimaBD = en.materiaPrima.FirstOrDefault(x => x.materiaPrimaID == materiaPrimaID);
                en.Entry(materiaPrimaBD).State = System.Data.EntityState.Deleted;
                en.SaveChanges();
            }
        }

        public List<productoTerminado> getTablaProductos()
        {
            using (var en = new PicachosEntidades())
            {
                var query = from p in en.productoTerminado
                            select p;
                return query.ToList();
            }
        }

        public bool BusquedaProducto(String nombrePT)
        {/*abre metodo*/
            bool existe = false;
            using (var en = new PicachosEntidades())
            {/*abre using*/
                existe = en.productoTerminado.Any(x => x.nombreProducto.Equals(nombrePT));
                return existe;
            }/*cierra using*/
        }/*cierra metodo*/


        

        #endregion
    }/*cierra clase ReglasNegocioProductosTerminados */
}/*cierra namespace*/