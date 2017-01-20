Imports System.IO
Imports appModels

Public Module BackUp

    Private DefaultPath As String = My.Application.Info.DirectoryPath & "\SCE Backup"

    Public Sub SelectPath(Optional ByVal NewPath As String = "")
        Try
            If String.IsNullOrEmpty(NewPath) Then
                NewPath = DefaultPath
                If Not Directory.Exists(NewPath) Then
                    Directory.CreateDirectory(NewPath)
                End If
            ElseIf NewPath = "" Then
                NewPath = DefaultPath
                If Not Directory.Exists(NewPath) Then
                    Directory.CreateDirectory(NewPath)
                End If
            End If

            If Not Directory.Exists(NewPath) Then
                Throw New Exception("El Directorio, '" & NewPath & "', especificado no existe o está inaccesible.")
            End If

            Using lector As New StreamWriter(My.Application.Info.DirectoryPath & "\" & Config.FilePathBackUp, append:=False)
                'lector.Write(SecurityCryptography.PasswordEnconding(NewPath))
                lector.Write(NewPath)
                lector.Flush()
                lector.Close()
            End Using
        Catch ex As Exception
            Throw New Exception("Ha ocurrido un error. Intente nuevamente. Descripción: " & ex.Message)
        End Try
    End Sub

    Public Function Path() As String
        If File.Exists(My.Application.Info.DirectoryPath & "\" & Config.FilePathBackUp) Then
            Using lector As New StreamReader(My.Application.Info.DirectoryPath & "\" & Config.FilePathBackUp)
                Try
                    'Dim folder = SecurityCryptography.PasswordDecoding(lector.ReadLine())
                    Dim folder = lector.ReadLine()
                    If Not Directory.Exists(folder) Then
                        Throw New Exception("El Directorio '" & folder & "' especificado no existe o está inaccesible.")
                    End If

                    Return folder
                Catch
                End Try
            End Using
        End If

        BackUp.SelectPath()
        Return DefaultPath
    End Function

    Public Sub BackUpCreate(ByVal Path As String)
        Try
            Using db As New CodeFirst
                If Not Directory.Exists(Path) Then
                    Throw New Exception("No se encuentra el Directorio '" & Path & "' o esta inaccesible.")
                End If
                Dim file As New StreamWriter(Path & "\" & Guid.NewGuid.ToString() & ".sce")
                file.WriteLine("----UsersAccounts----")
                For Each c In db.UsersAccounts
                    file.WriteLine("INSERT INTO UserAccount (" + _
                                   "IDUser, " + _
                                   "N, " + _
                                   "Reg, " + _
                                   "FMod, " + _
                                   "Name, " + _
                                   "SurnName, " + _
                                   "UserName, " + _
                                   "UserPass, " + _
                                   "Activo " + _
                                   ") VALUES ( " + _
                                   "'" + c.IDUser.ToString() + "', " + _
                                   c.N.ToString() + "," + _
                                   "'" + c.Reg.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.FMod.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.Name + "', " + _
                                   "'" + c.SurnName + "', " + _
                                   "'" + c.UserName + "', " + _
                                   "'" + c.UserPass + "', " + _
                                   If(c.Activo, "1", "0") + _
                                   ")" _
                    )
                Next
                file.WriteLine()
                file.WriteLine("----Cuenta----")
                For Each c In db.Cuentas

                    file.WriteLine("INSERT INTO Cuenta (" + _
                                   "IDCuenta, " + _
                                   "N, " + _
                                   "Reg, " + _
                                   "FMod, " + _
                                   "Nivel, " + _
                                   "IDCuentaGrupo, " + _
                                   "CodigoSuperior, " + _
                                   "IdGrupo, " + _
                                   "Grupo, " + _
                                   "IdSubGrupo, " + _
                                   "SubGrupo, " + _
                                   "IdMayor, " + _
                                   "Mayor, " + _
                                   "IdSubMayor, " + _
                                   "SubMayor, " + _
                                   "IdSubSubMayor, " + _
                                   "SubSubMayor, " + _
                                   "IdUltimoNivel, " + _
                                   "UltimoNivel, " + _
                                   "Descripcion, " + _
                                   "Naturaleza, " + _
                                   "Operacion, " + _
                                   "Deber, " + _
                                   "Haber, " + _
                                   "Saldo, " + _
                                   "IsProduct, " + _
                                   "Entrada, " + _
                                   "Salida, " + _
                                   "Existencia, " + _
                                   "Costo, " + _
                                   "Activo " + _
                                   ") VALUES ( " + _
                                   "'" + c.IDCuenta.ToString() + "', " + _
                                   c.N.ToString() + "," + _
                                   "'" + c.Reg.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.FMod.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.IdGrupo.ToString() + "', " + _
                                   "'" + c.Grupo + "', " + _
                                   "'" + c.IdSubGrupo.ToString() + "', " + _
                                   "'" + c.SubGrupo + "', " + _
                                   "'" + c.IdMayor.ToString() + "', " + _
                                   "'" + c.Mayor + "', " + _
                                   "'" + c.IdSubMayor.ToString() + "', " + _
                                   "'" + c.SubMayor + "', " + _
                                   "'" + c.IdSubSubMayor.ToString() + "', " + _
                                   "'" + c.SubSubMayor + "', " + _
                                   "'" + c.IdUltimoNivel.ToString() + "', " + _
                                   "'" + c.UltimoNivel + "', " + _
                                   "'" + c.Descripcion + "', " + _
                                   If(c.Naturaleza, "1", "0") + ", " + _
                                   If(c.Operacion, "1", "0") + ", " + _
                                   c.Deber.ToString() + "," + _
                                   c.Haber.ToString() + "," + _
                                   c.Saldo.ToString() + "," + _
                                   If(c.IsProduct, "1", "0") + ", " + _
                                   c.Entrada.ToString() + "," + _
                                   c.Salida.ToString() + "," + _
                                   c.Existencia.ToString() + "," + _
                                   c.Costo.ToString() + "," + _
                                   If(c.Activo, "1", "0") + _
                                   ")" _
                    )
                Next

                file.WriteLine()
                file.WriteLine("----ComprobanteDiario----")
                For Each c In db.ComprobantesDiarios


                    file.WriteLine("INSERT INTO ComprobanteDiario (" + _
                                   "IDComprobante, " + _
                                   "N, " + _
                                   "Reg, " + _
                                   "FMod, " + _
                                   "Fecha, " + _
                                   "Concepto, " + _
                                   "Referencia, " + _
                                   "Haber, " + _
                                   "Deber, " + _
                                   "Activo " + _
                                   ") VALUES ( " + _
                                   "'" + c.IDComprobante.ToString() + "', " + _
                                   c.N.ToString() + "," + _
                                   "'" + c.Reg.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.FMod.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.Fecha.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.Concepto + "', " + _
                                   "'" + c.Referencia + "', " + _
                                   c.Haber.ToString() + ", " + _
                                   c.Deber.ToString() + ", " + _
                                   If(c.Activo, "1", "0") + _
                                   ")" _
                    )
                Next

                file.WriteLine()
                file.WriteLine("----ComprobanteDiarioDetalle----")
                For Each c In db.ComprobantesDiariosDetalles


                    file.WriteLine("INSERT INTO ComprobanteDiarioDetalle (" + _
                                   "IDDetalle, " + _
                                   "N, " + _
                                   "Reg, " + _
                                   "FMod, " + _
                                   "IDCuenta, " + _
                                   "IDComprobante, " + _
                                   "Deber, " + _
                                   "Haber, " + _
                                   "Saldo, " + _
                                   "Entrada, " + _
                                   "Salida, " + _
                                   "Existencia, " + _
                                   "EntradaProd, " + _
                                   "SalidaProd, " + _
                                   "ExistenciaProd, " + _
                                   "Costo, " + _
                                   "CostoPromedio, " + _
                                   "IDCuentaGrupo, " + _
                                   "DeberGrupo, " + _
                                   "HaberGrupo, " + _
                                   "SaldoGrupo, " + _
                                   "IDCuentaSubGrupo, " + _
                                   "DeberSubGrupo, " + _
                                   "HaberSubGrupo, " + _
                                   "SaldoSubGrupo, " + _
                                   "IDCuentaMayor, " + _
                                   "DeberMayor, " + _
                                   "HaberMayor, " + _
                                   "SaldoMayor, " + _
                                   "IDCuentaSubMayor, " + _
                                   "DeberSubMayor, " + _
                                   "HaberSubMayor, " + _
                                   "SaldoSubMayor, " + _
                                   "IDCuentaSubSubMayor, " + _
                                   "DeberSubSubMayor, " + _
                                   "HaberSubSubMayor, " + _
                                   "SaldoSubSubMayor, " + _
                                   "DeberUltimoNivel, " + _
                                   "HaberUltimoNivel, " + _
                                   "SaldoUltimoNivel " + _
                                   ") VALUES ( " + _
                                   "'" + c.IDComprobante.ToString() + "', " + _
                                   c.N.ToString() + "," + _
                                   "'" + c.Reg.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   "'" + c.FMod.ToString("yyyy/MM/dd HH:mm:ss") + "'," + _
                                   c.Deber.ToString() + ", " + _
                                   c.Haber.ToString() + ", " + _
                                   c.Saldo.ToString() + ", " + _
                                   c.Entrada.ToString() + ", " + _
                                   c.Salida.ToString() + ", " + _
                                   c.Existencia.ToString() + ", " + _
                                   c.EntradaProd.ToString() + ", " + _
                                   c.SalidaProd.ToString() + ", " + _
                                   c.ExistenciaProd.ToString() + ", " + _
                                   c.Costo.ToString() + ", " + _
                                   c.CostoPromedio.ToString() + ", " + _
                                   "'" + c.IDCuentaGrupo.ToString() + "', " + _
                                   c.DeberGrupo.ToString() + ", " + _
                                   c.HaberGrupo.ToString() + ", " + _
                                   c.SaldoGrupo.ToString() + ", " + _
                                   "'" + c.IDCuentaSubGrupo.ToString() + "', " + _
                                   c.DeberSubGrupo.ToString() + ", " + _
                                   c.HaberSubGrupo.ToString() + ", " + _
                                   c.SaldoSubGrupo.ToString() + ", " + _
                                   "'" + c.IDCuentaMayor.ToString() + "', " + _
                                   c.DeberMayor.ToString() + ", " + _
                                   c.HaberMayor.ToString() + ", " + _
                                   c.SaldoMayor.ToString() + ", " + _
                                   "'" + c.IDCuentaSubMayor.ToString() + "', " + _
                                   c.DeberSubMayor.ToString() + ", " + _
                                   c.HaberSubMayor.ToString() + ", " + _
                                   c.SaldoSubMayor.ToString() + ", " + _
                                   "'" + c.IDCuentaSubSubMayor.ToString() + "', " + _
                                   c.DeberSubSubMayor.ToString() + ", " + _
                                   c.HaberSubSubMayor.ToString() + ", " + _
                                   c.SaldoSubSubMayor.ToString() + ", " + _
                                   c.DeberUltimoNivel.ToString() + ", " + _
                                   c.HaberUltimoNivel.ToString() + ", " + _
                                   c.SaldoUltimoNivel.ToString() + _
                                   ")" _
                    )
                Next

                file.Flush()
                file.Close()

            End Using
        Catch ex As Exception
            Throw New Exception("No se ha podido crear el Respaldo. Intente de nuevo. Descripción: " & ex.Message)
        End Try
    End Sub

    Public Function List() As List(Of BackUpEntity)
        Dim lst As New List(Of BackUpEntity)

        For Each c In DirectoryInfo.GetFiles(Path)

            lst.Add(
                c.
            )
        Next

        Return lst
    End Function

End Module
