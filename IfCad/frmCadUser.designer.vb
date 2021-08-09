<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadUser))
        Me.tsBarraBotoes = New System.Windows.Forms.ToolStrip()
        Me.btnNovo = New System.Windows.Forms.ToolStripButton()
        Me.btnEdita = New System.Windows.Forms.ToolStripButton()
        Me.btnSalva = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleta = New System.Windows.Forms.ToolStripButton()
        Me.btnTrocaSenha = New System.Windows.Forms.ToolStripButton()
        Me.btnUserHabSeg = New System.Windows.Forms.ToolStripButton()
        Me.btnSair = New System.Windows.Forms.ToolStripButton()
        Me.gvCadUser = New System.Windows.Forms.DataGridView()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsBarraBotoes.SuspendLayout()
        CType(Me.gvCadUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsBarraBotoes
        '
        Me.tsBarraBotoes.Dock = System.Windows.Forms.DockStyle.None
        Me.tsBarraBotoes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNovo, Me.btnEdita, Me.btnSalva, Me.btnDeleta, Me.btnTrocaSenha, Me.btnUserHabSeg, Me.btnSair})
        Me.tsBarraBotoes.Location = New System.Drawing.Point(2, 2)
        Me.tsBarraBotoes.Name = "tsBarraBotoes"
        Me.tsBarraBotoes.Size = New System.Drawing.Size(553, 36)
        Me.tsBarraBotoes.Stretch = True
        Me.tsBarraBotoes.TabIndex = 3
        Me.tsBarraBotoes.Text = "ToolStrip1"
        '
        'btnNovo
        '
        Me.btnNovo.AutoSize = False
        Me.btnNovo.Image = CType(resources.GetObject("btnNovo.Image"), System.Drawing.Image)
        Me.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(70, 33)
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNovo.ToolTipText = "Novo Usuário"
        '
        'btnEdita
        '
        Me.btnEdita.AutoSize = False
        Me.btnEdita.Image = CType(resources.GetObject("btnEdita.Image"), System.Drawing.Image)
        Me.btnEdita.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdita.Name = "btnEdita"
        Me.btnEdita.Size = New System.Drawing.Size(70, 33)
        Me.btnEdita.Text = "Alterar"
        Me.btnEdita.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEdita.ToolTipText = "Alterar Usuário"
        '
        'btnSalva
        '
        Me.btnSalva.AutoSize = False
        Me.btnSalva.Image = CType(resources.GetObject("btnSalva.Image"), System.Drawing.Image)
        Me.btnSalva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(70, 33)
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSalva.ToolTipText = "Gravar alterações"
        '
        'btnDeleta
        '
        Me.btnDeleta.AutoSize = False
        Me.btnDeleta.Image = CType(resources.GetObject("btnDeleta.Image"), System.Drawing.Image)
        Me.btnDeleta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleta.Name = "btnDeleta"
        Me.btnDeleta.Size = New System.Drawing.Size(70, 33)
        Me.btnDeleta.Text = "Remover"
        Me.btnDeleta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDeleta.ToolTipText = "Remover o item selecionado"
        '
        'btnTrocaSenha
        '
        Me.btnTrocaSenha.AutoSize = False
        Me.btnTrocaSenha.Image = CType(resources.GetObject("btnTrocaSenha.Image"), System.Drawing.Image)
        Me.btnTrocaSenha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTrocaSenha.Name = "btnTrocaSenha"
        Me.btnTrocaSenha.Size = New System.Drawing.Size(70, 33)
        Me.btnTrocaSenha.Text = "Troca Senha"
        Me.btnTrocaSenha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnTrocaSenha.ToolTipText = "Troca de Senha"
        '
        'btnUserHabSeg
        '
        Me.btnUserHabSeg.AutoSize = False
        Me.btnUserHabSeg.Image = CType(resources.GetObject("btnUserHabSeg.Image"), System.Drawing.Image)
        Me.btnUserHabSeg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUserHabSeg.Name = "btnUserHabSeg"
        Me.btnUserHabSeg.Size = New System.Drawing.Size(100, 33)
        Me.btnUserHabSeg.Text = "Hab. Segurança"
        Me.btnUserHabSeg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnUserHabSeg.ToolTipText = "Habilitar Segurança"
        '
        'btnSair
        '
        Me.btnSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSair.AutoSize = False
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(60, 33)
        Me.btnSair.Text = "Sair"
        Me.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'gvCadUser
        '
        Me.gvCadUser.AllowUserToAddRows = False
        Me.gvCadUser.AllowUserToDeleteRows = False
        Me.gvCadUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvCadUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserId, Me.Nome, Me.Login})
        Me.gvCadUser.Location = New System.Drawing.Point(0, 39)
        Me.gvCadUser.Name = "gvCadUser"
        Me.gvCadUser.ReadOnly = True
        Me.gvCadUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvCadUser.Size = New System.Drawing.Size(695, 310)
        Me.gvCadUser.TabIndex = 4
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "UserId"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 250
        '
        'Login
        '
        Me.Login.DataPropertyName = "Login"
        Me.Login.HeaderText = "Login"
        Me.Login.Name = "Login"
        Me.Login.ReadOnly = True
        Me.Login.Width = 150
        '
        'frmCadUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 349)
        Me.Controls.Add(Me.gvCadUser)
        Me.Controls.Add(Me.tsBarraBotoes)
        Me.Name = "frmCadUser"
        Me.Text = "Cadastro de Usuários"
        Me.tsBarraBotoes.ResumeLayout(False)
        Me.tsBarraBotoes.PerformLayout()
        CType(Me.gvCadUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tsBarraBotoes As System.Windows.Forms.ToolStrip
    Public WithEvents btnNovo As System.Windows.Forms.ToolStripButton
    Public WithEvents btnEdita As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSalva As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDeleta As System.Windows.Forms.ToolStripButton
    Public WithEvents btnTrocaSenha As System.Windows.Forms.ToolStripButton
    Public WithEvents btnUserHabSeg As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvCadUser As System.Windows.Forms.DataGridView
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Login As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
