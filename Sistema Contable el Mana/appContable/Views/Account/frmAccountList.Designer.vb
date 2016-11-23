<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountList))
        Me.Menu = New System.Windows.Forms.ToolStrip()
        Me.btNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.btEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btBuscar = New System.Windows.Forms.ToolStripButton()
        Me.KFormManager1 = New Klik.Windows.Forms.v1.Common.KFormManager(Me.components)
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
        Me.Menu.SuspendLayout()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBuscar.SuspendLayout()
        Me.pnBusqueda.SuspendLayout()
        CType(Me.btExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx2.SuspendLayout()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.BackColor = System.Drawing.Color.White
        Me.Menu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevo, Me.btGuardar, Me.btEditar, Me.btEliminar, Me.ToolStripSeparator1, Me.btBuscar})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(967, 39)
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
        'pnBuscar
        '
        Me.pnBuscar.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnBuscar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnBuscar.Controls.Add(Me.pnBusqueda)
        Me.pnBuscar.Controls.Add(Me.PanelEx2)
        Me.pnBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnBuscar.Location = New System.Drawing.Point(0, 39)
        Me.pnBuscar.Name = "pnBuscar"
        Me.pnBuscar.Size = New System.Drawing.Size(967, 40)
        Me.pnBuscar.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnBuscar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnBuscar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnBuscar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnBuscar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnBuscar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnBuscar.Style.GradientAngle = 90
        Me.pnBuscar.TabIndex = 4
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
        Me.dtRegistro.Location = New System.Drawing.Point(0, 79)
        Me.dtRegistro.MultiSelect = False
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRegistro.Size = New System.Drawing.Size(967, 314)
        Me.dtRegistro.TabIndex = 5
        '
        'frmAccountList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 393)
        Me.Controls.Add(Me.dtRegistro)
        Me.Controls.Add(Me.pnBuscar)
        Me.Controls.Add(Me.Menu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAccountList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Cuentas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        CType(Me.KFormManager1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents KFormManager1 As Klik.Windows.Forms.v1.Common.KFormManager
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
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
