<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelat
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
        Me.txtDtHor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPsNom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPsTara = New System.Windows.Forms.TextBox()
        Me.cbxMaq = New System.Windows.Forms.ComboBox()
        Me.butPesq = New System.Windows.Forms.Button()
        Me.butGeraRelat = New System.Windows.Forms.Button()
        Me.txtDatFin = New System.Windows.Forms.TextBox()
        Me.txtDatIni = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cbxNomeProd = New System.Windows.Forms.ComboBox()
        Me.gvEstatTot = New System.Windows.Forms.DataGridView()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.gvEstatCont = New System.Windows.Forms.DataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.butPesqEstat = New System.Windows.Forms.Button()
        Me.dpDataIni = New System.Windows.Forms.DateTimePicker()
        Me.dpDataFin = New System.Windows.Forms.DateTimePicker()
        CType(Me.gvEstatTot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gvEstatCont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDtHor
        '
        Me.txtDtHor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDtHor.Location = New System.Drawing.Point(663, 28)
        Me.txtDtHor.Name = "txtDtHor"
        Me.txtDtHor.ReadOnly = True
        Me.txtDtHor.Size = New System.Drawing.Size(167, 20)
        Me.txtDtHor.TabIndex = 0
        Me.txtDtHor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(596, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data/Hora:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(189, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Máquina:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(190, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Produto:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(162, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Peso Nominal:"
        '
        'txtPsNom
        '
        Me.txtPsNom.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPsNom.Location = New System.Drawing.Point(243, 60)
        Me.txtPsNom.Name = "txtPsNom"
        Me.txtPsNom.ReadOnly = True
        Me.txtPsNom.Size = New System.Drawing.Size(88, 20)
        Me.txtPsNom.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(402, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Peso Tara:"
        '
        'txtPsTara
        '
        Me.txtPsTara.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPsTara.Location = New System.Drawing.Point(467, 60)
        Me.txtPsTara.Name = "txtPsTara"
        Me.txtPsTara.ReadOnly = True
        Me.txtPsTara.Size = New System.Drawing.Size(88, 20)
        Me.txtPsTara.TabIndex = 11
        '
        'cbxMaq
        '
        Me.cbxMaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMaq.FormattingEnabled = True
        Me.cbxMaq.Location = New System.Drawing.Point(246, 28)
        Me.cbxMaq.Name = "cbxMaq"
        Me.cbxMaq.Size = New System.Drawing.Size(312, 21)
        Me.cbxMaq.TabIndex = 58
        '
        'butPesq
        '
        Me.butPesq.Location = New System.Drawing.Point(720, 53)
        Me.butPesq.Name = "butPesq"
        Me.butPesq.Size = New System.Drawing.Size(75, 23)
        Me.butPesq.TabIndex = 60
        Me.butPesq.Text = "Pesquisar"
        Me.butPesq.UseVisualStyleBackColor = True
        '
        'butGeraRelat
        '
        Me.butGeraRelat.Location = New System.Drawing.Point(813, 244)
        Me.butGeraRelat.Name = "butGeraRelat"
        Me.butGeraRelat.Size = New System.Drawing.Size(92, 32)
        Me.butGeraRelat.TabIndex = 61
        Me.butGeraRelat.Text = "Gerar Excel"
        Me.butGeraRelat.UseVisualStyleBackColor = True
        '
        'txtDatFin
        '
        Me.txtDatFin.Location = New System.Drawing.Point(446, 251)
        Me.txtDatFin.Name = "txtDatFin"
        Me.txtDatFin.Size = New System.Drawing.Size(200, 20)
        Me.txtDatFin.TabIndex = 66
        '
        'txtDatIni
        '
        Me.txtDatIni.Location = New System.Drawing.Point(163, 251)
        Me.txtDatIni.Name = "txtDatIni"
        Me.txtDatIni.Size = New System.Drawing.Size(200, 20)
        Me.txtDatIni.TabIndex = 65
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(382, 254)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Data Final:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(94, 254)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Data Inicial:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(709, 35)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(84, 13)
        Me.Label32.TabIndex = 68
        Me.Label32.Text = "Estatística Total"
        '
        'cbxNomeProd
        '
        Me.cbxNomeProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNomeProd.FormattingEnabled = True
        Me.cbxNomeProd.Location = New System.Drawing.Point(243, 25)
        Me.cbxNomeProd.Name = "cbxNomeProd"
        Me.cbxNomeProd.Size = New System.Drawing.Size(312, 21)
        Me.cbxNomeProd.TabIndex = 74
        '
        'gvEstatTot
        '
        Me.gvEstatTot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvEstatTot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvEstatTot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column21, Me.Column22, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column11, Me.Column12, Me.Column13})
        Me.gvEstatTot.Location = New System.Drawing.Point(12, 36)
        Me.gvEstatTot.Name = "gvEstatTot"
        Me.gvEstatTot.Size = New System.Drawing.Size(998, 141)
        Me.gvEstatTot.TabIndex = 75
        '
        'Column21
        '
        Me.Column21.HeaderText = "Data/Hora"
        Me.Column21.Name = "Column21"
        '
        'Column22
        '
        Me.Column22.HeaderText = "Data/Hora (Gravação)"
        Me.Column22.Name = "Column22"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Qtd Total Aceito"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "TU1"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Curr. TU1"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "TU2"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Valor Medio"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Desvio Padrao"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Rejeitado"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Qtd TU1"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.HeaderText = "Qtd TU2"
        Me.Column9.Name = "Column9"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Outros"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Total Verificado"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "Total Nao Pesados"
        Me.Column13.Name = "Column13"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbxMaq)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDtHor)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1039, 92)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados Básicos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cbxNomeProd)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.butPesq)
        Me.GroupBox2.Controls.Add(Me.txtPsTara)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtPsNom)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(35, 134)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1039, 94)
        Me.GroupBox2.TabIndex = 78
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuração"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.gvEstatTot)
        Me.GroupBox3.Location = New System.Drawing.Point(35, 282)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1039, 206)
        Me.GroupBox3.TabIndex = 80
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estatística Total"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.gvEstatCont)
        Me.GroupBox4.Location = New System.Drawing.Point(35, 521)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1039, 194)
        Me.GroupBox4.TabIndex = 81
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Nível contadores de rejeição Estatística Total"
        '
        'gvEstatCont
        '
        Me.gvEstatCont.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvEstatCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvEstatCont.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20})
        Me.gvEstatCont.Location = New System.Drawing.Point(12, 33)
        Me.gvEstatCont.Name = "gvEstatCont"
        Me.gvEstatCont.Size = New System.Drawing.Size(998, 141)
        Me.gvEstatCont.TabIndex = 77
        '
        'Column14
        '
        Me.Column14.HeaderText = "Giveaway Total (gramas)"
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.HeaderText = "Giveaway Total (%)"
        Me.Column15.Name = "Column15"
        '
        'Column16
        '
        Me.Column16.HeaderText = "M.M.ALTO"
        Me.Column16.Name = "Column16"
        '
        'Column17
        '
        Me.Column17.HeaderText = "ALTO OK"
        Me.Column17.Name = "Column17"
        '
        'Column18
        '
        Me.Column18.HeaderText = "NOMINAL"
        Me.Column18.Name = "Column18"
        '
        'Column19
        '
        Me.Column19.HeaderText = "BAIXO"
        Me.Column19.Name = "Column19"
        '
        'Column20
        '
        Me.Column20.HeaderText = "EXTRA"
        Me.Column20.Name = "Column20"
        '
        'butPesqEstat
        '
        Me.butPesqEstat.Location = New System.Drawing.Point(684, 244)
        Me.butPesqEstat.Name = "butPesqEstat"
        Me.butPesqEstat.Size = New System.Drawing.Size(92, 32)
        Me.butPesqEstat.TabIndex = 82
        Me.butPesqEstat.Text = "Pesquisar"
        Me.butPesqEstat.UseVisualStyleBackColor = True
        '
        'dpDataIni
        '
        Me.dpDataIni.Location = New System.Drawing.Point(163, 251)
        Me.dpDataIni.Name = "dpDataIni"
        Me.dpDataIni.Size = New System.Drawing.Size(200, 20)
        Me.dpDataIni.TabIndex = 83
        '
        'dpDataFin
        '
        Me.dpDataFin.Location = New System.Drawing.Point(446, 251)
        Me.dpDataFin.Name = "dpDataFin"
        Me.dpDataFin.Size = New System.Drawing.Size(200, 20)
        Me.dpDataFin.TabIndex = 84
        '
        'frmRelat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1409, 762)
        Me.Controls.Add(Me.dpDataFin)
        Me.Controls.Add(Me.dpDataIni)
        Me.Controls.Add(Me.butPesqEstat)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDatFin)
        Me.Controls.Add(Me.txtDatIni)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.butGeraRelat)
        Me.Name = "frmRelat"
        Me.Text = "Estatística Total"
        CType(Me.gvEstatTot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.gvEstatCont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDtHor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPsNom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPsTara As System.Windows.Forms.TextBox
    Friend WithEvents cbxMaq As System.Windows.Forms.ComboBox
    Friend WithEvents butPesq As System.Windows.Forms.Button
    Friend WithEvents butGeraRelat As System.Windows.Forms.Button
    Friend WithEvents txtDatFin As System.Windows.Forms.TextBox
    Friend WithEvents txtDatIni As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cbxNomeProd As System.Windows.Forms.ComboBox
    Friend WithEvents gvEstatTot As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gvEstatCont As System.Windows.Forms.DataGridView
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents butPesqEstat As System.Windows.Forms.Button
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dpDataIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpDataFin As System.Windows.Forms.DateTimePicker
End Class
