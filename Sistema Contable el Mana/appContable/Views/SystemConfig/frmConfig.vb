Imports appControllers
Imports appModels
Public Class frmConfig

    Dim FormLoad As Boolean = False

    Dim IDUser As Guid = Guid.Empty

    

    Private Sub frmAccountSecurityManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Me.Parent.Width
        Me.WindowState = FormWindowState.Maximized
        Me.frmAccountSecurityManager_Resize(Nothing, Nothing)
        
        Me.FormLoad = True
    End Sub

    
    Private Sub frmAccountSecurityManager_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Control Then
            Select Case e.KeyCode
                Case Keys.N
                    'btNuevo_Click(Nothing, Nothing)
                Case Keys.G
                    'If btGuardar.Enabled Then
                    '    btGuardar_Click(Nothing, Nothing)
                    'End If
                Case Keys.E
                    'If btEditar.Enabled Then
                    '    btEditar_Click(Nothing, Nothing)
                    'End If
                Case Keys.Delete
                    'If btEliminar.Enabled Then
                    '    btEliminar_Click(Nothing, Nothing)
                    'End If
                Case Keys.B
                    'btBuscar_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub frmAccountSecurityManager_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'pnBusqueda.Left = Me.Width - PanelEx1.Width - 448
    End Sub

End Class