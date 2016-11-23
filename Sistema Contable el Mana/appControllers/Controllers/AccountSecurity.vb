Imports appModels
Public Module AccountSecurity

    Public Function UserCreate(ByVal User As UserAccount) As UserAccount
        If User Is Nothing Then
            Throw New Exception("Ingresar todos los datos obligatorios (*)")
        End If
        If String.IsNullOrWhiteSpace(User.Name) Or String.IsNullOrWhiteSpace(User.SurnName) Or String.IsNullOrWhiteSpace(User.UserName) Or String.IsNullOrWhiteSpace(User.UserPass) Then
            Throw New Exception("Ingresar todos los datos obligatorios (*)")
        End If
        If Not Config.ValidatePass(User.UserPass) Then
            Throw New Exception("Es obligatorio que las contraseñas contengan mas de 8 caracteres. Ademas de contener números, mayúsculas y caracteres especiales.")
        End If
        Using db As New CodeFirst
            If db.UsersAccounts.Where(Function(f) f.UserName = User.UserName).Count() > 0 Then
                Throw New Exception("Ya existe una cuenta con este nombre de usuario")
            End If
            User.IDUser = Guid.NewGuid
            User.Reg = DateTime.Now
            User.FMod = DateTime.Now
            User.UserPass = SecurityCryptography.PasswordEnconding(User.UserPass)
            User.Activo = True

            db.UsersAccounts.Add(User)
            db.SaveChanges()
        End Using

        Return User
    End Function

    Public Function UserUpdate(ByVal User As UserAccount) As UserAccount
        If User Is Nothing Then
            Throw New Exception("Ingresar todos los datos obligatorios (*)")
        End If
        If User.IDUser <> Guid.Empty And String.IsNullOrWhiteSpace(User.Name) Or String.IsNullOrWhiteSpace(User.SurnName) Or String.IsNullOrWhiteSpace(User.UserName) Then
            Throw New Exception("Ingresar todos los datos obligatorios (*)")
        End If
        If User.UserPass <> "" Then
            If Not Config.ValidatePass(User.UserPass) Then
                Throw New Exception("Es obligatorio que las contraseñas contengan mas de 8 caracteres. Ademas de contener números, mayúsculas y caracteres especiales.")
            End If
        End If
        Using db As New CodeFirst
            Dim _UserAccount = db.UsersAccounts.Where(Function(f) f.IDUser = User.IDUser And f.Activo).FirstOrDefault
            If Not _UserAccount Is Nothing Then
                If db.UsersAccounts.Where(Function(f) f.UserName = User.UserName And f.IDUser <> User.IDUser).Count() > 0 Then
                    Throw New Exception("Ya existe una cuenta con este nombre de usuario")
                End If
                _UserAccount.FMod = DateTime.Now
                _UserAccount.Name = User.Name
                _UserAccount.SurnName = User.SurnName
                _UserAccount.UserName = User.UserName
                If User.UserPass <> "" Then
                    _UserAccount.UserPass = SecurityCryptography.PasswordEnconding(User.UserPass)
                End If

                db.Entry(_UserAccount).State = Entity.EntityState.Modified
                db.SaveChanges()
                Return _UserAccount
            Else
                Throw New Exception("No se encuentra esta 'Cuenta de Usuario'. Probablemente ha sido eliminada.")
            End If
        End Using
    End Function

    Public Sub UserDelete(ByVal IDUser As Guid)
        If IDUser = Guid.Empty Then
            Throw New Exception("Ingresar todos los datos obligatorios (*)")
        End If
        Using db As New CodeFirst
            Dim _UserAccount = db.UsersAccounts.Where(Function(f) f.IDUser = IDUser And f.Activo).FirstOrDefault
            If Not _UserAccount Is Nothing Then
                _UserAccount.Activo = False
                db.Entry(_UserAccount).State = Entity.EntityState.Modified
                db.SaveChanges()
            End If
        End Using
    End Sub

    Public Function List(ByVal Name As String, ByVal UserName As String) As List(Of UserAccount)
        Using db As New CodeFirst
            Return db.UsersAccounts.Where(Function(f) (f.Name & " " & f.SurnName).Contains(Name) And f.UserName.Contains(UserName) And f.Activo).OrderBy(Function(f) f.Reg).ToList
        End Using
    End Function

    Public Function Find(ByVal IDUser As Guid) As UserAccount
        Using db As New CodeFirst
            Return db.UsersAccounts.Where(Function(f) f.IDUser = IDUser).FirstOrDefault
        End Using
    End Function

    Public Function Signin(ByVal UserName As String, ByVal UserPass As String) As UserAccount
        Using db As New CodeFirst
            Dim User = db.UsersAccounts.Where(Function(f) f.UserName = UserName And f.Activo).FirstOrDefault
            If Not User Is Nothing Then
                Dim _UserPass = SecurityCryptography.PasswordDecoding(User.UserPass)
                If _UserPass = UserPass Then
                    Return User
                Else
                    Throw New Exception("Contraseña incorrecto")
                End If
            Else
                Throw New Exception("Usuario incorrecto")
            End If
        End Using
    End Function

    Public Sub ChangePassword(ByVal IDUser As Guid, ByVal UserPass As String, ByVal UserPassNew As String, ByVal UserPassRepit As String)
        If UserPassNew <> UserPassRepit Then
            Throw New Exception("Las contraseñas son distintas")
        End If
        Using db As New CodeFirst
            Dim User = db.UsersAccounts.Where(Function(f) f.IDUser = IDUser And f.Activo).FirstOrDefault
            If Not User Is Nothing Then
                If SecurityCryptography.PasswordDecoding(User.UserPass) = UserPass Then
                    User.UserPass = SecurityCryptography.PasswordEnconding(UserPassNew)
                    db.Entry(User).State = Entity.EntityState.Modified
                    db.SaveChanges()
                Else
                    Throw New Exception("Contraseña incorrecto")
                End If
            Else
                Throw New Exception("Usuario incorrecto")
            End If
        End Using
    End Sub

    Public Sub UserDefault()
        Using db As New CodeFirst
            If Not db.UsersAccounts.Count() > 0 Then
                Dim User As New appModels.UserAccount
                User.IDUser = Guid.NewGuid
                User.Reg = DateTime.Now
                User.FMod = DateTime.Now
                User.Name = "MICHEL ROBERTO"
                User.SurnName = "TRAÑA TABLADA"
                User.UserName = "admin"
                User.UserPass = SecurityCryptography.PasswordEnconding("admin*123")
                User.Activo = True

                db.UsersAccounts.Add(User)

                db.SaveChanges()
            End If
        End Using
    End Sub

End Module