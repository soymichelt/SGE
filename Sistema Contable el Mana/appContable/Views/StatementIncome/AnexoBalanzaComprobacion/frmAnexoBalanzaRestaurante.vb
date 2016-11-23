Imports appControllers


Public Class frmAnexoBalanzaRestaurante

    Dim FormLoad As Boolean = False


    Sub List()
        Try
            dtRegistro.DataSource = (From c In AnexoBalanzaComprobacion.Balanza3(dtpInicio.Value.ToShortDateString & " 00:00:00", dtpFinal.Value.ToShortDateString & " 23:59:59") Select c.IdCuenta, c.Reg, Nivel = If(c.Nivel = 1, "Grupo", If(c.Nivel = 2, "Sub-Grupo", If(c.Nivel = 3, "Mayor", If(c.Nivel = 4, "Sub-Mayor", If(c.Nivel = 5, "Sub-Sub-Mayor", If(c.Nivel = 6, "Ultimo Nivel", "")))))), c.CodigoCompleto, c.Descripcion, c.DebeInicial, c.HaberInicial, c.DebeMes, c.HaberMes, c.DebeSaldo, c.HaberSaldo).ToList
            If dtRegistro.ColumnCount > 0 Then
                txtItem.Value = dtRegistro.RowCount
                With dtRegistro
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
                    .Columns(2).HeaderText = "Nivel" : .Columns(2).Width = 100
                    .Columns(3).HeaderText = "Código" : .Columns(3).Width = 100
                    .Columns(4).HeaderText = "Descripción de la Cuenta" : .Columns(4).Width = 250
                    .Columns(5).HeaderText = "Debe Inicial" : .Columns(5).Width = 115 : .Columns(5).DefaultCellStyle.Format = Config.fm
                    .Columns(6).HeaderText = "Haber Inicial" : .Columns(6).Width = 115 : .Columns(6).DefaultCellStyle.Format = Config.fm
                    .Columns(7).HeaderText = "Debe Mes" : .Columns(7).Width = 115 : .Columns(7).DefaultCellStyle.Format = Config.fm
                    .Columns(8).HeaderText = "Haber Mes" : .Columns(8).Width = 115 : .Columns(8).DefaultCellStyle.Format = Config.fm
                    .Columns(9).HeaderText = "Debe Final" : .Columns(9).Width = 115 : .Columns(9).DefaultCellStyle.Format = Config.fm
                    .Columns(10).HeaderText = "Haber Final" : .Columns(10).Width = 115 : .Columns(10).DefaultCellStyle.Format = Config.fm
                    'Tamaño del campo de descripción
                    If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width + .Columns(7).Width + .Columns(8).Width + .Columns(9).Width + .Columns(10).Width Then
                        .Columns(4).Width = 250
                    Else
                        .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - .Columns(7).Width - .Columns(8).Width - .Columns(9).Width - .Columns(10).Width - 43
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
        dtRegistro.DataSource = (From c In (New List(Of entBalanzaComprobacion)) Select c.IdCuenta, c.Reg, c.Nivel, c.CodigoCompleto, c.Descripcion, c.DebeInicial, c.HaberInicial, c.DebeMes, c.HaberMes, c.DebeSaldo, c.HaberSaldo).ToList
        txtItem.Value = 0
        With dtRegistro
            .Columns(0).Visible = False
            .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
            .Columns(2).HeaderText = "Nivel" : .Columns(2).Width = 100
            .Columns(3).HeaderText = "Código" : .Columns(3).Width = 100
            .Columns(4).HeaderText = "Descripción de la Cuenta" : .Columns(4).Width = 250
            .Columns(5).HeaderText = "Debe Inicial" : .Columns(5).Width = 115 : .Columns(5).DefaultCellStyle.Format = Config.fm
            .Columns(6).HeaderText = "Haber Inicial" : .Columns(6).Width = 115 : .Columns(6).DefaultCellStyle.Format = Config.fm
            .Columns(7).HeaderText = "Debe Mes" : .Columns(7).Width = 115 : .Columns(7).DefaultCellStyle.Format = Config.fm
            .Columns(8).HeaderText = "Haber Mes" : .Columns(8).Width = 115 : .Columns(8).DefaultCellStyle.Format = Config.fm
            .Columns(9).HeaderText = "Debe Final" : .Columns(9).Width = 115 : .Columns(9).DefaultCellStyle.Format = Config.fm
            .Columns(10).HeaderText = "Haber Final" : .Columns(10).Width = 115 : .Columns(10).DefaultCellStyle.Format = Config.fm
            'Tamaño del campo de descripción
            If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width + .Columns(7).Width + .Columns(8).Width + .Columns(9).Width + .Columns(10).Width Then
                .Columns(4).Width = 250
            Else
                .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - .Columns(7).Width - .Columns(8).Width - .Columns(9).Width - .Columns(10).Width - 43
            End If

            For Each c As DataGridViewColumn In .Columns
                c.HeaderText = c.HeaderText.ToUpper
                c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
            Next
        End With
    End Sub

    Private Sub frmBalanzaConsolidado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtItem.Value = 0
        Me.txtItem.DisplayFormat = Config.fn
        Me.WindowState = FormWindowState.Maximized
        dtpInicio.Value = DateTime.Now
        dtpFinal.Value = DateTime.Now
        Grid()
        Me.FormLoad = True
    End Sub

    Private Sub frmBalanzaConsolidado_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnFecha.Left = pnBuscar.Width - 243
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
        Grid()
        dtpInicio.Value = DateTime.Now
        dtpFinal.Value = DateTime.Now

    End Sub

    Private Sub btImprimir_Click(sender As Object, e As EventArgs) Handles btImprimir.Click
        Try
            Dim rpt As New rptAnexoBalanceComprobacionHeladeria

            Dim tObj As CrystalDecisions.CrystalReports.Engine.TextObject
            tObj = rpt.Section1.ReportObjects("txtInicio")
            tObj.Text = "DESDE: " & dtpInicio.Value.ToLongDateString().ToUpper
            tObj = rpt.Section1.ReportObjects("txtFinal")
            tObj.Text = "HASTA: " & dtpFinal.Value.ToLongDateString().ToUpper

            rpt.SetDataSource((From c In AnexoBalanzaComprobacion.Balanza2(dtpInicio.Value.ToShortDateString & " 00:00:00", dtpFinal.Value.ToShortDateString & " 23:59:59") Select c.IdCuenta, c.Reg, c.Nivel, Codigo = c.CodigoCompleto, c.Descripcion, c.DebeInicial, c.HaberInicial, c.DebeMes, c.HaberMes, c.DebeSaldo, c.HaberSaldo).ToList)
            frmReport.crvVisual.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

End Class