/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  09/junio/2018*/

/*liberias que se utilizaran*/
using Picachos.Backend.Negocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/*namespace con su ruta*/
namespace Picachos.Backend.Negocio.LogicaNegocio
{/*abre namespace*/
    public class ReglasNegocioEySProductos
    {/*abre clase ReglasNegocioEySProductos*/

        #region Singleton
        /*instancia de la clase*/
        private static ReglasNegocioEySProductos instancia;
        /*obtiene la instancia de la clase*/
        public static ReglasNegocioEySProductos GetInstancia()
        {/*abre metodo*/
            if (instancia == null)
                instancia = new ReglasNegocioEySProductos();
            return instancia;
        }/*cierra metodo retornando la instancia*/
        #endregion

        #region Metodos CRUD
        /*Metodo para agregar entrada ingresando objProductoE*/
        public void AgregarEntrada(productoTerminadoES objProductoE)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                en.productoTerminadoES.Add(objProductoE);
                en.SaveChanges();
            }/*cierra using guardando cambios*/
        }/*cierra metodo*/

        /*Metodo para agregar Salida ingresando objProductoS*/
        public void AgregarSalida(productoTerminadoES objProductoS)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                en.productoTerminadoES.Add(objProductoS);
                en.SaveChanges();

            }/*cierra using guardando cambios*/
        }/*cierra metodo*/

        /*Metodo para actualizar cantidad ingresando materia prima y id de materia prima*/
        public String ActualizarCantidad(productoTerminado productoTerminado, int productoID)
        {/*abre metodo*/

            productoTerminado.productoID = productoID;

            using (var en = new PicachosEntidades())
            {/*abre using*/
                try
                {/*abre try*/
                    var productoBD = en.productoTerminado.FirstOrDefault(x => x.productoID == productoTerminado.productoID);
                    en.Entry(productoBD).State = System.Data.EntityState.Modified;
                    en.Entry(productoBD).CurrentValues.SetValues(productoTerminado);

                    en.SaveChanges();
                }/*cierra try guardando cambios*/
                catch (Exception e)
                {/*abre excepcion*/
                    return "Problemas" + e;/*mensaje de error*/
                }/*cierra excepcion*/
            }/*cierra using*/
            return "Producto Modificado";/*mensaje de error*/
        }/*cierra metodo*/


        #endregion

        #region Tablas Entrada y Salida

        /*Metodo para listar entrada de Productos*/
        public List<productoTerminadoES> getTablaGeneral()
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from datos in en.productoTerminadoES
                            select datos;
                return query.ToList();
            }/*cierra using retornando lista de general*/

        }/*cierra metodo*/

        /*Metodo para listar entrada de Productos*/
        public List<productoTerminadoES> getTablaEntrada()
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from datos in en.productoTerminadoES
                            where datos.cantidadES > 0
                            select datos;
                return query.ToList();
            }/*cierra using retornando lista de entrada*/

        }/*cierra metodo*/

        /*Metodo para listar salida de Productos*/
        public List<productoTerminadoES> getTablaSalida()
        {/*abre metodo*/

            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from datos in en.productoTerminadoES
                            where datos.cantidadES < 0
                            select datos;
                return query.ToList();
            }/*cierra using retornando lista de salidas*/
        }/*cierra metodo*/


        #endregion

        #region Metodos de retorno
        /**/
        public int GetCantidad(String nombreProducto)
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaCantidad = from datos in en.productoTerminado
                                    where datos.nombreProducto.Equals(nombreProducto, StringComparison.Ordinal)
                                    select datos;
                foreach (var productoTerminado in listaCantidad)
                {/**/
                    if (productoTerminado.nombreProducto.Equals(nombreProducto, StringComparison.Ordinal))
                        return productoTerminado.existencia.Value;
                }/**/
                return 0;
            }/**/
        }/**/

        /**/
        public int getProductoID(String nombreProducto)
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaMateria = from datos in en.productoTerminado
                                   where datos.nombreProducto.Equals(nombreProducto, StringComparison.Ordinal)
                                   select datos;
                foreach (var productoTerminado in listaMateria)
                {/**/
                    if (productoTerminado.nombreProducto.Equals(nombreProducto, StringComparison.Ordinal))
                        return productoTerminado.productoID;
                }/**/
                return 0;
            }/**/
        }/**/

        /**/
        public string getNombrePT(int productoID)
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaProductos = from datos in en.productoTerminado
                                   where datos.productoID == productoID
                                   select datos;
                foreach (var productoTerminado in listaProductos)
                {/**/
                    if (productoTerminado.productoID == productoID)
                        return productoTerminado.nombreProducto;
                }/**/
                return "No existe";/**/

            }/**/
        }/**/

        /**/
        public List<int> GetIDS()
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaIDS = from datos in en.productoTerminado
                               select datos.productoID;

                return listaIDS.ToList();
            }/**/
        }/**/

        //trae la descripcion para utilizar en productos
        public String getDescripcionPT(String nombreProducto)
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
                    {/*abre foreach en cada producto terminado*/
                        if (productoTerminado.nombreProducto.Equals(nombreProducto))
                            return productoTerminado.descripcionProducto;
                    }/*cierra foreach regresando resultado*/
                }/*cierra if*/
                return "no existe";/*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo*/

        #endregion

    }/*cierra clase*/
}/*cierra namespace*/

