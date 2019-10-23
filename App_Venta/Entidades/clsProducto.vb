Public Class clsProducto
    Property id As String
    Property descripcion As String
    Property precio As Double
    Property stock As Integer
    Property estado As Integer

    Sub New(id As String, des As String, precio As Double,
            stock As Integer, estado As Integer)
        Me.id = id
        Me.descripcion = des
        Me.precio = precio
        Me.stock = stock
        Me.estado = estado
    End Sub
End Class
