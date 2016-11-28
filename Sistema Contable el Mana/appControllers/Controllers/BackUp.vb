Imports System.IO
Imports appModels

Public Module BackUp

    Private ExplorerBackup As String = ""


    Public Function Path() As String
        If File.Exists(My.Application.Info.DirectoryPath & ExplorerBackup) Then
            Using lector As New StreamReader(My.Application.Info.DirectoryPath & ExplorerBackup)
                Try
                    Dim folder = SecurityCryptography.PasswordDecoding(lector.ReadLine())
                    Return folder
                Catch
                    Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\SCE Backup")
                End Try
            End Using
        Else
            Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\SCE Backup")
        End If

        Return My.Application.Info.DirectoryPath & "\SCE Backup"
    End Function

    Public Sub BackUpCreate(ByVal Path As String)
        Try
            Using db As New CodeFirst
                If Not Directory.Exists(Path) Then
                    Throw New Exception("No se encuentra el Directorio '" & Path & "' o esta inaccesible.")
                End If
                Dim file As New StreamWriter(Path & Guid.NewGuid.ToString() & ".sce")
                For Each c In db.UsersAccounts
                    file.WriteLine("----UsersAccounts----")
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

                For Each c In db.Cuentas
                    file.WriteLine("----Cuenta----")

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

                For Each c In db.ComprobantesDiarios
                    file.WriteLine("----ComprobanteDiario----")

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
                                   c.Haber + ", " + _
                                   c.Deber + ", " + _
                                   If(c.Activo, "1", "0") + _
                                   ")" _
                    )
                Next

                For Each c In db.ComprobantesDiariosDetalles
                    file.WriteLine("----ComprobanteDiarioDetalle----")

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
                                   c.Deber + ", " + _
                                   c.Haber + ", " + _
                                   c.Saldo + ", " + _
                                   c.Entrada + ", " + _
                                   c.Salida + ", " + _
                                   c.Existencia + ", " + _
                                   c.EntradaProd + ", " + _
                                   c.SalidaProd + ", " + _
                                   c.ExistenciaProd + ", " + _
                                   c.Costo + ", " + _
                                   c.CostoPromedio + ", " + _
                                   "'" + c.IDCuentaGrupo.ToString() + "', " + _
                                   c.DeberGrupo + ", " + _
                                   c.HaberGrupo + ", " + _
                                   c.SaldoGrupo + ", " + _
                                   "'" + c.IDCuentaSubGrupo.ToString() + "', " + _
                                   c.DeberSubGrupo + ", " + _
                                   c.HaberSubGrupo + ", " + _
                                   c.SaldoSubGrupo + ", " + _
                                   "'" + c.IDCuentaMayor.ToString() + "', " + _
                                   c.DeberMayor + ", " + _
                                   c.HaberMayor + ", " + _
                                   c.SaldoMayor + ", " + _
                                   "'" + c.IDCuentaSubMayor.ToString() + "', " + _
                                   c.DeberSubMayor + ", " + _
                                   c.HaberSubMayor + ", " + _
                                   c.SaldoSubMayor + ", " + _
                                   "'" + c.IDCuentaSubSubMayor.ToString() + "', " + _
                                   c.DeberSubSubMayor + ", " + _
                                   c.HaberSubSubMayor + ", " + _
                                   c.SaldoSubSubMayor + ", " + _
                                   c.DeberUltimoNivel + ", " + _
                                   c.HaberUltimoNivel + ", " + _
                                   c.SaldoUltimoNivel + _
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
End Module
