Imports appModels
Public Module EntriesAccounting

    Public Function Count() As Long
        Using db As New CodeFirst
            Dim c = db.ComprobantesDiarios.OrderByDescending(Function(f) f.N).FirstOrDefault
            If Not c Is Nothing Then
                Return c.N + 1
            Else
                Return 1
            End If
        End Using
    End Function

    Public Function Save(ByVal Comprobante As ComprobanteDiario, ByVal Detalle As List(Of entComprobanteDiarioDetalle)) As Guid
        Using db As New CodeFirst
            'Ingresar comprobante
            Comprobante.IDComprobante = Guid.NewGuid
            Comprobante.Reg = DateTime.Now
            Comprobante.FMod = Comprobante.Reg
            Comprobante.Haber = Detalle.Sum(Function(f) f.Haber)
            Comprobante.Deber = Detalle.Sum(Function(f) f.Deber)
            Comprobante.Activo = True
            db.ComprobantesDiarios.Add(Comprobante)

            'variables temporales
            Dim Grupo As Cuenta
            Dim IdGrupo As Nullable(Of Guid)
            Dim Nivel As Short

            'Detalle
            For Each item In Detalle
                Dim c = db.Cuentas.Where(Function(f) f.Activo And f.IDCuenta = item.IdCuenta).FirstOrDefault
                If Not c Is Nothing Then
                    Dim ExistenciaAnterior As Decimal = c.Existencia
                    Dim Costo, CostoPromedio As Decimal
                    'modificar saldos en la cuenta
                    If item.Deber > 0 Then
                        item.Haber = 0 : item.Salida = 0

                        'Validacion de salida cuentas con inventario
                        If c.IsProduct Then
                            If Not c.Naturaleza Then
                                item.Deber = c.Costo * item.Entrada
                            End If
                            c.Entrada = c.Entrada + item.Entrada
                            c.Existencia = If(c.Naturaleza, c.Existencia + item.Entrada, c.Existencia - item.Entrada)
                        End If

                        'Se valida que los saldos sean validos
                        'If If(c.Naturaleza, c.Saldo + item.Deber, c.Saldo - item.Deber) < 0 Then
                        '    Throw New Exception("El saldo de la cuenta '" & c.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                        'End If

                        'Se actualizan saldos
                        c.Deber = c.Deber + item.Deber
                        c.Saldo = If(c.Naturaleza, c.Saldo + item.Deber, c.Saldo - item.Deber)

                        'Calculo de Costos
                        If c.IsProduct Then
                            If c.Existencia > 0 Then
                                c.Costo = c.Saldo / c.Existencia
                                CostoPromedio = c.Costo
                            Else
                                c.Costo = 0
                            End If
                            If c.Entrada > 0 Then
                                Costo = item.Deber / item.Entrada
                            Else
                                Costo = 0
                            End If
                        End If
                    ElseIf item.Haber > 0 Then
                        item.Deber = 0 : item.Entrada = 0

                        'Validacion de salida cuentas con inventario
                        If c.IsProduct Then
                            If c.Naturaleza Then
                                item.Haber = c.Costo * item.Salida
                            End If
                            c.Salida = c.Salida + item.Salida
                            c.Existencia = If(c.Naturaleza, c.Existencia - item.Salida, c.Existencia + item.Salida)
                        End If

                        'Se valida que los saldos sean validos
                        'If If(c.Naturaleza, c.Saldo - item.Haber, c.Saldo + item.Haber) < 0 Then
                        '    Throw New Exception("El saldo de la cuenta '" & c.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                        'End If

                        'Se actualizan saldos
                        c.Haber = c.Haber + item.Haber
                        c.Saldo = If(c.Naturaleza, c.Saldo - item.Haber, c.Saldo + item.Haber)

                        'Calculo de Costos
                        If c.IsProduct Then
                            If c.Existencia > 0 Then
                                c.Costo = c.Saldo / c.Existencia
                                CostoPromedio = c.Costo
                            Else
                                c.Costo = 0
                            End If
                            If c.Salida > 0 Then
                                Costo = c.Haber / item.Salida
                            Else
                                Costo = 0
                            End If
                        End If
                    Else
                        'Throw New Exception("Ingresar el 'Deber' o el 'Haber' de la cuenta: " & c.Descripcion)
                    End If

                    item.DeberUltimoNivel = c.Deber
                    item.HaberUltimoNivel = c.Haber
                    item.SaldoUltimoNivel = c.Saldo

                    db.Entry(c).State = Entity.EntityState.Modified

                    'Recorrer grupos superiores
                    IdGrupo = c.IDCuentaGrupo
                    If Not IdGrupo Is Nothing Then
                        Nivel = c.Nivel
                        While Nivel > 0
                            If Not IdGrupo Is Nothing Then
                                Grupo = db.Cuentas.Where(Function(f) f.IDCuenta = IdGrupo And f.Activo).FirstOrDefault
                                If item.Deber > 0 Then
                                    Grupo.Deber = Grupo.Deber + item.Deber
                                    'If If(Grupo.Naturaleza, Grupo.Saldo + item.Deber, Grupo.Saldo - item.Deber) < 0 Then
                                    '    Throw New Exception("El saldo de la cuenta '" & Grupo.Grupo & Grupo.SubGrupo & Grupo.Mayor & Grupo.SubMayor & Grupo.SubSubMayor & " " & Grupo.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                                    'End If
                                    Grupo.Saldo = If(Grupo.Naturaleza, Grupo.Saldo + item.Deber, Grupo.Saldo - item.Deber)
                                ElseIf item.Haber > 0 Then
                                    Grupo.Haber = Grupo.Haber + item.Haber
                                    'If If(Grupo.Naturaleza, Grupo.Saldo - item.Haber, Grupo.Saldo + item.Haber) < 0 Then
                                    '    Throw New Exception("El saldo de la cuenta '" & Grupo.Grupo & Grupo.SubGrupo & Grupo.Mayor & Grupo.SubMayor & Grupo.SubSubMayor & " " & Grupo.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                                    'End If
                                    Grupo.Saldo = If(Grupo.Naturaleza, Grupo.Saldo - item.Haber, Grupo.Saldo + item.Haber)
                                End If
                                db.Entry(Grupo).State = Entity.EntityState.Modified
                                db.SaveChanges()

                                'Cargar saldos en el detalle de las cuentas de grupo
                                Select Case Grupo.Nivel
                                    Case 1
                                        item.IDCuentaGrupo = Grupo.IDCuenta
                                        item.DeberGrupo = Grupo.Deber
                                        item.HaberGrupo = Grupo.Haber
                                        item.SaldoGrupo = Grupo.Saldo
                                    Case 2
                                        item.IDCuentaSubGrupo = Grupo.IDCuenta
                                        item.DeberSubGrupo = Grupo.Deber
                                        item.HaberSubGrupo = Grupo.Haber
                                        item.SaldoSubGrupo = Grupo.Saldo
                                    Case 3
                                        item.IDCuentaMayor = Grupo.IDCuenta
                                        item.DeberMayor = Grupo.Deber
                                        item.HaberMayor = Grupo.Haber
                                        item.SaldoMayor = Grupo.Saldo
                                    Case 4
                                        item.IDCuentaSubMayor = Grupo.IDCuenta
                                        item.DeberSubMayor = Grupo.Deber
                                        item.HaberSubMayor = Grupo.Haber
                                        item.SaldoSubMayor = Grupo.Saldo
                                    Case 5
                                        item.IDCuentaSubSubMayor = Grupo.IDCuenta
                                        item.DeberSubSubMayor = Grupo.Deber
                                        item.HaberSubSubMayor = Grupo.Haber
                                        item.SaldoSubSubMayor = Grupo.Saldo
                                End Select
                                'Fin cargar saldo

                                IdGrupo = Grupo.IDCuentaGrupo
                            End If


                            'decremento
                            Nivel = Nivel - 1
                        End While
                    End If
                    'Fin

                    'Registrar el detalle
                    db.ComprobantesDiariosDetalles.Add(
                            New ComprobanteDiarioDetalle With {
                                .IDDetalle = Guid.NewGuid,
                                .Reg = DateTime.Now,
                                .FMod = .Reg,
                                .IDComprobante = Comprobante.IDComprobante,
                                .IDCuenta = c.IDCuenta,
                                .Deber = item.Deber,
                                .Haber = item.Haber,
                                .Saldo = c.Saldo,
                                .Entrada = item.Entrada,
                                .Salida = item.Salida,
                                .Existencia = ExistenciaAnterior,
                                .Costo = Costo,
                                .CostoPromedio = CostoPromedio,
                                .EntradaProd = c.Entrada,
                                .SalidaProd = c.Salida,
                                .ExistenciaProd = c.Existencia,
                                .IDCuentaGrupo = item.IDCuentaGrupo,
                                .DeberGrupo = item.DeberGrupo,
                                .HaberGrupo = item.HaberGrupo,
                                .SaldoGrupo = item.SaldoGrupo,
                                .IDCuentaSubGrupo = item.IDCuentaSubGrupo,
                                .DeberSubGrupo = item.DeberSubGrupo,
                                .HaberSubGrupo = item.HaberSubGrupo,
                                .SaldoSubGrupo = item.SaldoSubGrupo,
                                .IDCuentaMayor = item.IDCuentaMayor,
                                .DeberMayor = item.DeberMayor,
                                .HaberMayor = item.HaberMayor,
                                .SaldoMayor = item.SaldoMayor,
                                .IDCuentaSubMayor = item.IDCuentaSubMayor,
                                .DeberSubMayor = item.DeberSubMayor,
                                .HaberSubMayor = item.HaberSubMayor,
                                .SaldoSubMayor = item.SaldoSubMayor,
                                .IDCuentaSubSubMayor = item.IDCuentaSubSubMayor,
                                .DeberSubSubMayor = item.DeberSubSubMayor,
                                .HaberSubSubMayor = item.HaberSubSubMayor,
                                .SaldoSubSubMayor = item.SaldoSubSubMayor,
                                .DeberUltimoNivel = item.DeberUltimoNivel,
                                .HaberUltimoNivel = item.HaberUltimoNivel,
                        .SaldoUltimoNivel = item.SaldoUltimoNivel
                            })
                    'Fin

                Else
                    'Throw New Exception("La cuenta '" & item.Descripcion & "' no se encuentra. Probablemente ha sido eliminada.")
                End If
            Next
            db.SaveChanges()
            Return Comprobante.IDComprobante
        End Using
    End Function

    Public Sub Edit(ByVal Comprobante As ComprobanteDiario)
        If Comprobante.Fecha < Config.FechaInicio Then
            Throw New Exception("La fecha debe ser mayor a " & Config.FechaInicio.ToShortDateString)
        End If
        If String.IsNullOrWhiteSpace(Comprobante.Concepto) Then
            Throw New Exception("Ingresar el concepto")
        End If
        If String.IsNullOrWhiteSpace(Comprobante.Referencia) Then
            Throw New Exception("Ingresar la referencia")
        End If
        Using db As New CodeFirst
            Dim c = db.ComprobantesDiarios.Where(Function(f) f.IDComprobante = Comprobante.IDComprobante).FirstOrDefault
            If Not c Is Nothing Then
                c.Fecha = Comprobante.Fecha
                c.Concepto = Comprobante.Concepto
                c.Referencia = Comprobante.Referencia

                db.Entry(c).State = Entity.EntityState.Modified
                db.SaveChanges()
            Else
                Throw New Exception("No se encuentra este Comprobante. Probablemente ha sido eliminado.")
            End If
        End Using
    End Sub

    Public Function Test(ByVal Comprobante As ComprobanteDiario, ByVal Detalle As List(Of entComprobanteDiarioDetalle)) As Boolean
        If Not Comprobante Is Nothing And Not Detalle Is Nothing Then
            If Comprobante.Fecha < Config.FechaInicio Then
                Throw New Exception("La fecha debe ser mayor a " & Config.FechaInicio.ToShortDateString)
            End If
            If String.IsNullOrWhiteSpace(Comprobante.Concepto) Then
                Throw New Exception("Ingresar el concepto")
            End If
            If String.IsNullOrWhiteSpace(Comprobante.Referencia) Then
                Throw New Exception("Ingresar la referencia")
            End If
            If Detalle.Count = 0 Then
                Throw New Exception("Ingrsar el detalle")
            End If
            If Detalle.Sum(Function(f) f.Deber) <> Detalle.Sum(Function(f) f.Haber) Then
                Throw New Exception("La suma del Deber tiene que ser igual a la suma del Haber")
            End If
            Using db As New CodeFirst
                'Detalle
                For Each item In Detalle
                    Dim c = db.Cuentas.Where(Function(f) f.Activo And f.IDCuenta = item.IdCuenta).FirstOrDefault
                    If Not c Is Nothing Then
                        'Dim ExistenciaAnterior As Decimal = c.Existencia
                        'Dim Costo, CostoPromedio As Decimal
                        'modificar saldos en la cuenta
                        If item.Deber > 0 Then
                            'Se valida que los saldos sean validos
                            If If(c.Naturaleza, c.Saldo + item.Deber, c.Saldo - item.Deber) < 0 Then
                                Throw New Exception("El saldo de la cuenta '" & c.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                            End If
                        ElseIf item.Haber > 0 Then
                            'Se valida que los saldos sean validos
                            If If(c.Naturaleza, c.Saldo - item.Haber, c.Saldo + item.Haber) < 0 Then
                                Throw New Exception("El saldo de la cuenta '" & c.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                            End If
                        Else
                            Throw New Exception("Ingresar el 'Deber' o el 'Haber' de la cuenta: " & c.Descripcion)
                        End If

                        'Recorrer grupos superiores
                        'IdGrupo = c.IDCuentaGrupo
                        'If Not IdGrupo Is Nothing Then
                        '    Nivel = c.Nivel
                        '    While Nivel > 0
                        '        If Not IdGrupo Is Nothing Then
                        '            Grupo = db.Cuentas.Where(Function(f) f.IDCuenta = IdGrupo And f.Activo).FirstOrDefault
                        '            If item.Deber > 0 Then
                        '                Grupo.Deber = Grupo.Deber + item.Deber
                        '                If If(Grupo.Naturaleza, Grupo.Saldo + item.Deber, Grupo.Saldo - item.Deber) < 0 Then
                        '                    Throw New Exception("El saldo de la cuenta '" & Grupo.Grupo & Grupo.SubGrupo & Grupo.Mayor & Grupo.SubMayor & Grupo.SubSubMayor & " " & Grupo.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                        '                End If
                        '                Grupo.Saldo = If(Grupo.Naturaleza, Grupo.Saldo + item.Deber, Grupo.Saldo - item.Deber)
                        '            ElseIf item.Haber > 0 Then
                        '                Grupo.Haber = Grupo.Haber + item.Haber
                        '                If If(Grupo.Naturaleza, Grupo.Saldo - item.Haber, Grupo.Saldo + item.Haber) < 0 Then
                        '                    Throw New Exception("El saldo de la cuenta '" & Grupo.Grupo & Grupo.SubGrupo & Grupo.Mayor & Grupo.SubMayor & Grupo.SubSubMayor & " " & Grupo.Descripcion & "' es inferior a la cantidad que intentas decrementar")
                        '                End If
                        '                Grupo.Saldo = If(Grupo.Naturaleza, Grupo.Saldo - item.Haber, Grupo.Saldo + item.Haber)
                        '            End If
                        '            db.Entry(Grupo).State = Entity.EntityState.Modified
                        '            db.SaveChanges()

                        '            'Cargar saldos en el detalle de las cuentas de grupo
                        '            Select Case Grupo.Nivel
                        '                Case 1
                        '                    item.IDCuentaGrupo = Grupo.IDCuenta
                        '                    item.DeberGrupo = Grupo.Deber
                        '                    item.HaberGrupo = Grupo.Haber
                        '                    item.SaldoGrupo = Grupo.Saldo
                        '                Case 2
                        '                    item.IDCuentaSubGrupo = Grupo.IDCuenta
                        '                    item.DeberSubGrupo = Grupo.Deber
                        '                    item.HaberSubGrupo = Grupo.Haber
                        '                    item.SaldoSubGrupo = Grupo.Saldo
                        '                Case 3
                        '                    item.IDCuentaMayor = Grupo.IDCuenta
                        '                    item.DeberMayor = Grupo.Deber
                        '                    item.HaberMayor = Grupo.Haber
                        '                    item.SaldoMayor = Grupo.Saldo
                        '                Case 4
                        '                    item.IDCuentaSubMayor = Grupo.IDCuenta
                        '                    item.DeberSubMayor = Grupo.Deber
                        '                    item.HaberSubMayor = Grupo.Haber
                        '                    item.SaldoSubMayor = Grupo.Saldo
                        '                Case 5
                        '                    item.IDCuentaSubSubMayor = Grupo.IDCuenta
                        '                    item.DeberSubSubMayor = Grupo.Deber
                        '                    item.HaberSubSubMayor = Grupo.Haber
                        '                    item.SaldoSubSubMayor = Grupo.Saldo
                        '            End Select
                        '            'Fin cargar saldo

                        '            IdGrupo = Grupo.IDCuentaGrupo
                        '        End If


                        '        'decremento
                        '        Nivel = Nivel - 1
                        '    End While
                        'End If
                        'Fin

                    Else
                        Throw New Exception("La cuenta '" & item.Descripcion & "' no se encuentra. Probablemente ha sido eliminada.")
                    End If
                Next
                Return True
            End Using
        Else
            Throw New Exception("No se mandaron los datos")
        End If
    End Function

    Public Function Find(ByVal N As Long) As ComprobanteDiario
        Using db As New CodeFirst
            Return db.ComprobantesDiarios.Where(Function(f) f.N = N).FirstOrDefault
        End Using
    End Function

    Public Function Find(ByVal IDComprobante As Guid) As ComprobanteDiario
        Using db As New CodeFirst
            Return db.ComprobantesDiarios.Where(Function(f) f.IDComprobante = IDComprobante).FirstOrDefault
        End Using
    End Function

    Public Function List(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entEntriesAccounting)
        Using db As New CodeFirst
            Return (From co In db.ComprobantesDiarios Where co.Activo And co.Fecha >= Inicio And co.Fecha <= Final Order By co.Fecha Select New entEntriesAccounting With {.IdComprobante = co.IDComprobante, .N = co.N, .Reg = co.Reg, .FMod = co.FMod, .Fecha = co.Fecha, .Concepto = co.Concepto, .Referencia = co.Referencia, .Deber = co.Deber, .Haber = co.Haber, .Activo = co.Activo}).ToList
        End Using
    End Function

    Public Function EntrieDetails(ByVal IDComprobante As Guid) As List(Of entComprobanteDiarioDetalle)
        Using db As New CodeFirst
            Return (From co In db.ComprobantesDiarios.AsParallel() Join cd In db.ComprobantesDiariosDetalles.AsParallel() On co.IDComprobante Equals cd.IDComprobante Join cu In Account.List().AsParallel() On cd.IDCuenta Equals cu.IDCuenta _
                Where co.Activo And co.IDComprobante = IDComprobante _
                Order By cd.N
                Select New entComprobanteDiarioDetalle With _
                       {
                            .IdCuenta = cu.IDCuenta,
                            .Reg = cu.Reg,
                            .CodigoCompleto = cu.CodigoCompleto,
                            .Descripcion = cu.Descripcion,
                            .Naturaleza = cu.Naturaleza,
                            .Deber = cd.Deber,
                            .Haber = cd.Haber,
                            .Saldo = cd.Saldo
                       } _
                ).ToList
        End Using
    End Function

    Public Function FindDetails(ByVal IDComprobante As Guid) As List(Of entEntriesAccountingDetails)
        Using db As New CodeFirst
            Return (From co In db.ComprobantesDiarios.AsParallel() Join cd In db.ComprobantesDiariosDetalles.AsParallel() On co.IDComprobante Equals cd.IDComprobante Join cu In Account.List().AsParallel() On cd.IDCuenta Equals cu.IDCuenta _
                Where co.Activo And co.IDComprobante = IDComprobante _
                Order By cd.N
                Select New entEntriesAccountingDetails With _
                       {
                           .IdComprobante = co.IDComprobante,
                            .N = co.N,
                            .RegC = co.Reg,
                            .FModC = co.FMod,
                            .Fecha = co.Fecha,
                            .Concepto = co.Concepto,
                            .Referencia = co.Referencia,
                            .Activo = co.Activo,
                            .IdCuenta = cu.IDCuenta,
                            .RegD = cd.Reg,
                            .FModD = cd.FMod,
                            .CodigoCompleto = cu.CodigoCompleto,
                            .IdGrupo = cu.IdGrupo,
                            .Grupo = cu.Grupo,
                            .IdSubGrupo = cu.IdSubGrupo,
                            .SubGrupo = cu.SubGrupo,
                            .IdMayor = cu.IdMayor,
                            .Mayor = cu.Mayor,
                            .IdSubMayor = cu.IdSubMayor,
                            .SubMayor = cu.SubMayor,
                            .IdSubSubMayor = cu.IdSubSubMayor,
                            .SubSubMayor = cu.SubSubMayor,
                            .IdUltimoNivel = cu.IdUltimoNivel,
                            .UltimoNivel = cu.UltimoNivel,
                            .Descripcion = cu.Descripcion,
                            .Naturaleza = cu.Naturaleza,
                            .Deber = cd.Deber,
                            .Haber = cd.Haber,
                            .Saldo = cd.Saldo
                       } _
                ).ToList
        End Using
    End Function

    Public Function ListDetails(ByVal Inicio As DateTime, ByVal Final As DateTime, Optional ByVal IdCuenta As Nullable(Of Guid) = Nothing) As List(Of entEntriesAccountingDetails)
        Using db As New CodeFirst
            If Not IdCuenta Is Nothing Then
                Return ( _
                From co In db.ComprobantesDiarios.AsParallel() Join cd In db.ComprobantesDiariosDetalles.AsParallel() On co.IDComprobante Equals cd.IDComprobante Join cu In Account.List().AsParallel() On cd.IDCuenta Equals cu.IDCuenta _
                Where co.Activo And co.Fecha >= Inicio And co.Fecha <= Final And cu.IDCuenta = IdCuenta _
                Order By cd.N
                Select New entEntriesAccountingDetails With _
                       {
                           .IdComprobante = co.IDComprobante,
                            .N = co.N,
                            .RegC = co.Reg,
                            .FModC = co.FMod,
                            .Fecha = co.Fecha,
                            .Concepto = co.Concepto,
                            .Referencia = co.Referencia,
                            .Activo = co.Activo,
                            .IdCuenta = cu.IDCuenta,
                            .RegD = cd.Reg,
                            .FModD = cd.FMod,
                            .CodigoCompleto = cu.CodigoCompleto,
                            .IdGrupo = cu.IdGrupo,
                            .Grupo = cu.Grupo,
                            .IdSubGrupo = cu.IdSubGrupo,
                            .SubGrupo = cu.SubGrupo,
                            .IdMayor = cu.IdMayor,
                            .Mayor = cu.Mayor,
                            .IdSubMayor = cu.IdSubMayor,
                            .SubMayor = cu.SubMayor,
                            .IdSubSubMayor = cu.IdSubSubMayor,
                            .SubSubMayor = cu.SubSubMayor,
                            .IdUltimoNivel = cu.IdUltimoNivel,
                            .UltimoNivel = cu.UltimoNivel,
                            .Descripcion = cu.Descripcion,
                            .Naturaleza = cu.Naturaleza,
                            .Deber = cd.Deber,
                            .Haber = cd.Haber,
                            .Saldo = cd.Saldo
                       } _
                ).ToList
            Else
                Return ( _
                From co In db.ComprobantesDiarios.AsParallel() Join cd In db.ComprobantesDiariosDetalles.AsParallel() On co.IDComprobante Equals cd.IDComprobante Join cu In Account.List().AsParallel() On cd.IDCuenta Equals cu.IDCuenta _
                Where co.Activo And co.Fecha >= Inicio And co.Fecha <= Final _
                Order By cd.N
                Select New entEntriesAccountingDetails With _
                       {
                           .IdComprobante = co.IDComprobante,
                            .N = co.N,
                            .RegC = co.Reg,
                            .FModC = co.FMod,
                            .Fecha = co.Fecha,
                            .Concepto = co.Concepto,
                            .Referencia = co.Referencia,
                            .Activo = co.Activo,
                            .IdCuenta = cu.IDCuenta,
                            .RegD = cd.Reg,
                            .FModD = cd.FMod,
                            .CodigoCompleto = cu.CodigoCompleto,
                            .IdGrupo = cu.IdGrupo,
                            .Grupo = cu.Grupo,
                            .IdSubGrupo = cu.IdSubGrupo,
                            .SubGrupo = cu.SubGrupo,
                            .IdMayor = cu.IdMayor,
                            .Mayor = cu.Mayor,
                            .IdSubMayor = cu.IdSubMayor,
                            .SubMayor = cu.SubMayor,
                            .IdSubSubMayor = cu.IdSubSubMayor,
                            .SubSubMayor = cu.SubSubMayor,
                            .IdUltimoNivel = cu.IdUltimoNivel,
                            .UltimoNivel = cu.UltimoNivel,
                            .Descripcion = cu.Descripcion,
                            .Naturaleza = cu.Naturaleza,
                            .Deber = cd.Deber,
                            .Haber = cd.Haber,
                            .Saldo = cd.Saldo
                       } _
                ).ToList
            End If
        End Using
    End Function

    Public Sub Delete(ByVal IDComprobante As Guid)
        Using db As New CodeFirst
            Dim c = db.ComprobantesDiarios.Where(Function(f) f.Activo And f.IDComprobante = IDComprobante).FirstOrDefault
            If Not c Is Nothing Then
                c.Activo = False

                For Each item In c.ComprobantesDiariosDetalles

                Next

                db.Entry(c).State = Entity.EntityState.Modified
                db.SaveChanges()
            End If
        End Using
    End Sub


End Module
