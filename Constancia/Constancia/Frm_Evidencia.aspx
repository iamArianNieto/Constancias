<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_User.Master" CodeBehind="Frm_Evidencia.aspx.vb" Inherits="Constancia.Frm_Evidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="css/style-constanciasUsuario.css" rel="stylesheet" />

    <link href="css/RadioBotones.css" rel="stylesheet" />

    <!--Bootstrap 4.5.0-->
  	<link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <script src="jquery/jquery-3.5.1.slim.min.js"></script>
    <script src="bootstrap/js/popper.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
        
    <!--Ventana Modal-->
    <link href="css/Modal.css" rel="stylesheet" />
    <script>
        function fn_cargar() {
            //alert("Hola");
            var fileuploadctrl = document.getElementById('<%= FileUp.ClientID %>');
             fileuploadctrl.click();
        }
    </script>

    <style>
        table, table tr, table td {
            display: grid;
            width:100%;
        }

         .boton{
            width:90%;
            height:50px; 
            z-index:1;
            position:absolute;
            background-color: rgb(0,229,174);
            border:none;
            outline:none;
            text-decoration:none;
            border-radius: 10px;
            color:#FFF;

        }
         .boton:hover{
            background-color: #77D2FF;
            text-decoration: none;
            outline:none;
            border:none;
        }
         .boton:active{
             background-color: #6AC0E2;
             text-decoration: none;
             outline: none;
             border:none;
        }
         .boton:focus{
             text-decoration: none;
             outline: none;
             border:none;
        }
        .btn_imagen {
        width:40px; 
        z-index:2; 
        margin-left:10px;
        position:absolute; 
        }

        .btn_content{
            display:flex;  
            position:relative; 
            margin-bottom:80px;
        }
    </style>

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
    
    <div class="main_head" style="justify-content:center;" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display:flex;justify-content:center;">
            <img src="img/Logo_Plandi.png" class="img_logo_plandi" style="position:relative;text-align:center; width: calc(6em + 10vw);"/>
        </div>
        <hr style="border-color:#ACE7DE;"/>
    </div>
        <br />
        <p >Elige una de las siguientes opciones para continuar.</p>
    <div class="main_body">        
		<div class="contenedor_login">
            <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:left; left:30px; top:20px;">
                <asp:Label ID="Label2" cssclass="lbl_evidencias" runat="server" Text="Subir Evidencias"></asp:Label><br /><br /><br />
            </div>
            </div>
            <div class="container">            
            <div class="row">
                
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                             <asp:ImageButton ID="ImBtn_Fotografia" runat="server" ImageUrl="~/img/fotografias.png" CssClass="imagen" style="width:auto; height:90px;"/>
                            <br />
                            <asp:RadioButton ID="Rd_Fotografias" runat="server" GroupName="TipoEvidencia"  AutoPostBack="True" Text="Fotografías"  />      
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                         <ContentTemplate>
                             <asp:ImageButton ID="ImBtn_Cuestionario" runat="server" ImageUrl="~/img/cuestionario.png"  CssClass="imagen" style="width:auto; height:90px;"/>
                            <asp:RadioButton ID="Rd_Cuestionario" runat="server" GroupName="TipoEvidencia"  AutoPostBack="True" Text="Cuestionario" />
                         </ContentTemplate>
                     </asp:UpdatePanel>
                </div>
                
                 <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                         <ContentTemplate>
                            <!--<asp:Panel ID="elPanel" runat="server" ></asp:Panel>-->
<%--                             <asp:PlaceHolder ID="elPanel2" runat="server"></asp:PlaceHolder>--%>
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowStyle-VerticalAlign="Bottom" DataSourceID="SqlDataSource2" style="border:hidden; width:100%;" BorderStyle="None" GridLines="None" ShowHeader="False">
                                 <Columns>
                                     <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" SortExpression="Pregunta" />
                                          <asp:TemplateField HeaderText="respuesta">
                        <ItemTemplate>
                            <asp:TextBox ID="Txt_Respuesta" runat="server" CssClass="form-control txt_login" style="width:100%;" MaxLength="498"></asp:TextBox>
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
              <br />
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="text-align:left;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>

                          <div class="col-md-12 btn_content">
                                <img src="img/subir_fotografias.png" class="btn_imagen" />
<%--                                <button type="button" class="boton" onclick="fn_cargar()" ID="Btn_subirFotografia" runat="server" >Subir Fotografía</button>--%>
                                <asp:Button ID="Btn_subirFotografia" runat="server" Text="Subir Fotografía" CssClass="boton"/>
                            </div>
                            <div style="display:none;">

                            <asp:FileUpload ID="FileUp" runat="server" AllowMultiple="true" visible="true"/>

                            </div>
  
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" >     
                    <br />
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" style="text-align:right;">
                    
                    <asp:Button ID="Btn_Siguiente" runat="server" Text="Siguiente" CssClass="btn_siguiente" />
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
                <asp:TextBox ID="Txt_idconferencia" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="Txt_auxusuario" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="txt_auxres" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="Txt_auxCorreo" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btn_agregar" runat="server" Text="Button" Visible="false"/>
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
                    <a class="btn_siguiente" href="Frm_Constancia.aspx" style="width:300px; height:60px; padding:7px;" onclick="cerrarDatos();" role="button">Aceptar</a>
            </center>
        </div>
      </div>
    </div>
  </div>    
   
    
     

</asp:Content>