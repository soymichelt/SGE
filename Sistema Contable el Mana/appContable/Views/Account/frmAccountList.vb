Imports appModels
Imports appControllers

Public Class frmAccountList
    Public FrmReturn As Short = 0
    Dim FormLoad As Boolean = False
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
                    'Tamaño del campo de descripción
                    If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width + .Columns(7).Width + .Columns(8).Width Then
                        .Columns(4).Width = 250
                    Else
                        .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - .Columns(7).Width - .Columns(8).Width - 43
                    End If
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

    Private Sub frmAccountList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.frmAccountList_Resize(Nothing, Nothing)
        Me.List()
        cmbBuscar.SelectedIndex = 0
        txtItem.DisplayFormat = Config.fn
        txtBuscar.Focus()
        Me.FormLoad = True
    End Sub


    Private Sub frmAccountList_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnBusqueda.Left = pnBuscar.Width - 432
    End Sub

    Private Sub cmbBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBuscar.SelectedIndexChanged
        If Me.FormLoad Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.List()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Me.List()
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

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                Dim AccountID = Guid.Parse(dtRegistro.SelectedRows(0).Cells(0).Value.ToString)
                Dim c = Account.Find(AccountID)
                If Not c Is Nothing Then
                    Select Case Me.FrmReturn
                        Case 0

                        Case 1
                            If c.Nivel = 6 Then
                                With frmEntriesAccounting
                                    .Buscar(c)
                                    .txtDeber.Focus()
                                End With
                                Me.Close()
                            Else
                                Config.MsgErr("Seleccionar una cuenta de Ultimo Nivel.")
                            End If
                        Case 2
                            If c.Nivel = 6 Then
                                With frmTargetAuxiliar
                                    .Buscar(c)
                                End With
                                Me.Close()
                            Else
                                Config.MsgErr("Seleccionar una cuenta de Ultimo Nivel.")
                            End If
                        Case 3
                            If c.Nivel = 6 Then
                                If c.IsProduct Then
                                    With frmTargetParallel
                                        .Buscar(c)
                                    End With
                                    Me.Close()
                                Else
                                    Config.MsgErr("Solo se pueden cargar cuentas asociadas a la Existencia.")
                                End If
                            Else
                                Config.MsgErr("Seleccionar una cuenta de Ultimo Nivel.")
                            End If
                    End Select
                Else
                    Config.MsgErr("No se encuentra esta cuenta. Probablemente ha sido eliminada.")
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
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
End Class