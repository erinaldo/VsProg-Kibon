<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbProdPlanejCtrl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKbProdPlanejCtrl))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArquivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSair = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReceitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlcLe = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlcEnvia = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAjuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSobre = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButLe = New System.Windows.Forms.ToolStripButton()
        Me.ButEnvia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButAjuda = New System.Windows.Forms.ToolStripButton()
        Me.ButSair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbPasta = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbSubpasta = New System.Windows.Forms.ToolStripComboBox()
        Me.grpBatch = New System.Windows.Forms.GroupBox()
        Me.TotalProduzir = New System.Windows.Forms.MaskedTextBox()
        Me.TamanhoBatch = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpPlanej = New System.Windows.Forms.GroupBox()
        Me.txtContaD = New System.Windows.Forms.TextBox()
        Me.cmdRelat = New System.Windows.Forms.Button()
        Me.cmbReceitas = New System.Windows.Forms.ComboBox()
        Me.cmbDestTqs = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.labelStrip1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelStrip2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmrPula = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.cmdRelatPreench = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grpBatch.SuspendLayout()
        Me.grpPlanej.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArquivo, Me.ReceitaToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(634, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuArquivo
        '
        Me.mnuArquivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSair})
        Me.mnuArquivo.Name = "mnuArquivo"
        Me.mnuArquivo.Size = New System.Drawing.Size(61, 20)
        Me.mnuArquivo.Text = "Arquivo"
        '
        'mnuSair
        '
        Me.mnuSair.Name = "mnuSair"
        Me.mnuSair.Size = New System.Drawing.Size(93, 22)
        Me.mnuSair.Text = "Sair"
        '
        'ReceitaToolStripMenuItem
        '
        Me.ReceitaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlcLe, Me.mnuPlcEnvia})
        Me.ReceitaToolStripMenuItem.Name = "ReceitaToolStripMenuItem"
        Me.ReceitaToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReceitaToolStripMenuItem.Text = "Receita"
        '
        'mnuPlcLe
        '
        Me.mnuPlcLe.Name = "mnuPlcLe"
        Me.mnuPlcLe.Size = New System.Drawing.Size(155, 22)
        Me.mnuPlcLe.Text = "Ler do PLC..."
        '
        'mnuPlcEnvia
        '
        Me.mnuPlcEnvia.Name = "mnuPlcEnvia"
        Me.mnuPlcEnvia.Size = New System.Drawing.Size(155, 22)
        Me.mnuPlcEnvia.Text = "Enviar ao PLC..."
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAjuda, Me.ToolStripMenuItem1, Me.mnuSobre})
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.AjudaToolStripMenuItem.Text = "Ajuda"
        '
        'mnuAjuda
        '
        Me.mnuAjuda.Name = "mnuAjuda"
        Me.mnuAjuda.Size = New System.Drawing.Size(260, 22)
        Me.mnuAjuda.Text = "Tópicos de Ajuda"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(257, 6)
        '
        'mnuSobre
        '
        Me.mnuSobre.Name = "mnuSobre"
        Me.mnuSobre.Size = New System.Drawing.Size(260, 22)
        Me.mnuSobre.Text = "Sobre o Planejamento de Produção"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButLe, Me.ButEnvia, Me.ToolStripSeparator1, Me.ButAjuda, Me.ButSair, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.cmbPasta, Me.ToolStripLabel2, Me.cmbSubpasta})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(634, 25)
        Me.ToolStrip1.TabIndex = 1
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ButAjuda
        '
        Me.ButAjuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButAjuda.Image = CType(resources.GetObject("ButAjuda.Image"), System.Drawing.Image)
        Me.ButAjuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButAjuda.Name = "ButAjuda"
        Me.ButAjuda.Size = New System.Drawing.Size(23, 22)
        Me.ButAjuda.Text = "Ajuda"
        '
        'ButSair
        '
        Me.ButSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButSair.Image = CType(resources.GetObject("ButSair.Image"), System.Drawing.Image)
        Me.ButSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButSair.Name = "ButSair"
        Me.ButSair.Size = New System.Drawing.Size(23, 22)
        Me.ButSair.Text = "Sair"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabel1.Text = "Pasta:"
        '
        'cmbPasta
        '
        Me.cmbPasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPasta.Name = "cmbPasta"
        Me.cmbPasta.Size = New System.Drawing.Size(195, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripLabel2.Text = "Subpasta:"
        '
        'cmbSubpasta
        '
        Me.cmbSubpasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubpasta.Name = "cmbSubpasta"
        Me.cmbSubpasta.Size = New System.Drawing.Size(195, 25)
        '
        'grpBatch
        '
        Me.grpBatch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBatch.Controls.Add(Me.TotalProduzir)
        Me.grpBatch.Controls.Add(Me.TamanhoBatch)
        Me.grpBatch.Controls.Add(Me.Label8)
        Me.grpBatch.Controls.Add(Me.Label7)
        Me.grpBatch.Controls.Add(Me.Label5)
        Me.grpBatch.Controls.Add(Me.Label6)
        Me.grpBatch.Location = New System.Drawing.Point(13, 251)
        Me.grpBatch.Name = "grpBatch"
        Me.grpBatch.Size = New System.Drawing.Size(614, 113)
        Me.grpBatch.TabIndex = 2
        Me.grpBatch.TabStop = False
        Me.grpBatch.Text = "Batch"
        '
        'TotalProduzir
        '
        Me.TotalProduzir.Location = New System.Drawing.Point(120, 49)
        Me.TotalProduzir.Name = "TotalProduzir"
        Me.TotalProduzir.Size = New System.Drawing.Size(263, 20)
        Me.TotalProduzir.TabIndex = 19
        Me.TotalProduzir.Text = "1"
        '
        'TamanhoBatch
        '
        Me.TamanhoBatch.Location = New System.Drawing.Point(120, 19)
        Me.TamanhoBatch.Name = "TamanhoBatch"
        Me.TamanhoBatch.Size = New System.Drawing.Size(263, 20)
        Me.TamanhoBatch.TabIndex = 18
        Me.TamanhoBatch.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(395, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Kg"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Total a produzir"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Tamanho do Batch"
        '
        'grpPlanej
        '
        Me.grpPlanej.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPlanej.Controls.Add(Me.cmdRelatPreench)
        Me.grpPlanej.Controls.Add(Me.txtContaD)
        Me.grpPlanej.Controls.Add(Me.cmdRelat)
        Me.grpPlanej.Controls.Add(Me.cmbReceitas)
        Me.grpPlanej.Controls.Add(Me.cmbDestTqs)
        Me.grpPlanej.Controls.Add(Me.Label2)
        Me.grpPlanej.Controls.Add(Me.Label1)
        Me.grpPlanej.Location = New System.Drawing.Point(12, 52)
        Me.grpPlanej.Name = "grpPlanej"
        Me.grpPlanej.Size = New System.Drawing.Size(614, 193)
        Me.grpPlanej.TabIndex = 3
        Me.grpPlanej.TabStop = False
        Me.grpPlanej.Text = "Planejamento"
        '
        'txtContaD
        '
        Me.txtContaD.BackColor = System.Drawing.Color.White
        Me.txtContaD.Location = New System.Drawing.Point(463, 92)
        Me.txtContaD.Name = "txtContaD"
        Me.txtContaD.ReadOnly = True
        Me.txtContaD.Size = New System.Drawing.Size(67, 20)
        Me.txtContaD.TabIndex = 20
        Me.txtContaD.Text = "0"
        Me.txtContaD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdRelat
        '
        Me.cmdRelat.Image = Global.KbProdPlanejCtrl.My.Resources.Resources.ExcelLaST_32l
        Me.cmdRelat.Location = New System.Drawing.Point(536, 78)
        Me.cmdRelat.Name = "cmdRelat"
        Me.cmdRelat.Size = New System.Drawing.Size(58, 46)
        Me.cmdRelat.TabIndex = 6
        Me.cmdRelat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRelat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdRelat.UseVisualStyleBackColor = True
        '
        'cmbReceitas
        '
        Me.cmbReceitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReceitas.FormattingEnabled = True
        Me.cmbReceitas.Location = New System.Drawing.Point(120, 51)
        Me.cmbReceitas.Name = "cmbReceitas"
        Me.cmbReceitas.Size = New System.Drawing.Size(474, 21)
        Me.cmbReceitas.TabIndex = 4
        '
        'cmbDestTqs
        '
        Me.cmbDestTqs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestTqs.FormattingEnabled = True
        Me.cmbDestTqs.Location = New System.Drawing.Point(120, 24)
        Me.cmbDestTqs.Name = "cmbDestTqs"
        Me.cmbDestTqs.Size = New System.Drawing.Size(474, 21)
        Me.cmbDestTqs.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Produto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Planejamento para"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelStrip1, Me.labelStrip2})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 374)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(634, 22)
        Me.StatusStrip.TabIndex = 4
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
        'TmrPula
        '
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 1000
        '
        'cmdRelatPreench
        '
        Me.cmdRelatPreench.Image = Global.KbProdPlanejCtrl.My.Resources.Resources.ExcelLaST_32l
        Me.cmdRelatPreench.Location = New System.Drawing.Point(536, 136)
        Me.cmdRelatPreench.Name = "cmdRelatPreench"
        Me.cmdRelatPreench.Size = New System.Drawing.Size(58, 46)
        Me.cmdRelatPreench.TabIndex = 21
        Me.cmdRelatPreench.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRelatPreench.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdRelatPreench.UseVisualStyleBackColor = True
        '
        'frmKbProdPlanejCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 396)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.grpPlanej)
        Me.Controls.Add(Me.grpBatch)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmKbProdPlanejCtrl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planejamento de Produção Server"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpBatch.ResumeLayout(False)
        Me.grpBatch.PerformLayout()
        Me.grpPlanej.ResumeLayout(False)
        Me.grpPlanej.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuArquivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReceitaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlcLe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlcEnvia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAjuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSobre As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButLe As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButEnvia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButAjuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbPasta As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbSubpasta As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpBatch As System.Windows.Forms.GroupBox
    Friend WithEvents grpPlanej As System.Windows.Forms.GroupBox
    Friend WithEvents cmbReceitas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDestTqs As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents labelStrip1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents labelStrip2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TamanhoBatch As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TotalProduzir As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TmrPula As System.Windows.Forms.Timer
    Friend WithEvents cmdRelat As System.Windows.Forms.Button
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents txtContaD As System.Windows.Forms.TextBox
    Friend WithEvents cmdRelatPreench As Button
End Class
