Public Class MenuView
    Inherits UserControl

    '---------------------------- Variables ----------------------------'
    Private form As BaseForm
    Private imgBackground As PictureBox

    'Botones de cada dios Maya
    Private WithEvents btnAhMuzenCab As Button      'La Abeja Descendente
    Private WithEvents btnAhPuch As Button          'Soberano de Xibalba
    Private WithEvents btnChaac As Button           'Portador de la Lluvia
    Private WithEvents btnIxChel As Button          'Madre Lunar, Curandera del Amor
    Private WithEvents btnKinichKakmo As Button     'La Guacamaya de Fuego
    Private WithEvents btnKukulkan As Button        'La Serpiente Emplumada
    Private WithEvents btnYumKaax As Button         'Joven del Maíz

    Private WithEvents btnCamazotz As Button        'El Murciélago del Inframundo
    Private WithEvents btnItzamna As Button         'Creador del Mayab
    Private WithEvents btnIxTab As Button           'Guía de los Ahorcados
    Private WithEvents btnKinichAhau As Button      'Guerrero del Sol

    Private WithEvents btnBolonDzacab As Button     'El Relámpago Ardiente
    Private WithEvents btnEkChuah As Button         'El Mercader Chocolatoso
    Private WithEvents btnHuracan As Button         'La Tormenta Creadora
    Private WithEvents btnPawahtun As Button        'El que carga el Cosmos



    '------------------- Constructor e Inicializador -------------------'
    'Constructor
    Public Sub New(frm As BaseForm)
        form = frm
        InitializeComponent()
    End Sub


    'Inicializador de Componentes
    Private Sub InitializeComponent()

        '----------- Componentes y Controles -------------'
        'Fondo de la Vista
        imgBackground = New PictureBox()
        imgBackground.Dock = DockStyle.Fill
        imgBackground.Image = ResourceManager.Instance.GetImage("ProyectoFinalVB.MayanYggdrasil.jpg")
        imgBackground.SizeMode = PictureBoxSizeMode.StretchImage

        '----------- Botones de dioses Mayas -------------'
        'Botón AhMuzencab
        btnAhMuzenCab = New Button()
        ConfigureButton(btnAhMuzenCab)
        Dim ahMuzenCabTooltip As New ToolTip()
        ahMuzenCabTooltip.SetToolTip(btnAhMuzenCab, "AH MUZEN CAB - La Abeja Descendente")
        'Botón AhPuch
        btnAhPuch = New Button()
        ConfigureButton(btnAhPuch)
        Dim ahPuchTooltip As New ToolTip()
        ahPuchTooltip.SetToolTip(btnAhPuch, "AH PUCH - Soberano del Xibalba")
        'Botón Chaac
        btnChaac = New Button()
        ConfigureButton(btnChaac)
        Dim chaacTooltip As New ToolTip()
        chaacTooltip.SetToolTip(btnChaac, "CHAAC - Portador de la Lluvia")
        'Botón IxChel
        btnIxChel = New Button()
        ConfigureButton(btnIxChel)
        Dim ixChelTooltip As New ToolTip()
        ixChelTooltip.SetToolTip(btnIxChel, "IX CHEL - Madre Lunar, Curandera del Amor")
        'Botón KinichKakmo
        btnKinichKakmo = New Button()
        ConfigureButton(btnKinichKakmo)
        Dim kinichKakmoTooltip As New ToolTip()
        kinichKakmoTooltip.SetToolTip(btnKinichKakmo, "KINICH KAKMÓ - La Guacamaya de Fuego")
        'Botón Kukulcan
        btnKukulkan = New Button()
        ConfigureButton(btnKukulkan)
        Dim kukulkanTooltip As New ToolTip()
        kukulkanTooltip.SetToolTip(btnKukulkan, "KUKULCÁN - La Serpiente Emplumada")
        'Botón YumKaax
        btnYumKaax = New Button()
        ConfigureButton(btnYumKaax)
        Dim yumKaaxTooltip As New ToolTip()
        yumKaaxTooltip.SetToolTip(btnYumKaax, "YUM KAAX - El Joven del Maíz")
        'Botón Camazotz
        btnCamazotz = New Button()
        ConfigureButton(btnCamazotz)
        Dim camazotzTooltip As New ToolTip()
        camazotzTooltip.SetToolTip(btnCamazotz, "CAMATZOTZ - El Murciélago del Inframundo")
        'Botón Itzamná
        btnItzamna = New Button()
        ConfigureButton(btnItzamna)
        Dim itzamnaTooltip As New ToolTip()
        itzamnaTooltip.SetToolTip(btnItzamna, "ITZAMNÁ - Creador del Mayab")
        'Botón IxTab
        btnIxTab = New Button()
        ConfigureButton(btnIxTab)
        Dim ixTabTooltip As New ToolTip()
        ixTabTooltip.SetToolTip(btnIxTab, "IX TAB - Guía de los Ahorcados")
        'Botón KinichAhau
        btnKinichAhau = New Button()
        ConfigureButton(btnKinichAhau)
        Dim kinichAhauTooltip As New ToolTip()
        kinichAhauTooltip.SetToolTip(btnKinichAhau, "KINICH AHAU - Guerrero del Sol")
        'Botón BolonDzacab
        btnBolonDzacab = New Button()
        ConfigureButton(btnBolonDzacab)
        Dim bolonDzacabTooltip As New ToolTip()
        bolonDzacabTooltip.SetToolTip(btnBolonDzacab, "BOLON DZACAB - El Relámpago Ardiente")
        'Botón EkChuah
        btnEkChuah = New Button()
        ConfigureButton(btnEkChuah)
        Dim ekChuahTooltip As New ToolTip()
        ekChuahTooltip.SetToolTip(btnEkChuah, "EK CHUAH - El Mercader Chocolatoso")
        'Botón Huracan
        btnHuracan = New Button()
        ConfigureButton(btnHuracan)
        Dim huracanTooltip As New ToolTip()
        huracanTooltip.SetToolTip(btnHuracan, "HURACÁN - La Tormenta Creadora")
        'Botón Pawahtun
        btnPawahtun = New Button()
        ConfigureButton(btnPawahtun)
        Dim pawahtunTooltip As New ToolTip()
        pawahtunTooltip.SetToolTip(btnPawahtun, "PAWAHTUN - El que carga el Cosmos")


        '------------- Adición de Controles --------------'
        Me.Controls.Add(imgBackground)

        Me.Controls.Add(btnAhMuzenCab)
        Me.Controls.Add(btnAhPuch)
        Me.Controls.Add(btnChaac)
        Me.Controls.Add(btnIxChel)
        Me.Controls.Add(btnKinichKakmo)
        Me.Controls.Add(btnKukulkan)
        Me.Controls.Add(btnYumKaax)
        Me.Controls.Add(btnCamazotz)
        Me.Controls.Add(btnItzamna)
        Me.Controls.Add(btnIxTab)
        Me.Controls.Add(btnKinichAhau)
        Me.Controls.Add(btnBolonDzacab)
        Me.Controls.Add(btnEkChuah)
        Me.Controls.Add(btnHuracan)
        Me.Controls.Add(btnPawahtun)

        imgBackground.SendToBack()

        '----------- Configuración de Ventana ------------'
        AddHandler Me.Resize, AddressOf OrganizeAndResize
        OrganizeAndResize()

    End Sub



    '--------------------- Funciones y Subrutinas ----------------------'
    'Subrutina para Organizar y Reescalar
    Private Sub OrganizeAndResize()
        Dim w As Integer = Me.Width
        Dim h As Integer = Me.Height

        Dim btnSize = New Size(w / 12, w / 12)
        Dim centerX As Integer = w - btnSize.Width
        Dim centerY As Integer = h - btnSize.Height

        'AhMuzenCab
        btnAhMuzenCab.Size = btnSize
        btnAhMuzenCab.Location = New Point(centerX * 0.4, centerY * 0.5)
        btnAhMuzenCab.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.AhMuzenCabGif.gif", btnSize)
        'AhPuch
        btnAhPuch.Size = btnSize
        btnAhPuch.Location = New Point(centerX * 0.49, centerY * 0.87)
        btnAhPuch.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.AhPuchGif.gif", btnSize)
        'Chaac
        btnChaac.Size = btnSize
        btnChaac.Location = New Point(centerX * 0.72, centerY * 0.67)
        btnChaac.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.ChaacGif.gif", btnSize)
        'IxChel
        btnIxChel.Size = btnSize
        btnIxChel.Location = New Point(centerX * 0.26, centerY * 0.3)
        btnIxChel.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.IxChelGif.gif", btnSize)
        'KinichKakmo
        btnKinichKakmo.Size = btnSize
        btnKinichKakmo.Location = New Point(centerX * 0.78, centerY * 0.5)
        btnKinichKakmo.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.KinichKakmoGif.gif", btnSize)
        'Kukulcan
        btnKukulkan.Size = btnSize
        btnKukulkan.Location = New Point(centerX * 0.49, centerY * 0.3)
        btnKukulkan.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.KukulkanGif.gif", btnSize)
        'YumKaax
        btnYumKaax.Size = btnSize
        btnYumKaax.Location = New Point(centerX * 0.2, centerY * 0.5)
        btnYumKaax.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.YumKaaxGif.gif", btnSize)
        'Camatzotz
        btnCamazotz.Size = btnSize
        btnCamazotz.Location = New Point(centerX * 0.63, centerY * 0.83)
        btnCamazotz.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.CamazotzGif.gif", btnSize)
        'Itzamná
        btnItzamna.Size = btnSize
        btnItzamna.Location = New Point(centerX * 0.4, centerY * 0.13)
        btnItzamna.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.ItzamnaGif.gif", btnSize)
        'Ix Tab
        btnIxTab.Size = btnSize
        btnIxTab.Location = New Point(centerX * 0.35, centerY * 0.83)
        btnIxTab.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.IxTabGif.gif", btnSize)
        'Kinich Ahau
        btnKinichAhau.Size = btnSize
        btnKinichAhau.Location = New Point(centerX * 0.58, centerY * 0.13)
        btnKinichAhau.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.KinichAhauGif.gif", btnSize)
        'Bolon Dzacab
        btnBolonDzacab.Size = btnSize
        btnBolonDzacab.Location = New Point(centerX * 0.72, centerY * 0.3)
        btnBolonDzacab.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.BolonDzacabGif.gif", btnSize)
        'Ek Chuah
        btnEkChuah.Size = btnSize
        btnEkChuah.Location = New Point(centerX * 0.58, centerY * 0.5)
        btnEkChuah.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.EkChuahGif.gif", btnSize)
        'Huracán
        btnHuracan.Size = btnSize
        btnHuracan.Location = New Point(centerX * 0.26, centerY * 0.67)
        btnHuracan.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.HuracanGif.gif", btnSize)
        'Pawahtun
        btnPawahtun.Size = btnSize
        btnPawahtun.Location = New Point(centerX * 0.49, centerY * 0.67)
        btnPawahtun.Image = ResourceManager.Instance.ResizeGIF("ProyectoFinalVB.PawahtunGif.gif", btnSize)

    End Sub

    'Subrutina para Configurar Rápidamente un botón
    Private Sub ConfigureButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.BackColor = Color.Chocolate
        btn.FlatAppearance.BorderColor = Color.Brown
        btn.FlatAppearance.BorderSize = 10
    End Sub


    '----------------------------- Eventos -----------------------------'
    'Evento Click para AhMuzenCab
    Private Sub btnAhMuzenCab_Click(sender As Object, e As EventArgs) Handles btnAhMuzenCab.Click
        Debug.WriteLine("Cargando Ah Muzen Cab...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.AhMuzenCab.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para YumKaax
    Private Sub btnYumKaax_Click(sender As Object, e As EventArgs) Handles btnYumKaax.Click
        Debug.Write("Cargando Yum Kaax...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.YumKaax.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para AhPuch
    Private Sub btnAhPuch_Click(sender As Object, e As EventArgs) Handles btnAhPuch.Click
        Debug.Write("Cargando Ah Puch...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.AhPuch.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    Private Sub btnItzamna_Click(sender As Object, e As EventArgs) Handles btnItzamna.Click
        Debug.Write("Cargando Itzamna...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.Itzamna.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para Chaac
    Private Sub btnChaac_Click(sender As Object, e As EventArgs) Handles btnChaac.Click
        Debug.Write("Cargando Chaac...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.Chaac.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para IxChel
    Private Sub btnIxChel_Click(sender As Object, e As EventArgs) Handles btnIxChel.Click
        Debug.Write("Cargando Ix Chel...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.IxChel.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para KinichKakmo
    Private Sub btnKinichKakmo_Click(sender As Object, e As EventArgs) Handles btnKinichKakmo.Click
        Debug.Write("Cargando Kinich Kakmo...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.KinichKakmo.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para Kukulkan
    Private Sub btnKukulkan_Click(sender As Object, e As EventArgs) Handles btnKukulkan.Click
        Debug.Write("Cargando Kukulkan...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.Kukulkan.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para Camazotz
    Private Sub btnCamazotz_Click(sender As Object, e As EventArgs) Handles btnCamazotz.Click
        Debug.Write("Cargando Camazotz...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.Camazotz.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para IxTab
    Private Sub btnIxTab_Click(sender As Object, e As EventArgs) Handles btnIxTab.Click
        Debug.Write("Cargando Ix Tab...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.IxTab.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para KinichAhau
    Private Sub btnKinichAhau_Click(sender As Object, e As EventArgs) Handles btnKinichAhau.Click
        Debug.Write("Cargando Kinich Ahau...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.KinichAhau.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para BolonDzacab
    Private Sub btnBolonDzacab_Click(sender As Object, e As EventArgs) Handles btnBolonDzacab.Click
        Debug.Write("Cargando Bolon Dzacab...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.BolonDzacab.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para EkChuah
    Private Sub btnEkChuah_Click(sender As Object, e As EventArgs) Handles btnEkChuah.Click
        Debug.Write("Cargando Ek Chuah...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.EkChuah.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para Huracan
    Private Sub btnHuracan_Click(sender As Object, e As EventArgs) Handles btnHuracan.Click
        Debug.Write("Cargando Huracan...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.Huracan.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

    'Evento Click para Pawahtun
    Private Sub btnPawahtun_Click(sender As Object, e As EventArgs) Handles btnPawahtun.Click
        Debug.Write("Cargando Pawahtun...")
        Dim godData As GodData = GodRepository.LoadGod("ProyectoFinalVB.Pawahtun.txt")
        Dim godView As New GodView(form, godData)
        form.LoadView(godView)
    End Sub

End Class
