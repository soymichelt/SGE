Imports appControllers
Imports appModels
Public Class frmAccountSecurityManager

    Dim FormLoad As Boolean = False

    Dim IDUser As Guid = Guid.Empty

    Sub Clear()
        Me.IDUser = Guid.Empty
        txtNombres.Clear()
        txtApellidos.Clear()
        txtUsuario.Clear()
        txtContraseña.Clear()
        lblEditPass.Visible = False
        btGuardar.Enabled = True
        btEditar.Enabled = False
        btEliminar.Enabled = False
        txtNombres.Focus()

    End Sub

    Sub List()
        Try
            Dim query = AccountSecurity.List(If(cmbBuscar.SelectedItem.ToString = "Nombre", txtBuscar.Text.Trim, ""), If(cmbBuscar.SelectedItem.ToString = "Usuario", txtBuscar.Text.Trim, ""))
            dtRegistro.DataSource = (From q In query Select q.IDUser, q.Reg, q.FMod, q.Name, q.SurnName, q.UserName).ToList
            If dtRegistro.Columns.Count > 0 Then
                With dtRegistro
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = vbNewLine & "Registrado" & vbNewLine : .Columns(1).Width = 135
                    .Columns(2).HeaderText = "Modificado" : .Columns(2).Width = 135
                    .Columns(3).HeaderText = "Nombres" : .Columns(3).Width = 200
                    .Columns(4).HeaderText = "Apellidos" : .Columns(4).Width = 200
                    .Columns(5).HeaderText = "Usuario" : .Columns(5).Width = 200
                    For Each c As DataGridViewColumn In .Columns
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                        c.HeaderText = c.HeaderText.ToUpper
                    Next
                End With
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
        txtItem.Value = dtRegistro.RowCount
    End Sub

    Private Sub frmAccountSecurityManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Me.Parent.Width
        Me.WindowState = FormWindowState.Maximized
        Me.frmAccountSecurityManager_Resize(Nothing, Nothing)
        txtContraseña.UseSystemPasswordChar = True
        cmbBuscar.SelectedIndex = 0
        Me.List()
        txtItem.DisplayFormat = Config.fn
        Me.FormLoad = True
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        Clear()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" And txtUsuario.Text.Trim <> "" And txtContraseña.Text.Trim <> "" Then
            Try

                Dim User = AccountSecurity.UserCreate(New UserAccount With {
                                                        .Name = txtNombres.Text,
                                                        .SurnName = txtApellidos.Text,
                                                        .UserName = txtUsuario.Text,
                                                        .UserPass = txtContraseña.Text
                                                      })
                If Config.ValidatePass(txtContraseña.Text) Then
                    If Not User Is Nothing Then
                        Me.IDUser = User.IDUser
                        Me.List()
                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                        txtNombres.Focus()
                    Else
                        Config.MsgErr("Ha ocurrido un error al intentar guardar este usuario. Intente de nuevo.")
                    End If
                Else
                    Config.MsgErr("Es obligatorio que las contraseñas contengan mas de 8 caracteres. Ademas de contener números, mayúsculas y caracteres especiales.")
                End If
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        Else
            Config.MsgErr("Ingresar campos de orden obligatorio(*).")
        End If
    End Sub


    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        If txtNombres.Text.Trim <> "" And txtApellidos.Text.Trim <> "" And txtUsuario.Text.Trim <> "" Then
            Try
                If txtContraseña.Text <> "" Then
                    If Not Config.ValidatePass(txtContraseña.Text) Then
                        Config.MsgErr("Es obligatorio que las contraseñas contengan mas de 8 caracteres. Ademas de contener números, mayúsculas y caracteres especiales.")
                        Exit Sub
                    End If
                End If
                Dim User = AccountSecurity.UserUpdate(New UserAccount With {
                                                        .IDUser = Me.IDUser,
                                                        .Name = txtNombres.Text,
                                                        .SurnName = txtApellidos.Text,
                                                        .UserName = txtUsuario.Text,
                                                        .UserPass = txtContraseña.Text
                                                      })
                If Not User Is Nothing Then
                    Me.IDUser = User.IDUser
                    Me.List()
                    Me.Clear()
                Else
                    Config.MsgErr("Ha ocurrido un error al intentar guardar este usuario. Intente de nuevo.")
                End If
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        Else
            Config.MsgErr("Ingresar campos de orden obligatorio(*).")
        End If
    End Sub

    Private Sub txtNombres_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtNombres.Text.Trim <> "" Then
                txtApellidos.Focus()
            Else
                Config.MsgErr("Ingresar nombres")
            End If
        End If
    End Sub

    Private Sub txtApellidos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApellidos.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtApellidos.Text.Trim <> "" Then
                txtUsuario.Focus()
            Else
                Config.MsgErr("Ingresar apellidos")
            End If
        End If
    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtUsuario.Text.Trim <> "" Then
                txtContraseña.Focus()
            Else
                Config.MsgErr("Ingresar usuario")
            End If
        End If
    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged
        txtUsuario.Text = txtUsuario.Text.Replace(" ", "")
    End Sub

    Private Sub chkMostrar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrar.CheckedChanged
        If chkMostrar.Checked Then
            txtContraseña.UseSystemPasswordChar = False
        Else
            txtContraseña.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtContraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyDown
        If e.KeyData = Keys.Enter Then
            If btGuardar.Enabled Then
                btGuardar_Click(Nothing, Nothing)
            Else
                btEditar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub frmAccountSecurityManager_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    btNuevo_Click(Nothing, Nothing)
                Case Keys.G
                    If btGuardar.Enabled Then
                        btGuardar_Click(Nothing, Nothing)
                    End If
                Case Keys.E
                    If btEditar.Enabled Then
                        btEditar_Click(Nothing, Nothing)
                    End If
                Case Keys.Delete
                    If btEliminar.Enabled Then
                        btEliminar_Click(Nothing, Nothing)
                    End If
                Case Keys.B
                    btBuscar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Try
            AccountSecurity.UserDelete(Me.IDUser)
            Me.Clear()
            Config.MsgInfo("Eliminado correctamente")
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        txtBuscar.Focus()
    End Sub

    Private Sub frmAccountSecurityManager_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnBusqueda.Left = Me.Width - PanelEx1.Width - 448
    End Sub

    Private Sub cmbBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBuscar.SelectedIndexChanged
        If Me.FormLoad Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Me.List()
    End Sub


    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                Dim User = appControllers.AccountSecurity.Find(Guid.Parse(dtRegistro.SelectedRows(0).Cells(0).Value.ToString()))
                If Not User Is Nothing Then
                    Me.IDUser = User.IDUser
                    txtNombres.Text = User.Name
                    txtApellidos.Text = User.SurnName
                    txtUsuario.Text = User.UserName
                    txtContraseña.Clear()
                    lblEditPass.Visible = True
                    btGuardar.Enabled = False
                    btEditar.Enabled = True
                    btEliminar.Enabled = True
                    txtNombres.Focus()
                Else
                    Config.MsgErr("No se encuentra esta 'Cuenta de Usuario'. Probablemente ha sido eliminado.")
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
End Class