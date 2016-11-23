<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSignin))
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.gpSesion = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.btMostrar = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btSalir = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.btEntrar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContraseña = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpSesion.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btSalir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btEntrar, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpSesion
        '
        Me.gpSesion.BackgroundStyle.GradientAngle = 45.0!
        Me.gpSesion.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.gpSesion.CaptionStyle.Align = System.Drawing.ContentAlignment.MiddleCenter
        Me.gpSesion.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.gpSesion.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.gpSesion.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.gpSesion.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.gpSesion.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.gpSesion.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gpSesion.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.gpSesion.CaptionStyle.Size = New System.Drawing.Size(200, 24)
        Me.gpSesion.CaptionStyle.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.gpSesion.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.Black
        Me.gpSesion.CaptionStyle.TextStyle.Text = "Iniciar Sesión en SCE - El Maná"
        Me.gpSesion.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gpSesion.Controls.Add(Me.btMostrar)
        Me.gpSesion.Controls.Add(Me.PictureBox1)
        Me.gpSesion.Controls.Add(Me.btSalir)
        Me.gpSesion.Controls.Add(Me.btEntrar)
        Me.gpSesion.Controls.Add(Me.Label2)
        Me.gpSesion.Controls.Add(Me.Label1)
        Me.gpSesion.Controls.Add(Me.txtContraseña)
        Me.gpSesion.Controls.Add(Me.txtUsuario)
        Me.gpSesion.Location = New System.Drawing.Point(208, 232)
        Me.gpSesion.Name = "gpSesion"
        Me.gpSesion.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.gpSesion.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.gpSesion.Size = New System.Drawing.Size(298, 175)
        Me.gpSesion.TabIndex = 7
        '
        'btMostrar
        '
        Me.btMostrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btMostrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btMostrar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btMostrar.Image = Global.appContable.My.Resources.Resources.ShowPass
        Me.btMostrar.Location = New System.Drawing.Point(261, 77)
        Me.btMostrar.Name = "btMostrar"
        Me.btMostrar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor()
        Me.btMostrar.Size = New System.Drawing.Size(20, 20)
        Me.btMostrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btMostrar.TabIndex = 24
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.appContable.My.Resources.Resources.Linea
        Me.PictureBox1.Location = New System.Drawing.Point(18, 109)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(263, 4)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'btSalir
        '
        Me.btSalir.BorderStyle.EdgeRadius = 30
        Me.btSalir.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btSalir.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btSalir.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btSalir.ForegroundImageStyle.Image = Global.appContable.My.Resources.Resources.Salir
        Me.btSalir.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSalir.Location = New System.Drawing.Point(153, 126)
        Me.btSalir.Name = "btSalir"
        Me.btSalir.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver
        Me.btSalir.Size = New System.Drawing.Size(115, 31)
        Me.btSalir.TabIndex = 4
        Me.btSalir.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btSalir.TextStyle.Text = "Cerrar Sistema"
        Me.btSalir.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btEntrar
        '
        Me.btEntrar.BorderStyle.EdgeRadius = 30
        Me.btEntrar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btEntrar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btEntrar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btEntrar.ForegroundImageStyle.Image = Global.appContable.My.Resources.Resources.Signin
        Me.btEntrar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btEntrar.Location = New System.Drawing.Point(31, 126)
        Me.btEntrar.Name = "btEntrar"
        Me.btEntrar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.btEntrar.Size = New System.Drawing.Size(115, 31)
        Me.btEntrar.TabIndex = 3
        Me.btEntrar.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btEntrar.TextStyle.Text = "Iniciar Sesión"
        Me.btEntrar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Contraseña:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Nombre de Usuario:"
        '
        'txtContraseña
        '
        Me.txtContraseña.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtContraseña.Border.Class = "TextBoxBorder"
        Me.txtContraseña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContraseña.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContraseña.Location = New System.Drawing.Point(122, 77)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(140, 20)
        Me.txtContraseña.TabIndex = 2
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(122, 46)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(159, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'frmSignin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 612)
        Me.Controls.Add(Me.gpSesion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSignin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Sesión en SCE - El Maná"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpSesion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpSesion.ResumeLayout(False)
        Me.gpSesion.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btSalir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btEntrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents gpSesion As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtContraseña As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btSalir As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents btEntrar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btMostrar As DevComponents.DotNetBar.ButtonX
End Class
