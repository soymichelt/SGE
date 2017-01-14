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

    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtPath.Text = BackUp.Path()
            If txtPath.Text.Trim <> "" Then
                btCrearRespaldo.Enabled = False
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btExaminar_Click(sender As Object, e As EventArgs) Handles btExaminar.Click
        Try
            
            If fdbExplorador.ShowDialog() = Windows.Forms.DialogResult.OK Then
                BackUp.UpdatePath(fdbExplorador.SelectedPath)
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

        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
End Class