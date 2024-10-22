﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    'NOTA: este archivo se genera de forma automática; no lo modifique directamente. Para realizar cambios,
    ' o si detecta errores de compilación en este archivo, vaya al Diseñador de proyectos
    ' (vaya a Propiedades del proyecto o haga doble clic en el nodo My Project en el
    ' Explorador de soluciones) y realice cambios en la pestaña Aplicación.
    '
    Partial Friend Class MyApplication
        
        <Global.System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = false
            Me.EnableVisualStyles = true
            Me.SaveMySettingsOnExit = true
            Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
        Protected Overrides Sub OnCreateMainForm()
            Try
                'Se calcula el número de procesos llamados appContable
                Dim prcNum As Integer = Process.GetProcessesByName("appContable").Count

                'Se evalua si el numero de procesos llamados appContable supera 1
                '1 por que al ejecutar la app primero crea el proceso
                If prcNum > 1 Then

                    'Cierra el proceso actual
                    Process.GetProcessById(Process.GetCurrentProcess.Id).Kill()

                End If


                Using db As New appModels.CodeFirst
                    If Not db.Database.Exists() Then
                        Config.MsgErr("No se encuentra la base de datos del sistema. Puede esperar un momento e intentar nuevamente. Si el problema persiste comuníquese con el Administrador de SCE." & vbNewLine & "Att:" & vbNewLine & vbTab & "Administrador del Sistema")
                        Config.ExitApplication()
                    End If
                    appControllers.AccountSecurity.UserDefault()
                End Using


                'appControllers.Config.Nivel = 6
            Catch ex As Exception

                Config.MsgErr(ex.Message)

                Config.ExitApplication()

            End Try

            Me.MainForm = Global.appContable.frmSignin

        End Sub

        Public Property _MainForm As Form
            Get
                Return Me.MainForm
            End Get
            Set(ByVal Value As Form)
                Me.MainForm = Value
            End Set
        End Property
    End Class
End Namespace
