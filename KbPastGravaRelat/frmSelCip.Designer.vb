<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelCip
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
        Me.grdItens = New System.Windows.Forms.DataGridView()
        Me.dpDataFim = New System.Windows.Forms.DateTimePicker()
        Me.dpDataIni = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butPes = New System.Windows.Forms.Button()
        Me.cmbCirc = New System.Windows.Forms.ComboBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancela = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rwHistId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwDataHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwPasteurizador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grdItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rwHistId, Me.rwDataHora, Me.rwPasteurizador})
        Me.grdItens.Location = New System.Drawing.Point(15, 47)
        Me.grdItens.MultiSelect = False
        Me.grdItens.Name = "grdItens"
        Me.grdItens.ReadOnly = True
        Me.grdItens.RowHeadersVisible = False
        Me.grdItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdItens.Size = New System.Drawing.Size(805, 297)
        Me.grdItens.TabIndex = 38
        '
        'dpDataFim
        '
        Me.dpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDataFim.Location = New System.Drawing.Point(539, 9)
        Me.dpDataFim.Name = "dpDataFim"
        Me.dpDataFim.Size = New System.Drawing.Size(90, 20)
        Me.dpDataFim.TabIndex = 37
        '
        'dpDataIni
        '
        Me.dpDataIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDataIni.Location = New System.Drawing.Point(308, 11)
        Me.dpDataIni.Name = "dpDataIni"
        Me.dpDataIni.Size = New System.Drawing.Size(90, 20)
        Me.dpDataIni.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(205, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Data Inicial"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(436, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Data Final"
        '
        'butPes
        '
        Me.butPes.BackColor = System.Drawing.SystemColors.Control
        Me.butPes.Cursor = System.Windows.Forms.Cursors.Default
        Me.butPes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butPes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butPes.Location = New System.Drawing.Point(739, 7)
        Me.butPes.Name = "butPes"
        Me.butPes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butPes.Size = New System.Drawing.Size(81, 25)
        Me.butPes.TabIndex = 33
        Me.butPes.Text = "Refresh"
        Me.butPes.UseVisualStyleBackColor = False
        '
        'cmbCirc
        '
        Me.cmbCirc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCirc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCirc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCirc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCirc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbCirc.Items.AddRange(New Object() {"*", "1", "2"})
        Me.cmbCirc.Location = New System.Drawing.Point(92, 9)
        Me.cmbCirc.Name = "cmbCirc"
        Me.cmbCirc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCirc.Size = New System.Drawing.Size(89, 22)
        Me.cmbCirc.TabIndex = 31
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(228, 361)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(97, 25)
        Me.cmdOk.TabIndex = 30
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdCancela
        '
        Me.cmdCancela.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancela.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancela.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancela.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancela.Location = New System.Drawing.Point(500, 361)
        Me.cmdCancela.Name = "cmdCancela"
        Me.cmdCancela.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancela.Size = New System.Drawing.Size(97, 25)
        Me.cmdCancela.TabIndex = 29
        Me.cmdCancela.Text = "Cancela"
        Me.cmdCancela.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Pasteurizador"
        '
        'rwHistId
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwHistId.DefaultCellStyle = DataGridViewCellStyle1
        Me.rwHistId.HeaderText = "CipId"
        Me.rwHistId.Name = "rwHistId"
        Me.rwHistId.ReadOnly = True
        Me.rwHistId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rwHistId.Width = 150
        '
        'rwDataHora
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwDataHora.DefaultCellStyle = DataGridViewCellStyle2
        Me.rwDataHora.HeaderText = "Data e Hora"
        Me.rwDataHora.Name = "rwDataHora"
        Me.rwDataHora.ReadOnly = True
        Me.rwDataHora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rwDataHora.Width = 350
        '
        'rwPasteurizador
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwPasteurizador.DefaultCellStyle = DataGridViewCellStyle3
        Me.rwPasteurizador.HeaderText = "Pasteurizador"
        Me.rwPasteurizador.Name = "rwPasteurizador"
        Me.rwPasteurizador.ReadOnly = True
        Me.rwPasteurizador.Width = 150
        '
        'frmSelCip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 393)
        Me.Controls.Add(Me.grdItens)
        Me.Controls.Add(Me.dpDataFim)
        Me.Controls.Add(Me.dpDataIni)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butPes)
        Me.Controls.Add(Me.cmbCirc)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancela)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmSelCip"
        Me.Text = "Seleção de Históricos de CIP"
        CType(Me.grdItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdItens As System.Windows.Forms.DataGridView
    Friend WithEvents dpDataFim As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpDataIni As System.Windows.Forms.DateTimePicker
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents butPes As System.Windows.Forms.Button
    Public WithEvents cmbCirc As System.Windows.Forms.ComboBox
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents cmdCancela As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rwHistId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwDataHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwPasteurizador As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
