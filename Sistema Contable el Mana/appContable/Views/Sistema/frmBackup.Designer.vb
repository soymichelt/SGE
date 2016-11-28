Imports MaterialSkin.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackup
    Inherits MaterialForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackup))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MaterialTabSelector1 = New MaterialSkin.Controls.MaterialTabSelector()
        Me.MaterialTabControl1 = New MaterialSkin.Controls.MaterialTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.MaterialSingleLineTextField1 = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.btExaminar = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.dtRegistro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fdbExplorador = New System.Windows.Forms.FolderBrowserDialog()
        Me.btCrearRespaldo = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.btCancelar = New MaterialSkin.Controls.MaterialFlatButton()
        Me.Panel1.SuspendLayout()
        Me.MaterialTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MaterialTabSelector1)
        Me.Panel1.Location = New System.Drawing.Point(-2, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(714, 157)
        Me.Panel1.TabIndex = 0
        '
        'MaterialTabSelector1
        '
        Me.MaterialTabSelector1.BaseTabControl = Me.MaterialTabControl1
        Me.MaterialTabSelector1.Depth = 0
        Me.MaterialTabSelector1.Location = New System.Drawing.Point(82, 57)
        Me.MaterialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabSelector1.Name = "MaterialTabSelector1"
        Me.MaterialTabSelector1.Size = New System.Drawing.Size(554, 35)
        Me.MaterialTabSelector1.TabIndex = 0
        Me.MaterialTabSelector1.Text = "MaterialTabSelector1"
        '
        'MaterialTabControl1
        '
        Me.MaterialTabControl1.Controls.Add(Me.TabPage1)
        Me.MaterialTabControl1.Controls.Add(Me.TabPage2)
        Me.MaterialTabControl1.Depth = 0
        Me.MaterialTabControl1.Location = New System.Drawing.Point(80, 162)
        Me.MaterialTabControl1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabControl1.Name = "MaterialTabControl1"
        Me.MaterialTabControl1.SelectedIndex = 0
        Me.MaterialTabControl1.Size = New System.Drawing.Size(554, 321)
        Me.MaterialTabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btCancelar)
        Me.TabPage1.Controls.Add(Me.btCrearRespaldo)
        Me.TabPage1.Controls.Add(Me.btExaminar)
        Me.TabPage1.Controls.Add(Me.MaterialSingleLineTextField1)
        Me.TabPage1.Controls.Add(Me.MaterialLabel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(546, 294)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Crear Respaldos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtRegistro)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(546, 294)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Puntos de Restauración"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel1.Location = New System.Drawing.Point(15, 17)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(166, 19)
        Me.MaterialLabel1.TabIndex = 0
        Me.MaterialLabel1.Text = "Directorio de Respaldo:"
        '
        'MaterialSingleLineTextField1
        '
        Me.MaterialSingleLineTextField1.Depth = 0
        Me.MaterialSingleLineTextField1.Enabled = False
        Me.MaterialSingleLineTextField1.Hint = ""
        Me.MaterialSingleLineTextField1.Location = New System.Drawing.Point(187, 14)
        Me.MaterialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialSingleLineTextField1.Name = "MaterialSingleLineTextField1"
        Me.MaterialSingleLineTextField1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MaterialSingleLineTextField1.SelectedText = ""
        Me.MaterialSingleLineTextField1.SelectionLength = 0
        Me.MaterialSingleLineTextField1.SelectionStart = 0
        Me.MaterialSingleLineTextField1.Size = New System.Drawing.Size(316, 23)
        Me.MaterialSingleLineTextField1.TabIndex = 1
        Me.MaterialSingleLineTextField1.UseSystemPasswordChar = False
        '
        'btExaminar
        '
        Me.btExaminar.Depth = 0
        Me.btExaminar.Location = New System.Drawing.Point(501, 11)
        Me.btExaminar.MouseState = MaterialSkin.MouseState.HOVER
        Me.btExaminar.Name = "btExaminar"
        Me.btExaminar.Primary = True
        Me.btExaminar.Size = New System.Drawing.Size(30, 30)
        Me.btExaminar.TabIndex = 2
        Me.btExaminar.Text = "..."
        Me.btExaminar.UseVisualStyleBackColor = True
        '
        'dtRegistro
        '
        Me.dtRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtRegistro.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtRegistro.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dtRegistro.Location = New System.Drawing.Point(16, 20)
        Me.dtRegistro.Name = "dtRegistro"
        Me.dtRegistro.Size = New System.Drawing.Size(509, 274)
        Me.dtRegistro.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-1, 221)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(713, 324)
        Me.Panel2.TabIndex = 1
        '
        'btCrearRespaldo
        '
        Me.btCrearRespaldo.Depth = 0
        Me.btCrearRespaldo.Location = New System.Drawing.Point(19, 56)
        Me.btCrearRespaldo.MouseState = MaterialSkin.MouseState.HOVER
        Me.btCrearRespaldo.Name = "btCrearRespaldo"
        Me.btCrearRespaldo.Primary = True
        Me.btCrearRespaldo.Size = New System.Drawing.Size(238, 36)
        Me.btCrearRespaldo.TabIndex = 3
        Me.btCrearRespaldo.Text = "Crear Punto de Restauración"
        Me.btCrearRespaldo.UseVisualStyleBackColor = True
        '
        'btCancelar
        '
        Me.btCancelar.AutoSize = True
        Me.btCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btCancelar.Depth = 0
        Me.btCancelar.Location = New System.Drawing.Point(264, 56)
        Me.btCancelar.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btCancelar.MouseState = MaterialSkin.MouseState.HOVER
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Primary = False
        Me.btCancelar.Size = New System.Drawing.Size(82, 36)
        Me.btCancelar.TabIndex = 4
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(710, 545)
        Me.Controls.Add(Me.MaterialTabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Respaldos y Restauración"
        Me.Panel1.ResumeLayout(False)
        Me.MaterialTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dtRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MaterialTabControl1 As MaterialSkin.Controls.MaterialTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents MaterialTabSelector1 As MaterialSkin.Controls.MaterialTabSelector
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialSingleLineTextField1 As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents btExaminar As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents dtRegistro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents fdbExplorador As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btCrearRespaldo As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents btCancelar As MaterialSkin.Controls.MaterialFlatButton
End Class
