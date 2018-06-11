<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="ReportesPT.aspx.cs" Inherits="Picachos.Frontend.Vistas.Productos.ReportesPT" %>

<asp:Content ID="ContReportesPT" ContentPlaceHolderID="contPHRepPT" runat="server">

     <link href="../../Estilos/ReportesEySProductos.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
              <asp:Image ID="imgFondoRepPT" CssClass="imgFondoRepPT"  runat="server" ImageUrl="~/Imagenes/productos-rep.png" />
        </section>

        <asp:Label ID="labTipoConsulta" CssClass="labTipoConsulta" runat="server" Text="Seleccione Tipo de Consulta: " ></asp:Label>
          <asp:RadioButtonList ID="radio" CssClass="radio" runat="server" RepeatDirection="Horizontal" ForeColor="#0000ff" OnSelectedIndexChanged="radio_SelectedIndexChanged" Font-Size="Large"  AutoPostBack="true" >
            <asp:ListItem Text="Entrada" Value="Entrada"  />
            <asp:ListItem Text="Salida" Value="Salida" />
            <asp:ListItem Text="General" Value="General" />
        </asp:RadioButtonList>
        
     <section class="sectContenedor">  
      
        
          <asp:GridView ID="vgridConsultaES" CssClass="vgridConsultaES" runat="server" AutoGenerateColumns="False" GridLines="none" >                
        
                 <AlternatingRowStyle BackColor="#DCDCDC" />          
                  <Columns>                
                                      
                  <%--Primera columna(productoID) de la tabla EyS --%>
                       <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="tfHTabEntradaSalida" ItemStyle-CssClass="tfHTabEntradaSalida"  ControlStyle-Width="50px"> <%-- tfHTabEntradaSalida referencia a vgridEntySal--%>
                              <ItemTemplate>
                                   <asp:Label ID="LabID" runat="server" Text='<%# Bind("productoID") %>'></asp:Label>
                              </ItemTemplate>
                              <EditItemTemplate>                      
                                   <asp:TextBox ID="txtID" ReadOnly="true" runat="server" Text='<%# Eval("productoID") %>'></asp:TextBox>
                              </EditItemTemplate>
                      </asp:TemplateField>

               
                <%--Tercera columna(observacion) de la tabla EyS --%>
                      <asp:TemplateField HeaderText="Observación" HeaderStyle-CssClass="tfHTabEntradaSalida" ItemStyle-CssClass="tfHTabEntradaSalida" ControlStyle-Width="250px">
                              <ItemTemplate>
                                    <asp:Label ID="labObservacion" runat="server" Text='<% # Bind("observacion") %>'></asp:Label> 
                              </ItemTemplate>                  
                              <EditItemTemplate>
                                    <asp:TextBox ID="txbObservacion" runat="server" Text='<% # Bind("observacion") %>' ></asp:TextBox> 
                              </EditItemTemplate>
                              
                      </asp:TemplateField>
     
               <%--Cuarta columna(Fecha) de la tabla EyS --%>
                    <asp:TemplateField HeaderText="Fecha" HeaderStyle-CssClass="tfHTabEntradaSalida" ItemStyle-CssClass="tfHTabEntradaSalida" ControlStyle-Width="200px">
                             <ItemTemplate>
                                   <asp:Label ID="labFecha" runat="server" Text='<% # Bind("fechaES") %>'></asp:Label> 
                             </ItemTemplate>              
                             <EditItemTemplate>
                             <asp:TextBox ID="txbFecha" runat="server" Text='<% # Bind("fechaES") %>' ></asp:TextBox> 
                             </EditItemTemplate>
                    </asp:TemplateField>

               <%--Cuarta columna(CantidadES) de la tabla EyS --%>
                    <asp:TemplateField HeaderText="Cantidad" HeaderStyle-CssClass="tfHTabEntradaSalida" ItemStyle-CssClass="tfHTabEntradaSalida" ControlStyle-Width="100px">
                             <ItemTemplate>
                                   <asp:Label ID="labCantidad" runat="server" Text='<% # Bind("cantidadES") %>'></asp:Label> 
                             </ItemTemplate>              
                             <EditItemTemplate>
                             <asp:TextBox ID="txbCantidad" runat="server" Text='<% # Bind("cantidadES") %>' ></asp:TextBox> 
                             </EditItemTemplate>
                    </asp:TemplateField>

                       </Columns>  

              <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
              <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
              <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
              <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#F1F1F1" />
              <SortedAscendingHeaderStyle BackColor="#0000A9" />
              <SortedDescendingCellStyle BackColor="#CAC9C9" />
              <SortedDescendingHeaderStyle BackColor="#000065" />

             </asp:GridView>
         
          </section> 
</asp:Content>

