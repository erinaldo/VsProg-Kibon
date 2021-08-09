<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIfSrvChk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIfSrvChk))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.shKbProdPlanejCtrlSrv = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.shKbPastGravaSrv = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.shKbMistGravaSrv = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.shKbMatGravaSrv = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.shKbCipPlanejCtrlSrv = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.shKbGeral = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.butKbCipPlanejCtrlSrv = New System.Windows.Forms.Button()
        Me.butKbMatGravaSrv = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.butKbMistGravaSrv = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.butKbPastGravaSrv = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.butKbProdPlanejCtrlSrv = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.butFechar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tmrComm = New System.Windows.Forms.Timer(Me.components)
        Me.lblKbCipPlanejCtrlSrv = New System.Windows.Forms.Label()
        Me.lblKbMatGravaSrv = New System.Windows.Forms.Label()
        Me.lblKbMistGravaSrv = New System.Windows.Forms.Label()
        Me.lblKbPastGravaSrv = New System.Windows.Forms.Label()
        Me.lblKbProdPlanejCtrlSrv = New System.Windows.Forms.Label()
        Me.niIcone = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tmrInit = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Planejamento de CIP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(206, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(307, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TSE - Verificação de  Serviços"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.shKbProdPlanejCtrlSrv, Me.shKbPastGravaSrv, Me.shKbMistGravaSrv, Me.shKbMatGravaSrv, Me.shKbCipPlanejCtrlSrv, Me.shKbGeral})
        Me.ShapeContainer1.Size = New System.Drawing.Size(687, 355)
        Me.ShapeContainer1.TabIndex = 2
        Me.ShapeContainer1.TabStop = False
        '
        'shKbProdPlanejCtrlSrv
        '
        Me.shKbProdPlanejCtrlSrv.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.shKbProdPlanejCtrlSrv.Location = New System.Drawing.Point(459, 297)
        Me.shKbProdPlanejCtrlSrv.Name = "shKbProdPlanejCtrlSrv"
        Me.shKbProdPlanejCtrlSrv.Size = New System.Drawing.Size(20, 20)
        '
        'shKbPastGravaSrv
        '
        Me.shKbPastGravaSrv.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.shKbPastGravaSrv.Location = New System.Drawing.Point(459, 245)
        Me.shKbPastGravaSrv.Name = "shKbPastGravaSrv"
        Me.shKbPastGravaSrv.Size = New System.Drawing.Size(20, 20)
        '
        'shKbMistGravaSrv
        '
        Me.shKbMistGravaSrv.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.shKbMistGravaSrv.Location = New System.Drawing.Point(459, 193)
        Me.shKbMistGravaSrv.Name = "shKbMistGravaSrv"
        Me.shKbMistGravaSrv.Size = New System.Drawing.Size(20, 20)
        '
        'shKbMatGravaSrv
        '
        Me.shKbMatGravaSrv.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.shKbMatGravaSrv.Location = New System.Drawing.Point(459, 141)
        Me.shKbMatGravaSrv.Name = "shKbMatGravaSrv"
        Me.shKbMatGravaSrv.Size = New System.Drawing.Size(20, 20)
        '
        'shKbCipPlanejCtrlSrv
        '
        Me.shKbCipPlanejCtrlSrv.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.shKbCipPlanejCtrlSrv.Location = New System.Drawing.Point(459, 89)
        Me.shKbCipPlanejCtrlSrv.Name = "shKbCipPlanejCtrlSrv"
        Me.shKbCipPlanejCtrlSrv.Size = New System.Drawing.Size(20, 20)
        '
        'shKbGeral
        '
        Me.shKbGeral.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.shKbGeral.Location = New System.Drawing.Point(32, 14)
        Me.shKbGeral.Name = "shKbGeral"
        Me.shKbGeral.Size = New System.Drawing.Size(40, 40)
        '
        'butKbCipPlanejCtrlSrv
        '
        Me.butKbCipPlanejCtrlSrv.Location = New System.Drawing.Point(262, 88)
        Me.butKbCipPlanejCtrlSrv.Name = "butKbCipPlanejCtrlSrv"
        Me.butKbCipPlanejCtrlSrv.Size = New System.Drawing.Size(108, 26)
        Me.butKbCipPlanejCtrlSrv.TabIndex = 3
        Me.butKbCipPlanejCtrlSrv.Text = "Abrir"
        Me.butKbCipPlanejCtrlSrv.UseVisualStyleBackColor = True
        '
        'butKbMatGravaSrv
        '
        Me.butKbMatGravaSrv.Location = New System.Drawing.Point(262, 140)
        Me.butKbMatGravaSrv.Name = "butKbMatGravaSrv"
        Me.butKbMatGravaSrv.Size = New System.Drawing.Size(108, 26)
        Me.butKbMatGravaSrv.TabIndex = 5
        Me.butKbMatGravaSrv.Text = "Abrir"
        Me.butKbMatGravaSrv.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Maturadores"
        '
        'butKbMistGravaSrv
        '
        Me.butKbMistGravaSrv.Location = New System.Drawing.Point(262, 192)
        Me.butKbMistGravaSrv.Name = "butKbMistGravaSrv"
        Me.butKbMistGravaSrv.Size = New System.Drawing.Size(108, 26)
        Me.butKbMistGravaSrv.TabIndex = 7
        Me.butKbMistGravaSrv.Text = "Abrir"
        Me.butKbMistGravaSrv.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Mistura"
        '
        'butKbPastGravaSrv
        '
        Me.butKbPastGravaSrv.Location = New System.Drawing.Point(262, 244)
        Me.butKbPastGravaSrv.Name = "butKbPastGravaSrv"
        Me.butKbPastGravaSrv.Size = New System.Drawing.Size(108, 26)
        Me.butKbPastGravaSrv.TabIndex = 9
        Me.butKbPastGravaSrv.Text = "Abrir"
        Me.butKbPastGravaSrv.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Pasteurizadores"
        '
        'butKbProdPlanejCtrlSrv
        '
        Me.butKbProdPlanejCtrlSrv.Location = New System.Drawing.Point(262, 296)
        Me.butKbProdPlanejCtrlSrv.Name = "butKbProdPlanejCtrlSrv"
        Me.butKbProdPlanejCtrlSrv.Size = New System.Drawing.Size(108, 26)
        Me.butKbProdPlanejCtrlSrv.TabIndex = 11
        Me.butKbProdPlanejCtrlSrv.Text = "Abrir"
        Me.butKbProdPlanejCtrlSrv.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 298)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(200, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Planejamento de Produção"
        '
        'butFechar
        '
        Me.butFechar.Image = Global.IfSrvCkh.My.Resources.Resources.Bot16x16Sair
        Me.butFechar.Location = New System.Drawing.Point(576, 12)
        Me.butFechar.Name = "butFechar"
        Me.butFechar.Size = New System.Drawing.Size(99, 37)
        Me.butFechar.TabIndex = 12
        Me.butFechar.Text = "Fechar"
        Me.butFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.butFechar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(505, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "KbCipPlanejCtrlSrv"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(505, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "KbMatGravaSrv"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(505, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "KbMistGravaSrv"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(505, 246)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 20)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "KbPastGravaSrv"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(505, 298)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 20)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "KbProdPlanejCtrlSrv"
        '
        'tmrComm
        '
        Me.tmrComm.Interval = 1000
        '
        'lblKbCipPlanejCtrlSrv
        '
        Me.lblKbCipPlanejCtrlSrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKbCipPlanejCtrlSrv.Location = New System.Drawing.Point(376, 90)
        Me.lblKbCipPlanejCtrlSrv.Name = "lblKbCipPlanejCtrlSrv"
        Me.lblKbCipPlanejCtrlSrv.Size = New System.Drawing.Size(73, 20)
        Me.lblKbCipPlanejCtrlSrv.TabIndex = 18
        Me.lblKbCipPlanejCtrlSrv.Text = "0"
        Me.lblKbCipPlanejCtrlSrv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKbMatGravaSrv
        '
        Me.lblKbMatGravaSrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKbMatGravaSrv.Location = New System.Drawing.Point(376, 142)
        Me.lblKbMatGravaSrv.Name = "lblKbMatGravaSrv"
        Me.lblKbMatGravaSrv.Size = New System.Drawing.Size(73, 20)
        Me.lblKbMatGravaSrv.TabIndex = 19
        Me.lblKbMatGravaSrv.Text = "0"
        Me.lblKbMatGravaSrv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKbMistGravaSrv
        '
        Me.lblKbMistGravaSrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKbMistGravaSrv.Location = New System.Drawing.Point(376, 194)
        Me.lblKbMistGravaSrv.Name = "lblKbMistGravaSrv"
        Me.lblKbMistGravaSrv.Size = New System.Drawing.Size(73, 20)
        Me.lblKbMistGravaSrv.TabIndex = 20
        Me.lblKbMistGravaSrv.Text = "0"
        Me.lblKbMistGravaSrv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKbPastGravaSrv
        '
        Me.lblKbPastGravaSrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKbPastGravaSrv.Location = New System.Drawing.Point(376, 246)
        Me.lblKbPastGravaSrv.Name = "lblKbPastGravaSrv"
        Me.lblKbPastGravaSrv.Size = New System.Drawing.Size(73, 20)
        Me.lblKbPastGravaSrv.TabIndex = 21
        Me.lblKbPastGravaSrv.Text = "0"
        Me.lblKbPastGravaSrv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKbProdPlanejCtrlSrv
        '
        Me.lblKbProdPlanejCtrlSrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKbProdPlanejCtrlSrv.Location = New System.Drawing.Point(376, 298)
        Me.lblKbProdPlanejCtrlSrv.Name = "lblKbProdPlanejCtrlSrv"
        Me.lblKbProdPlanejCtrlSrv.Size = New System.Drawing.Size(73, 20)
        Me.lblKbProdPlanejCtrlSrv.TabIndex = 22
        Me.lblKbProdPlanejCtrlSrv.Text = "0"
        Me.lblKbProdPlanejCtrlSrv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'niIcone
        '
        Me.niIcone.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.niIcone.Icon = CType(resources.GetObject("niIcone.Icon"), System.Drawing.Icon)
        Me.niIcone.Text = "TSE - Verificação de  Serviços"
        Me.niIcone.Visible = True
        '
        'tmrInit
        '
        '
        'frmIfSrvChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 355)
        Me.Controls.Add(Me.lblKbProdPlanejCtrlSrv)
        Me.Controls.Add(Me.lblKbPastGravaSrv)
        Me.Controls.Add(Me.lblKbMistGravaSrv)
        Me.Controls.Add(Me.lblKbMatGravaSrv)
        Me.Controls.Add(Me.lblKbCipPlanejCtrlSrv)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.butFechar)
        Me.Controls.Add(Me.butKbProdPlanejCtrlSrv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.butKbPastGravaSrv)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.butKbMistGravaSrv)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.butKbMatGravaSrv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.butKbCipPlanejCtrlSrv)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIfSrvChk"
        Me.ShowInTaskbar = False
        Me.Text = "TSE - Verificação de  Serviços"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents shKbCipPlanejCtrlSrv As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents shKbGeral As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents butKbCipPlanejCtrlSrv As System.Windows.Forms.Button
    Friend WithEvents butKbMatGravaSrv As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butKbMistGravaSrv As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents butKbPastGravaSrv As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents butKbProdPlanejCtrlSrv As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents butFechar As System.Windows.Forms.Button
    Friend WithEvents shKbProdPlanejCtrlSrv As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents shKbPastGravaSrv As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents shKbMistGravaSrv As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents shKbMatGravaSrv As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tmrComm As System.Windows.Forms.Timer
    Friend WithEvents lblKbCipPlanejCtrlSrv As System.Windows.Forms.Label
    Friend WithEvents lblKbMatGravaSrv As System.Windows.Forms.Label
    Friend WithEvents lblKbMistGravaSrv As System.Windows.Forms.Label
    Friend WithEvents lblKbPastGravaSrv As System.Windows.Forms.Label
    Friend WithEvents lblKbProdPlanejCtrlSrv As System.Windows.Forms.Label
    Friend WithEvents niIcone As System.Windows.Forms.NotifyIcon
    Friend WithEvents tmrInit As System.Windows.Forms.Timer

End Class
