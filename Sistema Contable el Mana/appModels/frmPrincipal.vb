Public Class frmPrincipal

    Private Sub btTest_Click(sender As Object, e As EventArgs) Handles btTest.Click
        Try
            Using db As New CodeFirst
                If db.Database.Exists() Then
                    MessageBox.Show("Se establecio conexión correctamente!!")
                Else
                    If MessageBox.Show("¿No se encuentra la base de datos desea crearla?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        db.Database.CreateIfNotExists()
                        MessageBox.Show("Se creó correctamente!!")
                    End If
                End If
                Try
                    If db.Database.Exists Then
                        Dim c = db.Cuentas.Count
                        If c = 0 Then
                            If MessageBox.Show("¿Desea cargar información de inicio?", "Pregunta de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Dim cuenta As New appModels.Cuenta
                                'CUENTA DE ACTIVOS
                                cuenta.IDCuenta = Guid.NewGuid
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Reg = DateTime.Now
                                cuenta.FMod = cuenta.Reg
                                cuenta.Nivel = 1
                                cuenta.IDCuentaGrupo = Nothing
                                'Inicio codigo
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Grupo = "1"
                                cuenta.SubGrupo = ""
                                cuenta.Mayor = ""
                                cuenta.SubMayor = ""
                                cuenta.SubSubMayor = ""
                                cuenta.UltimoNivel = ""
                                'Fin codigo
                                cuenta.Descripcion = "ACTIVO"
                                cuenta.Naturaleza = True
                                cuenta.Operacion = True
                                cuenta.IsProduct = False
                                cuenta.Deber = 0
                                cuenta.Haber = 0
                                cuenta.Saldo = 0
                                cuenta.Entrada = 0
                                cuenta.Salida = 0
                                cuenta.Existencia = 0
                                cuenta.Activo = True
                                db.Cuentas.Add(cuenta)

                                'CUENTA DE PASIVOS
                                cuenta = New appModels.Cuenta()
                                cuenta.IDCuenta = Guid.NewGuid
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Reg = DateTime.Now
                                cuenta.FMod = cuenta.Reg
                                cuenta.Nivel = 1
                                cuenta.IDCuentaGrupo = Nothing
                                'Inicio codigo
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Grupo = "2"
                                cuenta.SubGrupo = ""
                                cuenta.Mayor = ""
                                cuenta.SubMayor = ""
                                cuenta.SubSubMayor = ""
                                cuenta.UltimoNivel = ""
                                'Fin codigo
                                cuenta.Descripcion = "PASIVO"
                                cuenta.Naturaleza = False
                                cuenta.Operacion = True
                                cuenta.IsProduct = False
                                cuenta.Deber = 0
                                cuenta.Haber = 0
                                cuenta.Saldo = 0
                                cuenta.Entrada = 0
                                cuenta.Salida = 0
                                cuenta.Existencia = 0
                                cuenta.Activo = True
                                db.Cuentas.Add(cuenta)

                                'CUENTA DE CAPITAL
                                cuenta = New appModels.Cuenta()
                                cuenta.IDCuenta = Guid.NewGuid
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Reg = DateTime.Now
                                cuenta.FMod = cuenta.Reg
                                cuenta.Nivel = 1
                                cuenta.IDCuentaGrupo = Nothing
                                'Inicio codigo
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Grupo = "3"
                                cuenta.SubGrupo = ""
                                cuenta.Mayor = ""
                                cuenta.SubMayor = ""
                                cuenta.SubSubMayor = ""
                                cuenta.UltimoNivel = ""
                                'Fin codigo
                                cuenta.Descripcion = "CAPITAL"
                                cuenta.Naturaleza = False
                                cuenta.Operacion = True
                                cuenta.IsProduct = False
                                cuenta.Deber = 0
                                cuenta.Haber = 0
                                cuenta.Saldo = 0
                                cuenta.Entrada = 0
                                cuenta.Salida = 0
                                cuenta.Existencia = 0
                                cuenta.Activo = True
                                db.Cuentas.Add(cuenta)

                                'CUENTA DE INGRESOS
                                cuenta = New appModels.Cuenta()
                                cuenta.IDCuenta = Guid.NewGuid
                                cuenta.Reg = DateTime.Now
                                cuenta.FMod = cuenta.Reg
                                cuenta.Nivel = 1
                                cuenta.IDCuentaGrupo = Nothing
                                'Inicio codigo
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Grupo = "4"
                                cuenta.SubGrupo = ""
                                cuenta.Mayor = ""
                                cuenta.SubMayor = ""
                                cuenta.SubSubMayor = ""
                                cuenta.UltimoNivel = ""
                                'Fin codigo
                                cuenta.Descripcion = "INGRESOS"
                                cuenta.Naturaleza = False
                                cuenta.Operacion = True
                                cuenta.IsProduct = False
                                cuenta.Deber = 0
                                cuenta.Haber = 0
                                cuenta.Saldo = 0
                                cuenta.Entrada = 0
                                cuenta.Salida = 0
                                cuenta.Existencia = 0
                                cuenta.Activo = True
                                db.Cuentas.Add(cuenta)

                                'CUENTA DE COSTOS DE VENTA
                                cuenta = New appModels.Cuenta()
                                cuenta.IDCuenta = Guid.NewGuid
                                cuenta.Reg = DateTime.Now
                                cuenta.FMod = cuenta.Reg
                                cuenta.Nivel = 1
                                cuenta.IDCuentaGrupo = Nothing
                                'Inicio codigo
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Grupo = "5"
                                cuenta.SubGrupo = ""
                                cuenta.Mayor = ""
                                cuenta.SubMayor = ""
                                cuenta.SubSubMayor = ""
                                cuenta.UltimoNivel = ""
                                'Fin codigo
                                cuenta.Descripcion = "COSTOS DE VENTA"
                                cuenta.Naturaleza = True
                                cuenta.Operacion = True
                                cuenta.IsProduct = False
                                cuenta.Deber = 0
                                cuenta.Haber = 0
                                cuenta.Saldo = 0
                                cuenta.Entrada = 0
                                cuenta.Salida = 0
                                cuenta.Existencia = 0
                                cuenta.Activo = True
                                db.Cuentas.Add(cuenta)

                                'CUENTA DE GASTOS
                                cuenta = New appModels.Cuenta()
                                cuenta.IDCuenta = Guid.NewGuid
                                cuenta.Reg = DateTime.Now
                                cuenta.FMod = cuenta.Reg
                                cuenta.Nivel = 1
                                cuenta.IDCuentaGrupo = Nothing
                                'Inicio codigo
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Grupo = "6"
                                cuenta.SubGrupo = ""
                                cuenta.Mayor = ""
                                cuenta.SubMayor = ""
                                cuenta.SubSubMayor = ""
                                cuenta.UltimoNivel = ""
                                'Fin codigo
                                cuenta.Descripcion = "GASTOS"
                                cuenta.Naturaleza = True
                                cuenta.Operacion = True
                                cuenta.IsProduct = False
                                cuenta.Deber = 0
                                cuenta.Haber = 0
                                cuenta.Saldo = 0
                                cuenta.Entrada = 0
                                cuenta.Salida = 0
                                cuenta.Existencia = 0
                                cuenta.Activo = True
                                db.Cuentas.Add(cuenta)

                                'CUENTA DE INGRESOS
                                cuenta = New appModels.Cuenta()
                                cuenta.IDCuenta = Guid.NewGuid
                                cuenta.Reg = DateTime.Now
                                cuenta.FMod = cuenta.Reg
                                cuenta.Nivel = 1
                                cuenta.IDCuentaGrupo = Nothing
                                'Inicio codigo
                                cuenta.IdGrupo = cuenta.IDCuenta
                                cuenta.Grupo = "7"
                                cuenta.SubGrupo = ""
                                cuenta.Mayor = ""
                                cuenta.SubMayor = ""
                                cuenta.SubSubMayor = ""
                                cuenta.UltimoNivel = ""
                                'Fin codigo
                                cuenta.Descripcion = "INGRESOS FINANCIEROS"
                                cuenta.Naturaleza = False
                                cuenta.Operacion = True
                                cuenta.IsProduct = False
                                cuenta.Deber = 0
                                cuenta.Haber = 0
                                cuenta.Saldo = 0
                                cuenta.Entrada = 0
                                cuenta.Salida = 0
                                cuenta.Existencia = 0
                                cuenta.Activo = True
                                db.Cuentas.Add(cuenta)

                                db.SaveChanges()
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
                
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
