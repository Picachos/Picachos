<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="EntradasYsalidas.aspx.cs" Inherits="Picachos.Frontend.Vistas.Productos.EntradasYsalidas" %>

<asp:Content ID="contEySPT" ContentPlaceHolderID="contPHeYsPT" runat="server">

    <link href="../../Estilos/RegistrarEySProductoTerminado.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
              <asp:Image ID="imgFondoEySPT" CssClass="imgFondoEySPT"  runat="server" ImageUrl="~/Imagenes/reg-eys.png" />
     </section>
      
     <%--Contenedor donde se presentara la informacion para registro de usuario, con validaciones y mensajes de error --%>
     <section class="sectContenedor">       
           <asp:Label ID="labTipoRegistro" CssClass="labTipoRegistro" runat="server" Text="¿Qué registraras?"></asp:Label>
           <asp:Button AccessKey="E" ID="btnEntrada" CssClass="btnEntrada" runat="server"  Text="Entrada" /> 
           <asp:Button AccessKey="S" ID="btnSalida" CssClass="btnSalida" runat="server"  Text="Salida" />   
         
           <asp:DropDownList CssClass="ddlEySPT" ID="ddlEySPT" runat="server"/> 
           
           <asp:Label ID="labCantidad" CssClass="labCantidad" runat="server" Text="Cantidad:"></asp:Label>          
           <asp:TextBox  ID="txbCantidad" CssClass="txbCantidad" runat="server" MaxLength="5" ToolTip="Ingresar cantidad con numero"></asp:TextBox>

           <asp:Label ID="labObservacion" CssClass="labObservacion" runat="server" Text="Observación:"></asp:Label>          
           <asp:TextBox  ID="txbObservacion" CssClass="txbObservacion" runat="server" MaxLength="400" ToolTip="Ingresar observacion" TextMode="MultiLine"></asp:TextBox>

           <asp:Button AccessKey="G" ID="btnGuardar" CssClass="btnGuardar" runat="server"  Text="Guardar" />      
           <asp:Button AccessKey="G" ID="btnCancelar" CssClass="btnCancelar" runat="server"  Text="Cancelar" />        
     </section>

</asp:Content>
