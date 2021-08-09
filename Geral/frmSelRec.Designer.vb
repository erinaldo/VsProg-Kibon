<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelRec
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelRec))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.trPastas = New System.Windows.Forms.TreeView()
        Me.lstImg = New System.Windows.Forms.ImageList(Me.components)
        Me.butCancelar = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.gvReceitas = New System.Windows.Forms.DataGridView()
        Me.colRecNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecNome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbSubpasta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPasta = New System.Windows.Forms.ComboBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gvReceitas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trPastas)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.butCancelar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.butOk)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gvReceitas)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbSubpasta)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbPasta)
        Me.SplitContainer1.Size = New System.Drawing.Size(712, 376)
        Me.SplitContainer1.SplitterDistance = 237
        Me.SplitContainer1.TabIndex = 1
        '
        'trPastas
        '
        Me.trPastas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trPastas.ImageIndex = 0
        Me.trPastas.ImageList = Me.lstImg
        Me.trPastas.Location = New System.Drawing.Point(0, 0)
        Me.trPastas.Name = "trPastas"
        Me.trPastas.SelectedImageIndex = 0
        Me.trPastas.Size = New System.Drawing.Size(237, 376)
        Me.trPastas.TabIndex = 0
        '
        'lstImg
        '
        Me.lstImg.ImageStream = CType(resources.GetObject("lstImg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.lstImg.TransparentColor = System.Drawing.Color.Fuchsia
        Me.lstImg.Images.SetKeyName(0, "Bot16x16_Pasta.bmp")
        '
        'butCancelar
        '
        Me.butCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancelar.Location = New System.Drawing.Point(258, 332)
        Me.butCancelar.Name = "butCancelar"
        Me.butCancelar.Size = New System.Drawing.Size(148, 36)
        Me.butCancelar.TabIndex = 10
        Me.butCancelar.Text = "Cancelar"
        Me.butCancelar.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butOk.Location = New System.Drawing.Point(71, 332)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(148, 36)
        Me.butOk.TabIndex = 9
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'gvReceitas
        '
        Me.gvReceitas.AllowUserToAddRows = False
        Me.gvReceitas.AllowUserToDeleteRows = False
        Me.gvReceitas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvReceitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvReceitas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRecNum, Me.colRecNome, Me.colRecDescr})
        Me.gvReceitas.Location = New System.Drawing.Point(3, 63)
        Me.gvReceitas.Name = "gvReceitas"
        Me.gvReceitas.ReadOnly = True
        Me.gvReceitas.RowHeadersWidth = 15
        Me.gvReceitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvReceitas.Size = New System.Drawing.Size(465, 259)
        Me.gvReceitas.TabIndex = 4
        '
        'colRecNum
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRecNum.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRecNum.HeaderText = "Numero"
        Me.colRecNum.Name = "colRecNum"
        Me.colRecNum.ReadOnly = True
        Me.colRecNum.Width = 60
        '
        'colRecNome
        '
        Me.colRecNome.HeaderText = "Nome"
        Me.colRecNome.Name = "colRecNome"
        Me.colRecNome.ReadOnly = True
        Me.colRecNome.Width = 150
        '
        'colRecDescr
        '
        Me.colRecDescr.HeaderText = "Descrição"
        Me.colRecDescr.Name = "colRecDescr"
        Me.colRecDescr.ReadOnly = True
        Me.colRecDescr.Width = 210
        '
        'cmbSubpasta
        '
        Me.cmbSubpasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubpasta.FormattingEnabled = True
        Me.cmbSubpasta.Location = New System.Drawing.Point(68, 36)
        Me.cmbSubpasta.Name = "cmbSubpasta"
        Me.cmbSubpasta.Size = New System.Drawing.Size(191, 21)
        Me.cmbSubpasta.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Subpasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pasta"
        '
        'cmbPasta
        '
        Me.cmbPasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPasta.FormattingEnabled = True
        Me.cmbPasta.Location = New System.Drawing.Point(68, 6)
        Me.cmbPasta.Name = "cmbPasta"
        Me.cmbPasta.Size = New System.Drawing.Size(191, 21)
        Me.cmbPasta.TabIndex = 0
        '
        'frmSelRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 376)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelRec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecione a Receita"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gvReceitas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents trPastas As System.Windows.Forms.TreeView
    Friend WithEvents lstImg As System.Windows.Forms.ImageList
    Friend WithEvents butCancelar As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents gvReceitas As System.Windows.Forms.DataGridView
    Friend WithEvents colRecNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecNome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbSubpasta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPasta As System.Windows.Forms.ComboBox
End Class
