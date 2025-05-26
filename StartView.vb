Public Class StartView
    Inherits UserControl

    '---------------------------- Variables ----------------------------'
    Private form As BaseForm
    Private WithEvents btnStart As Button
    Private lblTitle As Label
    Private imgBackground As PictureBox


    '--------------------- Constructor e Inicializador ----------------------'
    'Constructor
    Public Sub New(frm As BaseForm)
        form = frm
        InitializeComponent()
    End Sub


    'Inicializador de Componentes
    Private Sub InitializeComponent()

        '----------- Componentes y Controles -------------'
        'Label para el Título
        lblTitle = New Label()
        lblTitle.Text = "WIKI DE DIOSES MAYAS"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.UseCompatibleTextRendering = True
        lblTitle.BackColor = Color.Chocolate
        lblTitle.ForeColor = Color.WhiteSmoke

        'Botón para Abrir el Menu
        btnStart = New Button()
        btnStart.Text = "¡Vamos a la Ceiba Universal!"
        btnStart.UseCompatibleTextRendering = True
        btnStart.FlatStyle = FlatStyle.Flat
        btnStart.FlatAppearance.BorderSize = 10
        btnStart.BackColor = Color.Chocolate
        btnStart.ForeColor = Color.WhiteSmoke
        btnStart.FlatAppearance.BorderColor = Color.Brown

        'Fondo de la Vista
        imgBackground = New PictureBox()
        imgBackground.Dock = DockStyle.Fill
        imgBackground.Image = ResourceManager.Instance.GetImage("ProyectoFinalVB.MayanBackground.png")
        imgBackground.SizeMode = PictureBoxSizeMode.StretchImage


        '------------- Adición de Controles --------------'
        Me.Controls.Add(btnStart)
        Me.Controls.Add(lblTitle)
        Me.Controls.Add(imgBackground)

        imgBackground.SendToBack()

        '----------- Configuración de Ventana ------------'

        'Actualizar el Tamaño y Posición de los Controles
        AddHandler Me.Resize, AddressOf OrganizeAndResize
        OrganizeAndResize()
    End Sub



    '--------------------- Funciones y Subrutinas ----------------------'
    'Subrutina para Organizar y Reescalar los controles a la Ventana
    Public Sub OrganizeAndResize()
        Dim w As Integer = Me.Width
        Dim h As Integer = Me.Height

        'Ajustar el Título
        lblTitle.Size = New Size(w, h * 0.2)
        lblTitle.Location = New Point((w - lblTitle.Width) * 0.5, h * 0.1)
        lblTitle.Font = ResourceManager.Instance.GetFont("Aztek_Pixel", CInt(w / 25.0F), FontStyle.Bold)

        'Ajustar el Botón de Inicio
        btnStart.Size = New Size(w * 0.5, h * 0.1)
        btnStart.Location = New Point((w - btnStart.Width) * 0.5, (h - btnStart.Height) * 0.7)
        btnStart.Font = ResourceManager.Instance.GetFont("Micro_Chat", CInt(w / 100.0F), FontStyle.Regular)

    End Sub




    '----------------------------- Eventos -----------------------------'
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Debug.WriteLine("Botón 'Entrar' presionado.")
        'Cargar la Vista del Menú
        Dim menuView As New MenuView(form)
        form.LoadView(menuView)
    End Sub
End Class
