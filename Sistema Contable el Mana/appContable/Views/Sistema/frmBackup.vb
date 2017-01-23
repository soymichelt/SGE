Imports System.IO
Imports appControllers

Public Class frmBackup

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Skin = MaterialSkin.MaterialSkinManager.Instance
        Skin.AddFormToManage(Me)
        Skin.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT
        Skin.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue600, MaterialSkin.Primary.Blue700, MaterialSkin.Primary.Blue300, MaterialSkin.Accent.LightBlue100, MaterialSkin.TextShade.WHITE)

    End Sub

    Sub RestoreList()
        Try
            dtRegistro.DataSource = BackUp.List()
            If dtRegistro.ColumnCount > 0 Then
                dtRegistro.Columns(0).Width = 120 : dtRegistro.Columns(0).HeaderText = vbNewLine & "Fecha" & vbNewLine
                dtRegistro.Columns(1).Width = 260 : dtRegistro.Columns(1).HeaderText = "Nombre del Archivo"
                dtRegistro.Columns(2).Width = 350 : dtRegistro.Columns(2).HeaderText = "Ubicación"
                For Each c As DataGridViewColumn In dtRegistro.Columns
                    c.HeaderText = c.HeaderText.ToUpper
                    c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                Next
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtPath.Text = BackUp.Path()
            If txtPath.Text.Trim <> "" Then
                btCrearRespaldo.Enabled = True
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
        Me.RestoreList()
    End Sub

    Private Sub btExaminar_Click(sender As Object, e As EventArgs) Handles btExaminar.Click
        Try
            
            If fdbExplorador.ShowDialog() = Windows.Forms.DialogResult.OK Then
                BackUp.SelectPath(fdbExplorador.SelectedPath)
                txtPath.Text = fdbExplorador.SelectedPath
                If Not btCrearRespaldo.Enabled Then
                    btCrearRespaldo.Enabled = True
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmBackup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btCrearRespaldo_Click(sender As Object, e As EventArgs) Handles btCrearRespaldo.Click
        Try
            BackUp.BackUpCreate(BackUp.Path())
            Config.MsgInfo("Respaldo creado satisfactoriamente.")
            Me.RestoreList()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btActualizar_Click(sender As Object, e As EventArgs) Handles btActualizar.Click
        Me.RestoreList()
    End Sub

    Private Async Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                frmRestore.txtQuery.Text = Await BackUp.Restore(dtRegistro.SelectedRows(0).Cells(1).Value.ToString())
                Config.OnLoadForm(frmRestore)
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
End Class