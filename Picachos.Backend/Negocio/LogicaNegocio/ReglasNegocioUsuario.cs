
/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  20/02/2018*/

/*liberias que se utilizaran */
using Picachos.Backend.Negocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.SqlServer;

/*Nombre del namespace con su ruta*/
namespace Picachos.Backend.Negocio.LogicaNegocio
{/*abre namespace*/
    public class ReglasNegocioUsuario
    { /*abre Clase ReglasNegocioUsuario*/
        #region Singleton
        /*Instancia del objeto*/
        private static ReglasNegocioUsuario instancia;

        public static  ReglasNegocioUsuario GetInstancia()
        { /*abre ReglasNegocioUsuario*/
            if (instancia== null)
                instancia = new ReglasNegocioUsuario();
                return instancia;
        } /*Cierra ReglasNegocioUsuario*/
        #endregion

        /*Metodos que se utilizaran*/
        #region Metodos CRUD

        /*Metodo buscar usuario , buscara un usuario por medio del nombre*/
        public bool BuscarUsuario(String nombreUsuario)
        {/*abre metodo BuscarUsuario*/
            using (var en = new PicachosEntidades()) /*busca en la entidad picachos*/
            {/*abre using*/
                /*cuenta la cantidad de usuarios registrados bajo el nombre a buscar*/
                var cuentaNomUsua = (from datos in en.usuario
                                     where datos.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal)
                                     select datos).Count();

                if (cuentaNomUsua >= 1) // si el numero de usuario encontrados es mayor a uno.
                {/*abre if*/
                    return true;  // regresa valor verdadero; exitosa la busqueda.
                }/*cierra */
                else // en caso de no se mayor a uno.
                {/*abre else*/
                    return false; // regresa falso; no se contraron usuarios con el nombre ingresado.
                }/*cierra else*/
            }/*cierra using*/

        }/*cierra metodo BuscarUsuario*/

        /*Metodo para agregar usuario por medio del objeto usuario*/
        public void AgregarUsuario(usuario objusuario)
        {/*abre metodo AgregarUsuario*/
            using (var en = new PicachosEntidades())
            {/*abre using para buscar en entidades*/ 
                en.usuario.Add(objusuario);
                en.SaveChanges();

            }/*cierra using de buscar en entidades*/
        }/*cierra metodo AgregarUsuario*/

        /*Metodo para eliminar un usuario por medio de ID*/
        public String EliminarUsuario(int usuarioID)
        {/*abre metodo EliminarUsuario*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                if (usuarioID != 6)
                {/*abre if*/
                    var cantidadIDBorrado = (from x in en.usuario
                                             where x.usuarioID == usuarioID
                                             select x).Count();

                    /*variable de busqueda en base de datos*/
                    var usuarioBD = en.usuario.FirstOrDefault(x => x.usuarioID == usuarioID);
                    en.Entry(usuarioBD).State = System.Data.EntityState.Deleted;
                    en.SaveChanges();

                    if (cantidadIDBorrado >= 1) // si el numero de usuario encontrados es mayor a uno.
                        return "Usuario eliminado!"; /*mensaje de exito*/
                    else // en caso de no se mayor a uno.
                        return "Error no se encontro usuario"; /*mensaje de error*/
                }/*cierra if*/
                else
                    return "No se puede eliminar la cuenta administrador"; /*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo EliminarUsuario*/

        /*Metodo para actualizar la informacion del usuario ingresando usuario, id , contrasena*/
        public String ActualizarUsuario(usuario Usuario, int usuarioID, string contrasena)
        {/*abre metodo ActualizarUsuario*/

            /*Variables que se utilizaran para actualizar usuario*/
            Usuario.usuarioID = usuarioID;
                if (Usuario.contrasena.Equals("****"))
                    Usuario.contrasena = contrasena;

                using (var en = new PicachosEntidades())
                {/*abre using de busqueda */
                try
                {/*abre try*/

                    /*variables de busqueda y modificacion en la base de datos*/
                    var usuario_bd = en.usuario.FirstOrDefault(x => x.usuarioID == Usuario.usuarioID);
                        en.Entry(usuario_bd).State = System.Data.EntityState.Modified;
                        en.Entry(usuario_bd).CurrentValues.SetValues(Usuario);

                        en.SaveChanges();/*guarda cambios*/
                }/*cierra try*/
                catch (Exception e)
                {/*abre excepcion*/
                    return "Problemas"+e; /*mensaje de error*/
                }/*cierra excepcion*/
            }/*cierra using*/
            return "Usuario Modificado";
        }/*cierra metodo ActualizarUsuario*/

        /*Metodo para listar la Tabla de Usuarios*/
        public List<usuario> getTablaUsuario()
        {/*abre listado de usuarios*/
            using (var en = new PicachosEntidades())
            {/*abre using*/

                /*query que selecciona la informacion de usuarios*/
                var query = from p in en.usuario
                            select p;
                return query.ToList();
            }/*cierra using*/
        }/*cierra listado de usuarios*/

        /*Metodo para obtener id con nombre de usuario*/
        public static int GetID(String nombreUsuario)
        {/*abre metodo GetID*/
            using (var en = new PicachosEntidades())
            {/*abre using*/

                /*hace la comparacion para buscar usuario*/
                var listaUsuarios = from datos in en.usuario
                                    where datos.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal)
                                    select datos;
                foreach (var usuario in listaUsuarios)
                {/*para cada usuario hace la comparacion con el nombre*/
                    if (usuario.nombreUsuario.Equals(nombreUsuario,StringComparison.Ordinal))
                        return usuario.usuarioID; /*retorna el usuario*/
                }/*cierra foreach*/
                return 0;
            }/*cierra using*/

        }/*cierra metodo GetID*/

        /*Metodo para obetener rol con el nombre de usuario*/
        public String GetRol(String nombreUsuario)
        {/*abre metodo GetRol*/
            using (var en = new PicachosEntidades())
            {/*abre using*/

                /*variable para la busqueda en base de datos*/
                var listaUsuarios = from datos in en.usuario
                                    where datos.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal)
                                    select datos;
                foreach (var usuario in listaUsuarios)
                {/*para cada usuario en la lista de usuarios*/
                    if (usuario.nombreUsuario.Equals(nombreUsuario,StringComparison.Ordinal))
                        return usuario.rol; /*regresa el rol del usuario si se encontro comparando nombre ingresado con el nombre en bd*/
                }/*cierra foreach*/
                return "No se encontro ningun rol"; /*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo GetRol*/

        /*Metodo para obtener contrasena por medio de ID de usuario*/
        public String GetContrasena(int usuarioID)
        {/*abre metodo GetContrasena*/
            using (var en = new PicachosEntidades())
            {/**/

                /*variable para la busqueda en BD*/
                var listaUsuarios = from datos in en.usuario
                                    where datos.usuarioID == usuarioID
                                    select datos;
                foreach (var usuario in listaUsuarios)
                {/*busqueda por cada usuario en la lista*/
                    if (usuario.usuarioID == usuarioID)
                        return usuario.contrasena;/*regresa contrasena si el ID si lo encuentra en BD*/
                }/*cierra foreach*/
                return "No se encontro ningun rol"; /*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo GetContrasena*/



        #endregion

        #region Metodos Validaciones
        public static Boolean ValidarContra(string contrasena) //Método boleano para validar contraseña, recibe una contraseña tipo cadena
        {

            //Declaración de variables tipo booleanas
            Boolean hayMay = false, hayMin = false, hayNum = false;

            if (contrasena.Length >= 6) //  tamaño de contraseña mayor o igual a 6
            {//abrir if
                for (int x = 0; x < contrasena.Length; x++)
                {// abrir for
                    if (Char.IsNumber(contrasena[x])) // si es numero 
                    {
                        hayNum = true;
                    }
                    if (Char.IsLower(contrasena[x]))// si tiene minusculas
                    {
                        hayMin = true;
                    }
                    if (Char.IsUpper(contrasena[x])) // si tiene mayusculas
                    {
                        hayMay = true;
                    }
                }//cierra for

                if (hayNum && hayMin && hayMay) // si cumple con las condiciones
                {
                    return true; // regresa verdadero
                }
                else // si no
                {
                    return false; // regresa falso
                }

            }//cierra if
            else // si contraseña no cumple con el tamaño
            {
                return false; // regresa falso
            }

        }//ValidarContra

        public String ValidarCampos(usuario Usuario)
        {
            if (Usuario.nombreUsuario == Usuario.contrasena) // si nombre de usuario y contraseña son iguales
            {
                return "No esta permitido nombre de usuario y contraseña iguales"; // mensaje de retorno
            }
            if (ValidarContra(Usuario.contrasena)) // Se manda llamar al método 
            {
                return "OK"; // formato valido , mensaje de retorno
            }
            else // si no cumple
            {
                return "Formato invalido de contraseña";// mensaje de retorno
            }//<asp:ListItem>Administrador</asp:ListItem>
        }

        public Boolean ValidacionRepusuario(String nombreUsuario, int usuarioID)
        {
            using (var en = new PicachosEntidades())
            {
                var numeroUsuarios = (from datos in en.usuario
                                      where datos.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal)
                                      where datos.usuarioID != usuarioID
                                      select datos).Count();

                if (numeroUsuarios >= 1) // si el numero de usuario encontrados es mayor a uno.
                {
                    return false; // regresa valor verdadero; exitosa la busqueda.
                }
                else // en caso de no se mayor a uno.
                {
                    return true; // regresa falso; no se contraron usuarios con el nombre ingresado.
                }
            }
        }
        public Boolean ValidarSesion(String nombreUsuario, String contrasena)
        {
            bool existe=false;
            using (var en = new PicachosEntidades())
            {
                existe = en.usuario.Any(x => x.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal) && x.contrasena.Equals(contrasena, StringComparison.Ordinal));

            }
            return existe;
        }

        public String GetNombre(String nombreUsuario)
        {
            using (var en = new PicachosEntidades())
            {
                var listaUsuarios = from datos in en.usuario
                                    where datos.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal)
                                    select datos;
                foreach (var usuario in listaUsuarios)
                {
                    if (usuario.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal))
                        return usuario.nombre;
                }
                return "No se encontro el nombre";
            }
        }
        #endregion
    } /*cierra Clase ReglasNegocioUsuario*/
} /*cierra namespace*/
