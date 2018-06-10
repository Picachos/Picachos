<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="ConsultarClientes.aspx.cs" Inherits="Picachos.Frontend.Vistas.Clientes.ConsultarClientes" %>


<asp:Content ID="contConsClie" ContentPlaceHolderID="contPHConsC" runat="server">
    <link  href="../../Estilos/ConsultarClientes.css" rel="stylesheet" type="text/css" />
    
     <section id="sectImg">
              <asp:Image ID="imgFondo" CssClass="imgFondo"  runat="server" ImageUrl="~/Imagenes/cons-clientes.png"  />
     </section>
      
     <%--Contenedor donde se presentara la informacion para registro de cliente, con validaciones y mensajes de error --%>
     <section id="sectContene">       
          <%--AQUI VA EL CODIGO--%>
          <asp:GridView ID="vgridClientes" runat="server" AutoGenerateColumns="False" GridLines="None" 
               OnRowCancelingEdit="CFCliente"
               OnRowDeleting="BFCliente"
               OnRowEditing="EFCliente"
               OnRowUpdating="AFCliente"
              DataKeyNames="clienteID" >
              <Columns>
                   <%--Controles--%>
                  <asp:CommandField ButtonType="Button"  ControlStyle-CssClass="cfEditar" ShowEditButton="true" EditText="Editar" CancelText="Cancelar" DeleteText="Borrar"  UpdateText="Guardar"/>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button AccessKey="B" CssClass="btnBorrar" ID="btnBorrar" runat="server" CausesValidation ="False" CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Estas seguro de eliminar el cliente?')"/>
                     </ItemTemplate>
                </asp:TemplateField>

                  <%--Primera columna(clienteID) de la tabla Clientes --%>
                  <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="tfHTabC" ItemStyle-CssClass="tfBTabC"> <%-- TabC referencia a vgridClientes--%>
                      <ItemTemplate>
                          <asp:Label ID="LabID" runat="server" Text='<%# Bind("clienteID") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtID" ReadOnly="true" runat="server" Text='<%# Eval("clienteID") %>'></asp:TextBox>
                      </EditItemTemplate>
                      
                  </asp:TemplateField>

                   <%--Segunda columna(Nombre) de la tabla Clientes --%>
                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="tfHTabC"  ItemStyle-CssClass="tfBTabC" >
                    <ItemTemplate>
                        <asp:Label ID="labNom" runat="server" Text='<% # Bind("nombre") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbNom" runat="server" Text='<% # Bind("nombre") %>' ></asp:TextBox> <%--textBox txb--%>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Tercera columna(rfc) de la tabla clientes --%>
                <asp:TemplateField HeaderText="RFC" HeaderStyle-CssClass="tfHTabC" ItemStyle-CssClass="tfBTabC" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labRFC" runat="server" Text='<% # Bind("rfc") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbRFC" runat="server" Text='<% # Bind("rfc") %>' ></asp:TextBox> 
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Cuarta columna(observaciones) de la tabla Clientes --%>
                <asp:TemplateField HeaderText="Observaciones" HeaderStyle-CssClass="tfHTabC" ItemStyle-CssClass="tfBTabC" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labObs" runat="server" Text ='<% # Bind("observaciones") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                        <asp:TextBox ID="txbObs" runat="server" Text='<% # Bind("observaciones") %>' ></asp:TextBox> 
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Quinta columna(Direccion) de la tabla Clientes --%>
                <asp:TemplateField HeaderText="Dirección" HeaderStyle-CssClass="tfHTabC" ItemStyle-CssClass="tfBTabC" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labDir" runat="server" Text='<% # Bind("direccion") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                         <asp:TextBox ID="txbDir" runat="server" Text='<% # Bind("direccion") %>' ></asp:TextBox> 
                    </EditItemTemplate>
                </asp:TemplateField>

                   <%--Sexta columna(Telefono) de la tabla Clientes --%>
                <asp:TemplateField HeaderText="Teléfono" HeaderStyle-CssClass="tfHTabC" ItemStyle-CssClass="tfBTabC" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="labTel" runat="server" Text='<% # Bind("telefono") %>'></asp:Label> 
                    </ItemTemplate>
                        
                    <EditItemTemplate>
                         <asp:TextBox ID="txbTel" runat="server" Text='<% # Bind("telefono") %>' ></asp:TextBox> 
                    </EditItemTemplate>
                </asp:TemplateField>

                  <%--<asp:CommandField CancelText="Cancelar" DeleteText="Borrr" EditText="Editar" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Actualizar" />--%>
              </Columns>
          </asp:GridView>
     </section>
</asp:Content>
