Imports System.Security.Cryptography
Imports System.Text

Friend Class SecurityCryptography
    'Private Shared Clave As String = "5483*+/-"
    'Public Shared UTF8 As UTF8Encoding
    Private Shared Converter As New UnicodeEncoding

    Private Shared KeyPublic As String = "<RSAKeyValue><Modulus>39wtNPF5X1EwZ6UVj5TzFe1zqKHA0WPrpTnZh9IQU7KT/z4Rgek7sRUVqdAEufX81uEftDepRtlw3yRkmMGCP9tYBwVJRPjTVGZQoVjlRbXCdIpkW4PwTB8rjmUPTu03mZkGzjB0GS88hDrZ8bn9bzNYqHdUxtakJf0wOYMR6X8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
    Private Shared KeyPrivate As String = "<RSAKeyValue><Modulus>39wtNPF5X1EwZ6UVj5TzFe1zqKHA0WPrpTnZh9IQU7KT/z4Rgek7sRUVqdAEufX81uEftDepRtlw3yRkmMGCP9tYBwVJRPjTVGZQoVjlRbXCdIpkW4PwTB8rjmUPTu03mZkGzjB0GS88hDrZ8bn9bzNYqHdUxtakJf0wOYMR6X8=</Modulus><Exponent>AQAB</Exponent><P>/G9JYNLaRKZEqfxDxrUeFbB/CwoFnR+V47yDwqRptf04LVfD5JrXvJB1dxKuSYDx8QsrP4AzsRuMdBiN+nHquw==</P><Q>4wWTA84L3jzi6G1t2aRLTpk5u3hC8p9r9xUp7miszBF7Js9kzOvLBi1lvQkyMvnZSVMhYRPwjVuUQwHRwjYaDQ==</Q><DP>nAoyop5T+8GHikf8oVUNzrx2G53LUI/YuJisHeJB0hQ/6I9q8OHiX5YwdjVe9OK3K5gK2MrnqR/tV0piYSCPxw==</DP><DQ>3/BUt/EdZei7j7i6HnFhU7Pz7ghQSdKWhpGa3jDlGxu3Vm5IKZgCmiJX9GPI393zx8+34nHv3RDULFD0H9aMVQ==</DQ><InverseQ>NoCy5SWX+iSKYwLJE1nZ2eq05poSIt/J2oVjD3qiClVeVLVUmISlXdQ1dsLHiJCazbDEdggukXcvGfY0RZ04Nw==</InverseQ><D>ID62xEmEEha/wi4lTOlHmoD5h/DEtWSPLN2IV+gKMgQnDT0DiJLv5jIDTNKJ279zDAChcHQUDgCEIaA8XUSCXitKLXm2xvJKBir/uMf8XV/e5CzzA4fpEamGyLclGrtUyNZi4JPH4KcAF5jBB/q0NqpGZbQpS0JgOcI+o3/RAQE=</D></RSAKeyValue>"

    Public Shared Function PasswordEnconding(ByVal ValText As String) As String
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
            RSA.FromXmlString(SecurityCryptography.KeyPublic)
            Return Convert.ToBase64String(RSA.Encrypt(SecurityCryptography.Converter.GetBytes(ValText), True))
        End Using
    End Function

    Public Shared Function PasswordDecoding(ByVal ValText As String) As String
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

            'Dim publica, privada As String
            'publica = RSA.ToXmlString(False)
            'privada = RSA.ToXmlString(True)

            RSA.FromXmlString(SecurityCryptography.KeyPrivate)
            Return Converter.GetString(RSA.Decrypt(Convert.FromBase64String(ValText), False))
        End Using
    End Function
End Class