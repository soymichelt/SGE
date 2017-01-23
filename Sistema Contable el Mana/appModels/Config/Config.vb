Public Module Config

    ''' <summary>
    ''' Nombre del Servidor Encapsulado
    ''' </summary>
    ''' <remarks></remarks>
    Private pSQLServerName As String = ".\unanfaremch"
    ''' <summary>
    ''' Nombre del Servidor
    ''' </summary>
    ''' <value>Establece el nombre del Servidor</value>
    ''' <returns>Obtiene el nombre del Servidor</returns>
    ''' <remarks>Contiene el nombre del servidor donde se encuentra la instancia de SQL</remarks>
    Public Property SQLServerName As String
        Get
            Return pSQLServerName
        End Get
        Set(value As String)
            pSQLServerName = value
        End Set
    End Property

    ''' <summary>
    ''' Nombre de la Instancia SQL encapsulada
    ''' </summary>
    ''' <remarks></remarks>
    Private pInitialCatalog As String = "dbContable_23-01-2017"
    ''' <summary>
    ''' Nombre de la Instancia SQL
    ''' </summary>
    ''' <value>Establece el Nombre de la Instancia de SQL</value>
    ''' <returns>Obtiene el Nombre de la Instancia de SQL</returns>
    ''' <remarks>Contiene el nombre de la Instancia de SQL</remarks>
    Public Property InitialCatalog As String
        Get
            Return pInitialCatalog
        End Get
        Set(value As String)
            pInitialCatalog = value
        End Set
    End Property

    ''' <summary>
    ''' Nombre de Usuario de la Instancia SQL encapsulado
    ''' </summary>
    ''' <remarks></remarks>
    Private pSQLUserName As String = ""
    ''' <summary>
    ''' Nombre de Usuario de la Instancia SQL
    ''' </summary>
    ''' <value>Establece el Nombre de Usuario de la Instancia SQL</value>
    ''' <returns>Obtiene el Nombre de Usuario de la Instancia SQL</returns>
    ''' <remarks>Contiene el Nombre de Usuario de la Instancia SQL</remarks>
    Public Property SQLUserName() As String
        Get
            Return pSQLUserName
        End Get
        Set(ByVal value As String)
            pSQLUserName = value
        End Set
    End Property

    ''' <summary>
    ''' Contraseña del Usuario de la Instancia SQL encapsulado
    ''' </summary>
    ''' <remarks></remarks>
    Private pSQLUserPass As String = ""
    ''' <summary>
    ''' Contraseña del Usuario de la Instancia SQL
    ''' </summary>
    ''' <value>Establece la Contraseña del Usuario de la Instancia SQL</value>
    ''' <returns>Obtiene la Contraseña del Usuario de la Instancia SQL</returns>
    ''' <remarks>Contiene la Contraseña del Usuario de la Instancia SQL</remarks>
    Public Property SQLUserPass() As String
        Get
            Return pSQLUserPass
        End Get
        Set(ByVal value As String)
            pSQLUserPass = value
        End Set
    End Property

    
End Module