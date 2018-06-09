<%--EL SIGUIENTE CODIGO ESTA UTILIZANDO LA CARPETA Styles MEDIANTE EL ARCHIVO Login.css EL OBJETIVO ES INICIAR SESION --%>
<%--
Fecha     Revision       Editado por:    
19/11/17    2.0         Guillermo Fuentes
28/11/17    2.1         Guillermo Fuentes
20/02/18    3.1         Guillermo Fuentes

--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Picachos.Frontend.Vistas.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="cabeceraLogin" runat="server">
    <title>Login</title>    
    <link href="../../Imagenes/pino.png" rel='shortcut icon' type='image/x-icon'/>  
    <link rel="stylesheet" href="../../Estilos/Login.css"/> 
</head>

<body>
    <form  runat="server">
       <!--imagen de recuadro en loging-->
       <asp:Image id="imgFonLog" CssClass="imgFonLog" runat="server" ImageUrl="~/Imagenes/Login.png" />           
            <!--Se crea marco contenedor de elementos-->           
            <section  class="sectContenedor"> <!-- id="sectConteneLog" quiere decir seccion contendor login -->
                   <!--el sig codigo crea etiquetas y campos que tienen validaciones en el formulario y el boton para entrar-->               
                   <asp:Label ID="labNomUsuario" CssClass="labNomUsuario"  runat="server" Text="Nombre de usuario:"></asp:Label>                         
                   <asp:TextBox ID="txbNomUsuario" CssClass="txbNomUsuario" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqFVLogUsu" CssClass="reqFVLogUsu" runat="server" ControlToValidate="txbNomUsuario" ErrorMessage="Favor de ingresar nombre de usuario"></asp:RequiredFieldValidator>
                   
                   <asp:Label ID="labContrasena" CssClass="labContrasena" runat="server"  Text="Contraseña:"></asp:Label>   
                   <asp:TextBox ID="txbContrasena" CssClass="txbContrasena" runat="server" TextMode="Password"></asp:TextBox>     
                   <asp:RequiredFieldValidator ID="reqFVLogContra" CssClass="reqFVLogContra" runat="server" ControlToValidate="txbContrasena" ErrorMessage="Favor de ingresar contraseña"></asp:RequiredFieldValidator>
                   
                   <asp:Button AccessKey="E" ID="btnEntrar" CssClass="btnEntrar" runat="server" Text="Entrar" OnClick="ClickBotonEntrar" />       
            </section>            
    </form>
</body>
</html>


