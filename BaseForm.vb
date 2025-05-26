Imports System.Reflection

Public Class BaseForm
    Inherits Form

    '---------------------------- Variables ----------------------------'



    '--------------------- Funciones y Subrutinas ----------------------'
    'Constructor
    Public Sub New()
        'Configurar Ventana
        Me.Text = "Wiki de Dioses Mayas"
        Me.Size = New Size(900, 600)
        Me.MinimumSize = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen

        'Imprimir todos los Recursos
        Dim asm As Assembly = Assembly.GetExecutingAssembly()
        For Each r In asm.GetManifestResourceNames()
            Debug.WriteLine(r)
        Next

        'Cargar Componentes y Vista
        InitializeComponent()
        LoadView(New StartView(Me))
    End Sub


    'Subrutina para cargar Vista
    Public Sub LoadView(view As UserControl)
        panelContainer.Controls.Clear()
        view.Dock = DockStyle.Fill
        panelContainer.Controls.Add(view)
    End Sub


    '----------------------------- Eventos -----------------------------'
End Class
