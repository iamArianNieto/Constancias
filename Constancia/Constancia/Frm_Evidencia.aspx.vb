﻿Imports System.IO
Imports System
Imports System.Data
Imports System.Web.UI.WebControls

Public Class Frm_Evidencia
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            inicio()
            Dim conestancias As New Cat_Constancias


            Txt_auxCorreo.Text = Session("correo")
            Txt_idconferencia.Text = Session("Id_Conferencia")
            Txt_auxusuario.Text = Session("Usuario")
            'elPanel2.HorizontalAlign = HorizontalAlign.Left
            Rd_Fotografias.Checked = True

        End If
    End Sub

    Private Sub inicio()
        Rd_Fotografias.Checked = False
        Rd_Cuestionario.Checked = False
        ImBtn_Fotografia.ImageUrl = "img/fotografias.png"
        ImBtn_Cuestionario.ImageUrl = "img/cuestionario_desahabilitado.png"
        ImBtn_Cuestionario.Enabled = True
        ImBtn_Fotografia.Enabled = True
        GridView1.Visible = False

    End Sub

    Private Sub seleccion()

        If Rd_Fotografias.Checked = True Then
            Rd_Fotografias.Checked = True
            Rd_Cuestionario.Checked = False
            ImBtn_Fotografia.ImageUrl = "img/fotografias.png"
            ImBtn_Cuestionario.ImageUrl = "img/cuestionario_desahabilitado.png"
            Btn_subirFotografia.Visible = True
            GridView1.Visible = False
        ElseIf Rd_Cuestionario.Checked = True Then
            Rd_Fotografias.Checked = False
            Rd_Cuestionario.Checked = True
            ImBtn_Fotografia.ImageUrl = "img/fotografias_desahabilitado.png"
            ImBtn_Cuestionario.ImageUrl = "img/cuestionario.png"
            Btn_subirFotografia.Visible = False
            GridView1.Visible = True
            cargar_preguntas()
        Else
        End If
    End Sub


    Protected Sub Rd_Fotografias_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Fotografias.CheckedChanged
        seleccion()
    End Sub

    Protected Sub Rd_Cuestionario_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_Cuestionario.CheckedChanged
        seleccion()
    End Sub

    Private Function ValidarArchivos()
        Dim resultado As Boolean = True

        If FileUp.HasFiles Then
            resultado = True
        Else
            resultado = False
        End If

        Return resultado
    End Function

    Private Function CopiarArchivo(ByRef folio As Integer)

        Dim folderPath As String = Server.MapPath("~/Archivos/" & folio)

        'Si no exite carpeta la crea
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)

        End If

        'Revisar si existe un archivo para copiarlo
        If FileUp.HasFiles Then
            Try
                Dim getFileName As String

                For i = 0 To FileUp.PostedFiles.Count - 1
                    Dim htfiles As HttpPostedFile = FileUp.PostedFiles(i)
                    getFileName = Path.GetFileName(htfiles.FileName)
                    Dim ext = htfiles.ContentType


                    Dim noarchivo As Integer = 0
                    Dim archivo As String = folio & "_" & noarchivo



                    'verifica si existe archivos en el directorio sino obtniene el ultimo registro
                    Do While ((File.Exists(folderPath & "/" & archivo & ".png")) Or (File.Exists(folderPath & "/" & archivo & ".jpg")) Or (File.Exists(folderPath & "/" & archivo & ".pdf")) Or (File.Exists(folderPath & "/" & archivo & ".doc")) Or (File.Exists(folderPath & "/" & archivo & ".docx")) Or (File.Exists(folderPath & "/" & archivo & ".dotx")) Or (File.Exists(folderPath & "/" & archivo & ".docm")) Or (File.Exists(folderPath & "/" & archivo & ".dotm")))
                        noarchivo = noarchivo + 1
                        archivo = ""
                        archivo = folio & "_" & noarchivo
                    Loop

                    If htfiles.ContentLength > 8000000 Then 'Archivo en bytes  '20 MB
                        lblValidacion.Text = "El archivo " & getFileName & " es muy pesado"
                        'Lbl_Grabacion.ForeColor = System.Drawing.Color.Red
                        lblValidacion.ForeColor = System.Drawing.Color.Red
                        Return "ERROR"
                        'No se guarda la informacion solo muestra el archivo que no se podra guardar
                    Else
                        If ext = "image/png" Or ext = "image/jpeg" Or ext = "application/pdf" Or ext = "application/msword" Or ext = "application/vnd.openxmlformats-officedocument.wordprocessingml.document" Or ext = "application/vnd.openxmlformats-officedocument.wordprocessingml.template" Or ext = "application/vnd.ms-word.document.macroEnabled.12" Or ext = "application/vnd.ms-word.template.macroEnabled.12" Then
                            ' htfiles.SaveAs(folderPath & "/" & getFileName)
                            If ext = "image/png" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".png")
                            ElseIf ext = "image/jpeg" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".jpg")
                            ElseIf ext = "application/pdf" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".pdf")
                            ElseIf ext = "application/msword" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".doc")
                            ElseIf ext = "application/vnd.openxmlformats-officedocument.wordprocessingml.document" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".docx")
                            ElseIf ext = "application/vnd.openxmlformats-officedocument.wordprocessingml.template" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".dotx")
                            ElseIf ext = "application/vnd.ms-word.document.macroEnabled.12" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".docm")
                            ElseIf ext = "application/vnd.ms-excel" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xls")
                            ElseIf ext = "application/vnd.ms-excel" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xlt")
                            ElseIf ext = "application/vnd.ms-excel" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xla")
                            ElseIf ext = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xlsx")
                            ElseIf ext = "application/vnd.openxmlformats-officedocument.spreadsheetml.template" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xltx")
                            ElseIf ext = "application/vnd.ms-excel.sheet.macroEnabled.12" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xlsm")
                            ElseIf ext = "application/vnd.ms-excel.template.macroEnabled.12" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xltm")
                            ElseIf ext = "application/vnd.ms-excel.addin.macroEnabled.12" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xlam")
                            ElseIf ext = "application/vnd.ms-excel.sheet.binary.macroEnabled.12" Then
                                htfiles.SaveAs(folderPath & "/" & archivo & ".xlsb")
                            Else

                            End If


                        Else
                            lblValidacion.Text = "El archivo " & getFileName & " no tiene el formato correcto"
                            lblValidacion.ForeColor = System.Drawing.Color.Red
                            Return "ERROR"
                            'No se guarda la informacion solo muestra el archivo que no se podra guardar
                        End If
                    End If

                Next
                'btnGrabacion.SaveAs(folderPath & "/" & Path.GetFileName(btnGrabacion.FileName))

            Catch ex As Exception

                lblValidacion.Text = "Los archivos no se lograron subir"
                lblValidacion.ForeColor = System.Drawing.Color.Red
                Return "ERROR"

            End Try

        End If
        Return folderPath

    End Function

    Private Sub cargar_preguntas()
        Dim conferencia As New Cat_Conferencia
        Dim dt As DataTable
        dt = conferencia.Traer_Conferencia(Txt_idconferencia.Text)
        Dim contador As Integer = 1

        Dim resultado As String = ""
        Dim label As Label
        Dim txt_pregunta As TextBox
        For Each row As DataRow In dt.Rows
            'label = New Label
            'label.ID = "lbl_pregunta" & contador
            'label.Text = contador & "." & row("Pregunta")
            'label.Font.Bold = True
            'label.Width = Unit.Percentage(100)
            'elPanel2.Controls.Add(label)
            'txt_pregunta = New TextBox
            'txt_pregunta.Width = Unit.Percentage(100)
            'txt_pregunta.ID = "txt_pregunta" & contador

            ''txt_pregunta(contador_com).AutoPostBack = True
            'elPanel2.Controls.Add(txt_pregunta)
            contador = contador + 1
        Next



    End Sub



    Private Sub guardar()
        Dim conferencia As New Cat_Conferencia
        Dim respuestas As New Cat_Respuestas
        Dim constancias As New Cat_Constancias
        Dim contador As Integer = 1
        Dim usuario As New Cat_Usuario

        GridView1.Visible = True
        Dim dt1 As DataTable = New DataTable()
        Dim row As DataRow = dt1.NewRow()
        'Dim nombreusuario As String = usuario.TraerNombreUsuario(Txt_auxusuario.Text)
        Dim auxnumconstancia As Integer = 1
        Dim constanciaaux As String = Txt_idconferencia.Text & "-" & auxnumconstancia.ToString()

        Do While constancias.Existe_idconstancias(constanciaaux) = 1
            auxnumconstancia = auxnumconstancia + 1
            constanciaaux = Txt_idconferencia.Text & "-" & auxnumconstancia.ToString()
        Loop
        constancias.InsertConstancia(constanciaaux, Txt_idconferencia.Text, Txt_auxusuario.Text, Txt_auxCorreo.Text, "1", "0")

        Session("Id_Constancia") = constanciaaux
        'Session("Id_Constancia") = no_constancias
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim txtUsrId As TextBox = CType(GridView1.Rows(i).FindControl("Txt_Respuesta"), TextBox)
            Dim UserID As String = txtUsrId.Text

            respuestas.Insertar(constanciaaux, contador, UserID, Txt_auxCorreo.Text)
            contador = contador + 1
        Next


    End Sub

    Private Function validar()
        Dim resultado As Boolean = False


        resultado = True



            Return resultado
    End Function




    Private Sub subir_archivo()
        If ValidarArchivos() = True Then
            Dim res As String = CopiarArchivo(Convert.ToUInt32(Txt_idconferencia.Text)).ToString()
            If res = "ERROR" Then
                lblValidacion.Text = "No se agregaron archivos ni respuestas"
                ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)
                Exit Sub
            End If
            Dim constancias As New Cat_Constancias
            Dim usuario As New Cat_Usuario

            'Dim nombreusuario As String = usuario.TraerNombreUsuario(Txt_auxusuario.Text)


            Dim auxnumconstancia As Integer = 1
            Dim constanciaaux As String = Txt_idconferencia.Text & "-" & auxnumconstancia.ToString()

            Do While constancias.Existe_idconstancias(constanciaaux) = 1
                auxnumconstancia = auxnumconstancia + 1
                constanciaaux = Txt_idconferencia.Text & "-" & auxnumconstancia.ToString()
            Loop
            constancias.InsertConstancia(constanciaaux, Txt_idconferencia.Text, Txt_auxusuario.Text, Txt_auxCorreo.Text, "0", "1")



            inicio()
            lblValidacion.Text = "Archivo cargado con éxito."
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)
        Else
            lblValidacion.Text = "No hay archivo agregado"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)

        End If
    End Sub

    Private Sub guardar_correspondencia()
        guardar()
        lblValidacion.Text = "Respuesta exitosa."
        inicio()
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)

    End Sub

    Protected Sub Btn_Siguiente_Click(sender As Object, e As EventArgs) Handles Btn_Siguiente.Click
        If Rd_Fotografias.Checked = True Then
            subir_archivo()
        ElseIf Rd_Cuestionario.Checked = True Then
            guardar_correspondencia()

        Else
            lblValidacion.Text = "Seleccione si desea subir archivo o contestar cuestionario"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)

        End If
    End Sub

    Protected Sub ImBtn_Fotografia_Click(sender As Object, e As ImageClickEventArgs) Handles ImBtn_Fotografia.Click
        Rd_Cuestionario.Checked = False
        Rd_Fotografias.Checked = True
        seleccion()
    End Sub

    Private Sub ImBtn_Cuestionario_Click(sender As Object, e As ImageClickEventArgs) Handles ImBtn_Cuestionario.Click
        Rd_Fotografias.Checked = False
        Rd_Cuestionario.Checked = True
        seleccion()
    End Sub

    Protected Sub Btn_subirFotografia_Click(sender As Object, e As EventArgs) Handles Btn_subirFotografia.Click
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "fn_cargar", "fn_cargar();", True)

    End Sub
End Class