<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginUser.aspx.vb" Inherits="Constancia.LoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Generador de Constancias</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
	<!--Bootstrap 4.5.0-->
  	<link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <script src="jquery/jquery-3.5.1.slim.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="bootstrap/js/popper.min.js"></script>
  

    <!--Ventana Modal-->
    <link href="css/Modal.css" rel="stylesheet" />

    <link rel="stylesheet" href="css/style-constancias.css"/>
</head>
<body>
    <script>
        function ModalContrasenaIncorrecta() {
            
            $("#myModal").modal('show');
        }

        function ModalContrasenaIncorrectaCerrar() {
            $("#myModal").modal('hide');
        }

        function ModalDatos() {
            $("#myModalDatInc").modal('show');
        }

        function cerrarDatos() {
            $("#myModalDatInc").modal('hide');
        }
    </script>


    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="main_head" style="justify-content:center;" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display:flex;justify-content:center;">
            <img src="img/Logo_Plandi.png" class="img_logo_plandi" style="position:relative;text-align:center; width: calc(6em + 10vw);"/>
        </div>
        <hr style="border-color:#ACE7DE;"/>
    </div>
<div class="main_body">
		<div class="contenedor_login">
			 <div class="row" style="position: relative;">	
				 <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 login_izq">
                        <div class="lbl_bienvenido">¡BIENVENIDO!</div>
                        <br />
                        <div class="lbl_generaconstancias">
                           Aquí podrás obtener de manera fácil y rápida tu constancia.
                        </div>
                     
			        </div> 
                
				 <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 login_derecho" >
					<div style="margin-top:80px;"></div>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                            <div class="lbl_usuario">DATOS</div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="Txt_Usuario" class="form-control txt_login" runat ="server" placeholder="Nombre Completo"></asp:TextBox>
                                        <br />
                                        <asp:TextBox ID="Txt_Correo" class="form-control txt_login" runat ="server" placeholder="Correo Electrónico"></asp:TextBox>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                     </div>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                            <div class="lbl_usuario">CONTRASEÑA</div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="Txt_Contrasena" class="form-control txt_login" runat ="server" placeholder="•••••••••••" TextMode="Password"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: right; margin-top: 10%;">
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="Btn_Ingresar" CssClass="btn_siguiente" runat="server" Text="Siguiente" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
				 </div>
			 </div>
		</div>
	</div>


      
    

       
    
<!--Modal Contraseña Incorrecta-->                 
   <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content">
        <div class="modal-header">           

          <h3  class="modal-title" >¡ Error !</h3>
            <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
          
        </div>
        <div class="modal-body">
          <h6>Contraseña incorrecta, por favor intenta de nuevo.</h6>                 
        </div>
        <div class="modal-footer" style="margin-left: auto;margin-right: auto;">
         <center>
                    <a class="btn_siguiente" href="#" style="width:300px; height:60px; padding:7px;" onclick="ModalContrasenaIncorrectaCerrar();" role="button">Aceptar</a>
            </center>
        </div>
      </div>
    </div>
  </div>    

<!--Modal Datos Incompletos-->                 
   <div class="modal fade" id="myModalDatInc" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content">
        <div class="modal-header">           

          <h3  class="modal-title" >¡ Error !</h3>
            <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
          
        </div>
        <div class="modal-body">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>

                  <asp:Label ID="Lbl_validar" runat="server" Text="" Visible="false" Style="color:#000000"></asp:Label>     
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


       
  </form>          
</body>
</html>
