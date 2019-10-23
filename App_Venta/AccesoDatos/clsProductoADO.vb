Imports System.Data
Imports System.Data.SqlClient
Imports Entidades

Public Class clsProductoADO
    Public Sub agregar(obj As clsProducto)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "Insert Into producto " &
              "values('" & obj.id & "','" & obj.descripcion & "',
              " & obj.precio & "," & obj.stock & "," & obj.estado & ")"

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

    Public Sub modificar(obj As clsProducto)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "update producto" &
              " set descripcion = '" & obj.descripcion & "', precio =" & obj.precio & ", stock =" &
              obj.stock & ",estado = " & obj.estado & " where id = '" & obj.id & "'"

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
    Public Sub ActualizarStock(id_pro As String, stock As Integer)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "update producto" &
              " set stock = stock + " & stock & " where id = '" & id_pro & "'"

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
            da = New SqlDataAdapter("Select *from producto", cn.getConexion)
            da.Fill(dt)
            cn.Desconectar()
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
End Class
