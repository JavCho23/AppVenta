Public Class clsVenta
    Property codigo As String
    Property fechas As Date
    Property monto As Double
    Property dni_cliente As String
    Sub New(codigo As String, fechas As Date, monto As Double, dni_cliente As String)
        Me.codigo = codigo
        Me.dni_cliente = dni_cliente
        Me.fechas = fechas
        Me.monto = monto

    End Sub
End Class
