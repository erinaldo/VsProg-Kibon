<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCipFim
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butCipHistAnorm = New System.Windows.Forms.ToolStripButton()
        Me.butCipHistPtoCt = New System.Windows.Forms.ToolStripButton()
        Me.butCipGrava = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.butRefresh = New System.Windows.Forms.ToolStripButton()
        Me.colCipId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRotaId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCirc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Receita = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataHoraIni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataHoraFim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAnorm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPtoCr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCipId, Me.colRotaId, Me.colDescr, Me.colCirc, Me.RecNum, Me.Receita, Me.RecDescr, Me.RecCodigo, Me.colDataHoraIni, Me.colDataHoraFim, Me.colUserNome, Me.colAnorm, Me.colPtoCr})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvItens.DefaultCellStyle = DataGridViewCellStyle9
        Me.gvItens.Location = New System.Drawing.Point(0, 56)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(1340, 273)
        Me.gvItens.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butCipHistAnorm, Me.butCipHistPtoCt, Me.butCipGrava, Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.butRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1340, 53)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butCipHistAnorm
        '
        Me.butCipHistAnorm.AutoSize = False
        Me.butCipHistAnorm.Image = Global.IfCip.My.Resources.Resources.message
        Me.butCipHistAnorm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butCipHistAnorm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCipHistAnorm.Name = "butCipHistAnorm"
        Me.butCipHistAnorm.Size = New System.Drawing.Size(60, 50)
        Me.butCipHistAnorm.Text = "Anorm"
        Me.butCipHistAnorm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCipHistAnorm.ToolTipText = "Anormalidades do CIP selecionado"
        '
        'butCipHistPtoCt
        '
        Me.butCipHistPtoCt.AutoSize = False
        Me.butCipHistPtoCt.Image = Global.IfCip.My.Resources.Resources.question_and_answer
        Me.butCipHistPtoCt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butCipHistPtoCt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCipHistPtoCt.Name = "butCipHistPtoCt"
        Me.butCipHistPtoCt.Size = New System.Drawing.Size(60, 50)
        Me.butCipHistPtoCt.Text = "PtoCr"
        Me.butCipHistPtoCt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCipHistPtoCt.ToolTipText = "Pontos Críticos do CIP selecionado"
        '
        'butCipGrava
        '
        Me.butCipGrava.AutoSize = False
        Me.butCipGrava.Image = Global.IfCip.My.Resources.Resources.check
        Me.butCipGrava.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butCipGrava.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCipGrava.Name = "butCipGrava"
        Me.butCipGrava.Size = New System.Drawing.Size(60, 50)
        Me.butCipGrava.Text = "Grava"
        Me.butCipGrava.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCipGrava.ToolTipText = "Gravar CIP"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(59, 50)
        Me.ToolStripLabel1.Text = "Validar CIP"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 53)
        '
        'butRefresh
        '
        Me.butRefresh.AutoSize = False
        Me.butRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butRefresh.Image = Global.IfCip.My.Resources.Resources.refresh1
        Me.butRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butRefresh.Name = "butRefresh"
        Me.butRefresh.Size = New System.Drawing.Size(60, 50)
        Me.butRefresh.Text = "Refresh"
        '
        'colCipId
        '
        Me.colCipId.DataPropertyName = "CipId"
        Me.colCipId.HeaderText = "CipId"
        Me.colCipId.Name = "colCipId"
        Me.colCipId.ReadOnly = True
        Me.colCipId.Width = 50
        '
        'colRotaId
        '
        Me.colRotaId.DataPropertyName = "RotaId"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRotaId.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRotaId.HeaderText = "RotaId"
        Me.colRotaId.Name = "colRotaId"
        Me.colRotaId.ReadOnly = True
        Me.colRotaId.Width = 50
        '
        'colDescr
        '
        Me.colDescr.DataPropertyName = "Descr"
        Me.colDescr.HeaderText = "Descrição"
        Me.colDescr.Name = "colDescr"
        Me.colDescr.ReadOnly = True
        Me.colDescr.Width = 150
        '
        'colCirc
        '
        Me.colCirc.DataPropertyName = "Circ"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCirc.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCirc.HeaderText = "Circ"
        Me.colCirc.Name = "colCirc"
        Me.colCirc.ReadOnly = True
        Me.colCirc.Width = 50
        '
        'RecNum
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RecNum.DefaultCellStyle = DataGridViewCellStyle3
        Me.RecNum.HeaderText = "RecNum"
        Me.RecNum.Name = "RecNum"
        Me.RecNum.ReadOnly = True
        Me.RecNum.Width = 50
        '
        'Receita
        '
        Me.Receita.HeaderText = "Receita"
        Me.Receita.Name = "Receita"
        Me.Receita.ReadOnly = True
        '
        'RecDescr
        '
        Me.RecDescr.HeaderText = "Descrição"
        Me.RecDescr.Name = "RecDescr"
        Me.RecDescr.ReadOnly = True
        Me.RecDescr.Width = 150
        '
        'RecCodigo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RecCodigo.DefaultCellStyle = DataGridViewCellStyle4
        Me.RecCodigo.HeaderText = "Código"
        Me.RecCodigo.Name = "RecCodigo"
        Me.RecCodigo.ReadOnly = True
        Me.RecCodigo.Width = 70
        '
        'colDataHoraIni
        '
        Me.colDataHoraIni.DataPropertyName = "DataHoraIni"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDataHoraIni.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDataHoraIni.HeaderText = "Inicio"
        Me.colDataHoraIni.Name = "colDataHoraIni"
        Me.colDataHoraIni.ReadOnly = True
        Me.colDataHoraIni.Width = 170
        '
        'colDataHoraFim
        '
        Me.colDataHoraFim.DataPropertyName = "DataHoraFim"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDataHoraFim.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDataHoraFim.HeaderText = "Fim"
        Me.colDataHoraFim.Name = "colDataHoraFim"
        Me.colDataHoraFim.ReadOnly = True
        Me.colDataHoraFim.Width = 170
        '
        'colUserNome
        '
        Me.colUserNome.DataPropertyName = "UserNome"
        Me.colUserNome.HeaderText = "Usuario"
        Me.colUserNome.Name = "colUserNome"
        Me.colUserNome.ReadOnly = True
        Me.colUserNome.Width = 150
        '
        'colAnorm
        '
        Me.colAnorm.DataPropertyName = "Anorm"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colAnorm.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAnorm.HeaderText = "Anorm"
        Me.colAnorm.Name = "colAnorm"
        Me.colAnorm.ReadOnly = True
        Me.colAnorm.Width = 50
        '
        'colPtoCr
        '
        Me.colPtoCr.DataPropertyName = "PtoCr"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colPtoCr.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPtoCr.HeaderText = "PtoCr"
        Me.colPtoCr.Name = "colPtoCr"
        Me.colPtoCr.ReadOnly = True
        Me.colPtoCr.Width = 50
        '
        'frmCipFim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1340, 326)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gvItens)
        Me.Location = New System.Drawing.Point(0, 102)
        Me.Name = "frmCipFim"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Validar CIP"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butCipHistAnorm As System.Windows.Forms.ToolStripButton
    Friend WithEvents butCipHistPtoCt As System.Windows.Forms.ToolStripButton
    Friend WithEvents butCipGrava As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents colCipId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRotaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCirc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Receita As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataHoraIni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataHoraFim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAnorm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPtoCr As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
