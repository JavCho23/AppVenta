Imports System.Data.SqlClient
Imports Entidades
Public Class clsClienteADO
    Public Sub agregar(obj As clsCliente)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "Insert Into cliente " &
       "Values('" & obj.dni & "','" & obj.nombres & "','" & obj.apPaterno &
       "','" & obj.apMaterno & "','" & obj.fechaNac & "'," & obj.sexo & ")"
        Try
            cn = New clsConexion
            cn.Conectar()
            cmd = New SqlCommand(sql, cn.getConexion)
            cmd.ExecuteNonQuery()
            cn.Desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub modificar(obj As clsCliente)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "update cliente" &
              " set nombres = '" & obj.nombres & "', apPaterno = '" & obj.apPaterno & "', apMaterno = '" &
              obj.apMaterno & "', fechaNac = '" & obj.fechaNac & "', sexo =" & obj.sexo & " where dni = '" & obj.dni & "'"

        Try
            cn = New clsConexion
            cn.Conectar()
            cmd = New SqlCommand(sql, cn.getConexion)
            cmd.ExecuteNonQuery()
            cn.Desconectar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Listado() As DataTable
        Dim cn As clsConexion
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            cn = New clsConexion
            cn.Conectar()
            da = New SqlDataAdapter("Select *from cliente", cn.getConexion)
            da.Fill(dt)
            cn.Desconectar()
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
End Class
