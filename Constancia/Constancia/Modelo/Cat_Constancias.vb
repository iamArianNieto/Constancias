Public Class Cat_Constancias
    Public Function InsertConstancia(ByRef Id_constancia As String, ByRef Id_conferencia As String, ByRef Nombre As String, ByRef correo As String, ByRef pregunta As String, ByRef img As String)
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "INSERT INTO [dbo].[Constancia] ([Id_constancia],[Id_conferencia],[Nombre],[Correo],[Id_pregunta],[Imagen]) "
        Conexion_Ponencia.sql = Conexion_Ponencia.sql & "values('" & Id_constancia & "','" & Id_conferencia & "','" & Nombre & "','" & correo & "','" & pregunta & "','" & img & "') "
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
        Return True
    End Function


    Public Function InsertConstancia2(ByRef Id_constancia As String, ByRef Id_conferencia As String, ByRef Nombre As String, ByRef correo As String)
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "INSERT INTO [dbo].[Constancia] ([Id_constancia],[Id_conferencia],[Nombre],[Correo],[Id_pregunta]) "
        Conexion_Ponencia.sql = Conexion_Ponencia.sql & "values('" & Id_constancia & "','" & Id_conferencia & "','" & Nombre & "','" & correo & "') "
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
        Return True
    End Function

    Public Function Existe_idconstancias(ByRef conferencia As String)
        Conexion_Ponencia.conectarse()
        Dim Datos As String

        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "select count(*) from Constancia where Id_constancia = '" & conferencia & "' "
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
                Datos = "0"

                Conexion_Ponencia.conn.Close()
            End If
        Catch ex As Exception
            ex.ToString()
            Conexion_Ponencia.conn.Close()
        End Try
        Conexion_Ponencia.conn.Close()
        Return Datos
    End Function



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

    Public Function LlenarCatCostancia(ByRef Contrasena As String)
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "INSERT INTO Cat_Constancias (Contrasena) "
        Conexion_Ponencia.sql = Conexion_Ponencia.sql & "values('" & Contrasena & "') "
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
        Return True


    End Function
End Class
