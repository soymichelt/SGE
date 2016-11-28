Imports appControllers
Public Class frmSignin

    Private Sub btEntrar_Click(sender As Object, e As EventArgs) Handles btEntrar.Click
        Try
            If txtUsuario.Text = "" Then
                Config.MsgErr("Necesita ingresar el usuario")
                txtUsuario.Focus()
                Exit Sub
            End If
            If txtContraseña.Text = "" Then
                Config.MsgErr("Necesita ingresar la contraseña")
                txtContraseña.Clear()
                txtContraseña.Focus()
                Exit Sub
            End If
            Config.User = AccountSecurity.Signin(txtUsuario.Text, txtContraseña.Text)
            If Not Config.User Is Nothing Then
                'Si inicio sesión
                frmPrincipal.Show()
                My.Application._MainForm = frmPrincipal
                Me.Close()
            Else
                'Datos incorrectos
                Config.MsgErr("Usuario o contraseña incorrecto")
                txtContraseña.Clear()
                txtUsuario.Focus()
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
            txtUsuario.Focus()
        End Try
    End Sub

    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        Me.Close()
    End Sub

    Private Sub frmSignin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub


    Private Sub txtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtUsuario.Text.Trim <> "" Then
                txtContraseña.Focus()
            Else
                Config.MsgErr("Necesita ingresar el usuario")
            End If
        End If
    End Sub

    Private Sub txtContraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtContraseña.Text <> "" Then
                btEntrar.Focus()
            Else
                Config.MsgErr("Necesita ingresar la contraseña")
            End If
        End If
    End Sub

    Private Sub btMostrar_MouseDown(sender As Object, e As MouseEventArgs) Handles btMostrar.MouseDown
        txtContraseña.UseSystemPasswordChar = False
    End Sub

    Private Sub btMostrar_MouseUp(sender As Object, e As MouseEventArgs) Handles btMostrar.MouseUp
        txtContraseña.UseSystemPasswordChar = True
        txtContraseña.Focus()
    End Sub

    Private Sub frmSignin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim prcs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)
            If prcs.Length > 1 Then
                'Process.GetCurrentProcess.CloseMainWindow()
                'Exit Sub
            End If
        Catch ex As Exception
            Config.MsgErr("Se ha producido un error. La aplicación se cerrará. Descripción: " & ex.Message)
        End Try
        txtContraseña.UseSystemPasswordChar = True
    End Sub

    Private Sub frmSignin_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        gpSesion.Left = (Me.Width / 2) - (gpSesion.Width / 2)
        gpSesion.Top = (Me.Height / 2) - (gpSesion.Height / 2) - 10
    End Sub
End Class