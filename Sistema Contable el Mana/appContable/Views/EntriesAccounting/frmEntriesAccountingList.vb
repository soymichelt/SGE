Imports appControllers

Public Class frmEntriesAccountingList

    Dim FormLoad As Boolean = False

    Sub List()
        Try
            dtRegistro.DataSource = (From c In EntriesAccounting.List(dtpInicio.Value.ToShortDateString & " 00:00:00", dtpFinal.Value.ToShortDateString & " 23:59:59") Select c.IdComprobante, Anulado = If(c.Activo, "", "Anulado"), c.Reg, c.N, c.Fecha, c.Concepto, c.Referencia, c.Deber, c.Haber).ToList
            If dtRegistro.ColumnCount > 0 Then
                txtItem.Value = dtRegistro.RowCount
                With dtRegistro
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = vbNewLine & " " & vbNewLine : .Columns(1).Width = 100
                    .Columns(2).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(2).Width = 130
                    .Columns(3).HeaderText = "Nº Comprobante" : .Columns(3).Width = 150 : .Columns(3).DefaultCellStyle.Format = Config.fn
                    .Columns(4).HeaderText = "Fecha" : .Columns(4).Width = 130
                    .Columns(5).HeaderText = "Concepto" : .Columns(5).Width = 350
                    .Columns(6).HeaderText = "Referencia" : .Columns(6).Width = 200
                    .Columns(7).HeaderText = "Haber" : .Columns(7).Width = 140 : .Columns(7).DefaultCellStyle.Format = Config.fm
                    .Columns(8).HeaderText = "Deber" : .Columns(8).Width = 140 : .Columns(8).DefaultCellStyle.Format = Config.fm

                    'Tamaño del campo de descripción
                    If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width + .Columns(7).Width + .Columns(8).Width Then
                        .Columns(4).Width = 250
                    Else
                        .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - .Columns(7).Width - .Columns(8).Width
                    End If

                    For Each c As DataGridViewColumn In .Columns
                        c.HeaderText = c.HeaderText.ToUpper
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                    Next
                End With
            Else
                txtItem.Value = 0
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Sub Grid()
        dtRegistro.DataSource = (From c In (New List(Of entEntriesAccounting)) Select c.IdComprobante, Anulado = "", c.Reg, c.N, c.Fecha, c.Concepto, c.Referencia, c.Haber, c.Deber).ToList
        txtItem.Value = 0
        With dtRegistro
            .Columns(0).Visible = False
            .Columns(1).HeaderText = vbNewLine & " " & vbNewLine : .Columns(1).Width = 100
            .Columns(2).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(2).Width = 150
            .Columns(3).HeaderText = "Nº Comprobante" : .Columns(3).Width = 150 : .Columns(3).DefaultCellStyle.Format = Config.fn
            .Columns(4).HeaderText = "Fecha" : .Columns(4).Width = 130
            .Columns(5).HeaderText = "Concepto" : .Columns(5).Width = 350
            .Columns(6).HeaderText = "Referencia" : .Columns(6).Width = 200
            .Columns(7).HeaderText = "Haber" : .Columns(7).Width = 140 : .Columns(7).DefaultCellStyle.Format = Config.fm
            .Columns(8).HeaderText = "Deber" : .Columns(8).Width = 140 : .Columns(8).DefaultCellStyle.Format = Config.fm


            For Each c As DataGridViewColumn In .Columns
                c.HeaderText = c.HeaderText.ToUpper
                c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
            Next
        End With
    End Sub

    Sub ListDetails(ByVal IDComprobante As Guid)
        Try
            Dim Query = EntriesAccounting.EntrieDetails(IDComprobante)
            dtDetalle.DataSource = (From c In Query Select c.IdCuenta, c.Reg, c.CodigoCompleto, c.Descripcion, Naturaleza = If(c.Naturaleza, "Deudora", "Acreedora"), c.Deber, c.Haber, c.Saldo).ToList
            If dtDetalle.ColumnCount > 0 Then
                With dtDetalle
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
                    .Columns(2).HeaderText = "Código" : .Columns(2).Width = 120
                    .Columns(3).HeaderText = "Descripción de la Cuenta" : .Columns(3).Width = 300
                    .Columns(4).HeaderText = "Naturaleza" : .Columns(4).Width = 130
                    .Columns(5).HeaderText = "Deber" : .Columns(5).Width = 150 : .Columns(5).DefaultCellStyle.Format = Config.fm : .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(6).HeaderText = "Haber" : .Columns(6).Width = 150 : .Columns(6).DefaultCellStyle.Format = Config.fm : .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns(7).HeaderText = "Saldo" : .Columns(7).Width = 150 : .Columns(7).DefaultCellStyle.Format = Config.fm : .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    For Each c As DataGridViewColumn In .Columns
                        c.HeaderText = c.HeaderText.ToUpper
                        c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                    Next
                End With
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmEntriesAccountingList_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnFecha.Left = pnBuscar.Width - 243
    End Sub

    Private Sub frmEntriesAccountingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        frmEntriesAccountingList_Resize(Nothing, Nothing)

        dtpInicio.Value = DateTime.Now
        dtpFinal.Value = DateTime.Now

        Grid()
        Me.FormLoad = True
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicio.ValueChanged, dtpFinal.ValueChanged
        If Me.FormLoad Then
            Me.List()
        End If
    End Sub

    Private Sub btBuscar_Click(sender As Object, e As EventArgs) Handles btBuscar.Click
        Me.List()
    End Sub

    Private Sub btLimpiar_Click(sender As Object, e As EventArgs) Handles btLimpiar.Click
        dtpInicio.Value = DateTime.Now
        dtpFinal.Value = DateTime.Now
        Grid()
    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        Try
            Dim rpt As New rptAnexoBalanceComprobacionConsolidado

            Dim tObj As CrystalDecisions.CrystalReports.Engine.TextObject
            tObj = rpt.Section1.ReportObjects("txtInicio")
            tObj.Text = "DESDE: " & dtpInicio.Value.ToLongDateString().ToUpper
            tObj = rpt.Section1.ReportObjects("txtFinal")
            tObj.Text = "HASTA: " & dtpFinal.Value.ToLongDateString().ToUpper

            rpt.SetDataSource((From c In AnexoBalanzaComprobacion.Balanza1(dtpInicio.Value.ToShortDateString & " 00:00:00", dtpFinal.Value.ToShortDateString & " 23:59:59") Select c.IdCuenta, c.Reg, c.Nivel, Codigo = c.CodigoCompleto, c.Descripcion, c.DebeInicial, c.HaberInicial, c.DebeMes, c.HaberMes, c.DebeSaldo, c.HaberSaldo).ToList)
            frmReport.crvVisual.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub dtRegistro_SelectionChanged(sender As Object, e As EventArgs) Handles dtRegistro.SelectionChanged
        If Me.FormLoad Then
            Try
                If dtRegistro.SelectedRows.Count > 0 Then
                    Dim c = EntriesAccounting.Find(Guid.Parse(dtRegistro.SelectedRows(0).Cells(0).Value.ToString()))
                    If Not c Is Nothing Then
                        If c.Activo Then
                            expDetalle.TitleText = "Mostrar detalle del Comprobante Diario No. " & c.N.ToString(Config.fn)
                            Me.ListDetails(Guid.Parse(dtRegistro.SelectedRows(0).Cells(0).Value.ToString()))
                        Else
                            dtDetalle.DataSource = Nothing
                            expDetalle.TitleText = "Mostrar detalle del Comprobante Diario No. " & c.N.ToString(Config.fn) & " se encuentra anulado."
                        End If
                    Else
                        dtDetalle.DataSource = Nothing
                        expDetalle.TitleText = "No se encuentra este 'Comprobante Diario'. Probablemente ha sido eliminado."
                    End If
                Else
                    dtDetalle.DataSource = Nothing
                End If
            Catch ex As Exception
                Config.MsgErr(ex.Message)
            End Try
        End If
    End Sub
End Class