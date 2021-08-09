<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbToledoCtrl
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
        Me.butFecha = New System.Windows.Forms.Button()
        Me.lblSts = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.butIniciar = New System.Windows.Forms.Button()
        Me.butParar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtResp = New System.Windows.Forms.TextBox()
        Me.txtCmd = New System.Windows.Forms.TextBox()
        Me.butTestCom = New System.Windows.Forms.Button()
        Me.butEnvia = New System.Windows.Forms.Button()
        Me.TmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtEnvia = New System.Windows.Forms.TextBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'butFecha
        '
        Me.butFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butFecha.Location = New System.Drawing.Point(613, 65)
        Me.butFecha.Name = "butFecha"
        Me.butFecha.Size = New System.Drawing.Size(212, 31)
        Me.butFecha.TabIndex = 7
        Me.butFecha.Text = "Fechar"
        Me.butFecha.UseVisualStyleBackColor = True
        '
        'lblSts
        '
        Me.lblSts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSts.AutoSize = True
        Me.lblSts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSts.Location = New System.Drawing.Point(67, 419)
        Me.lblSts.Name = "lblSts"
        Me.lblSts.Size = New System.Drawing.Size(91, 16)
        Me.lblSts.TabIndex = 6
        Me.lblSts.Text = "Sem conexão"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 419)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Status:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Comando"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Resposta"
        '
        'butIniciar
        '
        Me.butIniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butIniciar.Location = New System.Drawing.Point(30, 26)
        Me.butIniciar.Name = "butIniciar"
        Me.butIniciar.Size = New System.Drawing.Size(103, 31)
        Me.butIniciar.TabIndex = 21
        Me.butIniciar.Text = "Iniciar"
        Me.butIniciar.UseVisualStyleBackColor = True
        '
        'butParar
        '
        Me.butParar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butParar.Location = New System.Drawing.Point(139, 26)
        Me.butParar.Name = "butParar"
        Me.butParar.Size = New System.Drawing.Size(103, 31)
        Me.butParar.TabIndex = 22
        Me.butParar.Text = "Parar"
        Me.butParar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtResp)
        Me.GroupBox4.Controls.Add(Me.txtCmd)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.butParar)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.butIniciar)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(28, 114)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(793, 282)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Comando/Resposta"
        '
        'txtResp
        '
        Me.txtResp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResp.Location = New System.Drawing.Point(30, 182)
        Me.txtResp.Multiline = True
        Me.txtResp.Name = "txtResp"
        Me.txtResp.Size = New System.Drawing.Size(728, 90)
        Me.txtResp.TabIndex = 31
        '
        'txtCmd
        '
        Me.txtCmd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCmd.Location = New System.Drawing.Point(30, 80)
        Me.txtCmd.Multiline = True
        Me.txtCmd.Name = "txtCmd"
        Me.txtCmd.Size = New System.Drawing.Size(728, 83)
        Me.txtCmd.TabIndex = 30
        '
        'butTestCom
        '
        Me.butTestCom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butTestCom.Location = New System.Drawing.Point(613, 31)
        Me.butTestCom.Name = "butTestCom"
        Me.butTestCom.Size = New System.Drawing.Size(212, 31)
        Me.butTestCom.TabIndex = 27
        Me.butTestCom.Text = "Testa Comunicação"
        Me.butTestCom.UseVisualStyleBackColor = True
        '
        'butEnvia
        '
        Me.butEnvia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butEnvia.Location = New System.Drawing.Point(415, 27)
        Me.butEnvia.Name = "butEnvia"
        Me.butEnvia.Size = New System.Drawing.Size(103, 31)
        Me.butEnvia.TabIndex = 28
        Me.butEnvia.Text = "Envia CMD"
        Me.butEnvia.UseVisualStyleBackColor = True
        '
        'TmrRefresh
        '
        Me.TmrRefresh.Interval = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEnvia)
        Me.GroupBox1.Controls.Add(Me.butEnvia)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(28, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(579, 74)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comando"
        '
        'txtEnvia
        '
        Me.txtEnvia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEnvia.Location = New System.Drawing.Point(27, 31)
        Me.txtEnvia.Name = "txtEnvia"
        Me.txtEnvia.Size = New System.Drawing.Size(364, 22)
        Me.txtEnvia.TabIndex = 20
        '
        'frmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 444)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.butTestCom)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butFecha)
        Me.Controls.Add(Me.lblSts)
        Me.Name = "frmCliente"
        Me.Text = "Cliente"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butFecha As System.Windows.Forms.Button
    Friend WithEvents lblSts As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents butIniciar As System.Windows.Forms.Button
    Friend WithEvents butParar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents butTestCom As System.Windows.Forms.Button
    Friend WithEvents butEnvia As System.Windows.Forms.Button
    Friend WithEvents txtCmd As System.Windows.Forms.TextBox
    Friend WithEvents txtResp As System.Windows.Forms.TextBox
    Friend WithEvents TmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEnvia As System.Windows.Forms.TextBox

End Class
