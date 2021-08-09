<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIfProd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIfProd))
        Me.TotalProduzir = New System.Windows.Forms.MaskedTextBox()
        Me.cmbSubpasta = New System.Windows.Forms.ToolStripComboBox()
        Me.TamanhoBatch = New System.Windows.Forms.MaskedTextBox()
        Me.lblUnidProduzir = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.labelStrip1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelStrip2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblProduzir = New System.Windows.Forms.Label()
        Me.grpPlanej = New System.Windows.Forms.GroupBox()
        Me.chkListaAutomatica = New System.Windows.Forms.CheckBox()
        Me.txtAlergenicos = New System.Windows.Forms.TextBox()
        Me.lblAlergenicos = New System.Windows.Forms.Label()
        Me.cmbReceitas = New System.Windows.Forms.ComboBox()
        Me.cmbDestTqs = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdRelatPreench = New System.Windows.Forms.Button()
        Me.cmdRelat = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.grpBatch = New System.Windows.Forms.GroupBox()
        Me.cmbPasta = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButLe = New System.Windows.Forms.ToolStripButton()
        Me.ButEnvia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TmrPula = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btValidaRec = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRelatId = New System.Windows.Forms.Label()
        Me.StatusStrip.SuspendLayout()
        Me.grpPlanej.SuspendLayout()
        Me.grpBatch.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TotalProduzir
        '
        Me.TotalProduzir.Location = New System.Drawing.Point(120, 49)
        Me.TotalProduzir.Name = "TotalProduzir"
        Me.TotalProduzir.Size = New System.Drawing.Size(263, 20)
        Me.TotalProduzir.TabIndex = 19
        Me.TotalProduzir.Text = "1"
        '
        'cmbSubpasta
        '
        Me.cmbSubpasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubpasta.Enabled = False
        Me.cmbSubpasta.Name = "cmbSubpasta"
        Me.cmbSubpasta.Size = New System.Drawing.Size(195, 25)
        '
        'TamanhoBatch
        '
        Me.TamanhoBatch.Location = New System.Drawing.Point(120, 19)
        Me.TamanhoBatch.Name = "TamanhoBatch"
        Me.TamanhoBatch.Size = New System.Drawing.Size(263, 20)
        Me.TamanhoBatch.TabIndex = 18
        Me.TamanhoBatch.Text = "0"
        '
        'lblUnidProduzir
        '
        Me.lblUnidProduzir.AutoSize = True
        Me.lblUnidProduzir.Location = New System.Drawing.Point(395, 51)
        Me.lblUnidProduzir.Name = "lblUnidProduzir"
        Me.lblUnidProduzir.Size = New System.Drawing.Size(20, 13)
        Me.lblUnidProduzir.TabIndex = 13
        Me.lblUnidProduzir.Text = "Kg"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(395, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Kg"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelStrip1, Me.labelStrip2})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 334)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(779, 22)
        Me.StatusStrip.TabIndex = 9
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'labelStrip1
        '
        Me.labelStrip1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.labelStrip1.Name = "labelStrip1"
        Me.labelStrip1.Padding = New System.Windows.Forms.Padding(20, 1, 1, 1)
        Me.labelStrip1.Size = New System.Drawing.Size(40, 17)
        Me.labelStrip1.Text = "L1"
        '
        'labelStrip2
        '
        Me.labelStrip2.Margin = New System.Windows.Forms.Padding(400, 3, 0, 2)
        Me.labelStrip2.Name = "labelStrip2"
        Me.labelStrip2.Size = New System.Drawing.Size(19, 17)
        Me.labelStrip2.Text = "L2"
        '
        'lblProduzir
        '
        Me.lblProduzir.AutoSize = True
        Me.lblProduzir.Location = New System.Drawing.Point(34, 51)
        Me.lblProduzir.Name = "lblProduzir"
        Me.lblProduzir.Size = New System.Drawing.Size(83, 13)
        Me.lblProduzir.TabIndex = 7
        Me.lblProduzir.Text = "Total a produzir:"
        '
        'grpPlanej
        '
        Me.grpPlanej.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPlanej.Controls.Add(Me.chkListaAutomatica)
        Me.grpPlanej.Controls.Add(Me.txtAlergenicos)
        Me.grpPlanej.Controls.Add(Me.lblAlergenicos)
        Me.grpPlanej.Controls.Add(Me.cmbReceitas)
        Me.grpPlanej.Controls.Add(Me.cmbDestTqs)
        Me.grpPlanej.Controls.Add(Me.Label2)
        Me.grpPlanej.Controls.Add(Me.Label1)
        Me.grpPlanej.Location = New System.Drawing.Point(12, 28)
        Me.grpPlanej.Name = "grpPlanej"
        Me.grpPlanej.Size = New System.Drawing.Size(759, 117)
        Me.grpPlanej.TabIndex = 8
        Me.grpPlanej.TabStop = False
        Me.grpPlanej.Text = "Planejamento"
        '
        'chkListaAutomatica
        '
        Me.chkListaAutomatica.AutoSize = True
        Me.chkListaAutomatica.Location = New System.Drawing.Point(646, 81)
        Me.chkListaAutomatica.Name = "chkListaAutomatica"
        Me.chkListaAutomatica.Size = New System.Drawing.Size(103, 17)
        Me.chkListaAutomatica.TabIndex = 9
        Me.chkListaAutomatica.Text = "Lista automática"
        Me.chkListaAutomatica.UseVisualStyleBackColor = True
        Me.chkListaAutomatica.Visible = False
        '
        'txtAlergenicos
        '
        Me.txtAlergenicos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAlergenicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlergenicos.Location = New System.Drawing.Point(120, 78)
        Me.txtAlergenicos.Name = "txtAlergenicos"
        Me.txtAlergenicos.ReadOnly = True
        Me.txtAlergenicos.Size = New System.Drawing.Size(264, 20)
        Me.txtAlergenicos.TabIndex = 8
        Me.txtAlergenicos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAlergenicos.Visible = False
        '
        'lblAlergenicos
        '
        Me.lblAlergenicos.AutoSize = True
        Me.lblAlergenicos.Location = New System.Drawing.Point(47, 78)
        Me.lblAlergenicos.Name = "lblAlergenicos"
        Me.lblAlergenicos.Size = New System.Drawing.Size(71, 13)
        Me.lblAlergenicos.TabIndex = 7
        Me.lblAlergenicos.Text = "Alergênico(s):"
        Me.lblAlergenicos.Visible = False
        '
        'cmbReceitas
        '
        Me.cmbReceitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReceitas.FormattingEnabled = True
        Me.cmbReceitas.Location = New System.Drawing.Point(120, 51)
        Me.cmbReceitas.Name = "cmbReceitas"
        Me.cmbReceitas.Size = New System.Drawing.Size(629, 21)
        Me.cmbReceitas.TabIndex = 4
        '
        'cmbDestTqs
        '
        Me.cmbDestTqs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestTqs.FormattingEnabled = True
        Me.cmbDestTqs.Location = New System.Drawing.Point(120, 24)
        Me.cmbDestTqs.Name = "cmbDestTqs"
        Me.cmbDestTqs.Size = New System.Drawing.Size(629, 21)
        Me.cmbDestTqs.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Produto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Planejamento paraX:"
        '
        'cmdRelatPreench
        '
        Me.cmdRelatPreench.Image = Global.IfProd.My.Resources.Resources.ExcelLaST_32l
        Me.cmdRelatPreench.Location = New System.Drawing.Point(238, 24)
        Me.cmdRelatPreench.Name = "cmdRelatPreench"
        Me.cmdRelatPreench.Size = New System.Drawing.Size(58, 46)
        Me.cmdRelatPreench.TabIndex = 9
        Me.cmdRelatPreench.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRelatPreench.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdRelatPreench.UseVisualStyleBackColor = True
        Me.cmdRelatPreench.Visible = False
        '
        'cmdRelat
        '
        Me.cmdRelat.Image = Global.IfProd.My.Resources.Resources.ExcelLaST_32l
        Me.cmdRelat.Location = New System.Drawing.Point(132, 24)
        Me.cmdRelat.Name = "cmdRelat"
        Me.cmdRelat.Size = New System.Drawing.Size(58, 46)
        Me.cmdRelat.TabIndex = 6
        Me.cmdRelat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRelat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdRelat.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Tamanho do Batch:"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripLabel2.Text = "Subpasta:"
        '
        'grpBatch
        '
        Me.grpBatch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBatch.Controls.Add(Me.TotalProduzir)
        Me.grpBatch.Controls.Add(Me.TamanhoBatch)
        Me.grpBatch.Controls.Add(Me.lblUnidProduzir)
        Me.grpBatch.Controls.Add(Me.Label7)
        Me.grpBatch.Controls.Add(Me.lblProduzir)
        Me.grpBatch.Controls.Add(Me.Label6)
        Me.grpBatch.Location = New System.Drawing.Point(12, 151)
        Me.grpBatch.Name = "grpBatch"
        Me.grpBatch.Size = New System.Drawing.Size(759, 84)
        Me.grpBatch.TabIndex = 7
        Me.grpBatch.TabStop = False
        Me.grpBatch.Text = "Batch"
        '
        'cmbPasta
        '
        Me.cmbPasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPasta.Enabled = False
        Me.cmbPasta.Name = "cmbPasta"
        Me.cmbPasta.Size = New System.Drawing.Size(195, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButLe, Me.ButEnvia, Me.ToolStripLabel1, Me.cmbPasta, Me.ToolStripLabel2, Me.cmbSubpasta})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(779, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButLe
        '
        Me.ButLe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButLe.Image = CType(resources.GetObject("ButLe.Image"), System.Drawing.Image)
        Me.ButLe.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButLe.Name = "ButLe"
        Me.ButLe.Size = New System.Drawing.Size(23, 22)
        Me.ButLe.Text = "Ler do PLC"
        '
        'ButEnvia
        '
        Me.ButEnvia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButEnvia.Image = CType(resources.GetObject("ButEnvia.Image"), System.Drawing.Image)
        Me.ButEnvia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButEnvia.Name = "ButEnvia"
        Me.ButEnvia.Size = New System.Drawing.Size(23, 22)
        Me.ButEnvia.Text = "Enviar ao PLC"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabel1.Text = "Pasta:"
        '
        'TmrPula
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btValidaRec)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblRelatId)
        Me.GroupBox1.Controls.Add(Me.cmdRelatPreench)
        Me.GroupBox1.Controls.Add(Me.cmdRelat)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(759, 82)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Relatórios"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(578, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Validação de Receita:"
        '
        'btValidaRec
        '
        Me.btValidaRec.Image = Global.IfProd.My.Resources.Resources.ExcelLaST_32l
        Me.btValidaRec.Location = New System.Drawing.Point(691, 24)
        Me.btValidaRec.Name = "btValidaRec"
        Me.btValidaRec.Size = New System.Drawing.Size(58, 46)
        Me.btValidaRec.TabIndex = 11
        Me.btValidaRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btValidaRec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btValidaRec.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Receita selecionada:"
        '
        'lblRelatId
        '
        Me.lblRelatId.AutoSize = True
        Me.lblRelatId.Location = New System.Drawing.Point(211, 24)
        Me.lblRelatId.Name = "lblRelatId"
        Me.lblRelatId.Size = New System.Drawing.Size(21, 13)
        Me.lblRelatId.TabIndex = 10
        Me.lblRelatId.Text = "ID:"
        Me.lblRelatId.Visible = False
        '
        'frmIfProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 356)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.grpPlanej)
        Me.Controls.Add(Me.grpBatch)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIfProd"
        Me.Text = "Planejamento de Produção"
        Me.TopMost = True
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.grpPlanej.ResumeLayout(False)
        Me.grpPlanej.PerformLayout()
        Me.grpBatch.ResumeLayout(False)
        Me.grpBatch.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TotalProduzir As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmbSubpasta As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TamanhoBatch As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblUnidProduzir As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents labelStrip1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents labelStrip2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblProduzir As System.Windows.Forms.Label
    Friend WithEvents grpPlanej As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRelat As System.Windows.Forms.Button
    Friend WithEvents cmbReceitas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDestTqs As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents grpBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPasta As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButLe As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButEnvia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TmrPula As System.Windows.Forms.Timer
    Friend WithEvents lblAlergenicos As System.Windows.Forms.Label
    Friend WithEvents txtAlergenicos As System.Windows.Forms.TextBox
    Friend WithEvents cmdRelatPreench As Button
    Friend WithEvents chkListaAutomatica As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblRelatId As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btValidaRec As Button
End Class
