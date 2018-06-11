<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="CosultarInventario.aspx.cs" Inherits="Picachos.Frontend.Vistas.Inventario.CosultarInventario" EnableEventValidation="false" %>

<asp:Content ID="contConsInv" ContentPlaceHolderID="contPHConsInv" runat="server">
    <link href="../../Estilos/ConsultarInventario.css" rel="stylesheet" type="text/css" />
   
   <section class="sectImgFondo">
         <asp:Image ID="imgFondoConsInv"  CssClass="imgFondoConsInv"  runat="server" ImageUrl="~/Imagenes/consInv.png" />
   </section>


   <section class="sectContenedor">
         
       <asp:GridView ID="vgridInventario" CssClass="vgridInventario" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" 
                OnRowCancelingEdit="CFInventario"
            OnRowDeleting="BFInventario"
            OnRowEditing="EFInventario"
           OnRowUpdating="AFInventario"
            DataKeyNames="materiaPrimaID" BackColor="White" BorderColor="#999999" BorderWidth="1px" CellPadding="3" >
          
           <AlternatingRowStyle BackColor="#DCDCDC" />
          
        <Columns>
                   <%--Controles--%>
                  <asp:CommandField ButtonType="Button"  ControlStyle-CssClass="cfEditar" ShowEditButton="true" EditText="Editar" CancelText="Cancelar" DeleteText="Borrar"  UpdateText="Guardar">
                            <ControlStyle CssClass="cfEditar" Width="60px"></ControlStyle>
                  </asp:CommandField>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button AccessKey="B" CssClass="btnBorrar" ID="btnBorrar" runat="server" CausesValidation ="False" CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Estas seguro de eliminar Materia Prima?')"/>
                     </ItemTemplate>
                </asp:TemplateField>
             <%--Primera columna(materiaPrimaID) de la tabla materiaPrima --%>
                  <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="tfHTabInv" ItemStyle-CssClass="tfBTabInv" ControlStyle-Width="50px"  > <%-- TabInv referencia a vgridInventario--%>
                      <ItemTemplate>
                          <asp:Label ID="LabID" runat="server" Text='<%# Bind("materiaPrimaID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtID" ReadOnly="true" runat="server" Text='<%# Eval("materiaPrimaID") %>'></asp:TextBox>
                      </EditItemTemplate>

<HeaderStyle CssClass="tfHTabInv"></HeaderStyle>

<ItemStyle CssClass="tfBTabInv"></ItemStyle>
                  </asp:TemplateField>
            
             <%--Tercera columna(NombreMateriaPrima) de la tabla materiaPrima --%>
                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="tfHTabInv" ItemStyle-CssClass="tfHTabInv" ControlStyle-Width="200px" >
                    <ItemTemplate>
                        <asp:Label ID="labNom" runat="server" Text='<% # Bind("nombreMateria") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbNom" runat="server" Text='<% # Bind("nombreMateria") %>' ></asp:TextBox> 
                    </EditItemTemplate>
               <ControlStyle></ControlStyle>

<HeaderStyle CssClass="tfHTabInv"></HeaderStyle>

<ItemStyle CssClass="tfHTabInv"></ItemStyle>
                </asp:TemplateField>
             <%--Cuarta columna(existencia) de la tabla materiaPrima --%>
                <asp:TemplateField HeaderText="Existencia" HeaderStyle-CssClass="tfHTabInv" ItemStyle-CssClass="tfHTabInv" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labExistencia" runat="server" Text='<% # Bind("existencia") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbExistencia" ReadOnly="true" runat="server" Text='<% # Bind("existencia") %>' ></asp:TextBox> 
                    </EditItemTemplate>

<ControlStyle Width="100px"></ControlStyle>

<HeaderStyle CssClass="tfHTabInv"></HeaderStyle>

<ItemStyle CssClass="tfHTabInv"></ItemStyle>
                </asp:TemplateField>
              <%--Quinta columna(Descripcion) de la tabla materiaPrima --%>
                <asp:TemplateField HeaderText="Descripcion" HeaderStyle-CssClass="tfHTabInv" ItemStyle-CssClass="tfHTabInv" ControlStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="labDescripcion" runat="server" Text='<% # Bind("descripcion") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbDescripcion" runat="server" Text='<% # Bind("descripcion") %>' ></asp:TextBox> 
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
