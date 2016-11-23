Imports appModels


Public Module AnexoBalanzaComprobacion

    Dim lst As New List(Of entBalanzaComprobacion)
    Dim i As entBalanzaComprobacion
    Dim Sum As New List(Of entSaldo)
    Dim Initial As entSaldo

    Public Function Balanza1(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entBalanzaComprobacion)
        AnexoBalanzaComprobacion.lst = New List(Of entBalanzaComprobacion)
        If Inicio < Config.FechaInicio Or Final < Config.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Config.FechaInicio.ToShortDateString() & "'")
        End If

        Using db As New CodeFirst
            For Each item In (Account.List().Where(Function(f) f.Nivel = 3 Or f.Nivel = 4 Or f.Nivel = 5 Or f.Nivel = 6).ToList)
                i = New entBalanzaComprobacion
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                'Consulta para obtener los saldos iniciales
                Select Case item.Nivel
                    Case 3
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cd.IDCuentaMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                             Order By cd.N Descending _
                             Take 1 _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberMayor,
                                 .Haber = cd.HaberMayor,
                                 .Saldo = cd.SaldoMayor _
                             }).FirstOrDefault
                    Case 4
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cd.IDCuentaSubMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                             Order By cd.N Descending _
                             Take 1 _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberSubMayor,
                                 .Haber = cd.HaberSubMayor,
                                 .Saldo = cd.SaldoSubMayor _
                             }).FirstOrDefault
                    Case 5
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                                 Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                                 Where cd.IDCuentaSubSubMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                                 Order By cd.N Descending _
                                 Take 1 _
                                 Select New entSaldo With { _
                                     .Debe = cd.DeberSubSubMayor,
                                     .Haber = cd.HaberSubSubMayor,
                                     .Saldo = cd.SaldoSubSubMayor _
                                 }).FirstOrDefault
                    Case 6
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                                 Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                                 Where cd.IDCuenta = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                                 Order By cd.N Descending _
                                 Take 1 _
                                 Select New entSaldo With { _
                                     .Debe = cd.DeberUltimoNivel,
                                     .Haber = cd.HaberUltimoNivel,
                                     .Saldo = cd.SaldoUltimoNivel _
                                 }).FirstOrDefault
                End Select

                'SaldoInicial
                If Not AnexoBalanzaComprobacion.Initial Is Nothing Then
                    If item.Naturaleza Then
                        i.DebeInicial = AnexoBalanzaComprobacion.Initial.Debe
                    Else
                        i.HaberInicial = AnexoBalanzaComprobacion.Initial.Haber
                    End If
                End If

                'Consulta para obtener los saldos del mes
                Select Case item.Nivel
                    Case 3
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cd.IDCuentaMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                             Order By cd.N Descending _
                             Take 1 _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberMayor,
                                 .Haber = cd.HaberMayor,
                                 .Saldo = cd.SaldoMayor _
                             }).FirstOrDefault
                    Case 4
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cd.IDCuentaSubMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                             Order By cd.N Descending _
                             Take 1 _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberSubMayor,
                                 .Haber = cd.HaberSubMayor,
                                 .Saldo = cd.SaldoSubMayor _
                             }).FirstOrDefault
                    Case 5
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                            Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                            Where cd.IDCuentaSubSubMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                            Order By cd.N Descending _
                            Take 1 _
                            Select New entSaldo With { _
                                .Debe = cd.DeberSubSubMayor,
                                .Haber = cd.HaberSubSubMayor,
                                .Saldo = cd.SaldoSubSubMayor _
                            }).FirstOrDefault
                    Case 6
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                            Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                            Where cd.IDCuenta = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                            Order By cd.N Descending _
                            Take 1 _
                            Select New entSaldo With { _
                                .Debe = cd.DeberUltimoNivel,
                                .Haber = cd.HaberUltimoNivel,
                                .Saldo = cd.SaldoUltimoNivel _
                            }).FirstOrDefault
                End Select


                'SaldoMes
                If Not AnexoBalanzaComprobacion.Initial Is Nothing Then
                    'SaldoFinal
                    i.DebeSaldo = AnexoBalanzaComprobacion.Initial.Debe 'If(Count > 0, Sum.Sum(Function(f) f.Debe), 0.0)
                    i.HaberSaldo = AnexoBalanzaComprobacion.Initial.Haber 'If(Count > 0, Sum.Sum(Function(f) f.Haber), 0.0)
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
        AnexoBalanzaComprobacion.lst = New List(Of entBalanzaComprobacion)
        If Inicio < Config.FechaInicio Or Final < Config.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Config.FechaInicio.ToShortDateString() & "'")
        End If

        Using db As New CodeFirst
            For Each item In (Account.List().Where(Function(f) f.SubMayor = Config.Neg1 And (f.Nivel = 5 Or f.Nivel = 6)).ToList)
                i = New entBalanzaComprobacion
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                'Consulta para obtener los saldos iniciales
                Select Case item.Nivel
                    Case 5
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                                 Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                                 Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                                 Order By cd.N Descending _
                                 Take 1 _
                                 Select New entSaldo With { _
                                     .Debe = cd.DeberSubSubMayor,
                                     .Haber = cd.HaberSubSubMayor,
                                     .Saldo = cd.SaldoSubSubMayor _
                                 }).FirstOrDefault
                    Case 6
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                                 Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                                 Where cu.IdUltimoNivel = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                                 Order By cd.N Descending _
                                 Take 1 _
                                 Select New entSaldo With { _
                                     .Debe = cd.DeberUltimoNivel,
                                     .Haber = cd.HaberUltimoNivel,
                                     .Saldo = cd.SaldoUltimoNivel _
                                 }).FirstOrDefault
                End Select

                'SaldoInicial
                If Not AnexoBalanzaComprobacion.Initial Is Nothing Then
                    If item.Naturaleza Then
                        i.DebeInicial = AnexoBalanzaComprobacion.Initial.Debe
                    Else
                        i.HaberInicial = AnexoBalanzaComprobacion.Initial.Haber
                    End If
                End If

                'Consulta para obtener los saldos del mes
                Select Case item.Nivel
                    Case 5
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                            Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                            Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                            Order By cd.N Descending _
                            Take 1 _
                            Select New entSaldo With { _
                                .Debe = cd.DeberSubSubMayor,
                                .Haber = cd.HaberSubSubMayor,
                                .Saldo = cd.SaldoSubSubMayor _
                            }).FirstOrDefault
                    Case 6
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                            Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                            Where cu.IdUltimoNivel = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                            Order By cd.N Descending _
                            Take 1 _
                            Select New entSaldo With { _
                                .Debe = cd.DeberUltimoNivel,
                                .Haber = cd.HaberUltimoNivel,
                                .Saldo = cd.SaldoUltimoNivel _
                            }).FirstOrDefault
                End Select

                If Not AnexoBalanzaComprobacion.Initial Is Nothing Then
                    'SaldoFinal
                    i.DebeSaldo = AnexoBalanzaComprobacion.Initial.Debe 'If(Count > 0, Sum.Sum(Function(f) f.Debe), 0.0)
                    i.HaberSaldo = AnexoBalanzaComprobacion.Initial.Haber 'If(Count > 0, Sum.Sum(Function(f) f.Haber), 0.0)
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
        AnexoBalanzaComprobacion.lst = New List(Of entBalanzaComprobacion)
        If Inicio < Config.FechaInicio Or Final < Config.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Config.FechaInicio.ToShortDateString() & "'")
        End If

        Using db As New CodeFirst
            For Each item In (Account.List().Where(Function(f) f.SubMayor = Config.Neg2 And (f.Nivel = 5 Or f.Nivel = 6)).ToList)
                i = New entBalanzaComprobacion
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                'Consulta para obtener los saldos iniciales
                Select Case item.Nivel
                    Case 5
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                                 Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                                 Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                                 Order By cd.N Descending _
                                 Take 1 _
                                 Select New entSaldo With { _
                                     .Debe = cd.DeberSubSubMayor,
                                     .Haber = cd.HaberSubSubMayor,
                                     .Saldo = cd.SaldoSubSubMayor _
                                 }).FirstOrDefault
                    Case 6
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                                 Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                                 Where cu.IdUltimoNivel = i.IdCuenta And co.Fecha < Inicio And co.Activo _
                                 Order By cd.N Descending _
                                 Take 1 _
                                 Select New entSaldo With { _
                                     .Debe = cd.DeberUltimoNivel,
                                     .Haber = cd.HaberUltimoNivel,
                                     .Saldo = cd.SaldoUltimoNivel _
                                 }).FirstOrDefault
                End Select

                'SaldoInicial
                If Not AnexoBalanzaComprobacion.Initial Is Nothing Then
                    If item.Naturaleza Then
                        i.DebeInicial = AnexoBalanzaComprobacion.Initial.Debe
                    Else
                        i.HaberInicial = AnexoBalanzaComprobacion.Initial.Haber
                    End If
                End If

                'Consulta para obtener los saldos del mes
                Select Case item.Nivel
                    Case 5
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                            Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                            Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                            Order By cd.N Descending _
                            Take 1 _
                            Select New entSaldo With { _
                                .Debe = cd.DeberSubSubMayor,
                                .Haber = cd.HaberSubSubMayor,
                                .Saldo = cd.SaldoSubSubMayor _
                            }).FirstOrDefault
                    Case 6
                        AnexoBalanzaComprobacion.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                            Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                            Where cu.IdUltimoNivel = i.IdCuenta And co.Fecha >= Inicio And co.Fecha <= Final And co.Activo _
                            Order By cd.N Descending _
                            Take 1 _
                            Select New entSaldo With { _
                                .Debe = cd.DeberUltimoNivel,
                                .Haber = cd.HaberUltimoNivel,
                                .Saldo = cd.SaldoUltimoNivel _
                            }).FirstOrDefault
                End Select

                If Not AnexoBalanzaComprobacion.Initial Is Nothing Then
                    'SaldoFinal
                    i.DebeSaldo = AnexoBalanzaComprobacion.Initial.Debe 'If(Count > 0, Sum.Sum(Function(f) f.Debe), 0.0)
                    i.HaberSaldo = AnexoBalanzaComprobacion.Initial.Haber 'If(Count > 0, Sum.Sum(Function(f) f.Haber), 0.0)
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
