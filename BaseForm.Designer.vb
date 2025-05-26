<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class BaseForm
    Inherits Form

    '---------------------------- Variables ----------------------------'
    Private panelContainer As Panel             ' Panel para las Vistas

    '--------------------- Funciones y Subrutinas ----------------------'
    'Inicializador de Componentes
    Private Sub InitializeComponent()
        Me.panelContainer = New Panel()
        Me.SuspendLayout()

        'panelContainer
        Me.panelContainer.Dock = DockStyle.Fill
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Size = New Size(800, 600)

        ' MainForm
        Me.ClientSize = New Size(800, 600)
        Me.Controls.Add(Me.panelContainer)
        Me.Name = "MainForm"
        Me.Text = "Wiki de Dioses Mayas"
        Me.ResumeLayout(False)
    End Sub
End Class

