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
        Skin.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.DeepOrange800, MaterialSkin.Primary.DeepOrange900, MaterialSkin.Primary.DeepOrange500, MaterialSkin.Accent.DeepPurple200, MaterialSkin.TextShade.WHITE)

    End Sub

    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btExaminar_Click(sender As Object, e As EventArgs) Handles btExaminar.Click
        Try
            Try
                fdbExplorador.SelectedPath = BackUp.Path
            Catch
            End Try

            If fdbExplorador.ShowDialog() = Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btCrearRespaldo_Click(sender As Object, e As EventArgs) Handles btCrearRespaldo.Click
        Try
            BackUp.BackUpCreate(txtDirectorio.Text)
            txtDirectorio.Clear()
            Config.MsgInfo("Respaldo creado correctamente")
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
End Class