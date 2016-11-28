Imports appControllers
Public Class frmPrincipal

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNCuenta.DisplayFormat = Config.fn
        RibbonControl1.SelectedRibbonTabItem = RibbonTabItem1
        tmTiempo_Tick(Nothing, Nothing)
        Me.frmPrincipal_Resize(Nothing, Nothing)
        txtInicio.Text = "01/01/" & DateTime.Now.Year
        txtFinal.Text = "31/12/" & DateTime.Now.Year
        If Not Config.User Is Nothing Then
            lblNombreUsuario.Text = "Nombre Personal: " & Config.User.Name & " " & Config.User.SurnName
            lblUsuario.Text = "Usuario: " & Config.User.UserName
        Else
            Me.Close()
        End If
        Try
            txtNCuenta.Value = Account.Count()
        Catch
        End Try
        'Try
        '    Dim ctl As Control
        '    Dim ctlMDI As MdiClient
        '    ' Loop through all of the form's controls looking
        '    ' for the control of type MdiClient.
        '    For Each ctl In Me.Controls
        '        Try
        '            ' Attempt to cast the control to type MdiClient.
        '            ctlMDI = CType(ctl, MdiClient)

        '            ' Set the BackColor of the MdiClient control.
        '            ctlMDI.BackColor = Me.BackColor

        '        Catch exc As InvalidCastException
        '            ' Catch and ignore the error if casting failed.
        '        End Try
        '    Next
        'Catch ex As Exception

        'End Try
        'frmAccountManager.Width = Me.Width
        'Config.OnLoadForm(frm:=frmAccountManager, Mdi:=Me)
        picLogo.Focus()
    End Sub

    Private Sub btCatalogo_Click(sender As Object, e As EventArgs) Handles btCatalogo.Click
        frmAccountManager.Width = Me.Width
        Config.OnLoadForm(frm:=frmAccountManager, Mdi:=Me)
    End Sub

    Private Sub tmTiempo_Tick(sender As Object, e As EventArgs) Handles tmTiempo.Tick
        lblFecha.Text = "Fecha: " & DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString()
    End Sub

    Private Sub frmPrincipal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        picLogo.Left = ExpandablePanel1.Width - 70
    End Sub

    Private Sub btTarjetaAuxiliar_Click(sender As Object, e As EventArgs) Handles btTarjetaAuxiliar.Click
        frmTargetAuxiliar.MdiParent = Me
        frmTargetAuxiliar.BringToFront()
        frmTargetAuxiliar.Show()
    End Sub

    Private Sub btComprobante_Click(sender As Object, e As EventArgs) Handles btComprobante.Click
        frmEntriesAccounting.MdiParent = Me
        frmEntriesAccounting.BringToFront()
        frmEntriesAccounting.Show()
    End Sub


    Private Sub btBalanzaConsolidado_Click(sender As Object, e As EventArgs) Handles btBalanzaConsolidado.Click
        Config.OnLoadForm(frm:=frmBalanzaConsolidado, Mdi:=Me)
    End Sub

    Private Sub btBalanzaHeladeria_Click(sender As Object, e As EventArgs) Handles btBalanzaHeladeria.Click
        Config.OnLoadForm(frm:=frmBalanzaHeladeria, Mdi:=Me)
    End Sub

    Private Sub btBalanzaRestaurante_Click(sender As Object, e As EventArgs) Handles btBalanzaRestaurante.Click
        Config.OnLoadForm(frm:=frmBalanzaRestaurante, Mdi:=Me)
    End Sub

    Private Sub btAnexoConsolidado_Click(sender As Object, e As EventArgs) Handles btAnexoConsolidado.Click
        Config.OnLoadForm(frm:=frmAnexoBalanzaConsolidado, Mdi:=Me)
    End Sub

    Private Sub btBalanceConsolidado_Click(sender As Object, e As EventArgs) Handles btBalanceConsolidado.Click
        Config.OnLoadForm(frm:=frmBalanceGeneralConsolidado, Mdi:=Me)
    End Sub

    Private Sub btBusquedaComprobante_Click(sender As Object, e As EventArgs) Handles btBusquedaComprobante.Click
        Config.OnLoadForm(frm:=frmEntriesAccountingList, Mdi:=Me)
    End Sub

    Private Sub btUsers_Click(sender As Object, e As EventArgs) Handles btUsers.Click
        frmAccountSecurityManager.MdiParent = Me
        frmAccountSecurityManager.BringToFront()
        frmAccountSecurityManager.Show()
    End Sub

    Private Sub btChangePassword_Click(sender As Object, e As EventArgs) Handles btChangePassword.Click
        frmChangePassword.ShowDialog()
    End Sub

    Private Sub btLogOut_Click(sender As Object, e As EventArgs) Handles btLogOut.Click
        Me.Close()
    End Sub

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'cambiar formulario de inicio
        My.Application._MainForm = frmSignin

        'mostrar formulario
        frmSignin.Show()

        'cerrar el actual
        Me.Dispose()
    End Sub

    Private Sub btAnexoHeladeria_Click(sender As Object, e As EventArgs) Handles btAnexoHeladeria.Click
        Config.OnLoadForm(frm:=frmAnexoBalanzaHeladeria, Mdi:=Me)
    End Sub

    Private Sub btAnexoRestaurante_Click(sender As Object, e As EventArgs) Handles btAnexoRestaurante.Click
        Config.OnLoadForm(frm:=frmAnexoBalanzaRestaurante, Mdi:=Me)
    End Sub

    Private Sub btBalanceHeladeria_Click(sender As Object, e As EventArgs) Handles btBalanceHeladeria.Click
        Config.OnLoadForm(frm:=frmBalanceGeneralHeladeria, Mdi:=Me)
    End Sub

    Private Sub btBalanceRestaurante_Click(sender As Object, e As EventArgs) Handles btBalanceRestaurante.Click
        Config.OnLoadForm(frm:=frmBalanceGeneralRestaurante, Mdi:=Me)
    End Sub

    Private Sub btEstadoConsolidado_Click(sender As Object, e As EventArgs) Handles btEstadoConsolidado.Click
        Config.OnLoadForm(frm:=frmEstadoResultadoConsolidado, Mdi:=Me)
    End Sub

    Private Sub btEstadoHeladeria_Click(sender As Object, e As EventArgs) Handles btEstadoHeladeria.Click
        Config.OnLoadForm(frm:=frmEstadoResultadoHeladeria, Mdi:=Me)
    End Sub

    Private Sub btEstadoRestaurante_Click(sender As Object, e As EventArgs) Handles btEstadoRestaurante.Click
        Config.OnLoadForm(frm:=frmEstadoResultadoRestaurante, Mdi:=Me)
    End Sub

    Private Sub btEdicionCuenta_Click(sender As Object, e As EventArgs) Handles btEdicionCuenta.Click
        btCatalogo_Click(Nothing, Nothing)
    End Sub

    Private Sub btUpdate_Click(sender As Object, e As EventArgs) Handles btUpdate.Click
        Try
            txtNCuenta.Value = Account.Count()
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub btTarjetaParalela_Click(sender As Object, e As EventArgs) Handles btTarjetaParalela.Click
        frmTargetParallel.MdiParent = Me
        frmTargetParallel.BringToFront()
        frmTargetParallel.Show()
    End Sub

    Private Sub btSalir_Click(sender As Object, e As EventArgs) Handles btSalir.Click
        Process.GetCurrentProcess().CloseMainWindow()
        'Application.Exit()
    End Sub

    Private Sub btInventario_Click(sender As Object, e As EventArgs) Handles btInventario.Click
        Config.OnLoadForm(frmInventario, Me)
        'frmInventario.MdiParent = Me
        'frmInventario.BringToFront()
        'frmInventario.Show()
    End Sub

    Private Sub btConfiguracion_Click(sender As Object, e As EventArgs) Handles btConfiguracion.Click

    End Sub

    Private Sub btRespaldo_Click(sender As Object, e As EventArgs) Handles btRespaldo.Click
        Config.OnLoadForm(frmBackup)
    End Sub
End Class