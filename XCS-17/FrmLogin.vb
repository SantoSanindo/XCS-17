Option Explicit On
Public Class FrmLogin
	Dim Screencontrol As Integer
	Dim buttonArray(37) As Button

	Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		For i As Integer = 0 To 36
			buttonArray(i) = CType(Controls("btn" & i), Button)
		Next
	End Sub

	Private Sub NumberButton_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn10.Click, btn11.Click, btn12.Click, btn13.Click, btn14.Click, btn15.Click, btn16.Click, btn17.Click, btn18.Click, btn19.Click, btn20.Click, btn21.Click, btn22.Click, btn23.Click, btn24.Click, btn25.Click, btn26.Click, btn27.Click, btn28.Click, btn29.Click, btn30.Click, btn31.Click, btn32.Click, btn33.Click, btn34.Click, btn35.Click, btn36.Click
		Dim clickedButton As Button = CType(sender, Button)
		If Screencontrol = 0 Then
			Text1.Text &= clickedButton.Text
		Else
			Text2.Text &= clickedButton.Text
		End If
	End Sub

	Private Sub btn37_Click(sender As Object, e As EventArgs) Handles btn37.Click
		If Screencontrol = 0 Then
			Text1.Focus()
			Text1.SelectionStart = Len(Text1.Text)
			SendKeys.Send("{BS}")
		Else
			Text2.Focus()
			Text2.SelectionStart = Len(Text2.Text)
			SendKeys.Send("{BS}")
		End If
	End Sub

	Private Sub Command1_Click(sender As Object, e As EventArgs) Handles Command1.Click
		If Screencontrol = 0 Then
			Screencontrol = 1
			Text2.Focus()
		Else
			Screencontrol = 0
			Text1.Focus()
		End If
	End Sub

	Private Sub Command2_Click(sender As Object, e As EventArgs) Handles Command2.Click
		Dim query = "SELECT * FROM TESE.dbo.[USER] WHERE USER_ID = '" & Text1.Text & "'"
		Dim dt = KoneksiDB.bacaData(query).Tables(0)

		Login = False

		Try
			If UCase(Text2.Text) = UCase(dt.Rows(0).Item("USER_PASSWORD")) Then
				Login = True
				MsgBox("Login successful")
				Me.Close()
			End If
		Catch ex As Exception
			MsgBox("Invalid username or password")
		End Try
	End Sub
End Class