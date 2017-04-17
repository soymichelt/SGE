Imports appModels

Public Module BalanceGeneral
    Dim lst As New List(Of entBalanceGeneral)
    Dim i As entBalanceGeneral
    Dim Initial As entSaldo
    Dim Sum As New List(Of entSaldo)
    Dim SumCir As Decimal = 0

    ''' <summary>
    ''' Representa un Balance General Consolidado
    ''' </summary>
    ''' <param name="Inicio">La Fecha de Inicio a partir de donde se seleccionaran los datos para generar el balance.</param>
    ''' <param name="Final">La Fecha de final antes de donde se seleccionaran los datos para generar el balance.</param>
    ''' <returns>Retorna un Tipo de colección con las cuentas del balance y sus saldos</returns>
    ''' <remarks></remarks>
    Public Function Balance1(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entBalanceGeneral)
        BalanceGeneral.lst = New List(Of entBalanceGeneral)
        If Inicio < Configuracion.FechaInicio Or Final < Configuracion.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Configuracion.FechaInicio.ToShortDateString() & "'")
        End If
        Dim tAct = 0, tPas = 0, tCap As Decimal = 0
        Dim tActCirc = 0, tActFijo = 0, tActDif = 0, tActOtros As Decimal = 0
        Dim tPasCirc As Decimal = 0
        Dim tCapCont As Decimal = 0

        Using db As New CodeFirst
            'Recorrer el listado de cuentas con los primeros 3 niveles
            For Each item In (Account.List().Where(Function(f) (f.Nivel = 1 Or f.Nivel = 2 Or f.Nivel = 3) And (f.Grupo = Config.accActivo Or f.Grupo = Config.accPasivo Or f.Grupo = Config.accCapital)).ToList)

                'SE AGREGA TOTAL DE ACTIVO CIRCULANTE
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActFijo Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO CIRCULANTE"
                    i.Col2 = tActCirc
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE ACTIVO FIJO
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActDiferido Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO FIJO"
                    i.Col2 = tActFijo
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE ACTIVO DIFERIDO
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActOtros Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO DIFERIDO"
                    i.Col2 = tActDif
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE OTROS ACTIVOS Y DE ACTIVOS GENERALES
                If item.Grupo = Config.accPasivo And item.Nivel = 1 Then
                    'Total de Otros Activos
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE OTROS ACTIVOS"
                    i.Col2 = tActOtros
                    lst.Add(i)

                    'Total de Activos
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVOS"
                    i.Col3 = tAct
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE PASIVO Y PASIVO CIRCULANTE
                If item.Grupo = Config.accCapital And item.Nivel = 1 Then
                    'Total Pasivo
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE PASIVO CIRCULANTE"
                    i.Col2 = tPasCirc
                    lst.Add(i)

                    'Total Pasivo Circulante
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE PASIVO CIRCULANTE"
                    i.Col3 = tPasCirc
                    lst.Add(i)
                End If

                'Se inicializa el item del balance general
                BalanceGeneral.i = New entBalanceGeneral
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                'Consulta para obtener los datos de las tarjetas auxiliares
                Select Case item.Nivel
                    Case 1
                        'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        BalanceGeneral.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdGrupo = i.IdCuenta And co.Fecha <= Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberGrupo,
                                 .Haber = cd.HaberGrupo,
                                 .Saldo = cd.SaldoGrupo _
                             }).FirstOrDefault

                        'cargas los saldos totales de las cuentas de grupo
                        If Not BalanceGeneral.Initial Is Nothing Then
                            Select Case item.Grupo
                                Case Config.accActivo
                                    tAct = BalanceGeneral.Initial.Saldo
                                Case Config.accPasivo
                                    tPas = BalanceGeneral.Initial.Saldo
                                Case Config.accCapital
                                    tCap = BalanceGeneral.Initial.Saldo
                            End Select
                        End If

                    Case 2
                        'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        BalanceGeneral.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdSubGrupo = i.IdCuenta And co.Fecha < Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberSubGrupo,
                                 .Haber = cd.HaberSubGrupo,
                                 .Saldo = cd.SaldoSubGrupo _
                             }).FirstOrDefault

                        'cargas los saldos totales de las cuentas de sub-grupo
                        If Not BalanceGeneral.Initial Is Nothing Then
                            Select Case item.SubGrupo
                                Case Config.accActCirculante
                                    If item.Grupo = Config.accActivo Then
                                        tActCirc = BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActFijo
                                    If item.Grupo = Config.accActivo Then
                                        tActFijo = BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActDiferido
                                    If item.Grupo = Config.accActivo Then
                                        tActDif = BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActOtros
                                    If item.Grupo = Config.accActivo Then
                                        tActOtros = BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accPasCirculante
                                    If item.Grupo = Config.accPasivo Then
                                        tPasCirc = BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accCapitalContable
                                    If item.Grupo = Config.accCapital Then
                                        tCapCont = BalanceGeneral.Initial.Saldo
                                    End If
                            End Select
                        End If
                    Case 3
                        'Dim Test = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                        '     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                        '     Where cu.IdMayor = i.IdCuenta And co.Fecha < Final And co.Activo _
                        '     Order By cd.N Descending _
                        '     Select cu.Descripcion, cd.N, N_Comprobante = co.N, cd.DeberMayor, cd.HaberMayor, cd.SaldoMayor).FirstOrDefault

                        'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        BalanceGeneral.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdMayor = i.IdCuenta And co.Fecha < Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberMayor,
                                 .Haber = cd.HaberMayor,
                                 .Saldo = cd.SaldoMayor _
                             }).FirstOrDefault

                        'cargas los saldos totales de las cuentas de mayor
                        If Not BalanceGeneral.Initial Is Nothing Then
                            If item.Grupo = Config.accActivo Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                End If
                            ElseIf item.Grupo = Config.accPasivo Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                End If
                            ElseIf item.Grupo = Config.accCapital Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                End If
                            End If
                        End If
                End Select

                'Se agrega la cuenta en la lista
                lst.Add(i)
            Next

            'SE AGREGA TOTAL DE CAPITAL Y CAPITAL CONTABLE
            'Total Pasivo
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE CAPITAL CONTABLE"
            i.Col2 = tCapCont
            lst.Add(i)

            'Total Pasivo Circulante
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE CAPITAL"
            i.Col3 = tCap
            lst.Add(i)

            'SE AGREGA TOTAL DEL CAPITAL MAS PASIVO
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE PASIVO MAS CAPITAL CONTABLE"
            i.Col3 = tPas + tCap
            lst.Add(i)

        End Using
        Return BalanceGeneral.lst
    End Function

    ''' <summary>
    ''' Representa un Balance General Heladería el Maná
    ''' </summary>
    ''' <param name="Inicio">La Fecha de Inicio a partir de donde se seleccionaran los datos para generar el balance general de la herladería.</param>
    ''' <param name="Final">La Fecha de final antes de donde se seleccionaran los datos para generar el balance general de la heladería.</param>
    ''' <returns>Retorna un Tipo de colección con las cuentas del balance y sus saldos</returns>
    ''' <remarks></remarks>
    Public Function Balance2(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entBalanceGeneral)
        BalanceGeneral.lst = New List(Of entBalanceGeneral)
        If Inicio < Configuracion.FechaInicio Or Final < Configuracion.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Configuracion.FechaInicio.ToShortDateString() & "'")
        End If
        Dim tAct = 0, tPas = 0, tCap As Decimal = 0
        Dim tActCirc = 0, tActFijo = 0, tActDif = 0, tActOtros As Decimal = 0
        Dim tPasCirc As Decimal = 0
        Dim tCapCont As Decimal = 0

        Using db As New CodeFirst
            'Recorrer el listado de cuentas con los primeros 3 niveles
            For Each item In (Account.List().Where(Function(f) (f.Nivel = 1 Or f.Nivel = 2 Or (f.Nivel = 5 And f.SubMayor = Config.Neg1)) And (f.Grupo = Config.accActivo Or f.Grupo = Config.accPasivo Or f.Grupo = Config.accCapital)).ToList)

                'SE AGREGA TOTAL DE ACTIVO CIRCULANTE
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActFijo Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO CIRCULANTE"
                    i.Col2 = tActCirc
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE ACTIVO FIJO
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActDiferido Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO FIJO"
                    i.Col2 = tActFijo
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE ACTIVO DIFERIDO
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActOtros Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO DIFERIDO"
                    i.Col2 = tActDif
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE OTROS ACTIVOS Y DE ACTIVOS GENERALES
                If item.Grupo = Config.accPasivo And item.Nivel = 1 Then
                    'Total de Otros Activos
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE OTROS ACTIVOS"
                    i.Col2 = tActOtros
                    lst.Add(i)

                    'Total de Activos
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVOS"
                    i.Col3 = tAct
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE PASIVO Y PASIVO CIRCULANTE
                If item.Grupo = Config.accCapital And item.Nivel = 1 Then
                    'Total Pasivo
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE PASIVO CIRCULANTE"
                    i.Col2 = tPasCirc
                    lst.Add(i)

                    'Total Pasivo Circulante
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE PASIVO CIRCULANTE"
                    i.Col3 = tPasCirc
                    lst.Add(i)
                End If

                'Se inicializa el item del balance general
                BalanceGeneral.i = New entBalanceGeneral
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                'Consulta para obtener los datos de las tarjetas auxiliares
                Select Case item.Nivel
                    Case 1
                        ''Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        'BalanceGeneral.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                        '     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                        '     Where cu.IdGrupo = i.IdCuenta And co.Fecha <= Final And co.Activo _
                        '     Order By co.Fecha Descending _
                        '     Select New entSaldo With { _
                        '         .Debe = cd.Deber,
                        '         .Haber = cd.Haber,
                        '         .Saldo = cd.Saldo _
                        '     }).FirstOrDefault

                        ''cargas los saldos totales de las cuentas de grupo
                        'If Not BalanceGeneral.Initial Is Nothing Then
                        '    Select Case item.Grupo
                        '        Case Config.accActivo
                        '            tAct = BalanceGeneral.Initial.Saldo
                        '        Case Config.accPasivo
                        '            tPas = BalanceGeneral.Initial.Saldo
                        '        Case Config.accCapital
                        '            tCap = BalanceGeneral.Initial.Saldo
                        '    End Select
                        'End If
                    Case 2
                        ''Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        'BalanceGeneral.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                        '     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                        '     Where cu.IdSubGrupo = i.IdCuenta And co.Fecha < Final And co.Activo _
                        '     Order By cd.N Descending _
                        '     Select New entSaldo With { _
                        '         .Debe = cd.DeberSubGrupo,
                        '         .Haber = cd.HaberSubGrupo,
                        '         .Saldo = cd.SaldoSubGrupo _
                        '     }).FirstOrDefault

                        ''cargas los saldos totales de las cuentas de sub-grupo
                        'If Not BalanceGeneral.Initial Is Nothing Then
                        '    Select Case item.SubGrupo
                        '        Case Config.accActCirculante
                        '            If item.Grupo = Config.accActivo Then
                        '                tActCirc = BalanceGeneral.Initial.Saldo
                        '            End If
                        '        Case Config.accActFijo
                        '            If item.Grupo = Config.accActivo Then
                        '                tActFijo = BalanceGeneral.Initial.Saldo
                        '            End If
                        '        Case Config.accActDiferido
                        '            If item.Grupo = Config.accActivo Then
                        '                tActDif = BalanceGeneral.Initial.Saldo
                        '            End If
                        '        Case Config.accActOtros
                        '            If item.Grupo = Config.accActivo Then
                        '                tActOtros = BalanceGeneral.Initial.Saldo
                        '            End If
                        '        Case Config.accPasCirculante
                        '            If item.Grupo = Config.accPasivo Then
                        '                tPasCirc = BalanceGeneral.Initial.Saldo
                        '            End If
                        '        Case Config.accCapitalContable
                        '            If item.Grupo = Config.accCapital Then
                        '                tCapCont = BalanceGeneral.Initial.Saldo
                        '            End If
                        '    End Select
                        'End If
                    Case 5
                        BalanceGeneral.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha < Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberSubSubMayor,
                                 .Haber = cd.HaberSubSubMayor,
                                 .Saldo = cd.SaldoSubSubMayor _
                             }).FirstOrDefault

                        'cargas los saldos totales de las cuentas de mayor
                        If Not BalanceGeneral.Initial Is Nothing Then

                            'Se acumulan saldos de grupo
                            Select Case item.Grupo
                                Case Config.accActivo
                                    tAct += BalanceGeneral.Initial.Saldo
                                Case Config.accPasivo
                                    tPas += BalanceGeneral.Initial.Saldo
                                Case Config.accCapital
                                    tCap += BalanceGeneral.Initial.Saldo
                            End Select

                            'Se acumulan saldos de sub grupo
                            Select Case item.SubGrupo
                                Case Config.accActCirculante
                                    If item.Grupo = Config.accActivo Then
                                        tActCirc += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActFijo
                                    If item.Grupo = Config.accActivo Then
                                        tActFijo += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActDiferido
                                    If item.Grupo = Config.accActivo Then
                                        tActDif += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActOtros
                                    If item.Grupo = Config.accActivo Then
                                        tActOtros += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accPasCirculante
                                    If item.Grupo = Config.accPasivo Then
                                        tPasCirc += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accCapitalContable
                                    If item.Grupo = Config.accCapital Then
                                        tCapCont += BalanceGeneral.Initial.Saldo
                                    End If
                            End Select


                            If item.Grupo = Config.accActivo Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                End If
                            ElseIf item.Grupo = Config.accPasivo Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                End If
                            ElseIf item.Grupo = Config.accCapital Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                End If
                            End If
                        End If
                End Select
                lst.Add(i)
            Next

            'SE AGREGA TOTAL DE CAPITAL Y CAPITAL CONTABLE
            'Total Pasivo
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE CAPITAL CONTABLE"
            i.Col2 = tCapCont
            lst.Add(i)

            'Total Pasivo Circulante
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE CAPITAL"
            i.Col3 = tCap
            lst.Add(i)

            'SE AGREGA TOTAL DEL CAPITAL MAS PASIVO
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE PASIVO MAS CAPITAL CONTABLE"
            i.Col3 = tPas + tCap
            lst.Add(i)

        End Using

        Return lst
    End Function

    ''' <summary>
    ''' Representa un Balance General Restaurante el Maná
    ''' </summary>
    ''' <param name="Inicio">La Fecha de Inicio a partir de donde se seleccionaran los datos para generar el balance general del restaurante.</param>
    ''' <param name="Final">La Fecha de final antes de donde se seleccionaran los datos para generar el balance general del restaurante.</param>
    ''' <returns>Retorna un Tipo de colección con las cuentas del balance y sus saldos</returns>
    ''' <remarks></remarks>
    Public Function Balance3(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entBalanceGeneral)
        BalanceGeneral.lst = New List(Of entBalanceGeneral)
        If Inicio < Configuracion.FechaInicio Or Final < Configuracion.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Configuracion.FechaInicio.ToShortDateString() & "'")
        End If
        Dim tAct = 0, tPas = 0, tCap As Decimal = 0
        Dim tActCirc = 0, tActFijo = 0, tActDif = 0, tActOtros As Decimal = 0
        Dim tPasCirc As Decimal = 0
        Dim tCapCont As Decimal = 0

        Using db As New CodeFirst
            'Recorrer el listado de cuentas con los primeros 3 niveles
            For Each item In (Account.List().Where(Function(f) (f.Nivel = 1 Or f.Nivel = 2 Or (f.Nivel = 5 And f.SubMayor = Config.Neg2)) And (f.Grupo = Config.accActivo Or f.Grupo = Config.accPasivo Or f.Grupo = Config.accCapital)).ToList)

                'SE AGREGA TOTAL DE ACTIVO CIRCULANTE
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActFijo Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO CIRCULANTE"
                    i.Col2 = tActCirc
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE ACTIVO FIJO
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActDiferido Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO FIJO"
                    i.Col2 = tActFijo
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE ACTIVO DIFERIDO
                If item.Grupo = Config.accActivo And item.Nivel = 2 And item.SubGrupo = Config.accActOtros Then
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVO DIFERIDO"
                    i.Col2 = tActDif
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE OTROS ACTIVOS Y DE ACTIVOS GENERALES
                If item.Grupo = Config.accPasivo And item.Nivel = 1 Then
                    'Total de Otros Activos
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE OTROS ACTIVOS"
                    i.Col2 = tActOtros
                    lst.Add(i)

                    'Total de Activos
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE ACTIVOS"
                    i.Col3 = tAct
                    lst.Add(i)
                End If

                'SE AGREGA TOTAL DE PASIVO Y PASIVO CIRCULANTE
                If item.Grupo = Config.accCapital And item.Nivel = 1 Then
                    'Total Pasivo
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE PASIVO CIRCULANTE"
                    i.Col2 = tPasCirc
                    lst.Add(i)

                    'Total Pasivo Circulante
                    i = New entBalanceGeneral
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "TOTAL DE PASIVO CIRCULANTE"
                    i.Col3 = tPasCirc
                    lst.Add(i)
                End If

                'Se inicializa el item del balance general
                BalanceGeneral.i = New entBalanceGeneral
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                'Consulta para obtener los datos de las tarjetas auxiliares
                Select Case item.Nivel
                    Case 1

                    Case 2

                    Case 5
                        BalanceGeneral.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha < Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberSubSubMayor,
                                 .Haber = cd.HaberSubSubMayor,
                                 .Saldo = cd.SaldoSubSubMayor _
                             }).FirstOrDefault

                        'cargas los saldos totales de las cuentas de mayor
                        If Not BalanceGeneral.Initial Is Nothing Then

                            'Se acumulan saldos de grupo
                            Select Case item.Grupo
                                Case Config.accActivo
                                    tAct += BalanceGeneral.Initial.Saldo
                                Case Config.accPasivo
                                    tPas += BalanceGeneral.Initial.Saldo
                                Case Config.accCapital
                                    tCap += BalanceGeneral.Initial.Saldo
                            End Select

                            'Se acumulan saldos de sub grupo
                            Select Case item.SubGrupo
                                Case Config.accActCirculante
                                    If item.Grupo = Config.accActivo Then
                                        tActCirc += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActFijo
                                    If item.Grupo = Config.accActivo Then
                                        tActFijo += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActDiferido
                                    If item.Grupo = Config.accActivo Then
                                        tActDif += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accActOtros
                                    If item.Grupo = Config.accActivo Then
                                        tActOtros += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accPasCirculante
                                    If item.Grupo = Config.accPasivo Then
                                        tPasCirc += BalanceGeneral.Initial.Saldo
                                    End If
                                Case Config.accCapitalContable
                                    If item.Grupo = Config.accCapital Then
                                        tCapCont += BalanceGeneral.Initial.Saldo
                                    End If
                            End Select


                            If item.Grupo = Config.accActivo Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                End If
                            ElseIf item.Grupo = Config.accPasivo Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                End If
                            ElseIf item.Grupo = Config.accCapital Then
                                If item.Naturaleza Then
                                    i.Col1 = BalanceGeneral.Initial.Saldo * (-1)
                                Else
                                    i.Col1 = BalanceGeneral.Initial.Saldo
                                End If
                            End If
                        End If
                End Select
                lst.Add(i)
            Next

            'SE AGREGA TOTAL DE CAPITAL Y CAPITAL CONTABLE
            'Total Pasivo
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE CAPITAL CONTABLE"
            i.Col2 = tCapCont
            lst.Add(i)

            'Total Pasivo Circulante
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE CAPITAL"
            i.Col3 = tCap
            lst.Add(i)

            'SE AGREGA TOTAL DEL CAPITAL MAS PASIVO
            i = New entBalanceGeneral
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "TOTAL DE PASIVO MAS CAPITAL CONTABLE"
            i.Col3 = tPas + tCap
            lst.Add(i)

        End Using

        Return lst
    End Function

End Module
