Imports System.IO
Imports System.Reflection
Imports System.Text

Public Class GodRepository

    'Cargar Dios desde Recurso Incrustado
    Public Shared Function LoadGod(resourcePath As String) As GodData
        Dim data As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        Dim currentKey As String = Nothing
        Dim sb As New StringBuilder()

        'Leer Archivo Incrustado
        Dim asm As Assembly = Assembly.GetExecutingAssembly()
        Using stream As Stream = asm.GetManifestResourceStream(resourcePath)
            If stream Is Nothing Then
                Debug.WriteLine("No se encontró Recurso: " & resourcePath)
                Return Nothing
            End If

            Using reader As New StreamReader(stream, Encoding.UTF8)
                While Not reader.EndOfStream
                    Dim lineRaw As String = reader.ReadLine()
                    Dim line As String = lineRaw.Trim()

                    If line = "" Then Continue While

                    If line.EndsWith("=") AndAlso line.Length > 1 Then
                        If currentKey IsNot Nothing Then
                            data(currentKey) = sb.ToString().Trim()
                            sb.Clear()
                        End If

                        currentKey = line.TrimEnd("="c)
                    Else
                        If currentKey IsNot Nothing Then
                            If sb.Length > 0 Then sb.AppendLine()
                            sb.Append(line)
                        End If
                    End If
                End While

                If currentKey IsNot Nothing Then
                    data(currentKey) = sb.ToString().Trim()
                End If

            End Using
        End Using

        'Crear Objeto GodData
        Dim god As New GodData With {
            .Name = GetValue(data, "NAME"),
            .Title = GetValue(data, "TITLE"),
            .Domain = GetValue(data, "DOMAIN"),
            .Symbology = GetValue(data, "SYMBOLOGY"),
            .Appearance = GetValue(data, "APPEARANCE"),
            .Description = Flatten(GetValue(data, "DESCRIPTION")),
            .gifName = GetValue(data, "GIFNAME")
        }

        Return god
    End Function

    'Obtener Valores (Con Excepciones)
    Private Shared Function GetValue(data As Dictionary(Of String, String), key As String) As String
        If data.ContainsKey(key) Then
            Return data(key)
        Else
            Debug.WriteLine("Advertencia: Clave no encontrada: " & key)
            Return "(No especificado)"
        End If
    End Function

    'Aplanar texto
    Private Shared Function Flatten(text As String) As String
        ' Elimina saltos de línea y reemplaza múltiples espacios por uno solo
        Return System.Text.RegularExpressions.Regex.Replace(text.Replace(vbCrLf, " ").Replace(vbLf, " "), "\s{2,}", " ").Trim()
    End Function

End Class
