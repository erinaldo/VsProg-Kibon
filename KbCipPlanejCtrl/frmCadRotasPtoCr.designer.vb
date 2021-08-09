<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadRotasPtoCr
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadRotasPtoCr))
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLimRev = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDescr = New System.Windows.Forms.TextBox
        Me.txtSubgrupo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtGrupo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRotaId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gvCadPtoCr = New System.Windows.Forms.DataGridView
        Me.PtoCrId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pergunta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsCadPtoCr = New System.Windows.Forms.BindingSource(Me.components)
        Me.gvCadRotasPtoCr = New System.Windows.Forms.DataGridView
        Me.Seq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RotaPtoCrId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RotaDescr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.butInsere = New System.Windows.Forms.Button
        Me.ilButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.butExclui = New System.Windows.Forms.Button
        Me.taCadPtoCr = New Geral.dsxCipValidTableAdapters.taxCadPtoCr
        Me.taCadRotaPtoCr = New Geral.dsxCipValidTableAdapters.taxCadRotaPtoCr
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.gvCadPtoCr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsCadPtoCr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCadRotasPtoCr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(112, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Descr"
        '
        'txtLimRev
        '
        Me.txtLimRev.Location = New System.Drawing.Point(538, 12)
        Me.txtLimRev.Name = "txtLimRev"
        Me.txtLimRev.Size = New System.Drawing.Size(63, 20)
        Me.txtLimRev.TabIndex = 25
        Me.txtLimRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(486, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Revisão"
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(157, 38)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(444, 20)
        Me.txtDescr.TabIndex = 23
        '
        'txtSubgrupo
        '
        Me.txtSubgrupo.Location = New System.Drawing.Point(400, 12)
        Me.txtSubgrupo.Name = "txtSubgrupo"
        Me.txtSubgrupo.Size = New System.Drawing.Size(63, 20)
        Me.txtSubgrupo.TabIndex = 22
        Me.txtSubgrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(347, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Subrupo"
        '
        'txtGrupo
        '
        Me.txtGrupo.Location = New System.Drawing.Point(277, 12)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(63, 20)
        Me.txtGrupo.TabIndex = 20
        Me.txtGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(232, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Grupo"
        '
        'txtRotaId
        '
        Me.txtRotaId.Location = New System.Drawing.Point(157, 12)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.Size = New System.Drawing.Size(63, 20)
        Me.txtRotaId.TabIndex = 18
        Me.txtRotaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(112, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "RotaId"
        '
        'gvCadPtoCr
        '
        Me.gvCadPtoCr.AllowUserToAddRows = False
        Me.gvCadPtoCr.AllowUserToDeleteRows = False
        Me.gvCadPtoCr.AutoGenerateColumns = False
        Me.gvCadPtoCr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCadPtoCr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PtoCrId, Me.Pergunta})
        Me.gvCadPtoCr.DataSource = Me.bsCadPtoCr
        Me.gvCadPtoCr.Location = New System.Drawing.Point(12, 78)
        Me.gvCadPtoCr.Name = "gvCadPtoCr"
        Me.gvCadPtoCr.ReadOnly = True
        Me.gvCadPtoCr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCadPtoCr.Size = New System.Drawing.Size(761, 117)
        Me.gvCadPtoCr.TabIndex = 27
        '
        'PtoCrId
        '
        Me.PtoCrId.DataPropertyName = "PtoCrId"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PtoCrId.DefaultCellStyle = DataGridViewCellStyle1
        Me.PtoCrId.HeaderText = "PtoCrId"
        Me.PtoCrId.Name = "PtoCrId"
        Me.PtoCrId.ReadOnly = True
        '
        'Pergunta
        '
        Me.Pergunta.DataPropertyName = "Pergunta"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Pergunta.DefaultCellStyle = DataGridViewCellStyle2
        Me.Pergunta.HeaderText = "Pergunta"
        Me.Pergunta.Name = "Pergunta"
        Me.Pergunta.ReadOnly = True
        Me.Pergunta.Width = 600
        '
        'bsCadPtoCr
        '
        Me.bsCadPtoCr.DataMember = "CadRotaPtoCr"
        '
        'gvCadRotasPtoCr
        '
        Me.gvCadRotasPtoCr.AllowUserToAddRows = False
        Me.gvCadRotasPtoCr.AllowUserToDeleteRows = False
        Me.gvCadRotasPtoCr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCadRotasPtoCr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seq, Me.RotaPtoCrId, Me.RotaDescr})
        Me.gvCadRotasPtoCr.Location = New System.Drawing.Point(12, 230)
        Me.gvCadRotasPtoCr.Name = "gvCadRotasPtoCr"
        Me.gvCadRotasPtoCr.ReadOnly = True
        Me.gvCadRotasPtoCr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCadRotasPtoCr.Size = New System.Drawing.Size(761, 277)
        Me.gvCadRotasPtoCr.TabIndex = 28
        '
        'Seq
        '
        Me.Seq.DataPropertyName = "Seq"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Seq.DefaultCellStyle = DataGridViewCellStyle3
        Me.Seq.HeaderText = "Seq"
        Me.Seq.Name = "Seq"
        Me.Seq.ReadOnly = True
        Me.Seq.Width = 50
        '
        'RotaPtoCrId
        '
        Me.RotaPtoCrId.DataPropertyName = "PtoCrId"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RotaPtoCrId.DefaultCellStyle = DataGridViewCellStyle4
        Me.RotaPtoCrId.HeaderText = "PtoCrId"
        Me.RotaPtoCrId.Name = "RotaPtoCrId"
        Me.RotaPtoCrId.ReadOnly = True
        Me.RotaPtoCrId.Width = 50
        '
        'RotaDescr
        '
        Me.RotaDescr.DataPropertyName = "Pergunta"
        Me.RotaDescr.HeaderText = "Pergunta"
        Me.RotaDescr.Name = "RotaDescr"
        Me.RotaDescr.ReadOnly = True
        Me.RotaDescr.Width = 600
        '
        'butInsere
        '
        Me.butInsere.ImageIndex = 1
        Me.butInsere.ImageList = Me.ilButtons
        Me.butInsere.Location = New System.Drawing.Point(443, 201)
        Me.butInsere.Name = "butInsere"
        Me.butInsere.Size = New System.Drawing.Size(75, 23)
        Me.butInsere.TabIndex = 29
        Me.butInsere.UseVisualStyleBackColor = True
        '
        'ilButtons
        '
        Me.ilButtons.ImageStream = CType(resources.GetObject("ilButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilButtons.TransparentColor = System.Drawing.Color.Magenta
        Me.ilButtons.Images.SetKeyName(0, "Bot16x16SetaAcima1.bmp")
        Me.ilButtons.Images.SetKeyName(1, "Bot16x16SetaAbaixo1.bmp")
        '
        'butExclui
        '
        Me.butExclui.ImageIndex = 0
        Me.butExclui.ImageList = Me.ilButtons
        Me.butExclui.Location = New System.Drawing.Point(265, 201)
        Me.butExclui.Name = "butExclui"
        Me.butExclui.Size = New System.Drawing.Size(75, 23)
        Me.butExclui.TabIndex = 30
        Me.butExclui.UseVisualStyleBackColor = True
        '
        'taCadPtoCr
        '
        Me.taCadPtoCr.ClearBeforeFill = True
        '
        'taCadRotaPtoCr
        '
        Me.taCadRotaPtoCr.ClearBeforeFill = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Pontos críticos cadastrados"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 214)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(208, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Selecionados para esta rota de CIP"
        '
        'frmCadRotasPtoCr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 519)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.butExclui)
        Me.Controls.Add(Me.butInsere)
        Me.Controls.Add(Me.gvCadRotasPtoCr)
        Me.Controls.Add(Me.gvCadPtoCr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLimRev)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.txtSubgrupo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtGrupo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRotaId)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCadRotasPtoCr"
        Me.Text = "frmCadRotasPtoCr"
        CType(Me.gvCadPtoCr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsCadPtoCr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCadRotasPtoCr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLimRev As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtSubgrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gvCadPtoCr As System.Windows.Forms.DataGridView
    Friend WithEvents gvCadRotasPtoCr As System.Windows.Forms.DataGridView
    Friend WithEvents butInsere As System.Windows.Forms.Button
    Friend WithEvents butExclui As System.Windows.Forms.Button
    Friend WithEvents taCadPtoCr As Geral.dsxCipValidTableAdapters.taxCadPtoCr
    Friend WithEvents taCadRotaPtoCr As Geral.dsxCipValidTableAdapters.taxCadRotaPtoCr
    Friend WithEvents bsCadPtoCr As System.Windows.Forms.BindingSource
    Friend WithEvents PtoCrId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pergunta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaPtoCrId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RotaDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ilButtons As System.Windows.Forms.ImageList
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
