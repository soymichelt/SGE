Imports appModels
Imports appControllers
Public Class frmAccountManager

    Dim FormLoad As Boolean = False
    'Dim thrd As Threading.Thread

    Sub Limpiar()
        txtCodigo.Clear()
        cmbGrupo.Enabled = True
        Try
            cmbGrupo.DataSource = (From c In Account.List() Where c.Nivel <= (Config.Nivel - 1) Select c.IDCuenta, Descripcion = c.Descripcion & " " & c.CodigoCompleto).ToList : cmbGrupo.ValueMember = "IdCuenta" : cmbGrupo.DisplayMember = "Descripcion"
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
        cmbGrupo.SelectedIndex = -1
        txtCodigoCuenta.Clear()
        txtDescripcion.Clear()
        rdDeudora.Checked = False
        rdAcreedora.Checked = False
        rdSi.Checked = False
        rdNo.Checked = True
        btGuardar.Enabled = True
        btEditar.Enabled = False
        btEliminar.Enabled = False
        cmbGrupo.Focus()
    End Sub

    Sub List()
        Try
            dtRegistro.DataSource = (From c In Account.List(If(cmbBuscar.SelectedItem IsNot Nothing, If(cmbBuscar.SelectedItem.ToString().Equals("Código"), txtBuscar.Text, ""), ""), If(cmbBuscar.SelectedItem IsNot Nothing, If(cmbBuscar.SelectedItem.ToString().Equals("Descripción"), txtBuscar.Text, ""), ""))
                                    Select c.IDCuenta, c.Reg, Nivel = If(c.Nivel = 1, "Grupo", If(c.Nivel = 2, "Sub-Grupo", If(c.Nivel = 3, "Mayor", If(c.Nivel = 4, "Sub-Mayor", If(c.Nivel = 5, "Sub-Sub-Mayor", "Ultimo Nivel"))))), Naturaleza = If(c.Naturaleza, "Deudora", "Acreedora"), c.CodigoCompleto, c.Descripcion, c.Deber, c.Haber, c.Saldo).ToList
            If dtRegistro.ColumnCount > 0 Then
                With dtRegistro
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
                    .Columns(2).HeaderText = "Nivel" : .Columns(2).Width = 100
                    .Columns(3).HeaderText = "Naturaleza" : .Columns(3).Width = 100
                    .Columns(4).HeaderText = "Código" : .Columns(4).Width = 100
                    .Columns(5).HeaderText = "Descripción de la Cuenta" : .Columns(5).Width = 300
                    .Columns(6).HeaderText = "Deber" : .Columns(6).Width = 100 : .Columns(6).DefaultCellStyle.Format = Config.fm
                    .Columns(7).HeaderText = "Haber" : .Columns(7).Width = 100 : .Columns(7).DefaultCellStyle.Format = Config.fm
                    .Columns(8).HeaderText = "Saldo" : .Columns(8).Width = 100 : .Columns(8).DefaultCellStyle.Format = Config.fm
                    For Each c As DataGridViewColumn In .Columns
                        c.HeaderText = c.HeaderText.ToUpper
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        txtItem.Value = dtRegistro.RowCount
    End Sub

    Sub BackProccess()
        Try
            cmbGrupo.DataSource = (From c In Account.List() Select c.IDCuenta, Descripcion = c.Descripcion & " " & c.CodigoCompleto).ToList : cmbGrupo.ValueMember = "IdCuenta" : cmbGrupo.DisplayMember = "Descripcion" : cmbGrupo.SelectedIndex = -1
            Me.List()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmAccountManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Me.Parent.Width
        Me.WindowState = FormWindowState.Maximized
        Me.frmAccountManager_Resize(Nothing, Nothing)
        cmbBuscar.SelectedIndex = 0
        txtItem.DisplayFormat = Config.fn
        'thrd = New Threading.Thread(AddressOf Me.BackProccess)
        'thrd.Start()
        
        Try
            cmbGrupo.DataSource = (From c In Account.List() Where c.Nivel <= (Config.Nivel - 1) Select c.IDCuenta, Descripcion = c.Descripcion & " " & c.CodigoCompleto).ToList : cmbGrupo.ValueMember = "IdCuenta" : cmbGrupo.DisplayMember = "Descripcion" : cmbGrupo.SelectedIndex = -1
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
        Me.List()
        Me.FormLoad = True
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        Limpiar()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Config.LoadState("Catálogo de cuentas está guardando...")


        If cmbGrupo.SelectedIndex <> -1 And Not cmbGrupo.SelectedValue Is Nothing And txtCodigoCuenta.Text.Trim <> "" And txtDescripcion.Text.Trim <> "" And (rdDeudora.Checked Or rdAcreedora.Checked) Then
            Try
                Dim g = Account.Find(Guid.Parse(cmbGrupo.SelectedValue.ToString()))
                If Not g Is Nothing Then
                    If g.Nivel < 6 Then
                        Account.Save(
                            New Cuenta With {
                                .IDCuentaGrupo = Guid.Parse(cmbGrupo.SelectedValue.ToString()),
                                .Grupo = g.Grupo,
                                .SubGrupo = If(g.Nivel = (1), txtCodigoCuenta.Text, g.SubGrupo),
                                .Mayor = If(g.Nivel = (2), txtCodigoCuenta.Text, g.Mayor),
                                .SubMayor = If(g.Nivel = (3), txtCodigoCuenta.Text, g.SubMayor),
                                .SubSubMayor = If(g.Nivel = (4), txtCodigoCuenta.Text, g.SubSubMayor),
                                .UltimoNivel = If(g.Nivel = (5), txtCodigoCuenta.Text, ""),
                                .Descripcion = txtDescripcion.Text,
                                .Naturaleza = rdDeudora.Checked,
                                .IsProduct = If(g.Nivel = 5, rdSi.Checked, False)
                            }
                        )
                        Limpiar()
                        List()
                    Else
                        Config.MsgErr("La cuenta '" & g.Grupo & g.SubGrupo & g.Mayor & g.SubMayor & g.SubSubMayor & " - " & g.Descripcion & "'")
                    End If
                Else
                    Config.MsgErr("No se encuentra este grupo. Probablemente ha sido eliminado.")
                End If
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        Else
            Config.MsgErr("Ingresar los campos de orden obligatorios (*).")
        End If

        Config.EndState()
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.List()
        End If
    End Sub

    Private Sub frmAccountManager_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnBusqueda.Left = pnBuscar.Width - 432
    End Sub

    Private Sub cmbBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBuscar.SelectedIndexChanged
        If Me.FormLoad Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub cmbGrupo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbGrupo.KeyDown
        If e.KeyData = Keys.Enter Then
            If cmbGrupo.SelectedIndex <> -1 And Not cmbGrupo.SelectedValue Is Nothing Then
                txtCodigoCuenta.Focus()
            Else
                Config.MsgErr("Seleccionar el grupo de la cuenta.")
            End If
        End If
    End Sub

    Private Sub txtCodigoCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCuenta.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtCodigoCuenta.Text.Trim <> "" Then
                txtDescripcion.Focus()
            Else
                Config.MsgErr("Ingresar el código de la cuenta.")
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtDescripcion.Text.Trim <> "" Then
                If rdDeudora.Checked Then
                    rdDeudora.Focus()
                ElseIf rdAcreedora.Checked Then
                    rdAcreedora.Focus()
                End If
            Else
                Config.MsgErr("Ingresar la descripción de la cuenta.")
            End If
        End If
    End Sub

    Private Sub rdDeudora_KeyDown(sender As Object, e As KeyEventArgs) Handles rdDeudora.KeyDown, rdAcreedora.KeyDown
        Select Case e.KeyData
            Case Keys.Add
                rdDeudora.Checked = True
            Case Keys.Subtract
                rdAcreedora.Checked = True
        End Select
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Config.LoadState("Catálogo de cuentas cargando...")
        Me.List()
        Config.EndState()
    End Sub

    Private Sub frmAccountManager_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
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

    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        Config.LoadState("Catálogo de cuentas está editando...")

        If cmbGrupo.SelectedIndex <> -1 And Not cmbGrupo.SelectedValue Is Nothing And txtCodigoCuenta.Text.Trim <> "" And txtDescripcion.Text.Trim <> "" And (rdDeudora.Checked Or rdAcreedora.Checked) Then
            Try
                Dim g = Account.Find(Guid.Parse(cmbGrupo.SelectedValue.ToString()))
                If Not g Is Nothing Then
                    If g.Nivel < 6 Then
                        Account.Edit(
                            New Cuenta With {
                                .IDCuenta = Guid.Parse(txtCodigo.Text),
                                .IDCuentaGrupo = Guid.Parse(cmbGrupo.SelectedValue.ToString()),
                                .Grupo = g.Grupo,
                                .SubGrupo = If(g.Nivel = (1), txtCodigoCuenta.Text, g.SubGrupo),
                                .Mayor = If(g.Nivel = (2), txtCodigoCuenta.Text, g.Mayor),
                                .SubMayor = If(g.Nivel = (3), txtCodigoCuenta.Text, g.SubMayor),
                                .SubSubMayor = If(g.Nivel = (4), txtCodigoCuenta.Text, g.SubSubMayor),
                                .UltimoNivel = If(g.Nivel = (5), txtCodigoCuenta.Text, ""),
                                .Descripcion = txtDescripcion.Text,
                                .Naturaleza = rdDeudora.Checked,
                                .IsProduct = If(g.Nivel = 5, rdSi.Checked, False)
                            }
                        )
                        Limpiar()
                        List()
                    Else
                        Config.MsgErr("La cuenta '" & g.Grupo & g.SubGrupo & g.Mayor & g.SubMayor & g.SubSubMayor & " - " & g.Descripcion & "'")
                    End If
                Else
                    Config.MsgErr("No se encuentra este grupo. Probablemente ha sido eliminado.")
                End If
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        Else
            Config.MsgErr("Ingresar los campos de orden obligatorios (*).")
        End If

        Config.EndState()
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Config.LoadState("Catálogo de cuentas está eliminando...")

        If MessageBox.Show("Desea eliminar esta cuenta", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Account.Delete(Guid.Parse(txtCodigo.Text))
                Limpiar()
                Me.List()
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        End If

        Config.EndState()
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        If dtRegistro.SelectedRows.Count > 0 Then
            Select Case e.KeyData
                Case Keys.Enter
                    dtRegistro_CellDoubleClick(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        If dtRegistro.SelectedRows.Count > 0 Then
            Try
                Dim c = Account.Find(Guid.Parse(dtRegistro.SelectedRows(0).Cells(0).Value.ToString))
                If Not c Is Nothing Then
                    If c.Nivel = 1 Then
                        Config.MsgErr("Las cuentas de Nivel 1 no se pueden editar ni eliminar")
                        Exit Sub
                    End If
                    txtCodigo.Text = c.IDCuenta.ToString()
                    Dim grupo = Account.Find(c.IDCuentaGrupo)
                    cmbGrupo.Enabled = False
                    If Not grupo Is Nothing Then
                        cmbGrupo.Text = grupo.Descripcion & " " & grupo.CodigoCompleto
                    End If
                    Select Case c.Nivel
                        Case 2 : txtCodigoCuenta.Text = c.SubGrupo
                        Case 3 : txtCodigoCuenta.Text = c.Mayor
                        Case 4 : txtCodigoCuenta.Text = c.SubMayor
                        Case 5 : txtCodigoCuenta.Text = c.SubSubMayor
                        Case 6 : txtCodigoCuenta.Text = c.UltimoNivel
                    End Select
                    txtDescripcion.Text = c.Descripcion
                    If c.Naturaleza Then
                        rdDeudora.Checked = True
                    Else
                        rdAcreedora.Checked = True
                    End If
                    If c.Nivel = 6 Then
                        rdSi.Enabled = True
                        rdNo.Enabled = True
                        If c.IsProduct Then
                            rdSi.Checked = True
                        Else
                            rdNo.Checked = True
                        End If
                    End If
                    btGuardar.Enabled = False
                    btEditar.Enabled = True
                    btEliminar.Enabled = True
                    txtCodigoCuenta.Focus()
                Else
                    Config.MsgErr("No se encuentra esta cuenta")
                End If
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        End If
    End Sub

    Private Sub dtRegistro_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtRegistro.CellFormatting
        Try
            If dtRegistro.Columns(e.ColumnIndex).Name = "Nivel" Then
                If e.Value.ToString = "Grupo" Then
                    dtRegistro.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(142, 169, 219)
                End If
            End If
            If dtRegistro.Columns(e.ColumnIndex).Name = "Descripcion" Then
                If e.Value.ToString = "HELADERÍA EL MANÁ" Or e.Value.ToString = "HELADERIA EL MANÁ" Or e.Value.ToString = "HELADERÍA EL MANA" Or e.Value.ToString = "HELADERIA EL MANA" Then ' < Decimal.Parse(dtRegistro.Rows(e.RowIndex).Cells(16).Value) Then
                    dtRegistro.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(169, 208, 142)
                End If
                If e.Value.ToString = "RESTAURANTE EL MANÁ" Or e.Value.ToString = "HELADERIA EL MANA" Then ' < Decimal.Parse(dtRegistro.Rows(e.RowIndex).Cells(16).Value) Then
                    dtRegistro.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132)
                End If
            End If
        Catch ex As Exception
            'MENSAJE DE ERROR
        End Try
    End Sub


    Private Sub btExportar_Click(sender As Object, e As EventArgs) Handles btExportar.Click
        Try
            Dim rpt As New rptAccountList
            rpt.SetDataSource((From c In Account.List(If(cmbBuscar.SelectedItem IsNot Nothing, If(cmbBuscar.SelectedItem.ToString().Equals("Código"), txtBuscar.Text, ""), ""), If(cmbBuscar.SelectedItem IsNot Nothing, If(cmbBuscar.SelectedItem.ToString().Equals("Descripción"), txtBuscar.Text, ""), ""))
                                    Select c.IDCuenta, c.Reg, c.FMod, C1 = c.Grupo, C2 = c.SubGrupo, C3 = c.Mayor, C4 = c.SubMayor, C5 = c.SubSubMayor, C6 = c.UltimoNivel, c.Descripcion, Naturaleza = If(c.Naturaleza, "Deudora", "Acreedora"), Debe = c.Deber, c.Haber, c.Saldo).ToList)
            Dim tObj As CrystalDecisions.CrystalReports.Engine.TextObject _
                = rpt.Section1.ReportObjects("txtParam")
            tObj.Text = If(cmbBuscar.SelectedItem IsNot Nothing, If(cmbBuscar.SelectedItem.ToString().Equals("Código"), "CÓDIGO: '" & txtBuscar.Text & "'", "DESCRIPCIÓN: '" & txtBuscar.Text & "'"), "")
            frmReport.crvVisual.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If Me.FormLoad Then
            If Not cmbGrupo.SelectedValue Is Nothing And cmbGrupo.SelectedIndex <> -1 Then
                Try
                    Dim g = Account.Find(Guid.Parse(cmbGrupo.SelectedValue.ToString()))
                    If Not g Is Nothing Then
                        If g.Naturaleza Then
                            rdDeudora.Checked = True
                        Else
                            rdAcreedora.Checked = True
                        End If
                        If g.Nivel = 5 Then
                            rdSi.Enabled = True
                            rdNo.Enabled = True
                        Else
                            rdSi.Enabled = False
                            rdNo.Enabled = False
                        End If
                        rdNo.Checked = False
                    Else
                        cmbGrupo.DataSource = (From c In Account.List() Select c.IDCuenta, Descripcion = c.Descripcion & " " & c.CodigoCompleto).ToList : cmbGrupo.ValueMember = "IdCuenta" : cmbGrupo.DisplayMember = "Descripcion"
                    End If
                Catch ex As Exception
                    Config.MsgErr(ex.Message)
                End Try
            End If
        End If
    End Sub


    Private Sub rdSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdSi.CheckedChanged
        If Me.FormLoad Then
            
        End If
    End Sub

    Private Sub rdNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdNo.CheckedChanged
        If Me.FormLoad Then
            
        End If
    End Sub
End Class