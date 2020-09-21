<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_Admin.Master" CodeBehind="Frm_Administracion.aspx.vb" Inherits="Constancia.Frm_Administracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/RadioBotones.css" rel="stylesheet" />
    <link href="css/style-constanciasUsuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
            body {
            overflow-y:auto;
            }
        .boton{
            color:white;
            background-color: #00E5AE;
            border-radius:5px;
            padding: 10px;
            font-size:3vh;
            font-display:block;
            border-color:#00E5AE;
            border-style:none;
        }

        .boton:hover{
            background-color:#77D2FF;
        }

        .botonmas{

              width: 30px;
              height: 30px;
              text-align: center;
              display: flex;
              justify-content: center;
              align-items: center;
              transition: transform .2s;

             -moz-border-radius: 50%;
             -webkit-border-radius: 50%;
             border-radius: 50%;
             color:white;
             background-color: #00E5AE;
             border-color:#00E5AE;
             border-style:none;
             outline:none;
      
        }

        .botonmas:hover{
            background-color:#77D2FF;
        }
    </style>

    <script>
        function nuevo() {
            var resultado = "";
            var contador = 2;
           
            var aux = document.getElementById('txt_auxdiv').value;
            var masuno = parseInt(aux) + parseInt(1);
            document.getElementById('txt_auxdiv').value = masuno;
            resultado = "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 row'>"
            
                var x;
                var aux_contador;
           
            while (parseInt(contador) <= (masuno))
            {
                if (parseInt(aux) > 1) {
                    aux_contador = contador - 1;
                    if (aux_contador != 1) {
                        x = document.getElementById('Pregunta' + aux_contador).value;
                        
                       
                        document.getElementById('Pregunta' + aux_contador).value = x;
                    }

                        resultado = resultado + "<div class='col-lg-10 col-md-10 col-sm-10 col-xs-10'>"
                        resultado = resultado + "<h6 id='Lblpregunta" + contador + "' style='margin-left:-78%; color:#999999;'>Pregunta " + contador + "</h6>"
                        resultado = resultado + "<input id='Pregunta" + contador + "' required type='text' class='form-control txt_login'/>"
                        resultado = resultado + "</div>"
                        resultado = resultado + "<div class='col-lg-2 col-md-2 col-sm-2 col-xs-2'>"
                        resultado = resultado + "<input id='Btnpregunta" + contador + "'  class='botonmas' type='button' value='+' style='margin-top:30px;' onclick='nuevo();'/>"
                        resultado = resultado + "</div>"
                       contador++;
                   
                  //  
             
                }
                else {
                 
                    resultado = resultado + "<div class='col-lg-10 col-md-10 col-sm-10 col-xs-10'>"
                    resultado = resultado + "<h6 id='Lblpregunta" + contador + "' style='margin-left:-78%;'>Pregunta " + contador + "</h6>"
                    resultado = resultado + "<input id='Pregunta" + contador + "' required type='text' class='form-control txt_login'/>"
                
               
                    resultado = resultado + "</div>"
                    resultado = resultado + "<div class='col-lg-2 col-md-2 col-sm-2 col-xs-2'>"
                    resultado = resultado + "<input id='Btnpregunta" + contador + "'  class='botonmas' type='button' value='+' style='margin-top:30px;' onclick='nuevo();'/>"
                    resultado = resultado + "</div>"

                    contador++;
                 }
            }
            resultado = resultado + "</div>"
            document.getElementById('divpreguna').innerHTML = resultado;
        } 

        function generacadena() {
             var resultado = "";
             var contador = 2;
             var aux = document.getElementById('txt_auxdiv').value;

            var primer = document.getElementById('Pregunta').value;
            resultado = primer +"¥"
           
            while (parseInt(contador) <= parseInt(aux)) {
                var respuesa = document.getElementById('Pregunta' + contador).value;
                resultado = resultado + "" + respuesa+"¥"

                contador++;
            }

            document.getElementById('<%=Txt_GenerarCadena.ClientID%>').value = resultado;
           // alert(resultado);
            var btn = document.getElementById('<%=Btn_Generarcadena.ClientID%>');
            btn.click();
            Modal();                              
        }

        
        function ModalInicial() {
           
            document.getElementById('txt_auxdiv').value = "1";
            document.getElementById('divpreguna').innerHTML = "";
            document.getElementById('Pregunta').value = "";
            
             $("#myModal").modal('show');
        }


        function ModalDatos() {
            $("#myModalDatInc").modal('show');
        }

        function cerrarDatos() {
            $("#myModalDatInc").modal('hide');
        }
                       
        function Modal() {
            
            $("#myModal").modal('show');
        }

        function ModalCerrar() {
            $("#myModal").modal('hide');
        }

  
    </script>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main_head">
        <div class="main_head_title">GENERADOR DE CONSTANCIAS</div>
        <div class="main_head_subtitle">ADMINISTRADOR</div>
        <img src="img/Logo_Plandi.png" class="img_logo_plandi"/>
        <hr style="border-color:azure;"/>
    </div>

        <center><h3 style="color:white; font-weight:bold;">¡BIENVENIDO!</h3></center>
        <p >Llena los siguientes campos.</p>

        <div class="main_body">
            <div class="contenedor_login" >

                <div class="row container" style="margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px;">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 row" style="margin-top:50px;">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">

                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div class="form-group2">
                                        <asp:TextBox ID="Txt_Ponente" placeholder="Nombre del Ponente" runat="server" CssClass="form-control txt_login" MaxLength="198"></asp:TextBox>
                                    </div>
                                    <br />
                                    <asp:TextBox ID="Txt_Conferencia" placeholder="Nombre de la Conferencia" runat="server" CssClass="form-control txt_login" MaxLength="498"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 row">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <img src="imagenes/hora.png" alt="Alternate Text" style="width:15%; height:auto;" />
                                        <asp:Label ID="Lbl_Hora" runat="server" Text="Horario" Font-Bold="true" style="color:#999999;"></asp:Label>
                                        <asp:TextBox ID="Txt_Hora" runat="server" TextMode="Time" Style="width:100%" CssClass="form-control txt_login"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>  
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <img src="imagenes/fecha.png" alt="Alternate Text" style="width:15%;"/>
                                        <asp:Label ID="Lbl_Fecha" runat="server" Text="Fecha" Font-Bold="true" style="color:#999999;"></asp:Label> <br />
                                        <asp:TextBox ID="Txt_Fecha" runat="server" TextMode="Date" Style="width:100%" CssClass="form-control txt_login"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 row" style="margin-top:20px; margin-right:0px; margin-left:5px; border-bottom:1px solid #77D2FF;">
                        <h6 style="color:#77D2FF; ">CUESTIONARIO</h6>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 row" style="margin-top:20px;">
            
                        <div  class="col-lg-8 col-md-8 col-sm-8 col-xs-8" style="overflow-y:scroll; height:200px;" >
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 row">
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
                                    <h6 id="Lblpregunta" style="margin-left:-78%; color:#999999;">Pregunta 1</h6>
                                    <input id="Pregunta" type="text" style="width:100%;" required class="form-control txt_login"/>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                    <input id="Btnpregunta" class="botonmas" type="button" value="+"  style="margin-top:30px;" onclick='nuevo();' />
                       
                                </div>
                            </div>
                            <div id="divpreguna"></div>

                        </div>
                        <div  class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <center><asp:Button ID="Btn_Terminar" runat="server" Text="Terminar" cssclass="boton" Font-Bold="true" style="border-radius:10px;width:100%;max-width:214px;margin-top:150px;"/></center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <div style="visibility:hidden">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                           <asp:Button ID="Btn_Generarcadena" runat="server" Text="Button" />

                            <asp:TextBox ID="Txt_GenerarCadena" runat="server" AutoPostBack="true" Style="text-transform:uppercase"></asp:TextBox>
                            <asp:TextBox ID="Txt_AuxUsuario" runat="server"></asp:TextBox>
                            <asp:TextBox ID="Txt_AuxNomUsuario" runat="server"></asp:TextBox>
                            <asp:TextBox ID="Txt_AuxPrivilegio" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
  
                    <input id="txt_auxdiv" type="text" value="1"/>
                </div>
        </div>
        </div>


    <!--Modal Contraseña Incorrecta-->                 
   <div class="modal fade" id="myModal" role="dialog" data-backdrop="static"s>
    <div class="modal-dialog modal-sm">
      <div class="modal-content">
        <div class="modal-header">           

          <h3  class="modal-title" >Alta exitosa</h3>
            <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
            <center><img src="imagenes/ok.png" alt="Alternate Text" style="width:30%;height:auto;"/></center>
        </div>
        <div class="modal-body">
         <center>
          <h6>Contraseña Asignada:</h6>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lbl_clave" runat="server" Text="" Font-Bold="true" style="color:#000000"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
         </center>
        </div>
        <div class="modal-footer" style="margin-left: auto;margin-right: auto;">
         <center>
                    <a class="btn_siguiente" href="#" style="width:300px; height:60px; padding:7px;" onclick="ModalCerrar();" role="button">Aceptar</a>
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
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>

                  <asp:Label ID="Lbl_validar" runat="server" Text="" Visible="true" Style="color:#000000"></asp:Label>     
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
