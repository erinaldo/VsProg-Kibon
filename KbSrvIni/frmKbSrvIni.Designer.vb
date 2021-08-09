<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbSrvIni
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKbSrvIni))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.niIcone = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.butFechar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.ServNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObjContaErro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'niIcone
        '
        Me.niIcone.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.niIcone.Icon = CType(resources.GetObject("niIcone.Icon"), System.Drawing.Icon)
        Me.niIcone.Text = "TSE - Verificação de  Serviços"
        Me.niIcone.Visible = True
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 1000
        '
        'butFechar
        '
        Me.butFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butFechar.Image = Global.KbSrvIni.My.Resources.Resources.Bot16x16Sair1
        Me.butFechar.Location = New System.Drawing.Point(466, 24)
        Me.butFechar.Name = "butFechar"
        Me.butFechar.Size = New System.Drawing.Size(98, 37)
        Me.butFechar.TabIndex = 34
        Me.butFechar.Text = "Fechar"
        Me.butFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butFechar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(126, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(241, 26)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "TSE - Reinicia Serviços"
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServNome, Me.ObjContaErro, Me.Status})
        Me.gvItens.Location = New System.Drawing.Point(12, 81)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(552, 256)
        Me.gvItens.TabIndex = 35
        '
        'ServNome
        '
        Me.ServNome.HeaderText = "ServNome"
        Me.ServNome.Name = "ServNome"
        Me.ServNome.Width = 200
        '
        'ObjContaErro
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ObjContaErro.DefaultCellStyle = DataGridViewCellStyle2
        Me.ObjContaErro.HeaderText = "ContaErro"
        Me.ObjContaErro.Name = "ObjContaErro"
        Me.ObjContaErro.Width = 70
        '
        'Status
        '
        Me.Status.HeaderText = "StatusTxt"
        Me.Status.Name = "Status"
        Me.Status.Width = 120
        '
        'frmKbSrvIni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 349)
        Me.Controls.Add(Me.gvItens)
        Me.Controls.Add(Me.butFechar)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKbSrvIni"
        Me.Text = "TSE - Reinicia Serviços"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents niIcone As System.Windows.Forms.NotifyIcon
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents butFechar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents ServNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObjContaErro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
