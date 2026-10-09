Public Class Form1
    Public KeC = 0, RiQ = 0, oKeC = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReRead()
        Fresh()
    End Sub

    Private Sub 刷新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新ToolStripMenuItem.Click
        Fresh()
    End Sub

    Private Sub 重新读取ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重新读取ToolStripMenuItem.Click
        ReRead()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Fresh()
    End Sub
End Class