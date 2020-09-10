Public Class Cat_Cuestionario
    Public Sub Insertar(ByRef no As String, ByRef pregunta As String, ByRef conferencia As String)
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "insert into Cuestionario(Id_pregunta,Pregunta,id_conferencia) "
        Conexion_Ponencia.sql = Conexion_Ponencia.sql & "values('" & no & "','" & pregunta & "','" & conferencia & "') "
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
