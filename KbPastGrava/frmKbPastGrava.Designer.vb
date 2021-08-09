<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbPastGrava
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKbPastGrava))
        Me.txtDataHora = New System.Windows.Forms.TextBox()
        Me.grdItens = New System.Windows.Forms.DataGridView()
        Me.rwPast = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwSts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwRecNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwTqOrig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwTqDest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwPressaoEst1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwPressaoEst2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwTempFdvPv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwTempFdvSp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwTempSaidaProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwPresSaidaProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwValvFdvA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwValvFdvB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwPresHomoEntr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwPresHomoSaida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwAgAlcoolTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.botSair = New System.Windows.Forms.Button()
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.txtContaD = New System.Windows.Forms.TextBox()
        CType(Me.grdItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDataHora
        '
        Me.txtDataHora.AcceptsReturn = True
        Me.txtDataHora.BackColor = System.Drawing.SystemColors.Window
        Me.txtDataHora.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDataHora.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataHora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDataHora.Location = New System.Drawing.Point(12, 176)
        Me.txtDataHora.MaxLength = 0
        Me.txtDataHora.Name = "txtDataHora"
        Me.txtDataHora.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataHora.Size = New System.Drawing.Size(201, 20)
        Me.txtDataHora.TabIndex = 26
        Me.txtDataHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.grdItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rwPast, Me.rwSts, Me.rwRecNum, Me.rwTqOrig, Me.rwTqDest, Me.rwPressaoEst1, Me.rwPressaoEst2, Me.rwTempFdvPv, Me.rwTempFdvSp, Me.rwTempSaidaProd, Me.rwPresSaidaProd, Me.rwValvFdvA, Me.rwValvFdvB, Me.rwPresHomoEntr, Me.rwPresHomoSaida, Me.rwAgAlcoolTemp})
        Me.grdItens.Location = New System.Drawing.Point(12, 12)
        Me.grdItens.MultiSelect = False
        Me.grdItens.Name = "grdItens"
        Me.grdItens.ReadOnly = True
        Me.grdItens.RowHeadersVisible = False
        Me.grdItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdItens.Size = New System.Drawing.Size(848, 147)
        Me.grdItens.TabIndex = 27
        '
        'rwPast
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwPast.DefaultCellStyle = DataGridViewCellStyle1
        Me.rwPast.HeaderText = "Past"
        Me.rwPast.Name = "rwPast"
        Me.rwPast.ReadOnly = True
        Me.rwPast.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rwPast.Width = 50
        '
        'rwSts
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwSts.DefaultCellStyle = DataGridViewCellStyle2
        Me.rwSts.HeaderText = "Sts"
        Me.rwSts.Name = "rwSts"
        Me.rwSts.ReadOnly = True
        Me.rwSts.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rwSts.Width = 50
        '
        'rwRecNum
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwRecNum.DefaultCellStyle = DataGridViewCellStyle3
        Me.rwRecNum.HeaderText = "RecNum"
        Me.rwRecNum.Name = "rwRecNum"
        Me.rwRecNum.ReadOnly = True
        Me.rwRecNum.Width = 50
        '
        'rwTqOrig
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwTqOrig.DefaultCellStyle = DataGridViewCellStyle4
        Me.rwTqOrig.HeaderText = "TqOrig"
        Me.rwTqOrig.Name = "rwTqOrig"
        Me.rwTqOrig.ReadOnly = True
        Me.rwTqOrig.Width = 50
        '
        'rwTqDest
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwTqDest.DefaultCellStyle = DataGridViewCellStyle5
        Me.rwTqDest.HeaderText = "TqDest"
        Me.rwTqDest.Name = "rwTqDest"
        Me.rwTqDest.ReadOnly = True
        Me.rwTqDest.Width = 50
        '
        'rwPressaoEst1
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwPressaoEst1.DefaultCellStyle = DataGridViewCellStyle6
        Me.rwPressaoEst1.HeaderText = "PressaoEst1"
        Me.rwPressaoEst1.Name = "rwPressaoEst1"
        Me.rwPressaoEst1.ReadOnly = True
        Me.rwPressaoEst1.Width = 50
        '
        'rwPressaoEst2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwPressaoEst2.DefaultCellStyle = DataGridViewCellStyle7
        Me.rwPressaoEst2.HeaderText = "PressaoEst2"
        Me.rwPressaoEst2.Name = "rwPressaoEst2"
        Me.rwPressaoEst2.ReadOnly = True
        Me.rwPressaoEst2.Width = 50
        '
        'rwTempFdvPv
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwTempFdvPv.DefaultCellStyle = DataGridViewCellStyle8
        Me.rwTempFdvPv.HeaderText = "TempFdvPv"
        Me.rwTempFdvPv.Name = "rwTempFdvPv"
        Me.rwTempFdvPv.ReadOnly = True
        Me.rwTempFdvPv.Width = 50
        '
        'rwTempFdvSp
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwTempFdvSp.DefaultCellStyle = DataGridViewCellStyle9
        Me.rwTempFdvSp.HeaderText = "TempFdvSp"
        Me.rwTempFdvSp.Name = "rwTempFdvSp"
        Me.rwTempFdvSp.ReadOnly = True
        Me.rwTempFdvSp.Width = 50
        '
        'rwTempSaidaProd
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwTempSaidaProd.DefaultCellStyle = DataGridViewCellStyle10
        Me.rwTempSaidaProd.HeaderText = "TempSaidaProd"
        Me.rwTempSaidaProd.Name = "rwTempSaidaProd"
        Me.rwTempSaidaProd.ReadOnly = True
        Me.rwTempSaidaProd.Width = 50
        '
        'rwPresSaidaProd
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwPresSaidaProd.DefaultCellStyle = DataGridViewCellStyle11
        Me.rwPresSaidaProd.HeaderText = "PresSaidaProd"
        Me.rwPresSaidaProd.Name = "rwPresSaidaProd"
        Me.rwPresSaidaProd.ReadOnly = True
        Me.rwPresSaidaProd.Width = 50
        '
        'rwValvFdvA
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwValvFdvA.DefaultCellStyle = DataGridViewCellStyle12
        Me.rwValvFdvA.HeaderText = "ValvFdvA"
        Me.rwValvFdvA.Name = "rwValvFdvA"
        Me.rwValvFdvA.ReadOnly = True
        Me.rwValvFdvA.Width = 50
        '
        'rwValvFdvB
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwValvFdvB.DefaultCellStyle = DataGridViewCellStyle13
        Me.rwValvFdvB.HeaderText = "ValvFdvB"
        Me.rwValvFdvB.Name = "rwValvFdvB"
        Me.rwValvFdvB.ReadOnly = True
        Me.rwValvFdvB.Width = 50
        '
        'rwPresHomoEntr
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwPresHomoEntr.DefaultCellStyle = DataGridViewCellStyle14
        Me.rwPresHomoEntr.HeaderText = "PresHomoEntr"
        Me.rwPresHomoEntr.Name = "rwPresHomoEntr"
        Me.rwPresHomoEntr.ReadOnly = True
        Me.rwPresHomoEntr.Width = 50
        '
        'rwPresHomoSaida
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwPresHomoSaida.DefaultCellStyle = DataGridViewCellStyle15
        Me.rwPresHomoSaida.HeaderText = "PresHomoSaida"
        Me.rwPresHomoSaida.Name = "rwPresHomoSaida"
        Me.rwPresHomoSaida.ReadOnly = True
        Me.rwPresHomoSaida.Width = 50
        '
        'rwAgAlcoolTemp
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rwAgAlcoolTemp.DefaultCellStyle = DataGridViewCellStyle16
        Me.rwAgAlcoolTemp.HeaderText = "Agua Alcool TºC"
        Me.rwAgAlcoolTemp.Name = "rwAgAlcoolTemp"
        Me.rwAgAlcoolTemp.ReadOnly = True
        Me.rwAgAlcoolTemp.Width = 50
        '
        'botSair
        '
        Me.botSair.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.botSair.BackColor = System.Drawing.SystemColors.Control
        Me.botSair.Cursor = System.Windows.Forms.Cursors.Default
        Me.botSair.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botSair.ForeColor = System.Drawing.SystemColors.ControlText
        Me.botSair.Image = CType(resources.GetObject("botSair.Image"), System.Drawing.Image)
        Me.botSair.Location = New System.Drawing.Point(795, 168)
        Me.botSair.Name = "botSair"
        Me.botSair.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.botSair.Size = New System.Drawing.Size(65, 41)
        Me.botSair.TabIndex = 25
        Me.botSair.Text = "Fechar"
        Me.botSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.botSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.botSair.UseVisualStyleBackColor = False
        '
        'tmrPoll
        '
        Me.tmrPoll.Interval = 1000
        '
        'txtContaD
        '
        Me.txtContaD.AcceptsReturn = True
        Me.txtContaD.BackColor = System.Drawing.SystemColors.Window
        Me.txtContaD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContaD.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContaD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContaD.Location = New System.Drawing.Point(240, 176)
        Me.txtContaD.MaxLength = 0
        Me.txtContaD.Name = "txtContaD"
        Me.txtContaD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContaD.Size = New System.Drawing.Size(201, 20)
        Me.txtContaD.TabIndex = 28
        Me.txtContaD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmKbPastGrava
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 221)
        Me.Controls.Add(Me.txtContaD)
        Me.Controls.Add(Me.txtDataHora)
        Me.Controls.Add(Me.grdItens)
        Me.Controls.Add(Me.botSair)
        Me.Name = "frmKbPastGrava"
        Me.Text = "PastGrava"
        CType(Me.grdItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtDataHora As System.Windows.Forms.TextBox
    Friend WithEvents grdItens As System.Windows.Forms.DataGridView
    Public WithEvents botSair As System.Windows.Forms.Button
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer
    Friend WithEvents rwPast As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwSts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwRecNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwTqOrig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwTqDest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwPressaoEst1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwPressaoEst2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwTempFdvPv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwTempFdvSp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwTempSaidaProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwPresSaidaProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwValvFdvA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwValvFdvB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwPresHomoEntr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwPresHomoSaida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwAgAlcoolTemp As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents txtContaD As System.Windows.Forms.TextBox

End Class
