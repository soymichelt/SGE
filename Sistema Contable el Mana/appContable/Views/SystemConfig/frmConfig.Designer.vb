<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.ElTab1 = New Klik.Windows.Forms.v1.EntryLib.ELTab()
        Me.ElTabPage1 = New Klik.Windows.Forms.v1.EntryLib.ELTabPage()
        Me.ElTabPage2 = New Klik.Windows.Forms.v1.EntryLib.ELTabPage()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElTab1.SuspendLayout()
        CType(Me.ElTabPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElTabPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KFormManager1
        '
        Me.KFormManager1.BackgroundImageStyle.Alpha = 100
        Me.KFormManager1.BackgroundImageStyle.ImageEffect = Klik.Windows.Forms.v1.Common.ImageEffect.Mirror
        Me.KFormManager1.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.MainContainer = Me
        '
        'ElTab1
        '
        Me.ElTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElTab1.Location = New System.Drawing.Point(0, 0)
        Me.ElTab1.Name = "ElTab1"
        Me.ElTab1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElTab1.Size = New System.Drawing.Size(966, 393)
        Me.ElTab1.TabCaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElTab1.TabCaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElTab1.TabCaptionStyle.StateStyles.FocusStyle.BackgroundPaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElTab1.TabCaptionStyle.StateStyles.FocusStyle.BackgroundSolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElTab1.TabIndex = 0
        Me.ElTab1.TabPages.Add(Me.ElTabPage1)
        Me.ElTab1.TabPages.Add(Me.ElTabPage2)
        '
        'ElTabPage1
        '
        Me.ElTabPage1.BackgroundStyle.GradientAngle = 45.0!
        Me.ElTabPage1.CaptionImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElTabPage1.CaptionTextStyle.Text = "Edición de Comprobantes"
        Me.ElTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.ElTabPage1.Name = "ElTabPage1"
        Me.ElTabPage1.Size = New System.Drawing.Size(964, 369)
        '
        'ElTabPage2
        '
        Me.ElTabPage2.BackgroundStyle.GradientAngle = 45.0!
        Me.ElTabPage2.CaptionImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ElTabPage2.CaptionTextStyle.Text = "ElTabPage2"
        Me.ElTabPage2.Location = New System.Drawing.Point(1, 23)
        Me.ElTabPage2.Name = "ElTabPage2"
        Me.ElTabPage2.Size = New System.Drawing.Size(964, 369)
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 393)
        Me.Controls.Add(Me.ElTab1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfig"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración del Sistema"
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElTab1.ResumeLayout(False)
        CType(Me.ElTabPage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElTabPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents ElTab1 As Klik.Windows.Forms.v1.EntryLib.ELTab
    Friend WithEvents ElTabPage1 As Klik.Windows.Forms.v1.EntryLib.ELTabPage
    Friend WithEvents ElTabPage2 As Klik.Windows.Forms.v1.EntryLib.ELTabPage
End Class
