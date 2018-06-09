<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistrarEntradaInventario.aspx.cs" Inherits="Picachos.Frontend.Vistas.Inventario.RegistrarEntradaInventario" %>

<asp:Content ID="contReEnYSaInv" ContentPlaceHolderID="contPHEnYSaInv" runat="server">
   
   <link href="../../Estilos/RegistrarEySInventario.css" rel="stylesheet" type="text/css" />
   
   <section class="sectImgFondo">
         <asp:Image  CssClass="imgFondoRegEySInv"  runat="server" ImageUrl="~/Imagenes/regEySinv.png" />
   </section>
    

   <section class="sectContenedor">
          <asp:DropDownList CssClass="ddlEoSInv" ID="ddlEoSInv" runat="server">
                   <asp:ListItem>Entrada</asp:ListItem>
                   <asp:ListItem>Salida</asp:ListItem>
         </asp:DropDownList>
          
         <asp:Label ID="labNomreMP" CssClass="labNombreMP" runat="server" Text="Nombre de la materia prima: "></asp:Label>
        
         <asp:DropDownList CssClass="ddlRegEySInv" ID="ddlRegEySInv" runat="server">
                   
         </asp:DropDownList>
      


         <asp:Label ID="labDesc" CssClass="labDesc" runat="server" Text="Observacion: "></asp:Label>
         <asp:Textbox id="txbDesc" CssClass="txbDesc" TextMode="MultiLine" runat="server"></asp:Textbox>
        
        <asp:Label ID="labCantidad" CssClass="labCantidad" runat="server" Text="Cantidad: "></asp:Label>
        <asp:TextBox  ID="txbCant" CssClass="txbCant"  runat="server" MaxLength="10" ></asp:TextBox>
        
        <asp:Button AccessKey="G" ID="btnGuardar" CssClass="btnGuardar" runat="server" style="font-size: large" Text="Guardar" OnClick="ValidarOpcion"/>
        <asp:Button AccessKey="L" ID="btnLimpiar" CssClass="btnLimpiar" runat="server" style="font-size: large" Text="Limpiar" OnClick="Limpiar"/>
   
   </section> 




</asp:Content>
