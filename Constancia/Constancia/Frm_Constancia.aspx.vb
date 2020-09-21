Imports System.Data.SqlClient

Public Class Frm_Constancia
    Inherits System.Web.UI.Page
    Public datos(7), nombre As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            datos = Obtener_Datos(Session("Contrasena"))
            nombre = Obtener_Nombre(Session("Id_Constancia"))
            Lbl_Encabezado.Text = datos(0) & " " & datos(1)
            Lbl_Reconocimiento.Text = datos(2)
            Lbl_a.Text = datos(3)
            Lbl_Nombre.Text = nombre
            Lbl_Complemento.Text = datos(4) & " " & Session("Conferencia") & " " & datos(5) & " " & Session("Ponente") & " " & datos(6)
            'Lbl_Fecha.Text = datos(7)
            Lbl_Fecha.Text = Session("Fecha")
        End If
    End Sub

    Private Sub Img_Imprimir_Click(sender As Object, e As ImageClickEventArgs) Handles Img_Imprimir.Click
        datos = Obtener_Datos(Session("Contrasena"))
        nombre = Obtener_Nombre(Session("Id_Constancia"))
        Dim resumen As String = datos(4) + " " + Session("Conferencia") + datos(5) + " " + Session("Ponente") + " " + datos(6)

        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "generarPDF", "generarPDF('" & datos(0) & "', 
        '" & datos(1) & "', '" & datos(2) & "', '" & datos(3) & "', '" & nombre & "', '" & resumen & "', '" & datos(5) & "','" & Session("Ponente") & "',
        '" & datos(6) & "', '" & Session("Fecha") & "');", True)
    End Sub

    Private Sub Btn_Aux_Click(sender As Object, e As EventArgs) Handles Btn_Aux.Click
        Actualizar(Session("Id_Constancia"))
    End Sub


    Public Function Actualizar(ByRef IdC As String)
        Try
            Conexion_Admin.sql = "Update Constancia set Comentarios='" & Txt_Observaciones.Text & "' where Id_constancia='" & IdC & "'"
            Conexion_Admin.conectarse()
            Conexion_Admin.cmd = New SqlCommand(Conexion_Admin.sql, Conexion_Admin.conn)
            Conexion_Admin.cmd.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
            Conexion_Admin.conn.Close()
            SqlConnection.ClearPool(Conexion_Admin.conn)
        End Try
        Conexion_Admin.conn.Close()
        SqlConnection.ClearPool(Conexion_Admin.conn)

        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "cerrar()", "cerrar();", True)
    End Function

    Public Function Obtener_Datos(ByRef IdC As String)
        Conexion_Admin.conectarse()
        Dim Datos(7) As String

        Conexion_Admin.cmd.CommandType = CommandType.Text
        Conexion_Admin.cmd.Connection = Conexion_Admin.conn
        Conexion_Admin.sql = ""
        Conexion_Admin.sql = "select Encabezado1, Encabezado2, Reconocimiento,  A, Participacion, Conector, Fin, Fecha from Cat_Constancias where Contrasena='" & IdC & "'"
        Conexion_Admin.cmd.CommandText = Conexion_Admin.sql
        Try
            Conexion_Admin.dr = Conexion_Admin.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Admin.dr.HasRows Then
                While Conexion_Admin.dr.Read()
                    Datos(0) = Conexion_Admin.dr(0).ToString
                    Datos(1) = Conexion_Admin.dr(1).ToString
                    Datos(2) = Conexion_Admin.dr(2).ToString
                    Datos(3) = Conexion_Admin.dr(3).ToString
                    Datos(4) = Conexion_Admin.dr(4).ToString
                    Datos(5) = Conexion_Admin.dr(5).ToString
                    Datos(6) = Conexion_Admin.dr(6).ToString
                    Datos(7) = Conexion_Admin.dr(7).ToString
                End While

                Conexion_Admin.conn.Close()
                SqlConnection.ClearPool(Conexion_Admin.conn)
            Else
                Datos(0) = ""
                Datos(1) = ""
                Datos(2) = ""
                Datos(3) = ""
                Datos(4) = ""
                Datos(5) = ""
                Datos(6) = ""
                Datos(7) = ""
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
        Return Datos
    End Function

    Public Function Obtener_Nombre(ByRef IdC As String)
        Conexion_Admin.conectarse()
        Dim Datos As String

        Conexion_Admin.cmd.CommandType = CommandType.Text
        Conexion_Admin.cmd.Connection = Conexion_Admin.conn
        Conexion_Admin.sql = ""
        Conexion_Admin.sql = "select Nombre from Constancia where Id_constancia='" & IdC & "'"
        Conexion_Admin.cmd.CommandText = Conexion_Admin.sql
        Try
            Conexion_Admin.dr = Conexion_Admin.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Admin.dr.HasRows Then
                While Conexion_Admin.dr.Read()
                    Datos = Conexion_Admin.dr(0).ToString
                End While

                Conexion_Admin.conn.Close()
                SqlConnection.ClearPool(Conexion_Admin.conn)
            Else
                Datos = ""
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
        Return Datos
    End Function
End Class