<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Constancia.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Generador de Constancias</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap/js/bootstrap.min.js"></script>
	<link rel="stylesheet" href="css/style-constancias.css"/>


    
    <!--Ventana Modal-->
    <link href="css/Modal.css" rel="stylesheet" />


</head>
<body>
    <script>
        function ModalContrasenaIncorrecta() {
            
            $("#myModalDatInc").modal('show');
        }

        function cerrar() {
            $("#myModalDatInc").modal('hide');
        }
    </script>


    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

	<%--<div class="main_head">--%>
        <div class="main_head_title">GENERADOR DE CONSTANCIAS</div>
        <div class="main_head_subtitle">ADMINISTRADOR</div>
        <img src="img/Logo_Plandi.png" class="img_logo_plandi"/>
           <%-- <hr style=""/>--%>
   
	<div class="main_body">
		<div class="contenedor_login">
			 <div class="row" style="position: relative;">	
				 <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 login_izq">
                        <div class="lbl_bienvenido">¡BIENVENIDO!</div>
                        <br />
                        <div class="lbl_generaconstancias">
                            Genera constancias para tus conferencias de manera fácil y rápida.
                        </div>
                     
			        </div> 
                
				 <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 login_derecho" >
					<div style="margin-top:80px;"></div>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                            <div class="lbl_usuario">USUARIO</div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                         <asp:TextBox ID="Txt_Usuario" class="form-control txt_login" runat ="server" placeholder="Nombre de usuario"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                     </div>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                            <div class="lbl_usuario">CONTRASEÑA</div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="Txt_Contraseña" class="form-control txt_login" runat ="server" placeholder="•••••••••••" TextMode="Password"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: right; margin-top: 10%;">
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btn_Ingresar" CssClass="btn_siguiente" runat="server" Text="Siguiente" />
    
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
				 </div>
    		 </div>
    	</div>
	</div>
    <!--Modal Datos Incompletos-->                 
   <div class="modal fade" id="myModalDatInc" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content">
        <div class="modal-header">           

          <h3  class="modal-title" >Sistema</h3>
            <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
          
        </div>
        <div class="modal-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                  <asp:Label ID="Lbl_validar" runat="server" Text="" Visible="True" Style="color:#000000" ></asp:Label>     
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="modal-footer" style="margin-left: auto;margin-right: auto;">
         <center>
                    <a class="btn_siguiente" style="width:300px; height:60px; padding:7px;" href="#" onclick="cerrar();" role="button">Aceptar</a>
            </center>
        </div>
      </div>
    </div>
  </div> 

</form>
</body>
</html>
