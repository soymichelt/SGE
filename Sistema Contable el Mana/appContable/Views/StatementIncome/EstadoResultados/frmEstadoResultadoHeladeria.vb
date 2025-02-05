﻿Imports appControllers


Public Class frmEstadoResultadoHeladeria

    Dim FormLoad As Boolean = False

    Sub List()
        Config.LoadState("Estado de resultados heladeria cargando...")

        Try
            dtRegistro.DataSource = (From c In EstadoResultados.Estado2(dtpInicio.Value.ToShortDateString & " 00:00:00", dtpFinal.Value.ToShortDateString & " 23:59:59") Select c.IdCuenta, c.Reg, Nivel = If(c.Nivel = 1, "Grupo", If(c.Nivel = 2, "Sub-Grupo", If(c.Nivel = 3, "Mayor", If(c.Nivel = 4, "Sub-Mayor", If(c.Nivel = 5, "Sub-Sub-Mayor", If(c.Nivel = 6, "Ultimo Nivel", "")))))), c.CodigoCompleto, c.Descripcion, c.Col1, c.Col2).ToList
            If dtRegistro.ColumnCount > 0 Then
                txtItem.Value = dtRegistro.RowCount
                With dtRegistro
                    .Columns(0).Visible = False
                    .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
                    .Columns(2).HeaderText = "Nivel" : .Columns(2).Width = 100
                    .Columns(3).HeaderText = "Código" : .Columns(3).Width = 100
                    .Columns(4).HeaderText = "Descripción de la Cuenta" : .Columns(4).Width = 350
                    .Columns(5).HeaderText = "Columna 1" : .Columns(5).Width = 115 : .Columns(5).DefaultCellStyle.Format = Config.fm
                    .Columns(6).HeaderText = "Columna 2" : .Columns(6).Width = 115 : .Columns(6).DefaultCellStyle.Format = Config.fm
                    'Tamaño del campo de descripción
                    If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width Then
                        .Columns(4).Width = 250
                    Else
                        .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - 43
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

        Config.EndState()
    End Sub

    Sub Grid()
        dtRegistro.DataSource = (From c In (New List(Of entEstadoResultados)) Select c.IdCuenta, c.Reg, c.Nivel, c.CodigoCompleto, c.Descripcion, c.Col1, c.Col2).ToList
        txtItem.Value = 0
        With dtRegistro
            .Columns(0).Visible = False
            .Columns(1).HeaderText = vbNewLine & "Registrada" & vbNewLine : .Columns(1).Width = 120
            .Columns(2).HeaderText = "Nivel" : .Columns(2).Width = 100
            .Columns(3).HeaderText = "Código" : .Columns(3).Width = 100
            .Columns(4).HeaderText = "Descripción de la Cuenta" : .Columns(4).Width = 350
            .Columns(5).HeaderText = "Columna 1" : .Columns(5).Width = 115 : .Columns(5).DefaultCellStyle.Format = Config.fm
            .Columns(6).HeaderText = "Columna 2" : .Columns(6).Width = 115 : .Columns(6).DefaultCellStyle.Format = Config.fm
            'Tamaño del campo de descripción
            If dtRegistro.Width <= .Columns(1).Width + .Columns(2).Width + .Columns(3).Width + .Columns(4).Width + .Columns(5).Width + .Columns(6).Width Then
                .Columns(4).Width = 250
            Else
                .Columns(4).Width = dtRegistro.Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(5).Width - .Columns(6).Width - 43
            End If

            For Each c As DataGridViewColumn In .Columns
                c.HeaderText = c.HeaderText.ToUpper
                c.HeaderCell.Style.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
            Next
        End With
    End Sub

    Private Sub frmEstadoHeladeria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtItem.Value = 0
        Me.txtItem.DisplayFormat = Config.fn
        Me.WindowState = FormWindowState.Maximized
        dtpInicio.Value = DateTime.Now
        dtpFinal.Value = DateTime.Now
        Grid()
        Me.FormLoad = True
    End Sub

    Private Sub frmEstadoHeladeria_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnFecha.Left = pnBuscar.Width - 243
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As Object, e As EventArgs)
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
            Dim rpt As New rptEstadoResultadosHeladeria

            Dim tObj As CrystalDecisions.CrystalReports.Engine.TextObject
            tObj = rpt.Section1.ReportObjects("txtInicio")
            tObj.Text = "DESDE: " & dtpInicio.Value.ToLongDateString().ToUpper
            tObj = rpt.Section1.ReportObjects("txtFinal")
            tObj.Text = "HASTA: " & dtpFinal.Value.ToLongDateString().ToUpper

            rpt.SetDataSource((From c In EstadoResultados.Estado2(dtpInicio.Value.ToShortDateString & " 00:00:00", dtpFinal.Value.ToShortDateString & " 23:59:59") Select c.IdCuenta, c.Reg, c.Nivel, Codigo = c.CodigoCompleto, c.Descripcion, c.Col1, c.Col2).ToList)
            frmReport.crvVisual.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

End Class