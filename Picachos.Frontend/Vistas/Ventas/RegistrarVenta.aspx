<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistrarVenta.aspx.cs" Inherits="Picachos.Frontend.Vistas.Ventas.RegistrarVenta" %>

<asp:Content ID="contRegV" ContentPlaceHolderID="contPHRegV" runat="server">
     <link href="../../Estilos/RegistrarVentas.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
              <asp:Image ID="imgFondoReVenta" CssClass="imgFondoReVenta"  runat="server" ImageUrl="~/Imagenes/reg_ventas.png"  />
     </section>
      
     <%--Contenedor donde se presentara la informacion para registro de usuario, con validaciones y mensajes de error --%>
     <section class="sectContenedor">       
          <asp:Label ID="labTipoHyA" CssClass="labTipoHyA" runat="server" Text="HIELO Y AGUA PURIFICADA"></asp:Label>
          <asp:Label ID="labPICA" CssClass="labPICA" runat="server" Text="Picachos"></asp:Label>
          <asp:Label ID="labMontain" CssClass="labMontain" runat="server" Text="Mountain Spring"></asp:Label>
          <asp:Label ID="labCarr" CssClass="labCarr" runat="server" Text="Carr. Mexicali-Tecate Km 69.703"></asp:Label>
          <asp:Label ID="labPobla" CssClass="labPobla" runat="server" Text="Pob. La Rumorosa, Tecate, B.C. "></asp:Label>

          <asp:Label ID="labNdeVenta" CssClass="labNdeVenta" runat="server" Text="Nota de venta:"></asp:Label>
          <asp:Label ID="labNumNotaVe" CssClass="labNumNotaVe" runat="server" Text="#333333333"></asp:Label>
          <asp:Label ID="labFecha" CssClass="labFecha" runat="server" Text="Fecha:"></asp:Label>
          <asp:Label ID="labFechaSistema" CssClass="labFechaSistema" runat="server" Text="09/06/2018"></asp:Label>

          <asp:TextBox  ID="txbRazon" CssClass="txbRazon" runat="server" MaxLength="60" placeholder="Razón social"></asp:TextBox>
          <asp:TextBox  ID="txbDom" CssClass="txbDom" runat="server" MaxLength="60" placeholder="Domicilio"></asp:TextBox>
          <asp:TextBox  ID="txbRFC" CssClass="txbRFC" runat="server" MaxLength="60" placeholder="R.F.C."></asp:TextBox>

          
     </section>
</asp:Content>

