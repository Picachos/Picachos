﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="RegistrarVenta.aspx.cs" Inherits="Picachos.Frontend.Vistas.Ventas.RegistrarVenta" %>

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
          <asp:Label ID="labNumNotaVe" CssClass="labNumNotaVe" runat="server" ></asp:Label>
          <asp:Label ID="labFecha" CssClass="labFecha" runat="server" Text="Fecha:"></asp:Label>
          <asp:Label ID="labFechaSistema" CssClass="labFechaSistema" runat="server"></asp:Label>

          <asp:DropDownList CssClass="ddlRegVenta" ID="ddlRegVenta" runat="server" Tooltip="Seleccionar nombre de cliente">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbDom" CssClass="txbDom" runat="server" MaxLength="60" placeholder="Domicilio"></asp:TextBox>
          <asp:TextBox  ID="txbRFC" CssClass="txbRFC" runat="server" MaxLength="60" placeholder="R.F.C."></asp:TextBox>

          <asp:TextBox  ID="txbCant" CssClass="txbCant" runat="server" MaxLength="60" Enabled="false" placeholder="CANT"></asp:TextBox>
          <asp:TextBox  ID="txbConcepto" CssClass="txbConcepto" runat="server" MaxLength="60" Enabled="false" placeholder="CONCEPTO"></asp:TextBox>
          <asp:TextBox  ID="txbPrecio" CssClass="txbPrecio" runat="server" MaxLength="60" Enabled="false" placeholder="P. UNIT"></asp:TextBox>
          <asp:TextBox  ID="txbImporte" CssClass="txbImporte" runat="server" MaxLength="60" Enabled="false" placeholder="IMPORTE"></asp:TextBox>
          
       <section id="sectContenedorRows" class="sectContenedorRows">
          <asp:TextBox  ID="txbCantCero" CssClass="txbCantCero" runat="server" MaxLength="5" OnTextChanged="multiplicarCeroCant"  ></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoCero" ID="ddlConceptoCero" runat="server" OnSelectedIndexChanged="multiplicarCeroCant" AutoPostBack="true" >                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioCero" CssClass="txbPrecioCero" runat="server" MaxLength="10"  CausesValidation="false" OnTextChanged="multiplicarCero" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteCero" CssClass="txbImporteCero" runat="server" Enabled ="false"></asp:TextBox>


          <asp:TextBox  ID="txbCantUno" CssClass="txbCantUno" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarUnoCant"></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoUno" ID="ddlConceptoUno" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarUnoCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioUno" CssClass="txbPrecioUno" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarUno"  Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteUno" CssClass="txbImporteUno" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantDos" CssClass="txbCantDos" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarDosCant"></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoDos" ID="ddlConceptoDos" runat="server" Enabled="false"  OnSelectedIndexChanged="multiplicarDosCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioDos" CssClass="txbPrecioDos" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarDos" Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteDos" CssClass="txbImporteDos" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantTres" CssClass="txbCantTres" runat="server" MaxLength="5" CausesValidation="false"  Enabled="false" OnTextChanged="multiplicarTresCant" ></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoTres" ID="ddlConceptoTres" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarTresCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioTres" CssClass="txbPrecioTres" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarTres" Enabled="false"></asp:TextBox>
          <asp:TextBox  ID="txbImporteTres" CssClass="txbImporteTres" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantCuatro" CssClass="txbCantCuatro" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarCuatroCant" ></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoCuatro" ID="ddlConceptoCuatro" runat="server" Enabled="false"  OnSelectedIndexChanged="multiplicarCuatroCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioCuatro" CssClass="txbPrecioCuatro" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarCuatro" Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteCuatro" CssClass="txbImporteCuatro" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantCinco" CssClass="txbCantCinco" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarCincoCant" ></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoCinco" ID="ddlConceptoCinco" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarCincoCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioCinco" CssClass="txbPrecioCinco" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarCinco" Enabled="false"></asp:TextBox>
          <asp:TextBox  ID="txbImporteCinco" CssClass="txbImporteCinco" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantSeis" CssClass="txbCantSeis" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarSeisCant" ></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoSeis" ID="ddlConceptoSeis" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarSeisCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioSeis" CssClass="txbPrecioSeis" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarSeis" Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteSeis" CssClass="txbImporteSeis" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantSiete" CssClass="txbCantSiete" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarSieteCant"></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoSiete" ID="ddlConceptoSiete" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarSieteCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioSiete" CssClass="txbPrecioSiete" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarSiete" Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteSiete" CssClass="txbImporteSiete" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantOcho" CssClass="txbCantOcho" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarOchoCant"></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoOcho" ID="ddlConceptoOcho" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarOchoCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioOcho" CssClass="txbPrecioOcho" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarOcho" Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteOcho" CssClass="txbImporteOcho" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantNueve" CssClass="txbCantNueve" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarNueveCant" ></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoNueve" ID="ddlConceptoNueve" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarNueveCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioNueve" CssClass="txbPrecioNueve" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarNueve" Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteNueve" CssClass="txbImporteNueve" runat="server" Enabled="false"></asp:TextBox>

          <asp:TextBox  ID="txbCantDiez" CssClass="txbCantDiez" runat="server" MaxLength="5" Enabled="false" OnTextChanged="multiplicarDiezCant"></asp:TextBox>
          <asp:DropDownList CssClass="ddlConceptoDiez" ID="ddlConceptoDiez" runat="server" Enabled="false" OnSelectedIndexChanged="multiplicarDiezCant" AutoPostBack="true">                  
          </asp:DropDownList>
          <asp:TextBox  ID="txbPrecioDiez" CssClass="txbPrecioDiez" runat="server" MaxLength="10" CausesValidation="false" OnTextChanged="multiplicarDiez" Enabled="false" ></asp:TextBox>
          <asp:TextBox  ID="txbImporteDiez" CssClass="txbImporteDiez" runat="server" Enabled="false"></asp:TextBox>
       </section>

          <asp:Label ID="labTotal" CssClass="labTotal" runat="server" Text="Total: $"></asp:Label>
          <asp:Label ID="labResultado" CssClass="labResultado" runat="server" ></asp:Label>

          <asp:Button AccessKey="G" ID="btnGuardar" CssClass="btnGuardar" runat="server"  Text="Guardar" OnClick="Guardar" />      
          <asp:Button AccessKey="C" ID="btnCancelar" CssClass="btnCancelar" runat="server"  Text="Cancelar"   />    
          <asp:Button AccessKey="B" ID="btnBuscar" CssClass="btnBuscar" runat="server"  Text="Buscar" OnClick="buscar" />    

     </section>
</asp:Content>
