Public Class entAccount
    Public Property IDCuenta As Guid
    Public Property N As Long
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Nivel As Short
    'Datos de la Cuenta Superior
    Public Property IDCuentaGrupo As Nullable(Of Guid)
    'Datos del Codigo de la Cuenta

    'Codigo
    Public Property IdGrupo As Nullable(Of Guid)
    Public Property Grupo As String
    Public Property IdSubGrupo As Nullable(Of Guid)
    Public Property SubGrupo As String
    Public Property IdMayor As Nullable(Of Guid)
    Public Property Mayor As String
    Public Property IdSubMayor As Nullable(Of Guid)
    Public Property SubMayor As String
    Public Property IdSubSubMayor As Nullable(Of Guid)
    Public Property SubSubMayor As String
    Public Property IdUltimoNivel As Nullable(Of Guid)
    Public Property UltimoNivel As String
    'Fin Codigo

    'Otros datos
    Public Property CodigoCompleto As String
    Public Property Descripcion As String
    Public Property Naturaleza As Boolean
    Public Property Operacion As Boolean

    'Saldo
    Public Property Deber As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal

    'Existencia
    Public Property Entrada As Decimal
    Public Property Salida As Decimal
    Public Property Existencia As Decimal
    Public Property Costo As Decimal
    Public Property CostoPromedio As Decimal

    Public Property IsProduct As Boolean
    Public Property Cantidad As Decimal
    Public Property Activo As Boolean
End Class

Public Class entCardDaugther
    Public Property IdCuenta As Guid
    Public Property IdComprobante As Guid
    Public Property N As Long
    Public Property Fecha As DateTime
    Public Property Concepto As String
    Public Property Referencia As String
    Public Property Deber As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal
End Class

Public Class entCardParallel
    Public Property IdCuenta As Guid
    Public Property IdComprobante As Guid
    Public Property N As Long
    Public Property Fecha As DateTime
    Public Property Concepto As String
    Public Property Referencia As String
    Public Property Entrada As Decimal
    Public Property Salida As Decimal
    Public Property Existencia As Decimal
    Public Property Costo As Decimal
    Public Property CostoPromedio As Decimal
    Public Property Deber As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal
End Class

Public Class entEntriesAccounting
    Public Property IdComprobante As Guid
    Public Property N As Long
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Fecha As DateTime
    Public Property Concepto As String
    Public Property Referencia As String
    Public Property Haber As Decimal
    Public Property Deber As Decimal
    Public Property Activo As Boolean
End Class

Partial Public Class entEntriesAccountingDetails
    Public Property IdComprobante As Guid
    Public Property N As Long
    Public Property RegC As DateTime
    Public Property FModC As DateTime
    Public Property Fecha As DateTime
    Public Property Concepto As String
    Public Property Referencia As String
    Public Property Activo As Boolean
    Public Property IdCuenta As Guid
    Public Property RegD As DateTime
    Public Property FModD As DateTime

    'Codigo de la Cuenta
    Public Property IdGrupo As Nullable(Of Guid)
    Public Property Grupo As String
    Public Property IdSubGrupo As Nullable(Of Guid)
    Public Property SubGrupo As String
    Public Property IdMayor As Nullable(Of Guid)
    Public Property Mayor As String
    Public Property IdSubMayor As Nullable(Of Guid)
    Public Property SubMayor As String
    Public Property IdSubSubMayor As Nullable(Of Guid)
    Public Property SubSubMayor As String
    Public Property IdUltimoNivel As Nullable(Of Guid)
    Public Property UltimoNivel As String
    'Fin Codigo de la Cuenta

    Public Property CodigoCompleto As String
    Public Property Descripcion As String
    Public Property Naturaleza As Boolean

    'Saldo
    Public Property Deber As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal

    'Existencia
    Public Property Entrada As Decimal
    Public Property Salida As Decimal
    Public Property Existencia As Decimal
    Public Property Costo As Decimal
    Public Property CostoPromedio As Decimal
End Class

'Atributos secundarios del detalle del comprobante
Partial Public Class entEntriesAccountingDetails

    'Grupo
    Public Property IDCuentaGrupo As Guid
    Public Property DeberGrupo As Decimal
    Public Property HaberGrupo As Decimal
    Public Property SaldoGrupo As Decimal

    'Sub Grupo
    Public Property IDCuentaSubGrupo As Guid
    Public Property DeberSubGrupo As Decimal
    Public Property HaberSubGrupo As Decimal
    Public Property SaldoSubGrupo As Decimal

    'Mayor
    Public Property IDCuentaMayor As Guid
    Public Property DeberMayor As Decimal
    Public Property HaberMayor As Decimal
    Public Property SaldoMayor As Decimal

    'Sub Mayor
    Public Property IDCuentaSubMayor As Guid
    Public Property DeberSubMayor As Decimal
    Public Property HaberSubMayor As Decimal
    Public Property SaldoSubMayor As Decimal

    'Sub Sub Mayor
    Public Property IDCuentaSubSubMayor As Guid
    Public Property DeberSubSubMayor As Decimal
    Public Property HaberSubSubMayor As Decimal
    Public Property SaldoSubSubMayor As Decimal

    'Ultimo Nivel
    Public Property DeberUltimoNivel As Decimal
    Public Property HaberUltimoNivel As Decimal
    Public Property SaldoUltimoNivel As Decimal
End Class

Partial Public Class entComprobanteDiarioDetalle
    Public Property IdCuenta As Guid
    Public Property Reg As DateTime
    Public Property CodigoCompleto As String
    Public Property Descripcion As String
    Public Property Naturaleza As Boolean

    'Saldo
    Public Property Deber As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal

    'Existencia
    Public Property Entrada As Decimal
    Public Property Salida As Decimal
    Public Property Existencia As Decimal
    Public Property Costo As Decimal
    Public Property CostoPromedio As Decimal
End Class

'Atributos secundarios del detalle del comprobante
Partial Public Class entComprobanteDiarioDetalle

    'Grupo
    Public Property IDCuentaGrupo As Guid
    Public Property DeberGrupo As Decimal
    Public Property HaberGrupo As Decimal
    Public Property SaldoGrupo As Decimal

    'Sub Grupo
    Public Property IDCuentaSubGrupo As Guid
    Public Property DeberSubGrupo As Decimal
    Public Property HaberSubGrupo As Decimal
    Public Property SaldoSubGrupo As Decimal

    'Mayor
    Public Property IDCuentaMayor As Guid
    Public Property DeberMayor As Decimal
    Public Property HaberMayor As Decimal
    Public Property SaldoMayor As Decimal

    'Sub Mayor
    Public Property IDCuentaSubMayor As Guid
    Public Property DeberSubMayor As Decimal
    Public Property HaberSubMayor As Decimal
    Public Property SaldoSubMayor As Decimal

    'Sub Sub Mayor
    Public Property IDCuentaSubSubMayor As Guid
    Public Property DeberSubSubMayor As Decimal
    Public Property HaberSubSubMayor As Decimal
    Public Property SaldoSubSubMayor As Decimal

    'Ultimo Nivel
    Public Property DeberUltimoNivel As Decimal
    Public Property HaberUltimoNivel As Decimal
    Public Property SaldoUltimoNivel As Decimal


End Class


'ESTRUCTURAS DE ESTADOS FINANCIEROS
Public Class entBalanzaComprobacion
    Public Property IdCuenta As Guid
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Nivel As Integer
    Public Property CodigoCompleto As String
    Public Property Descripcion As String
    Public Property DebeInicial As Decimal
    Public Property HaberInicial As Decimal
    Public Property DebeMes As Decimal
    Public Property HaberMes As Decimal
    Public Property DebeSaldo As Decimal
    Public Property HaberSaldo As Decimal
End Class


Public Class entBalanceGeneral
    Public Property IdCuenta As Guid
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Nivel As Integer
    Public Property CodigoCompleto As String
    Public Property Descripcion As String
    Public Property Col1 As Decimal
    Public Property Col2 As Decimal
    Public Property Col3 As Decimal
    Public Property Col4 As Decimal
End Class

Public Class entEstadoResultados
    Public Property IdCuenta As Guid
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Nivel As Integer
    Public Property CodigoCompleto As String
    Public Property Descripcion As String
    Public Property Col1 As Decimal
    Public Property Col2 As Decimal
End Class

'Saldos
Public Class entSaldo
    Public Property Debe As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal
End Class