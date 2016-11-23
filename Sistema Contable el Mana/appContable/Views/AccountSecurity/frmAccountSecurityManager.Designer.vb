<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountSecurityManager
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountSecurityManager))
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnBuscar = New DevComponents.DotNetBar.PanelEx()
        Me.pnBusqueda = New DevComponents.DotNetBar.PanelEx()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btExportar = New Klik.Windows.Forms.v1.EntryLib.ELButton()
        Me.txtBuscar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbBuscar = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.txtItem = New DevComponents.Editors.IntegerInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.lblEditPass = New System.Windows.Forms.Label()
        Me.chkMostrar = New System.Windows.Forms.CheckBox()
        Me.txtContraseña = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtApellidos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombres = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.btEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBuscar.SuspendLayout()
        Me.pnBusqueda.SuspendLayout()
        CType(Me.btExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        Me.Menu.SuspendLayout()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtRegistro
        '
        Me.dtRegistro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(374, 79)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(592, 314)
        Me.dtRegistro.TabIndex = 7
        '
        'pnBuscar
        '
        Me.pnBuscar.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnBuscar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnBuscar.Controls.Add(Me.pnBusqueda)
        Me.pnBuscar.Controls.Add(Me.PanelEx2)
        Me.pnBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnBuscar.Location = New System.Drawing.Point(374, 39)
        Me.pnBuscar.Name = "pnBuscar"
        Me.pnBuscar.Size = New System.Drawing.Size(592, 40)
        Me.pnBuscar.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnBuscar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnBuscar.Style.GradientAngle = 90
        Me.pnBuscar.TabIndex = 6
        '
        'pnBusqueda
        '
        Me.pnBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnBusqueda.Controls.Add(Me.lblBuscar)
        Me.pnBusqueda.Controls.Add(Me.btExportar)
        Me.pnBusqueda.Controls.Add(Me.txtBuscar)
        Me.pnBusqueda.Controls.Add(Me.cmbBuscar)
        Me.pnBusqueda.Location = New System.Drawing.Point(160, 5)
        Me.pnBusqueda.Name = "pnBusqueda"
        Me.pnBusqueda.Size = New System.Drawing.Size(427, 30)
        Me.pnBusqueda.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnBusqueda.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnBusqueda.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnBusqueda.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnBusqueda.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnBusqueda.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnBusqueda.Style.GradientAngle = 90
        Me.pnBusqueda.TabIndex = 21
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.BackColor = System.Drawing.Color.Transparent
        Me.lblBuscar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(3, 7)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 14)
        Me.lblBuscar.TabIndex = 3
        Me.lblBuscar.Text = "Buscar:"
        '
        'btExportar
        '
        Me.btExportar.BorderStyle.EdgeRadius = 30
        Me.btExportar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.btExportar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btExportar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.btExportar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btExportar.ForegroundImageStyle.Image = Global.appContable.My.Resources.Resources.Exportar
        Me.btExportar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btExportar.Location = New System.Drawing.Point(293, 3)
        Me.btExportar.Name = "btExportar"
        Me.btExportar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.btExportar.Size = New System.Drawing.Size(129, 24)
        Me.btExportar.TabIndex = 19
        Me.btExportar.TextStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btExportar.TextStyle.Text = "Exportar Búsqueda"
        Me.btExportar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBuscar
        '
        '
        '
        '
        Me.txtBuscar.Border.Class = "TextBoxBorder"
        Me.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBuscar.Location = New System.Drawing.Point(145, 5)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(144, 20)
        Me.txtBuscar.TabIndex = 4
        '
        'cmbBuscar
        '
        Me.cmbBuscar.DisplayMember = "Text"
        Me.cmbBuscar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBuscar.FormattingEnabled = True
        Me.cmbBuscar.ItemHeight = 14
        Me.cmbBuscar.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbBuscar.Location = New System.Drawing.Point(50, 5)
        Me.cmbBuscar.Name = "cmbBuscar"
        Me.cmbBuscar.Size = New System.Drawing.Size(89, 20)
        Me.cmbBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBuscar.TabIndex = 15
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Nombre"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Usuario"
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.txtItem)
        Me.PanelEx2.Controls.Add(Me.Label5)
        Me.PanelEx2.Location = New System.Drawing.Point(5, 5)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(149, 30)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 20
        '
        'txtItem
        '
        Me.txtItem.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtItem.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtItem.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtItem.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.IsInputReadOnly = True
        Me.txtItem.Location = New System.Drawing.Point(60, 5)
        Me.txtItem.MinValue = 0
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(84, 20)
        Me.txtItem.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "N° ITEM:"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ElGroupBox1)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx1.Location = New System.Drawing.Point(0, 39)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(374, 354)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 4
        '
        'ElGroupBox1
        '
        Me.ElGroupBox1.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox1.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox1.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox1.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.SystemColors.ActiveCaption
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle
        Me.ElGroupBox1.CaptionStyle.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
        Me.ElGroupBox1.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid
        Me.ElGroupBox1.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ElGroupBox1.CaptionStyle.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox1.CaptionStyle.Size = New System.Drawing.Size(110, 24)
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Cuenta de Usuario"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.lblEditPass)
        Me.ElGroupBox1.Controls.Add(Me.chkMostrar)
        Me.ElGroupBox1.Controls.Add(Me.txtContraseña)
        Me.ElGroupBox1.Controls.Add(Me.Label4)
        Me.ElGroupBox1.Controls.Add(Me.txtUsuario)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.txtApellidos)
        Me.ElGroupBox1.Controls.Add(Me.txtNombres)
        Me.ElGroupBox1.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Location = New System.Drawing.Point(21, 11)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(331, 155)
        Me.ElGroupBox1.TabIndex = 2
        '
        'lblEditPass
        '
        Me.lblEditPass.AutoSize = True
        Me.lblEditPass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditPass.Location = New System.Drawing.Point(92, 134)
        Me.lblEditPass.Name = "lblEditPass"
        Me.lblEditPass.Size = New System.Drawing.Size(163, 14)
        Me.lblEditPass.TabIndex = 19
        Me.lblEditPass.Text = "La contraseña vacia no se edita"
        Me.lblEditPass.Visible = False
        '
        'chkMostrar
        '
        Me.chkMostrar.AutoSize = True
        Me.chkMostrar.Location = New System.Drawing.Point(250, 113)
        Me.chkMostrar.Name = "chkMostrar"
        Me.chkMostrar.Size = New System.Drawing.Size(63, 18)
        Me.chkMostrar.TabIndex = 17
        Me.chkMostrar.Text = "Mostrar"
        Me.chkMostrar.UseVisualStyleBackColor = True
        '
        'txtContraseña
        '
        '
        '
        '
        Me.txtContraseña.Border.Class = "TextBoxBorder"
        Me.txtContraseña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtContraseña.Location = New System.Drawing.Point(95, 111)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(149, 20)
        Me.txtContraseña.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 14)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Contraseña:"
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.Location = New System.Drawing.Point(95, 85)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(218, 20)
        Me.txtUsuario.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Usuario:"
        '
        'txtApellidos
        '
        '
        '
        '
        Me.txtApellidos.Border.Class = "TextBoxBorder"
        Me.txtApellidos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtApellidos.Location = New System.Drawing.Point(95, 59)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(218, 20)
        Me.txtApellidos.TabIndex = 3
        '
        'txtNombres
        '
        '
        '
        '
        Me.txtNombres.Border.Class = "TextBoxBorder"
        Me.txtNombres.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombres.Location = New System.Drawing.Point(95, 34)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(218, 20)
        Me.txtNombres.TabIndex = 2
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(513, 146)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(66, 20)
        Me.txtCodigo.TabIndex = 12
        Me.txtCodigo.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Apellidos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombres:"
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btEditar, Me.btEliminar, Me.ToolStripSeparator1, Me.btBuscar})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(966, 39)
        Me.Menu.TabIndex = 5
        Me.Menu.Text = "ToolStrip1"
        '
        'btNuevo
        '
        Me.btNuevo.ForeColor = System.Drawing.Color.Black
        Me.btNuevo.Image = Global.appContable.My.Resources.Resources.Nuevo
        Me.btNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(74, 36)
        Me.btNuevo.Text = "Nuevo"
        '
        'btGuardar
        '
        Me.btGuardar.ForeColor = System.Drawing.Color.Black
        Me.btGuardar.Image = Global.appContable.My.Resources.Resources.Guardar
        Me.btGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(83, 36)
        Me.btGuardar.Text = "Guardar"
        '
        'btEditar
        '
        Me.btEditar.Enabled = False
        Me.btEditar.ForeColor = System.Drawing.Color.Black
        Me.btEditar.Image = Global.appContable.My.Resources.Resources.Editar
        Me.btEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEditar.Name = "btEditar"
        Me.btEditar.Size = New System.Drawing.Size(70, 36)
        Me.btEditar.Text = "Editar"
        '
        'btEliminar
        '
        Me.btEliminar.Enabled = False
        Me.btEliminar.ForeColor = System.Drawing.Color.Black
        Me.btEliminar.Image = Global.appContable.My.Resources.Resources.Eliminar
        Me.btEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(79, 36)
        Me.btEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btBuscar
        '
        Me.btBuscar.ForeColor = System.Drawing.Color.Black
        Me.btBuscar.Image = Global.appContable.My.Resources.Resources.Buscar
        Me.btBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(78, 36)
        Me.btBuscar.Text = "Buscar"
        '
        'KFormManager1
        '
        Me.KFormManager1.BackgroundImageStyle.Alpha = 100
        Me.KFormManager1.BackgroundImageStyle.ImageEffect = Klik.Windows.Forms.v1.Common.ImageEffect.Mirror
        Me.KFormManager1.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.MainContainer = Me
        '
        'frmAccountSecurityManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 393)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.pnBuscar)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAccountSecurityManager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión de Usuarios"
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBuscar.ResumeLayout(False)
        Me.pnBusqueda.ResumeLayout(False)
        Me.pnBusqueda.PerformLayout()
        CType(Me.btExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents pnBuscar As DevComponents.DotNetBar.PanelEx
    Friend WithEvents pnBusqueda As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btExportar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents txtBuscar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbBuscar As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtItem As DevComponents.Editors.IntegerInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtApellidos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombres As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkMostrar As System.Windows.Forms.CheckBox
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents lblEditPass As System.Windows.Forms.Label
End Class
