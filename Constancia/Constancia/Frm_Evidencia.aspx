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
                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/fotografias.png" CssClass="imagen" />
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/cuestionario.png"  CssClass="imagen"/>
                </div>
                 <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                      <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                 </div>
              
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="TipoEvidencia"  AutoPostBack="True" Text="Fotografías" />      
                    </ContentTemplate></asp:UpdatePanel>
                </div>
                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                      <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="TipoEvidencia"  AutoPostBack="True" Text="Cuestionario"/>
                        </ContentTemplate></asp:UpdatePanel>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                 </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="text-align:left;">
                    <input type="button" value="Subir Fotografías" onclick="showBrowseDialog()" />
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" >                   
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" style="text-align:right;">
                    <asp:Button ID="Button2" runat="server" Text="Siguiente" CssClass="btn_siguiente" />
                </div>
            </div>
            <br /> 
            <asp:FileUpload ID="FileUpload1" Style="display: none" runat="server" onchange="upload()" />
            </div>
         </div>
     </div>
</div>
   
 

   
    
     


<script type="text/javascript" language="javascript">
    function showBrowseDialog() {
        var fileuploadctrl = document.getElementById('<%= FileUpload1.ClientID %>');
        fileuploadctrl.click();
    }

    function upload() {
      <%--  var btn = document.getElementById('<%= hideButton.ClientID %>');--%>
        btn.click();
    }
</script>
</asp:Content>
