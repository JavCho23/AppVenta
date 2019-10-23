Imports AccesoDatos
Imports Entidades
Public Class frmManCliente
    Private Sub frmManCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarClientes()
    End Sub

    Private Sub cargarClientes()
        Dim dt As DataTable
        Dim objCAD As New clsClienteADO

        Try
            dt = objCAD.Listado
            dgvDatos.DataSource = dt
        Catch ex As Exception
            MsgBox("ERORR:" & ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim obj As clsCliente
        Dim objCAD As New clsClienteADO

        Try
            obj = New clsCliente(txtDni.Text, txtNombre.Text, txtApPaterno.Text, txtApMaterno.Text,
                                  CDate(dtpFecha.Text), CInt(rbtFemenino.Checked))
            objCAD.agregar(obj)
            MsgBox("CLIENTE AGREGADO", MsgBoxStyle.Information)
            cargarClientes()
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        End Try
    End Sub

    Private Sub limpiar()
        txtDni.Text = ""
        txtNombre.Text = ""
        txtApPaterno.Text = ""
        txtApMaterno.Text = ""
        dtpFecha.Text = ""
        rbtFemenino.Checked = False
        rbtMasculino.Checked = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
        btnRegistrar.Enabled = True
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim obj As clsCliente
        Dim objCAD As New clsClienteADO

        Try
            obj = New clsCliente(txtDni.Text, txtNombre.Text, txtApPaterno.Text, txtApMaterno.Text,
                                  CDate(dtpFecha.Text), CInt(rbtFemenino.Checked))
            objCAD.modificar(obj)
            MsgBox("CLIENTE MODIFICADO", MsgBoxStyle.Information)
            cargarClientes()
            limpiar()
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        txtDni.Text = CType(dgvDatos.CurrentRow.Cells.Item(0).Value, String)
        txtNombre.Text = CType(dgvDatos.CurrentRow.Cells.Item(1).Value, String)
        txtApPaterno.Text = CType(dgvDatos.CurrentRow.Cells.Item(2).Value, String)
        txtApMaterno.Text = CType(dgvDatos.CurrentRow.Cells.Item(3).Value, String)
        dtpFecha.Text = CType(dgvDatos.CurrentRow.Cells.Item(4).Value, String)
        If (CBool(dgvDatos.CurrentRow.Cells.Item(5).Value)) Then
            rbtFemenino.Checked = True
        Else
            rbtMasculino.Checked = True
        End If

    End Sub
End Class