<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntriesAccounting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntriesAccounting))
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImprimir = New System.Windows.Forms.ToolStripButton()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnDetalle = New DevComponents.DotNetBar.PanelEx()
        Me.pnExistencia = New DevComponents.DotNetBar.PanelEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEntrada = New DevComponents.Editors.DoubleInput()
        Me.txtSalida = New DevComponents.Editors.DoubleInput()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtTotalSaldoSel = New DevComponents.Editors.DoubleInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalDeberSel = New DevComponents.Editors.DoubleInput()
        Me.txtTotalHaberSel = New DevComponents.Editors.DoubleInput()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIdCuenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtNCuenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btBuscarCuenta = New DevComponents.DotNetBar.ButtonX()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.pnSaldo = New DevComponents.DotNetBar.PanelEx()
        Me.lblDeber = New System.Windows.Forms.Label()
        Me.txtDeber = New DevComponents.Editors.DoubleInput()
        Me.txtHaber = New DevComponents.Editors.DoubleInput()
        Me.lblHaber = New System.Windows.Forms.Label()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ElGroupBox2 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalHaber = New DevComponents.Editors.DoubleInput()
        Me.txtTotalDeber = New DevComponents.Editors.DoubleInput()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ElGroupBox1 = New Klik.Windows.Forms.v1.EntryLib.ELGroupBox()
        Me.txtNComprobante = New DevComponents.Editors.IntegerInput()
        Me.dtpFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtReferencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConcepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.Menu.SuspendLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDetalle.SuspendLayout()
        Me.pnExistencia.SuspendLayout()
        CType(Me.txtEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalSaldoSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDeberSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalHaberSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSaldo.SuspendLayout()
        CType(Me.txtDeber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHaber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox2.SuspendLayout()
        CType(Me.txtTotalHaber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDeber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ElGroupBox1.SuspendLayout()
        CType(Me.txtNComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btEditar, Me.btEliminar, Me.ToolStripSeparator1, Me.btImprimir})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(1078, 39)
        Me.Menu.TabIndex = 2
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
        'btEliminar
        '
        Me.btEliminar.Enabled = False
        Me.btEliminar.ForeColor = System.Drawing.Color.Black
        Me.btEliminar.Image = Global.appContable.My.Resources.Resources.Eliminar
        Me.btEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(75, 36)
        Me.btEliminar.Text = "Anular"
        Me.btEliminar.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btImprimir
        '
        Me.btImprimir.Enabled = False
        Me.btImprimir.ForeColor = System.Drawing.Color.Black
        Me.btImprimir.Image = Global.appContable.My.Resources.Resources.imprimir_det
        Me.btImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Size = New System.Drawing.Size(79, 36)
        Me.btImprimir.Text = "Imprimir"
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
        Me.dtRegistro.Location = New System.Drawing.Point(374, 127)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(704, 266)
        Me.dtRegistro.TabIndex = 6
        '
        'pnDetalle
        '
        Me.pnDetalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnDetalle.Controls.Add(Me.pnExistencia)
        Me.pnDetalle.Controls.Add(Me.PanelEx2)
        Me.pnDetalle.Controls.Add(Me.pnSaldo)
        Me.pnDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDetalle.Location = New System.Drawing.Point(374, 39)
        Me.pnDetalle.Name = "pnDetalle"
        Me.pnDetalle.Size = New System.Drawing.Size(704, 88)
        Me.pnDetalle.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnDetalle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnDetalle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnDetalle.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnDetalle.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnDetalle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnDetalle.Style.GradientAngle = 90
        Me.pnDetalle.TabIndex = 5
        '
        'pnExistencia
        '
        Me.pnExistencia.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnExistencia.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnExistencia.Controls.Add(Me.Label8)
        Me.pnExistencia.Controls.Add(Me.txtEntrada)
        Me.pnExistencia.Controls.Add(Me.txtSalida)
        Me.pnExistencia.Controls.Add(Me.Label9)
        Me.pnExistencia.Location = New System.Drawing.Point(466, 46)
        Me.pnExistencia.Name = "pnExistencia"
        Me.pnExistencia.Size = New System.Drawing.Size(232, 33)
        Me.pnExistencia.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnExistencia.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnExistencia.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnExistencia.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnExistencia.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnExistencia.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnExistencia.Style.GradientAngle = 90
        Me.pnExistencia.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 14)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Entrada:"
        '
        'txtEntrada
        '
        '
        '
        '
        Me.txtEntrada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtEntrada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEntrada.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtEntrada.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntrada.Increment = 1.0R
        Me.txtEntrada.IsInputReadOnly = True
        Me.txtEntrada.Location = New System.Drawing.Point(50, 6)
        Me.txtEntrada.MinValue = 0.0R
        Me.txtEntrada.Name = "txtEntrada"
        Me.txtEntrada.Size = New System.Drawing.Size(67, 20)
        Me.txtEntrada.TabIndex = 3
        '
        'txtSalida
        '
        '
        '
        '
        Me.txtSalida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSalida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSalida.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSalida.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalida.Increment = 1.0R
        Me.txtSalida.IsInputReadOnly = True
        Me.txtSalida.Location = New System.Drawing.Point(161, 6)
        Me.txtSalida.MinValue = 0.0R
        Me.txtSalida.Name = "txtSalida"
        Me.txtSalida.Size = New System.Drawing.Size(67, 20)
        Me.txtSalida.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(118, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 14)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Salida:"
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.PictureBox1)
        Me.PanelEx2.Controls.Add(Me.txtTotalSaldoSel)
        Me.PanelEx2.Controls.Add(Me.Label7)
        Me.PanelEx2.Controls.Add(Me.Label5)
        Me.PanelEx2.Controls.Add(Me.txtTotalDeberSel)
        Me.PanelEx2.Controls.Add(Me.txtTotalHaberSel)
        Me.PanelEx2.Controls.Add(Me.Label6)
        Me.PanelEx2.Controls.Add(Me.txtIdCuenta)
        Me.PanelEx2.Controls.Add(Me.lblBuscar)
        Me.PanelEx2.Controls.Add(Me.txtNCuenta)
        Me.PanelEx2.Controls.Add(Me.btBuscarCuenta)
        Me.PanelEx2.Controls.Add(Me.txtDescripcion)
        Me.PanelEx2.Location = New System.Drawing.Point(6, 9)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(438, 70)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.appContable.My.Resources.Resources.Linea
        Me.PictureBox1.Location = New System.Drawing.Point(7, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(425, 4)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'txtTotalSaldoSel
        '
        '
        '
        '
        Me.txtTotalSaldoSel.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalSaldoSel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalSaldoSel.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalSaldoSel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSaldoSel.Increment = 1.0R
        Me.txtTotalSaldoSel.Location = New System.Drawing.Point(353, 43)
        Me.txtTotalSaldoSel.Name = "txtTotalSaldoSel"
        Me.txtTotalSaldoSel.Size = New System.Drawing.Size(80, 20)
        Me.txtTotalSaldoSel.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(295, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 14)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "T / Saldo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 14)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "T / Deber:"
        '
        'txtTotalDeberSel
        '
        '
        '
        '
        Me.txtTotalDeberSel.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalDeberSel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalDeberSel.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalDeberSel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDeberSel.Increment = 1.0R
        Me.txtTotalDeberSel.Location = New System.Drawing.Point(64, 43)
        Me.txtTotalDeberSel.Name = "txtTotalDeberSel"
        Me.txtTotalDeberSel.Size = New System.Drawing.Size(80, 20)
        Me.txtTotalDeberSel.TabIndex = 13
        '
        'txtTotalHaberSel
        '
        '
        '
        '
        Me.txtTotalHaberSel.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalHaberSel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalHaberSel.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalHaberSel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHaberSel.Increment = 1.0R
        Me.txtTotalHaberSel.Location = New System.Drawing.Point(210, 43)
        Me.txtTotalHaberSel.Name = "txtTotalHaberSel"
        Me.txtTotalHaberSel.Size = New System.Drawing.Size(80, 20)
        Me.txtTotalHaberSel.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(150, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "T / Haber:"
        '
        'txtIdCuenta
        '
        '
        '
        '
        Me.txtIdCuenta.Border.Class = "TextBoxBorder"
        Me.txtIdCuenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdCuenta.Location = New System.Drawing.Point(-8, 6)
        Me.txtIdCuenta.Name = "txtIdCuenta"
        Me.txtIdCuenta.Size = New System.Drawing.Size(10, 20)
        Me.txtIdCuenta.TabIndex = 11
        Me.txtIdCuenta.Visible = False
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.BackColor = System.Drawing.Color.Transparent
        Me.lblBuscar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(4, 9)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(44, 14)
        Me.lblBuscar.TabIndex = 3
        Me.lblBuscar.Text = "Cuenta:"
        '
        'txtNCuenta
        '
        '
        '
        '
        Me.txtNCuenta.Border.Class = "TextBoxBorder"
        Me.txtNCuenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNCuenta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNCuenta.Location = New System.Drawing.Point(51, 6)
        Me.txtNCuenta.Name = "txtNCuenta"
        Me.txtNCuenta.Size = New System.Drawing.Size(70, 20)
        Me.txtNCuenta.TabIndex = 4
        '
        'btBuscarCuenta
        '
        Me.btBuscarCuenta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btBuscarCuenta.BackColor = System.Drawing.Color.Transparent
        Me.btBuscarCuenta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btBuscarCuenta.Image = Global.appContable.My.Resources.Resources.btn_buscar
        Me.btBuscarCuenta.Location = New System.Drawing.Point(403, 3)
        Me.btBuscarCuenta.Name = "btBuscarCuenta"
        Me.btBuscarCuenta.Size = New System.Drawing.Size(29, 24)
        Me.btBuscarCuenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btBuscarCuenta.TabIndex = 9
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(120, 6)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(284, 20)
        Me.txtDescripcion.TabIndex = 10
        '
        'pnSaldo
        '
        Me.pnSaldo.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnSaldo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnSaldo.Controls.Add(Me.lblDeber)
        Me.pnSaldo.Controls.Add(Me.txtDeber)
        Me.pnSaldo.Controls.Add(Me.txtHaber)
        Me.pnSaldo.Controls.Add(Me.lblHaber)
        Me.pnSaldo.Location = New System.Drawing.Point(466, 9)
        Me.pnSaldo.Name = "pnSaldo"
        Me.pnSaldo.Size = New System.Drawing.Size(232, 33)
        Me.pnSaldo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnSaldo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnSaldo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnSaldo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnSaldo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnSaldo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnSaldo.Style.GradientAngle = 90
        Me.pnSaldo.TabIndex = 10
        '
        'lblDeber
        '
        Me.lblDeber.AutoSize = True
        Me.lblDeber.BackColor = System.Drawing.Color.Transparent
        Me.lblDeber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeber.Location = New System.Drawing.Point(1, 8)
        Me.lblDeber.Name = "lblDeber"
        Me.lblDeber.Size = New System.Drawing.Size(39, 14)
        Me.lblDeber.TabIndex = 5
        Me.lblDeber.Text = "Deber:"
        '
        'txtDeber
        '
        '
        '
        '
        Me.txtDeber.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDeber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDeber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDeber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeber.Increment = 1.0R
        Me.txtDeber.Location = New System.Drawing.Point(50, 6)
        Me.txtDeber.MinValue = 0.0R
        Me.txtDeber.Name = "txtDeber"
        Me.txtDeber.Size = New System.Drawing.Size(67, 20)
        Me.txtDeber.TabIndex = 1
        '
        'txtHaber
        '
        '
        '
        '
        Me.txtHaber.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtHaber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHaber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtHaber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHaber.Increment = 1.0R
        Me.txtHaber.Location = New System.Drawing.Point(161, 6)
        Me.txtHaber.MinValue = 0.0R
        Me.txtHaber.Name = "txtHaber"
        Me.txtHaber.Size = New System.Drawing.Size(67, 20)
        Me.txtHaber.TabIndex = 2
        '
        'lblHaber
        '
        Me.lblHaber.AutoSize = True
        Me.lblHaber.BackColor = System.Drawing.Color.Transparent
        Me.lblHaber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHaber.Location = New System.Drawing.Point(118, 8)
        Me.lblHaber.Name = "lblHaber"
        Me.lblHaber.Size = New System.Drawing.Size(39, 14)
        Me.lblHaber.TabIndex = 7
        Me.lblHaber.Text = "Haber:"
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
        Me.PanelEx1.TabIndex = 4
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
        Me.ElGroupBox2.CaptionStyle.TextStyle.Text = "Saldo Comprob."
        Me.ElGroupBox2.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox2.Controls.Add(Me.Label11)
        Me.ElGroupBox2.Controls.Add(Me.Label10)
        Me.ElGroupBox2.Controls.Add(Me.txtTotalHaber)
        Me.ElGroupBox2.Controls.Add(Me.txtTotalDeber)
        Me.ElGroupBox2.Controls.Add(Me.TextBox1)
        Me.ElGroupBox2.Location = New System.Drawing.Point(21, 196)
        Me.ElGroupBox2.Name = "ElGroupBox2"
        Me.ElGroupBox2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox2.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox2.Size = New System.Drawing.Size(331, 60)
        Me.ElGroupBox2.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(163, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 14)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "T / Haber:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 14)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "T / Deber:"
        '
        'txtTotalHaber
        '
        '
        '
        '
        Me.txtTotalHaber.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalHaber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalHaber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalHaber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHaber.Increment = 1.0R
        Me.txtTotalHaber.Location = New System.Drawing.Point(223, 30)
        Me.txtTotalHaber.Name = "txtTotalHaber"
        Me.txtTotalHaber.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalHaber.TabIndex = 2
        '
        'txtTotalDeber
        '
        '
        '
        '
        Me.txtTotalDeber.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTotalDeber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTotalDeber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTotalDeber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDeber.Increment = 1.0R
        Me.txtTotalDeber.Location = New System.Drawing.Point(68, 30)
        Me.txtTotalDeber.Name = "txtTotalDeber"
        Me.txtTotalDeber.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalDeber.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(513, 146)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 20)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Visible = False
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
        Me.ElGroupBox1.CaptionStyle.TextStyle.Text = "Comprobante"
        Me.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElGroupBox1.Controls.Add(Me.txtNComprobante)
        Me.ElGroupBox1.Controls.Add(Me.dtpFecha)
        Me.ElGroupBox1.Controls.Add(Me.txtReferencia)
        Me.ElGroupBox1.Controls.Add(Me.Label4)
        Me.ElGroupBox1.Controls.Add(Me.txtConcepto)
        Me.ElGroupBox1.Controls.Add(Me.Label2)
        Me.ElGroupBox1.Controls.Add(Me.txtCodigo)
        Me.ElGroupBox1.Controls.Add(Me.Label3)
        Me.ElGroupBox1.Controls.Add(Me.Label1)
        Me.ElGroupBox1.Location = New System.Drawing.Point(21, 11)
        Me.ElGroupBox1.Name = "ElGroupBox1"
        Me.ElGroupBox1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue
        Me.ElGroupBox1.Padding = New System.Windows.Forms.Padding(4, 27, 4, 3)
        Me.ElGroupBox1.Size = New System.Drawing.Size(331, 179)
        Me.ElGroupBox1.TabIndex = 2
        '
        'txtNComprobante
        '
        '
        '
        '
        Me.txtNComprobante.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtNComprobante.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNComprobante.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtNComprobante.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNComprobante.Location = New System.Drawing.Point(100, 30)
        Me.txtNComprobante.Name = "txtNComprobante"
        Me.txtNComprobante.Size = New System.Drawing.Size(218, 20)
        Me.txtNComprobante.TabIndex = 2
        '
        'dtpFecha
        '
        '
        '
        '
        Me.dtpFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpFecha.ButtonDropDown.Visible = True
        Me.dtpFecha.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(100, 55)
        '
        '
        '
        Me.dtpFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFecha.MonthCalendar.BackgroundStyle.Class = ""
        Me.dtpFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.Class = ""
        Me.dtpFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.MonthCalendar.DisplayMonth = New Date(2016, 5, 1, 0, 0, 0, 0)
        Me.dtpFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.Class = ""
        Me.dtpFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFecha.MonthCalendar.TodayButtonVisible = True
        Me.dtpFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(103, 20)
        Me.dtpFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpFecha.TabIndex = 4
        '
        'txtReferencia
        '
        '
        '
        '
        Me.txtReferencia.Border.Class = "TextBoxBorder"
        Me.txtReferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReferencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(100, 145)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(218, 20)
        Me.txtReferencia.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Referencia:"
        '
        'txtConcepto
        '
        '
        '
        '
        Me.txtConcepto.Border.Class = "TextBoxBorder"
        Me.txtConcepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConcepto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.Location = New System.Drawing.Point(100, 80)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(218, 60)
        Me.txtConcepto.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Concepto:"
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
        Me.Label3.Location = New System.Drawing.Point(57, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Fecha:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "N° Comprobante:"
        '
        'KFormManager1
        '
        Me.KFormManager1.BackgroundImageStyle.Alpha = 100
        Me.KFormManager1.BackgroundImageStyle.ImageEffect = Klik.Windows.Forms.v1.Common.ImageEffect.Mirror
        Me.KFormManager1.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle
        Me.KFormManager1.MainContainer = Me
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
        'frmEntriesAccounting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 393)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.pnDetalle)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmEntriesAccounting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asientos Contables"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDetalle.ResumeLayout(False)
        Me.pnExistencia.ResumeLayout(False)
        Me.pnExistencia.PerformLayout()
        CType(Me.txtEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalSaldoSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDeberSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalHaberSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSaldo.ResumeLayout(False)
        Me.pnSaldo.PerformLayout()
        CType(Me.txtDeber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHaber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.ElGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox2.ResumeLayout(False)
        Me.ElGroupBox2.PerformLayout()
        CType(Me.txtTotalHaber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDeber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ElGroupBox1.ResumeLayout(False)
        Me.ElGroupBox1.PerformLayout()
        CType(Me.txtNComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents pnDetalle As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtNCuenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ElGroupBox1 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtDeber As DevComponents.Editors.DoubleInput
    Friend WithEvents lblDeber As System.Windows.Forms.Label
    Friend WithEvents txtHaber As DevComponents.Editors.DoubleInput
    Friend WithEvents lblHaber As System.Windows.Forms.Label
    Friend WithEvents btBuscarCuenta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNComprobante As DevComponents.Editors.IntegerInput
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
    Friend WithEvents ElGroupBox2 As Klik.Windows.Forms.v1.EntryLib.ELGroupBox
    Friend WithEvents txtTotalHaber As DevComponents.Editors.DoubleInput
    Friend WithEvents txtTotalDeber As DevComponents.Editors.DoubleInput
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents pnSaldo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIdCuenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents pnExistencia As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEntrada As DevComponents.Editors.DoubleInput
    Friend WithEvents txtSalida As DevComponents.Editors.DoubleInput
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSaldoSel As DevComponents.Editors.DoubleInput
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDeberSel As DevComponents.Editors.DoubleInput
    Friend WithEvents txtTotalHaberSel As DevComponents.Editors.DoubleInput
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
End Class
