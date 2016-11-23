Imports appModels

Public Module Inventario

    Public Function List(Optional ByVal _Codigo As String = "", Optional ByVal _Descripcion As String = "") As List(Of entAccount)
        Try
            Using db As New CodeFirst
                Return (From cu In Account.List() Where cu.IsProduct And cu.CodigoCompleto.Contains(_Codigo) And cu.Descripcion.Contains(_Descripcion) Select New entAccount With {
                     .IDCuenta = cu.IDCuenta,
                     .N = cu.N,
                     .Reg = cu.Reg,
                     .CodigoCompleto = cu.CodigoCompleto,
                     .Descripcion = cu.Descripcion,
                     .Entrada = cu.Entrada,
                     .Salida = cu.Salida,
                     .Existencia = cu.Existencia,
                     .Costo = cu.Costo,
                     .Deber = cu.Deber,
                     .Haber = cu.Haber,
                     .Saldo = cu.Saldo
                 }).ToList
            End Using
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        End Try
    End Function

End Module
