<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.Status1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsVersao = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCadValvulas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCadMotores = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCadSensores = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCadTanques = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCadFlip = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatórioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GerarRelatórioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butLogin = New System.Windows.Forms.ToolStripButton()
        Me.butValvula = New System.Windows.Forms.ToolStripButton()
        Me.butMotor = New System.Windows.Forms.ToolStripButton()
        Me.butPlaca = New System.Windows.Forms.ToolStripButton()
        Me.butTanque = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.butSair = New System.Windows.Forms.ToolStripButton()
        Me.butRotasLim = New System.Windows.Forms.ToolStripButton()
        Me.butRotaPtoCrit = New System.Windows.Forms.ToolStripButton()
        Me.butCadPtoCrit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.butRelatorio = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbCircuito = New System.Windows.Forms.ToolStripComboBox()
        Me.gvRotas = New System.Windows.Forms.DataGridView()
        Me.colRotaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCirc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTQ1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTQ2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTQ3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.butNovaRota = New System.Windows.Forms.ToolStripButton()
        Me.butEditar = New System.Windows.Forms.ToolStripButton()
        Me.butExcluir = New System.Windows.Forms.ToolStripButton()
        Me.butDuplicar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.butUp = New System.Windows.Forms.ToolStripButton()
        Me.butDown = New System.Windows.Forms.ToolStripButton()
        Me.tmrPula = New System.Windows.Forms.Timer(Me.components)
        Me.StatusBar.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gvRotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status1, Me.stsVersao})
        Me.StatusBar.Location = New System.Drawing.Point(0, 616)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(966, 22)
        Me.StatusBar.TabIndex = 0
        '
        'Status1
        '
        Me.Status1.AutoSize = False
        Me.Status1.Name = "Status1"
        Me.Status1.Size = New System.Drawing.Size(350, 17)
        Me.Status1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stsVersao
        '
        Me.stsVersao.AutoSize = False
        Me.stsVersao.Name = "stsVersao"
        Me.stsVersao.Size = New System.Drawing.Size(601, 17)
        Me.stsVersao.Spring = True
        Me.stsVersao.Text = "Ver."
        Me.stsVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem, Me.CadastroToolStripMenuItem, Me.RelatórioToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(966, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'ArquivoToolStripMenuItem
        '
        Me.ArquivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem})
        Me.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        Me.ArquivoToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ArquivoToolStripMenuItem.Text = "&Arquivo"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.SairToolStripMenuItem.Text = "&Sair"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCadValvulas, Me.mnuCadMotores, Me.mnuCadSensores, Me.mnuCadTanques, Me.mnuCadFlip})
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.CadastroToolStripMenuItem.Text = "&Cadastro"
        '
        'mnuCadValvulas
        '
        Me.mnuCadValvulas.Name = "mnuCadValvulas"
        Me.mnuCadValvulas.Size = New System.Drawing.Size(205, 22)
        Me.mnuCadValvulas.Text = "&Valvulas"
        '
        'mnuCadMotores
        '
        Me.mnuCadMotores.Name = "mnuCadMotores"
        Me.mnuCadMotores.Size = New System.Drawing.Size(205, 22)
        Me.mnuCadMotores.Text = "&Motores"
        '
        'mnuCadSensores
        '
        Me.mnuCadSensores.Name = "mnuCadSensores"
        Me.mnuCadSensores.Size = New System.Drawing.Size(205, 22)
        Me.mnuCadSensores.Text = "&Sensores de Placa de Fluxo"
        '
        'mnuCadTanques
        '
        Me.mnuCadTanques.Name = "mnuCadTanques"
        Me.mnuCadTanques.Size = New System.Drawing.Size(205, 22)
        Me.mnuCadTanques.Text = "&Tanques"
        '
        'mnuCadFlip
        '
        Me.mnuCadFlip.Name = "mnuCadFlip"
        Me.mnuCadFlip.Size = New System.Drawing.Size(205, 22)
        Me.mnuCadFlip.Text = "&Flip"
        '
        'RelatórioToolStripMenuItem
        '
        Me.RelatórioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GerarRelatórioToolStripMenuItem})
        Me.RelatórioToolStripMenuItem.Name = "RelatórioToolStripMenuItem"
        Me.RelatórioToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.RelatórioToolStripMenuItem.Text = "&Relatório"
        '
        'GerarRelatórioToolStripMenuItem
        '
        Me.GerarRelatórioToolStripMenuItem.Name = "GerarRelatórioToolStripMenuItem"
        Me.GerarRelatórioToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.GerarRelatórioToolStripMenuItem.Text = "Gerar &Relatório"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butLogin, Me.butValvula, Me.butMotor, Me.butPlaca, Me.butTanque, Me.ToolStripSeparator4, Me.butSair, Me.butRotasLim, Me.butRotaPtoCrit, Me.butCadPtoCrit, Me.ToolStripSeparator3, Me.butRelatorio, Me.ToolStripLabel1, Me.cmbCircuito})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(966, 57)
        Me.ToolStrip1.TabIndex = 2
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
        Me.butLogin.ToolTipText = "Login"
        '
        'butValvula
        '
        Me.butValvula.AutoSize = False
        Me.butValvula.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvula.Image = CType(resources.GetObject("butValvula.Image"), System.Drawing.Image)
        Me.butValvula.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butValvula.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvula.Name = "butValvula"
        Me.butValvula.Size = New System.Drawing.Size(52, 54)
        Me.butValvula.Text = "Cadastro de Valvulas"
        '
        'butMotor
        '
        Me.butMotor.AutoSize = False
        Me.butMotor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butMotor.Image = CType(resources.GetObject("butMotor.Image"), System.Drawing.Image)
        Me.butMotor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butMotor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butMotor.Name = "butMotor"
        Me.butMotor.Size = New System.Drawing.Size(60, 50)
        Me.butMotor.Text = "Cadastro de Bombas"
        '
        'butPlaca
        '
        Me.butPlaca.AutoSize = False
        Me.butPlaca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butPlaca.Image = CType(resources.GetObject("butPlaca.Image"), System.Drawing.Image)
        Me.butPlaca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butPlaca.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butPlaca.Name = "butPlaca"
        Me.butPlaca.Size = New System.Drawing.Size(60, 50)
        Me.butPlaca.Text = "Cadastro Sensores"
        '
        'butTanque
        '
        Me.butTanque.AutoSize = False
        Me.butTanque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butTanque.Image = CType(resources.GetObject("butTanque.Image"), System.Drawing.Image)
        Me.butTanque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butTanque.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butTanque.Name = "butTanque"
        Me.butTanque.Size = New System.Drawing.Size(60, 50)
        Me.butTanque.Text = " "
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 57)
        '
        'butSair
        '
        Me.butSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.butSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butSair.Image = CType(resources.GetObject("butSair.Image"), System.Drawing.Image)
        Me.butSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSair.Name = "butSair"
        Me.butSair.Size = New System.Drawing.Size(52, 54)
        Me.butSair.Text = "Sair"
        '
        'butRotasLim
        '
        Me.butRotasLim.AutoSize = False
        Me.butRotasLim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butRotasLim.Image = Global.KbCipRotas.My.Resources.Resources.message
        Me.butRotasLim.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butRotasLim.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butRotasLim.Name = "butRotasLim"
        Me.butRotasLim.Size = New System.Drawing.Size(60, 50)
        Me.butRotasLim.Text = "ToolStripButton1"
        '
        'butRotaPtoCrit
        '
        Me.butRotaPtoCrit.AutoSize = False
        Me.butRotaPtoCrit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butRotaPtoCrit.Image = Global.KbCipRotas.My.Resources.Resources.question_and_answer
        Me.butRotaPtoCrit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butRotaPtoCrit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butRotaPtoCrit.Name = "butRotaPtoCrit"
        Me.butRotaPtoCrit.Size = New System.Drawing.Size(60, 50)
        Me.butRotaPtoCrit.Text = "ToolStripButton1"
        '
        'butCadPtoCrit
        '
        Me.butCadPtoCrit.AutoSize = False
        Me.butCadPtoCrit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butCadPtoCrit.Image = Global.KbCipRotas.My.Resources.Resources.up_down_question
        Me.butCadPtoCrit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butCadPtoCrit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butCadPtoCrit.Name = "butCadPtoCrit"
        Me.butCadPtoCrit.Size = New System.Drawing.Size(60, 50)
        Me.butCadPtoCrit.Text = "ToolStripButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 57)
        '
        'butRelatorio
        '
        Me.butRelatorio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butRelatorio.Image = CType(resources.GetObject("butRelatorio.Image"), System.Drawing.Image)
        Me.butRelatorio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.butRelatorio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butRelatorio.Name = "butRelatorio"
        Me.butRelatorio.Size = New System.Drawing.Size(52, 54)
        Me.butRelatorio.Text = "Relatório"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 54)
        Me.ToolStripLabel1.Text = "Filtrar Circuito"
        '
        'cmbCircuito
        '
        Me.cmbCircuito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCircuito.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCircuito.MaxDropDownItems = 5
        Me.cmbCircuito.Name = "cmbCircuito"
        Me.cmbCircuito.Size = New System.Drawing.Size(80, 57)
        '
        'gvRotas
        '
        Me.gvRotas.AllowUserToAddRows = False
        Me.gvRotas.AllowUserToDeleteRows = False
        Me.gvRotas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gvRotas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvRotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvRotas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gvRotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvRotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRotaID, Me.colDescr, Me.colCirc, Me.colTipo, Me.colTQ1, Me.colTQ2, Me.colTQ3, Me.colSeq})
        Me.gvRotas.Location = New System.Drawing.Point(44, 84)
        Me.gvRotas.Name = "gvRotas"
        Me.gvRotas.ReadOnly = True
        Me.gvRotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvRotas.Size = New System.Drawing.Size(922, 529)
        Me.gvRotas.TabIndex = 3
        '
        'colRotaID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRotaID.DefaultCellStyle = DataGridViewCellStyle2
        Me.colRotaID.HeaderText = "RotaID"
        Me.colRotaID.Name = "colRotaID"
        Me.colRotaID.ReadOnly = True
        Me.colRotaID.Width = 60
        '
        'colDescr
        '
        Me.colDescr.HeaderText = "Descricao"
        Me.colDescr.Name = "colDescr"
        Me.colDescr.ReadOnly = True
        Me.colDescr.Width = 300
        '
        'colCirc
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCirc.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCirc.HeaderText = "Circuito"
        Me.colCirc.Name = "colCirc"
        Me.colCirc.ReadOnly = True
        Me.colCirc.Width = 50
        '
        'colTipo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTipo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 50
        '
        'colTQ1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTQ1.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTQ1.HeaderText = "Tanque 1"
        Me.colTQ1.Name = "colTQ1"
        Me.colTQ1.ReadOnly = True
        '
        'colTQ2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTQ2.DefaultCellStyle = DataGridViewCellStyle6
        Me.colTQ2.HeaderText = "Tanque 2"
        Me.colTQ2.Name = "colTQ2"
        Me.colTQ2.ReadOnly = True
        '
        'colTQ3
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTQ3.DefaultCellStyle = DataGridViewCellStyle7
        Me.colTQ3.HeaderText = "Tanque 3"
        Me.colTQ3.Name = "colTQ3"
        Me.colTQ3.ReadOnly = True
        '
        'colSeq
        '
        Me.colSeq.HeaderText = "Sequencia"
        Me.colSeq.Name = "colSeq"
        Me.colSeq.ReadOnly = True
        Me.colSeq.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AllowMerge = False
        Me.ToolStrip2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butNovaRota, Me.butEditar, Me.butExcluir, Me.butDuplicar, Me.ToolStripSeparator2, Me.butUp, Me.butDown})
        Me.ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 84)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(41, 273)
        Me.ToolStrip2.TabIndex = 4
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'butNovaRota
        '
        Me.butNovaRota.AutoSize = False
        Me.butNovaRota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butNovaRota.Image = CType(resources.GetObject("butNovaRota.Image"), System.Drawing.Image)
        Me.butNovaRota.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butNovaRota.Name = "butNovaRota"
        Me.butNovaRota.Size = New System.Drawing.Size(40, 40)
        Me.butNovaRota.Text = "Nova Rota"
        '
        'butEditar
        '
        Me.butEditar.AutoSize = False
        Me.butEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEditar.Image = CType(resources.GetObject("butEditar.Image"), System.Drawing.Image)
        Me.butEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEditar.Name = "butEditar"
        Me.butEditar.Size = New System.Drawing.Size(40, 40)
        Me.butEditar.Text = "Edita Rota"
        '
        'butExcluir
        '
        Me.butExcluir.AutoSize = False
        Me.butExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butExcluir.Image = CType(resources.GetObject("butExcluir.Image"), System.Drawing.Image)
        Me.butExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butExcluir.Name = "butExcluir"
        Me.butExcluir.Size = New System.Drawing.Size(40, 40)
        Me.butExcluir.Text = "Apaga Rota"
        '
        'butDuplicar
        '
        Me.butDuplicar.AutoSize = False
        Me.butDuplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butDuplicar.Image = CType(resources.GetObject("butDuplicar.Image"), System.Drawing.Image)
        Me.butDuplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butDuplicar.Name = "butDuplicar"
        Me.butDuplicar.Size = New System.Drawing.Size(40, 40)
        Me.butDuplicar.Text = "Copia Rota"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(39, 6)
        '
        'butUp
        '
        Me.butUp.AutoSize = False
        Me.butUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butUp.Image = CType(resources.GetObject("butUp.Image"), System.Drawing.Image)
        Me.butUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butUp.Name = "butUp"
        Me.butUp.Size = New System.Drawing.Size(40, 40)
        Me.butUp.Text = "Sobe rota"
        '
        'butDown
        '
        Me.butDown.AutoSize = False
        Me.butDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butDown.Image = CType(resources.GetObject("butDown.Image"), System.Drawing.Image)
        Me.butDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butDown.Name = "butDown"
        Me.butDown.Size = New System.Drawing.Size(40, 40)
        Me.butDown.Text = "Desce rota"
        '
        'tmrPula
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 638)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.gvRotas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CIP - Cadastro de Rotas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gvRotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents Status1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCadValvulas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCadMotores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCadSensores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCadTanques As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelatórioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GerarRelatórioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butValvula As System.Windows.Forms.ToolStripButton
    Friend WithEvents butMotor As System.Windows.Forms.ToolStripButton
    Friend WithEvents butPlaca As System.Windows.Forms.ToolStripButton
    Friend WithEvents butTanque As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butRotasLim As System.Windows.Forms.ToolStripButton
    Friend WithEvents butRelatorio As System.Windows.Forms.ToolStripButton
    Friend WithEvents butSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvRotas As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents butNovaRota As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents butDuplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butUp As System.Windows.Forms.ToolStripButton
    Friend WithEvents butDown As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuCadFlip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colRotaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCirc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTQ1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTQ2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTQ3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmrPula As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbCircuito As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents stsVersao As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents butLogin As System.Windows.Forms.ToolStripButton
    Friend WithEvents butCadPtoCrit As System.Windows.Forms.ToolStripButton
    Friend WithEvents butRotaPtoCrit As System.Windows.Forms.ToolStripButton

End Class
