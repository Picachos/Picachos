/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  19/mayo/2018*/

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
    public class ReglasNegocioEntradaSalidaMP
    {/*abre clase ReglasNegocioEntradaSalidaMP*/

        #region Singleton
        /*instancia de la clase*/
        private static ReglasNegocioEntradaSalidaMP instancia;
        /*obtiene la instancia de la clase*/
        public static ReglasNegocioEntradaSalidaMP GetInstancia()
        {/*abre metodo*/
            if (instancia == null)
                instancia = new ReglasNegocioEntradaSalidaMP();
            return instancia;
        }/*cierra metodo retornando la instancia*/
        #endregion

        #region Metodos CRUD
        /*Metodo para agregar entrada ingresando objEntrada*/
        public void AgregarEntrada(entradasalidaMateriaprima objEntrada)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                en.entradasalidaMateriaprima.Add(objEntrada);
                   en.SaveChanges();
            }/*cierra using guardando cambios*/
        }/*cierra metodo*/

        /*Metodo para agregar Salida ingresando objSalida*/
        public void AgregarSalida(entradasalidaMateriaprima objSalida)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                en.entradasalidaMateriaprima.Add(objSalida);
                en.SaveChanges();

            }/*cierra using guardando cambios*/
        }/*cierra metodo*/

        /*Metodo para actualizar cantidad ingresando materia prima y id de materia prima*/
        public String ActualizarCantidad(materiaPrima MateriaPrima, int materiaPrimaID)
        {/*abre metodo*/

            MateriaPrima.materiaPrimaID = materiaPrimaID;

            using (var en = new PicachosEntidades())
            {/*abre using*/
                try
                {/*abre try*/
                    var materiaPrimaBD = en.materiaPrima.FirstOrDefault(x => x.materiaPrimaID == MateriaPrima.materiaPrimaID);
                    en.Entry(materiaPrimaBD).State = System.Data.EntityState.Modified;
                    en.Entry(materiaPrimaBD).CurrentValues.SetValues(MateriaPrima);

                    en.SaveChanges();
                }/*cierra try guardando cambios*/
                catch (Exception e)
                {/*abre excepcion*/
                    return "Problemas" + e;/*mensaje de error*/
                }/*cierra excepcion*/
            }/*cierra using*/
            return "Materia Prima Modificado";/*mensaje de error*/
        }/*cierra metodo*/


        #endregion

        #region Tablas Entrada y Salida
        /*Metodo para listar general de MP*/
        public List<entradasalidaMateriaprima> getTablaGeneral()
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from datos in en.entradasalidaMateriaprima
                            select datos;
                return query.ToList();
            }/*cierra using retornando lista*/

        }/*cierra metodo*/

        /*Metodo para listar entrada de MP*/
        public List<entradasalidaMateriaprima> getTablaEntrada()
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from datos in en.entradasalidaMateriaprima
                                   where datos.cantidadES>0
                                   select datos;
                return query.ToList();
            }/*cierra using retornando lista de entrada*/

        }/*cierra metodo*/

        /*Metodo para listar salida de MP*/
        public List<entradasalidaMateriaprima> getTablaSalida()
        {/*abre metodo*/

            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from datos in en.entradasalidaMateriaprima
                               where datos.cantidadES <0
                               select datos;
                   return query.ToList();
            }/*cierra using retornando lista de salidas*/
        }/*cierra metodo*/


        #endregion

        #region Metodos de retorno
        /**/
        public int GetCantidad(String nombreMateria)
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaCantidad = from datos in en.materiaPrima
                                       where datos.nombreMateria.Equals(nombreMateria, StringComparison.Ordinal)
                                       select datos;
                   foreach (var materiaPrima in listaCantidad)
                {/**/
                    if (materiaPrima.nombreMateria.Equals(nombreMateria, StringComparison.Ordinal))
                           return materiaPrima.existencia.Value;
                }/**/
                return 0;
            }/**/
        }/**/

        /**/
        public int getMateriaID(String nombreMateria)
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaMateria = from datos in en.materiaPrima
                                      where datos.nombreMateria.Equals(nombreMateria, StringComparison.Ordinal)
                                      select datos;
                   foreach (var materiaPrima in listaMateria)
                {/**/
                    if (materiaPrima.nombreMateria.Equals(nombreMateria, StringComparison.Ordinal))
                           return materiaPrima.materiaPrimaID;
                }/**/
                return 0;
            }/**/
        }/**/

        /**/
        public string getNombreMP(int materiaPrimaID)
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaMateria = from datos in en.materiaPrima
                                      where datos.materiaPrimaID == materiaPrimaID
                                      select datos;
                   foreach (var materiaPrima in listaMateria)
                {/**/
                    if (materiaPrima.materiaPrimaID == materiaPrimaID)
                           return materiaPrima.nombreMateria;
                }/**/
                return "No existe";/**/

            }/**/
        }/**/

        /**/
        public List<int>  GetIDS()
        {/**/
            using (var en = new PicachosEntidades())
            {/**/
                var listaIDS = from datos in en.materiaPrima
                                  select datos.materiaPrimaID;
                  
                       return listaIDS.ToList();
            }/**/
        }/**/

        #endregion

    }/*cierra clase*/
}/*cierra namespace*/
