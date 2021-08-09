<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbMatGrava
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKbMatGrava))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtDataHora = New System.Windows.Forms.TextBox()
        Me.botSair = New System.Windows.Forms.Button()
        Me.grdItens = New System.Windows.Forms.DataGridView()
        Me.Tanque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Te = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeqTq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grdItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDataHora
        '
        Me.txtDataHora.AcceptsReturn = True
        Me.txtDataHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDataHora.BackColor = System.Drawing.SystemColors.Window
        Me.txtDataHora.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDataHora.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataHora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDataHora.Location = New System.Drawing.Point(12, 428)
        Me.txtDataHora.MaxLength = 0
        Me.txtDataHora.Name = "txtDataHora"
        Me.txtDataHora.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataHora.Size = New System.Drawing.Size(201, 20)
        Me.txtDataHora.TabIndex = 6
        Me.txtDataHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'botSair
        '
        Me.botSair.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.botSair.BackColor = System.Drawing.SystemColors.Control
        Me.botSair.Cursor = System.Windows.Forms.Cursors.Default
        Me.botSair.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botSair.ForeColor = System.Drawing.SystemColors.ControlText
        Me.botSair.Image = CType(resources.GetObject("botSair.Image"), System.Drawing.Image)
        Me.botSair.Location = New System.Drawing.Point(396, 420)
        Me.botSair.Name = "botSair"
        Me.botSair.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.botSair.Size = New System.Drawing.Size(65, 41)
        Me.botSair.TabIndex = 4
        Me.botSair.Text = "Fechar"
        Me.botSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.botSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.botSair.UseVisualStyleBackColor = False
        '
        'grdItens
        '
        Me.grdItens.AllowDrop = True
        Me.grdItens.AllowUserToAddRows = False
        Me.grdItens.AllowUserToDeleteRows = False
        Me.grdItens.AllowUserToResizeRows = False
        Me.grdItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tanque, Me.Te, Me.CodProd, Me.Hr, Me.Cn, Me.SeqTq})
        Me.grdItens.Location = New System.Drawing.Point(12, 12)
        Me.grdItens.MultiSelect = False
        Me.grdItens.Name = "grdItens"
        Me.grdItens.ReadOnly = True
        Me.grdItens.RowHeadersVisible = False
        Me.grdItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdItens.Size = New System.Drawing.Size(449, 399)
        Me.grdItens.TabIndex = 24
        '
        'Tanque
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Tanque.DefaultCellStyle = DataGridViewCellStyle1
        Me.Tanque.HeaderText = "Tanque"
        Me.Tanque.Name = "Tanque"
        Me.Tanque.ReadOnly = True
        Me.Tanque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Tanque.Width = 70
        '
        'Te
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Te.DefaultCellStyle = DataGridViewCellStyle2
        Me.Te.HeaderText = "Te"
        Me.Te.Name = "Te"
        Me.Te.ReadOnly = True
        Me.Te.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Te.Width = 70
        '
        'CodProd
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CodProd.DefaultCellStyle = DataGridViewCellStyle3
        Me.CodProd.HeaderText = "CodProd"
        Me.CodProd.Name = "CodProd"
        Me.CodProd.ReadOnly = True
        Me.CodProd.Width = 70
        '
        'Hr
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Hr.DefaultCellStyle = DataGridViewCellStyle4
        Me.Hr.HeaderText = "Hr"
        Me.Hr.Name = "Hr"
        Me.Hr.ReadOnly = True
        Me.Hr.Width = 70
        '
        'Cn
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cn.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cn.HeaderText = "Cn"
        Me.Cn.Name = "Cn"
        Me.Cn.ReadOnly = True
        Me.Cn.Width = 70
        '
        'SeqTq
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SeqTq.DefaultCellStyle = DataGridViewCellStyle6
        Me.SeqTq.HeaderText = "SeqTq"
        Me.SeqTq.Name = "SeqTq"
        Me.SeqTq.ReadOnly = True
        Me.SeqTq.Width = 70
        '
        'tmrPoll
        '
        Me.tmrPoll.Interval = 1000
        '
        'frmKbMatGrava
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 473)
        Me.Controls.Add(Me.grdItens)
        Me.Controls.Add(Me.txtDataHora)
        Me.Controls.Add(Me.botSair)
        Me.Name = "frmKbMatGrava"
        Me.Text = "MatGrava"
        CType(Me.grdItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtDataHora As System.Windows.Forms.TextBox
    Public WithEvents botSair As System.Windows.Forms.Button
    Friend WithEvents grdItens As System.Windows.Forms.DataGridView
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer
    Friend WithEvents Tanque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Te As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeqTq As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
