<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountManager))
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.btEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.rdNo = New System.Windows.Forms.RadioButton()
        Me.rdSi = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdAcreedora = New System.Windows.Forms.RadioButton()
        Me.rdDeudora = New System.Windows.Forms.RadioButton()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCodigoCuenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbGrupo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        Me.pnBuscar.SuspendLayout()
        Me.pnBusqueda.SuspendLayout()
        CType(Me.btExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btEditar, Me.btEliminar, Me.ToolStripSeparator1, Me.btBuscar})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(967, 39)
        Me.Menu.TabIndex = 1
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
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ElGroupBox2)
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
        Me.PanelEx1.TabIndex = 1
        '
        'ElGroupBox2
        '
        Me.ElGroupBox2.BackgroundStyle.GradientAngle = 45.0!
        Me.ElGroupBox2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias
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
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Tarjeta Paralela"
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.rdNo)
        Me.ElGroupBox2.Controls.Add(Me.rdSi)
        Me.ElGroupBox2.Controls.Add(Me.TextBox1)
        Me.ElGroupBox2.Controls.Add(Me.Label9)
        Me.ElGroupBox2.Location = New System.Drawing.Point(21, 153)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(331, 75)
        Me.ElGroupBox2.TabIndex = 3
        '
        'rdNo
        '
        Me.rdNo.AutoSize = True
        Me.rdNo.Checked = True
        Me.rdNo.Enabled = False
        Me.rdNo.Location = New System.Drawing.Point(135, 36)
        Me.rdNo.Name = "rdNo"
        Me.rdNo.Size = New System.Drawing.Size(38, 18)
        Me.rdNo.TabIndex = 2
        Me.rdNo.TabStop = True
        Me.rdNo.Text = "No"
        Me.rdNo.UseVisualStyleBackColor = True
        '
        'rdSi
        '
        Me.rdSi.AutoSize = True
        Me.rdSi.Enabled = False
        Me.rdSi.Location = New System.Drawing.Point(95, 36)
        Me.rdSi.Name = "rdSi"
        Me.rdSi.Size = New System.Drawing.Size(34, 18)
        Me.rdSi.TabIndex = 1
        Me.rdSi.Text = "Si"
        Me.rdSi.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(513, 146)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 20)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 14)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Asociar Kardex:"
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Datos Cuenta"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.Label4)
        Me.ElGroupBox1.Controls.Add(Me.rdAcreedora)
        Me.ElGroupBox1.Controls.Add(Me.rdDeudora)
        Me.ElGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.ElGroupBox1.Controls.Add(Me.txtCodigoCuenta)
        Me.ElGroupBox1.Controls.Add(Me.cmbGrupo)
        Me.ElGroupBox1.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Location = New System.Drawing.Point(21, 11)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(331, 136)
        Me.ElGroupBox1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 14)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Naturaleza:"
        '
        'rdAcreedora
        '
        Me.rdAcreedora.AutoSize = True
        Me.rdAcreedora.Location = New System.Drawing.Point(167, 106)
        Me.rdAcreedora.Name = "rdAcreedora"
        Me.rdAcreedora.Size = New System.Drawing.Size(77, 18)
        Me.rdAcreedora.TabIndex = 6
        Me.rdAcreedora.Text = "Acreedora"
        Me.rdAcreedora.UseVisualStyleBackColor = True
        '
        'rdDeudora
        '
        Me.rdDeudora.AutoSize = True
        Me.rdDeudora.Location = New System.Drawing.Point(95, 106)
        Me.rdDeudora.Name = "rdDeudora"
        Me.rdDeudora.Size = New System.Drawing.Size(66, 18)
        Me.rdDeudora.TabIndex = 4
        Me.rdDeudora.Text = "Deudora"
        Me.rdDeudora.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.Location = New System.Drawing.Point(95, 80)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(218, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtCodigoCuenta
        '
        '
        '
        '
        Me.txtCodigoCuenta.Border.Class = "TextBoxBorder"
        Me.txtCodigoCuenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigoCuenta.Location = New System.Drawing.Point(95, 55)
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.Size = New System.Drawing.Size(218, 20)
        Me.txtCodigoCuenta.TabIndex = 2
        '
        'cmbGrupo
        '
        Me.cmbGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGrupo.DisplayMember = "Text"
        Me.cmbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.ItemHeight = 14
        Me.cmbGrupo.Location = New System.Drawing.Point(95, 30)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(218, 20)
        Me.cmbGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbGrupo.TabIndex = 1
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
        Me.Label3.Location = New System.Drawing.Point(23, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código Cuenta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Grupo:"
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
        Me.pnBuscar.Size = New System.Drawing.Size(593, 40)
        Me.pnBuscar.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnBuscar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnBuscar.Style.GradientAngle = 90
        Me.pnBuscar.TabIndex = 2
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
        Me.pnBusqueda.TabIndex = 4
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
        Me.ComboItem1.Text = "Código"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Descripción"
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
        Me.PanelEx2.TabIndex = 3
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
        Me.dtRegistro.Size = New System.Drawing.Size(593, 314)
        Me.dtRegistro.TabIndex = 3
        '
        'frmAccountManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 393)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.pnBuscar)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmAccountManager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión de Cuentas"
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        Me.pnBuscar.ResumeLayout(False)
        Me.pnBusqueda.ResumeLayout(False)
        Me.pnBusqueda.PerformLayout()
        CType(Me.btExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents pnBuscar As DevComponents.DotNetBar.PanelEx
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCuenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdDeudora As System.Windows.Forms.RadioButton
    Friend WithEvents rdAcreedora As System.Windows.Forms.RadioButton
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbBuscar As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btExportar As Klik.Windows.Forms.v1.EntryLib.ELButton
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItem As DevComponents.Editors.IntegerInput
    Friend WithEvents pnBusqueda As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rdSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdNo As System.Windows.Forms.RadioButton
End Class
