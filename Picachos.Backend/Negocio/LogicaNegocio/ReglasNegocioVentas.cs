using Picachos.Backend.Negocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picachos.Backend.Negocio.LogicaNegocio
{
    public class ReglasNegocioVentas
    {
        #region Singleton
        /*instancia de ReglasNegocioMateriaPrima*/
        private static ReglasNegocioVentas instancia;

        public static ReglasNegocioVentas GetInstancia()
        {/*abre la instancia */
            if (instancia == null)
                instancia = new ReglasNegocioVentas();
            return instancia;/*regresa una nueva instancia en caso de ser nulo*/
        }/*cierra la instancia*/
        #endregion

        #region Metodos de retorno

        public String getDatosDireccion(String nombreCliente)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var listaCliente = from datos in en.cliente
                                   where datos.nombre.Equals(nombreCliente, StringComparison.Ordinal)
                                   select datos;
                foreach (var cliente in listaCliente)
                {/*abre foreach en materia prima*/
                    if (cliente.nombre.Equals(nombreCliente, StringComparison.Ordinal))
                        return cliente.direccion;
                }/*cierra foreach regresando resultado*/
                return null;
            }/*cierra using*/

        }/*cierra metodo*/

        public String getDatoRFC(String nombreCliente)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var listaCliente = from datos in en.cliente
                                   where datos.nombre.Equals(nombreCliente, StringComparison.Ordinal)
                                   select datos;
                foreach (var cliente in listaCliente)
                {/*abre foreach en materia prima*/
                    if (cliente.nombre.Equals(nombreCliente, StringComparison.Ordinal))
                        return cliente.rfc;
                }/*cierra foreach regresando resultado*/
                return null;
            }/*cierra using*/

        }/*cierra metodo*/


        public String getUltimoID()
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var ultimo = from datos in en.venta
                             select datos.folio.GetValueOrDefault();


                return ultimo.ToString();
            }/*cierra using retornando lista
        }/*cierra metodo*/




        #endregion

        }
    }
}