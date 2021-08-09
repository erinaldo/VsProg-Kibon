<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIfRelat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIfRelat))
        Me.ToolStripRelat = New System.Windows.Forms.ToolStrip()
        Me.MenuStripRelat = New System.Windows.Forms.MenuStrip()
        Me.butMaq = New System.Windows.Forms.ToolStripMenuItem()
        Me.butDescr = New System.Windows.Forms.ToolStripMenuItem()
        Me.butProd = New System.Windows.Forms.ToolStripMenuItem()
        Me.butProd2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.butDados = New System.Windows.Forms.ToolStripMenuItem()
        Me.butDadosBas = New System.Windows.Forms.ToolStripMenuItem()
        Me.butConf = New System.Windows.Forms.ToolStripMenuItem()
        Me.butConfCont = New System.Windows.Forms.ToolStripMenuItem()
        Me.butContZonPlus = New System.Windows.Forms.ToolStripMenuItem()
        Me.butContZonGood = New System.Windows.Forms.ToolStripMenuItem()
        Me.butContZonMinus = New System.Windows.Forms.ToolStripMenuItem()
        Me.butConfClass = New System.Windows.Forms.ToolStripMenuItem()
        Me.butConfDesl = New System.Windows.Forms.ToolStripMenuItem()
        Me.butEstat = New System.Windows.Forms.ToolStripMenuItem()
        Me.butEstatInterAtu = New System.Windows.Forms.ToolStripMenuItem()
        Me.butEstatUltInter = New System.Windows.Forms.ToolStripMenuItem()
        Me.butEstatBatchAtu = New System.Windows.Forms.ToolStripMenuItem()
        Me.butEstatUltBatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.butEstatTot = New System.Windows.Forms.ToolStripMenuItem()
        Me.butHistor = New System.Windows.Forms.ToolStripMenuItem()
        Me.butRelat = New System.Windows.Forms.ToolStripMenuItem()
        Me.butRejInterAtu = New System.Windows.Forms.ToolStripMenuItem()
        Me.butRejUltInter = New System.Windows.Forms.ToolStripMenuItem()
        Me.butRejBatchAtu = New System.Windows.Forms.ToolStripMenuItem()
        Me.butUltBatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.butRejTot = New System.Windows.Forms.ToolStripMenuItem()
        Me.butRelatFinal = New System.Windows.Forms.ToolStripMenuItem()
        Me.Navegacao = New MDIWindowManager.WindowManagerPanel()
        Me.StatusStripIfRelat = New System.Windows.Forms.StatusStrip()
        Me.MenuStripRelat.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripRelat
        '
        Me.ToolStripRelat.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripRelat.Name = "ToolStripRelat"
        Me.ToolStripRelat.Size = New System.Drawing.Size(1067, 25)
        Me.ToolStripRelat.TabIndex = 2
        Me.ToolStripRelat.Text = "ToolStrip1"
        '
        'MenuStripRelat
        '
        Me.MenuStripRelat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butMaq, Me.butConf, Me.butEstat, Me.butHistor, Me.butRelat})
        Me.MenuStripRelat.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripRelat.Name = "MenuStripRelat"
        Me.MenuStripRelat.Size = New System.Drawing.Size(1067, 24)
        Me.MenuStripRelat.TabIndex = 3
        Me.MenuStripRelat.Text = "MenuStrip1"
        '
        'butMaq
        '
        Me.butMaq.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butDescr, Me.butProd})
        Me.butMaq.Name = "butMaq"
        Me.butMaq.Size = New System.Drawing.Size(66, 20)
        Me.butMaq.Text = "Máquina"
        '
        'butDescr
        '
        Me.butDescr.Name = "butDescr"
        Me.butDescr.Size = New System.Drawing.Size(125, 22)
        Me.butDescr.Text = "Descrição"
        '
        'butProd
        '
        Me.butProd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butProd2, Me.butDados, Me.butDadosBas})
        Me.butProd.Name = "butProd"
        Me.butProd.Size = New System.Drawing.Size(125, 22)
        Me.butProd.Text = "Produto"
        '
        'butProd2
        '
        Me.butProd2.Name = "butProd2"
        Me.butProd2.Size = New System.Drawing.Size(226, 22)
        Me.butProd2.Text = "Produtos"
        '
        'butDados
        '
        Me.butDados.Name = "butDados"
        Me.butDados.Size = New System.Drawing.Size(226, 22)
        Me.butDados.Text = "Dados Produto Ativo"
        '
        'butDadosBas
        '
        Me.butDadosBas.Name = "butDadosBas"
        Me.butDadosBas.Size = New System.Drawing.Size(226, 22)
        Me.butDadosBas.Text = "Dados Básicos Produto Ativo"
        '
        'butConf
        '
        Me.butConf.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butConfCont, Me.butConfClass, Me.butConfDesl})
        Me.butConf.Name = "butConf"
        Me.butConf.Size = New System.Drawing.Size(91, 20)
        Me.butConf.Text = "Configuração"
        '
        'butConfCont
        '
        Me.butConfCont.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butContZonPlus, Me.butContZonGood, Me.butContZonMinus})
        Me.butConfCont.Name = "butConfCont"
        Me.butConfCont.Size = New System.Drawing.Size(202, 22)
        Me.butConfCont.Text = "Contadores"
        '
        'butContZonPlus
        '
        Me.butContZonPlus.Name = "butContZonPlus"
        Me.butContZonPlus.Size = New System.Drawing.Size(141, 22)
        Me.butContZonPlus.Text = "Zona PLUS"
        '
        'butContZonGood
        '
        Me.butContZonGood.Name = "butContZonGood"
        Me.butContZonGood.Size = New System.Drawing.Size(141, 22)
        Me.butContZonGood.Text = "Zona GOOD"
        '
        'butContZonMinus
        '
        Me.butContZonMinus.Name = "butContZonMinus"
        Me.butContZonMinus.Size = New System.Drawing.Size(141, 22)
        Me.butContZonMinus.Text = "Zona MINUS"
        '
        'butConfClass
        '
        Me.butConfClass.Name = "butConfClass"
        Me.butConfClass.Size = New System.Drawing.Size(202, 22)
        Me.butConfClass.Text = "Zonas de Classificação"
        '
        'butConfDesl
        '
        Me.butConfDesl.Name = "butConfDesl"
        Me.butConfDesl.Size = New System.Drawing.Size(202, 22)
        Me.butConfDesl.Text = "Limites de Deslizamento"
        '
        'butEstat
        '
        Me.butEstat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butEstatInterAtu, Me.butEstatUltInter, Me.butEstatBatchAtu, Me.butEstatUltBatch, Me.butEstatTot})
        Me.butEstat.Name = "butEstat"
        Me.butEstat.Size = New System.Drawing.Size(76, 20)
        Me.butEstat.Text = "Estatísticas"
        '
        'butEstatInterAtu
        '
        Me.butEstatInterAtu.Name = "butEstatInterAtu"
        Me.butEstatInterAtu.Size = New System.Drawing.Size(159, 22)
        Me.butEstatInterAtu.Text = "Intervalo Atual"
        '
        'butEstatUltInter
        '
        Me.butEstatUltInter.Name = "butEstatUltInter"
        Me.butEstatUltInter.Size = New System.Drawing.Size(159, 22)
        Me.butEstatUltInter.Text = "Último Intervalo"
        '
        'butEstatBatchAtu
        '
        Me.butEstatBatchAtu.Name = "butEstatBatchAtu"
        Me.butEstatBatchAtu.Size = New System.Drawing.Size(159, 22)
        Me.butEstatBatchAtu.Text = "Batch Atual"
        '
        'butEstatUltBatch
        '
        Me.butEstatUltBatch.Name = "butEstatUltBatch"
        Me.butEstatUltBatch.Size = New System.Drawing.Size(159, 22)
        Me.butEstatUltBatch.Text = "Último Batch"
        '
        'butEstatTot
        '
        Me.butEstatTot.Name = "butEstatTot"
        Me.butEstatTot.Size = New System.Drawing.Size(159, 22)
        Me.butEstatTot.Text = "Total"
        '
        'butHistor
        '
        Me.butHistor.Name = "butHistor"
        Me.butHistor.Size = New System.Drawing.Size(67, 20)
        Me.butHistor.Text = "Histórico"
        '
        'butRelat
        '
        Me.butRelat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butRejInterAtu, Me.butRejUltInter, Me.butRejBatchAtu, Me.butUltBatch, Me.butRejTot, Me.butRelatFinal})
        Me.butRelat.Name = "butRelat"
        Me.butRelat.Size = New System.Drawing.Size(66, 20)
        Me.butRelat.Text = "Relatório"
        '
        'butRejInterAtu
        '
        Me.butRejInterAtu.Name = "butRejInterAtu"
        Me.butRejInterAtu.Size = New System.Drawing.Size(159, 22)
        Me.butRejInterAtu.Text = "Intervalo Atual"
        '
        'butRejUltInter
        '
        Me.butRejUltInter.Name = "butRejUltInter"
        Me.butRejUltInter.Size = New System.Drawing.Size(159, 22)
        Me.butRejUltInter.Text = "Último Intervalo"
        '
        'butRejBatchAtu
        '
        Me.butRejBatchAtu.Name = "butRejBatchAtu"
        Me.butRejBatchAtu.Size = New System.Drawing.Size(159, 22)
        Me.butRejBatchAtu.Text = "Batch Atual"
        '
        'butUltBatch
        '
        Me.butUltBatch.Name = "butUltBatch"
        Me.butUltBatch.Size = New System.Drawing.Size(159, 22)
        Me.butUltBatch.Text = "Último Batch"
        '
        'butRejTot
        '
        Me.butRejTot.Name = "butRejTot"
        Me.butRejTot.Size = New System.Drawing.Size(159, 22)
        Me.butRejTot.Text = "Total"
        '
        'butRelatFinal
        '
        Me.butRelatFinal.Name = "butRelatFinal"
        Me.butRelatFinal.Size = New System.Drawing.Size(159, 22)
        Me.butRelatFinal.Text = "Relatório Final"
        '
        'Navegacao
        '
        Me.Navegacao.AllowUserVerticalRepositioning = False
        Me.Navegacao.AutoDetectMdiChildWindows = True
        Me.Navegacao.AutoHide = False
        Me.Navegacao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Navegacao.ButtonRenderMode = MDIWindowManager.ButtonRenderMode.Standard
        Me.Navegacao.DisableCloseAction = False
        Me.Navegacao.DisableHTileAction = False
        Me.Navegacao.DisablePopoutAction = False
        Me.Navegacao.DisableTileAction = False
        Me.Navegacao.EnableTabPaintEvent = False
        Me.Navegacao.Location = New System.Drawing.Point(2, 51)
        Me.Navegacao.MinMode = False
        Me.Navegacao.Name = "Navegacao"
        Me.Navegacao.Orientation = MDIWindowManager.WindowManagerOrientation.Top
        Me.Navegacao.ShowCloseButton = True
        Me.Navegacao.ShowIcons = True
        Me.Navegacao.ShowLayoutButtons = True
        Me.Navegacao.ShowTitle = False
        Me.Navegacao.Size = New System.Drawing.Size(1063, 40)
        Me.Navegacao.Style = MDIWindowManager.TabStyle.ModernTabs
        Me.Navegacao.TabIndex = 20
        Me.Navegacao.TabRenderMode = MDIWindowManager.TabsProvider.Standard
        Me.Navegacao.Text = "Royal Canin Descalvado - Navegação"
        Me.Navegacao.TitleBackColor = System.Drawing.SystemColors.ControlDark
        Me.Navegacao.TitleForeColor = System.Drawing.SystemColors.ControlLightLight
        '
        'StatusStripIfRelat
        '
        Me.StatusStripIfRelat.Location = New System.Drawing.Point(0, 540)
        Me.StatusStripIfRelat.Name = "StatusStripIfRelat"
        Me.StatusStripIfRelat.Size = New System.Drawing.Size(1067, 22)
        Me.StatusStripIfRelat.TabIndex = 21
        Me.StatusStripIfRelat.Text = "StatusStrip1"
        '
        'frmIfRelat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 562)
        Me.Controls.Add(Me.StatusStripIfRelat)
        Me.Controls.Add(Me.Navegacao)
        Me.Controls.Add(Me.ToolStripRelat)
        Me.Controls.Add(Me.MenuStripRelat)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStripRelat
        Me.Name = "frmIfRelat"
        Me.Text = "Relatório Chekweigher Toledo"
        Me.MenuStripRelat.ResumeLayout(False)
        Me.MenuStripRelat.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripRelat As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStripRelat As System.Windows.Forms.MenuStrip
    Friend WithEvents butConf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butEstat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butEstatInterAtu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butEstatUltInter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butEstatBatchAtu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butEstatUltBatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butEstatTot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRelat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRejInterAtu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRejUltInter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRejBatchAtu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butUltBatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRejTot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butHistor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butConfCont As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butContZonPlus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butContZonGood As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butContZonMinus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butConfClass As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butConfDesl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Navegacao As MDIWindowManager.WindowManagerPanel
    Friend WithEvents butMaq As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butDescr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butProd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butDados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butDadosBas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butProd2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRelatFinal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStripIfRelat As System.Windows.Forms.StatusStrip

End Class
