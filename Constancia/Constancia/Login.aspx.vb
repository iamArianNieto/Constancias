Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Response.AppendHeader("Cache-Control", "no-store")
        End If
    End Sub



    Private Function Validar()
        Dim Resultado As Boolean = False
        If Txt_Usuario.Text = "" And Txt_Contraseña.Text = "" Then
            Lbl_Validar.Visible = True
            Lbl_Validar.Text = "Escriba su Usuario y Contraseña"
            Resultado = False

        ElseIf Txt_Usuario.Text = "" Then
            Lbl_Validar.Visible = True
            Lbl_Validar.Text = "Escriba su Usuario"
            Resultado = False
        ElseIf Txt_Contraseña.Text = "" Then
            Lbl_Validar.Visible = True
            Lbl_Validar.Text = "Escriba su Contraseña"
            Resultado = False
        Else
            Resultado = True
        End If
        Return Resultado
    End Function

    Private Sub Borrar()
        Txt_Usuario.Text = ""
        Txt_Contraseña.Text = ""
    End Sub

    Private Sub btn_Ingresar_Click(sender As Object, e As EventArgs) Handles btn_Ingresar.Click
        Dim Usuarios As New Cat_Usuario
        Dim usuario As String
        Dim pass As String
        Dim resultado As Integer

        usuario = Txt_Usuario.Text.ToUpper()
        pass = Txt_Contraseña.Text

        If Validar() = True Then
            Try
                resultado = Usuarios.LogearUsuario(usuario, pass)
                If resultado = 1 Then

                    'Informacion de el usuario
                    Dim user(4) As String
                    user = Usuarios.TraerDatosUsuario_Principal(usuario, pass)

                    'Informacion de el catalogo de activos
                    Session("Nombre") = user(0)
                    Session("Privilegio") = user(1)
                    Session("Usuario") = user(2)
                    Conexion_Usuarios.conn.Close()
                    Response.Redirect("Frm_Administracion.aspx")

                Else

                    Lbl_Validar.Visible = True
                    Lbl_Validar.Text = "Usuario o la Contraseña no se encontraron"
                    Borrar()
                    Conexion_Usuarios.conn.Close()
                    ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalContrasenaIncorrecta", "ModalContrasenaIncorrecta()", True)

                End If
            Catch ex As Exception
                ex.ToString()
                Lbl_validar.Text = ex.ToString()
                Conexion_Usuarios.conn.Close()
                ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalContrasenaIncorrecta", "ModalContrasenaIncorrecta()", True)

            End Try
        Else
            Borrar()
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalContrasenaIncorrecta", "ModalContrasenaIncorrecta()", True)

        End If
    End Sub
End Class