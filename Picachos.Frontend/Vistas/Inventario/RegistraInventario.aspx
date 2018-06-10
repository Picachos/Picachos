<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistraInventario.aspx.cs" Inherits="Picachos.Frontend.Vistas.Inventario.RegistraInventario" %>

<asp:Content ID="contRI" ContentPlaceHolderID="contPHRegiInv" runat="server">
    <link href="../../Estilos/RegistrarInventario.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
              <asp:Image ID="imgFondoReInv"  CssClass="imgFondoReInv"  runat="server" ImageUrl="~/Imagenes/reg-inve.png"  />
     </section>

      <section class="sectContenedor">
           <asp:Label ID="labNombreMP" CssClass="labNombreMP" runat="server" Text="Nombre de materia prima:"></asp:Label>       
           <asp:TextBox  ID="txbNombreMP" CssClass="txbNombreMP" runat="server" MaxLength="60" ToolTip="Ingresar nombre(s) descriptivo(s)"></asp:TextBox>
           <asp:RequiredFieldValidator CssClass="reqFVNombreMP" ID="reqFVNombreMP" runat="server" ControlToValidate="txbNombreMP" ErrorMessage="Favor de ingresar nombre de materia prima"></asp:RequiredFieldValidator>

           
           <asp:Label ID="labDesc" CssClass="labDesc" runat="server" Text="Descripción: "></asp:Label>
           <asp:TextBox  ID="txbDesc" CssClass="txbDesc" runat="server" MaxLength="60" ToolTip="Ingresar descripcion" TextMode="MultiLine"></asp:TextBox>
      

           <asp:Button AccessKey="G" ID="btnGuardar" CssClass="btnGuardar" runat="server" style="font-size: large;" Text="Guardar" OnClick="GuardarMP"  />           
           <asp:Button AccessKey="L" ID="btnLimpiar" CssClass="btnLimpiar" runat="server" style="font-size: large;" Text="Limpiar"  CausesValidation="false" OnClick="Limpiar" />
      </section>

</asp:Content>

