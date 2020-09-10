Public Class Cat_Conferencia
    Public Sub Insertar(ByRef conferencia As String, ByRef Nombre_conferencia As String, ByRef Nombre_ponente As String, ByRef fecha As String, ByRef hora As String, ByRef Contrasena As String, ByRef usuario As String)
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "insert into Conferencia(Id_conferencia,Nombre_conferencia,Nombre_ponente,Fecha_conferencia,Horario,Contraseña,Numero_cuenta) "
        Conexion_Ponencia.sql = Conexion_Ponencia.sql & "values('" & conferencia & "','" & Nombre_conferencia & "','" & Nombre_ponente & "','" & fecha & "','" & hora & "','" & Contrasena & "','" & usuario & "') "
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

    Public Function get_ultimo_res()
        Dim Existe As String
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn
        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "select top 1 Id_conferencia from Conferencia order by Id_conferencia desc"
        Conexion_Ponencia.cmd.CommandText = Conexion_Ponencia.sql
        Try
            Conexion_Ponencia.dr = Conexion_Ponencia.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Ponencia.dr.HasRows Then
                While Conexion_Ponencia.dr.Read()
                    Existe = Conexion_Ponencia.dr(0)

                End While
                Conexion_Ponencia.conn.Close()
            Else
                Existe = "0"
                Conexion_Ponencia.conn.Close()
            End If
        Catch ex As Exception
            ' MsgBox("No se logro conectar a la base de datos", MsgBoxStyle.Critical, "Error: RegistroIncidentes::get_ultimo_res")
            Conexion_Ponencia.conn.Close()
        End Try
        Return Existe
    End Function


    Public Function ExisteFolio(ByRef id As String)
        Dim Existe As Integer = 0
        Conexion_Ponencia.conectarse()
        Conexion_Ponencia.cmd.CommandType = CommandType.Text
        Conexion_Ponencia.cmd.Connection = Conexion_Ponencia.conn

        Conexion_Ponencia.sql = ""
        Conexion_Ponencia.sql = "select count(*) as 'Existe' from Conferencia where Id_conferencia = '" & id & "'"

        Conexion_Ponencia.cmd.CommandText = Conexion_Ponencia.sql
        Try

            Conexion_Ponencia.dr = Conexion_Ponencia.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Ponencia.dr.HasRows Then
                While Conexion_Ponencia.dr.Read()
                    Existe = Convert.ToInt32(Conexion_Ponencia.dr(0))

                End While
                Conexion_Ponencia.conn.Close()
            Else
                Existe = 1 'Para evitar errores en la base de datos 
                Conexion_Ponencia.conn.Close()
            End If
        Catch ex As Exception
            'MsgBox("No se logro conectar a la base de datos", MsgBoxStyle.Critical, "Error: Color::ExisteColor")
            Conexion_Ponencia.conn.Close()
        End Try
        Return Existe
    End Function
End Class
