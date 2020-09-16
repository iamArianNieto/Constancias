Public Class Cat_Constancias
    Public Function Traer_idconstancias(ByRef conferencia As String)
        Conexion_Ponencia.conectarse()
        Dim Datos As String

        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "select Id_constancia from Constancia where Id_conferencia = '" & conferencia & "' "
        Conexion_Ponencia.cmd.CommandText = Conexion_Ponencia.sql
        Try
            Conexion_Ponencia.dr = Conexion_Ponencia.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Ponencia.dr.HasRows Then
                While Conexion_Ponencia.dr.Read()
                    Datos = Conexion_Ponencia.dr(0).ToString

                End While

                Conexion_Ponencia.conn.Close()
            Else
                Datos = ""

                Conexion_Ponencia.conn.Close()
            End If
        Catch ex As Exception
            ex.ToString()
            Conexion_Ponencia.conn.Close()
        End Try
        Conexion_Ponencia.conn.Close()
        Return Datos
    End Function

    Public Function Traer_correo(ByRef conferencia As String)
        Conexion_Ponencia.conectarse()
        Dim Datos As String

        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "select correo from Constancia where Id_conferencia = '" & conferencia & "' "
        Conexion_Ponencia.cmd.CommandText = Conexion_Ponencia.sql
        Try
            Conexion_Ponencia.dr = Conexion_Ponencia.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Ponencia.dr.HasRows Then
                While Conexion_Ponencia.dr.Read()
                    Datos = Conexion_Ponencia.dr(0).ToString

                End While

                Conexion_Ponencia.conn.Close()
            Else
                Datos = ""

                Conexion_Ponencia.conn.Close()
            End If
        Catch ex As Exception
            ex.ToString()
            Conexion_Ponencia.conn.Close()
        End Try
        Conexion_Ponencia.conn.Close()
        Return Datos
    End Function
End Class
