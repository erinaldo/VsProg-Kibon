<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCipInicio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCipInicio))
        Me.gvCadRotas = New System.Windows.Forms.DataGridView
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Subgrupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RotaId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LimRev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndTempos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.butIniciar = New System.Windows.Forms.Button
        Me.radCipCompleto = New System.Windows.Forms.RadioButton
        Me.radCipParcial = New System.Windows.Forms.RadioButton
        Me.dsCipValid = New Geral.dsxCipValid
        Me.taCadRotas = New Geral.dsxCipValidTableAdapters.taxCadRotasVl
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.butFecha = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        CType(Me.gvCadRotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsCipValid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvCadRotas
        '
        Me.gvCadRotas.AllowUserToAddRows = False
        Me.gvCadRotas.AllowUserToDeleteRows = False
        Me.gvCadRotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvCadRotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCadRotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Grupo, Me.Subgrupo, Me.Descr, Me.RotaId, Me.LimRev, Me.EndTempos})
        Me.gvCadRotas.Location = New System.Drawing.Point(12, 57)
        Me.gvCadRotas.Name = "gvCadRotas"
        Me.gvCadRotas.ReadOnly = True
        Me.gvCadRotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCadRotas.Size = New System.Drawing.Size(674, 296)
        Me.gvCadRotas.TabIndex = 0
        '
        'Grupo
        '
        Me.Grupo.DataPropertyName = "Grupo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Grupo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 50
        '
        'Subgrupo
        '
        Me.Subgrupo.DataPropertyName = "Subgrupo"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Subgrupo.DefaultCellStyle = DataGridViewCellStyle4
        Me.Subgrupo.HeaderText = "Subgrupo"
        Me.Subgrupo.Name = "Subgrupo"
        Me.Subgrupo.ReadOnly = True
        Me.Subgrupo.Width = 50
        '
        'Descr
        '
        Me.Descr.DataPropertyName = "Descr"
        Me.Descr.HeaderText = "Descr"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        Me.Descr.Width = 500
        '
        'RotaId
        '
        Me.RotaId.DataPropertyName = "RotaId"
        Me.RotaId.HeaderText = "RotaId"
        Me.RotaId.Name = "RotaId"
        Me.RotaId.ReadOnly = True
        Me.RotaId.Visible = False
        '
        'LimRev
        '
        Me.LimRev.DataPropertyName = "LimRev"
        Me.LimRev.HeaderText = "LimRev"
        Me.LimRev.Name = "LimRev"
        Me.LimRev.ReadOnly = True
        Me.LimRev.Visible = False
        '
        'EndTempos
        '
        Me.EndTempos.DataPropertyName = "EndTempos"
        Me.EndTempos.HeaderText = "EndTempos"
        Me.EndTempos.Name = "EndTempos"
        Me.EndTempos.ReadOnly = True
        Me.EndTempos.Visible = False
        '
        'butIniciar
        '
        Me.butIniciar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butIniciar.Location = New System.Drawing.Point(228, 369)
        Me.butIniciar.Name = "butIniciar"
        Me.butIniciar.Size = New System.Drawing.Size(228, 30)
        Me.butIniciar.TabIndex = 1
        Me.butIniciar.Text = "Iniciar"
        Me.butIniciar.UseVisualStyleBackColor = True
        '
        'radCipCompleto
        '
        Me.radCipCompleto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.radCipCompleto.AutoSize = True
        Me.radCipCompleto.BackColor = System.Drawing.Color.Transparent
        Me.radCipCompleto.Checked = True
        Me.radCipCompleto.Location = New System.Drawing.Point(169, 34)
        Me.radCipCompleto.Name = "radCipCompleto"
        Me.radCipCompleto.Size = New System.Drawing.Size(87, 17)
        Me.radCipCompleto.TabIndex = 3
        Me.radCipCompleto.TabStop = True
        Me.radCipCompleto.Text = "Cip Completo"
        Me.radCipCompleto.UseVisualStyleBackColor = False
        '
        'radCipParcial
        '
        Me.radCipParcial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.radCipParcial.AutoSize = True
        Me.radCipParcial.BackColor = System.Drawing.Color.Transparent
        Me.radCipParcial.Location = New System.Drawing.Point(438, 34)
        Me.radCipParcial.Name = "radCipParcial"
        Me.radCipParcial.Size = New System.Drawing.Size(75, 17)
        Me.radCipParcial.TabIndex = 4
        Me.radCipParcial.Text = "Cip Parcial"
        Me.radCipParcial.UseVisualStyleBackColor = False
        '
        'dsCipValid
        '
        Me.dsCipValid.DataSetName = "dsxCipValid"
        Me.dsCipValid.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taCadRotas
        '
        Me.taCadRotas.ClearBeforeFill = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butFecha, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(698, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butFecha
        '
        Me.butFecha.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.butFecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butFecha.Image = CType(resources.GetObject("butFecha.Image"), System.Drawing.Image)
        Me.butFecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butFecha.Name = "butFecha"
        Me.butFecha.Size = New System.Drawing.Size(23, 22)
        Me.butFecha.Text = "Fechar"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel1.Text = "Iniciar CIP"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "CIP em execução"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.LightGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(12, 369)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(26, 16)
        Me.Panel2.TabIndex = 14
        '
        'frmCipInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 411)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.radCipParcial)
        Me.Controls.Add(Me.radCipCompleto)
        Me.Controls.Add(Me.butIniciar)
        Me.Controls.Add(Me.gvCadRotas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Location = New System.Drawing.Point(0, 102)
        Me.Name = "frmCipInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Iniciar CIP"
        CType(Me.gvCadRotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsCipValid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dsCipValid As Geral.dsxCipValid
    Friend WithEvents taCadRotas As Geral.dsxCipValidTableAdapters.taxCadRotasVl
    Friend WithEvents gvCadRotas As System.Windows.Forms.DataGridView
    Friend WithEvents butIniciar As System.Windows.Forms.Button
    Friend WithEvents radCipCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents radCipParcial As System.Windows.Forms.RadioButton
    Friend WithEvents Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subgrupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LimRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTempos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butFecha As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
