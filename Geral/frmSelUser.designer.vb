<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.butCancela = New System.Windows.Forms.Button
        Me.butOk = New System.Windows.Forms.Button
        Me.gvItens = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NOME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SenhaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butCancela
        '
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(237, 341)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(138, 30)
        Me.butCancela.TabIndex = 86
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(32, 341)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(138, 30)
        Me.butOk.TabIndex = 85
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.AutoGenerateColumns = False
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.NOME, Me.UserIdDataGridViewTextBoxColumn, Me.NomeDataGridViewTextBoxColumn, Me.LoginDataGridViewTextBoxColumn, Me.SenhaDataGridViewTextBoxColumn})
        Me.gvItens.DataSource = Me.BindingSource1
        Me.gvItens.Location = New System.Drawing.Point(0, 0)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(401, 335)
        Me.gvItens.TabIndex = 84
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "USERID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'NOME
        '
        Me.NOME.DataPropertyName = "NOME"
        Me.NOME.HeaderText = "Nome"
        Me.NOME.Name = "NOME"
        Me.NOME.ReadOnly = True
        Me.NOME.Width = 200
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "UserId"
        Me.UserId.Name = "UserId"
        '
        'UserIdDataGridViewTextBoxColumn
        '
        Me.UserIdDataGridViewTextBoxColumn.DataPropertyName = "UserId"
        Me.UserIdDataGridViewTextBoxColumn.HeaderText = "UserId"
        Me.UserIdDataGridViewTextBoxColumn.Name = "UserIdDataGridViewTextBoxColumn"
        Me.UserIdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NomeDataGridViewTextBoxColumn
        '
        Me.NomeDataGridViewTextBoxColumn.DataPropertyName = "Nome"
        Me.NomeDataGridViewTextBoxColumn.HeaderText = "Nome"
        Me.NomeDataGridViewTextBoxColumn.Name = "NomeDataGridViewTextBoxColumn"
        Me.NomeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LoginDataGridViewTextBoxColumn
        '
        Me.LoginDataGridViewTextBoxColumn.DataPropertyName = "Login"
        Me.LoginDataGridViewTextBoxColumn.HeaderText = "Login"
        Me.LoginDataGridViewTextBoxColumn.Name = "LoginDataGridViewTextBoxColumn"
        Me.LoginDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SenhaDataGridViewTextBoxColumn
        '
        Me.SenhaDataGridViewTextBoxColumn.DataPropertyName = "Senha"
        Me.SenhaDataGridViewTextBoxColumn.HeaderText = "Senha"
        Me.SenhaDataGridViewTextBoxColumn.Name = "SenhaDataGridViewTextBoxColumn"
        Me.SenhaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frmSelUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 383)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.gvItens)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSelUser"
        Me.Text = "Usuário - Seleciona"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents NomeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SenhaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
