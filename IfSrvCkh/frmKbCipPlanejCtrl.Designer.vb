<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbCipPlanejCtrl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKbCipPlanejCtrl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.butSair = New System.Windows.Forms.ToolStripButton()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.colCirc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRotaId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vazao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Temp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cond = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlkNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlkPasso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pausa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.stsStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butSair})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(871, 33)
        Me.ToolStrip.TabIndex = 3
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'butSair
        '
        Me.butSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.butSair.AutoSize = False
        Me.butSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butSair.Image = CType(resources.GetObject("butSair.Image"), System.Drawing.Image)
        Me.butSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSair.Name = "butSair"
        Me.butSair.Size = New System.Drawing.Size(30, 30)
        Me.butSair.Text = "Sair"
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCirc, Me.ColStatus, Me.colRotaId, Me.colRecNum, Me.colExec, Me.Vazao, Me.Temp, Me.Cond, Me.BlkNum, Me.BlkPasso, Me.Pausa})
        Me.gvItens.Location = New System.Drawing.Point(0, 36)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.RowHeadersWidth = 15
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(871, 230)
        Me.gvItens.TabIndex = 4
        '
        'colCirc
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCirc.DefaultCellStyle = DataGridViewCellStyle1
        Me.colCirc.HeaderText = "Circ"
        Me.colCirc.Name = "colCirc"
        Me.colCirc.ReadOnly = True
        Me.colCirc.Width = 50
        '
        'ColStatus
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColStatus.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColStatus.HeaderText = "Status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.ReadOnly = True
        Me.ColStatus.Width = 90
        '
        'colRotaId
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRotaId.DefaultCellStyle = DataGridViewCellStyle3
        Me.colRotaId.HeaderText = "RotaId"
        Me.colRotaId.Name = "colRotaId"
        Me.colRotaId.ReadOnly = True
        Me.colRotaId.Width = 80
        '
        'colRecNum
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRecNum.DefaultCellStyle = DataGridViewCellStyle4
        Me.colRecNum.HeaderText = "RecNum"
        Me.colRecNum.Name = "colRecNum"
        Me.colRecNum.ReadOnly = True
        Me.colRecNum.Width = 80
        '
        'colExec
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colExec.DefaultCellStyle = DataGridViewCellStyle5
        Me.colExec.HeaderText = "Exec"
        Me.colExec.Name = "colExec"
        Me.colExec.ReadOnly = True
        Me.colExec.Width = 70
        '
        'Vazao
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Vazao.DefaultCellStyle = DataGridViewCellStyle6
        Me.Vazao.HeaderText = "Vazão"
        Me.Vazao.Name = "Vazao"
        Me.Vazao.ReadOnly = True
        Me.Vazao.Width = 70
        '
        'Temp
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Temp.DefaultCellStyle = DataGridViewCellStyle7
        Me.Temp.HeaderText = "Temp"
        Me.Temp.Name = "Temp"
        Me.Temp.ReadOnly = True
        Me.Temp.Width = 70
        '
        'Cond
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cond.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cond.HeaderText = "Cond"
        Me.Cond.Name = "Cond"
        Me.Cond.ReadOnly = True
        Me.Cond.Width = 70
        '
        'BlkNum
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BlkNum.DefaultCellStyle = DataGridViewCellStyle9
        Me.BlkNum.HeaderText = "BlkNum"
        Me.BlkNum.Name = "BlkNum"
        Me.BlkNum.ReadOnly = True
        Me.BlkNum.Width = 70
        '
        'BlkPasso
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.BlkPasso.DefaultCellStyle = DataGridViewCellStyle10
        Me.BlkPasso.HeaderText = "BlkPasso"
        Me.BlkPasso.Name = "BlkPasso"
        Me.BlkPasso.ReadOnly = True
        Me.BlkPasso.Width = 70
        '
        'Pausa
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Pausa.DefaultCellStyle = DataGridViewCellStyle11
        Me.Pausa.HeaderText = "Pausa"
        Me.Pausa.Name = "Pausa"
        Me.Pausa.ReadOnly = True
        Me.Pausa.Width = 70
        '
        'tmrPoll
        '
        Me.tmrPoll.Interval = 2000
        '
        'stsStrip
        '
        Me.stsStrip.Location = New System.Drawing.Point(0, 269)
        Me.stsStrip.Name = "stsStrip"
        Me.stsStrip.Size = New System.Drawing.Size(871, 22)
        Me.stsStrip.TabIndex = 5
        Me.stsStrip.Text = "StatusStrip1"
        '
        'frmKbCipPlanejCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 291)
        Me.Controls.Add(Me.stsStrip)
        Me.Controls.Add(Me.gvItens)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmKbCipPlanejCtrl"
        Me.Text = "Controle de Planejamento de CIP"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents butSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer
    Friend WithEvents stsStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents colCirc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRotaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vazao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cond As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlkNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlkPasso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pausa As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
