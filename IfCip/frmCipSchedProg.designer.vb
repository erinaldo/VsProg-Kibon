<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCipSchedProg
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.ProgId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RotaId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Circ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butAdd = New System.Windows.Forms.ToolStripButton()
        Me.butEdita = New System.Windows.Forms.ToolStripButton()
        Me.butRemove = New System.Windows.Forms.ToolStripButton()
        Me.butEditaData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.butProgHab = New System.Windows.Forms.ToolStripButton()
        Me.butDesab = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbCirc = New System.Windows.Forms.ToolStripComboBox()
        Me.butRefresh = New System.Windows.Forms.ToolStripButton()
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
        Me.gvItens.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProgId, Me.Data, Me.RotaId, Me.Descr, Me.Circ, Me.RecNum, Me.RecNome, Me.RecDescr, Me.RecCodigo, Me.Sts})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvItens.DefaultCellStyle = DataGridViewCellStyle8
        Me.gvItens.Location = New System.Drawing.Point(0, 56)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(1196, 328)
        Me.gvItens.TabIndex = 0
        '
        'ProgId
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProgId.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProgId.HeaderText = "ProgId"
        Me.ProgId.Name = "ProgId"
        Me.ProgId.ReadOnly = True
        Me.ProgId.Width = 50
        '
        'Data
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Data.DefaultCellStyle = DataGridViewCellStyle2
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 150
        '
        'RotaId
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RotaId.DefaultCellStyle = DataGridViewCellStyle3
        Me.RotaId.HeaderText = "RotaId"
        Me.RotaId.Name = "RotaId"
        Me.RotaId.ReadOnly = True
        Me.RotaId.Width = 50
        '
        'Descr
        '
        Me.Descr.HeaderText = "Descr"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        Me.Descr.Width = 200
        '
        'Circ
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Circ.DefaultCellStyle = DataGridViewCellStyle4
        Me.Circ.HeaderText = "Circ"
        Me.Circ.Name = "Circ"
        Me.Circ.ReadOnly = True
        Me.Circ.Width = 50
        '
        'RecNum
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RecNum.DefaultCellStyle = DataGridViewCellStyle5
        Me.RecNum.HeaderText = "RecNum"
        Me.RecNum.Name = "RecNum"
        Me.RecNum.ReadOnly = True
        Me.RecNum.Width = 50
        '
        'RecNome
        '
        Me.RecNome.HeaderText = "Receita"
        Me.RecNome.Name = "RecNome"
        Me.RecNome.ReadOnly = True
        Me.RecNome.Width = 200
        '
        'RecDescr
        '
        Me.RecDescr.HeaderText = "Descrição"
        Me.RecDescr.Name = "RecDescr"
        Me.RecDescr.ReadOnly = True
        Me.RecDescr.Width = 200
        '
        'RecCodigo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RecCodigo.DefaultCellStyle = DataGridViewCellStyle6
        Me.RecCodigo.HeaderText = "Código"
        Me.RecCodigo.Name = "RecCodigo"
        Me.RecCodigo.ReadOnly = True
        '
        'Sts
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Sts.DefaultCellStyle = DataGridViewCellStyle7
        Me.Sts.HeaderText = "Status"
        Me.Sts.Name = "Sts"
        Me.Sts.ReadOnly = True
        Me.Sts.Width = 70
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butAdd, Me.butEdita, Me.butRemove, Me.butEditaData, Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.butProgHab, Me.butDesab, Me.ToolStripSeparator2, Me.cmbCirc, Me.butRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1196, 53)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butAdd
        '
        Me.butAdd.AutoSize = False
        Me.butAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butAdd.Image = Global.IfCip.My.Resources.Resources.document_new
        Me.butAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(60, 50)
        Me.butAdd.Text = "ToolStripButton3"
        Me.butAdd.ToolTipText = "Criar nova programação de CIP"
        '
        'butEdita
        '
        Me.butEdita.AutoSize = False
        Me.butEdita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEdita.Image = Global.IfCip.My.Resources.Resources.document_edit
        Me.butEdita.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butEdita.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEdita.Name = "butEdita"
        Me.butEdita.Size = New System.Drawing.Size(60, 50)
        Me.butEdita.Text = "ToolStripButton5"
        Me.butEdita.ToolTipText = "Alterar a rota do CIP selecionado"
        '
        'butRemove
        '
        Me.butRemove.AutoSize = False
        Me.butRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butRemove.Image = Global.IfCip.My.Resources.Resources.document_delete
        Me.butRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butRemove.Name = "butRemove"
        Me.butRemove.Size = New System.Drawing.Size(60, 50)
        Me.butRemove.Text = "ToolStripButton4"
        Me.butRemove.ToolTipText = "Apagr o CIP selecionado"
        '
        'butEditaData
        '
        Me.butEditaData.AutoSize = False
        Me.butEditaData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEditaData.Image = Global.IfCip.My.Resources.Resources.calendar
        Me.butEditaData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butEditaData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEditaData.Name = "butEditaData"
        Me.butEditaData.Size = New System.Drawing.Size(60, 50)
        Me.butEditaData.Text = "ToolStripButton6"
        Me.butEditaData.ToolTipText = "Data programada"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(105, 50)
        Me.ToolStripLabel1.Text = "Programação de CIP"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 53)
        '
        'butProgHab
        '
        Me.butProgHab.AutoSize = False
        Me.butProgHab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butProgHab.Image = Global.IfCip.My.Resources.Resources.gears_run
        Me.butProgHab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butProgHab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butProgHab.Name = "butProgHab"
        Me.butProgHab.Size = New System.Drawing.Size(60, 50)
        Me.butProgHab.Text = "Hbilita"
        '
        'butDesab
        '
        Me.butDesab.AutoSize = False
        Me.butDesab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butDesab.Image = Global.IfCip.My.Resources.Resources.gears_stop
        Me.butDesab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butDesab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butDesab.Name = "butDesab"
        Me.butDesab.Size = New System.Drawing.Size(60, 50)
        Me.butDesab.Text = "Desabilita"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 53)
        '
        'cmbCirc
        '
        Me.cmbCirc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCirc.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.cmbCirc.Items.AddRange(New Object() {"*", "A", "B", "C", "D", "E", "CA", "CB", "CC", "CD", "CE"})
        Me.cmbCirc.Name = "cmbCirc"
        Me.cmbCirc.Size = New System.Drawing.Size(75, 53)
        '
        'butRefresh
        '
        Me.butRefresh.AutoSize = False
        Me.butRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butRefresh.Image = Global.IfCip.My.Resources.Resources.refresh
        Me.butRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butRefresh.Name = "butRefresh"
        Me.butRefresh.Size = New System.Drawing.Size(60, 50)
        Me.butRefresh.Text = "Refresh"
        '
        'frmCipSchedProg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 385)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gvItens)
        Me.Location = New System.Drawing.Point(0, 102)
        Me.Name = "frmCipSchedProg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Programação"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents PerIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents butRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEdita As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditaData As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butProgHab As System.Windows.Forms.ToolStripButton
    Friend WithEvents butDesab As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbCirc As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ProgId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Circ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
End Class
