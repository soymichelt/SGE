Module Config

    'Nombre de Archivo de Backup
    Public ExplorerBackup As String = "ebu.sce"

    'Mensaje
    Public Sub MsgInfo(ByVal Msg As String)
        System.Windows.Forms.MessageBox.Show(Msg, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Sub MsgAdv(ByVal Msg As String)
        System.Windows.Forms.MessageBox.Show("Advertencia: " & Msg, "Advertencia! Mensaje de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Public Sub MsgErr(ByVal Msg As String)
        System.Windows.Forms.MessageBox.Show("Error: " & Msg, "Error! Mensaje de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public BusinessName As String = "VETERINARIA ""LA ECONÓMICA"""
    Public BusinessAddress As String = "Ciudad Rama, frente al Colegio Nuestra Señora de Fatima"
    Public BusinessRUC As String = "1211406630002J"
    Public BusinessPhone1 As String = "8840-3000"
    Public BusinessPhone2 As String = "8624-8024"

    Public fn As String = "0###"
    Public fm As String = "#,##0.00"

    Public Nivel As Integer = 6

    Public FechaInicio As DateTime = "01/01/2016 00:00:00"

    Public PerStart As DateTime = "01/01/2016 00:00:00"
    Public perFinal As DateTime = DateTime.MaxValue

    'Usuario
    Public Property User As appModels.UserAccount

    'Cerrar
    Public Sub ExitApplication()
        Application.Exit()
    End Sub

    Public Sub LoginInit()
        frmSignin.Show()
        For Each c As Form In Application.OpenForms
            If c.Name <> "frmSignin" Then
                c.Dispose()
            End If
        Next
    End Sub

    Public Sub CrystalTitle(ByVal Title As String, ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim txtob As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.ReportObjects("txtTitulo")
        txtob.Text = "SISTEMA DE CONTABILIDAD EMPRESARIAL - EL MANÁ" & vbNewLine & Config.BusinessName & vbNewLine & Title
        txtob = Nothing
    End Sub

    'Llamadas de Formulario
    Public Sub OnLoadForm(ByVal frm As Form, Optional ByVal Mdi As Form = Nothing)
        If Not Mdi Is Nothing Then
            frm.MdiParent = Mdi
            frm.BringToFront()
            frm.Show()
        Else
            frm.ShowDialog()
        End If
    End Sub

    'Codigo predefinidos
    Public ctActivo As String = "1"
    Public ctPasivo As String = "2"
    Public ctCapital As String = "3"
    Public ctIngreso As String = "4"
    Public ctCosto As String = "5"
    Public ctGasto As String = "6"
    Public ctIngresoFinanciero As String = "7"


    'validar contraseña
    Public Function ValidatePass(ByVal Text As String) As Boolean
        If Text.Length < 8 Then
            Return False
        End If
        Dim bC = False, bM = False, bN As Boolean = False
        For Each c In Text.ToCharArray()
            If Char.IsUpper(c) Then
                bM = True
            End If
            If Char.IsNumber(c) Then
                bN = True
            End If
            If Char.IsSymbol(c) Or Char.IsPunctuation(c) Then
                bC = True
            End If
        Next
        If bC And bM And bN Then
            Return True
        Else
            Return False
        End If
    End Function


End Module