<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistrarClientes.aspx.cs" Inherits="Picachos.Frontend.Vistas.Clientes.RegistrarClientes" %>

<asp:Content ID="contRegCli" ContentPlaceHolderID="contPHRegC" runat="server">
     <link href="../../Estilos/RegistrarClientes.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
              <asp:Image ID="imgFondoRegCli" CssClass="imgFondoRegCli"  runat="server" ImageUrl="~/Imagenes/reg_clientes.png"  />
     </section>
      
     <%--Contenedor donde se presentara la informacion para registro de usuario, con validaciones y mensajes de error --%>
     <section class="sectContenedor">       
         
         <asp:Label ID="labRazonSocial" CssClass="labRazonSocial" runat="server" Text="Razón social:"></asp:Label>                
         <asp:TextBox  ID="txbRazonSocial" CssClass="txbRazonSocial" runat="server" MaxLength="60" ToolTip="Ingresar la razón social de la empresa o el nombre de el cliente"></asp:TextBox>
         <asp:RequiredFieldValidator CssClass="reqFVRazSocial" ID="reqFVRazSocial" runat="server" ControlToValidate="txbRazonSocial" ErrorMessage="Favor de ingresar la razón social"></asp:RequiredFieldValidator>

         <asp:Label ID="labRFC" CssClass="labRFC" runat="server" Text="R.F.C."></asp:Label>                
         <asp:TextBox  ID="txbRFC" CssClass="txbRFC" runat="server" MaxLength="13" ToolTip="Ingresar los 13 digitos del R.F.C."></asp:TextBox>
         <asp:RequiredFieldValidator CssClass="reqFVRFC" ID="reqFVRFC" runat="server"  ControlToValidate="txbRFC" ErrorMessage="Favor de ingresar R.F.C"></asp:RequiredFieldValidator>
         <asp:CustomValidator CssClass="cValtxbRFC" ID="cValtxbRFC" runat="server" ControlToValidate="txbRFC" ErrorMessage="RFC ingresado esta incorrecto " OnServerValidate="SerValRFC"></asp:CustomValidator> 
  
         <asp:Label ID="labDireccion" CssClass="labDireccion" runat="server" Text="Dirección:"></asp:Label>                
         <asp:TextBox  ID="TextDireccion" CssClass="TextDireccion" runat="server" MaxLength="80" ToolTip="Ingresar direccion donde se enviara el pedido"></asp:TextBox>
         <asp:RequiredFieldValidator CssClass="reqFVDirecc" ID="reqFVDirecc" runat="server" ControlToValidate="TextDireccion" ErrorMessage="Favor de ingresar dirección"></asp:RequiredFieldValidator>
       
         <asp:Label ID="labTelefono" CssClass="labTelefono" runat="server" Text="Teléfono:"></asp:Label>                
         <asp:TextBox  ID="txbTelefono" CssClass="txbTelefono" runat="server" MaxLength="10" ToolTip="Ingresar telefono"></asp:TextBox>
         <asp:RequiredFieldValidator CssClass="reqFVTelefono" ID="reqFVTelefono" runat="server" ControlToValidate="txbTelefono" ErrorMessage="Favor de ingresar teléfono"></asp:RequiredFieldValidator>  
         <asp:RegularExpressionValidator ID="RegEVTelefono" CssClass="reqFVTelefono" runat="server" ControlToValidate="txbTelefono" ErrorMessage="Introducir Valor numérico" ForeColor="red" ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>

         <asp:Label ID="labObservacion" CssClass="labObservacion" runat="server" Text="Observaciones: "></asp:Label>
         <asp:TextBox  ID="txbObservacion" CssClass="txbObservacion" runat="server" MaxLength="400" ToolTip="Ingresar observación" TextMode="MultiLine"></asp:TextBox>
       
         <asp:Button AccessKey="G" ID="btnGuardar" CssClass="btnGuardar" runat="server" style="font-size: large" Text="Guardar" OnClick="GuardarCliente"  />           
         <asp:Button AccessKey="L" ID="btnLimpiar" CssClass="btnLimpiar" runat="server" style="font-size: large" Text="Limpiar"  OnClick="Limpiar" CausesValidation="false"  />   
     
     </section>
    
</asp:Content>
