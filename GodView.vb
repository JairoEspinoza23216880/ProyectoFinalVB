Public Class GodView
    Inherits UserControl

    '---------------------------- Variables ----------------------------'
    Private pictureGif As PictureBox
    Private lblName, lblTitle As Label
    Private lblDomain, lblSymbology, lblAppearance As Label
    Private txtDescription As Label
    Private WithEvents btnGoBack As Button

    Private background As PictureBox
    Private mainForm As BaseForm

    Private maingod As GodData

    '---------------------------- Constructor/Inicializador ----------------------------'
    'Constructor
    Public Sub New(ByVal frm As BaseForm, god As GodData)
        mainForm = frm
        maingod = god
        InitializeComponent()
        LoadGodData(god)
    End Sub

    'Inicializador
    Private Sub InitializeComponent()

        'Label de Nombre
        lblName = New Label()
        lblName.UseCompatibleTextRendering = True
        lblName.BackColor = Color.Chocolate
        lblName.ForeColor = Color.WhiteSmoke

        'Label de Título
        lblTitle = New Label()
        lblTitle.UseCompatibleTextRendering = True
        lblTitle.BackColor = Color.Chocolate
        lblTitle.ForeColor = Color.WhiteSmoke

        'Fondo de Pantalla
        background = New PictureBox With {
            .Dock = DockStyle.Fill,
            .Image = ResourceManager.Instance.GetImage("ProyectoFinalVB.MayanBackground.png"),
            .SizeMode = PictureBoxSizeMode.StretchImage
        }

        'GIF del Dios
        pictureGif = New PictureBox With {
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .BorderStyle = BorderStyle.FixedSingle
        }

        lblDomain = New Label()
        lblSymbology = New Label()
        lblAppearance = New Label()

        txtDescription = New Label With {
            .AutoSize = False,
            .BorderStyle = BorderStyle.FixedSingle
        }

        btnGoBack = New Button With {
            .Text = "Regresar al Menu",
            .UseCompatibleTextRendering = True,
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.Chocolate,
            .ForeColor = Color.WhiteSmoke
        }
        btnGoBack.FlatAppearance.BorderSize = 10
        btnGoBack.FlatAppearance.BorderColor = Color.Brown

        'Añadir controles al UserControl
        Controls.Add(pictureGif)
        Controls.Add(lblName)
        Controls.Add(lblTitle)
        Controls.Add(lblDomain)
        Controls.Add(lblSymbology)
        Controls.Add(lblAppearance)
        Controls.Add(txtDescription)
        Controls.Add(btnGoBack)

        Controls.Add(background)
        background.SendToBack()

        AddHandler Me.Resize, AddressOf OrganizeAndResize
        OrganizeAndResize()

    End Sub

    '---------------------- Funciones y Subrutinas ----------------------'
    'Cargar datos del Dios
    Private Sub LoadGodData(god As GodData)
        lblName.Text = god.Name
        lblTitle.Text = god.Title
        lblDomain.Text = "Dominio: " & god.Domain
        lblSymbology.Text = "Simbolismo: " & god.Symbology
        lblAppearance.Text = "Apariencia: " & god.Appearance
        txtDescription.Text = god.Description

        pictureGif.Image = ResourceManager.Instance.ResizeGIF(god.gifName, pictureGif.Size)

    End Sub

    'Organizar y redimensionar controles
    Private Sub OrganizeAndResize()
        Dim w As Integer = Me.Width
        Dim h As Integer = Me.Height

        ' Columnas
        Dim leftW As Integer = CInt(w * 0.35)
        Dim rightW As Integer = w - leftW - 30
        Dim spacing As Integer = 10

        ' === GIF cuadrado ===
        Dim gifSize As Integer = Math.Min(leftW, h \ 2)
        pictureGif.SetBounds(10, 10, gifSize, gifSize)
        pictureGif.Image = ResourceManager.Instance.ResizeGIF(maingod.gifName, pictureGif.Size)

        ' === Etiquetas de la izquierda ===
        Dim domainHeight As Integer = CInt(h * 0.06)
        Dim symbologyHeight As Integer = CInt(h * 0.06)
        Dim currentY As Integer = pictureGif.Bottom + spacing

        ' Dominio
        lblDomain.SetBounds(10, currentY, leftW, domainHeight)
        lblDomain.Font = ResourceManager.Instance.GetFont("Micro_Chat", Math.Max(8, domainHeight \ 2.8), FontStyle.Regular)
        currentY += domainHeight + spacing

        ' Simbología
        lblSymbology.SetBounds(10, currentY, leftW, symbologyHeight)
        lblSymbology.Font = ResourceManager.Instance.GetFont("Micro_Chat", Math.Max(8, symbologyHeight \ 2.8), FontStyle.Regular)
        currentY += symbologyHeight + spacing

        ' Apariencia (ocupa el espacio restante hasta el botón)
        Dim goBackY As Integer = h - 75
        Dim appearanceHeight As Integer = goBackY - currentY - spacing
        lblAppearance.SetBounds(10, currentY, leftW, appearanceHeight)
        lblAppearance.Font = ResourceManager.Instance.GetFont("Micro_Chat", Math.Max(8, appearanceHeight \ 10), FontStyle.Regular)

        ' Botón
        btnGoBack.SetBounds(10, h - 75, leftW, 60)
        btnGoBack.Font = ResourceManager.Instance.GetFont("Tiny_Talk", Math.Max(8, h \ 100), FontStyle.Regular)

        ' === Panel derecho: nombre, título y descripción ===
        Dim nameHeight As Integer = CInt(h * 0.15)
        Dim titleHeight As Integer = CInt(h * 0.08)

        lblName.SetBounds(leftW + 20, 10, rightW, nameHeight)
        lblName.Font = ResourceManager.Instance.GetFont("Aztek_Pixel", Math.Max(8, nameHeight \ 3), FontStyle.Bold)

        lblTitle.SetBounds(leftW + 20, lblName.Bottom + spacing, rightW, titleHeight)
        lblTitle.Font = ResourceManager.Instance.GetFont("Micro_Chat", Math.Max(8, titleHeight \ 4), FontStyle.Regular)

        ' Descripción ocupa el resto del espacio
        Dim descY As Integer = lblTitle.Bottom + spacing
        Dim descHeight As Integer = h - descY - 20
        txtDescription.SetBounds(leftW + 20, descY, rightW, descHeight)
        txtDescription.Font = ResourceManager.Instance.GetFont("Tiny_Talk", Math.Max(8, descHeight \ 30), FontStyle.Regular)
    End Sub

    'Evento de clic en el botón "Regresar al Menu"
    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Debug.WriteLine("Regresando a Menu...")
        Dim menuView As New MenuView(mainForm)
        mainForm.LoadView(menuView)
    End Sub

End Class
