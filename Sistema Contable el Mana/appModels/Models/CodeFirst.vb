#Region "Nombres de Espacio"
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Data.Entity
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
#End Region

Public Class UserAccount

    <Key()>
    Public Property IDUser As Guid
    Public Property N As Long
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Name As String
    Public Property SurnName As String
    Public Property UserName As String
    Public Property UserPass As String
    Public Property Activo As Boolean

End Class

Public Class Cuenta
    'Version 1
    '<Key()>
    'Public Property IDCuenta As Guid
    '<DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    'Public Property N As Long
    'Public Property Reg As DateTime
    'Public Property Nivel As Short
    ''Datos de la Cuenta Superior
    'Public Property IDCuentaGrupo As Nullable(Of Guid)
    'Public Property CodigoSuperior As String
    ''Datos de la Cuenta
    'Public Property Codigo As String
    'Public Property Descripcion As String
    'Public Property Naturaleza As Boolean
    'Public Property Operacion As Boolean
    'Public Property Deber As Decimal
    'Public Property Haber As Decimal
    'Public Property Saldo As Decimal
    'Public Property Activo As Boolean

    'Version 2
    <Key()>
    Public Property IDCuenta As Guid
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Nivel As Short
    'Datos de la Cuenta Superior
    Public Property IDCuentaGrupo As Nullable(Of Guid)
    Public Property CodigoSuperior As String
    'Codigos de la Cuenta
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

    'Descripción de la Cuenta
    Public Property Descripcion As String
    Public Property Naturaleza As Boolean
    Public Property Operacion As Boolean

    'Saldos de la Cuenta
    Public Property Deber As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal

    'Datos de Tarjeta Paralela
    Public Property IsProduct As Boolean
    Public Property Entrada As Decimal
    Public Property Salida As Decimal
    Public Property Existencia As Decimal
    Public Property Costo As Decimal

    'Estado de la Cuenta
    Public Property Activo As Boolean

    Public Overridable Property ComprobantesDiariosDetalles As ICollection(Of ComprobanteDiarioDetalle) = New HashSet(Of ComprobanteDiarioDetalle)
    Public Overridable Property Kardexs As ICollection(Of Kardex) = New HashSet(Of Kardex)
End Class

Public Class Kardex
    <Key()>
    Public Property IDKardex As Guid
    Public Property N As Long
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property IDComprobante As Guid
    Public Property IDCuenta As Guid

    Public Property ExistAnterior As Decimal
    Public Property Entrada As Decimal
    Public Property Salida As Decimal
    Public Property ExistActual As Decimal

    Public Property Costo As Decimal
    Public Property CostoPromedio As Decimal

    Public Property Haber As Decimal
    Public Property Deber As Decimal
    Public Property Saldo As Decimal

    Public Property Activo As Boolean

    Public Overridable Property ComprobanteDiario As ComprobanteDiario
    Public Overridable Property Cuenta As Cuenta
End Class

Public Class ComprobanteDiario
    <Key()>
    Public Property IDComprobante As Guid
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property Fecha As DateTime
    Public Property Concepto As String
    Public Property Referencia As String
    Public Property Haber As Decimal
    Public Property Deber As Decimal
    Public Property Activo As Boolean

    Public Overridable Property ComprobantesDiariosDetalles As ICollection(Of ComprobanteDiarioDetalle) = New HashSet(Of ComprobanteDiarioDetalle)
    Public Overridable Property Kardexs As ICollection(Of Kardex) = New HashSet(Of Kardex)
End Class

'Atributos directos del detalle del comprobante
Partial Public Class ComprobanteDiarioDetalle
    <Key()>
    Public Property IDDetalle As Guid
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)>
    Public Property N As Long
    Public Property Reg As DateTime
    Public Property FMod As DateTime
    Public Property IDCuenta As Guid
    Public Property IDComprobante As Guid
    Public Property Deber As Decimal
    Public Property Haber As Decimal
    Public Property Saldo As Decimal

    Public Overridable Property Cuenta As Cuenta
    Public Overridable Property ComprobanteDiario As ComprobanteDiario
End Class

'Datos de Almacen
Partial Public Class ComprobanteDiarioDetalle
    'Saldos Registrados
    Public Property Entrada As Decimal
    Public Property Salida As Decimal
    Public Property Existencia As Decimal

    'Saldos de la Cuenta
    Public Property EntradaProd As Decimal
    Public Property SalidaProd As Decimal
    Public Property ExistenciaProd As Decimal

    'Costos
    Public Property Costo As Decimal
    Public Property CostoPromedio As Decimal
End Class

'Atributos secundarios del detalle del comprobante
Partial Public Class ComprobanteDiarioDetalle

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

Public Class CodeFirst
    Inherits DbContext

    Public Sub New()
        MyBase.New("Data Source=" & Config.SQLServerName & "; Initial Catalog=" & Config.InitialCatalog & ";" & If(Not String.IsNullOrWhiteSpace(Config.SQLUserName) And Not String.IsNullOrWhiteSpace(Config.SQLUserPass), "User ID=" & Config.SQLUserName & "; Password=" & Config.SQLUserPass & ";", "Integrated Security=True;"))
    End Sub


    Public Property Cuentas As DbSet(Of Cuenta)
    Public Property ComprobantesDiarios As DbSet(Of ComprobanteDiario)
    Public Property ComprobantesDiariosDetalles As DbSet(Of ComprobanteDiarioDetalle)
    Public Property Kardexs As DbSet(Of Kardex)

    Public Property UsersAccounts As DbSet(Of UserAccount)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention)()

        'decimales
        modelBuilder.Entity(Of Cuenta).Property(Function(f) f.Deber).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cuenta).Property(Function(f) f.Haber).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cuenta).Property(Function(f) f.Saldo).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cuenta).Property(Function(f) f.Existencia).HasPrecision(18, 4)
        modelBuilder.Entity(Of Cuenta).Property(Function(f) f.Costo).HasPrecision(18, 4)

        modelBuilder.Entity(Of ComprobanteDiarioDetalle).Property(Function(f) f.Deber).HasPrecision(18, 4)
        modelBuilder.Entity(Of ComprobanteDiarioDetalle).Property(Function(f) f.Haber).HasPrecision(18, 4)

        modelBuilder.Entity(Of Kardex).Property(Function(f) f.ExistAnterior).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.Entrada).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.Salida).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.ExistActual).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.Costo).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.CostoPromedio).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.Deber).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.Haber).HasPrecision(18, 4)
        modelBuilder.Entity(Of Kardex).Property(Function(f) f.Saldo).HasPrecision(18, 4)



        MyBase.OnModelCreating(modelBuilder)
    End Sub

End Class
