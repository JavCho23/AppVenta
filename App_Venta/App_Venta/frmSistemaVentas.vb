Public Class frmSistemaVentas
    Private Sub CLIENTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLIENTESToolStripMenuItem.Click
        Dim obj As New frmManCliente

        obj.ShowDialog()

    End Sub

    Private Sub PRODUCTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODUCTOSToolStripMenuItem.Click
        Dim obj As New frmManProductos

        obj.ShowDialog()

    End Sub

    Private Sub VENTASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VENTASToolStripMenuItem.Click
        Dim obj As New frmVenta

        obj.ShowDialog()

    End Sub

    Private Sub FACTURAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FACTURAToolStripMenuItem.Click
        Dim obj As New frmDetalles

        obj.ShowDialog()

    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIRToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class