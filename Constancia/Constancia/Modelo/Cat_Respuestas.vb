Public Class Cat_Respuestas
    Public Sub Insertar(ByRef idconstancias As String, ByRef nopregunta As String, ByRef Respuesta As String, ByRef correo As String)
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "insert into Respuesta(Id_constancia,Id_pregunta,Respuesta)"
        Conexion_Ponencia.sql = Conexion_Ponencia.sql & "values('" & idconstancias & "','" & nopregunta & "','" & Respuesta & "') "
        Conexion_Ponencia.cmd.CommandText = Conexion_Ponencia.sql
        Try
            Conexion_Ponencia.cmd.ExecuteNonQuery()
        Catch ex As Exception
            If ex.ToString.Contains("valores duplicados") Then
            ElseIf ex.ToString.Contains("No coinciden los tipos de datos") Then
            Else
            End If
        End Try
        Conexion_Ponencia.conn.Close()

    End Sub
End Class
