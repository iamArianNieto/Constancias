Public Class Conferencia
    Public Function Constrasena(ByRef contrasena As String)
        Conexion_Usuarios.conectarse()
        Dim Existe As Integer = 0

        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn

        Conexion_Usuarios.sql = ""
        Conexion_Usuarios.sql = "select count(*) as 'Total' from Conferencia where Contraseña = '" & contrasena & "'"
        Conexion_Usuarios.cmd.CommandText = Conexion_Usuarios.sql
        Try
            Conexion_Usuarios.conectarse()
            Conexion_Usuarios.dr = Conexion_Usuarios.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Usuarios.dr.HasRows Then
                While Conexion_Usuarios.dr.Read()
                    Existe = Convert.ToInt32(Conexion_Usuarios.dr(0))

                End While
                Conexion_Usuarios.conn.Close()
            Else
                Existe = 0
                Conexion_Usuarios.conn.Close()
            End If


        Catch ex As Exception
            Conexion_Usuarios.conn.Close()
        End Try
        Return Existe
    End Function
    Public Function TraerDatosConferencia(ByRef pass As String)
        Conexion_Usuarios.conectarse()
        Dim Datos(5) As String

        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn
        Conexion_Usuarios.sql = ""
        Conexion_Usuarios.sql = "SET LANGUAGE 'español' select Nombre_conferencia,Nombre_ponente, "
        Conexion_Usuarios.sql = Conexion_Usuarios.sql + "(DATENAME(DD,Fecha_conferencia) + ' de ' +DATENAME(mm,Fecha_conferencia) + ' de ' + DATENAME(yyyy, Fecha_conferencia)) AS Fecha,Horario,Id_conferencia from Conferencia where Contraseña='" & pass & "'  "
        Conexion_Usuarios.cmd.CommandText = Conexion_Usuarios.sql
        Try
            Conexion_Usuarios.dr = Conexion_Usuarios.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Usuarios.dr.HasRows Then
                While Conexion_Usuarios.dr.Read()
                    Datos(0) = Conexion_Usuarios.dr(0).ToString
                    Datos(1) = Conexion_Usuarios.dr(1).ToString
                    Datos(2) = Conexion_Usuarios.dr(2).ToString
                    Datos(3) = Conexion_Usuarios.dr(3).ToString
                    Datos(4) = Conexion_Usuarios.dr(4).ToString
                End While

                Conexion_Usuarios.conn.Close()
            Else
                Datos(0) = ""
                Datos(1) = ""
                Datos(2) = ""
                Datos(3) = ""
                Conexion_Usuarios.conn.Close()
            End If
        Catch ex As Exception
            ex.ToString()
            Conexion_Usuarios.conn.Close()
        End Try
        Conexion_Usuarios.conn.Close()
        Return Datos
    End Function

End Class
