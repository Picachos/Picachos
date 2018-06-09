<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Picachos.Master" AutoEventWireup="true" CodeBehind="CosultarInventario.aspx.cs" Inherits="Picachos.Frontend.Vistas.Inventario.CosultarInventario" %>

<asp:Content ID="contConsInv" ContentPlaceHolderID="contPHConsInv" runat="server">
    <link href="../../Estilos/ConsultarInventario.css" rel="stylesheet" type="text/css" />
   
   <section class="sectImgFondo">
         <asp:Image ID="imgFondoConsInv"  CssClass="imgFondoConsInv"  runat="server" ImageUrl="~/Imagenes/consInv.png" />
   </section>


   <section class="sectContenedor">
         
       <asp:GridView ID="vgridInventario" runat="server" AutoGenerateColumns="False" DataKeyNames="materiaPrimaID" DataSourceID="sqlSourcesDataInventario" Height="161px" Width="222px">
           <Columns>
               <asp:BoundField DataField="materiaPrimaID" HeaderText="materiaPrimaID" InsertVisible="False" ReadOnly="True" SortExpression="materiaPrimaID" />
               <asp:BoundField DataField="productoID" HeaderText="productoID" SortExpression="productoID" />
               <asp:BoundField DataField="nombreMateria" HeaderText="nombreMateria" SortExpression="nombreMateria" />
               <asp:BoundField DataField="existencia" HeaderText="existencia" SortExpression="existencia" />
               <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
           </Columns>
       </asp:GridView>
       <asp:SqlDataSource ID="sqlSourcesDataInventario" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:picachosConnectionString %>" DeleteCommand="DELETE FROM [Materiaprima] WHERE [materiaPrimaID] = @original_materiaPrimaID AND (([productoID] = @original_productoID) OR ([productoID] IS NULL AND @original_productoID IS NULL)) AND (([nombreMateria] = @original_nombreMateria) OR ([nombreMateria] IS NULL AND @original_nombreMateria IS NULL)) AND (([existencia] = @original_existencia) OR ([existencia] IS NULL AND @original_existencia IS NULL)) AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL))" InsertCommand="INSERT INTO [Materiaprima] ([productoID], [nombreMateria], [existencia], [descripcion]) VALUES (@productoID, @nombreMateria, @existencia, @descripcion)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Materiaprima]" UpdateCommand="UPDATE [Materiaprima] SET [productoID] = @productoID, [nombreMateria] = @nombreMateria, [existencia] = @existencia, [descripcion] = @descripcion WHERE [materiaPrimaID] = @original_materiaPrimaID AND (([productoID] = @original_productoID) OR ([productoID] IS NULL AND @original_productoID IS NULL)) AND (([nombreMateria] = @original_nombreMateria) OR ([nombreMateria] IS NULL AND @original_nombreMateria IS NULL)) AND (([existencia] = @original_existencia) OR ([existencia] IS NULL AND @original_existencia IS NULL)) AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL))">
           <DeleteParameters>
               <asp:Parameter Name="original_materiaPrimaID" Type="Int32" />
               <asp:Parameter Name="original_productoID" Type="Int32" />
               <asp:Parameter Name="original_nombreMateria" Type="String" />
               <asp:Parameter Name="original_existencia" Type="Int32" />
               <asp:Parameter Name="original_descripcion" Type="String" />
           </DeleteParameters>
           <InsertParameters>
               <asp:Parameter Name="productoID" Type="Int32" />
               <asp:Parameter Name="nombreMateria" Type="String" />
               <asp:Parameter Name="existencia" Type="Int32" />
               <asp:Parameter Name="descripcion" Type="String" />
           </InsertParameters>
           <UpdateParameters>
               <asp:Parameter Name="productoID" Type="Int32" />
               <asp:Parameter Name="nombreMateria" Type="String" />
               <asp:Parameter Name="existencia" Type="Int32" />
               <asp:Parameter Name="descripcion" Type="String" />
               <asp:Parameter Name="original_materiaPrimaID" Type="Int32" />
               <asp:Parameter Name="original_productoID" Type="Int32" />
               <asp:Parameter Name="original_nombreMateria" Type="String" />
               <asp:Parameter Name="original_existencia" Type="Int32" />
               <asp:Parameter Name="original_descripcion" Type="String" />
           </UpdateParameters>
       </asp:SqlDataSource>
         
   </section> 

</asp:Content>
