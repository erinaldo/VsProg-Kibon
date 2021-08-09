<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLog))
        Me.gvLog = New System.Windows.Forms.DataGridView()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEvento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.butRefresh = New System.Windows.Forms.Button()
        Me.butSair = New System.Windows.Forms.Button()
        Me.butLimpar = New System.Windows.Forms.Button()
        CType(Me.gvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvLog
        '
        Me.gvLog.AllowUserToAddRows = False
        Me.gvLog.AllowUserToDeleteRows = False
        Me.gvLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colEvento})
        Me.gvLog.Location = New System.Drawing.Point(12, 12)
        Me.gvLog.Name = "gvLog"
        Me.gvLog.ReadOnly = True
        Me.gvLog.RowHeadersWidth = 5
        Me.gvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvLog.Size = New System.Drawing.Size(659, 459)
        Me.gvLog.TabIndex = 0
        '
        'colItem
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colItem.DefaultCellStyle = DataGridViewCellStyle1
        Me.colItem.HeaderText = "Item"
        Me.colItem.Name = "colItem"
        Me.colItem.ReadOnly = True
        Me.colItem.Width = 50
        '
        'colEvento
        '
        Me.colEvento.HeaderText = "Evento"
        Me.colEvento.Name = "colEvento"
        Me.colEvento.ReadOnly = True
        Me.colEvento.Width = 570
        '
        'butRefresh
        '
        Me.butRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRefresh.Image = CType(resources.GetObject("butRefresh.Image"), System.Drawing.Image)
        Me.butRefresh.Location = New System.Drawing.Point(525, 480)
        Me.butRefresh.Name = "butRefresh"
        Me.butRefresh.Size = New System.Drawing.Size(70, 39)
        Me.butRefresh.TabIndex = 9
        Me.butRefresh.UseVisualStyleBackColor = True
        '
        'butSair
        '
        Me.butSair.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSair.Image = CType(resources.GetObject("butSair.Image"), System.Drawing.Image)
        Me.butSair.Location = New System.Drawing.Point(601, 480)
        Me.butSair.Name = "butSair"
        Me.butSair.Size = New System.Drawing.Size(70, 39)
        Me.butSair.TabIndex = 8
        Me.butSair.UseVisualStyleBackColor = True
        '
        'butLimpar
        '
        Me.butLimpar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butLimpar.Image = CType(resources.GetObject("butLimpar.Image"), System.Drawing.Image)
        Me.butLimpar.Location = New System.Drawing.Point(449, 480)
        Me.butLimpar.Name = "butLimpar"
        Me.butLimpar.Size = New System.Drawing.Size(70, 39)
        Me.butLimpar.TabIndex = 10
        Me.butLimpar.UseVisualStyleBackColor = True
        '
        'frmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 531)
        Me.ControlBox = False
        Me.Controls.Add(Me.butLimpar)
        Me.Controls.Add(Me.butRefresh)
        Me.Controls.Add(Me.butSair)
        Me.Controls.Add(Me.gvLog)
        Me.Name = "frmLog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log de Eventos"
        CType(Me.gvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvLog As System.Windows.Forms.DataGridView
    Friend WithEvents colItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEvento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents butRefresh As System.Windows.Forms.Button
    Friend WithEvents butSair As System.Windows.Forms.Button
    Friend WithEvents butLimpar As System.Windows.Forms.Button
End Class
