Imports appModels

Public Module BalanzaComprobacion
    Dim lst As New List(Of entBalanzaComprobacion)
    Dim i As entBalanzaComprobacion
    Dim Sum As New List(Of entSaldo)
    Dim Initial As entSaldo


    Public Function Balanza1(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entBalanzaComprobacion)
        BalanzaComprobacion.lst = New List(Of entBalanzaComprobacion)
        If Inicio < Configuracion.FechaInicio Or Final < Configuracion.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Configuracion.FechaInicio.ToShortDateString() & "'")
        End If

        Using db As New CodeFirst
            For Each item In (Account.List().Where(Function(f) f.Nivel = 3).ToList)
                i = New entBalanzaComprobacion
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion


                'Consulta para obtener los saldos iniciales
                BalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                     Where cu.IdMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                     Order By cd.N Descending _
                     Take 1 _
                     Select New entSaldo With { _
                         .Debe = cd.DeberMayor,
                         .Haber = cd.HaberMayor,
                         .Saldo = cd.SaldoMayor _
                     }).FirstOrDefault


                'SaldoInicial
                If Not BalanzaComprobacion.Initial Is Nothing Then
                    If item.Naturaleza Then
                        i.DebeInicial = BalanzaComprobacion.Initial.Saldo
                    Else
                        i.HaberInicial = BalanzaComprobacion.Initial.Saldo
                    End If
                End If


                'Consulta para obtener los saldos del mes
                BalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                     Where cu.IdMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                     Order By cd.N Descending _
                     Take 1 _
                     Select New entSaldo With { _
                         .Debe = cd.DeberMayor,
                         .Haber = cd.HaberMayor,
                         .Saldo = cd.SaldoMayor _
                     }).FirstOrDefault


                'SaldoMes
                If Not BalanzaComprobacion.Initial Is Nothing Then
                    'SaldoFinal
                    i.DebeSaldo = BalanzaComprobacion.Initial.Debe 'If(Count > 0, Sum.Sum(Function(f) f.Debe), 0.0)
                    i.HaberSaldo = BalanzaComprobacion.Initial.Haber 'If(Count > 0, Sum.Sum(Function(f) f.Haber), 0.0)
                    'Saldo del Mes
                    i.DebeMes = i.DebeSaldo - i.DebeInicial
                    i.HaberMes = i.HaberSaldo - i.HaberInicial
                Else
                    i.DebeSaldo = i.DebeInicial
                    i.HaberSaldo = i.HaberInicial
                End If


                'se agrega a la lista
                lst.Add(i)
            Next
        End Using
        Return lst
    End Function

    Public Function Balanza2(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entBalanzaComprobacion)
        BalanzaComprobacion.lst = New List(Of entBalanzaComprobacion)
        If Inicio < Configuracion.FechaInicio Or Final < Configuracion.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Configuracion.FechaInicio.ToShortDateString() & "'")
        End If

        Using db As New CodeFirst
            For Each item In (Account.List().Where(Function(f) f.SubMayor = Config.Neg1 And f.Nivel = 5).ToList)
                i = New entBalanzaComprobacion
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion


                'Consulta para obtener los saldos iniciales
                BalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                     Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                     Order By cd.N Descending _
                     Take 1 _
                     Select New entSaldo With { _
                         .Debe = cd.DeberSubSubMayor,
                         .Haber = cd.HaberSubSubMayor,
                         .Saldo = cd.SaldoSubSubMayor _
                     }).FirstOrDefault


                'SaldoInicial
                If Not BalanzaComprobacion.Initial Is Nothing Then
                    If item.Naturaleza Then
                        i.DebeInicial = BalanzaComprobacion.Initial.Saldo
                    Else
                        i.HaberInicial = BalanzaComprobacion.Initial.Saldo
                    End If
                End If


                'Consulta para obtener los saldos del mes
                BalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                     Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                     Order By cd.N Descending _
                     Take 1 _
                     Select New entSaldo With { _
                         .Debe = cd.Deber,
                         .Haber = cd.Haber,
                         .Saldo = cd.Saldo _
                     }).FirstOrDefault


                'SaldoMes
                If Not BalanzaComprobacion.Initial Is Nothing Then
                    'SaldoFinal
                    i.DebeSaldo = BalanzaComprobacion.Initial.Debe 'If(Count > 0, Sum.Sum(Function(f) f.Debe), 0.0)
                    i.HaberSaldo = BalanzaComprobacion.Initial.Haber 'If(Count > 0, Sum.Sum(Function(f) f.Haber), 0.0)
                    'Saldo del Mes
                    i.DebeMes = i.DebeSaldo - i.DebeInicial
                    i.HaberMes = i.HaberSaldo - i.HaberInicial
                Else
                    i.DebeSaldo = i.DebeInicial
                    i.HaberSaldo = i.HaberInicial
                End If


                'se agrega a la lista
                lst.Add(i)
            Next
        End Using
        Return lst
    End Function

    Public Function Balanza3(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entBalanzaComprobacion)
        BalanzaComprobacion.lst = New List(Of entBalanzaComprobacion)
        If Inicio < Configuracion.FechaInicio Or Final < Configuracion.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Configuracion.FechaInicio.ToShortDateString() & "'")
        End If

        Using db As New CodeFirst
            For Each item In (Account.List().Where(Function(f) f.SubMayor = Config.Neg2 And f.Nivel = 5).ToList)
                i = New entBalanzaComprobacion
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion


                'Consulta para obtener los saldos iniciales
                BalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                     Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                     Order By cd.N Descending _
                     Take 1
                     Select New entSaldo With { _
                         .Debe = cd.Deber,
                         .Haber = cd.Haber,
                         .Saldo = cd.Saldo _
                     }).FirstOrDefault


                'SaldoInicial
                If Not BalanzaComprobacion.Initial Is Nothing Then
                    If item.Naturaleza Then
                        i.DebeInicial = BalanzaComprobacion.Initial.Saldo
                    Else
                        i.HaberInicial = BalanzaComprobacion.Initial.Saldo
                    End If
                End If

                'Consulta para obtener los saldos del mes
                BalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                     Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                     Select New entSaldo With { _
                         .Debe = cd.Deber,
                         .Haber = cd.Haber,
                         .Saldo = cd.Saldo _
                     }).FirstOrDefault


                'SaldoMes
                If Not BalanzaComprobacion.Initial Is Nothing Then
                    'SaldoFinal
                    i.DebeSaldo = BalanzaComprobacion.Initial.Debe 'If(Count > 0, Sum.Sum(Function(f) f.Debe), 0.0)
                    i.HaberSaldo = BalanzaComprobacion.Initial.Haber 'If(Count > 0, Sum.Sum(Function(f) f.Haber), 0.0)
                    'Saldo del Mes
                    i.DebeMes = i.DebeSaldo - i.DebeInicial
                    i.HaberMes = i.HaberSaldo - i.HaberInicial
                Else
                    i.DebeSaldo = i.DebeInicial
                    i.HaberSaldo = i.HaberInicial
                End If


                'se agrega a la lista
                lst.Add(i)
            Next
        End Using
        Return lst
    End Function

End Module
