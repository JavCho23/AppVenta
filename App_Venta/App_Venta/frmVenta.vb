Imports Entidades
Imports AccesoDatos
Public Class frmVenta
    Dim cantId As Integer
    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cnC As New clsClienteADO
        Dim cnP As New clsProductoADO
        Try
            dgvProductos.DataSource = cnP.Listado()
            cmbClientes.DataSource = cnC.Listado()
            cmbClientes.ValueMember = "dni"
            cmbClientes.DisplayMember = "nombres"
            Me.cantId = 1
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim cantidad As Integer = CInt(InputBox("¿Cuantos desea Agregar?"))
        If (cantidad <= CInt(dgvProductos.CurrentRow.Cells.Item(3).Value)) Then
            dgvDetalles.Rows.Add(Me.cantId, cantidad, cantidad * CInt(dgvProductos.CurrentRow.Cells.Item(2).Value), CType(dgvProductos.CurrentRow.Cells.Item(0).Value, String))
            Me.cantId = Me.cantId + 1
            dgvProductos.CurrentRow.Cells.Item(3).Value = CInt(dgvProductos.CurrentRow.Cells.Item(3).Value) - cantidad
        Else
            MsgBox("No hay stock suficiente", MsgBoxStyle.Critical)
        End If


    End Sub

    Private Sub dgvDetalles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalles.CellContentClick
        btnQuitar.Enabled = True
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim cantidad As Integer = CInt(InputBox("¿Cuantos desea Quitar?"))
        If (CInt(dgvDetalles.CurrentRow.Cells.Item(1).Value) - cantidad > 0) Then
            dgvDetalles.CurrentRow.Cells.Item(1).Value = CInt(dgvDetalles.CurrentRow.Cells.Item(1).Value) - cantidad
            dgvProductos.CurrentRow.Cells.Item(3).Value = CInt(dgvProductos.CurrentRow.Cells.Item(3).Value) + cantidad
        ElseIf (CInt(dgvDetalles.CurrentRow.Cells.Item(1).Value) - cantidad = 0) Then
            dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index)
            dgvProductos.CurrentRow.Cells.Item(3).Value = CInt(dgvProductos.CurrentRow.Cells.Item(3).Value) + cantidad
        Else
            MsgBox("No se pueden quitar tantos", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim cn As New clsVentaADO
        Dim total As Double
        Try
            For Each row As DataGridViewRow In dgvDetalles.Rows
                total = total + CType(row.Cells.Item(2).Value, Double)
            Next
            Dim obj As New clsVenta(txtCodigo.Text, DateTimePicker1.Value, total, CType(cmbClientes.SelectedValue, String))
            cn.Agregar(obj)
            MsgBox("Venta Agregado", MsgBoxStyle.Information)
            For Each row As DataGridViewRow In dgvDetalles.Rows
                cn.AgregarDetalle(CInt(row.Cells.Item(1).Value), CType(row.Cells.Item(2).Value, Double), txtCodigo.Text, CType(row.Cells.Item(3).Value, String))
            Next
            MsgBox("Detalles Agregados", MsgBoxStyle.Information)
            dgvDetalles.Rows.Clear()
            limpiar()

        Catch ex As Exception
            MsgBox("ERROR: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub limpiar()
        txtCodigo.Text = ""
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        btnAgregar.Enabled = True
    End Sub

End Class