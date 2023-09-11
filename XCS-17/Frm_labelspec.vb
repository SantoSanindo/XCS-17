Public Class Frm_labelspec
    Private Sub Cmd_Back_Click(sender As Object, e As EventArgs) Handles Cmd_Back.Click
        Me.Close()
    End Sub

    Private Sub Frm_labelspec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query = "SELECT ModelName FROM TESE.dbo.Label"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        For i As Integer = 0 To dt.Rows.Count - 1
            Cmbo_Select.Items.Add(dt.Rows(i).Item(0))
        Next
    End Sub

    Private Sub Cmbo_Select_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmbo_Select.SelectedIndexChanged
        If Cmbo_Select.Text = "" Then Exit Sub
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & Cmbo_Select.Text & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        Text115.Text = dt.Rows(0).Item("Group_Qty")
        Text11.Text = dt.Rows(0).Item("ArticleNos")
        Text18.Text = dt.Rows(0).Item("Unitary_Template")
        Text17.Text = dt.Rows(0).Item("Unitary_Img")
        Text15.Text = dt.Rows(0).Item("Unitary_Reference")
        'Text13.Text = dt.Rows(0).Item("Unitary_Detail2")
        'Text14.Text = dt.Rows(0).Item("Unitary_Detail3")
        'Text19.Text = dt.Rows(0).Item("Unitary_Country")
        'Text10.Text = dt.Rows(0).Item("Unitary_PV")
    End Sub
End Class