Imports appModels
Public Module Account

    Public Function Save(ByVal Cuenta As Cuenta) As Guid
        If Not Cuenta Is Nothing Then
            Using db As New CodeFirst

                'Codificar
                Cuenta.IDCuenta = Guid.NewGuid

                'Fecha de registro
                Cuenta.Reg = DateTime.Now
                Cuenta.FMod = Cuenta.Reg

                'Inicializar Existencia
                Cuenta.Entrada = 0
                Cuenta.Salida = 0
                Cuenta.Existencia = 0
                Cuenta.Costo = 0

                'Activar producto
                Cuenta.Activo = True

                If Not Cuenta.IDCuentaGrupo Is Nothing Then
                    If Cuenta.Descripcion.Trim = "" Then
                        Throw New Exception("Ingresar la descripción")
                    End If
                    Dim grupo = db.Cuentas.Where(Function(f) f.IDCuenta = Cuenta.IDCuentaGrupo And f.Activo).FirstOrDefault
                    If Not grupo Is Nothing Then
                        If grupo.Nivel = 6 Then
                            Throw New Exception("La cuenta '" & grupo.Descripcion & "' es de ultimo nivel y no puede ser usada como grupo")
                        End If
                        Dim cAcc = ""
                        Dim exist As Cuenta
                        Select Case grupo.Nivel
                            Case 1
                                If Cuenta.SubGrupo.Trim <> "" Then
                                    cAcc = Cuenta.SubGrupo
                                    exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.SubGrupo = Cuenta.SubGrupo And f.Activo).FirstOrDefault
                                Else
                                    Throw New Exception("Ingresar el código de la cuenta Sub Grupo")
                                End If
                            Case 2
                                If Cuenta.Mayor.Trim <> "" Then
                                    cAcc = Cuenta.Mayor
                                    exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.Mayor = Cuenta.Mayor And f.Activo).FirstOrDefault
                                Else
                                    Throw New Exception("Ingresar el código de la cuenta Mayor")
                                End If
                            Case 3
                                If Cuenta.SubMayor.Trim <> "" Then
                                    cAcc = Cuenta.SubMayor
                                    exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.SubMayor = Cuenta.SubMayor And f.Activo).FirstOrDefault
                                Else
                                    Throw New Exception("Ingresar el código de la cuenta Sub Mayor")
                                End If
                            Case 4
                                If Cuenta.SubSubMayor.Trim <> "" Then
                                    cAcc = Cuenta.SubSubMayor
                                    exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.SubSubMayor = Cuenta.SubSubMayor And f.Activo).FirstOrDefault
                                Else
                                    Throw New Exception("Ingresar el código de la cuenta Sub Sub Mayor")
                                End If
                            Case 5
                                If Cuenta.UltimoNivel.Trim <> "" Then
                                    cAcc = Cuenta.UltimoNivel
                                    exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.UltimoNivel = Cuenta.UltimoNivel And f.Activo).FirstOrDefault
                                Else
                                    Throw New Exception("Ingresar el código de la cuenta Ultimo Nivel")
                                End If
                        End Select
                        If exist Is Nothing Then
                            Cuenta.Nivel = grupo.Nivel + 1
                            Select Case grupo.Nivel
                                Case 1
                                    Cuenta.IdGrupo = grupo.IdGrupo
                                    Cuenta.Grupo = grupo.Grupo
                                    Cuenta.IdSubGrupo = Cuenta.IDCuenta
                                    Cuenta.Mayor = ""
                                    Cuenta.SubMayor = ""
                                    Cuenta.SubSubMayor = ""
                                    Cuenta.UltimoNivel = ""
                                Case 2
                                    Cuenta.IdGrupo = grupo.IdGrupo
                                    Cuenta.Grupo = grupo.Grupo
                                    Cuenta.IdSubGrupo = grupo.IdSubGrupo
                                    Cuenta.SubGrupo = grupo.SubGrupo
                                    Cuenta.IdMayor = Cuenta.IDCuenta
                                    Cuenta.SubMayor = ""
                                    Cuenta.SubSubMayor = ""
                                    Cuenta.UltimoNivel = ""
                                Case 3
                                    Cuenta.IdGrupo = grupo.IdGrupo
                                    Cuenta.Grupo = grupo.Grupo
                                    Cuenta.IdSubGrupo = grupo.IdSubGrupo
                                    Cuenta.SubGrupo = grupo.SubGrupo
                                    Cuenta.IdMayor = grupo.IdMayor
                                    Cuenta.Mayor = grupo.Mayor
                                    Cuenta.IdSubMayor = Cuenta.IDCuenta
                                    Cuenta.SubSubMayor = ""
                                    Cuenta.UltimoNivel = ""
                                Case 4
                                    'Se valida que el nivel 5 solo debe ser para HELADERÍA EL MANÁ ó para RESTAURANTE EL MANÁ
                                    If Cuenta.SubMayor.Trim <> Config.Neg1 And Cuenta.SubMayor.Trim <> Config.Neg2 Then
                                        Throw New Exception("El Código de las Cuentas de Nivel '4 - Sub - Mayor' deben ser estrictamente: '" & Config.Neg1 & "' o '" & Config.Neg2 & "'")
                                    End If
                                    Cuenta.IdGrupo = grupo.IdGrupo
                                    Cuenta.Grupo = grupo.Grupo
                                    Cuenta.IdSubGrupo = grupo.IdSubGrupo
                                    Cuenta.SubGrupo = grupo.SubGrupo
                                    Cuenta.IdMayor = grupo.IdMayor
                                    Cuenta.Mayor = grupo.Mayor
                                    Cuenta.IdSubMayor = grupo.IdSubMayor
                                    Cuenta.SubMayor = grupo.SubMayor
                                    Cuenta.IdSubSubMayor = Cuenta.IDCuenta
                                    Cuenta.UltimoNivel = ""
                                Case 5
                                    Cuenta.IdGrupo = grupo.IdGrupo
                                    Cuenta.Grupo = grupo.Grupo
                                    Cuenta.IdSubGrupo = grupo.IdSubGrupo
                                    Cuenta.SubGrupo = grupo.SubGrupo
                                    Cuenta.IdMayor = grupo.IdMayor
                                    Cuenta.Mayor = grupo.Mayor
                                    Cuenta.IdSubMayor = grupo.IdSubMayor
                                    Cuenta.SubMayor = grupo.SubMayor
                                    Cuenta.IdSubSubMayor = grupo.IdSubSubMayor
                                    Cuenta.SubSubMayor = grupo.SubSubMayor
                                    Cuenta.IdUltimoNivel = Cuenta.IDCuenta
                            End Select
                            If Cuenta.Nivel = 6 Then
                                Cuenta.Operacion = True
                            End If
                            db.Cuentas.Add(Cuenta)
                        Else
                            Throw New Exception("Ya existe una cuenta dentro del grupo: '" & grupo.Grupo & grupo.SubGrupo & grupo.Mayor & grupo.SubMayor & grupo.SubSubMayor & grupo.UltimoNivel & " " & grupo.Descripcion & "' con el código " & cAcc & " descrita como '" & exist.Descripcion & "'")
                            exist = Nothing : Cuenta = Nothing : grupo = Nothing
                        End If
                    Else
                        Throw New Exception("No se encuentra este grupo.")
                    End If
                    Try
                        db.SaveChanges()
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                Else
                    Throw New Exception("Ingresar grupo")
                End If
            End Using
        Else
            Throw New Exception("No se mandaron los datos")
        End If
    End Function

    Public Sub Edit(ByVal Cuenta As Cuenta)
        If Not Cuenta Is Nothing Then
            Using db As New CodeFirst
                Dim c = db.Cuentas.Where(Function(f) f.IDCuenta = Cuenta.IDCuenta).FirstOrDefault
                If Not c Is Nothing Then
                    If c.Nivel = 1 Then
                        Throw New Exception("Las cuentas de Nivel 1 no se pueden editar ni eliminar")
                    End If
                    If c.Saldo <> 0 Then
                        Throw New Exception("Para editar una cuenta su saldo debe ser 0.00")
                    End If
                    If db.Cuentas.Where(Function(f) f.IDCuentaGrupo = c.IDCuenta And f.Activo).Count > 0 Then
                        Throw New Exception("No se puede editar una cuenta que tiene asignados Sub Grupos")
                    End If

                    'fecha de modificacion
                    c.FMod = DateTime.Now

                    c.IDCuentaGrupo = Cuenta.IDCuentaGrupo
                    c.Descripcion = Cuenta.Descripcion
                    c.Naturaleza = Cuenta.Naturaleza
                    c.IsProduct = Cuenta.IsProduct

                    If Not Cuenta.IDCuentaGrupo Is Nothing Then
                        If Cuenta.Descripcion.Trim = "" Then
                            Throw New Exception("Ingresar la descripción")
                        End If
                        Dim grupo = db.Cuentas.Where(Function(f) f.IDCuenta = Cuenta.IDCuentaGrupo And f.Activo).FirstOrDefault
                        If Not grupo Is Nothing Then
                            If grupo.Nivel = 6 Then
                                Throw New Exception("La cuenta '" & grupo.Descripcion & "' es de ultimo nivel y no puede ser usada como grupo")
                            End If
                            Dim cAcc = ""
                            Dim exist As Cuenta
                            Select Case grupo.Nivel
                                Case 1
                                    If Cuenta.SubGrupo.Trim <> "" Then
                                        cAcc = Cuenta.SubGrupo
                                        exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.IDCuenta <> c.IDCuenta And f.SubGrupo = Cuenta.SubGrupo And f.Activo).FirstOrDefault
                                    Else
                                        Throw New Exception("Ingresar el código de la cuenta Sub Grupo")
                                    End If
                                Case 2
                                    If Cuenta.Mayor.Trim <> "" Then
                                        cAcc = Cuenta.Mayor
                                        exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.IDCuenta <> c.IDCuenta And f.Mayor = Cuenta.Mayor And f.Activo).FirstOrDefault
                                    Else
                                        Throw New Exception("Ingresar el código de la cuenta Mayor")
                                    End If
                                Case 3
                                    If Cuenta.SubMayor.Trim <> "" Then
                                        cAcc = Cuenta.SubMayor
                                        exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.IDCuenta <> c.IDCuenta And f.SubMayor = Cuenta.SubMayor And f.Activo).FirstOrDefault
                                    Else
                                        Throw New Exception("Ingresar el código de la cuenta Sub Mayor")
                                    End If
                                Case 4
                                    If Cuenta.SubSubMayor.Trim <> "" Then
                                        cAcc = Cuenta.SubSubMayor
                                        exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.IDCuenta <> c.IDCuenta And f.SubSubMayor = Cuenta.SubSubMayor And f.Activo).FirstOrDefault
                                    Else
                                        Throw New Exception("Ingresar el código de la cuenta Sub Sub Mayor")
                                    End If
                                Case 5
                                    If Cuenta.UltimoNivel.Trim <> "" Then
                                        cAcc = Cuenta.UltimoNivel
                                        exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.IDCuenta <> c.IDCuenta And f.UltimoNivel = Cuenta.UltimoNivel And f.Activo).FirstOrDefault
                                    Else
                                        Throw New Exception("Ingresar el código de la cuenta Ultimo Nivel")
                                    End If
                            End Select
                            If exist Is Nothing Then
                                c.Nivel = grupo.Nivel + 1
                                Select Case grupo.Nivel
                                    Case 1
                                        c.IdGrupo = grupo.IdGrupo
                                        c.Grupo = grupo.Grupo
                                        c.IdSubGrupo = Cuenta.IDCuenta
                                        c.SubGrupo = Cuenta.SubGrupo
                                        c.Mayor = ""
                                        c.SubMayor = ""
                                        c.SubSubMayor = ""
                                        c.UltimoNivel = ""
                                    Case 2
                                        c.IdGrupo = grupo.IdGrupo
                                        c.Grupo = grupo.Grupo
                                        c.IdSubGrupo = grupo.IdSubGrupo
                                        c.SubGrupo = grupo.SubGrupo
                                        c.IdMayor = Cuenta.IDCuenta
                                        c.Mayor = Cuenta.Mayor
                                        c.SubMayor = ""
                                        c.SubSubMayor = ""
                                        c.UltimoNivel = ""
                                    Case 3
                                        c.IdGrupo = grupo.IdGrupo
                                        c.Grupo = grupo.Grupo
                                        c.IdSubGrupo = grupo.IdSubGrupo
                                        c.SubGrupo = grupo.SubGrupo
                                        c.IdMayor = grupo.IdMayor
                                        c.Mayor = grupo.Mayor
                                        c.IdSubMayor = Cuenta.IDCuenta
                                        c.SubMayor = Cuenta.SubMayor
                                        c.SubSubMayor = ""
                                        c.UltimoNivel = ""
                                    Case 4
                                        'Se valida que el nivel 5 solo debe ser para HELADERÍA EL MANÁ ó para RESTAURANTE EL MANÁ
                                        If Cuenta.SubSubMayor.Trim <> Config.Neg1 And Cuenta.SubSubMayor.Trim <> Config.Neg2 Then
                                            Throw New Exception("El Código de las Cuentas de Nivel '5 - Sub - Sub - Mayor' deben ser estrictamente: '" & Config.Neg1 & "' o '" & Config.Neg2 & "'")
                                        End If
                                        c.IdGrupo = grupo.IdGrupo
                                        c.Grupo = grupo.Grupo
                                        c.IdSubGrupo = grupo.IdSubGrupo
                                        c.SubGrupo = grupo.SubGrupo
                                        c.IdMayor = grupo.IdMayor
                                        c.Mayor = grupo.Mayor
                                        c.IdSubMayor = grupo.IdSubMayor
                                        c.SubMayor = grupo.SubMayor
                                        c.IdSubSubMayor = Cuenta.IDCuenta
                                        c.SubSubMayor = Cuenta.SubSubMayor
                                        c.UltimoNivel = ""
                                    Case 5
                                        c.IdGrupo = grupo.IdGrupo
                                        c.Grupo = grupo.Grupo
                                        c.IdSubGrupo = grupo.IdSubGrupo
                                        c.SubGrupo = grupo.SubGrupo
                                        c.IdMayor = grupo.IdMayor
                                        c.Mayor = grupo.Mayor
                                        c.IdSubMayor = grupo.IdSubMayor
                                        c.SubMayor = grupo.SubMayor
                                        c.IdSubSubMayor = grupo.IdSubSubMayor
                                        c.SubSubMayor = grupo.SubSubMayor
                                        c.IdUltimoNivel = Cuenta.IDCuenta
                                        c.UltimoNivel = Cuenta.UltimoNivel
                                End Select
                                If Cuenta.Nivel = 6 Then
                                    Cuenta.Operacion = True
                                End If
                                db.Entry(c).State = Entity.EntityState.Modified


                                'recorrer grupos


                                db.SaveChanges()
                            Else
                                exist = Nothing : Cuenta = Nothing : grupo = Nothing
                                Throw New Exception("Ya existe una cuenta dentro del grupo: '" & grupo.Descripcion & "' con el código " & cAcc & " descrita como '" & exist.Descripcion & "'")
                            End If
                        Else
                            Throw New Exception("No se encuentra este grupo.")
                        End If
                        Try
                            db.SaveChanges()
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    Else
                        Throw New Exception("Ingresar grupo")
                    End If
                Else
                    Throw New Exception("No se encuentra esta cuenta")
                End If
            End Using


            'Using db As New CodeFirst
            '    Dim c = db.Cuentas.Where(Function(f) f.IDCuenta = Cuenta.IDCuenta).FirstOrDefault
            '    If Not c Is Nothing Then
            '        If Not c.IDCuentaGrupo Is Nothing Then
            '            c.IDCuentaGrupo = Cuenta.IDCuentaGrupo
            '            c.Codigo = Cuenta.Codigo
            '            c.Descripcion = Cuenta.Descripcion
            '            c.Naturaleza = Cuenta.Naturaleza

            '            If c.Codigo.Trim = "" Then
            '                Throw New Exception("Ingresar el código")
            '            End If
            '            If c.Descripcion.Trim = "" Then
            '                Throw New Exception("Ingresar la descripción")
            '            End If
            '            Dim grupo = db.Cuentas.Where(Function(f) f.IDCuenta = Cuenta.IDCuentaGrupo And f.Activo).FirstOrDefault
            '            If Not grupo Is Nothing Then
            '                If grupo.Nivel = 6 Then
            '                    Throw New Exception("La cuenta '" & grupo.Descripcion & "' es de ultimo nivel y no puede ser usada como grupo")
            '                End If
            '                Dim exist = db.Cuentas.Where(Function(f) f.IDCuentaGrupo = grupo.IDCuenta And f.IDCuenta <> c.IDCuenta And f.Codigo = Cuenta.Codigo And f.Activo).FirstOrDefault
            '                If exist Is Nothing Then
            '                    c.Nivel = grupo.Nivel + 1
            '                    If c.Nivel < Config.Nivel Then
            '                        If db.Cuentas.Where(Function(f) f.IDCuentaGrupo = c.IDCuenta And f.Activo).Count > 0 Then
            '                            Throw New Exception("Esta Cuenta es un grupo y tiene otras cuentas asociadas. Para poder realizar esta operación necesita remover primero las descendencia.")
            '                        End If
            '                    End If
            '                    c.CodigoSuperior = grupo.CodigoSuperior & grupo.Codigo
            '                    db.Entry(c).State = Entity.EntityState.Modified
            '                Else
            '                    Throw New Exception("Ya existe una cuenta dentro del grupo: '" & grupo.Descripcion & "' con el código " & exist.Codigo & " descrita como '" & exist.Descripcion & "'")
            '                End If
            '            Else
            '                Throw New Exception("No se encuentra este grupo.")
            '            End If
            '            Try
            '                db.SaveChanges()
            '            Catch ex As Exception
            '                Throw New Exception(ex.Message)
            '            End Try
            '        Else
            '            Throw New Exception("Ingresar grupo.")
            '        End If
            '    Else
            '        Throw New Exception("No se encuentra esta cuenta")
            '    End If
            'End Using
        Else
            Throw New Exception("No se mandaron los datos")
        End If
    End Sub

    Public Sub Delete(ByVal IdCuenta As Guid)
        Using db As New CodeFirst
            Dim c = db.Cuentas.Where(Function(f) f.IDCuenta = IdCuenta).FirstOrDefault
            If Not c Is Nothing Then
                If c.Nivel = 1 Then
                    Throw New Exception("Las cuentas de Nivel 1 no se pueden editar ni eliminar")
                End If
                If c.Nivel < Config.Nivel Then
                    If db.Cuentas.Where(Function(f) f.IDCuentaGrupo = c.IDCuenta And f.Activo).Count > 0 Then
                        Throw New Exception("Esta Cuenta es un grupo y tiene otras cuentas asociadas. Para poder realizar esta operación necesita remover primero las descendencia.")
                    End If
                End If

                c.Activo = False
                db.Entry(c).State = Entity.EntityState.Modified
                Try
                    db.SaveChanges()
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            Else
                Throw New Exception("No se encuentra esta cuenta")
            End If
        End Using
    End Sub

    Public Function List(Optional ByVal _Codigo As String = "", Optional ByVal _Descripcion As String = "") As List(Of entAccount)
        Try
            Using db As New CodeFirst
                Return (From c In db.Cuentas.AsParallel() _
                        Select c, COL1 = c.Grupo & c.SubGrupo, COL2 = c.Mayor & c.SubMayor, COL3 = c.SubSubMayor & c.UltimoNivel _
                        Where c.Activo And (COL1 & COL2 & COL3).Contains(_Codigo) And c.Descripcion.Contains(_Descripcion) _
                        Order By COL1 & COL2 & COL3 _
                        Select New entAccount With {
                            .IDCuenta = c.IDCuenta,
                            .N = c.N,
                            .Reg = c.Reg,
                            .FMod = c.FMod,
                            .Nivel = c.Nivel,
                            .IDCuentaGrupo = c.IDCuentaGrupo,
                            .CodigoCompleto = COL1 & COL2 & COL3,
                            .IdGrupo = c.IdGrupo,
                            .Grupo = c.Grupo,
                            .IdSubGrupo = c.IdSubGrupo,
                            .SubGrupo = c.SubGrupo,
                            .IdMayor = c.IdMayor,
                            .Mayor = c.Mayor,
                            .IdSubMayor = c.IdSubMayor,
                            .SubMayor = c.SubMayor,
                            .IdSubSubMayor = c.IdSubSubMayor,
                            .SubSubMayor = c.SubSubMayor,
                            .IdUltimoNivel = c.IdUltimoNivel,
                            .UltimoNivel = c.UltimoNivel,
                            .Descripcion = c.Descripcion,
                            .Naturaleza = c.Naturaleza,
                            .Operacion = c.Operacion,
                            .Deber = c.Deber,
                            .Haber = c.Haber,
                            .Saldo = c.Saldo,
                            .IsProduct = c.IsProduct,
                            .Costo = c.Costo,
                            .Entrada = c.Entrada,
                            .Salida = c.Salida,
                            .Existencia = c.Existencia,
                            .Activo = c.Activo
                        }).ToList
            End Using


            'Using db As New CodeFirst
            '    Dim ListAccount As New List(Of entAccount)
            '    Dim Account As entAccount
            '    Dim nivel As Short
            '    Dim IdGrupo As Nullable(Of Guid)
            '    Dim grupo As Cuenta
            '    For Each c In db.Cuentas.Where(Function(f) f.Activo).ToList()
            '        Account = New entAccount With {
            '            .IDCuenta = c.IDCuenta,
            '            .N = c.N,
            '            .Reg = c.Reg,
            '            .Nivel = c.Nivel,
            '            .IDCuentaGrupo = c.IDCuentaGrupo,
            '            .CodigoSuperior = c.CodigoSuperior,
            '            .Descripcion = c.Descripcion,
            '            .Naturaleza = c.Naturaleza,
            '            .Deber = c.Deber,
            '            .Haber = c.Haber,
            '            .Saldo = c.Saldo,
            '            .Activo = c.Activo
            '        }
            '        Select Case c.Nivel
            '            Case 6 : Account.UltimoNivel = c.Codigo
            '            Case 5 : Account.SubSubMayor = c.Codigo
            '            Case 4 : Account.SubMayor = c.Codigo
            '            Case 3 : Account.Mayor = c.Codigo
            '            Case 2 : Account.SubGrupo = c.Codigo
            '            Case 1 : Account.Grupo = c.Codigo
            '        End Select
            '        IdGrupo = c.IDCuentaGrupo
            '        If Not IdGrupo Is Nothing Then
            '            nivel = c.Nivel
            '            While nivel > 0
            '                If Not IdGrupo Is Nothing Then
            '                    grupo = db.Cuentas.Where(Function(f) f.IDCuenta = IdGrupo).FirstOrDefault
            '                    Select Case grupo.Nivel
            '                        Case 5 : Account.SubSubMayor = grupo.Codigo
            '                        Case 4 : Account.SubMayor = grupo.Codigo
            '                        Case 3 : Account.Mayor = grupo.Codigo
            '                        Case 2 : Account.SubGrupo = grupo.Codigo
            '                        Case 1 : Account.Grupo = grupo.Codigo
            '                    End Select

            '                    IdGrupo = grupo.IDCuentaGrupo
            '                End If

            '                'decremento
            '                nivel = nivel - 1
            '            End While
            '        End If
            '        'agregar
            '        Account.CodigoCompleto = Account.Grupo & Account.SubGrupo & Account.Mayor & Account.SubMayor & Account.SubSubMayor & Account.UltimoNivel
            '        ListAccount.Add(Account)
            '    Next

            '    Return ListAccount.Where(Function(f) f.CodigoCompleto.Contains(_Codigo) And f.Descripcion.Contains(_Descripcion)).OrderBy(Function(f) f.CodigoCompleto).ToList
            'End Using
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        End Try
    End Function

    Public Function ListGroup() As List(Of entAccount)
        Return Account.List().Where(Function(f) f.Nivel <> 6).ToList
    End Function

    Public Function Find(ByVal Codigo As String) As entAccount
        If Codigo.Trim <> "" Then
            Dim c = Account.List().Where(Function(f) f.CodigoCompleto.Equals(Codigo)).FirstOrDefault
            Return c
        Else
            Throw New Exception("Ingresar código de la cuenta.")
        End If
    End Function

    Public Function Find(ByVal IdCuenta As Guid) As entAccount
        Dim c = Account.List().Where(Function(f) f.IDCuenta = IdCuenta).FirstOrDefault
        Return c
    End Function

    Public Function Count() As Integer
        Using db As New CodeFirst
            Return Account.List().Count()
        End Using
    End Function

End Module