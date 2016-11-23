Imports appControllers

Public Class frmChangePassword

    Dim FormLoad As Boolean = False

    Private Sub btChangePassword_Click(sender As Object, e As EventArgs) Handles btEntrar.Click
        Try
            AccountSecurity.ChangePassword(Config.User.IDUser, txtActual.Text, txtNueva.Text, txtRepetir.Text)
            txtActual.Clear()
            txtNueva.Clear()
            txtRepetir.Clear()
            Config.MsgInfo("La contraseña se cambio correctamente")
            Me.Close()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        Me.Close()
    End Sub

    Private Sub frmChangePassword_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class