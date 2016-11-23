Imports appModels

Public Module EstadoResultados

    Dim lst As New List(Of entEstadoResultados)
    Dim i As entEstadoResultados
    Dim Initial As entSaldo
    Dim Sum As New List(Of entSaldo)
    Dim SumCir As Decimal = 0

    ''' <summary>
    ''' Representa un Estado de Resultados Consolidado
    ''' </summary>
    ''' <param name="Inicio">La Fecha de Inicio a partir de donde se seleccionaran los datos para generar el Estado de Resultados.</param>
    ''' <param name="Final">La Fecha de final antes de donde se seleccionaran los datos para generar el Estado de Resultados.</param>
    ''' <returns>Retorna un Tipo de colección con las cuentas del Estado de Resultados y sus saldos</returns>
    ''' <remarks></remarks>
    Public Function Estado1(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entEstadoResultados)
        EstadoResultados.lst = New List(Of entEstadoResultados)
        If Inicio < Config.FechaInicio Or Final < Config.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Config.FechaInicio.ToShortDateString() & "'")
        End If
        Dim utlBruta = 0, utlOperaciones = 0, IngFinanc As Decimal = 0

        Using db As New CodeFirst
            'Recorrer el listado de cuentas con los primeros 3 niveles
            For Each item In (Account.List().Where(Function(f) (f.Nivel = 3) And (f.Grupo = Config.accIngresoVenta Or f.Grupo = Config.accCosto Or f.Grupo = Config.accGasto Or f.Grupo = Config.accIngresoFinanciero)).ToList)

                'SE AGREGA UTILIDAD BRUTA
                If item.Grupo = Config.accGasto And item.Mayor = Config.accGastoVentaMay Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "UTILIDAD BRUTA"
                    i.Col2 = utlBruta
                    lst.Add(i)
                End If

                'SE AGREGA GASTO TOTAL
                If item.Grupo = Config.accIngresoFinanciero And item.Mayor = Config.accIngresoFinancieroMay Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "GASTO TOTAL"
                    i.Col2 = utlOperaciones
                    lst.Add(i)
                End If

                'SE AGREGA UTILIDAD DE OPERACIONES
                If item.Grupo = Config.accIngresoFinanciero And item.Mayor = Config.accIngresoFinancieroMay Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "UTILIDAD DE OPERACIONES"
                    i.Col2 = utlBruta - utlOperaciones
                    lst.Add(i)
                End If

                'Se inicializa el item del balance general
                EstadoResultados.i = New entEstadoResultados
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                EstadoResultados.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                     Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                     Where cu.IdMayor = i.IdCuenta And co.Fecha <= Final And co.Activo _
                     Order By cd.N Descending _
                     Select New entSaldo With { _
                         .Debe = cd.DeberMayor,
                         .Haber = cd.HaberMayor,
                         .Saldo = cd.SaldoMayor _
                     }).FirstOrDefault
                If Not EstadoResultados.Initial Is Nothing Then

                    'Calcular Utilidad Bruta y Agregar Ingresos
                    If item.Grupo = Config.accIngresoVenta Or item.Grupo = Config.accCosto Then
                        'se agrega el saldo a la cuenta
                        i.Col2 = EstadoResultados.Initial.Saldo

                        'Se incrementan si son ingresos de venta
                        If item.Grupo = Config.accIngresoVenta Then
                            utlBruta += EstadoResultados.Initial.Saldo
                        End If

                        'Se decrementan si son costos
                        If item.Grupo = Config.accCosto Then
                            utlBruta -= EstadoResultados.Initial.Saldo
                        End If

                    End If

                    'Calcular Utilidad de Operaciones y Agregar Gastos
                    If item.Grupo = Config.accGasto Then

                        'se agrega el saldo a la cuenta
                        i.Col1 = EstadoResultados.Initial.Saldo

                        'Acumula el gasto
                        utlOperaciones += EstadoResultados.Initial.Saldo

                    End If

                    'Agregar ingresos financieros
                    If item.Grupo = Config.accIngresoFinanciero Then

                        'se agrega el saldo a la cuenta
                        i.Col2 = EstadoResultados.Initial.Saldo

                        'Se incrementan si son ingresos financieros
                        IngFinanc += EstadoResultados.Initial.Saldo

                    End If
                End If

                lst.Add(i)
            Next

            'SE AGREGA UTILIDAD O PERDIDA
            i = New entEstadoResultados
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "UTILIDAD O PERDIDA DEL MES"
            i.Col2 = utlBruta - utlOperaciones + IngFinanc
            lst.Add(i)

        End Using

        Return EstadoResultados.lst
    End Function

    ''' <summary>
    ''' Representa un Estado de Resultados de la Heladeria el Maná
    ''' </summary>
    ''' <param name="Inicio">La Fecha de Inicio a partir de donde se seleccionaran los datos para generar el Estado de Resultados.</param>
    ''' <param name="Final">La Fecha de final antes de donde se seleccionaran los datos para generar el Estado de Resultados.</param>
    ''' <returns>Retorna un Tipo de colección con las cuentas del Estado de Resultados y sus saldos</returns>
    ''' <remarks></remarks>
    Public Function Estado2(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entEstadoResultados)
        EstadoResultados.lst = New List(Of entEstadoResultados)
        If Inicio < Config.FechaInicio Or Final < Config.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Config.FechaInicio.ToShortDateString() & "'")
        End If
        Dim utlBruta = 0, utlOperaciones = 0, IngFinanc As Decimal = 0

        Using db As New CodeFirst
            'Recorrer el listado de cuentas con los primeros 3 niveles
            For Each item In (Account.List().Where(Function(f) (f.Nivel = 5 Or f.Nivel = 6) And f.SubMayor = Config.Neg1 And (f.Grupo = Config.accIngresoVenta Or f.Grupo = Config.accCosto Or f.Grupo = Config.accGasto Or f.Grupo = Config.accIngresoFinanciero)).ToList)

                'SE AGREGA UTILIDAD BRUTA
                If item.Grupo = Config.accGasto And item.Mayor = Config.accGastoVentaMay And item.Nivel = 5 Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "UTILIDAD BRUTA"
                    i.Col2 = utlBruta
                    lst.Add(i)
                End If

                'SE AGREGA GASTO TOTAL
                If item.Grupo = Config.accIngresoFinanciero And item.Mayor = Config.accIngresoFinancieroMay And item.Nivel = 5 Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "GASTO TOTAL"
                    i.Col2 = utlOperaciones
                    lst.Add(i)
                End If

                'SE AGREGA UTILIDAD DE OPERACIONES
                If item.Grupo = Config.accIngresoFinanciero And item.Mayor = Config.accIngresoFinancieroMay And item.Nivel = 5 Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "UTILIDAD DE OPERACIONES"
                    i.Col2 = utlBruta - utlOperaciones
                    lst.Add(i)
                End If

                'Se inicializa el item del balance general
                EstadoResultados.i = New entEstadoResultados
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                Select Case item.Nivel
                    Case 5
                        'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        EstadoResultados.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha <= Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberSubSubMayor,
                                 .Haber = cd.HaberSubSubMayor,
                                 .Saldo = cd.SaldoSubSubMayor _
                             }).FirstOrDefault
                        '
                        If Not EstadoResultados.Initial Is Nothing Then

                            'Calcular Utilidad Bruta y Agregar Ingresos
                            If item.Grupo = Config.accIngresoVenta Or item.Grupo = Config.accCosto Then
                                'se agrega el saldo a la cuenta
                                i.Col2 = EstadoResultados.Initial.Saldo

                                'Se incrementan si son ingresos de venta
                                If item.Grupo = Config.accIngresoVenta Then
                                    utlBruta += EstadoResultados.Initial.Saldo
                                End If

                                'Se decrementan si son costos
                                If item.Grupo = Config.accCosto Then
                                    utlBruta -= EstadoResultados.Initial.Saldo
                                End If

                            End If

                            'Calcular Utilidad de Operaciones y Agregar Gastos
                            If item.Grupo = Config.accGasto Then

                                'se agrega el saldo a la cuenta
                                i.Col2 = EstadoResultados.Initial.Saldo

                                'Acumula el gasto
                                utlOperaciones += EstadoResultados.Initial.Saldo

                            End If

                            'Agregar ingresos financieros
                            If item.Grupo = Config.accIngresoFinanciero Then

                                'se agrega el saldo a la cuenta
                                i.Col2 = EstadoResultados.Initial.Saldo

                                'Se incrementan si son ingresos financieros
                                IngFinanc += EstadoResultados.Initial.Saldo

                            End If
                        End If
                    Case 6
                        'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        EstadoResultados.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdUltimoNivel = i.IdCuenta And co.Fecha < Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberUltimoNivel,
                                 .Haber = cd.HaberUltimoNivel,
                                 .Saldo = cd.SaldoUltimoNivel _
                             }).FirstOrDefault
                        '
                        If Not EstadoResultados.Initial Is Nothing Then
                            'se agrega el saldo a la cuenta
                            i.Col1 = EstadoResultados.Initial.Saldo
                        End If
                End Select

                lst.Add(i)
            Next

            'SE AGREGA UTILIDAD O PERDIDA
            i = New entEstadoResultados
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "UTILIDAD O PERDIDA DEL MES"
            i.Col2 = utlBruta - utlOperaciones + IngFinanc
            lst.Add(i)

        End Using

        Return EstadoResultados.lst
    End Function


    ''' <summary>
    ''' Representa un Estado de Resultados del Restaurante el Maná
    ''' </summary>
    ''' <param name="Inicio">La Fecha de Inicio a partir de donde se seleccionaran los datos para generar el Estado de Resultados.</param>
    ''' <param name="Final">La Fecha de final antes de donde se seleccionaran los datos para generar el Estado de Resultados.</param>
    ''' <returns>Retorna un Tipo de colección con las cuentas del Estado de Resultados y sus saldos</returns>
    ''' <remarks></remarks>
    Public Function Estado3(ByVal Inicio As DateTime, ByVal Final As DateTime) As List(Of entEstadoResultados)
        EstadoResultados.lst = New List(Of entEstadoResultados)
        If Inicio < Config.FechaInicio Or Final < Config.FechaInicio Then
            Throw New Exception("Las Fechas deben ser mayor que '" & Config.FechaInicio.ToShortDateString() & "'")
        End If
        Dim utlBruta = 0, utlOperaciones = 0, IngFinanc As Decimal = 0

        Using db As New CodeFirst
            'Recorrer el listado de cuentas con los primeros 3 niveles
            For Each item In (Account.List().Where(Function(f) (f.Nivel = 5 Or f.Nivel = 6) And f.SubMayor = Config.Neg2 And (f.Grupo = Config.accIngresoVenta Or f.Grupo = Config.accCosto Or f.Grupo = Config.accGasto Or f.Grupo = Config.accIngresoFinanciero)).ToList)

                'SE AGREGA UTILIDAD BRUTA
                If item.Grupo = Config.accGasto And item.Mayor = Config.accGastoVentaMay And item.Nivel = 5 Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "UTILIDAD BRUTA"
                    i.Col2 = utlBruta
                    lst.Add(i)
                End If

                'SE AGREGA GASTO TOTAL
                If item.Grupo = Config.accIngresoFinanciero And item.Mayor = Config.accIngresoFinancieroMay And item.Nivel = 5 Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "GASTO TOTAL"
                    i.Col2 = utlOperaciones
                    lst.Add(i)
                End If

                'SE AGREGA UTILIDAD DE OPERACIONES
                If item.Grupo = Config.accIngresoFinanciero And item.Mayor = Config.accIngresoFinancieroMay And item.Nivel = 5 Then
                    i = New entEstadoResultados
                    i.IdCuenta = Guid.Empty
                    i.Reg = DateTime.Now
                    i.FMod = DateTime.Now
                    i.Nivel = -1
                    i.CodigoCompleto = ""
                    i.Descripcion = "UTILIDAD DE OPERACIONES"
                    i.Col2 = utlBruta - utlOperaciones
                    lst.Add(i)
                End If

                'Se inicializa el item del balance general
                EstadoResultados.i = New entEstadoResultados
                i.IdCuenta = item.IDCuenta
                i.Reg = item.Reg
                i.FMod = item.FMod
                i.Nivel = item.Nivel
                i.CodigoCompleto = item.CodigoCompleto
                i.Descripcion = item.Descripcion

                Select Case item.Nivel
                    Case 5
                        'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        EstadoResultados.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdSubSubMayor = i.IdCuenta And co.Fecha <= Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberSubSubMayor,
                                 .Haber = cd.HaberSubSubMayor,
                                 .Saldo = cd.SaldoSubSubMayor _
                             }).FirstOrDefault
                        '
                        If Not EstadoResultados.Initial Is Nothing Then

                            'Calcular Utilidad Bruta y Agregar Ingresos
                            If item.Grupo = Config.accIngresoVenta Or item.Grupo = Config.accCosto Then
                                'se agrega el saldo a la cuenta
                                i.Col2 = EstadoResultados.Initial.Saldo

                                'Se incrementan si son ingresos de venta
                                If item.Grupo = Config.accIngresoVenta Then
                                    utlBruta += EstadoResultados.Initial.Saldo
                                End If

                                'Se decrementan si son costos
                                If item.Grupo = Config.accCosto Then
                                    utlBruta -= EstadoResultados.Initial.Saldo
                                End If

                            End If

                            'Calcular Utilidad de Operaciones y Agregar Gastos
                            If item.Grupo = Config.accGasto Then

                                'se agrega el saldo a la cuenta
                                i.Col2 = EstadoResultados.Initial.Saldo

                                'Acumula el gasto
                                utlOperaciones += EstadoResultados.Initial.Saldo

                            End If

                            'Agregar ingresos financieros
                            If item.Grupo = Config.accIngresoFinanciero Then

                                'se agrega el saldo a la cuenta
                                i.Col2 = EstadoResultados.Initial.Saldo

                                'Se incrementan si son ingresos financieros
                                IngFinanc += EstadoResultados.Initial.Saldo

                            End If
                        End If
                    Case 6
                        'Obtenemos el ultimo dato de grupos de la tarjeta auxiliar
                        EstadoResultados.Initial = (From cu In Account.List() Join cd In db.ComprobantesDiariosDetalles On cu.IDCuenta Equals cd.IDCuenta
                             Join co In db.ComprobantesDiarios On cd.IDComprobante Equals co.IDComprobante _
                             Where cu.IdUltimoNivel = i.IdCuenta And co.Fecha < Final And co.Activo _
                             Order By cd.N Descending _
                             Select New entSaldo With { _
                                 .Debe = cd.DeberUltimoNivel,
                                 .Haber = cd.HaberUltimoNivel,
                                 .Saldo = cd.SaldoUltimoNivel _
                             }).FirstOrDefault
                        '
                        If Not EstadoResultados.Initial Is Nothing Then
                            'se agrega el saldo a la cuenta
                            i.Col1 = EstadoResultados.Initial.Saldo
                        End If
                End Select

                lst.Add(i)
            Next

            'SE AGREGA UTILIDAD O PERDIDA
            i = New entEstadoResultados
            i.IdCuenta = Guid.Empty
            i.Reg = DateTime.Now
            i.FMod = DateTime.Now
            i.Nivel = -1
            i.CodigoCompleto = ""
            i.Descripcion = "UTILIDAD O PERDIDA DEL MES"
            i.Col2 = utlBruta - utlOperaciones + IngFinanc
            lst.Add(i)

        End Using

        Return EstadoResultados.lst
    End Function

End Module