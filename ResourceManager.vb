Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports ImageMagick

Public Class ResourceManager
    '---------------------------- Variables ----------------------------'
    Private Shared _instance As ResourceManager
    Private fontCollection As New PrivateFontCollection()
    Private fontCache As New Dictionary(Of String, FontFamily)

    '--------------------- Constructor e Inicializador ----------------------'
    'Constructor
    Private Sub New()
        LoadFont("ProyectoFinalVB.Micro_Chat.ttf")
        LoadFont("ProyectoFinalVB.Tiny_Talk.ttf")
        LoadFont("ProyectoFinalVB.Aztek_Pixel.ttf")

        fontCache("Micro_Chat") = fontCollection.Families.FirstOrDefault(Function(f) f.Name.Contains("Micro"))
        fontCache("Tiny_Talk") = fontCollection.Families.FirstOrDefault(Function(f) f.Name.Contains("Tiny"))
        fontCache("Aztek_Pixel") = fontCollection.Families.FirstOrDefault(Function(f) f.Name.Contains("Aztek"))

        Debug.WriteLine("Familias Actuales: ")
        For Each fam In fontCollection.Families
            Debug.WriteLine(" - " & fam.Name)
        Next
    End Sub


    '--------------------- Funciones y Subrutinas ----------------------'
    ''Función para obtener la instancia del ResourceManager
    Public Shared ReadOnly Property Instance As ResourceManager
        Get
            If _instance Is Nothing Then
                _instance = New ResourceManager()
            End If
            Return _instance
        End Get
    End Property


    'Función para obtener el ResourceStream
    Private Function GetResourceStream(resourceName As String) As IO.Stream
        Dim assembly As Assembly = Assembly.GetExecutingAssembly()
        Return assembly.GetManifestResourceStream(resourceName)
    End Function


    '--------------------- Funciones de Fuente ----------------------'
    'Cargar Fuente desde Recurso Embebido
    Public Sub LoadFont(resourcePath As String)
        Using stream As IO.Stream = GetResourceStream(resourcePath)
            If stream Is Nothing Then
                Debug.WriteLine("No se pudo encontrar el recurso: " & resourcePath)
                Return
            End If

            Dim fontData(stream.Length - 1) As Byte
            stream.Read(fontData, 0, fontData.Length)

            Dim fontPtr As IntPtr = Marshal.AllocCoTaskMem(fontData.Length)
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length)

            fontCollection.AddMemoryFont(fontPtr, fontData.Length)
            Marshal.FreeCoTaskMem(fontPtr)

            Dim familiesBefore = fontCollection.Families.Length
            fontCollection.AddMemoryFont(fontPtr, fontData.Length)
            Dim familiesAfter = fontCollection.Families.Length

            If familiesAfter > familiesBefore Then
                Dim fam = fontCollection.Families(familiesAfter - 1)
                fontCache(fam.Name) = fam
                Debug.WriteLine("Fuente Cargada con Éxito: " & fam.Name)
            Else
                Debug.WriteLine("No se agregó nueva familia para: " & resourcePath)
            End If
        End Using
    End Sub

    'Obtener la Fuente
    Public Function GetFont(familyName As String, size As Single, style As FontStyle) As Font
        If size <= 0 Then
            Debug.WriteLine("Tamaño de fuente inválido: " & size)
            size = 8
        End If

        If fontCache.ContainsKey(familyName) Then
            Debug.WriteLine("Fuente encontrada en caché: " & familyName)
            Try
                Return New Font(fontCache(familyName), size, style)
            Catch ex As Exception
                Debug.WriteLine("Error al Obtener la fuente: " & ex.Message)
                Return New Font(FontFamily.GenericSansSerif, size, style)
            End Try

        Else
            Debug.WriteLine("Fuente no encontrada en caché: " & familyName)
            Return New Font(FontFamily.GenericSansSerif, size, style)
        End If
    End Function


    '---------------------- Funciones de Imagen ----------------------'
    'Función para obtener una imagen desde un recurso embebido
    Public Function GetImage(resourceName As String) As Image
        Using stream As IO.Stream = GetResourceStream(resourceName)
            If stream Is Nothing Then
                Debug.WriteLine("No se pudo encontrar el recurso de imagen: " & resourceName)
                Return Nothing
            End If
            Return Image.FromStream(stream)
        End Using
    End Function

    'Obtener y Reescalar GIF
    Public Function ResizeGIF(resourceName As String, newSize As Size) As Image
        Dim resizedStream As New IO.MemoryStream()

        Using resourceStream As IO.Stream = GetResourceStream(resourceName)
            If resourceStream Is Nothing Then
                Debug.WriteLine("No se pudo encontrar el recurso del GIF: " & resourceName)
                Return Nothing
            End If

            Using collection As New MagickImageCollection(resourceStream)
                For Each frame As MagickImage In collection
                    ' Forzar escala con NearestNeighbor (mantiene nitidez en pixel art)
                    frame.FilterType = FilterType.Point
                    frame.Resize(CUInt(newSize.Width), CUInt(newSize.Height))

                    ' Asegurar que cada frame tenga el método de eliminación adecuado
                    frame.GifDisposeMethod = GifDisposeMethod.Background
                Next

                ' Guardar el nuevo GIF en memoria
                collection.Write(resizedStream, MagickFormat.Gif)
            End Using
        End Using

        resizedStream.Position = 0
        Return Image.FromStream(resizedStream)
    End Function


End Class
