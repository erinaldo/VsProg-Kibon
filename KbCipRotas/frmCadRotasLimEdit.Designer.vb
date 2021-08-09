<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadRotasLimEdit
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
        Me.butCancela = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.txtTempMax = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTempMin = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCondMin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCondMax = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVazaoMin = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtVazaoMax = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTempoAjuste = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'butCancela
        '
        Me.butCancela.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(304, 400)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(144, 37)
        Me.butCancela.TabIndex = 33
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.butOk.Location = New System.Drawing.Point(106, 400)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(144, 37)
        Me.butOk.TabIndex = 32
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'txtTempMax
        '
        Me.txtTempMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempMax.Location = New System.Drawing.Point(237, 46)
        Me.txtTempMax.Name = "txtTempMax"
        Me.txtTempMax.Size = New System.Drawing.Size(170, 26)
        Me.txtTempMax.TabIndex = 34
        Me.txtTempMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Temperatura máxima"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(413, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "ºC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(413, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 20)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "ºC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(58, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 20)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Temperatura mínima"
        '
        'txtTempMin
        '
        Me.txtTempMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempMin.Location = New System.Drawing.Point(237, 78)
        Me.txtTempMin.Name = "txtTempMin"
        Me.txtTempMin.Size = New System.Drawing.Size(170, 26)
        Me.txtTempMin.TabIndex = 37
        Me.txtTempMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(413, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 20)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "mS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(58, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(164, 20)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Condutividade mínima"
        '
        'txtCondMin
        '
        Me.txtCondMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCondMin.Location = New System.Drawing.Point(237, 170)
        Me.txtCondMin.Name = "txtCondMin"
        Me.txtCondMin.Size = New System.Drawing.Size(170, 26)
        Me.txtCondMin.TabIndex = 43
        Me.txtCondMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(413, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 20)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "mS"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(58, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 20)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Condutividade máxima"
        '
        'txtCondMax
        '
        Me.txtCondMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCondMax.Location = New System.Drawing.Point(237, 138)
        Me.txtCondMax.Name = "txtCondMax"
        Me.txtCondMax.Size = New System.Drawing.Size(170, 26)
        Me.txtCondMax.TabIndex = 40
        Me.txtCondMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(413, 261)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 20)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "mᶟ/h"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(58, 261)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 20)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Vazão mínima"
        '
        'txtVazaoMin
        '
        Me.txtVazaoMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVazaoMin.Location = New System.Drawing.Point(237, 258)
        Me.txtVazaoMin.Name = "txtVazaoMin"
        Me.txtVazaoMin.Size = New System.Drawing.Size(170, 26)
        Me.txtVazaoMin.TabIndex = 49
        Me.txtVazaoMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(413, 229)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 20)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "mᶟ/h"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(58, 229)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 20)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Vazão máxima"
        '
        'txtVazaoMax
        '
        Me.txtVazaoMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVazaoMax.Location = New System.Drawing.Point(237, 226)
        Me.txtVazaoMax.Name = "txtVazaoMax"
        Me.txtVazaoMax.Size = New System.Drawing.Size(170, 26)
        Me.txtVazaoMax.TabIndex = 46
        Me.txtVazaoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(413, 315)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 20)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "s"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(58, 315)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 20)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "Tempo de ajuste"
        '
        'txtTempoAjuste
        '
        Me.txtTempoAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempoAjuste.Location = New System.Drawing.Point(237, 312)
        Me.txtTempoAjuste.Name = "txtTempoAjuste"
        Me.txtTempoAjuste.Size = New System.Drawing.Size(170, 26)
        Me.txtTempoAjuste.TabIndex = 52
        Me.txtTempoAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmCadRotasLimEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 460)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTempoAjuste)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtVazaoMin)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtVazaoMax)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCondMin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCondMax)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTempMin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTempMax)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Name = "frmCadRotasLimEdit"
        Me.Text = "Limites de CIP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents txtTempMax As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTempMin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCondMin As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCondMax As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVazaoMin As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtVazaoMax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTempoAjuste As System.Windows.Forms.TextBox
End Class
