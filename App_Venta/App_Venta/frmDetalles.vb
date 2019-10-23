Imports AccesoDatos
Imports Entidades

Public Class frmDetalles
    Private Sub frmDetalles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarVentas()
    End Sub
    Private Sub cargarVentas()
        Dim dt As DataTable
        Dim objCAD As New clsVentaADO

        Try
            dt = objCAD.Listado
            dgvVenta.DataSource = dt
        Catch ex As Exception
            MsgBox("ERORR:" & ex.Message)
        End Try
    End Sub
    Private Sub cargarDetalles(cod_venta As String)
        Dim dt As DataTable
        Dim objAD As New clsDetallesADO

        Try
            dt = objAD.Listado(cod_venta)
            dgvDetalles.DataSource = dt
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dgvVenta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVenta.CellContentClick
        Dim cod As String = dgvVenta.CurrentRow.Cells.Item(0).Value.ToString
        cargarDetalles(cod)
        btnDevolver.Enabled = True
    End Sub

    Private Sub btnDevolver_Click(sender As Object, e As EventArgs) Handles btnDevolver.Click
        Dim cnP As New clsProductoADO
        Dim cnD As New clsDetallesADO
        For Each row As DataGridViewRow In dgvDetalles.Rows
            cnP.ActualizarStock(row.Cells.Item(4).Value.ToString, CInt(row.Cells.Item(1).Value))
            cnD.Eliminar(row.Cells.Item(3).Value.ToString)
        Next
        Dim cnV As New clsVentaADO
        cnV.Eliminar(dgvVenta.CurrentRow.Cells.Item(0).Value.ToString)
        cargarVentas()
        dgvDetalles.DataSource = vbNull

    End Sub
End Class