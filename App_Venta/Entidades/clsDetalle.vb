Public Class clsDetalle
    Property id As String
    Property cantidad As Integer
    Property subtotal As Double
    Property cod_venta As String
    Property id_Pro As String

    Sub New(id As String, cantidad As Integer, subtotal As Double,
            cod As String, idP As String)
        Me.id = id
        Me.cantidad = cantidad
        Me.subtotal = subtotal
        Me.cod_venta = cod
        Me.id_Pro = idP
    End Sub


End Class
