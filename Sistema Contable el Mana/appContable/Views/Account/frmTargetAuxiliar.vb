Imports appControllers
Public Class frmTargetAuxiliar
    Dim FormLoad As Boolean = False
    Sub Limpiar()
        dtpInicio.Value = DateTime.Now
        dtpFinal.Value = DateTime.Now
        List()
        txtCodigo.Focus()
    End Sub

    Sub List(Optional ByVal Codigo As String = "", Optional ByVal Descripcion As String = "")
        Try
            If txtIdCuenta.Text.Trim <> "" Then
                Dim consulta = (From c In CardDaughter.List(Guid.Parse(txtIdCuenta.Text), dtpInicio.Value.ToShortDateString() & " 00:00:00", dtpFinal.Value.ToShortDateString() & " 23:59:59") Order By c.Fecha Select c.IdComprobante, c.N, c.Fecha, c.Concepto, c.Referencia, DebeSaldo = c.Deber, HaberMes = c.Haber, HaberSaldo = c.Saldo).ToList
                If dtRegistro.Visible Then
                    dtRegistro.DataSource = consulta.ToList
                    If dtRegistro.ColumnCount > 0 Then
                        With dtRegistro
                            .Columns(0).Visible = False
                            .Columns(1).HeaderText = vbNewLine & "N° Comprobante" & vbNewLine : .Columns(1).Width = 160 : .Columns(1).DefaultCellStyle.Format = Config.fn
                            .Columns(2).HeaderText = vbNewLine & "Fecha" & vbNewLine : .Columns(2).Width = 150
                            .Columns(3).HeaderText = "Concepto del Comprobante" : .Columns(3).Width = 400
                            .Columns(4).HeaderText = "Referencia del Movimiento" : .Columns(4).Width = 250
                            .Columns(5).HeaderText = "Deber" : .Columns(5).Width = 120 : .Columns(5).DefaultCellStyle.Format = Config.fm
                            .Columns(6).HeaderText = "Haber" : .Columns(6).Width = 120 : .Columns(6).DefaultCellStyle.Format = Config.fm
                            .Columns(7).HeaderText = "Saldo" : .Columns(7).Width = 120 : .Columns(7).DefaultCellStyle.Format = Config.fm

                            'Tamaño del campo de descripción
                            If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width + .Columns(7).Width Then
                                .Columns(4).Width = 250
                            Else
                                .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - .Columns(7).Width - 43
                            End If

                            For Each c As DataGridViewColumn In .Columns
                                c.HeaderText = c.HeaderText.ToUpper
                                c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                            Next
                        End With
                    End If
                Else
                    Dim rpt As New rptCardAuxiliar

                    Dim tObj As CrystalDecisions.CrystalReports.Engine.TextObject
                    tObj = rpt.Section1.ReportObjects("txtCodigo")
                    tObj.Text = "CÓDIGO: " & Codigo
                    tObj = rpt.Section1.ReportObjects("txtDescripcion")
                    tObj.Text = "DESCRIPCIÓN: " & Descripcion
                    tObj = rpt.Section1.ReportObjects("txtInicio")
                    tObj.Text = "DESDE: " & dtpInicio.Value.ToLongDateString().ToUpper
                    tObj = rpt.Section1.ReportObjects("txtFinal")
                    tObj.Text = "HASTA: " & dtpFinal.Value.ToLongDateString().ToUpper

                    rpt.SetDataSource(consulta)
                    CrystalReportViewer1.ReportSource = rpt
                End If
            Else
                dtRegistro.DataSource = Nothing
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmTargetAuxiliar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub frmTargetAuxiliar_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnFecha.Left = pnBuscar.Width - 243
    End Sub

    Private Sub frmTargetAuxiliar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        frmTargetAuxiliar_Resize(Nothing, Nothing)
        dtpInicio.Value = DateTime.Now
        dtpFinal.Value = DateTime.Now
        Me.FormLoad = True
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyData = Keys.Enter Then
            btBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        txtCodigo.Text = txtCodigo.Text.Replace(" ", "")
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicio.ValueChanged
        If Me.FormLoad Then
            If txtIdCuenta.Text.Trim <> "" Then
                Me.List()
            Else
                txtCodigo.Focus()
            End If
        End If
    End Sub

    Private Sub dtpFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFinal.ValueChanged
        If Me.FormLoad Then
            If txtIdCuenta.Text.Trim <> "" Then
                Me.List()
            Else
                txtCodigo.Focus()
            End If
        End If
    End Sub

    'Metodo para buscar
    Public Sub Buscar()
        Try
            If txtCodigo.Text.Trim = "" And txtIdCuenta.Text.Trim <> "" Then
                Dim c = Account.Find(Guid.Parse(txtIdCuenta.Text.Trim))
                If Not c Is Nothing Then
                    If c.Nivel = 6 Then
                        txtIdCuenta.Text = c.IDCuenta.ToString()
                        txtDescripcion.Text = c.CodigoCompleto & " " & c.Descripcion
                        Me.List(c.CodigoCompleto, c.Descripcion)
                        txtCodigo.Clear()
                        txtCodigo.Focus()
                    Else
                        dtRegistro.Visible = True
                        dtRegistro.DataSource = Nothing
                        Config.MsgErr("Solo se pueden cargar cuentas de Ultimo Nivel.")
                    End If
                Else
                    dtRegistro.Visible = True
                    dtRegistro.DataSource = Nothing
                    Config.MsgErr("No se cuentra una cuenta con el código " & txtDescripcion.Text.Trim)
                End If
                Me.List()
                txtCodigo.Clear()
                txtCodigo.Focus()
            Else
                Dim c = Account.Find(txtCodigo.Text)
                If Not c Is Nothing Then
                    If c.Nivel = 6 Then
                        txtIdCuenta.Text = c.IDCuenta.ToString()
                        txtDescripcion.Text = c.CodigoCompleto & " " & c.Descripcion
                        Me.List()
                        txtCodigo.Clear()
                        txtCodigo.Focus()
                    Else
                        Config.MsgErr("Solo se pueden cargar cuentas de Ultimo Nivel.")
                    End If
                Else
                    Config.MsgErr("No se encuentra ninguna cuenta con este código.")
                End If
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Public Sub Buscar(ByVal c As entAccount)
        Try
            If Not c Is Nothing Then
                If c.Nivel = 6 Then
                    txtIdCuenta.Text = c.IDCuenta.ToString()
                    txtDescripcion.Text = c.CodigoCompleto & " " & c.Descripcion
                    Me.List(c.CodigoCompleto, c.Descripcion)
                    txtCodigo.Clear()
                    txtCodigo.Focus()
                Else
                    Config.MsgErr("Solo se pueden cargar cuentas de Ultimo Nivel.")
                End If
            Else
                Config.MsgErr("No se encuentra ninguna cuenta con este código.")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        dtRegistro.Visible = True
        Buscar()
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        Limpiar()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        dtRegistro.Visible = False
        Buscar()
    End Sub

    Private Sub btBuscarCuenta_Click(sender As Object, e As EventArgs) Handles btBuscarCuenta.Click
        frmAccountList.FrmReturn = 2
        frmAccountList.ShowDialog()
        txtCodigo.Focus()
    End Sub
End Class