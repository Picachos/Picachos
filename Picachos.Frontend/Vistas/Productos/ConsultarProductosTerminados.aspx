<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="ConsultarProductosTerminados.aspx.cs" Inherits="Picachos.Frontend.Vistas.Productos.ConsultarProductosTerminados" %>


<asp:Content ID="ContentCPT" ContentPlaceHolderID="contPHConsultaPT" runat="server">
     <link href="../../Estilos/ConsultarProductosTerminados.css" rel="stylesheet" type="text/css" />

     <section class="sectImgFondo">
              <asp:Image ID="imgFondoConsPT"  CssClass="imgFondoConsPT"  runat="server" ImageUrl="~/Imagenes/reg_Consultas.png"  />
     </section>

     <section class="sectContenedor">                   

         <asp:GridView ID="vgridProductos" CssClass="vgridProductos" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" 
                OnRowCancelingEdit="CFProductos"
            OnRowDeleting="BFProductos"
            OnRowEditing="EFProductos"
           OnRowUpdating="AFProductos"
            DataKeyNames="productoID" BackColor="White" BorderColor="#999999" BorderWidth="1px" CellPadding="3" >
          
           <AlternatingRowStyle BackColor="#DCDCDC" />
          
        <Columns>
                   <%--Controles--%>
                  <asp:CommandField ButtonType="Button"  ControlStyle-CssClass="cfEditar" ShowEditButton="true" EditText="Editar" CancelText="Cancelar" DeleteText="Borrar"  UpdateText="Guardar">
                            <ControlStyle CssClass="cfEditar" Width="60px"></ControlStyle>
                  </asp:CommandField>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button AccessKey="B" CssClass="btnBorrar" ID="btnBorrar" runat="server" CausesValidation ="False" CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Estas seguro de eliminar Producto?')"/>
                     </ItemTemplate>
                </asp:TemplateField>
             <%--Primera columna(productoID) de la tabla  --%>
                  <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="tfHTabProducto" ItemStyle-CssClass="tfBTabProducto" ControlStyle-Width="30px"  > <%-- TabProducto referencia a vgridProductos--%>
                      <ItemTemplate>
                          <asp:Label ID="LabID" runat="server" Text='<%# Bind("productoID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtID" ReadOnly="true" runat="server" Text='<%# Eval("productoID") %>'></asp:TextBox>
                      </EditItemTemplate>

<HeaderStyle CssClass="tfHTabProducto"></HeaderStyle>

<ItemStyle CssClass="tfBTabProducto"></ItemStyle>
                  </asp:TemplateField>
            
             <%--Segunda columna(Nombre) de la tabla  --%>
                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="tfHTabProducto" ItemStyle-CssClass="tfBTabProducto" ControlStyle-Width="100px" >
                    <ItemTemplate>
                        <asp:Label ID="labNom" runat="server" Text='<% # Bind("nombreProducto") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbNom" runat="server" Text='<% # Bind("nombreProducto") %>' ></asp:TextBox> 
                    </EditItemTemplate>
               <ControlStyle></ControlStyle>

<HeaderStyle CssClass="tfHTabProducto"></HeaderStyle>

<ItemStyle CssClass="tfBTabProducto"></ItemStyle>
                </asp:TemplateField>
            <%--Tercera columna(Descripcion) de la tabla  --%>
                <asp:TemplateField HeaderText="Descripción" HeaderStyle-CssClass="v=tfHTabProducto" ItemStyle-CssClass="tfBTabProducto" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="labDescripcion" runat="server" Text='<% # Bind("descripcionProducto") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbDescripcion" runat="server" Text='<% # Bind("descripcionProducto") %>' ></asp:TextBox> 
                    </EditItemTemplate>

                </asp:TemplateField>
              <%--Cuarta columna(materiales) de la tabla  --%>
                <asp:TemplateField HeaderText="Materiales" HeaderStyle-CssClass="tfHTabProducto" ItemStyle-CssClass="tfBTabProducto" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="labMateriales" runat="server" Text='<% # Bind("materiales") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbMateriales"  runat="server" Text='<% # Bind("materiales") %>' ></asp:TextBox> 
                    </EditItemTemplate>

<ControlStyle Width="150px"></ControlStyle>

<HeaderStyle CssClass="tfHTabProducto"></HeaderStyle>

<ItemStyle CssClass="tfBTabProducto"></ItemStyle>
                     </asp:TemplateField>
            <%--Quinta columna(Tipo) de la tabla  --%>
                <asp:TemplateField HeaderText="Tipo" HeaderStyle-CssClass="tfHTabProducto" ItemStyle-CssClass="tfBTabProducto" ControlStyle-Width="120px">
                    <ItemTemplate>
                        <asp:Label ID="labTipo" runat="server" Text='<% # Bind("tipo") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbTipo"  runat="server" Text='<% # Bind("tipo") %>' ></asp:TextBox> 
                    </EditItemTemplate>

<ControlStyle Width="120px"></ControlStyle>

<HeaderStyle CssClass="tfHTabProducto"></HeaderStyle>

<ItemStyle CssClass="tfBTabProducto"></ItemStyle>
                     </asp:TemplateField>

             <%--Sexta columna(existencia) de la tabla  --%>
                <asp:TemplateField HeaderText="Existencia" HeaderStyle-CssClass="tfHTabProducto" ItemStyle-CssClass="tfBTabProducto" ControlStyle-Width="50px">
                    <ItemTemplate>
                        <asp:Label ID="labExistencia" runat="server" Text='<% # Bind("existencia") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbExistencia" ReadOnly="true" runat="server" Text='<% # Bind("existencia") %>' ></asp:TextBox> 
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
