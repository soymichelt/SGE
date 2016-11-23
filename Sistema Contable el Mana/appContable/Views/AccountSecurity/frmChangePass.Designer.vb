<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePassword))
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRepetir = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btSalir = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.btEntrar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNueva = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtActual = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.btSalir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btEntrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ElGroupBox2
        '
        Me.ElGroupBox2.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox2.CaptionStyle.Align = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox2.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox2.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox2.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox2.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox2.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox2.CaptionStyle.Size = New System.Drawing.Size(200, 24)
        Me.ElGroupBox2.CaptionStyle.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ElGroupBox2.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.Black
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Iniciar Sesión en SCE - El Maná"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.Label3)
        Me.ElGroupBox2.Controls.Add(Me.txtRepetir)
        Me.ElGroupBox2.Controls.Add(Me.PictureBox1)
        Me.ElGroupBox2.Controls.Add(Me.btSalir)
        Me.ElGroupBox2.Controls.Add(Me.btEntrar)
        Me.ElGroupBox2.Controls.Add(Me.Label2)
        Me.ElGroupBox2.Controls.Add(Me.Label1)
        Me.ElGroupBox2.Controls.Add(Me.txtNueva)
        Me.ElGroupBox2.Controls.Add(Me.txtActual)
        Me.ElGroupBox2.Location = New System.Drawing.Point(67, 46)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(298, 201)
        Me.ElGroupBox2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 14)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Repetir:"
        '
        'txtRepetir
        '
        Me.txtRepetir.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtRepetir.Border.Class = "TextBoxBorder"
        Me.txtRepetir.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRepetir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepetir.Location = New System.Drawing.Point(122, 98)
        Me.txtRepetir.Name = "txtRepetir"
        Me.txtRepetir.ReadOnly = True
        Me.txtRepetir.Size = New System.Drawing.Size(159, 20)
        Me.txtRepetir.TabIndex = 3
        Me.txtRepetir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btSalir
        '
        Me.btSalir.BorderStyle.EdgeRadius = 30
        Me.btSalir.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btSalir.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btSalir.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btSalir.ForegroundImageStyle.Image = Global.appContable.My.Resources.Resources.Salir
        Me.btSalir.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSalir.Location = New System.Drawing.Point(181, 152)
        Me.btSalir.Name = "btSalir"
        Me.btSalir.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver
        Me.btSalir.Size = New System.Drawing.Size(85, 31)
        Me.btSalir.TabIndex = 5
        Me.btSalir.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btSalir.TextStyle.Text = "Cancelar"
        Me.btSalir.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btEntrar
        '
        Me.btEntrar.BorderStyle.EdgeRadius = 30
        Me.btEntrar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btEntrar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btEntrar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btEntrar.ForegroundImageStyle.Image = Global.appContable.My.Resources.Resources.ChangePassword
        Me.btEntrar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btEntrar.Location = New System.Drawing.Point(31, 152)
        Me.btEntrar.Name = "btEntrar"
        Me.btEntrar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.btEntrar.Size = New System.Drawing.Size(145, 31)
        Me.btEntrar.TabIndex = 4
        Me.btEntrar.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btEntrar.TextStyle.Text = "Cambiar Contraseña"
        Me.btEntrar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Contraseña nueva:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Contraseña:"
        '
        'txtNueva
        '
        Me.txtNueva.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNueva.Border.Class = "TextBoxBorder"
        Me.txtNueva.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNueva.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNueva.Location = New System.Drawing.Point(122, 72)
        Me.txtNueva.Name = "txtNueva"
        Me.txtNueva.ReadOnly = True
        Me.txtNueva.Size = New System.Drawing.Size(159, 20)
        Me.txtNueva.TabIndex = 2
        Me.txtNueva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActual
        '
        Me.txtActual.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtActual.Border.Class = "TextBoxBorder"
        Me.txtActual.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActual.Location = New System.Drawing.Point(122, 46)
        Me.txtActual.Name = "txtActual"
        Me.txtActual.ReadOnly = True
        Me.txtActual.Size = New System.Drawing.Size(159, 20)
        Me.txtActual.TabIndex = 1
        Me.txtActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.appContable.My.Resources.Resources.Linea
        Me.PictureBox1.Location = New System.Drawing.Point(18, 135)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(263, 4)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 295)
        Me.Controls.Add(Me.ElGroupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Sesión en SCE - El Maná"
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        CType(Me.btSalir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btEntrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtNueva As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtActual As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btSalir As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents btEntrar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRepetir As DevComponents.DotNetBar.Controls.TextBoxX
End Class
