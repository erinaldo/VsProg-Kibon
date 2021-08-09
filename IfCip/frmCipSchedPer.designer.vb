<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCipSchedPer
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butAdd = New System.Windows.Forms.ToolStripButton()
        Me.butEditaRota = New System.Windows.Forms.ToolStripButton()
        Me.butRemove = New System.Windows.Forms.ToolStripButton()
        Me.butEditaData = New System.Windows.Forms.ToolStripButton()
        Me.butPerNDias = New System.Windows.Forms.ToolStripButton()
        Me.butEditaDias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.PerId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RotaId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RotaDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Circ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PerNDias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butAdd, Me.butEditaRota, Me.butRemove, Me.butEditaData, Me.butPerNDias, Me.butEditaDias, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1144, 53)
        Me.ToolStrip1.TabIndex = 4
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
        'butEditaRota
        '
        Me.butEditaRota.AutoSize = False
        Me.butEditaRota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEditaRota.Image = Global.IfCip.My.Resources.Resources.document_edit
        Me.butEditaRota.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butEditaRota.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEditaRota.Name = "butEditaRota"
        Me.butEditaRota.Size = New System.Drawing.Size(60, 50)
        Me.butEditaRota.Text = "ToolStripButton5"
        Me.butEditaRota.ToolTipText = "Alterar a rota do CIP selecionado"
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
        Me.butEditaData.ToolTipText = "Alterar a data do CIP seleciondo"
        '
        'butPerNDias
        '
        Me.butPerNDias.AutoSize = False
        Me.butPerNDias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butPerNDias.Image = Global.IfCip.My.Resources.Resources.calendar_up
        Me.butPerNDias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butPerNDias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butPerNDias.Name = "butPerNDias"
        Me.butPerNDias.Size = New System.Drawing.Size(60, 50)
        Me.butPerNDias.Text = "ToolStripButton1"
        Me.butPerNDias.ToolTipText = "Numero de dias entre os CIPs"
        '
        'butEditaDias
        '
        Me.butEditaDias.AutoSize = False
        Me.butEditaDias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEditaDias.Image = Global.IfCip.My.Resources.Resources.document_time
        Me.butEditaDias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butEditaDias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEditaDias.Name = "butEditaDias"
        Me.butEditaDias.Size = New System.Drawing.Size(60, 50)
        Me.butEditaDias.Text = "ToolStripButton1"
        Me.butEditaDias.ToolTipText = "Editar dias selecionados"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(80, 50)
        Me.ToolStripLabel1.Text = "CIPs Periódicos"
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PerId, Me.RotaId, Me.RotaDescr, Me.Circ, Me.Data, Me.PerNDias, Me.RecNum, Me.RecNome, Me.Descr, Me.RecCodigo})
        Me.gvItens.Location = New System.Drawing.Point(0, 56)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(1144, 492)
        Me.gvItens.TabIndex = 3
        '
        'PerId
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PerId.DefaultCellStyle = DataGridViewCellStyle1
        Me.PerId.HeaderText = "PerId"
        Me.PerId.Name = "PerId"
        Me.PerId.ReadOnly = True
        Me.PerId.Width = 50
        '
        'RotaId
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RotaId.DefaultCellStyle = DataGridViewCellStyle2
        Me.RotaId.HeaderText = "RotaId"
        Me.RotaId.Name = "RotaId"
        Me.RotaId.ReadOnly = True
        Me.RotaId.Width = 50
        '
        'RotaDescr
        '
        Me.RotaDescr.HeaderText = "Rota"
        Me.RotaDescr.Name = "RotaDescr"
        Me.RotaDescr.ReadOnly = True
        Me.RotaDescr.Width = 200
        '
        'Circ
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Circ.DefaultCellStyle = DataGridViewCellStyle3
        Me.Circ.HeaderText = "Circ"
        Me.Circ.Name = "Circ"
        Me.Circ.ReadOnly = True
        Me.Circ.Width = 50
        '
        'Data
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Data.DefaultCellStyle = DataGridViewCellStyle4
        Me.Data.HeaderText = "Início"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 150
        '
        'PerNDias
        '
        Me.PerNDias.DataPropertyName = "PerNHoras"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PerNDias.DefaultCellStyle = DataGridViewCellStyle5
        Me.PerNDias.HeaderText = "Horas"
        Me.PerNDias.Name = "PerNDias"
        Me.PerNDias.ReadOnly = True
        Me.PerNDias.Width = 50
        '
        'RecNum
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RecNum.DefaultCellStyle = DataGridViewCellStyle6
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
        '
        'Descr
        '
        Me.Descr.HeaderText = "Descrição"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        Me.Descr.Width = 200
        '
        'RecCodigo
        '
        Me.RecCodigo.HeaderText = "Código"
        Me.RecCodigo.Name = "RecCodigo"
        Me.RecCodigo.ReadOnly = True
        '
        'frmCipSchedPer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 549)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gvItens)
        Me.Name = "frmCipSchedPer"
        Me.Text = "Cip Periódico"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents butRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditaRota As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditaData As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents butEditaDias As System.Windows.Forms.ToolStripButton
    Friend WithEvents butPerNDias As System.Windows.Forms.ToolStripButton
    Friend WithEvents PerId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Circ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PerNDias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
