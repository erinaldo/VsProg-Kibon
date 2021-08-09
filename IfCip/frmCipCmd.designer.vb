<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCipCmd
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCipCmd))
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.butStart = New System.Windows.Forms.ToolStripButton()
        Me.butStop = New System.Windows.Forms.ToolStripButton()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.CircNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RotaId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Circ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Exec = New System.Windows.Forms.DataGridViewImageColumn()
        Me.imExec = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrPoll
        '
        Me.tmrPoll.Interval = 1000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.butStart, Me.butStop})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1216, 53)
        Me.ToolStrip1.TabIndex = 69
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(92, 50)
        Me.ToolStripLabel1.Text = "Comandos de CIP"
        '
        'butStart
        '
        Me.butStart.AutoSize = False
        Me.butStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butStart.Image = Global.IfCip.My.Resources.Resources.media_play_green
        Me.butStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butStart.Name = "butStart"
        Me.butStart.Size = New System.Drawing.Size(60, 50)
        Me.butStart.Text = "Iniciar"
        '
        'butStop
        '
        Me.butStop.AutoSize = False
        Me.butStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butStop.Image = Global.IfCip.My.Resources.Resources.media_stop_red
        Me.butStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butStop.Name = "butStop"
        Me.butStop.Size = New System.Drawing.Size(60, 50)
        Me.butStop.Text = "Prar"
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
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CircNum, Me.RotaId, Me.Descr, Me.Circ, Me.RecNum, Me.RecNome, Me.RecDescr, Me.RecCodigo, Me.Exec})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvItens.DefaultCellStyle = DataGridViewCellStyle5
        Me.gvItens.Location = New System.Drawing.Point(0, 56)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(1216, 360)
        Me.gvItens.TabIndex = 70
        '
        'CircNum
        '
        Me.CircNum.HeaderText = "CircNum"
        Me.CircNum.Name = "CircNum"
        Me.CircNum.ReadOnly = True
        Me.CircNum.Visible = False
        '
        'RotaId
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RotaId.DefaultCellStyle = DataGridViewCellStyle1
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Circ.DefaultCellStyle = DataGridViewCellStyle2
        Me.Circ.HeaderText = "Circ"
        Me.Circ.Name = "Circ"
        Me.Circ.ReadOnly = True
        Me.Circ.Width = 50
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RecCodigo.DefaultCellStyle = DataGridViewCellStyle4
        Me.RecCodigo.HeaderText = "Código"
        Me.RecCodigo.Name = "RecCodigo"
        Me.RecCodigo.ReadOnly = True
        '
        'Exec
        '
        Me.Exec.HeaderText = "Exec"
        Me.Exec.Name = "Exec"
        Me.Exec.ReadOnly = True
        Me.Exec.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Exec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Exec.Width = 70
        '
        'imExec
        '
        Me.imExec.ImageStream = CType(resources.GetObject("imExec.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imExec.TransparentColor = System.Drawing.Color.Transparent
        Me.imExec.Images.SetKeyName(0, "media_stop_red.png")
        Me.imExec.Images.SetKeyName(1, "media_play_green.png")
        '
        'frmCipCmd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 415)
        Me.Controls.Add(Me.gvItens)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmCipCmd"
        Me.Text = "Comandos do CIP"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents butStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents butStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents imExec As System.Windows.Forms.ImageList
    Friend WithEvents CircNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Circ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Exec As System.Windows.Forms.DataGridViewImageColumn
End Class
