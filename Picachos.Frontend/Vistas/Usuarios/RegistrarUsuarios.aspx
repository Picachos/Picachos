<%-- EL SIGUIENTE CODIGO ES PARA EL REGISTRO DE USUARIO --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuarios.aspx.cs" Inherits="Picachos.Frontend.Vistas.Usuarios.RegistrarUsuarios" %>

<asp:Content ID="contRU" ContentPlaceHolderID="contPHRegiUsua" runat="server">   
     <link href="../../Estilos/RegistrarUsuarios.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
              <asp:Image ID="imgFondoReUs" CssClass="imgFondoReUs"  runat="server" ImageUrl="~/Imagenes/REGISTRAR.png"  />
     </section>
      
     <%--Contenedor donde se presentara la informacion para registro de usuario, con validaciones y mensajes de error --%>
     <section class="sectContenedor">       
              <asp:Label ID="labNombre" CssClass="labNombre" runat="server" Text="Nombre completo:"></asp:Label>                
              <asp:TextBox  ID="txbNombre" CssClass="txbNombre" runat="server" MaxLength="60" ToolTip="Ingresar nombre(s) y apellido(s)"></asp:TextBox>
              <asp:RequiredFieldValidator CssClass="reqFVNombre" ID="reqFVNombre" runat="server" ControlToValidate="txbNombre" ErrorMessage="Favor de ingresar nombre completo"></asp:RequiredFieldValidator>
               
              <asp:Label ID="labNomUsuario" CssClass="labNomUsuario" runat="server" Text="Nombre de usuario:"></asp:Label>
              <asp:TextBox CssClass="txbNomUsua" ID="txbNomUsua" runat="server" MaxLength="20" ToolTip="Maximo 20 caracteres" ></asp:TextBox>                
              <asp:RequiredFieldValidator ID="reqFVNomUsua" CssClass="reqFVNomUsua" runat="server" ControlToValidate="txbNomUsua" ErrorMessage="Favor de ingresar nombre de usuario"></asp:RequiredFieldValidator>
               
              <asp:Label ID="labContra" CssClass="labContra" runat="server" Text="Contraseña:"></asp:Label>
              <asp:TextBox CssClass="txbContra" ID="txbContra" runat="server" TextMode="Password" MaxLength="20"  ToolTip="Ingresar minimo 6 caracteres, y un maximo de 20; Debe contener por lo menos una letra mayuscula y un numero; Ejemplo: Picacho7A"  ></asp:TextBox> 
              <asp:RequiredFieldValidator ID="reqFVContra" CssClass="reqFVContra" runat="server" ControlToValidate="txbContra" ErrorMessage="Favor de ingresar contraseña" ></asp:RequiredFieldValidator>
             
              <asp:CustomValidator CssClass="cValtxbContra" ID="cValtxbContra" runat="server" ControlToValidate="txbContra" ErrorMessage="Error para mas informacíon consulta el botón [?]" OnServerValidate="SerValContrasena"></asp:CustomValidator> 
               

              <asp:Label ID="labConfiContra" CssClass="labConfiContra" runat="server" Text="Confirmar contraseña:"></asp:Label>                
              <asp:TextBox CssClass="txbConfContr" ID="txbConfContr" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>             
              <asp:RequiredFieldValidator ID="reqFVConfContr" CssClass="reqFVConfContr" runat="server" ControlToValidate="txbConfContr" ErrorMessage="Favor de ingresar contraseña" ></asp:RequiredFieldValidator>
             
              <asp:CompareValidator ID="compValContras" CssClass="compValContras" runat="server" ControlToCompare="txbContra" ControlToValidate="txbConfContr" ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
              <asp:CompareValidator ID="compValRepe" CssClass="compValRepe" runat="server" ControlToCompare="txbNomUsua" ControlToValidate="txbContra" ErrorMessage="Nombre de usuario y contraseña no deben ser iguales" Operator="NotEqual"></asp:CompareValidator>
                
              <asp:Label ID="labRol" CssClass="labRol" runat="server" Text="Puesto:"></asp:Label>                
              <asp:DropDownList CssClass="ddlRolRU" ID="ddlRolRU" runat="server">
                   <asp:ListItem>Administrador</asp:ListItem>
                   <asp:ListItem>Despachador</asp:ListItem>
                   <asp:ListItem>Repartidor</asp:ListItem>
              </asp:DropDownList>
              
              <asp:ImageButton ID="imgBtnPregunta" AccessKey="I" CssClass="imgBtnPregunta" runat="server" ImageUrl="~/Imagenes/pregunta.png" CausesValidation="false" OnClick="Pregunta"   />
              <asp:Button AccessKey="G" ID="btnGuardar" CssClass="btnGuardar" runat="server" style="font-size: large" Text="Guardar" OnClick="GuardarUsuario"  />           
              <asp:Button AccessKey="L" ID="btnLimpiar" CssClass="btnLimpiar" runat="server" style="font-size: large" Text="Limpiar"  CausesValidation="false" OnClick="Limpiar" />     
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txbNombre" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$">No ingreses Caracteres especiales en Nombre usuario</asp:RegularExpressionValidator>
         </section>
      
</asp:Content>