Imports AccesoDatos
Imports Entidades

Public Class frmManProductos
    Private Sub frmManProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarProductos()
    End Sub

    Private Sub cargarProductos()
        Dim dt As DataTable
        Dim objAD As New clsProductoADO

        Try
            dt = objAD.Listado
            dgvDatos.DataSource = dt
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        End Try
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim obj As clsProducto
        Dim objAD As New clsProductoADO

        Try
            obj = New clsProducto(txtId.Text, txtDescripcion.Text,
                                  CDbl(txtPrecio.Text), CInt(txtStock.Text), CInt(chkEstado.Checked))
            objAD.agregar(obj)
            MsgBox("Producto agregado", MsgBoxStyle.Information)
            cargarProductos()
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        End Try
    End Sub

    Private Sub limpiar()
        txtId.Text = ""
        txtDescripcion.Text = ""
        txtPrecio.Text = ""
        txtStock.Text = ""
        chkEstado.Checked = True
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim obj As clsProducto
        Dim objAd As New clsProductoADO

        Try
            obj = New clsProducto(txtId.Text, txtDescripcion.Text,
                                  CDbl(txtPrecio.Text), CInt(txtStock.Text), CInt(chkEstado.Checked))
            objAd.modificar(obj)
            MsgBox("Producto modificado", MsgBoxStyle.Information)
            cargarProductos()
            limpiar()
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        End Try

    End Sub

    Private Sub dgvDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        txtId.Text = CType(dgvDatos.CurrentRow.Cells.Item(0).Value, String)
        txtDescripcion.Text = CType(dgvDatos.CurrentRow.Cells.Item(1).Value, String)
        txtPrecio.Text = CType(dgvDatos.CurrentRow.Cells.Item(2).Value, String)
        txtStock.Text = CType(dgvDatos.CurrentRow.Cells.Item(3).Value, String)
        chkEstado.Checked = CBool(dgvDatos.CurrentRow.Cells.Item(4).Value)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub
End Class