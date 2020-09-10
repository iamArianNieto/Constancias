Public Class Cat_Usuario
    Public Function LogearUsuario(ByRef usuario As String, ByRef contrasena As String)
        Conexion_Usuarios.conectarse()
        Dim Existe As Integer = 0

        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn

        Conexion_Usuarios.sql = ""
        Conexion_Usuarios.sql = "select count(*) as 'Total' from Usuario where Numero_cuenta = '" & usuario & "' and Contraseña = '" & contrasena & "' and Id_activo=2 "
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


    Public Function TraerDatosUsuario_Principal(ByRef usuario As String, ByRef pass As String)
        Conexion_Usuarios.conectarse()
        Dim Datos(2) As String

        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn
        Conexion_Usuarios.sql = ""
        Conexion_Usuarios.sql = "select concat(Nombre,' ',Ape_paterno,' ',Ape_materno) as 'Nombre',Id_privilegio,Numero_cuenta from Usuario where Numero_cuenta = '" & usuario & "' and Contraseña='" & pass & "' "
        Conexion_Usuarios.cmd.CommandText = Conexion_Usuarios.sql
        Try
            Conexion_Usuarios.dr = Conexion_Usuarios.cmd.ExecuteReader()
            'Existe algun campo
            If Conexion_Usuarios.dr.HasRows Then
                While Conexion_Usuarios.dr.Read()
                    Datos(0) = Conexion_Usuarios.dr(0).ToString
                    Datos(1) = Conexion_Usuarios.dr(1).ToString
                    Datos(2) = Conexion_Usuarios.dr(2).ToString

                End While

                Conexion_Usuarios.conn.Close()
            Else
                Datos(0) = ""
                Datos(1) = ""
                Datos(2) = ""

                Conexion_Usuarios.conn.Close()
            End If
        Catch ex As Exception
            ex.ToString()
            Conexion_Usuarios.conn.Close()
        End Try
        Conexion_Usuarios.conn.Close()
        Return Datos

    End Function


    Public Function TraerDatosUsuario(ByRef usuario As String)
        Conexion_Usuarios.conectarse()
        Dim Datos(5) As String
        Dim sql As String

        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn
        Conexion_Usuarios.sql = ""
        sql = ""
        sql = sql + "select Numero_cuenta, Contraseña, Nombre,Ape_Paterno,Ape_Materno, "
        sql = sql + "Id_activo "
        sql = sql + "from Usuario where Numero_cuenta='" & usuario & "' "
        sql = sql + "order by Numero_cuenta desc "
        Conexion_Usuarios.sql = sql
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
                    Datos(5) = Conexion_Usuarios.dr(5).ToString
                End While

                Conexion_Usuarios.conn.Close()
            Else
                Datos(0) = ""
                Datos(1) = ""
                Datos(2) = ""
                Datos(3) = ""
                Datos(4) = ""
                Datos(5) = ""
                Conexion_Usuarios.conn.Close()
            End If
        Catch ex As Exception
            ex.ToString()
            Conexion_Usuarios.conn.Close()
        End Try
        Conexion_Usuarios.conn.Close()
        Return Datos
    End Function


    Public Sub InsertarUsuario(ByRef Cuenta As String, ByRef Contraseña As String, ByRef Nombre As String, ByRef Ape_Paterno As String, ByRef Ape_Materno As String, ByRef activo As String)
        Conexion_Usuarios.conectarse()
        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn
        Conexion_Usuarios.sql = ""
        Conexion_Usuarios.sql = "insert into Usuario(Numero_cuenta,Contraseña,Nombre,Ape_Paterno,Ape_Materno,Id_activo) "
        Conexion_Usuarios.sql = Conexion_Usuarios.sql & "values('" & Cuenta & "','" & Contraseña & "','" & Nombre & "','" & Ape_Paterno & "','" & Ape_Materno & "'," & activo & ") "
        Conexion_Usuarios.cmd.CommandText = Conexion_Usuarios.sql
        Try
            Conexion_Usuarios.cmd.ExecuteNonQuery()
        Catch ex As Exception
            If ex.ToString.Contains("valores duplicados") Then
            ElseIf ex.ToString.Contains("No coinciden los tipos de datos") Then
            Else
            End If
        End Try
        Conexion_Usuarios.conn.Close()

    End Sub

    Public Sub EditarUsuario(ByRef cuenta As String, ByRef contraseña As String, ByRef nombre As String, ByRef ap As String, ByRef am As String, ByRef activo As String)
        Conexion_Usuarios.conectarse()
        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn
        Conexion_Usuarios.sql = ""
        Conexion_Usuarios.sql = "update Usuario set Numero_cuenta ='" & cuenta & "',Contraseña='" & contraseña & "',Nombre='" & nombre & "',Ape_Paterno='" & ap & "',Ape_Materno='" & am & "', "
        Conexion_Usuarios.sql = Conexion_Usuarios.sql & "Id_activo='" & activo & "' where Numero_cuenta ='" & cuenta & "' "
        Conexion_Usuarios.cmd.CommandText = Conexion_Usuarios.sql
        Try
            Conexion_Usuarios.cmd.ExecuteNonQuery()
        Catch ex As Exception
            If ex.ToString.Contains("valores duplicados") Then
            ElseIf ex.ToString.Contains("No coinciden los tipos de datos") Then
            Else
            End If
        End Try
        Conexion_Usuarios.conn.Close()
    End Sub

    Public Function ExisteUsuario(ByRef usuario As String)
        Conexion_Usuarios.conectarse()
        Dim Existe As Integer = 0

        Conexion_Usuarios.cmd.CommandType = CommandType.Text
        Conexion_Usuarios.cmd.Connection = Conexion_Usuarios.conn

        Conexion_Usuarios.sql = ""
        Conexion_Usuarios.sql = "select count(*) as 'Total' from Cat_Usuarios where Numero_cuenta = '" & usuario & "' " ' and Id_Activos=2 "
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

End Class
