<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadPtoCritRotaEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadPtoCritRotaEdit))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butSalva = New System.Windows.Forms.Button()
        Me.butCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPtoCrId = New System.Windows.Forms.TextBox()
        Me.txtPtoCrPergunta = New System.Windows.Forms.TextBox()
        Me.butPtoCrSel = New System.Windows.Forms.Button()
        Me.butRotaSel = New System.Windows.Forms.Button()
        Me.txtRotaId = New System.Windows.Forms.TextBox()
        Me.txtSeq = New System.Windows.Forms.TextBox()
        Me.txtRotaDescr = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rota Id"
        '
        'butSalva
        '
        Me.butSalva.Location = New System.Drawing.Point(100, 143)
        Me.butSalva.Name = "butSalva"
        Me.butSalva.Size = New System.Drawing.Size(150, 23)
        Me.butSalva.TabIndex = 1
        Me.butSalva.Text = "Ok"
        Me.butSalva.UseVisualStyleBackColor = True
        '
        'butCancelar
        '
        Me.butCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCancelar.Location = New System.Drawing.Point(322, 143)
        Me.butCancelar.Name = "butCancelar"
        Me.butCancelar.Size = New System.Drawing.Size(150, 23)
        Me.butCancelar.TabIndex = 2
        Me.butCancelar.Text = "Cancelar"
        Me.butCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Pto Crítico"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Sequencia"
        '
        'txtPtoCrId
        '
        Me.txtPtoCrId.Location = New System.Drawing.Point(100, 62)
        Me.txtPtoCrId.Name = "txtPtoCrId"
        Me.txtPtoCrId.Size = New System.Drawing.Size(42, 20)
        Me.txtPtoCrId.TabIndex = 10
        Me.txtPtoCrId.Text = "0"
        Me.txtPtoCrId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPtoCrPergunta
        '
        Me.txtPtoCrPergunta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPtoCrPergunta.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPtoCrPergunta.Location = New System.Drawing.Point(148, 63)
        Me.txtPtoCrPergunta.Name = "txtPtoCrPergunta"
        Me.txtPtoCrPergunta.ReadOnly = True
        Me.txtPtoCrPergunta.Size = New System.Drawing.Size(357, 20)
        Me.txtPtoCrPergunta.TabIndex = 11
        '
        'butPtoCrSel
        '
        Me.butPtoCrSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butPtoCrSel.Location = New System.Drawing.Point(511, 63)
        Me.butPtoCrSel.Name = "butPtoCrSel"
        Me.butPtoCrSel.Size = New System.Drawing.Size(41, 20)
        Me.butPtoCrSel.TabIndex = 12
        Me.butPtoCrSel.Text = "..."
        Me.butPtoCrSel.UseVisualStyleBackColor = True
        '
        'butRotaSel
        '
        Me.butRotaSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRotaSel.Location = New System.Drawing.Point(511, 23)
        Me.butRotaSel.Name = "butRotaSel"
        Me.butRotaSel.Size = New System.Drawing.Size(41, 20)
        Me.butRotaSel.TabIndex = 14
        Me.butRotaSel.Text = "..."
        Me.butRotaSel.UseVisualStyleBackColor = True
        '
        'txtRotaId
        '
        Me.txtRotaId.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtRotaId.Location = New System.Drawing.Point(100, 23)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.ReadOnly = True
        Me.txtRotaId.Size = New System.Drawing.Size(42, 20)
        Me.txtRotaId.TabIndex = 15
        Me.txtRotaId.Text = "0"
        Me.txtRotaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSeq
        '
        Me.txtSeq.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSeq.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSeq.Location = New System.Drawing.Point(100, 104)
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Size = New System.Drawing.Size(401, 20)
        Me.txtSeq.TabIndex = 16
        Me.txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRotaDescr
        '
        Me.txtRotaDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRotaDescr.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtRotaDescr.Location = New System.Drawing.Point(148, 24)
        Me.txtRotaDescr.Name = "txtRotaDescr"
        Me.txtRotaDescr.ReadOnly = True
        Me.txtRotaDescr.Size = New System.Drawing.Size(357, 20)
        Me.txtRotaDescr.TabIndex = 17
        '
        'frmCadPtoCritRotaEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 186)
        Me.Controls.Add(Me.txtRotaDescr)
        Me.Controls.Add(Me.txtSeq)
        Me.Controls.Add(Me.txtRotaId)
        Me.Controls.Add(Me.butRotaSel)
        Me.Controls.Add(Me.butPtoCrSel)
        Me.Controls.Add(Me.txtPtoCrPergunta)
        Me.Controls.Add(Me.txtPtoCrId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.butCancelar)
        Me.Controls.Add(Me.butSalva)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadPtoCritRotaEdit"
        Me.Text = "Edita Rota por Pto Critico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butSalva As System.Windows.Forms.Button
    Friend WithEvents butCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPtoCrId As System.Windows.Forms.TextBox
    Friend WithEvents txtPtoCrPergunta As System.Windows.Forms.TextBox
    Friend WithEvents butPtoCrSel As System.Windows.Forms.Button
    Friend WithEvents butRotaSel As System.Windows.Forms.Button
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents txtSeq As System.Windows.Forms.TextBox
    Friend WithEvents txtRotaDescr As System.Windows.Forms.TextBox
End Class
