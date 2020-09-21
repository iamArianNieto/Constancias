Imports System.Data.SqlClient

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
        Session("Contrasena") = Txt_Contrasena.Text
        If Validar() = True Then
            Try
                resultado = Contrasena.Constrasena(pass)
                If resultado = 1 Then
                    'Informacion de la conferencia
                    Dim Datoconferencia(4) As String
                    Session("Usuario") = Txt_Usuario.Text
                    Session("correo") = Txt_Correo.Text
                    Datoconferencia = Contrasena.TraerDatosConferencia(pass)
                    Session("Conferencia") = Datoconferencia(0)
                    Session("Ponente") = Datoconferencia(1)
                    Session("Fecha") = Datoconferencia(2)
                    Session("Hora") = Datoconferencia(3)
                    Session("Id_Conferencia") = Datoconferencia(4)
                    Conexion_Usuarios.conn.Close()
                    LlenaConstancia(Datoconferencia(4))
                    Response.Redirect("Frm_Evidencia.aspx")

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
    Protected Sub LlenaConstancia(ByRef Id_conferencia As String)
        Dim ID As String = ""
        Dim InsertaConstancias As New Cat_Constancias


        Conexion_Admin.cmd.CommandType = CommandType.Text
        Conexion_Admin.cmd.Connection = Conexion_Admin.conn
        Conexion_Admin.conn.Open()
        Conexion_Admin.sql = ""
        Conexion_Admin.sql = "select CONCAT('" & Id_conferencia & "-', ISNULL(count(Id_constancia),0) + 1) from Constancia where Id_conferencia= '" & Id_conferencia & "'"
        Conexion_Admin.cmd.CommandText = Conexion_Admin.sql
        Try
            Conexion_Admin.dr = Conexion_Admin.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Admin.dr.HasRows Then
                While Conexion_Admin.dr.Read()
                    ID = Conexion_Admin.dr(0).ToString
                    Session("Id_Constancia") = ID
                End While
                Conexion_Admin.conn.Close()
                SqlConnection.ClearPool(Conexion_Admin.conn)
                InsertaConstancias.InsertConstancia2(ID, Session("Id_Conferencia"), Session("Usuario"), Session("correo"))
            Else
                ID = ""
                Conexion_Admin.conn.Close()
                SqlConnection.ClearPool(Conexion_Admin.conn)
            End If
        Catch ex As Exception
            ex.ToString()
            Conexion_Admin.conn.Close()
            SqlConnection.ClearPool(Conexion_Admin.conn)
        End Try
        Conexion_Admin.conn.Close()
        SqlConnection.ClearPool(Conexion_Admin.conn)

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