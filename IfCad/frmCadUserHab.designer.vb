<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadUserHab
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbHab = New System.Windows.Forms.ListBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbHabDisp = New System.Windows.Forms.ListBox()
        Me.CadUserSegBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.butHabRem = New System.Windows.Forms.Button()
        Me.butHabAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CadUserHabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CadUserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtUserId = New System.Windows.Forms.TextBox()
        CType(Me.CadUserSegBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CadUserHabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CadUserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 112
        Me.Label7.Text = "Disponíveis"
        '
        'lbHab
        '
        Me.lbHab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbHab.FormattingEnabled = True
        Me.lbHab.Location = New System.Drawing.Point(257, 55)
        Me.lbHab.Name = "lbHab"
        Me.lbHab.Size = New System.Drawing.Size(126, 160)
        Me.lbHab.TabIndex = 109
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(167, 8)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(216, 20)
        Me.txtNome.TabIndex = 107
        Me.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(122, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Nome"
        '
        'lbHabDisp
        '
        Me.lbHabDisp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbHabDisp.FormattingEnabled = True
        Me.lbHabDisp.Location = New System.Drawing.Point(16, 55)
        Me.lbHabDisp.Name = "lbHabDisp"
        Me.lbHabDisp.Size = New System.Drawing.Size(130, 160)
        Me.lbHabDisp.TabIndex = 108
        '
        'CadUserSegBindingSource
        '
        Me.CadUserSegBindingSource.DataMember = "CadUserSeg"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(254, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Selecionados"
        '
        'butHabRem
        '
        Me.butHabRem.Location = New System.Drawing.Point(167, 130)
        Me.butHabRem.Name = "butHabRem"
        Me.butHabRem.Size = New System.Drawing.Size(75, 23)
        Me.butHabRem.TabIndex = 111
        Me.butHabRem.Text = "<<"
        Me.butHabRem.UseVisualStyleBackColor = True
        '
        'butHabAdd
        '
        Me.butHabAdd.Location = New System.Drawing.Point(167, 64)
        Me.butHabAdd.Name = "butHabAdd"
        Me.butHabAdd.Size = New System.Drawing.Size(75, 23)
        Me.butHabAdd.TabIndex = 110
        Me.butHabAdd.Text = ">>"
        Me.butHabAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "UserId"
        '
        'CadUserHabBindingSource
        '
        Me.CadUserHabBindingSource.DataMember = "CadUserHab"
        '
        'CadUserBindingSource
        '
        Me.CadUserBindingSource.DataMember = "CadUser"
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(49, 8)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(63, 20)
        Me.txtUserId.TabIndex = 105
        Me.txtUserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmCadUserHab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 227)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbHab)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbHabDisp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.butHabRem)
        Me.Controls.Add(Me.butHabAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserId)
        Me.Name = "frmCadUserHab"
        Me.Text = "Usuários Habilitados"
        CType(Me.CadUserSegBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CadUserHabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CadUserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbHab As System.Windows.Forms.ListBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbHabDisp As System.Windows.Forms.ListBox
    Friend WithEvents CadUserSegBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents butHabRem As System.Windows.Forms.Button
    Friend WithEvents butHabAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CadUserHabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CadUserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
End Class
