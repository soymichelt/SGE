Module Config
    Public FilePathBackUp As String = "ConfigBackup.sce"

    Public Nivel As Short = 6

    Public FechaInicio As DateTime = "01/01/2016 00:00:00"

    Public PerStart As DateTime = "01/01/2016 00:00:00"
    Public perFinal As DateTime = "31/12/2016 23:59:59"

    Public Neg1 As String = "1"
    Public Neg2 As String = "2"


    'Cuentas Especiales de Estados Financieros
    'Balance general
    ''' <summary>
    ''' Cuentas de Columna1
    ''' </summary>
    ''' <remarks></remarks>
    Public accClient As String = "03"
    Public accEstCuentIncob As String = "04"

    ''' <summary>
    ''' Cuentas de Activo
    ''' </summary>
    ''' <remarks></remarks>
    Public accActCirculante As String = "1"
    Public accActFijo As String = "2"
    Public accActDiferido As String = "3"
    Public accActOtros As String = "4"

    ''' <summary>
    ''' Cuentas de Pasivo
    ''' </summary>
    ''' <remarks></remarks>
    Public accPasCirculante As String = "1"

    ''' <summary>
    ''' Cuentas de Capital
    ''' </summary>
    ''' <remarks></remarks>
    Public accCapitalContable As String = "1"

    ''' <summary>
    ''' Cuentas Generales del Balance
    ''' </summary>
    ''' <remarks></remarks>
    Public accActivo As String = "1"
    Public accPasivo As String = "2"
    Public accCapital As String = "3"

    ''' <summary>
    ''' Cuentas Generales de Estado de Resultados
    ''' </summary>
    ''' <remarks></remarks>
    Public accIngresoVenta As String = "4"
    Public accCosto As String = "5"
    Public accGasto As String = "6"
    Public accIngresoFinanciero As String = "7"

    ''' <summary>
    ''' Cuentas Generales de Estado de Resultados
    ''' </summary>
    ''' <remarks></remarks>
    Public accIngresoVentaMay As String = "01"
    Public accCostoVentaMay As String = "01"
    Public accGastoVentaMay As String = "01"
    Public accGastoAdministracionMay As String = "02"
    Public accGastoFinancieroMay As String = "03"
    Public accIngresoFinancieroMay As String = "01"


    'validar contraseña
    Public Function ValidatePass(ByVal Pass As String) As Boolean
        If Pass.Length < 8 Then
            Return False
        End If
        Dim bC = False, bM = False, bN As Boolean = False
        For Each c In Pass.ToCharArray
            If Char.IsUpper(c) Then
                bM = True
            End If
            If Char.IsNumber(c) Then
                bN = True
            End If
            If Char.IsSymbol(c) Or Char.IsPunctuation(c) Then
                bC = True
            End If
        Next
        If bC And bM And bN Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
