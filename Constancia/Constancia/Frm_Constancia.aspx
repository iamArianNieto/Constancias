<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_User.Master" CodeBehind="Frm_Constancia.aspx.vb" Inherits="Constancia.Frm_Constancia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Generador de Constancias</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>   
    <link rel="stylesheet" type="text/css" href="css/colortip-1.0-jquery.css"/>      

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script> 

    <link href="css/Modal.css" rel="stylesheet" />

    <script type="text/javascript" src="jquery/colortip-1.0-jquery.js"></script>
    <script src ="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.debug.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
    <%--<script src="jquery/jspdf.debug.js"></script>--%>
      
    <style>
        html, body, html * {
            font-family: 'Roboto';
        }

        .html, body {
            /* Para que funcione correctamente en Smartphones y Tablets */
            height: 100vh;
        }

        body{
            overflow-x: hidden;            
        }

        .cabecero_titulo{
	        height: 110px; 
	        width: 100%; 
	        background-image: url(img/fondo3.png);
	        color: #FFF;
	        text-align: center; 
	        justify-content: center;  	
        }
        
        .logo_cabe{
            width: 20%
        }

        .boton{
            text-align:right;
            padding-right: 3%;
            padding-top: 3%;
        }

        .imagen{
            background-image: url("img/Reconocimiento.svg");
            background-repeat: no-repeat;
            padding-left: 55px;
            width: 100%;
            height: 800px;
        }      
        
        .acomodo{
            text-align: right; 
            padding-top: 60px; 
            padding-right: 2%;
        }

        .tamImagen{
            width: 60%;
        }

        .img-cont{
            padding-left: 28%;
            padding-top: 20px;
        }

        .tamImagen {
                width: 60%;
            }
        
            .acomodo{
                text-align: right; 
                padding-top: 30px; 
                padding-right: 5%;
            }

        .encabezadoCon{
            padding-top: 70px;
            font-size: 25px;
            text-align: center;
        }

        .reconocimientoCon{
            padding-top: 5px;
            font-size: 35px;
            text-align: center;
            color: green
        }

        .aCon{
            font-size: 18px;
            text-align: center;
        }

        .nombreCon{
            font-size: 25px;
            text-align: center;
        }

        .complementoCon{
            padding-top: 10px;
            font-size: 19px;
            text-align: center;
        }

        .horaCon{
            padding-top: 12px;
            font-size: 12px;
            text-align: right;
        }

        @media only screen and (min-width: 1000px) and (max-width: 1130px){
            .tamImagen {
                width: 50%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 30px; 
                padding-right: 0%;
            }

            .logo_cabe{
                width: 27%
            }

            .img-cont{
                padding-left: 20%;
                padding-top: 10px;
            }

            .imagen {
                transform: scale(.9);
                padding-left: 115px;
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 900px) and (max-width: 999px){
            .tamImagen {
                width: 50%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 20px; 
                padding-right: 0%;
            }

            .logo_cabe{
                width: 31%
            }

            .img-cont{
                padding-left: 13%;
                padding-top: 20px;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 115px;
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 20px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 850px) and (max-width: 899px){
            .tamImagen {
                width: 50%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 20px; 
                padding-right: 0%;
            }

            .logo_cabe{
                width: 31%
            }

            .img-cont{
                padding-left: 10%;
                padding-top: 20px;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 100px;
                transform: scale(.9);
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 800px) and (max-width: 849px){
            .tamImagen {
                width: 50%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 20px; 
                padding-right: 0%;
            }

            .logo_cabe{
                width: 31%
            }

            .img-cont{
                padding-left: 6%;
                padding-top: 20px;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 100px;
                transform: scale(.9);
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 750px) and (max-width: 799px){
            .tamImagen {
                width: 50%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 20px; 
                padding-right: 0%;
            }

            .logo_cabe{
                width: 34%
            }

            .img-cont{
                padding-left: 4%;
                padding-top: 20px;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 100px;
                transform: scale(.9);
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 700px) and (max-width: 749px){
            .tamImagen {
                width: 70%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 20px; 
                padding-right: 3%;
            }


            .logo_cabe{
                width: 34%
            }

            .img-cont{
                padding-left: 4%;
                padding-top: 20px;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 100px;
                transform: scale(.8);
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 650px) and (max-width: 699px){
            .tamImagen {
                width: 100%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 20px; 
                padding-right: 6%;
            }


            .logo_cabe{
                width: 40%
            }

            .img-cont{
                padding-left: 1%;
                padding-top: 20px;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 100px;
                transform: scale(.7);
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 600px) and (max-width: 649px){
            .tamImagen {
                width: 100%;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 20px; 
                padding-right: 6%;
            }

            .logo_cabe{
                width: 40%
            }

            .img-cont{
                padding-left: 0%;
                padding-top: 20px;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 100px;
                transform: scale(.7);
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }

        @media only screen and (min-width: 550px) and (max-width: 599px) {
            .tamImagen {
                width: 100%;
            }

            .logo_cabe {
                width: 50%
            }

            .img-cont {
                padding-left: 0%;
                padding-top: 20px;
            }
        
            .acomodo{
                text-align: center; 
                padding-top: 10px; 
                padding-right: 6%;
            }

            .imagen {
                width: 700px;
                height: 700px;
                padding-left: 100px;
                transform: scale(.7);
            }

            .encabezadoCon{
                padding-top: 70px;
                font-size: 22px;
                text-align: center;
            }

            .reconocimientoCon{
                padding-top: 5px;
                font-size: 30px;
                text-align: center;
                color: green
            }

            .aCon{
                font-size: 13px;
                text-align: center;
            }

            .nombreCon{
                font-size: 20px;
                text-align: center;
            }

            .complementoCon{
                padding-top: 20px;
                font-size: 15px;
                text-align: center;
            }

            .horaCon{
                padding-top: 12px;
                font-size: 11px;
                text-align: right;
            }
        }
    </style>

    <script>
        $(document).ready(function(){
            $('[title]').colorTip({color:'yellow'});             
        });

        function generarPDF(enca1, enca2, reco, a, nom, res1, res2,pon, res3, fech) {                
            
            var doc = new jsPDF('l', 'pt', 'letter')
                , size = [14]
                , font = ""
                , font, size, lines
                , verticalOffset = 10;
            // Font font1 = new Font(Font.TIMES_ROMAN, 10, Font.BOLD); //negrita
            //var doc = new jsPDF('l','pt','letter');

            var logo = new Image();
            logo.src = 'img/Constancia.jpg';       
            doc.addImage(logo, 'JPEG', 10, 20, 770, 570);
            doc.setFontSize(20);
            doc.text(400, 130, enca1, 'center');
            doc.text(400, 155, enca2, 'center');
            doc.setFontSize(35);
            doc.setTextColor(112,168,32);
            doc.text(400, 220, reco, 'center');
            doc.setFontSize(20);
            doc.setTextColor(0,0,0);
            doc.text(400, 245, a, 'center');
            doc.setFontSize(30);
            
           doc.text(400, 290, nom, 'center');
          

            doc.setFontSize(20);
       

           lines = doc.setFont(font[0], font[0])
               .setFontSize(size)
         
                       .splitTextToSize(res1, 603), //this is how long you want your text

           doc.text(400,  350, lines,'center'),
           //     doc.text(400, 330, pon, 'center');
           //doc.fromHTML('Paranyan <b>' + pon + '</b> jsPDF', 400, 320);
            //doc.setFontSize(20);
            //doc.text(400, 370, res2, 'center');
            //doc.setFontSize(20);
            //doc.text(400, 390, res3, 'center');
            //doc.setFontSize(15);
            doc.text(688, 430, fech, 'right');
            doc.save('Constancia.pdf');

            $("#myModalObservaciones").modal();
        }

        function insertar() {
            var boton = document.getElementById("<%=Btn_Aux.ClientID%>");
            boton.click();
        }

        function cerrar() {
            $("#myModalObservaciones").cerrar();
        }

        function imprimir() {
            var boton = document.getElementById("<%=Img_Imprimir.ClientID%>");
            boton.click()
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <asp:scriptmanager runat="server"></asp:scriptmanager>
    <div class="cabecero_titulo">
        <asp:Image ID="Img_plandi" runat="server" ImageUrl="~/img/Logo_Plandi.png" class="logo_cabe" />
    </div>    
    <div class="row">         
        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 img-cont">            
            <div class="imagen">
                <asp:Label ID="Lbl_Encabezado" runat="server" Width="75%" CssClass="encabezadoCon"></asp:Label>
                <asp:Label ID="Lbl_Reconocimiento" runat="server" Width="75%" CssClass="reconocimientoCon"></asp:Label>
                <asp:Label ID="Lbl_a" runat="server" Width="75%" CssClass="aCon"></asp:Label>
                <asp:Label ID="Lbl_Nombre" runat="server" Width="75%" CssClass="nombreCon"></asp:Label>                
                <asp:Label ID="Lbl_Complemento" runat="server" Width="75%" CssClass="complementoCon"></asp:Label>
                <asp:Label ID="Lbl_Fecha" runat="server" Width="75%" CssClass="horaCon"></asp:Label>
            </div>            
        </div>
        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 acomodo">            
            <a title="Descargar" class="imprimir"><img src="img/descargar.png" title="Descargar" onclick="imprimir()" class="tamImagen"/></a>
            
        </div>
        <div style="visibility: hidden">
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <asp:Button ID="Btn_Aux" runat="server" Text="Button" />
                    <asp:ImageButton ID="Img_Imprimir" runat="server"  ImageUrl="~/img/descargar.png" Width="5%" ToolTip="Descargar"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
  
    <!--Modal de observaciones-->                 
    <div class="modal fade" id="myModalObservaciones" role="dialog" data-backdrop="static">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">           
                    <h4  class="modal-title" style="color: white; padding-left: 10px;" >Manda tus comentarios</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>          
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="Txt_Observaciones" runat="server" TextMode="MultiLine" Width="100%" Height="120px" placeholder="Tu comentario aquí" MaxLength="498"></asp:TextBox>           
                </div>
                <div class="modal-footer" style="margin-left: auto;margin-right: auto;">                    
                    <center>
                        <a class="myButton" href="" role="button" onclick="insertar()">Enviar</a>
                    </center>
                </div>
            </div>
        </div>
    </div>    
     
</asp:Content>
