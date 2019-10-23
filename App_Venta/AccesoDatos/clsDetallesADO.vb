Imports System.Data.SqlClient
Imports Entidades
Public Class clsDetallesADO
    Public Function Listado(cod_venta As String) As DataTable
        Dim cn As clsConexion
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            cn = New clsConexion
            cn.Conectar()
            da = New SqlDataAdapter("Select *from detalle where cod_ven='" & cod_venta & "'", cn.getConexion)
            da.Fill(dt)
            cn.Desconectar()
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Public Sub Eliminar(cod_ven As String)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "Delete detalle
                where cod_ven='" & cod_ven & "'"
        Try
            cn = New clsConexion()
            cn.Conectar()
            cmd = New SqlCommand(sql, cn.getConexion)
            cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub
End Class
