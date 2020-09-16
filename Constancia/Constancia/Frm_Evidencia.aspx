<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_User.Master" CodeBehind="Frm_Evidencia.aspx.vb" Inherits="Constancia.Frm_Evidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/RadioBotones.css" rel="stylesheet" />
    <link href="css/style-constanciasUsuario.css" rel="stylesheet" />
    <!--Bootstrap 4.5.0-->
  	<link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <script src="jquery/jquery-3.5.1.slim.min.js"></script>
    <script src="bootstrap/js/popper.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function ModalDatos() {
            $("#myModalDatInc").modal('show');
        }

        function cerrarDatos() {
            $("#myModalDatInc").modal('hide');
        }

        function generarcadena(valor) {
            var x = parseInt(valor);

            
            var contador = 1;
            var respuesta = "";
            while (contador<=x)
            {

                var text = document.getElementById('ContentPlaceHolder1_txt_pregunta' + contador).innerHTML;
                alert(x);
                respuesta = respuesta + "" + text + "¥";
                contador = contador + 1; 
            }

            alert(respuesta);

            document.getElementById("<%=Txt_auxusuario.ClientID%>").value = respuesta;

        }

    </script>

<div class="formBox" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div class="main_head">
        <div class="main_head_title">GENERADOR DE CONSTANCIAS</div>
        <div class="main_head_subtitle">ADMINISTRADOR</div>
        <img src="img/Logo_Plandi.png" class="img_logo_plandi"/>
           <%-- <hr style=""/>--%>
    </div>
        <br />
        <p >Elige una de las siguientes opciones para continuar.</p>
    <div class="main_body">        
		<div class="contenedor_login">
            <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:Label ID="Label2" cssclass="lbl_usuario" runat="server" Text="Subir Evidencias"></asp:Label>
            </div>
            </div>
            <div class="container">            
            <div class="row">
                
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                             <asp:ImageButton ID="ImBtn_Fotografia" runat="server" ImageUrl="~/img/fotografias.png" CssClass="imagen" style="width:100%; height:auto;"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                         <ContentTemplate>
                             <asp:ImageButton ID="ImBtn_Cuestionario" runat="server" ImageUrl="~/img/cuestionario.png"  CssClass="imagen" style="width:100%; height:auto;"/>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                </div>
                 <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                         <ContentTemplate>
                            <!--<asp:Panel ID="elPanel" runat="server" ></asp:Panel>-->
<%--                             <asp:PlaceHolder ID="elPanel2" runat="server"></asp:PlaceHolder>--%>
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="276px">
                                 <Columns>
                                     <asp:BoundField DataField="Id_pregunta" HeaderText="Id_pregunta" SortExpression="Id_pregunta" />
                                     <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" SortExpression="Pregunta" />
                                          <asp:TemplateField HeaderText="respuesta">
                        <ItemTemplate>
                            <asp:TextBox ID="Txt_Respuesta" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GeneradorConnectionString %>" SelectCommand="SELECT [Id_pregunta], [Pregunta] FROM [Cuestionario] WHERE ([Id_conferencia] = @Id_conferencia)">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="Id_conferencia" SessionField="Id_Conferencia" Type="String" />
                                            </SelectParameters>
                             </asp:SqlDataSource>
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                        </ContentTemplate>
                     </asp:UpdatePanel>
                     

                 </div>
              
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <asp:RadioButton ID="Rd_Fotografias" runat="server" GroupName="TipoEvidencia"  AutoPostBack="True" Text="Fotografías" />      
                    </ContentTemplate></asp:UpdatePanel>
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                      <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                            <asp:RadioButton ID="Rd_Cuestionario" runat="server" GroupName="TipoEvidencia"  AutoPostBack="True" Text="Cuestionario"/>
                        </ContentTemplate></asp:UpdatePanel>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                 </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="text-align:left;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:FileUpload ID="FileUp" runat="server" AllowMultiple="true" />
  
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" >                   
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" style="text-align:right;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="Btn_Siguiente" runat="server" Text="Siguiente" CssClass="btn_siguiente" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <br /> 
            </div>
         </div>
     </div>
</div>
   
    <div>
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="Txt_idconferencia" runat="server"></asp:TextBox>
                <asp:TextBox ID="Txt_auxusuario" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt_auxres" runat="server"></asp:TextBox>
                <asp:TextBox ID="Txt_auxCorreo" runat="server"></asp:TextBox>
                <asp:Button ID="btn_agregar" runat="server" Text="Button" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
 
    <div class="modal fade" id="myModalDatInc" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content">
        <div class="modal-header">           

          <h3  class="modal-title" >¡ Sistema !</h3>
            <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
          
        </div>
        <div class="modal-body">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>

                  <asp:Label ID="lblValidacion" runat="server" Text="" Visible="true" Style="color:black"></asp:Label>     
                </ContentTemplate>
            </asp:UpdatePanel>
        
        </div>
        <div class="modal-footer" style="margin-left: auto;margin-right: auto;">
         <center>
                    <a class="btn_siguiente" href="#" style="width:300px; height:60px; padding:7px;" onclick="cerrarDatos();" role="button">Aceptar</a>
            </center>
        </div>
      </div>
    </div>
  </div>    
   
    
     

</asp:Content>
