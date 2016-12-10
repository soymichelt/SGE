Imports System.IO

Public Class frmHelp

    Sub LoadFile()
        Try
            If File.Exists(My.Application.Info.DirectoryPath & "\Help.pdf") Then
                pdfHelp.src = My.Application.Info.DirectoryPath & "\Help.pdf"
                pdfHelp.setZoom(90)
            Else
                Config.MsgErr("Al parecer el Archivo de Ayuda ha sido eliminado. " & My.Application.Info.DirectoryPath & "\Help.pdf")
            End If
        Catch ex As Exception
            Config.MsgErr(ex.Message)
        End Try
    End Sub

    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LoadFile()
    End Sub
End Class