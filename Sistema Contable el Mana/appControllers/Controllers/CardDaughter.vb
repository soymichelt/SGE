Imports appModels
Public Module CardDaughter

    Public Function List(ByVal IdCUenta As Guid, ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entCardDaugther)
        Try
            Using db As New CodeFirst
                Return (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                 Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante Where cu.IDCuenta = IdCUenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo Select New entCardDaugther With {.IdCuenta = cu.IDCuenta, .IdComprobante = co.IDComprobante, .N = co.N, .Fecha = co.Fecha, .Concepto = co.Concepto, .Referencia = co.Referencia, .Deber = cd.Deber, .Haber = cd.Haber, .Saldo = cd.Saldo}).ToList
            End Using
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        End Try
    End Function

End Module
