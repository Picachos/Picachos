/*Elaborado por Robles Alvarado Sonia*/
/*Ultima modificación:  10/06/2018*/

/*librerias que se utilizaran */

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
    public class ReglasNegocioCliente
    { /*abre Clase ReglasNegocioCliente*/
        #region Singleton
        /*Instancia del objeto*/
        private static ReglasNegocioCliente instancia;

        public static ReglasNegocioCliente GetInstancia()
        { /*abre ReglasNegocioCliente*/
            if (instancia == null)
                instancia = new ReglasNegocioCliente();
            return instancia;
        } /*Cierra ReglasNegocioCliente*/
        #endregion

        /*Metodos que se utilizaran*/
        #region Metodos CRUD

        /*Metodo buscar cliente , buscara un cliente por medio del nombre*/
        public bool BuscarCliente(String nombreCliente)
        {/*abre metodo BuscarCliente*/
            using (var en = new PicachosEntidades()) /*busca en la entidad picachos*/
            {/*abre using*/
                /*cuenta la cantidad de clientes registrados bajo el nombre a buscar*/
                var cuentaNomClie = (from datos in en.cliente
                                     where datos.nombre.Equals(nombreCliente, StringComparison.Ordinal)
                                     select datos).Count();

                if (cuentaNomClie >= 1) // si el numero de clientes encontrados es mayor a uno.
                {/*abre if*/
                    return true;  // regresa valor verdadero; exitosa la busqueda.
                }/*cierra */
                else // en caso de no se mayor a uno.
                {/*abre else*/
                    return false; // regresa falso; no se contraron clientes con el nombre ingresado.
                }/*cierra else*/
            }/*cierra using*/

        }/*cierra metodo BuscarCliente*/

        /*Metodo para agregar cliente por medio del objeto cliente*/
        public void AgregarCliente(cliente objcliente)
        {/*abre metodo AgregarUsuario*/
            using (var en = new PicachosEntidades())
            {/*abre using para buscar en entidades*/
                en.cliente.Add(objcliente);
                en.SaveChanges();

            }/*cierra using de buscar en entidades*/
        }/*cierra metodo AgregarCliente*/

        /*Metodo para eliminar un cliente por medio de ID*/
        public String EliminarCliente(int clienteID)
        {/*abre metodo EliminarCliente*/
            using (var en = new PicachosEntidades())
            {/*abre using*/
                if (clienteID != 6)
                {/*abre if*/
                    var cantidadIDBorrado = (from x in en.cliente
                                             where x.clienteID == clienteID
                                             select x).Count();

                    /*variable de busqueda en base de datos*/
                    var clienteBD = en.cliente.FirstOrDefault(x => x.clienteID == clienteID);
                    en.Entry(clienteBD).State = System.Data.EntityState.Deleted;
                    en.SaveChanges();

                    if (cantidadIDBorrado >= 1) // si el numero de clientes encontrados es mayor a uno.
                        return "Cliente eliminado!"; /*mensaje de exito*/
                    else // en caso de no se mayor a uno.
                        return "Error no se encontro cliente"; /*mensaje de error*/
                }/*cierra if*/
                else
                    return "Error al intentar eliminar"; /*mensaje de error*/
            }/*cierra using*/
        }/*cierra metodo EliminarCliente*/

        /*Metodo para actualizar la informacion del cliente ingresando cliente, id*/
        public String ActualizarCliente(cliente Cliente, int clienteID)
        {/*abre metodo ActualizarCliente*/

            /*Variables que se utilizaran para actualizar cliente*/
            Cliente.clienteID = clienteID;
            if (Cliente.clienteID.Equals(clienteID))

                using (var en = new PicachosEntidades())
                {/*abre using de busqueda */
                    try
                    {/*abre try*/

                        /*variables de busqueda y modificacion en la base de datos*/
                        var cliente_bd = en.cliente.FirstOrDefault(x => x.clienteID == Cliente.clienteID);
                        en.Entry(cliente_bd).State = System.Data.EntityState.Modified;
                        en.Entry(cliente_bd).CurrentValues.SetValues(Cliente);

                        en.SaveChanges();/*guarda cambios*/
                    }/*cierra try*/
                    catch (Exception e)
                    {/*abre excepcion*/
                        return "Problemas" + e; /*mensaje de error*/
                    }/*cierra excepcion*/
                }/*cierra using*/
            return "Cliente Modificado";
        }/*cierra metodo ActualizarCliente*/

        /*Metodo para listar la Tabla de Cliente*/
        public List<cliente> getTablaCliente()
        {/*abre listado de usuarios*/
            using (var en = new PicachosEntidades())
            {/*abre using*/

                /*query que selecciona la informacion de clientes*/
                var query = from p in en.cliente
                            select p;
                return query.ToList();
            }/*cierra using*/
        }/*cierra listado de cliente*/

        /*Metodo para obtener id con nombre de cliente*/
        public static int GetID(String nombreCliente)
        {/*abre metodo GetID*/
            using (var en = new PicachosEntidades())
            {/*abre using*/

                /*hace la comparacion para buscar cliente*/
                var listaClientes = from datos in en.cliente
                                    where datos.nombre.Equals(nombreCliente, StringComparison.Ordinal)
                                    select datos;
                foreach (var cliente in listaClientes)
                {/*para cada usuario hace la comparacion con el nombre*/
                    if (cliente.nombre.Equals(nombreCliente, StringComparison.Ordinal))
                        return cliente.clienteID; /*retorna el cliente*/
                }/*cierra foreach*/
                return 0;
            }/*cierra using*/

        }/*cierra metodo GetID*/


        #endregion

        #region Metodos Validaciones
        public Boolean ValidacionRepcliente(String nombre, int clienteID)
        {
            using (var en = new PicachosEntidades())
            {
                var numeroclientes = (from datos in en.cliente
                                      where datos.nombre.Equals(nombre, StringComparison.Ordinal)
                                      where datos.clienteID != clienteID
                                      select datos).Count();

                if (numeroclientes >= 1) // si el numero de usuario encontrados es mayor a uno.
                {
                    return false; // regresa valor verdadero; exitosa la busqueda.
                }
                else // en caso de no se mayor a uno.
                {
                    return true; // regresa falso; no se contraron usuarios con el nombre ingresado.
                }//fin else
            }//fin using
        }//fin ValidacionRepCliente
        public Boolean ValidarRFC(String rfc)
        {
            if (rfc.Length != 13)// || rfc.Length!=13) // si rfc menor a 13
            {
                return true;// "RFC invalido"; // mensaje de retorno
            }

            else // si no cumple
            {
                return false;// "RFC valido";// mensaje de retorno
            }
        }

        public Boolean ValidarTel(String tel)
        {
            if (tel.Length != 10) // si telefono es mayor a 10
            {
                return true;// "Telefono invalido"; // mensaje de retorno
            }
            else // si no cumple
            {
                return false;// "Telefono valido";// mensaje de retorno
            }
        }
        public static Boolean ValidarSizeRFC(string RFC) //Método boleano para validar contraseña, recibe una contraseña tipo cadena
        {

            //Declaración de variables tipo booleanas
            Boolean hayMay = false, hayMin = false, hayNum = false;
            if (RFC.Length >= 13) //  tamaño de RFC mayor o igual a 6
            {//abrir if
                for (int x = 0; x < RFC.Length; x++)
                {// abrir for
                    if (Char.IsNumber(RFC[x])) // si es numero 
                    {
                        hayNum = true;
                    }
                    if (Char.IsLower(RFC[x]))// si tiene minusculas
                    {
                        hayMin = true;
                    }
                    /*if (Char.IsUpper(RFC[x])) // si tiene mayusculas
                    {
                        hayMay = true;
                    }*/
                }//cierra for

                if (hayNum && hayMin)//&& hayMay) // si cumple con las condiciones
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

        }//ValidarSizeRFC

        public static Boolean ValidarRFC2(String rfc)
        {//Metodo para validacion de campo en consultas de clientes 
            if (rfc.Length == 13)// || rfc.Length!=13) // si rfc menor a 13
            {
                return true;// "RFC invalido"; // mensaje de retorno
            }

            else // si no cumple
            {
                return false;// "RFC valido";// mensaje de retorno
            }
        }
        public static Boolean ValidarTel2(String telefono)
        {
            if (telefono.Length == 10) // si telefono es mayor a 10
            {
                return true;// "Telefono invalido"; // mensaje de retorno
            }
            else // si no cumple
            {
                return false;// "Telefono valido";// mensaje de retorno
            }
        }

        public static Boolean ValidarSizeRFC2(string RFC) //Método boleano para validar contraseña, recibe una contraseña tipo cadena
        {

            //Declaración de variables tipo booleanas
            Boolean hayMay = false, hayMin = false, hayNum = false;
            if (RFC.Length >= 13) //  tamaño de RFC mayor o igual a 6
            {//abrir if
                for (int x = 0; x < RFC.Length; x++)
                {// abrir for
                    if (Char.IsNumber(RFC[x])) // si es numero 
                    {
                        hayNum = true;
                    }
                    /*if (Char.IsLower(RFC[x]))// si tiene minusculas
                    {
                        hayMin = true;
                    }*/
                    if (Char.IsUpper(RFC[x])) // si tiene mayusculas
                    {
                        hayMay = true;
                    }
                }//cierra for

                if (hayNum && hayMay)//hayMin && hayMay) // si cumple con las condiciones
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

        }//ValidarSizeRFC

        public String ValidarCampos(cliente Cliente)
        {
            if (Cliente.nombre == Cliente.rfc) // si nombre de usuario y contraseña son iguales
            {
                return "No esta permitido nombre repetidos"; // mensaje de retorno
            }
            if (ValidarSizeRFC2(Cliente.rfc) && ValidarRFC2(Cliente.rfc) && ValidarTel2(Cliente.telefono))
            // Se manda llamar al método 
            {
                return "OK"; // formato valido , mensaje de retorno
            }
            else // si no cumple
            {
                return "Formato invalido ";// mensaje de retorno
            }//<asp:ListItem>Administrador</asp:ListItem>
        }

        public Boolean ValidarSesion(String nombreUsuario, String contrasena)
        {
            bool existe = false;
            using (var en = new PicachosEntidades())
            {
                existe = en.usuario.Any(x => x.nombreUsuario.Equals(nombreUsuario, StringComparison.Ordinal) && x.contrasena.Equals(contrasena, StringComparison.Ordinal));

            }
            return existe;
        }

        public String GetNombre(String nombreCliente)
        {
            using (var en = new PicachosEntidades())
            {
                var listaCliente = from datos in en.cliente
                                   where datos.nombre.Equals(nombreCliente, StringComparison.Ordinal)
                                   select datos;
                foreach (var cliente in listaCliente)
                {
                    if (cliente.nombre.Equals(nombreCliente, StringComparison.Ordinal))
                        return cliente.nombre;
                }
                return "No se encontro el nombre";
            }
        }

        #endregion
    } /*cierra Clase ReglasNegocioCliente*/
} /*cierra namespace*/

