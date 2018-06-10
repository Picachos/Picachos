<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistrarProductoTerminado.aspx.cs" Inherits="Picachos.Frontend.Vistas.Productos.RegistrarProductoTerminado" %>

<asp:Content ID="ContentRPT" ContentPlaceHolderID="contPHRegiPT" runat="server">
     <link href="../../Estilos/RegistrarProductoTerminado.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
              <asp:Image ID="imgFondoRegPT"  CssClass="imgFondoRegPT"  runat="server" ImageUrl="~/Imagenes/reg_producto.png"  />
     </section>

      <section class="sectContenedor">
           <asp:Label ID="labNombrePT" CssClass="labNombrePT" runat="server" Text="Nombre del producto:"></asp:Label>       
           <asp:TextBox  ID="txbNombrePT" CssClass="txbNombrePT" runat="server" MaxLength="60" ToolTip="Ingresar nombre(s) descriptivo(s)"></asp:TextBox>
                                     
           <asp:Label ID="labDesc" CssClass="labDesc" runat="server" Text="Descripción: "></asp:Label>
           <asp:TextBox  ID="txbDesc" CssClass="txbDesc" runat="server" MaxLength="60" ToolTip="Ingresar descripcion" TextMode="MultiLine"></asp:TextBox>
      
           <asp:Label ID="labTipoProducto" CssClass="labTipoProducto" runat="server" Text="¿Tipo de producto?"></asp:Label>
           <asp:Button AccessKey="U" ID="btnUnitario" CssClass="btnUnitario" runat="server"  Text="Unitario" OnClick="esUnitario"/> 
           
           <asp:DropDownList CssClass="ddlRegRegPT" ID="ddlRegRegPT" runat="server"/>


           <asp:Button AccessKey="A" ID="btnAgregar" CssClass="btnAgregar" runat="server"  Text="Agregar" OnClick="agregarLista"/>

           <asp:TextBox  ID="txbSelecUno" CssClass="txbSelecUno" Enabled="false" runat="server" ></asp:TextBox>
           <asp:Button  ID="btnSelecUno" CssClass="btnSelecUno" runat="server"  Text="x" OnClick="botonUno"/> 
          
           <asp:TextBox  ID="txbSelecDos" CssClass="txbSelecDos" Enabled="false" runat="server" ></asp:TextBox>
           <asp:Button  ID="btnSelecDos" CssClass="btnSelecDos" runat="server"  Text="x" OnClick="botonDos"/> 
          
           <asp:TextBox  ID="txbSelecTres" CssClass="txbSelecTres" Enabled="false" runat="server" ></asp:TextBox>
           <asp:Button  ID="btnSelecTres" CssClass="btnSelecTres" runat="server"  Text="x" OnClick="botonTres"/> 
          
           
           <asp:Label ID="labCantidad" CssClass="labCantidad" runat="server" Text="Cantidad: "></asp:Label>
           <asp:TextBox  ID="txbCant" CssClass="txbCant"  runat="server" MaxLength="10" ></asp:TextBox>

           <asp:Button AccessKey="G" ID="btnGuardar" CssClass="btnGuardar" runat="server"  Text="Guardar"   />           
           <asp:Button AccessKey="L" ID="btnLimpiar" CssClass="btnLimpiar" runat="server"  Text="Limpiar"  CausesValidation="false" OnClick="btnLimpiar_Click" />
           
      </section>
</asp:Content>

