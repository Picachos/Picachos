<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="ConsultarProductosTerminados.aspx.cs" Inherits="Picachos.Frontend.Vistas.Productos.ConsultarProductosTerminados" %>


<asp:Content ID="ContentCPT" ContentPlaceHolderID="contPHConsultaPT" runat="server">
     <link href="../../Estilos/ConsultarProductosTerminados.css" rel="stylesheet" type="text/css" />

     <section class="sectImgFondo">
              <asp:Image ID="imgFondoRegPT"  CssClass="imgFondoRegPT"  runat="server" ImageUrl="~/Imagenes/reg_Consultas.png"  />
     </section>

     <section class="sectContenedor">
         <asp:Label ID="labTipoConsulta" CssClass="labTipoConsulta" runat="server" Text="¿Tipo de consulta?"></asp:Label>
           <asp:Button AccessKey="U" ID="btnGeneral" CssClass="btnGeneral" runat="server"  Text="General" /> 
           <asp:Button AccessKey="E" ID="btnEspecifica" CssClass="btnEspecifica" runat="server"  Text="Especifica" /> 

         <asp:DropDownList CssClass="ddlConsPT" ID="ddlConsPT" runat="server"/>
         <asp:Button AccessKey="E" ID="btnBuscar" CssClass="btnBuscar" runat="server" /> 

         <asp:GridView ID="vgridEntySal" runat="server" AutoGenerateColumns="False" GridLines="none" >                
        
                 <AlternatingRowStyle BackColor="#DCDCDC" />
          
                  <Columns>                
                                      
                  <%--Primera columna(materiaPrimaID) de la tabla --%>
                       <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="tfHTabConsPT" ItemStyle-CssClass="tfHTabConsPT"  > <%-- tfHTabEntradaSalida referencia a vgridEntySal--%>
                              <ItemTemplate>
                                   <asp:Label ID="LabID" runat="server" Text='<%# Bind("productoID") %>'></asp:Label>
                              </ItemTemplate>
                              <EditItemTemplate>                      
                                   <asp:TextBox ID="txtID" ReadOnly="true" runat="server" Text='<%# Eval("productoID") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <HeaderStyle CssClass="tfHTabInv"></HeaderStyle>
                              <ItemStyle CssClass="tfBTabInv"></ItemStyle>
                       </asp:TemplateField>
               
                <%--Segunda columna(observacion) de la tabla  --%>
                      <asp:TemplateField HeaderText="Observación" HeaderStyle-CssClass="tfHTabConsPT" ItemStyle-CssClass="tfHTabConsPT" ControlStyle-Width="100px">
                              <ItemTemplate>
                                    <asp:Label ID="labNombre" runat="server" Text='<% # Bind("nombreProducto") %>'></asp:Label> 
                              </ItemTemplate>                  
                              <EditItemTemplate>
                                    <asp:TextBox ID="txbNombre" runat="server" Text='<% # Bind("nombreProducto") %>' ></asp:TextBox> 
                              </EditItemTemplate>
                              <ControlStyle Width="100px"></ControlStyle>
                              <HeaderStyle CssClass="tfHTabInv"></HeaderStyle>
                              <ItemStyle CssClass="tfHTabInv"></ItemStyle>
                      </asp:TemplateField>
     
               <%--Tercera columna(Fecha) de la tabla  --%>
                    <asp:TemplateField HeaderText="Fecha" HeaderStyle-CssClass="tfHTabConsPT" ItemStyle-CssClass="tfHTabConsPT" ControlStyle-Width="100px">
                             <ItemTemplate>
                                   <asp:Label ID="labDesc" runat="server" Text='<% # Bind("descripcionProducto") %>'></asp:Label> 
                             </ItemTemplate>              
                             <EditItemTemplate>
                             <asp:TextBox ID="txbDesc" runat="server" Text='<% # Bind("descripcionProducto") %>' ></asp:TextBox> 
                             </EditItemTemplate>
                    </asp:TemplateField>

               <%--Cuarta columna(CantidadES) de la tabla --%>
                    <asp:TemplateField HeaderText="Cantidad" HeaderStyle-CssClass="tfHTabConsPT" ItemStyle-CssClass="tfHTabConsPT" ControlStyle-Width="100px">
                             <ItemTemplate>
                                   <asp:Label ID="labCantidad" runat="server" Text='<% # Bind("cantidad") %>'></asp:Label> 
                             </ItemTemplate>              
                             <EditItemTemplate>
                             <asp:TextBox ID="txbCantidad" runat="server" Text='<% # Bind("cantidad") %>' ></asp:TextBox> 
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

     </section>

</asp:Content>
