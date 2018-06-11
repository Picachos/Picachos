/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  10/abril/2018*/

/*liberias que se utilizaran */
using Picachos.Backend.Negocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace con su ruta*/
namespace Picachos.Backend.Negocio.LogicaNegocio
{/*abre el namespace*/
    public class ReglasNegocioMateriaPrima
    {/*abre la clase ReglasNegocioMateriaPrima*/

        #region Singleton
        /*instancia de ReglasNegocioMateriaPrima*/
        private static ReglasNegocioMateriaPrima instancia;

        public static ReglasNegocioMateriaPrima GetInstancia()
        {/*abre la instancia */
            if (instancia == null)
                instancia = new ReglasNegocioMateriaPrima();
            return instancia;/*regresa una nueva instancia en caso de ser nulo*/
        }/*cierra la instancia*/
        #endregion

        #region Metodos CRUD
        /*Metodo de AgregarInventario por objMateriaPrima*/
        public void AgregarInventario(materiaPrima objMateriaPrima)
        {/*abre metodo de AgregarInventario*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                en.materiaPrima.Add(objMateriaPrima);
                en.SaveChanges();/*guarda objMateriaPrima*/

            }/*cierra using*/
        }/*cierra metodo de AgregarInventario*/

        /*Metodo para ActualizarInventario ingresando materia prima y id de materia prima*/
        public String ActualizarInventario(materiaPrima MateriaPrima, int materiaPrimaID)
        {/*abre metodo de actualizar inventario*/

            MateriaPrima.materiaPrimaID = materiaPrimaID;
            
            using (var en = new PicachosEntidades())
            {/*abre using*/
                try
                {/*abre try*/

                    /*variable para cambios en BD */
                    var materiaPrimaBD = en.materiaPrima.FirstOrDefault(x => x.materiaPrimaID == MateriaPrima.materiaPrimaID);
                    en.Entry(materiaPrimaBD).State = System.Data.EntityState.Modified;
                    en.Entry(materiaPrimaBD).CurrentValues.SetValues(MateriaPrima);

                    en.SaveChanges();/*guarda cambios realizados en inventario*/
                }/*cierra try*/
                catch (Exception e)
                {/*abre excepcion*/
                    return "Problemas" + e;/*mensaje de error*/
                }/*cierra excepcion*/
            }/*cierra using*/
            return "Materia Prima Modificado";/**/
        }/*cierra metodo*/

        /*Metodo para eliminar del inventario por medio de ID de materia prima*/
        public void EliminarInventario(int materiaPrimaID)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var cantidadIDBorradoESMP = (from x in en.entradasalidaMateriaprima
                                         where x.materiaPrimaID == materiaPrimaID
                                         select x).Count();
                var cantidadIDBorradoMP = (from x in en.materiaPrima
                                         where x.materiaPrimaID == materiaPrimaID
                                             select x).Count();
                /*variable para realizar el eliminar de la BD*/
                var materiaPrimaBDESMP = en.entradasalidaMateriaprima.FirstOrDefault(x => x.materiaPrimaID == materiaPrimaID);
                    en.Entry(materiaPrimaBDESMP).State = System.Data.EntityState.Deleted;
                    en.SaveChanges();
                var materiaPrimaBDMP = en.materiaPrima.FirstOrDefault(x => x.materiaPrimaID == materiaPrimaID);
                    en.Entry(materiaPrimaBDMP).State = System.Data.EntityState.Deleted;
                    en.SaveChanges();
                /*guarda los cambios de materia eliminada*/
            }/*cierra using*/
        }/*cierra metodo*/

        /*Metodo para listar la materia prima*/
        public List<materiaPrima> getTablaMP()
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var query = from p in en.materiaPrima
                            select p;
                return query.ToList();/*regresa lista de materia prima*/
            }/*cierra using*/
        }/*cierra metodo*/

        /*Metodo para buscar una ID en inventario por medio de ID ingresada*/
        public Boolean BusquedaInventarioId(int IDmateriaBus)
        {/*abre metodo*/
            bool existe;
            using (var en = new PicachosEntidades())
            {/*abre using*/

                existe = en.materiaPrima.Any(x => x.materiaPrimaID == IDmateriaBus);

            }/*cierra using*/
            return existe;
        }/*cierra metodo regresando resultado*/

        /*Metodo para buscar en inventario el nombre de materia prima ingresando el nombre de la misma*/
        public Boolean BusquedaInventarioNombre(String nombreMateriaBus)
        {/*abre metodo*/
            bool existe;
            using (var en = new PicachosEntidades())
            {/*abre using*/

                existe = en.materiaPrima.Any(x => x.nombreMateria.Equals(nombreMateriaBus));

            }/*cierra using*/
            return existe;
        }/*cierra metodo regresando respuesta*/
       
         /*Metodo para buscar en inventario nombre de la materia prima a buscar*/
        public bool BuscarInventarioNombre(String nombreMateriaBus)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/

                /*variable para busqueda en BD*/
                var materiaBus = (from datos in en.materiaPrima
                                  where datos.nombreMateria.Equals(nombreMateriaBus, StringComparison.Ordinal)
                                  select datos).Count();

                if (materiaBus >= 1) // si el numero de usuario encontrados es mayor a uno.
                {/*abre if*/
                    return true;  // regresa valor verdadero; exitosa la busqueda.
                }/*cierra if*/
                else // en caso de no se mayor a uno.
                {/*abre else*/
                    return false; // regresa falso; no se contraron usuarios con el nombre ingresado.
                }/*cierra else*/
            }/*cierra using*/

        }/*cierra metodo*/


        #endregion

        #region Metodos de retorno
        //para saber si existe la materia prima
        public String getDatoNombre(String materiaNombre)
        {/*abre metodo*/
            bool existe = false;
           using (var en = new PicachosEntidades())
            {/*abre using*/
                existe = en.materiaPrima.Any(x => x.nombreMateria.Equals(materiaNombre));
               if (existe)
                {/*abre if*/
                    var query = from p in en.materiaPrima
                               where p.nombreMateria.Equals(materiaNombre)
                               select p;
                   foreach (var materiaPrima in query)
                    {/*abre foreach en cada materia prima*/
                        if (materiaPrima.nombreMateria.Equals(materiaNombre))
                           return materiaPrima.nombreMateria;
                    }/*cierra foreach regresando resultado*/
                }/*cierra if*/
                return "no existe";/*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo*/

        //trae la descripcion para utilizar en EyS
       public String getDescripcionMP(String materiaNombre)
        {/*abre metodo*/
            bool existe = false;
           using (var en = new PicachosEntidades())
            {/*abre using*/
                existe = en.materiaPrima.Any(x => x.nombreMateria.Equals(materiaNombre));
               if (existe)
                {/*abre if*/
                    var query = from p in en.materiaPrima
                               where p.nombreMateria.Equals(materiaNombre)
                               select p;
                   foreach (var materiaPrima in query)
                    {/*abre foreach en cada materia prima*/
                        if (materiaPrima.nombreMateria.Equals(materiaNombre))
                           return materiaPrima.descripcion;
                    }/*cierra foreach regresando resultado*/
                }/*cierra if*/
                return "no existe";/*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo*/

         //trae  el nombre de una materia prima buscada por ID
        public static String getNombreporID(int IDmateriaPrima)
        {/*abre metodo*/
            bool existe = false;
           using (var en = new PicachosEntidades())
            {/*abre using*/
                existe = en.materiaPrima.Any(x => x.materiaPrimaID == IDmateriaPrima);
               if (existe)
                {/*abre if para saber si existe*/
                    var query = from p in en.materiaPrima
                               where p.materiaPrimaID == IDmateriaPrima
                               select p;
                   foreach (var materiaPrima in query)
                    {/*abre foreach en materia prima*/
                        if (materiaPrima.materiaPrimaID == IDmateriaPrima)
                           return materiaPrima.nombreMateria;
                    }/*cierra foreach regresando respuesta*/
                }/*cierra if*/
                return "no existe";/*mensaje de error*/
            }/*cierra using*/

        }/*cierra metodo*/


        // para saber el ID de una materia a buscar por nombre
        public static int getDatoID(String materiaNombre)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var listaMateria = from datos in en.materiaPrima
                                  where datos.nombreMateria.Equals(materiaNombre, StringComparison.Ordinal)
                                  select datos;
               foreach (var materiaPrima in listaMateria)
                {/*abre foreach en materia prima*/
                    if (materiaPrima.nombreMateria.Equals(materiaNombre, StringComparison.Ordinal))
                       return materiaPrima.materiaPrimaID;
                }/*cierra foreach regresando resultado*/
                return 0;
            }/*cierra using*/

        }/*cierra metodo*/

        // para buscar la existencia de la materia prima a buscar por nombre
        public static int getDatoCantidad(String materiaNombre)
        {/*abre metodo*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                var listaMateria = from datos in en.materiaPrima
                                  where datos.nombreMateria.Equals(materiaNombre, StringComparison.Ordinal)
                                  select datos;
               foreach (var materiaPrima in listaMateria)
                {/*abre foreach en materia prima*/
                    if (materiaPrima.nombreMateria.Equals(materiaNombre, StringComparison.Ordinal))
                       return materiaPrima.existencia.Value;
                }/*cierra foreach regresando resultado*/
                return 0;
            }/*cierra using*/

        }/*cierra metodo*/

        #endregion


    }/*cierra la clase ReglasNegocioMateriaPrima*/
}/*cierra namespace*/
