<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Picachos.Frontend.Vistas.Inventario.Reportes" %>


<asp:Content ID="contReportes" ContentPlaceHolderID="contPHReportes" runat="server">
     <link href="../../Estilos/ReportesInventario.css" rel="stylesheet" type="text/css" />
    
     <section class="sectImgFondo">
         <asp:Image ID="imgFondoRepo" CssClass="imgFondoRepo"  runat="server" ImageUrl="~/Imagenes/reportesInventario.png"  />
     </section>
     <section class="sectContenedor">  
          <asp:DropDownList CssClass="ddlTipoRep" ID="ddlTipoRep" runat="server">
                   <asp:ListItem>Entradas</asp:ListItem>
                   <asp:ListItem>Salidas</asp:ListItem>
                   <asp:ListItem>General</asp:ListItem>
         </asp:DropDownList>

        
        
          <asp:GridView ID="vgridEntySal" CssClass="vgridEntySal" runat="server" AutoGenerateColumns="False" GridLines="none" >                
        
                 <AlternatingRowStyle BackColor="#DCDCDC" />          
                  <Columns>                
                                      
                  <%--Primera columna(materiaPrimaID) de la tabla EyS --%>
                       <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="tfHTabEntradaSalida" ItemStyle-CssClass="tfHTabEntradaSalida"  > <%-- tfHTabEntradaSalida referencia a vgridEntySal--%>
                              <ItemTemplate>
                                   <asp:Label ID="LabID" runat="server" Text='<%# Bind("materiaPrimaID") %>'></asp:Label>
                              </ItemTemplate>
                              <EditItemTemplate>                      
                                   <asp:TextBox ID="txtID" ReadOnly="true" runat="server" Text='<%# Eval("materiaPrimaID") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <HeaderStyle CssClass="tfHTabInv"></HeaderStyle>
                              <ItemStyle CssClass="tfBTabInv"></ItemStyle>
                       </asp:TemplateField>
               
                <%--Segunda columna(observacion) de la tabla EyS --%>
                      <asp:TemplateField HeaderText="Observación" HeaderStyle-CssClass="tfHTabEntradaSalida" ItemStyle-CssClass="tfHTabEntradaSalida" ControlStyle-Width="100px">
                              <ItemTemplate>
                                    <asp:Label ID="labObservacion" runat="server" Text='<% # Bind("observacion") %>'></asp:Label> 
                              </ItemTemplate>                  
                              <EditItemTemplate>
                                    <asp:TextBox ID="txbObservacion" runat="server" Text='<% # Bind("observacion") %>' ></asp:TextBox> 
                              </EditItemTemplate>
                              <ControlStyle Width="100px"></ControlStyle>
                              <HeaderStyle CssClass="tfHTabInv"></HeaderStyle>
                              <ItemStyle CssClass="tfHTabInv"></ItemStyle>
                      </asp:TemplateField>
     
               <%--Tercera columna(Fecha) de la tabla EyS --%>
                    <asp:TemplateField HeaderText="Fecha" HeaderStyle-CssClass="tfHTabEntradaSalida" ItemStyle-CssClass="tfHTabEntradaSalida" ControlStyle-Width="100px">
                             <ItemTemplate>
                                   <asp:Label ID="labFecha" runat="server" Text='<% # Bind("fecha") %>'></asp:Label> 
                             </ItemTemplate>              
                             <EditItemTemplate>
                             <asp:TextBox ID="txbFecha" runat="server" Text='<% # Bind("fecha") %>' ></asp:TextBox> 
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

              <%--<asp:CommandField CancelText="Cancelar" DeleteText="Borrr" EditText="Editar" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Actualizar" />--%>
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
         
     
             <asp:Button AccessKey="G" ID="btnGenerar" CssClass="btnGenerar" runat="server" style="font-size: large" Text="Generar" OnClick="GenerarReporte"  />           

     </section> 
</asp:Content>
