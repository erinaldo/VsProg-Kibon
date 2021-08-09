<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadAlergRec
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadAlergRec))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.gvAlergRec = New System.Windows.Forms.DataGridView()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.chkClearAll = New System.Windows.Forms.CheckBox()
        Me.ImageListAlerg = New System.Windows.Forms.ImageList(Me.components)
        Me.chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ImgAlergRec = New System.Windows.Forms.DataGridViewImageColumn()
        Me.CodAlerg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alergenico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvAlergRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 500)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(409, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'gvAlergRec
        '
        Me.gvAlergRec.AllowUserToAddRows = False
        Me.gvAlergRec.AllowUserToDeleteRows = False
        Me.gvAlergRec.AllowUserToResizeColumns = False
        Me.gvAlergRec.AllowUserToResizeRows = False
        Me.gvAlergRec.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvAlergRec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gvAlergRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvAlergRec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chk, Me.ImgAlergRec, Me.CodAlerg, Me.Alergenico, Me.Letra})
        Me.gvAlergRec.Location = New System.Drawing.Point(0, 23)
        Me.gvAlergRec.Name = "gvAlergRec"
        Me.gvAlergRec.RowHeadersVisible = False
        Me.gvAlergRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvAlergRec.Size = New System.Drawing.Size(408, 450)
        Me.gvAlergRec.TabIndex = 0
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(333, 475)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 23)
        Me.butCancel.TabIndex = 3
        Me.butCancel.Text = "Cancelar"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(256, 475)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(75, 23)
        Me.butOk.TabIndex = 4
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'chkClearAll
        '
        Me.chkClearAll.AutoSize = True
        Me.chkClearAll.Location = New System.Drawing.Point(10, 4)
        Me.chkClearAll.Name = "chkClearAll"
        Me.chkClearAll.Size = New System.Drawing.Size(99, 17)
        Me.chkClearAll.TabIndex = 5
        Me.chkClearAll.Text = "Limpar Seleção"
        Me.chkClearAll.UseVisualStyleBackColor = True
        '
        'ImageListAlerg
        '
        Me.ImageListAlerg.ImageStream = CType(resources.GetObject("ImageListAlerg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListAlerg.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListAlerg.Images.SetKeyName(0, "ALLERGY_06.png")
        '
        'chk
        '
        Me.chk.HeaderText = ""
        Me.chk.Name = "chk"
        Me.chk.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.chk.Width = 30
        '
        'ImgAlergRec
        '
        Me.ImgAlergRec.HeaderText = ""
        Me.ImgAlergRec.Image = CType(resources.GetObject("ImgAlergRec.Image"), System.Drawing.Image)
        Me.ImgAlergRec.Name = "ImgAlergRec"
        Me.ImgAlergRec.ReadOnly = True
        Me.ImgAlergRec.Width = 30
        '
        'CodAlerg
        '
        Me.CodAlerg.HeaderText = "CodAlerg"
        Me.CodAlerg.Name = "CodAlerg"
        Me.CodAlerg.ReadOnly = True
        Me.CodAlerg.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodAlerg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodAlerg.Visible = False
        Me.CodAlerg.Width = 30
        '
        'Alergenico
        '
        Me.Alergenico.HeaderText = "Alergênico"
        Me.Alergenico.Name = "Alergenico"
        Me.Alergenico.ReadOnly = True
        Me.Alergenico.Width = 250
        '
        'Letra
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle6
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.Width = 50
        '
        'frmCadAlergRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 522)
        Me.Controls.Add(Me.chkClearAll)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.gvAlergRec)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCadAlergRec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecione o(s) Alergênico(s)"
        CType(Me.gvAlergRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvAlergRec As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents chkClearAll As System.Windows.Forms.CheckBox
    Friend WithEvents ImageListAlerg As System.Windows.Forms.ImageList
    Friend WithEvents chk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ImgAlergRec As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CodAlerg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alergenico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
