Imports System.IO
Imports appModels

Public Module BackUp

    Public Sub BackUpCreate(ByVal Path As String)
        Try
            Using db As New CodeFirst
                If Not Directory.Exists(Path) Then
                    Throw New Exception("No se encuentra el Directorio '" & Path & "' o esta inaccesible.")
                End If
                Dim file As New StreamWriter(Path)
            End Using
        Catch ex As Exception
            Throw New Exception("No se ha podido crear el Respaldo. Intente de nuevo. Descripción: " & ex.Message)
        End Try
    End Sub
End Module
