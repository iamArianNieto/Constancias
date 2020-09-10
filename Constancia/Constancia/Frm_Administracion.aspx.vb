Public Class Frm_Administracion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Response.AppendHeader("Cache-Control", "no-store")
            Txt_AuxUsuario.Text = Session("Nombre")
            Txt_AuxNomUsuario.Text = Session("Nombre")
            Txt_AuxPrivilegio.Text = Session("Privilegio")

        End If
    End Sub

    Protected Sub Btn_Terminar_Click(sender As Object, e As EventArgs) Handles Btn_Terminar.Click
        If validar() = True Then

            obtenerpreguntas()


        Else
            Lbl_validar.Text = "Llena los datos"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)

        End If
    End Sub

    Private Sub guardar()
        Dim res As String = Txt_GenerarCadena.Text
        Dim auxcon As Integer = 1
        Dim delimitadores As String = "¥"
        Dim vectoraux = res.Split(delimitadores)
        Dim id As String = ""

        'agregar conferencia
        id = AgregarConferencia()

        For Each item As String In vectoraux
            If item <> "" Then
                'MsgBox(auxcon & ". " & item)
                'agregar cuestionario
                AgregarPreguntas(auxcon, item, id)
                auxcon = auxcon + 1
            End If
        Next
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "Modal", "Modal()", True)


    End Sub


    Protected Sub Btn_Generarcadena_Click(sender As Object, e As EventArgs) Handles Btn_Generarcadena.Click
        guardar()
    End Sub

    Private Function AgregarConferencia()
        Dim id As String = ""
        Dim conferencia As New Cat_Conferencia
        Dim aux_id As Integer = Convert.ToInt32(conferencia.get_ultimo_res())
        Dim pass As String = Crearcontrasena(8)

        Do While conferencia.ExisteFolio(aux_id) = 1
            aux_id = aux_id + 1
        Loop

        conferencia.Insertar(aux_id, Txt_Conferencia.Text.ToUpper(), Txt_Ponente.Text.ToUpper(), Txt_Fecha.Text, Txt_Hora.Text, pass, Txt_AuxUsuario.Text)

        id = aux_id.ToString()
        lbl_clave.Text = pass

        Return id
    End Function

    Private Function Crearcontrasena(ByRef longitud As Integer)
        Dim caracteres As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim res As StringBuilder = New StringBuilder()
        Dim md As Random = New Random()
        Do While 0 < longitud
            res.Append(caracteres(md.Next(caracteres.Length)))
        Loop

        Return res.ToString()
    End Function

    Private Sub AgregarPreguntas(ByRef no As String, ByRef pregunta As String, ByRef id As String)
        Dim cuestionario As New Cat_Cuestionario
        cuestionario.Insertar(no, pregunta, id)
    End Sub


    Private Function validar()
        Dim resultado As Boolean = False

        If Txt_Ponente.Text.Length() = 0 Then
            Lbl_validar.Text = "Escriba el nombre del ponente"
            resultado = False
        ElseIf Txt_Conferencia.Text.Length() = 0 Then
            Lbl_validar.Text = "Escriba el nombre de la conferencia"
            resultado = False
        ElseIf Txt_Hora.Text.Length() = 0 Then
            Lbl_validar.Text = "Seleccione una hora"
            resultado = False
        ElseIf Txt_Fecha.Text.Length() = 0 Then
            Lbl_validar.Text = "Seleccione una fecha"
            resultado = False
        Else
            resultado = True
        End If

        Return resultado
    End Function

    Private Sub obtenerpreguntas()
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "generacadena", "generacadena();", True)

    End Sub

End Class