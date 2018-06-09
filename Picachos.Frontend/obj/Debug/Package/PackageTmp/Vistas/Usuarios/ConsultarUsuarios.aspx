<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="Picachos.Frontend.Vistas.Usuarios.ConsultarUsuarios" %>

<asp:Content ID="contConsUsua" ContentPlaceHolderID="contPHConsUsua" runat="server">

    
      <link rel="stylesheet" href="../../Estilos/ConsultarUsuarios.css"/>

      <section id="sectImg">          
           <asp:Image ID="ImgFondo"  ImageUrl="~/Imagenes/Consultar.png" CssClass="imgFondo" runat="server" /> 
      </section>
      
       
      <section id="sectContene">

          <asp:GridView ID="vgridUsuario" runat="server" AutoGenerateColumns="False" GridLines="None" 
               OnRowCancelingEdit="CFUsuario"
               OnRowDeleting="BFUsuario"
               OnRowEditing="EFUsuario"
               OnRowUpdating="AFUsuario"
              DataKeyNames="usuarioID" >
              <Columns>
                   <%--Controles--%>
                  <asp:CommandField ButtonType="Button"  ControlStyle-CssClass="cfEditar" ShowEditButton="true" EditText="Editar" CancelText="Cancelar" DeleteText="Borrar"  UpdateText="Guardar"/>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button AccessKey="B" CssClass="btnBorrar" ID="btnBorrar" runat="server" CausesValidation ="False" CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Estas seguro de eliminar el usuario?')"/>
                     </ItemTemplate>
                </asp:TemplateField>

                  <%--Primera columna(usuarioID) de la tabla Usuarios --%>
                  <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="tfHTabU" ItemStyle-CssClass="tfBTabU"> <%-- TabU referencia a vgridUsuario--%>
                      <ItemTemplate>
                          <asp:Label ID="LabID" runat="server" Text='<%# Bind("usuarioID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtID" ReadOnly="true" runat="server" Text='<%# Eval("usuarioID") %>'></asp:TextBox>
                      </EditItemTemplate>
                      
                  </asp:TemplateField>

                   <%--Segunda columna(Nombre) de la tabla Usuarios --%>
                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="tfHTabU"  ItemStyle-CssClass="tfBTabU" >
                    <ItemTemplate>
                        <asp:Label ID="labNom" runat="server" Text='<% # Bind("nombre") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbNom" runat="server" Text='<% # Bind("nombre") %>' ></asp:TextBox> <%--textBox txb--%>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Tercera columna(NombreUsuario) de la tabla Usuarios --%>
                <asp:TemplateField HeaderText="Nombre Usuario" HeaderStyle-CssClass="tfHTabU" ItemStyle-CssClass="tfBTabU" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labNomUsu" runat="server" Text='<% # Bind("nombreUsuario") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbNomUsu" runat="server" Text='<% # Bind("nombreUsuario") %>' ></asp:TextBox> 
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Cuarta columna(Contrasena) de la tabla Usuarios --%>
                <asp:TemplateField HeaderText="Contraseña" HeaderStyle-CssClass="tfHTabU" ItemStyle-CssClass="tfBTabU" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labContra" runat="server" Text ='**********'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbContra" runat="server" Text='<% # Bind("contrasena") %>' TextMode="Password" ></asp:TextBox> 
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Quinta columna(Rol) de la tabla Usuarios --%>
                <asp:TemplateField HeaderText="Rol" HeaderStyle-CssClass="tfHTabU" ItemStyle-CssClass="tfBTabU" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labRol" runat="server" Text='<% # Bind("rol") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlRol" runat="server" SelectedValue ='<% # Bind("rol") %>'> 
                            <asp:ListItem Enabled="false">Administrador</asp:ListItem>
                            <asp:ListItem>Repartidor</asp:ListItem>
                            <asp:ListItem>Despachador</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                  <%--<asp:CommandField CancelText="Cancelar" DeleteText="Borrr" EditText="Editar" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Actualizar" />--%>
              </Columns>
          </asp:GridView>

      </section>

</asp:Content>

