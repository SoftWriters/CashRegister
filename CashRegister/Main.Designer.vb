<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lvwChange = New System.Windows.Forms.ListView()
        Me.chResults = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAmtOwed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAmtPaid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(34, 269)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(170, 61)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Load File"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lvwChange
        '
        Me.lvwChange.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chAmtOwed, Me.chAmtPaid, Me.chResults})
        Me.lvwChange.FullRowSelect = True
        Me.lvwChange.Location = New System.Drawing.Point(34, 21)
        Me.lvwChange.Name = "lvwChange"
        Me.lvwChange.Size = New System.Drawing.Size(758, 242)
        Me.lvwChange.TabIndex = 2
        Me.lvwChange.UseCompatibleStateImageBehavior = False
        Me.lvwChange.View = System.Windows.Forms.View.Details
        '
        'chResults
        '
        Me.chResults.Text = "Change"
        Me.chResults.Width = 558
        '
        'chAmtOwed
        '
        Me.chAmtOwed.Text = "Amount Owed"
        Me.chAmtOwed.Width = 100
        '
        'chAmtPaid
        '
        Me.chAmtPaid.Text = "Amount Paid"
        Me.chAmtPaid.Width = 100
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(210, 269)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(170, 61)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 357)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lvwChange)
        Me.Controls.Add(Me.btnLoad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Register"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLoad As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents lvwChange As ListView
    Friend WithEvents chResults As ColumnHeader
    Friend WithEvents chAmtOwed As ColumnHeader
    Friend WithEvents chAmtPaid As ColumnHeader
    Friend WithEvents btnExit As Button
End Class
