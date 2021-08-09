<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIfCip
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIfCip))
        Me.lblUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPollSts = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPollConta = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butLogin = New System.Windows.Forms.ToolStripButton()
        Me.butCipProg = New System.Windows.Forms.ToolStripButton()
        Me.butCipCorr = New System.Windows.Forms.ToolStripButton()
        Me.butCipFim = New System.Windows.Forms.ToolStripButton()
        Me.butRelat = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.butCipSchedPer = New System.Windows.Forms.ToolStripButton()
        Me.butCadastro = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.butSenha = New System.Windows.Forms.ToolStripButton()
        Me.butUser = New System.Windows.Forms.ToolStripButton()
        Me.butFechar = New System.Windows.Forms.ToolStripButton()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.IniciarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFechar = New System.Windows.Forms.ToolStripMenuItem()
        Me.CIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCipProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCipCorr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCipFim = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRelat = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCipSchedPer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCadastro = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSenha = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUser
        '
        Me.lblUser.AutoSize = False
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(111, 17)
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblUser, Me.ToolStripStatusLabel2, Me.lblPollSts, Me.ToolStripStatusLabel3, Me.lblPollConta})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 424)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1186, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(56, 17)
        Me.ToolStripStatusLabel1.Text = "Usuário:  "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel2.Text = "Poll Sts"
        Me.ToolStripStatusLabel2.Visible = False
        '
        'lblPollSts
        '
        Me.lblPollSts.Name = "lblPollSts"
        Me.lblPollSts.Size = New System.Drawing.Size(82, 17)
        Me.lblPollSts.Text = "Desconectado"
        Me.lblPollSts.Visible = False
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel3.Text = "PollConta"
        Me.ToolStripStatusLabel3.Visible = False
        '
        'lblPollConta
        '
        Me.lblPollConta.Name = "lblPollConta"
        Me.lblPollConta.Size = New System.Drawing.Size(13, 17)
        Me.lblPollConta.Text = "0"
        Me.lblPollConta.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 53)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butLogin, Me.ToolStripSeparator1, Me.butCipProg, Me.butCipCorr, Me.butCipFim, Me.butRelat, Me.ToolStripSeparator4, Me.butCipSchedPer, Me.butCadastro, Me.ToolStripSeparator3, Me.butSenha, Me.butUser, Me.butFechar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1186, 53)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butLogin
        '
        Me.butLogin.AutoSize = False
        Me.butLogin.Image = CType(resources.GetObject("butLogin.Image"), System.Drawing.Image)
        Me.butLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butLogin.Name = "butLogin"
        Me.butLogin.Size = New System.Drawing.Size(60, 50)
        Me.butLogin.Text = "Login"
        Me.butLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'butCipProg
        '
        Me.butCipProg.AutoSize = False
        Me.butCipProg.Image = CType(resources.GetObject("butCipProg.Image"), System.Drawing.Image)
        Me.butCipProg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCipProg.Name = "butCipProg"
        Me.butCipProg.Size = New System.Drawing.Size(60, 50)
        Me.butCipProg.Text = "Programa"
        Me.butCipProg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCipProg.ToolTipText = "CIPs programados"
        '
        'butCipCorr
        '
        Me.butCipCorr.AutoSize = False
        Me.butCipCorr.Image = CType(resources.GetObject("butCipCorr.Image"), System.Drawing.Image)
        Me.butCipCorr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCipCorr.Name = "butCipCorr"
        Me.butCipCorr.Size = New System.Drawing.Size(60, 50)
        Me.butCipCorr.Text = "Corrente"
        Me.butCipCorr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCipCorr.ToolTipText = "CIPs em execução"
        '
        'butCipFim
        '
        Me.butCipFim.AutoSize = False
        Me.butCipFim.Image = CType(resources.GetObject("butCipFim.Image"), System.Drawing.Image)
        Me.butCipFim.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCipFim.Name = "butCipFim"
        Me.butCipFim.Size = New System.Drawing.Size(60, 50)
        Me.butCipFim.Text = "Valida CIP"
        Me.butCipFim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCipFim.ToolTipText = "Validação de CIPs"
        '
        'butRelat
        '
        Me.butRelat.Image = CType(resources.GetObject("butRelat.Image"), System.Drawing.Image)
        Me.butRelat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butRelat.Name = "butRelat"
        Me.butRelat.Size = New System.Drawing.Size(63, 50)
        Me.butRelat.Text = "Relatórios"
        Me.butRelat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butRelat.ToolTipText = "Relatórios"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 53)
        '
        'butCipSchedPer
        '
        Me.butCipSchedPer.AutoSize = False
        Me.butCipSchedPer.Image = CType(resources.GetObject("butCipSchedPer.Image"), System.Drawing.Image)
        Me.butCipSchedPer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCipSchedPer.Name = "butCipSchedPer"
        Me.butCipSchedPer.Size = New System.Drawing.Size(60, 50)
        Me.butCipSchedPer.Text = "Periódico"
        Me.butCipSchedPer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCipSchedPer.ToolTipText = "Programação periódica de CIPs"
        '
        'butCadastro
        '
        Me.butCadastro.AutoSize = False
        Me.butCadastro.Image = CType(resources.GetObject("butCadastro.Image"), System.Drawing.Image)
        Me.butCadastro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCadastro.Name = "butCadastro"
        Me.butCadastro.Size = New System.Drawing.Size(60, 50)
        Me.butCadastro.Text = "Cadastro"
        Me.butCadastro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butCadastro.ToolTipText = "Abre cadastro"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 53)
        '
        'butSenha
        '
        Me.butSenha.AutoSize = False
        Me.butSenha.Image = CType(resources.GetObject("butSenha.Image"), System.Drawing.Image)
        Me.butSenha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSenha.Name = "butSenha"
        Me.butSenha.Size = New System.Drawing.Size(71, 50)
        Me.butSenha.Text = "Troca Senha"
        Me.butSenha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butSenha.ToolTipText = "Trocar senha do usuário logado"
        '
        'butUser
        '
        Me.butUser.AutoSize = False
        Me.butUser.Image = Global.IfCip.My.Resources.Resources.Bot16x16Usuario
        Me.butUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butUser.Name = "butUser"
        Me.butUser.Size = New System.Drawing.Size(71, 50)
        Me.butUser.Text = "Usuários"
        Me.butUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butUser.ToolTipText = "Trocar senha do usuário logado"
        '
        'butFechar
        '
        Me.butFechar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.butFechar.AutoSize = False
        Me.butFechar.Image = CType(resources.GetObject("butFechar.Image"), System.Drawing.Image)
        Me.butFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butFechar.Name = "butFechar"
        Me.butFechar.Size = New System.Drawing.Size(60, 50)
        Me.butFechar.Text = "Sair"
        Me.butFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 151)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IniciarToolStripMenuItem, Me.CIPToolStripMenuItem, Me.ConfiguraçãoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1186, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'IniciarToolStripMenuItem
        '
        Me.IniciarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogin, Me.ToolStripSeparator2, Me.mnuFechar})
        Me.IniciarToolStripMenuItem.Name = "IniciarToolStripMenuItem"
        Me.IniciarToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.IniciarToolStripMenuItem.Text = "Iniciar"
        '
        'mnuLogin
        '
        Me.mnuLogin.Image = CType(resources.GetObject("mnuLogin.Image"), System.Drawing.Image)
        Me.mnuLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuLogin.Name = "mnuLogin"
        Me.mnuLogin.Size = New System.Drawing.Size(104, 22)
        Me.mnuLogin.Text = "Login"
        Me.mnuLogin.ToolTipText = "Login"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(101, 6)
        '
        'mnuFechar
        '
        Me.mnuFechar.Image = CType(resources.GetObject("mnuFechar.Image"), System.Drawing.Image)
        Me.mnuFechar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFechar.Name = "mnuFechar"
        Me.mnuFechar.Size = New System.Drawing.Size(104, 22)
        Me.mnuFechar.Text = "Sair"
        Me.mnuFechar.ToolTipText = "Sair"
        '
        'CIPToolStripMenuItem
        '
        Me.CIPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCipProg, Me.mnuCipCorr, Me.mnuCipFim, Me.mnuRelat})
        Me.CIPToolStripMenuItem.Name = "CIPToolStripMenuItem"
        Me.CIPToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.CIPToolStripMenuItem.Text = "CIP"
        '
        'mnuCipProg
        '
        Me.mnuCipProg.Image = CType(resources.GetObject("mnuCipProg.Image"), System.Drawing.Image)
        Me.mnuCipProg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCipProg.Name = "mnuCipProg"
        Me.mnuCipProg.Size = New System.Drawing.Size(132, 22)
        Me.mnuCipProg.Text = "Programa"
        Me.mnuCipProg.ToolTipText = "CIPs programados"
        '
        'mnuCipCorr
        '
        Me.mnuCipCorr.Image = CType(resources.GetObject("mnuCipCorr.Image"), System.Drawing.Image)
        Me.mnuCipCorr.Name = "mnuCipCorr"
        Me.mnuCipCorr.Size = New System.Drawing.Size(132, 22)
        Me.mnuCipCorr.Text = "Comandos"
        Me.mnuCipCorr.ToolTipText = "CIPs em execução"
        '
        'mnuCipFim
        '
        Me.mnuCipFim.Image = CType(resources.GetObject("mnuCipFim.Image"), System.Drawing.Image)
        Me.mnuCipFim.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCipFim.Name = "mnuCipFim"
        Me.mnuCipFim.Size = New System.Drawing.Size(132, 22)
        Me.mnuCipFim.Text = "Valida CIP"
        Me.mnuCipFim.ToolTipText = "Validação de CIPs"
        '
        'mnuRelat
        '
        Me.mnuRelat.Image = CType(resources.GetObject("mnuRelat.Image"), System.Drawing.Image)
        Me.mnuRelat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuRelat.Name = "mnuRelat"
        Me.mnuRelat.Size = New System.Drawing.Size(132, 22)
        Me.mnuRelat.Text = "Relatórios"
        Me.mnuRelat.ToolTipText = "Relatórios"
        '
        'ConfiguraçãoToolStripMenuItem
        '
        Me.ConfiguraçãoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCipSchedPer, Me.mnuCadastro, Me.ToolStripSeparator5, Me.mnuSenha, Me.mnuUsuarios})
        Me.ConfiguraçãoToolStripMenuItem.Name = "ConfiguraçãoToolStripMenuItem"
        Me.ConfiguraçãoToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.ConfiguraçãoToolStripMenuItem.Text = "Configuração"
        '
        'mnuCipSchedPer
        '
        Me.mnuCipSchedPer.Image = CType(resources.GetObject("mnuCipSchedPer.Image"), System.Drawing.Image)
        Me.mnuCipSchedPer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCipSchedPer.Name = "mnuCipSchedPer"
        Me.mnuCipSchedPer.Size = New System.Drawing.Size(152, 22)
        Me.mnuCipSchedPer.Text = "Preiódico"
        Me.mnuCipSchedPer.ToolTipText = "Programação periódica de CIPs"
        '
        'mnuCadastro
        '
        Me.mnuCadastro.Image = CType(resources.GetObject("mnuCadastro.Image"), System.Drawing.Image)
        Me.mnuCadastro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCadastro.Name = "mnuCadastro"
        Me.mnuCadastro.Size = New System.Drawing.Size(152, 22)
        Me.mnuCadastro.Text = "Cadastro"
        Me.mnuCadastro.ToolTipText = "Abre cadastro"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(149, 6)
        '
        'mnuSenha
        '
        Me.mnuSenha.Image = CType(resources.GetObject("mnuSenha.Image"), System.Drawing.Image)
        Me.mnuSenha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSenha.Name = "mnuSenha"
        Me.mnuSenha.Size = New System.Drawing.Size(152, 22)
        Me.mnuSenha.Text = "Troca Senha"
        Me.mnuSenha.ToolTipText = "Trocar senha do usuário logado"
        '
        'mnuUsuarios
        '
        Me.mnuUsuarios.Image = Global.IfCip.My.Resources.Resources.Bot16x16Usuario
        Me.mnuUsuarios.Name = "mnuUsuarios"
        Me.mnuUsuarios.Size = New System.Drawing.Size(152, 22)
        Me.mnuUsuarios.Text = "Usuários"
        '
        'frmIfCip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 446)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmIfCip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cip da Kibon Valinhos"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butFechar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butCadastro As System.Windows.Forms.ToolStripButton
    Friend WithEvents butSenha As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butLogin As System.Windows.Forms.ToolStripButton
    Friend WithEvents butCipFim As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butCipCorr As System.Windows.Forms.ToolStripButton
    Friend WithEvents butCipProg As System.Windows.Forms.ToolStripButton
    Friend WithEvents butCipSchedPer As System.Windows.Forms.ToolStripButton
    Friend WithEvents butRelat As System.Windows.Forms.ToolStripButton
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents IniciarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFechar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCipProg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCipCorr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCipFim As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRelat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguraçãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCipSchedPer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCadastro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSenha As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPollSts As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPollConta As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents butUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUsuarios As System.Windows.Forms.ToolStripMenuItem
End Class
