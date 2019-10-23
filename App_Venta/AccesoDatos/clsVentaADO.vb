Imports System.Data
Imports System.Data.SqlClient
Imports Entidades
Public Class clsVentaADO
    Public Sub Agregar(Obj As clsVenta)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "Insert Into venta Values('" & Obj.codigo & "', '" & FormatDateTime(Obj.fechas, DateFormat.ShortDate) & "', " & Obj.monto & ", '" & Obj.dni_cliente & "')"
        Try
            cn = New clsConexion()
            cn.Conectar()
            cmd = New SqlCommand(sql, cn.getConexion)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub AgregarDetalle(Cantidad As Integer, sub_total As Double, cod_venta As String, id_pro As String)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "Insert Into detalle Values(" & Cantidad & ", " & sub_total & ", '" & cod_venta & "', '" & id_pro & "')"
        Try
            cn = New clsConexion()
            cn.Conectar()
            cmd = New SqlCommand(sql, cn.getConexion)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Modificar(Obj As clsProducto)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "Update producto 
               set descripcion  ='" & Obj.descripcion & "', precio = " & Obj.precio & ", stock = " & Obj.stock & "
                where producto.id='" & Obj.id & "'"
        Try
            cn = New clsConexion()
            cn.Conectar()
            cmd = New SqlCommand(sql, cn.getConexion)
            cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub
    Public Function Listado() As DataTable
        Dim cn As clsConexion
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            cn = New clsConexion()
            cn.Conectar()
            da = New SqlDataAdapter("Select * from venta", cn.getConexion)
            da.Fill(dt)
            cn.Desconectar()

        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function

    Public Sub Eliminar(cod_venta As String)
        Dim sql As String
        Dim cn As clsConexion
        Dim cmd As SqlCommand

        sql = "Delete venta 
                where codigo='" & cod_venta & "'"
        Try
            cn = New clsConexion()
            cn.Conectar()
            cmd = New SqlCommand(sql, cn.getConexion)
            cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub
End Class
