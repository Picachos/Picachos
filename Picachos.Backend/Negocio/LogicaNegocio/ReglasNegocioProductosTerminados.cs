/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación: 09/06/2018 */

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

        public void EliminarProducto(int productoID)
        {
            using (var en = new PicachosEntidades())
            {
                var cantidadIDBorradoESPT = (from x in en.productoTerminadoES
                                           where x.productoID == productoID
                                           select x).Count();
                var cantidadIDBorradoPT = (from x in en.productoTerminado
                                         where x.productoID == productoID
                                         select x).Count();
                var productoBDESPT = en.productoTerminadoES.FirstOrDefault(x => x.productoID == productoID);
                en.Entry(productoBDESPT).State = System.Data.EntityState.Deleted;
                en.SaveChanges();

                var productoBDPT = en.productoTerminado.FirstOrDefault(x => x.productoID == productoID);
                en.Entry(productoBDPT).State = System.Data.EntityState.Deleted;
                en.SaveChanges();
            }
        }

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


        public String getMateriales(String nombreProducto)
        {/*abre metodo*/
            bool existe = false;
            using (var en = new PicachosEntidades())
            {/*abre using*/
                existe = en.productoTerminado.Any(x => x.nombreProducto.Equals(nombreProducto));
                if (existe)
                {/*abre if*/
                    var query = from p in en.productoTerminado
                                where p.nombreProducto.Equals(nombreProducto)
                                select p;
                    foreach (var productoTerminado in query)
                    {/*abre foreach en cada productos*/
                        if (productoTerminado.nombreProducto.Equals(nombreProducto))
                            return productoTerminado.materiales;
                    }/*cierra foreach regresando resultado*/
                }/*cierra if*/
                return "no existe";/*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo*/

        public String getTipo(String nombreProducto)
        {/*abre metodo*/
            bool existe = false;
            using (var en = new PicachosEntidades())
            {/*abre using*/
                existe = en.productoTerminado.Any(x => x.nombreProducto.Equals(nombreProducto));
                if (existe)
                {/*abre if*/
                    var query = from p in en.productoTerminado
                                where p.nombreProducto.Equals(nombreProducto)
                                select p;
                    foreach (var productoTerminado in query)
                    {/*abre foreach en cada productos*/
                        if (productoTerminado.nombreProducto.Equals(nombreProducto))
                            return productoTerminado.tipo;
                    }/*cierra foreach regresando resultado*/
                }/*cierra if*/
                return "no existe";/*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo*/

        public int getDatoID(String productoNom)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var listaProducto = from datos in en.productoTerminado
                                    where datos.nombreProducto.Equals(productoNom, StringComparison.Ordinal)
                                    select datos;
                foreach (var producto in listaProducto)
                {/*abre foreach en materia prima*/
                    if (producto.nombreProducto.Equals(productoNom, StringComparison.Ordinal))
                        return producto.productoID;
                }/*cierra foreach regresando resultado*/
                return 0;
            }/*cierra using*/
        }

       public  int getDatoCantidad(String nombre)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var listaProducto = from datos in en.productoTerminado
                                   where datos.nombreProducto.Equals(nombre, StringComparison.Ordinal)
                                  select datos;
                foreach (var producto in listaProducto)
                {/*abre foreach en materia prima*/
                    if (producto.nombreProducto.Equals(nombre, StringComparison.Ordinal))
                       return producto.existencia.Value;
                }/*cierra foreach regresando resultado*/
                return 0;
            }/*cierra using*/

        }/*cierra metodo*/



        #endregion
    }/*cierra clase ReglasNegocioProductosTerminados */
}/*cierra namespace*/