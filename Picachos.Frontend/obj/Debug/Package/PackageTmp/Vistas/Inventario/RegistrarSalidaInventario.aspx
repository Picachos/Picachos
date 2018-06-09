<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistrarSalidaInventario.aspx.cs" Inherits="Picachos.Frontend.Vistas.Inventario.RegistrarSalidaInventario" %>

<asp:Content ID="contReSaInv" ContentPlaceHolderID="contPHRegSalInv" runat="server">
     <link href="../../Estilos/ReportesInventario.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
         <asp:Image ID="imgFondoRepo" CssClass="imgFondoRepo"  runat="server" ImageUrl="~/Imagenes/reportesInventario.png"  />
     </section>
     <section class="sectContenedor">  
          <asp:DropDownList CssClass="ddlTipoReporte" ID="ddlTipoReporte" runat="server">
                   <asp:ListItem>Entradas</asp:ListItem>
                   <asp:ListItem>Salidas</asp:ListItem>
                   <asp:ListItem>General</asp:ListItem>
         </asp:DropDownList>

      <section id="sectContene">
          <asp:GridView ID="vgridUsuario" runat="server" AutoGenerateColumns="False" GridLines="None" >
             
          </asp:GridView>

      </section>



         
     </section> 


</asp:Content>
