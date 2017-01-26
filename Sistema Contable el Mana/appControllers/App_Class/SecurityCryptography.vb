Imports System.Security.Cryptography
Imports System.Text
Friend Class SecurityCryptography

    Private Shared KeyValue As String = "5483*+/-"

    Public Shared ReadOnly Property KeyProp() As String
        Get
            Return SecurityCryptography.KeyValue
        End Get
    End Property


    Public Shared UTF8 As UTF8Encoding
    Private Shared Converter As New UnicodeEncoding

    Public Shared Function Encoding(ByVal ValText As String) As String
        'Using EncripSha1 As New SHA1CryptoServiceProvider
        '    'Return Convert.ToBase64String(EncripSha1.ComputeHash((New UnicodeEncoding).GetBytes(strPass)))
        'End Using
        'Using varRSA As New RSACryptoServiceProvider
        '    Return Convert.ToBase64String(varRSA.Encrypt(HashSecurity.UTF8.GetBytes(strPass), False))
        'End Using

        'Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("7361*/-+") 'La clave debe ser de 8 caracteres
        'Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        'Dim buffer() As Byte = Encoding.UTF8.GetBytes(ValText)
        'Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        'des.Key = EncryptionKey
        'des.IV = IV
        'Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

        Using RSA As New RSACryptoServiceProvider
            RSA.FromXmlString(KeyModule.KeyPublic)
            Return Convert.ToBase64String(RSA.Encrypt(SecurityCryptography.Converter.GetBytes(ValText), False))
        End Using
    End Function

    Public Shared Function Decoding(ByVal ValText As String) As String
        'Using varRSA As New RSACryptoServiceProvider
        '    Return HashSecurity.UTF8.GetString(varRSA.Decrypt(Convert.FromBase64String(strPassEncode), False))
        'End Using

        'Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("7361*/-+") 'La clave debe ser de 8 caracteres
        'Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        'Dim buffer() As Byte = Convert.FromBase64String(ValText)
        'Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        'des.Key = EncryptionKey
        'des.IV = IV
        'Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

        Using RSA As New RSACryptoServiceProvider
            RSA.FromXmlString(KeyModule.KeyPrivate)
            Return Converter.GetString(RSA.Decrypt(Convert.FromBase64String(ValText), False))
        End Using
    End Function
End Class