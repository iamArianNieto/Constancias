Imports System.IO

Public Class Frm_Evidencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            inicio()
            Txt_idconferencia.Text = Session("Id_Conferencia")
            Txt_auxusuario.Text = Session("Usuario")

        End If
    End Sub

    Private Sub inicio()
        Rd_Fotografias.Checked = False
        Rd_Cuestionario.Checked = False
        ImBtn_Fotografia.ImageUrl = "img/fotografias_desahabilitado.png"
        ImBtn_Cuestionario.ImageUrl = "img/cuestionario_desahabilitado.png"
        ImBtn_Cuestionario.Enabled = False
        ImBtn_Fotografia.Enabled = False
        FileUp.Visible = False
    End Sub

    Private Sub seleccion()
        If Rd_Fotografias.Checked = True Then
            Rd_Fotografias.Checked = True
            Rd_Cuestionario.Checked = False
            ImBtn_Fotografia.ImageUrl = "img/fotografias.png"
            ImBtn_Cuestionario.ImageUrl = "img/cuestionario_desahabilitado.png"
            FileUp.Visible = True
        ElseIf Rd_Cuestionario.Checked = True Then
            Rd_Fotografias.Checked = False
            Rd_Cuestionario.Checked = True
            ImBtn_Fotografia.ImageUrl = "img/fotografias_desahabilitado.png"
            ImBtn_Cuestionario.ImageUrl = "img/cuestionario.png"
            FileUp.Visible = False
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

        For Each row As DataRow In dt.Rows
            resultado = resultado & "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>"
            resultado = resultado & "<h6 id='Lblpregunta" & contador & "' style='width:100%;'>" & row("Pregunta") & "</h6>"
            resultado = resultado + "<input id='Pregunta" & contador & "' required type='text' style='width:100%;text-transform:uppercase'/>"
            resultado = resultado & "</div>"
            contador = contador + 1
        Next


        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "MuestraRes", "MuestraRes('" & resultado & "')", True)



    End Sub


    Private Function validar()
        Dim resultado As Boolean = False

        If ValidarArchivos() = False Then
            lblValidacion.Text = "No se agregaron archivos"
            resultado = False
        ElseIf Txt_GenerarCadena.Text.Length = 0 Then
            lblValidacion.Text = "Ingrese las respuestas"
            resultado = False
        Else
            resultado = True
        End If


        Return resultado
    End Function

    Private Sub guardar()
        Dim respuestas As New Cat_Respuestas
        Dim res As String = Txt_GenerarCadena.Text.ToUpper()
        Dim auxcon As Integer = 1
        Dim delimitadores As String = "¥"
        Dim vectoraux = res.Split(delimitadores)

        For Each item As String In vectoraux
            If item <> "" Then
                'MsgBox(auxcon & ". " & item)
                'agregar cuestionario
                respuestas.Insertar(Txt_idconferencia.Text, auxcon, item)
                auxcon = auxcon + 1
            End If
        Next


    End Sub



    Protected Sub Btn_Siguiente_Click(sender As Object, e As EventArgs) Handles Btn_Siguiente.Click
        If validar() = True Then
            Dim res As String = CopiarArchivo(Convert.ToUInt32(Txt_idconferencia.Text)).ToString()
            If res = "ERROR" Then
                lblValidacion.Text = "No se agregaron archivos ni respuestas"
                ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)
                Exit Sub
            End If
            guardar()

        Else
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "ModalDatos", "ModalDatos()", True)

        End If
    End Sub
End Class