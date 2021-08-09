<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIfCad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIfCad))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InícioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.CIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRotas = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadCfg = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadPtoCr = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadPerg = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuáriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadUserSeg = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.ToolStripButton()
        Me.btnCadRotas = New System.Windows.Forms.ToolStripButton()
        Me.btnSair = New System.Windows.Forms.ToolStripButton()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCadCfg = New System.Windows.Forms.ToolStripButton()
        Me.btnCadRotasPtCritico = New System.Windows.Forms.ToolStripButton()
        Me.btnCadPtoCr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCadUser = New System.Windows.Forms.ToolStripButton()
        Me.btnCadUserSeg = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InícioToolStripMenuItem, Me.CIPToolStripMenuItem, Me.CadastroToolStripMenuItem, Me.UsuáriosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(849, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InícioToolStripMenuItem
        '
        Me.InícioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuLogin})
        Me.InícioToolStripMenuItem.Name = "InícioToolStripMenuItem"
        Me.InícioToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.InícioToolStripMenuItem.Text = "Início"
        '
        'menuLogin
        '
        Me.menuLogin.Name = "menuLogin"
        Me.menuLogin.Size = New System.Drawing.Size(99, 22)
        Me.menuLogin.Text = "Login"
        '
        'CIPToolStripMenuItem
        '
        Me.CIPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRotas})
        Me.CIPToolStripMenuItem.Name = "CIPToolStripMenuItem"
        Me.CIPToolStripMenuItem.Size = New System.Drawing.Size(36, 20)
        Me.CIPToolStripMenuItem.Text = "CIP"
        Me.CIPToolStripMenuItem.Visible = False
        '
        'menuRotas
        '
        Me.menuRotas.Name = "menuRotas"
        Me.menuRotas.Size = New System.Drawing.Size(152, 22)
        Me.menuRotas.Text = "Rotas"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuCadCfg, Me.menuCadPtoCr, Me.menuCadPerg})
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.CadastroToolStripMenuItem.Text = "Cadastro"
        Me.CadastroToolStripMenuItem.Visible = False
        '
        'menuCadCfg
        '
        Me.menuCadCfg.Name = "menuCadCfg"
        Me.menuCadCfg.Size = New System.Drawing.Size(152, 22)
        Me.menuCadCfg.Text = "Parâmetros"
        '
        'menuCadPtoCr
        '
        Me.menuCadPtoCr.Name = "menuCadPtoCr"
        Me.menuCadPtoCr.Size = New System.Drawing.Size(152, 22)
        Me.menuCadPtoCr.Text = "Pontos Críticos"
        '
        'menuCadPerg
        '
        Me.menuCadPerg.Name = "menuCadPerg"
        Me.menuCadPerg.Size = New System.Drawing.Size(152, 22)
        Me.menuCadPerg.Text = "Perguntas"
        '
        'UsuáriosToolStripMenuItem
        '
        Me.UsuáriosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuCadUser, Me.menuCadUserSeg})
        Me.UsuáriosToolStripMenuItem.Name = "UsuáriosToolStripMenuItem"
        Me.UsuáriosToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.UsuáriosToolStripMenuItem.Text = "Usuários"
        '
        'menuCadUser
        '
        Me.menuCadUser.Name = "menuCadUser"
        Me.menuCadUser.Size = New System.Drawing.Size(176, 22)
        Me.menuCadUser.Text = "Cadastro de usuários"
        '
        'menuCadUserSeg
        '
        Me.menuCadUserSeg.Name = "menuCadUserSeg"
        Me.menuCadUserSeg.Size = New System.Drawing.Size(176, 22)
        Me.menuCadUserSeg.Text = "Áreas de segurança"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 441)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(849, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(51, 17)
        Me.ToolStripStatusLabel1.Text = "Usuário:"
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(49, 446)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(0, 13)
        Me.lblUser.TabIndex = 4
        '
        'btnLogin
        '
        Me.btnLogin.AutoSize = False
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(60, 50)
        Me.btnLogin.Text = "Login"
        Me.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLogin.ToolTipText = "Login"
        '
        'btnCadRotas
        '
        Me.btnCadRotas.AutoSize = False
        Me.btnCadRotas.Image = CType(resources.GetObject("btnCadRotas.Image"), System.Drawing.Image)
        Me.btnCadRotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCadRotas.Name = "btnCadRotas"
        Me.btnCadRotas.Size = New System.Drawing.Size(60, 50)
        Me.btnCadRotas.Text = "Rotas"
        Me.btnCadRotas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCadRotas.ToolTipText = "Cadastro de Clientes"
        Me.btnCadRotas.Visible = False
        '
        'btnSair
        '
        Me.btnSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSair.AutoSize = False
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(60, 50)
        Me.btnSair.Text = "Sair"
        Me.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSair.ToolTipText = "Sair"
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLogin, Me.btnSair, Me.ToolStripSeparator4, Me.btnCadRotas, Me.ToolStripSeparator3, Me.btnCadCfg, Me.btnCadRotasPtCritico, Me.btnCadPtoCr, Me.ToolStripSeparator1, Me.btnCadUser, Me.btnCadUserSeg})
        Me.tsMain.Location = New System.Drawing.Point(0, 24)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(849, 53)
        Me.tsMain.TabIndex = 1
        Me.tsMain.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 53)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 53)
        Me.ToolStripSeparator3.Visible = False
        '
        'btnCadCfg
        '
        Me.btnCadCfg.AutoSize = False
        Me.btnCadCfg.Image = CType(resources.GetObject("btnCadCfg.Image"), System.Drawing.Image)
        Me.btnCadCfg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCadCfg.Name = "btnCadCfg"
        Me.btnCadCfg.Size = New System.Drawing.Size(60, 50)
        Me.btnCadCfg.Text = "Parâm."
        Me.btnCadCfg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCadCfg.ToolTipText = "Cadastro de Parâmetros"
        Me.btnCadCfg.Visible = False
        '
        'btnCadRotasPtCritico
        '
        Me.btnCadRotasPtCritico.AutoSize = False
        Me.btnCadRotasPtCritico.Image = CType(resources.GetObject("btnCadRotasPtCritico.Image"), System.Drawing.Image)
        Me.btnCadRotasPtCritico.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCadRotasPtCritico.Name = "btnCadRotasPtCritico"
        Me.btnCadRotasPtCritico.Size = New System.Drawing.Size(60, 50)
        Me.btnCadRotasPtCritico.Text = "Rta Pto. C"
        Me.btnCadRotasPtCritico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCadRotasPtCritico.ToolTipText = "Lista de Itens da Área"
        Me.btnCadRotasPtCritico.Visible = False
        '
        'btnCadPtoCr
        '
        Me.btnCadPtoCr.AutoSize = False
        Me.btnCadPtoCr.Image = CType(resources.GetObject("btnCadPtoCr.Image"), System.Drawing.Image)
        Me.btnCadPtoCr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCadPtoCr.Name = "btnCadPtoCr"
        Me.btnCadPtoCr.Size = New System.Drawing.Size(60, 50)
        Me.btnCadPtoCr.Text = "Perguntas"
        Me.btnCadPtoCr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCadPtoCr.ToolTipText = "Cadastro de Parâmetros"
        Me.btnCadPtoCr.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 53)
        Me.ToolStripSeparator1.Visible = False
        '
        'btnCadUser
        '
        Me.btnCadUser.AutoSize = False
        Me.btnCadUser.Image = CType(resources.GetObject("btnCadUser.Image"), System.Drawing.Image)
        Me.btnCadUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCadUser.Name = "btnCadUser"
        Me.btnCadUser.Size = New System.Drawing.Size(60, 50)
        Me.btnCadUser.Text = "Usuários"
        Me.btnCadUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCadUser.ToolTipText = "Cadastro de Usuários"
        '
        'btnCadUserSeg
        '
        Me.btnCadUserSeg.AutoSize = False
        Me.btnCadUserSeg.Image = CType(resources.GetObject("btnCadUserSeg.Image"), System.Drawing.Image)
        Me.btnCadUserSeg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCadUserSeg.Name = "btnCadUserSeg"
        Me.btnCadUserSeg.Size = New System.Drawing.Size(60, 50)
        Me.btnCadUserSeg.Text = "Áreas Seg."
        Me.btnCadUserSeg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCadUserSeg.ToolTipText = "Cadastro de Áreas de Segurança"
        '
        'frmIfCad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 463)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmIfCad"
        Me.Text = "Cadastro"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents InícioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRotas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCadCfg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCadPerg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuáriosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCadUserSeg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents menuCadUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLogin As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCadRotas As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCadCfg As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCadUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCadUserSeg As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCadPtoCr As System.Windows.Forms.ToolStripButton
    Public WithEvents btnCadRotasPtCritico As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCadPtoCr As System.Windows.Forms.ToolStripMenuItem
End Class
