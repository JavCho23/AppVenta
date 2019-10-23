Public Class clsCliente
    Property dni As String
    Property nombres As String
    Property apPaterno As String
    Property apMaterno As String
    Property fechaNac As Date
    Property sexo As Integer

    Sub New(dni As String, nom As String, apPa As String, apMa As String,
            fechaN As Date, sexo As Integer)
        Me.dni = dni
        Me.nombres = nom
        Me.apPaterno = apPa
        Me.apMaterno = apMa
        Me.fechaNac = fechaN
        Me.sexo = sexo

    End Sub
End Class
