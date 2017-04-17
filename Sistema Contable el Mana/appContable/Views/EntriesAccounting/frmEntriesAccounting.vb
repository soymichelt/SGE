Imports appControllers
Imports appModels
Public Class frmEntriesAccounting
    Dim FormLoad As Boolean = False

    Dim List As New List(Of entComprobanteDiarioDetalle)

    Sub Grid()
        dtRegistro.DataSource = (From c In Me.List Select c.IdCuenta, c.Reg, c.CodigoCompleto, c.Descripcion, Naturaleza = If(c.Naturaleza, "Deudora", "Acreedora"), c.Deber, c.Haber, c.Saldo, c.Entrada, c.Salida, c.Existencia).ToList
        If Me.List.Count > 0 Then
            txtTotalDeber.Value = Me.List.Sum(Function(f) f.Deber)
            txtTotalHaber.Value = Me.List.Sum(Function(f) f.Haber)
        Else
            txtTotalDeber.Value = 0.0
            txtTotalHaber.Value = 0.0
        End If
        If dtRegistro.ColumnCount > 0 Then
            With dtRegistro
                .Columns(0).Visible = False
                .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
                .Columns(2).HeaderText = vbNewLine & "Código" & vbNewLine : .Columns(2).Width = 120
                .Columns(3).HeaderText = "Descripción de la Cuenta" : .Columns(3).Width = 300
                .Columns(4).HeaderText = "Naturaleza" : .Columns(4).Width = 110
                .Columns(5).HeaderText = "Deber" : .Columns(5).Width = 100 : .Columns(5).DefaultCellStyle.Format = Config.fm : .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).HeaderText = "Haber" : .Columns(6).Width = 100 : .Columns(6).DefaultCellStyle.Format = Config.fm : .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).HeaderText = "Saldo" : .Columns(7).Width = 100 : .Columns(7).DefaultCellStyle.Format = Config.fm : .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Entrada" : .Columns(8).Width = 100 : .Columns(8).DefaultCellStyle.Format = Config.fm : .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Salida" : .Columns(9).Width = 100 : .Columns(9).DefaultCellStyle.Format = Config.fm : .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Existencia" : .Columns(10).Width = 100 : .Columns(10).DefaultCellStyle.Format = Config.fm : .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                For Each c As DataGridViewColumn In .Columns
                    c.HeaderText = c.HeaderText.ToUpper
                    c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                Next
            End With
        End If
    End Sub

    Sub Limpiar()
        Try
            txtNComprobante.Enabled = True
            txtNComprobante.Value = EntriesAccounting.Count()
            dtpFecha.Value = DateTime.Now
            txtConcepto.Clear()
            txtReferencia.Clear()
            Me.List.RemoveAll(Function(f) True)
            Me.Grid()
            btGuardar.Enabled = True
            btEditar.Enabled = False
            btEliminar.Enabled = False
            btImprimir.Enabled = False
            txtNComprobante.Focus()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmEntriesAccounting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized

            'Formato Campos Decimales
            txtTotalDeber.Value = 0.0 : txtTotalDeber.DisplayFormat = Config.fm
            txtTotalHaber.Value = 0.0 : txtTotalHaber.DisplayFormat = Config.fm
            txtDeber.Value = 0.0 : txtDeber.DisplayFormat = Config.fm
            txtHaber.Value = 0.0 : txtHaber.DisplayFormat = Config.fm
            txtEntrada.Value = 0.0 : txtEntrada.DisplayFormat = Config.fm
            txtSalida.Value = 0.0 : txtSalida.DisplayFormat = Config.fm
            txtTotalDeberSel.Value = 0.0 : txtTotalDeberSel.DisplayFormat = Config.fm
            txtTotalHaberSel.Value = 0.0 : txtTotalHaberSel.DisplayFormat = Config.fm
            txtTotalSaldoSel.Value = 0.0 : txtTotalSaldoSel.DisplayFormat = Config.fm


            dtpFecha.Value = DateTime.Now
            txtNComprobante.Value = EntriesAccounting.Count
            txtNComprobante.DisplayFormat = Config.fn
            txtNComprobante.Value = 0
            Me.Grid()
            Me.FormLoad = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmEntriesAccounting_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnSaldo.Left = pnDetalle.Width - 238
        pnExistencia.Left = pnDetalle.Width - 238
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        Limpiar()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Config.LoadState("Comprobante diario está guardando...")

        Try
            If dtpFecha.Value < Config.FechaInicio Then
                Config.MsgErr("La fecha debe ser mayor a " & Config.FechaInicio.ToShortDateString())
                Exit Sub
            End If
            If txtConcepto.Text.Trim = "" Then
                Config.MsgErr("Ingresar el concepto")
                Exit Sub
            End If
            If txtReferencia.Text.Trim = "" Then
                Config.MsgErr("Ingresar el referencia")
                Exit Sub
            End If
            If Me.List.Count = 0 Then
                Config.MsgErr("Ingresar el detalle")
                Exit Sub
            End If
            If Me.List.Sum(Function(f) f.Deber) <> Me.List.Sum(Function(f) f.Haber) Then
                Config.MsgErr("La suma del Deber tiene que ser igual a la suma del Haber")
                Exit Sub
            End If
            'Declaración de la instancia comprobante
            Dim Comprobante As New ComprobanteDiario With {
                    .Fecha = dtpFecha.Value,
                    .Concepto = txtConcepto.Text,
                    .Referencia = txtReferencia.Text
                }

            'Testeo antes de guardar la información
            EntriesAccounting.Test(Comprobante, Me.List)

            'Guardado de la información
            txtCodigo.Text = EntriesAccounting.Save(
                Comprobante,
                Me.List
            ).ToString

            'Habilitación y deshabilitación de los botones según operación
            txtCodigo.Text = Comprobante.IDComprobante.ToString
            btGuardar.Enabled = False : btEditar.Enabled = True : btEliminar.Enabled = True : btImprimir.Enabled = True
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try

        Config.EndState()
    End Sub

    Public Sub Buscar(ByVal CodigoCuenta As String)
        Try
            Dim c = Account.Find(CodigoCuenta)
            If Not c Is Nothing Then
                If c.Nivel = Config.Nivel Then
                    txtIdCuenta.Text = c.IDCuenta.ToString()
                    txtDescripcion.Text = c.CodigoCompleto & " " & c.Descripcion
                    If c.IsProduct Then
                        txtEntrada.IsInputReadOnly = False
                        txtSalida.IsInputReadOnly = False
                    Else
                        txtEntrada.IsInputReadOnly = True
                        txtSalida.IsInputReadOnly = True
                    End If
                    txtTotalDeberSel.Value = c.Deber
                    txtTotalHaberSel.Value = c.Haber
                    txtTotalSaldoSel.Value = c.Saldo
                    txtNCuenta.Clear()
                    txtDeber.Focus()
                Else
                    Config.MsgErr("No puede registrar movimientos en esta cuenta por que no es de Ultimo Nivel.")
                End If
            Else
                Config.MsgErr("No se encuentra ninguna cuenta con este nombre.")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub Buscar(ByVal c As entAccount)
        Try
            If Not c Is Nothing Then
                If c.Nivel = Config.Nivel Then
                    txtIdCuenta.Text = c.IDCuenta.ToString()
                    txtDescripcion.Text = c.CodigoCompleto & " " & c.Descripcion
                    If c.IsProduct Then
                        txtEntrada.IsInputReadOnly = False
                        txtSalida.IsInputReadOnly = False
                    Else
                        txtEntrada.IsInputReadOnly = True
                        txtSalida.IsInputReadOnly = True
                    End If
                    txtTotalDeberSel.Value = c.Deber
                    txtTotalHaberSel.Value = c.Haber
                    txtTotalSaldoSel.Value = c.Saldo
                    txtNCuenta.Clear()
                    txtDeber.Focus()
                Else
                    Config.MsgErr("No puede registrar movimientos en esta cuenta por que no es de Ultimo Nivel.")
                End If
            Else
                Config.MsgErr("No se encuentra ninguna cuenta con este código.")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNCuenta.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtNCuenta.Text.Trim <> "" Then
                Me.Buscar(txtNCuenta.Text.Trim)
            Else
                btBuscarCuenta_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtDeber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDeber.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtIdCuenta.Text.Trim <> "" Then
                If txtDeber.Value > 0 Then
                    txtHaber.Value = 0
                    txtSalida.Value = 0
                    Dim c = Account.Find(Guid.Parse(txtIdCuenta.Text))
                    If Not c Is Nothing Then
                        If Not c.IsProduct Then
                            txtEntrada.IsInputReadOnly = True
                            txtSalida.IsInputReadOnly = True
                            Dim ent = Me.List.Where(Function(f) f.IdCuenta = c.IDCuenta).FirstOrDefault
                            If If(c.Naturaleza, c.Saldo + txtDeber.Value, c.Saldo - txtDeber.Value) >= 0 Then
                                If ent Is Nothing Then
                                    ent = New entComprobanteDiarioDetalle()
                                    Me.List.Add(ent)
                                End If

                                'se cargan datos de la cuenta
                                ent.IdCuenta = c.IDCuenta
                                ent.Reg = c.Reg
                                ent.CodigoCompleto = c.CodigoCompleto
                                ent.Descripcion = c.Descripcion
                                ent.Naturaleza = c.Naturaleza

                                'se cargan saldos
                                ent.Haber = 0
                                ent.Deber = txtDeber.Value
                                ent.Saldo = If(c.Naturaleza, c.Saldo + ent.Deber, c.Saldo - ent.Deber)

                                'Se actualiza el grid
                                Me.Grid()

                                'se limpian los campos del detalle
                                txtDeber.Value = 0
                                txtTotalDeberSel.Value = 0.0 : txtTotalHaberSel.Value = 0.0 : txtTotalSaldoSel.Value = 0.0
                                txtIdCuenta.Clear() : txtDescripcion.Clear() : txtNCuenta.Focus()
                            Else
                                Config.MsgErr("El Saldo es menor que la cantidad que intentas Debitar")
                            End If
                        Else
                            'Se calcula una cantidad segun el costo actual de la cuenta
                            If c.Existencia > 0 And c.Costo > 0 Then
                                txtEntrada.Value = txtDeber.Value / c.Costo
                            End If

                            txtEntrada.IsInputReadOnly = False
                            txtSalida.IsInputReadOnly = False
                            txtEntrada.Focus()
                        End If
                    Else
                        txtDescripcion.Clear()
                        txtTotalDeberSel.Value = 0.0
                        txtTotalHaberSel.Value = 0.0
                        txtTotalSaldoSel.Value = 0.0

                        'limpiar existencia
                        txtEntrada.Value = 0
                        txtSalida.Value = 0
                        txtEntrada.IsInputReadOnly = True
                        txtSalida.IsInputReadOnly = True

                        Config.MsgErr("No se encuentra ninguna cuenta con este código.")
                        txtNCuenta.Focus()
                    End If
                Else
                    'Limpiar entrada
                    txtEntrada.Value = 0

                    txtHaber.Focus()
                End If
            Else
                txtNCuenta.Focus()
            End If
        End If
    End Sub

    Private Sub txtDeber_ValueChanged(sender As Object, e As EventArgs) Handles txtDeber.ValueChanged
        If txtDeber.Value > 0 Then
            txtHaber.Value = 0
            txtSalida.Value = 0
        End If
    End Sub

    Private Sub txtHaber_ValueChanged(sender As Object, e As EventArgs) Handles txtHaber.ValueChanged
        If txtHaber.Value > 0 Then
            txtDeber.Value = 0
            txtEntrada.Value = 0
        End If
    End Sub

    Private Sub txtHaber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHaber.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtIdCuenta.Text.Trim <> "" Then
                If txtHaber.Value > 0 Then
                    txtDeber.Value = 0
                    Dim c = Account.Find(Guid.Parse(txtIdCuenta.Text))
                    If Not c Is Nothing Then
                        If Not c.IsProduct Then
                            Dim ent = Me.List.Where(Function(f) f.IdCuenta = c.IDCuenta).FirstOrDefault
                            If If(c.Naturaleza, c.Saldo - txtHaber.Value, c.Saldo + txtHaber.Value) >= 0 Then

                                If ent Is Nothing Then
                                    ent = New entComprobanteDiarioDetalle()
                                    Me.List.Add(ent)
                                End If

                                'se cargan datos de la cuenta
                                ent.IdCuenta = c.IDCuenta
                                ent.Reg = c.Reg
                                ent.CodigoCompleto = c.CodigoCompleto
                                ent.Descripcion = c.Descripcion
                                ent.Naturaleza = c.Naturaleza

                                'se cargan saldos
                                ent.Deber = 0
                                ent.Haber = txtHaber.Value
                                ent.Saldo = If(c.Naturaleza, c.Saldo - ent.Haber, c.Saldo + ent.Haber)

                                'se actualiza el grid
                                Me.Grid()

                                'se limpian los campos del detalle
                                txtHaber.Value = 0
                                txtTotalDeberSel.Value = 0.0 : txtTotalHaberSel.Value = 0.0 : txtTotalSaldoSel.Value = 0.0
                                txtIdCuenta.Clear() : txtDescripcion.Clear() : txtNCuenta.Focus()
                            Else
                                Config.MsgErr("El Saldo es menor que la cantidad que intentas Acreeditar")
                            End If
                        Else
                            'Se calcula una cantidad segun el costo actual de la cuenta
                            If c.Existencia > 0 And c.Costo > 0 Then
                                txtSalida.Value = txtHaber.Value / c.Costo
                            End If

                            txtEntrada.IsInputReadOnly = False
                            txtSalida.IsInputReadOnly = False
                            txtSalida.Focus()
                        End If
                    Else
                        txtDescripcion.Clear()
                        txtTotalDeberSel.Value = 0.0
                        txtTotalHaberSel.Value = 0.0
                        txtTotalSaldoSel.Value = 0.0

                        'limpiar existencia
                        txtEntrada.Value = 0
                        txtSalida.Value = 0
                        txtEntrada.IsInputReadOnly = True
                        txtSalida.IsInputReadOnly = True

                        Config.MsgErr("No se encuentra ninguna cuenta con este código.")
                        txtNCuenta.Focus()
                    End If
                Else
                    'Limpiar Salida
                    txtSalida.Value = 0

                    txtDeber.Focus()
                End If
            Else
                txtNCuenta.Focus()
            End If
        End If
    End Sub

    Private Sub txtNComprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNComprobante.KeyDown
        If e.KeyData = Keys.Enter Then
            Try
                If txtNComprobante.Value > 0 Then
                    Dim c = EntriesAccounting.Find(txtNComprobante.Value)
                    If Not c Is Nothing Then
                        btGuardar.Enabled = False
                        btEditar.Enabled = True
                        btEliminar.Enabled = True
                        btImprimir.Enabled = True

                        txtCodigo.Text = c.IDComprobante.ToString
                        txtNComprobante.Enabled = False
                        dtpFecha.Value = c.Fecha
                        txtConcepto.Text = c.Concepto
                        txtReferencia.Text = c.Referencia
                        List.RemoveAll(Function(f) True)
                        List.AddRange(EntriesAccounting.EntrieDetails(c.IDComprobante))
                        Me.Grid()
                    Else
                        txtNComprobante.Value = EntriesAccounting.Count
                        txtConcepto.Focus()
                    End If
                Else
                    txtNComprobante.Value = EntriesAccounting.Count
                    txtConcepto.Focus()
                End If
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtConcepto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConcepto.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtConcepto.Text.Trim <> "" Then
                txtReferencia.Focus()
            Else
                Config.MsgErr("Ingresar el Concepto")
            End If
        End If
    End Sub

    Private Sub txtReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferencia.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtReferencia.Text.Trim <> "" Then
                txtNCuenta.Focus()
            Else
                Config.MsgErr("Ingresar la Referencia")
            End If
        End If
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Try
            If MessageBox.Show("¿Desea anular este comprobante?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EntriesAccounting.Delete(Guid.Parse(txtCodigo.Text))
                Limpiar()
                Config.MsgInfo("Anulado correctamente")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        Try
            Dim rpt As New rptEntriesAccountingImp
            rpt.SetDataSource((From c In EntriesAccounting.FindDetails(Guid.Parse(txtCodigo.Text)) Select c.IdComprobante, c.N, Reg = c.RegC, FMod = c.FModC, Dia = c.Fecha.Day, Mes = c.Fecha.Month, Anual = c.Fecha.Year, c.Concepto, c.Referencia, c.IdCuenta, Codigo = c.CodigoCompleto, c.Descripcion, Naturaleza = If(c.Naturaleza, "Deudora", "Acreedora"), Debe = c.Deber, c.Haber, c.Saldo))
            frmReport.crvVisual.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
    Private Sub frmEntriesAccounting_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                Case Keys.P
                    btImprimir_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub txtTotalDeber_ValueChanged(sender As Object, e As EventArgs) Handles txtTotalDeber.ValueChanged, txtTotalHaber.ValueChanged
        If txtTotalDeber.Value = txtTotalHaber.Value Then
            txtTotalDeber.ForeColor = Color.Green
            txtTotalHaber.ForeColor = Color.Green
        Else
            txtTotalDeber.ForeColor = Color.Red
            txtTotalHaber.ForeColor = Color.Red
        End If
    End Sub

    Private Sub dtRegistro_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRegistro.CellDoubleClick
        Try
            If dtRegistro.SelectedRows.Count > 0 Then
                Dim c = Account.Find(Guid.Parse(dtRegistro.SelectedRows(0).Cells(0).Value.ToString()))
                If Not c Is Nothing Then
                    txtIdCuenta.Text = c.IDCuenta.ToString
                    txtNCuenta.Text = c.CodigoCompleto
                    txtDescripcion.Text = c.CodigoCompleto & " " & c.Descripcion
                    txtDeber.Value = Decimal.Parse(dtRegistro.SelectedRows(0).Cells(5).Value.ToString)
                    txtHaber.Value = Decimal.Parse(dtRegistro.SelectedRows(0).Cells(6).Value.ToString)
                    If Decimal.Parse(dtRegistro.SelectedRows(0).Cells(8).Value.ToString) > 0 Or Decimal.Parse(dtRegistro.SelectedRows(0).Cells(9).Value.ToString) > 0 Then
                        txtEntrada.IsInputReadOnly = False
                        txtEntrada.Value = Decimal.Parse(dtRegistro.SelectedRows(0).Cells(8).Value.ToString)
                        txtSalida.IsInputReadOnly = False
                        txtSalida.Value = Decimal.Parse(dtRegistro.SelectedRows(0).Cells(9).Value.ToString)
                    Else
                        txtEntrada.IsInputReadOnly = True
                        txtSalida.IsInputReadOnly = True
                    End If
                    txtNCuenta.Focus()
                Else
                    Config.MsgErr("Esta cuenta ya no se encuentra")
                    dtRegistro.Rows.Remove(dtRegistro.SelectedRows(0))
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub dtRegistro_KeyDown(sender As Object, e As KeyEventArgs) Handles dtRegistro.KeyDown
        e.SuppressKeyPress = True
        Select Case e.KeyData
            Case Keys.Enter
                dtRegistro_CellDoubleClick(Nothing, Nothing)
            Case Keys.Delete
                Try
                    If dtRegistro.SelectedRows.Count > 0 Then
                        Dim CuentaID = Guid.Parse(dtRegistro.SelectedRows(0).Cells(0).Value.ToString())
                        Me.List.Remove(Me.List.Where(Function(f) f.IdCuenta = CuentaID).FirstOrDefault())
                        Me.Grid()
                        txtNCuenta.Focus()
                    End If
                Catch ex As Exception
                    Config.MsgErr(ex.Message)
                End Try
        End Select
    End Sub

    Private Sub txtEntrada_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEntrada.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtIdCuenta.Text.Trim <> "" Then
                If txtEntrada.Value > 0 Then
                    txtHaber.Value = 0
                    txtSalida.Value = 0
                    Dim c = Account.Find(Guid.Parse(txtIdCuenta.Text))
                    If Not c Is Nothing Then
                        If c.IsProduct Then
                            'Si no se ha ingresado 
                            If txtDeber.Value = 0 Then
                                txtDeber.Value = c.Costo * txtEntrada.Value
                                txtDeber.Focus()
                                Exit Sub
                            End If

                            'se selecciona el item si existe en la lista
                            Dim item = Me.List.Where(Function(f) f.IdCuenta = c.IDCuenta).FirstOrDefault

                            'Se validan los saldos
                            If If(c.Naturaleza, c.Saldo + txtDeber.Value, c.Saldo - txtDeber.Value) >= 0 Then

                                'Se validan las existencias
                                If If(c.Naturaleza, c.Existencia + txtEntrada.Value, c.Existencia - txtEntrada.Value) < 0 Then
                                    Config.MsgErr("Las existencias no puede quedar en Negativo. Atualmente es: " & c.Existencia)
                                    Exit Sub
                                End If

                                'Se crea un nuevo item si este no se encuentra en la lista
                                If item Is Nothing Then
                                    item = New entComprobanteDiarioDetalle()
                                    Me.List.Add(item)
                                End If

                                'Se agragan a la lista los datos de la cuenta
                                item.IdCuenta = c.IDCuenta
                                item.Reg = c.Reg
                                item.CodigoCompleto = c.CodigoCompleto
                                item.Descripcion = c.Descripcion
                                item.Naturaleza = c.Naturaleza

                                'Validacion de salida cuentas con inventario
                                'If Not c.Naturaleza Then
                                '    txtDeber.Value = c.Costo * txtEntrada.Value
                                'End If

                                'Saldos
                                item.Haber = 0
                                item.Deber = txtDeber.Value
                                item.Saldo = If(c.Naturaleza, c.Saldo + item.Deber, c.Saldo - item.Deber)

                                'Existencia
                                item.Salida = 0
                                item.Entrada = txtEntrada.Value
                                item.Existencia = If(c.Naturaleza, c.Existencia + item.Entrada, c.Saldo - item.Entrada)

                                Me.Grid()
                                txtDeber.Value = 0
                                txtIdCuenta.Clear()
                                txtDescripcion.Clear()
                                txtEntrada.Value = 0
                                txtSalida.Value = 0
                                txtTotalDeberSel.Value = 0 : txtTotalHaberSel.Value = 0 : txtTotalSaldoSel.Value = 0
                                txtNCuenta.Focus()
                            Else
                                Config.MsgErr("El Saldo es menor que la cantidad que intentas Debitar")
                            End If
                        Else
                            'limpiar existencia
                            txtEntrada.Value = 0
                            txtSalida.Value = 0
                            txtEntrada.IsInputReadOnly = True
                            txtSalida.IsInputReadOnly = True
                            txtDeber.Focus()
                        End If
                    Else
                        txtDescripcion.Clear()
                        txtTotalDeberSel.Value = 0.0
                        txtTotalHaberSel.Value = 0.0
                        txtTotalSaldoSel.Value = 0.0

                        'limpiar existencia
                        txtEntrada.Value = 0
                        txtSalida.Value = 0
                        txtEntrada.IsInputReadOnly = True
                        txtSalida.IsInputReadOnly = True

                        Config.MsgErr("No se encuentra ninguna cuenta con este código.")
                        txtNCuenta.Focus()
                    End If
                Else
                    txtDeber.Value = 0
                    txtHaber.Focus()
                End If
            Else
                txtNCuenta.Focus()
            End If
        End If
    End Sub

    Private Sub txtSalida_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSalida.KeyDown
        If e.KeyData = Keys.Enter Then
            If txtIdCuenta.Text.Trim <> "" Then
                If txtSalida.Value > 0 Then

                    txtDeber.Value = 0
                    txtEntrada.Value = 0
                    Dim c = Account.Find(Guid.Parse(txtIdCuenta.Text))
                    If Not c Is Nothing Then
                        If c.IsProduct Then
                            If txtHaber.Value = 0 Then
                                txtHaber.Value = c.Costo * txtSalida.Value
                                txtHaber.Focus()
                                Exit Sub
                            End If

                            'se selecciona el item si existe en la lista
                            Dim item = Me.List.Where(Function(f) f.IdCuenta = c.IDCuenta).FirstOrDefault

                            'Se validan los saldos
                            If If(c.Naturaleza, c.Saldo - txtHaber.Value, c.Saldo + txtHaber.Value) >= 0 Then

                                'Se validan las existencias
                                If If(c.Naturaleza, c.Existencia - txtSalida.Value, c.Existencia + txtSalida.Value) < 0 Then
                                    Config.MsgErr("Las existencias no puede quedar en Negativo. Atualmente es: " & c.Existencia)
                                    Exit Sub
                                End If

                                'Se crea un nuevo item si este no se encuentra en la lista
                                If item Is Nothing Then
                                    item = New entComprobanteDiarioDetalle()
                                    Me.List.Add(item)
                                End If

                                'Se agragan a la lista los datos de la cuenta
                                item.IdCuenta = c.IDCuenta
                                item.Reg = c.Reg
                                item.CodigoCompleto = c.CodigoCompleto
                                item.Descripcion = c.Descripcion
                                item.Naturaleza = c.Naturaleza

                                'Validacion de salida cuentas con inventario
                                'If c.Naturaleza Then
                                '    txtHaber.Value = c.Costo * txtSalida.Value
                                'End If

                                'Saldos
                                item.Deber = 0
                                item.Haber = txtHaber.Value
                                item.Saldo = If(c.Naturaleza, c.Saldo - item.Haber, c.Saldo + item.Haber)

                                'Existencia
                                item.Entrada = 0
                                item.Salida = txtSalida.Value
                                item.Existencia = If(c.Naturaleza, c.Existencia - item.Salida, c.Saldo + item.Salida)

                                Me.Grid()
                                txtHaber.Value = 0
                                txtIdCuenta.Clear()
                                txtDescripcion.Clear()
                                txtEntrada.Value = 0
                                txtSalida.Value = 0
                                txtTotalDeberSel.Value = 0 : txtTotalHaberSel.Value = 0 : txtTotalSaldoSel.Value = 0
                                txtNCuenta.Focus()
                            Else
                                Config.MsgErr("El Saldo es menor que la cantidad que intentas Acreditar")
                            End If
                        Else
                            'limpiar existencia
                            txtEntrada.Value = 0
                            txtSalida.Value = 0
                            txtEntrada.IsInputReadOnly = True
                            txtSalida.IsInputReadOnly = True
                            txtHaber.Focus()
                        End If
                    Else
                        txtDescripcion.Clear()
                        txtTotalDeberSel.Value = 0.0
                        txtTotalHaberSel.Value = 0.0
                        txtTotalSaldoSel.Value = 0.0

                        'limpiar existencia
                        txtEntrada.Value = 0
                        txtSalida.Value = 0
                        txtEntrada.IsInputReadOnly = True
                        txtSalida.IsInputReadOnly = True

                        Config.MsgErr("No se encuentra ninguna cuenta con este código.")
                        txtNCuenta.Focus()
                    End If
                Else
                    txtHaber.Value = 0
                    txtDeber.Focus()
                End If
            Else
                txtNCuenta.Focus()
            End If
        End If
    End Sub

    Private Sub txtEntrada_ValueChanged(sender As Object, e As EventArgs) Handles txtEntrada.ValueChanged
        If txtEntrada.Value > 0 Then
            txtHaber.Value = 0
            txtSalida.Value = 0
        End If
    End Sub

    Private Sub btBuscarCuenta_Click(sender As Object, e As EventArgs) Handles btBuscarCuenta.Click
        frmAccountList.FrmReturn = 1
        frmAccountList.ShowDialog()
        If txtIdCuenta.Text.Trim <> "" Then
            txtDeber.Focus()
        Else
            txtNCuenta.Focus()
        End If
    End Sub

    Private Sub txtSalida_ValueChanged(sender As Object, e As EventArgs) Handles txtSalida.ValueChanged
        If txtSalida.Value > 0 Then
            txtDeber.Value = 0
            txtEntrada.Value = 0
        End If
    End Sub

    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        frmEntriesAccountingEdit.IDComprobante = Guid.Parse(txtCodigo.Text)
        Config.OnLoadForm(frmEntriesAccountingEdit)
    End Sub
End Class