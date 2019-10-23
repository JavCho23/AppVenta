Imports AccesoDatos
Imports Entidades

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objCn As clsConexion

        Try
            objCn = New clsConexion
            objCn.Conectar()
            MsgBox("Conexion Exitosa", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim obj As clsProducto
        Dim objAD As New clsProductoADO

        Try
            obj = New clsProducto("P100", "camisa", 80, 50, 1)
            objAD.agregar(obj)
            MsgBox("Producto agregado", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        End Try
    End Sub
End Class
