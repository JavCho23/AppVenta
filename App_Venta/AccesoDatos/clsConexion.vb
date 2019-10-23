Imports System.Data
Imports System.Data.SqlClient

Public Class clsConexion
    Private cn As SqlConnection

    Sub New()
        Dim ruta As String

        ruta = "Data Source=(local);Initial Catalog=BD_Progra3;Integrated Security=true"
        cn = New SqlConnection(ruta)
    End Sub

    Public Sub Conectar()
        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Desconectar()
        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public ReadOnly Property getConexion As SqlConnection
        Get
            Return cn
        End Get
    End Property
End Class
