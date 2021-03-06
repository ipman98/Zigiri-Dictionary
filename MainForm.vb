﻿'
' Created by SharpDevelop.
' User: IP-Man
' Date: 5/11/2017
' Time: 9:01 AM
' 
Public Partial Class MainForm
	Public myversion As String="0.4.0"	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	
	Sub MainFormLoad(sender As Object, e As EventArgs)
		If String.IsNullOrEmpty(Clipboard.GetText) Then
			Clipboard.SetText("none")
		End If
	End Sub
	
	Sub FindBtnClick(sender As Object, e As EventArgs)
		Call StartSearch()
	End Sub
		
	Sub InputKeyPress(sender As Object, e As KeyPressEventArgs)
		If e.KeyChar = ChrW(Keys.Enter) Then
			Call StartSearch()
		End If
	End Sub
	
	Sub OutputDoubleClick(sender As Object, e As EventArgs)
		If suggest=True Then 
			input.Text=output.SelectedItem.ToString
			suggest=False
			Call SearchMeaning(output.SelectedItem.ToString)
		End If 
	End Sub
	
	Sub GrabTextTick(sender As Object, e As EventArgs)
		Call atoGrabText()
	End Sub
	
	Sub AtoGrabCheckedChanged(sender As Object, e As EventArgs)
		Call ShowErrors()
		If atoGrab.Checked=True Then
			grabText.Enabled=True 
		Else
			grabText.Enabled=False
		End If
	End Sub
	
	Sub OutputMouseDown(sender As Object, e As MouseEventArgs)
		If e.Button = MouseButtons.Right Then
			contextMenu.Show(MousePosition)
		End If 
	End Sub
	
	Sub CopyToolStripMenuItemClick(sender As Object, e As EventArgs)
		If String.IsNullOrEmpty(output.Text) Then 
			MsgBox("Please select an item to copy!")
		Else 
			Clipboard.SetText(output.Text)
		End If
	End Sub
	
	Sub SmModeCheckedChanged(sender As Object, e As EventArgs)
		Call ShowErrors()
		If smMode.Checked=True Then
			Me.Height=133
			trayMeaning.Checked=True 
			trayMeaning.Enabled=False
		Else
			Me.Height=348
			trayMeaning.Checked=False 
			trayMeaning.Enabled=True
		End If
	End Sub
	
	
	Sub TrayMeaningCheckedChanged(sender As Object, e As EventArgs)
		If trayMeaning.Checked=True Then
			tm=True
		Else
			tm=False
		End If
	End Sub
	
	Sub MainFormResize(sender As Object, e As EventArgs)
		If Me.WindowState = FormWindowState.Minimized Then		
			Me.Visible = False
			notifyIcon.ShowBalloonTip(1000, "", "Zigiri Dictionary is here!", ToolTipIcon.Info)
		End If
	End Sub
	
	Sub NotifyIconClick(sender As Object, e As EventArgs)
		Me.Show
		Me.WindowState = FormWindowState.Normal 
	End Sub
	
	Sub AboutBtnClick(sender As Object, e As EventArgs)
		MsgBox("Version " & myversion & vbNewLine & "Developed By Navinda Dissanayake." & 
			vbNewLine & "Visit : www.navinda.xyz for more information.")	
	End Sub
	
	Sub InfoBtnButtonClick(sender As Object, e As EventArgs)
		MsgBox("Current version : " & myversion.ToString & vbNewLine & ".NET Framework : 4.0",vbInformation,"Zigiri Dictionary "  & myversion)
	End Sub
	
	Sub ShowErrors()
		If (atoGrab.Checked=True And smMode.Checked=True) Then
			errorshow=True
		Else If (atoGrab.Checked=False And smMode.Checked=False) Then
			errorshow=True
		ElseIf (atoGrab.Checked=False And smMode.Checked=True) Then
			errorshow=True
		Else If (atoGrab.Checked=True And smMode.Checked=False) Then
			errorshow=False
		End If
	End Sub
	
	Sub StartSearch()
		If String.IsNullOrEmpty(input.Text.Trim) Then
			MsgBox("Please enter something to search!")
		Else
			Call SearchMeaning((input.Text.Trim).ToLower)
		End If
	End Sub

End Class
