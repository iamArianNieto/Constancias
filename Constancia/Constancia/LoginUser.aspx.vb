Public Class LoginAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.AppendHeader("Cache-Control", "no-store")
        End If
    End Sub

    Private Sub Btn_Ingresar_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar.Click
        Dim Contrasena As New Conferencia
        Dim usuario As String
        Dim pass As String
        Dim resultado As Integer

        usuario = Txt_Usuario.Text
        pass = Txt_Contrasena.Text

        If validar() = True Then
            Try
                resultado = Contrasena.Constrasena(pass)
                If resultado = 1 Then
                    'Informacion de la conferencia
                    Dim Datoconferencia(4) As String
                    Datoconferencia = Contrasena.TraerDatosConferencia(pass)
                    Session("Conferencia") = Datoconferencia(0)
                    Session("Ponente") = Datoconferencia(1)
                    Session("Fecha") = Datoconferencia(2)
                    Session("Hora") = Datoconferencia(3)
                    Session("Id_Conferencia") = Datoconferencia(4)
                    Conexion_Usuarios.conn.Close()
                    Response.Redirect("Frm_Evidencias.aspx")

                Else
                    Borrar()
                    Conexion_Usuarios.conn.Close()
                    ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalContrasenaIncorrecta", "ModalContrasenaIncorrecta()", True)

                End If
            Catch ex As Exception
                ex.ToString()
                Conexion_Usuarios.conn.Close()
            End Try
        Else
            Borrar()
            Conexion_Usuarios.conn.Close()
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)

        End If
    End Sub

    Private Function Validar()
        Dim Resultado As Boolean = False
        If Txt_Usuario.Text = "" And Txt_Contrasena.Text = "" And Txt_Correo.Text = "" Then
            Lbl_validar.Visible = True
            Lbl_validar.Text = "Por favor ingrese su Nombre, Correo y Contraseña"
            Resultado = False
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatosIncompletos", "ModalDatosIncompletos()", True)

        ElseIf Txt_Usuario.Text = "" And Txt_Contrasena.Text <> "" And Txt_Correo.Text <> "" Then
            Lbl_validar.Visible = True
            Lbl_validar.Text = "Por favor ingrese su Nombre"
            Resultado = False
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatosIncompletos", "ModalDatosIncompletos()", True)

        ElseIf Txt_Contrasena.Text = "" And Txt_Correo.Text <> "" And Txt_Usuario.Text <> "" Then
            Lbl_validar.Visible = True
            Lbl_validar.Text = "Por favor ingrese su Contraseña"
            Resultado = False
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatosIncompletos", "ModalDatosIncompletos()", True)

        ElseIf Txt_Correo.Text = "" And Txt_Usuario.Text <> "" And Txt_Contrasena.Text <> "" Then
            Lbl_validar.Visible = True
            Lbl_validar.Text = "Por favor ingrese su Correo"
            Resultado = False
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatosIncompletos", "ModalDatosIncompletos()", True)

        ElseIf Txt_Usuario.Text = "" And Txt_Contrasena.Text = "" And Txt_Correo.Text <> "" Then
            Lbl_validar.Visible = True
            Lbl_validar.Text = "Por favor ingrese su Nombre y Contraseña"
            Resultado = False
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatosIncompletos", "ModalDatosIncompletos()", True)

        ElseIf Txt_Usuario.Text = "" And Txt_Correo.Text = "" And Txt_Contrasena.Text <> "" Then
            Lbl_validar.Visible = True
            Lbl_validar.Text = "Por favor ingrese su Nombre y Correo"
            Resultado = False
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatosIncompletos", "ModalDatosIncompletos()", True)

        ElseIf Txt_Correo.Text = "" And Txt_Contrasena.Text = "" And Txt_Usuario.Text <> "" Then
            Lbl_validar.Visible = True
            Lbl_validar.Text = "Por favor ingrese su Contraseña y Correo"
            Resultado = False
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatosIncompletos", "ModalDatosIncompletos()", True)
        Else
            Resultado = True
        End If
        Return Resultado
    End Function

    Private Sub Borrar()
        Txt_Usuario.Text = ""
        Txt_Contrasena.Text = ""
    End Sub
End Class