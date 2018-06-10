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

        public String EliminarProducto(int productoID)
        {/*abre metodo EliminarProducto*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                if (productoID != 6)
                {/*abre if*/
                    var cantidadIDBorrado = (from x in en.productoTerminado
                                             where x.productoID == productoID
                                             select x).Count();

                    /*variable de busqueda en base de datos*/
                    var productoBD = en.productoTerminado.FirstOrDefault(x => x.productoID == productoID);
                    en.Entry(productoBD).State = System.Data.EntityState.Deleted;
                    en.SaveChanges();

                    if (cantidadIDBorrado >= 1) // si el numero de clientes encontrados es mayor a uno.
                        return "Producto eliminado!"; /*mensaje de exito*/
                    else // en caso de no se mayor a uno.
                        return "Error no se encontro Producto"; /*mensaje de error*/
                }/*cierra if*/
                else
                    return "Error al intentar eliminar"; /*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo EliminarProducto*/

        public String ActualizarPT(productoTerminado ProductoTerminado, int productoID)
        {/*abre metodo de actualizar inventario*/

            ProductoTerminado.productoID = productoID;

            using (var en = new PicachosEntidades())
            {/*abre using*/
                try
                {/*abre try*/

                    /*variable para cambios en BD */
                    var productosBD = en.productoTerminado.FirstOrDefault(x => x.productoID == ProductoTerminado.productoID);
                    en.Entry(productosBD).State = System.Data.EntityState.Modified;
                    en.Entry(productosBD).CurrentValues.SetValues(ProductoTerminado);
                    en.SaveChanges();/*guarda cambios realizados en inventario*/
                }/*cierra try*/
                catch (Exception e)
                {/*abre excepcion*/
                    return "Problemas" + e;/*mensaje de error*/
                }/*cierra excepcion*/
            }/*cierra using*/
            return "Producto Terminado Modificado";/**/
        }/*cierra metodo*/

        #endregion

        #region Tablas Productos terminados


        public List<productoTerminado> getTablaGeneral()
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from datos in en.productoTerminado
                            select datos;
                return query.ToList();
            }/*cierra using retornando lista de entrada*/

        }/*cierra metodo*/
        #endregion
        #region Metodos de Retorno
        //seccion de metodos que regresan valor 
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