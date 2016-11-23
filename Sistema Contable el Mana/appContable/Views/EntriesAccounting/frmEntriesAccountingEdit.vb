Imports appControllers

Public Class frmEntriesAccountingEdit

    Public Property IDComprobante As Guid = Guid.Empty

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Try
            Dim c = EntriesAccounting.Find(Me.IDComprobante)
            If Not c Is Nothing Then

                'Se rellenan los datos
                c.Fecha = dtpFecha.Value
                c.Concepto = txtConcepto.Text
                c.Referencia = txtReferencia.Text

                'Se manda a editar
                EntriesAccounting.Edit(c)
                Config.MsgInfo("Comprobante Editado")
                Me.Close()
            Else
                Config.MsgErr("No se encuentra este comprobante. Probablemente ha sido eliminado.")
                Me.Close()
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmEntriesAccountingEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim c = EntriesAccounting.Find(Me.IDComprobante)
            If Not c Is Nothing Then
                txtNComprobante.Value = c.N
                dtpFecha.Value = c.Fecha
                txtConcepto.Text = c.Concepto
                txtReferencia.Text = c.Referencia
                dtpFecha.Focus()
            Else
                Config.MsgErr("No se encuentra este comprobante. Probablemente ha sido eliminado.")
                Me.Close()
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub
End Class