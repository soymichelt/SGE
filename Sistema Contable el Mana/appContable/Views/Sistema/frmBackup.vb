Public Class frmBackup

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Skin = MaterialSkin.MaterialSkinManager.Instance
        Skin.AddFormToManage(Me)
        Skin.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT
        Skin.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.DeepOrange800, MaterialSkin.Primary.DeepOrange900, MaterialSkin.Primary.DeepOrange500, MaterialSkin.Accent.DeepPurple200, MaterialSkin.TextShade.WHITE)

    End Sub

    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class