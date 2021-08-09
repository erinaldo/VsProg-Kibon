<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgenda
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgenda))
        Me.butIniciar = New System.Windows.Forms.Button
        Me.gvAgenda = New System.Windows.Forms.DataGridView
        Me.Modo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RotaId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Subgrupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LimRev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndTempos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.butFecha = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        CType(Me.gvAgenda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'butIniciar
        '
        Me.butIniciar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butIniciar.Location = New System.Drawing.Point(282, 369)
        Me.butIniciar.Name = "butIniciar"
        Me.butIniciar.Size = New System.Drawing.Size(270, 30)
        Me.butIniciar.TabIndex = 6
        Me.butIniciar.Text = "Iniciar"
        Me.butIniciar.UseVisualStyleBackColor = True
        '
        'gvAgenda
        '
        Me.gvAgenda.AllowUserToAddRows = False
        Me.gvAgenda.AllowUserToDeleteRows = False
        Me.gvAgenda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvAgenda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Modo, Me.Id, Me.RotaId, Me.Grupo, Me.Subgrupo, Me.Data, Me.Tipo, Me.Descr, Me.LimRev, Me.EndTempos})
        Me.gvAgenda.Location = New System.Drawing.Point(12, 39)
        Me.gvAgenda.Name = "gvAgenda"
        Me.gvAgenda.ReadOnly = True
        Me.gvAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvAgenda.Size = New System.Drawing.Size(814, 315)
        Me.gvAgenda.TabIndex = 5
        '
        'Modo
        '
        Me.Modo.DataPropertyName = "Modo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Modo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Modo.HeaderText = "Modo"
        Me.Modo.Name = "Modo"
        Me.Modo.ReadOnly = True
        Me.Modo.Width = 50
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Id.DefaultCellStyle = DataGridViewCellStyle2
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 50
        '
        'RotaId
        '
        Me.RotaId.DataPropertyName = "RotaId"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RotaId.DefaultCellStyle = DataGridViewCellStyle3
        Me.RotaId.HeaderText = "RotaId"
        Me.RotaId.Name = "RotaId"
        Me.RotaId.ReadOnly = True
        Me.RotaId.Visible = False
        Me.RotaId.Width = 50
        '
        'Grupo
        '
        Me.Grupo.DataPropertyName = "Grupo"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Grupo.DefaultCellStyle = DataGridViewCellStyle4
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 50
        '
        'Subgrupo
        '
        Me.Subgrupo.DataPropertyName = "Subgrupo"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Subgrupo.DefaultCellStyle = DataGridViewCellStyle5
        Me.Subgrupo.HeaderText = "Subgrupo"
        Me.Subgrupo.Name = "Subgrupo"
        Me.Subgrupo.ReadOnly = True
        Me.Subgrupo.Width = 50
        '
        'Data
        '
        Me.Data.DataPropertyName = "DataHora"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Data.DefaultCellStyle = DataGridViewCellStyle6
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 150
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle7
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'Descr
        '
        Me.Descr.DataPropertyName = "Descr"
        Me.Descr.HeaderText = "Descr"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        Me.Descr.Width = 300
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
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butFecha, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(838, 25)
        Me.ToolStrip1.TabIndex = 8
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(12, 369)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(26, 16)
        Me.Panel1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 372)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "CIP atrasado"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 389)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "CIP em execução"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.LightGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(12, 386)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(26, 16)
        Me.Panel2.TabIndex = 12
        '
        'frmAgenda
        '
        Me.AcceptButton = Me.butIniciar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 411)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.butIniciar)
        Me.Controls.Add(Me.gvAgenda)
        Me.Name = "frmAgenda"
        Me.Text = "Agenda"
        CType(Me.gvAgenda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butIniciar As System.Windows.Forms.Button
    Friend WithEvents gvAgenda As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butFecha As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Modo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subgrupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LimRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTempos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
