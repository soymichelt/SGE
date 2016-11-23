Imports appModels
Imports appControllers

Public Class frmInventario

    Public FrmReturn As Short = 0
    Dim FormLoad As Boolean = False

    Sub List()
        Try
            Dim consulta = (From c In Inventario.List(If(cmbBuscar.SelectedItem IsNot Nothing, If(cmbBuscar.SelectedItem.ToString().Equals("Código"), txtBuscar.Text, ""), ""), If(cmbBuscar.SelectedItem IsNot Nothing, If(cmbBuscar.SelectedItem.ToString().Equals("Descripción"), txtBuscar.Text, ""), ""))
                                    Select c.IDCuenta, c.Reg, Nivel = If(c.Nivel = 1, "Grupo", If(c.Nivel = 2, "Sub-Grupo", If(c.Nivel = 3, "Mayor", If(c.Nivel = 4, "Sub-Mayor", If(c.Nivel = 5, "Sub-Sub-Mayor", "Ultimo Nivel"))))), Codigo = c.CodigoCompleto, c.Descripcion, DebeSaldo = c.Deber, HaberMes = c.Haber, HaberSaldo = c.Saldo, c.Costo, DebeInicial = c.Entrada, HaberInicial = c.Salida, DebeMes = c.Existencia).ToList

            If dtRegistro.Visible Then
                dtRegistro.DataSource = consulta.ToList
                If dtRegistro.ColumnCount > 0 Then
                    With dtRegistro
                        .Columns(0).Visible = False
                        .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
                        .Columns(2).HeaderText = "Nivel" : .Columns(2).Width = 100
                        .Columns(3).HeaderText = "Código" : .Columns(3).Width = 100
                        .Columns(4).HeaderText = "Descripción de la Cuenta" : .Columns(4).Width = 300
                        .Columns(5).HeaderText = "Deber" : .Columns(5).Width = 100 : .Columns(5).DefaultCellStyle.Format = Config.fm
                        .Columns(6).HeaderText = "Haber" : .Columns(6).Width = 100 : .Columns(6).DefaultCellStyle.Format = Config.fm
                        .Columns(7).HeaderText = "Saldo" : .Columns(7).Width = 100 : .Columns(7).DefaultCellStyle.Format = Config.fm
                        .Columns(8).HeaderText = "Costo" : .Columns(8).Width = 100 : .Columns(8).DefaultCellStyle.Format = Config.fm
                        .Columns(9).HeaderText = "Entrada" : .Columns(9).Width = 100 : .Columns(9).DefaultCellStyle.Format = Config.fm
                        .Columns(10).HeaderText = "Salida" : .Columns(11).Width = 100 : .Columns(10).DefaultCellStyle.Format = Config.fm
                        .Columns(11).HeaderText = "Existencia" : .Columns(11).Width = 100 : .Columns(11).DefaultCellStyle.Format = Config.fm
                        'Tamaño del campo de descripción
                        If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width + .Columns(7).Width + .Columns(8).Width + .Columns(9).Width + .Columns(10).Width + .Columns(11).Width Then
                            .Columns(4).Width = 250
                        Else
                            .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - .Columns(7).Width - .Columns(8).Width - .Columns(9).Width - .Columns(10).Width - .Columns(11).Width - 43
                        End If
                        For Each c As DataGridViewColumn In .Columns
                            c.HeaderText = c.HeaderText.ToUpper
                            c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                        Next
                    End With
                End If
            Else
                Dim rpt As New rptInventario

                Dim tObj As CrystalDecisions.CrystalReports.Engine.TextObject
                tObj = rpt.Section1.ReportObjects("txtTipo")
                tObj.Text = "BÚSQUEDA POR: " & cmbBuscar.Text
                tObj = rpt.Section1.ReportObjects("txtBusqueda")
                tObj.Text = txtBuscar.Text

                rpt.SetDataSource(consulta)
                CrystalReportViewer1.ReportSource = rpt
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        txtItem.Value = dtRegistro.RowCount
    End Sub

    Private Sub frmAccountList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.frmAccountList_Resize(Nothing, Nothing)
        Me.List()
        cmbBuscar.SelectedIndex = 0
        txtItem.DisplayFormat = Config.fn
        txtBuscar.Focus()
        Me.FormLoad = True
    End Sub


    Private Sub frmAccountList_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnBusqueda.Left = pnBuscar.Width - 300
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

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
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

    Private Sub dtRegistro_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
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

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        Me.List()
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        txtBuscar.Clear()
        Me.List()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        List()
    End Sub
End Class