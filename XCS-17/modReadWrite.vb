Option Explicit On
Module modReadWrite
	Public INIPHOTOPATH As String 'PATH TO THE PHOTO FOR THE LABEL TEMPLATE
	Public INITEMPLATEPATH As String 'PATH TO LABEL Template
	Public INIPSNFOLDERPATH As String 'Path to the PSN.Txt
	Public INIMATERIALPATH As String
	Public INIACHIEVEPATH As String 'Path to achieve folder
	Public INISTATUSPATH As String 'PATH TO SERVER\FRIDGE
	Public INIPRINTPATH As String 'PATH TO PRINT.TXT
	Public INIVACUUMPATH As String

	Dim FNum As Integer
	Dim LineStr As String

	'Read settings from INI file
	Public Sub ReadINI(Filename As String)
		Dim ItemStr As String
		Dim SectionHeading As String = ""
		Dim pos As Integer

		FNum = FreeFile()
		FileOpen(FNum, Filename, OpenMode.Input)

		Do While Not EOF(FNum)

			LineStr = LineInput(FNum)

			'Check for Section heading
			If Left(LineStr, 1) = "[" Then
				SectionHeading = Mid(LineStr, 2, Len(LineStr) - 2)
			Else
				If InStr(LineStr, "=") > 0 Then
					pos = InStr(LineStr, "=")
					ItemStr = Left(LineStr, pos - 1)

					Select Case UCase(SectionHeading)

						Case "LABEL PHOTO PATH" 'Shared FILE
							Select Case UCase(ItemStr)
								Case "PATH" : INIPHOTOPATH = Mid(LineStr, pos + 1)
							End Select

						Case "LABEL TEMPLATE PATH" 'Shared FILE
							Select Case UCase(ItemStr)
								Case "PATH" : INITEMPLATEPATH = Mid(LineStr, pos + 1)
							End Select

						Case "PSN FOLDER PATH" 'Share FILE
							Select Case UCase(ItemStr)
								Case "PATH" : INIPSNFOLDERPATH = Mid(LineStr, pos + 1)
							End Select

						Case "MATERIAL PATH" 'RACK MATERIAL LIST
							Select Case UCase(ItemStr)
								Case "PATH" : INIMATERIALPATH = Mid(LineStr, pos + 1)
							End Select

						Case "ACHIEVE PATH"
							Select Case UCase(ItemStr)
								Case "PATH" : INIACHIEVEPATH = Mid(LineStr, pos + 1)
							End Select

						Case "STATUS PATH"
							Select Case UCase(ItemStr)
								Case "PATH" : INISTATUSPATH = Mid(LineStr, pos + 1)
							End Select

						Case "VACUUM PATH"
							Select Case UCase(ItemStr)
								Case "PATH" : INIVACUUMPATH = Mid(LineStr, pos + 1)
							End Select

						Case "PRINT PATH" 'LOCAL FILE
							Select Case UCase(ItemStr)
								Case "PATH" : INIPRINTPATH = Mid(LineStr, pos + 1)
							End Select
					End Select
				End If
			End If
		Loop

		FileClose(FNum)
	End Sub

	'Write data to PSN file
	Public Function WRITEPSNFILE(ProductPSN As String) As Boolean
		On Error GoTo ErrorHandler
		FNum = FreeFile()
		FileOpen(FNum, INIPSNFOLDERPATH & ProductPSN & ".Txt", OpenMode.Output)

		PrintLine(FNum)
		PrintLine(FNum, "[MODEL] : " & PSNFileInfo.ModelName)
		PrintLine(FNum)
		PrintLine(FNum, "[DATE CREATED] : " & PSNFileInfo.DateCreated)
		PrintLine(FNum)
		PrintLine(FNum, "[DATE COMPLETED] : " & PSNFileInfo.DateCompleted)
		PrintLine(FNum)
		PrintLine(FNum, "[OPERATOR ID] : " & PSNFileInfo.OperatorID)
		PrintLine(FNum)
		PrintLine(FNum, "[WORK ORDER NO] : " & PSNFileInfo.WONos)
		PrintLine(FNum)
		PrintLine(FNum, "[MAIN PCBA S/N] : " & PSNFileInfo.MainPCBA)
		PrintLine(FNum)
		PrintLine(FNum, "[SECONDARY PCBA S/N] : " & PSNFileInfo.SecondaryPCBA)
		PrintLine(FNum)
		PrintLine(FNum, "[ELECTROMAGNET S/N] : " & PSNFileInfo.ElectroMagnet)
		PrintLine(FNum)
		PrintLine(FNum, "[PSN] : " & PSNFileInfo.PSN)
		PrintLine(FNum)
		PrintLine(FNum, "[BODY ASSY STATION CHECK IN DATE] : " & PSNFileInfo.BodyAssyCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[BODY ASSY STATION CHECK OUT DATE] : " & PSNFileInfo.BodyAssyCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[BODY ASSY STATION STATUS] : " & PSNFileInfo.BodyAssyStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[SCREWING STATION CHECK IN DATE] : " & PSNFileInfo.ScrewStnCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[SCREWING STATION CHECK OUT DATE] : " & PSNFileInfo.ScrewStnCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[SCREWING STATION STATUS] : " & PSNFileInfo.ScrewStnStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST CHECK IN DATE] : " & PSNFileInfo.FTCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST CHECK OUT DATE] : " & PSNFileInfo.FTCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST SYNCH MEASUREMENT] : " & PSNFileInfo.FTSycMeas)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST STATUS] : " & PSNFileInfo.FTStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[STATION 5 CHECK IN DATE] : " & PSNFileInfo.Stn5CheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[STATION 5 CHECK OUT DATE] : " & PSNFileInfo.Stn5CheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[STATION 5 STATUS] : " & PSNFileInfo.Stn5Status)
		PrintLine(FNum)
		PrintLine(FNum, "[VACUUM CHECK IN DATE] : " & PSNFileInfo.VacuumCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[VACUUM CHECK OUT DATE] : " & PSNFileInfo.VacummCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[VACUUM STATUS] : " & PSNFileInfo.VacuumStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[PACKAGING CHECK IN DATE] : " & PSNFileInfo.PackagingCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[PACKAGING CHECK OUT DATE] : " & PSNFileInfo.PackagingCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[PACKAGING STATUS] : " & PSNFileInfo.PackagingStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG STATION #10 STATUS] : " & PSNFileInfo.DebugStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG COMMENTS] : " & PSNFileInfo.DebugComment)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG TECHNICIANS ID] : " & PSNFileInfo.DebugTechnican)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG DATE REPAIRED] : " & PSNFileInfo.RepairDate)
		FileClose(FNum)
		Return True
		Exit Function

ErrorHandler:
		Return False
	End Function

	Public Function LOADPSNFILE(ProductPSN As String) As Boolean
		Dim SectionHeading As String
		Dim pos1, pos2, pos3 As Integer

		FNum = FreeFile()
		If Dir(INIPSNFOLDERPATH & ProductPSN & ".Txt") = "" Then
			'SetDefaultINIValues
			'WriteINI
			Return False
			Exit Function
		Else
			FileOpen(FNum, INIPSNFOLDERPATH & ProductPSN & ".Txt", OpenMode.Input)

			Do While Not EOF(FNum)

				LineStr = LineInput(FNum)

				'Check for Section heading
				If InStr(LineStr, "[") > 0 And InStr(LineStr, "]") > 0 Then
					pos1 = InStr(LineStr, "[")
					pos2 = InStr(LineStr, "]")
					pos3 = InStr(LineStr, ":")

					SectionHeading = Mid(LineStr, pos1 + 1, pos2 - pos1 - 1)

					Select Case UCase(SectionHeading)
						Case "MODEL"
							PSNFileInfo.ModelName = Trim(Mid(LineStr, pos3 + 1))

						Case "DATE CREATED"
							PSNFileInfo.DateCreated = Trim(Mid(LineStr, pos3 + 1))

						Case "DATE COMPLETED"
							PSNFileInfo.DateCompleted = Trim(Mid(LineStr, pos3 + 1))

						Case "OPERATOR ID"
							PSNFileInfo.OperatorID = Trim(Mid(LineStr, pos3 + 1))

						Case "WORK ORDER NO"
							PSNFileInfo.WONos = Trim(Mid(LineStr, pos3 + 1))

						Case "MAIN PCBA S/N"
							PSNFileInfo.MainPCBA = Trim(Mid(LineStr, pos3 + 1))

						Case "SECONDARY PCBA S/N"
							PSNFileInfo.SecondaryPCBA = Trim(Mid(LineStr, pos3 + 1))

						Case "ELECTROMAGNET S/N"
							PSNFileInfo.ElectroMagnet = Trim(Mid(LineStr, pos3 + 1))

						Case "PSN"
							PSNFileInfo.PSN = Trim(Mid(LineStr, pos3 + 1))

						Case "BODY ASSY STATION CHECK IN DATE"
							PSNFileInfo.BodyAssyCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "BODY ASSY STATION CHECK OUT DATE"
							PSNFileInfo.BodyAssyCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "BODY ASSY STATION STATUS"
							PSNFileInfo.BodyAssyStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "SCREWING STATION CHECK IN DATE"
							PSNFileInfo.ScrewStnCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "SCREWING STATION CHECK OUT DATE"
							PSNFileInfo.ScrewStnCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "SCREWING STATION STATUS"
							PSNFileInfo.ScrewStnStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST CHECK IN DATE"
							PSNFileInfo.FTCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST CHECK OUT DATE"
							PSNFileInfo.FTCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST SYNCH MEASUREMENT"
							PSNFileInfo.FTSycMeas = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST STATUS"
							PSNFileInfo.FTStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "STATION 5 CHECK IN DATE"
							PSNFileInfo.Stn5CheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "STATION 5 CHECK OUT DATE"
							PSNFileInfo.Stn5CheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "STATION 5 STATUS"
							PSNFileInfo.Stn5Status = Trim(Mid(LineStr, pos3 + 1))

						Case "VACUUM CHECK IN DATE"
							PSNFileInfo.VacuumCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "VACUUM CHECK OUT DATE"
							PSNFileInfo.VacummCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "VACUUM STATUS"
							PSNFileInfo.VacuumStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "PACKAGING CHECK IN DATE"
							PSNFileInfo.PackagingCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "PACKAGING CHECK OUT DATE"
							PSNFileInfo.PackagingCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "PACKAGING STATUS"
							PSNFileInfo.PackagingStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG STATION #10 STATUS"
							PSNFileInfo.DebugStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG COMMENTS"
							PSNFileInfo.DebugComment = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG TECHNICIANS ID"
							PSNFileInfo.DebugTechnican = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG DATE REPAIRED"
							PSNFileInfo.RepairDate = Trim(Mid(LineStr, pos3 + 1))

					End Select
				End If
			Loop
			FileClose(FNum)
			Return True
		End If
	End Function

	'Write data to PSN file
	Public Function WRITEPSNFILEVAC(ProductPSN As String) As Boolean
		On Error GoTo ErrorHandler
		FNum = FreeFile()
		FileOpen(FNum, INIPSNFOLDERPATH & ProductPSN & ".Txt", OpenMode.Output)

		PrintLine(FNum)
		PrintLine(FNum, "[MODEL] : " & VacuumPSNFileInfo.ModelName)
		PrintLine(FNum)
		PrintLine(FNum, "[DATE CREATED] : " & VacuumPSNFileInfo.DateCreated)
		PrintLine(FNum)
		PrintLine(FNum, "[DATE COMPLETED] : " & VacuumPSNFileInfo.DateCompleted)
		PrintLine(FNum)
		PrintLine(FNum, "[OPERATOR ID] : " & VacuumPSNFileInfo.OperatorID)
		PrintLine(FNum)
		PrintLine(FNum, "[WORK ORDER NO] : " & VacuumPSNFileInfo.WONos)
		PrintLine(FNum)
		PrintLine(FNum, "[MAIN PCBA S/N] : " & VacuumPSNFileInfo.MainPCBA)
		PrintLine(FNum)
		PrintLine(FNum, "[SECONDARY PCBA S/N] : " & VacuumPSNFileInfo.SecondaryPCBA)
		PrintLine(FNum)
		PrintLine(FNum, "[ELECTROMAGNET S/N] : " & VacuumPSNFileInfo.ElectroMagnet)
		PrintLine(FNum)
		PrintLine(FNum, "[PSN] : " & VacuumPSNFileInfo.PSN)
		PrintLine(FNum)
		PrintLine(FNum, "[BODY ASSY STATION CHECK IN DATE] : " & VacuumPSNFileInfo.BodyAssyCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[BODY ASSY STATION CHECK OUT DATE] : " & VacuumPSNFileInfo.BodyAssyCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[BODY ASSY STATION STATUS] : " & VacuumPSNFileInfo.BodyAssyStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[SCREWING STATION CHECK IN DATE] : " & VacuumPSNFileInfo.ScrewStnCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[SCREWING STATION CHECK OUT DATE] : " & VacuumPSNFileInfo.ScrewStnCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[SCREWING STATION STATUS] : " & VacuumPSNFileInfo.ScrewStnStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST CHECK IN DATE] : " & VacuumPSNFileInfo.FTCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST CHECK OUT DATE] : " & VacuumPSNFileInfo.FTCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST SYNCH MEASUREMENT] : " & VacuumPSNFileInfo.FTSycMeas)
		PrintLine(FNum)
		PrintLine(FNum, "[FINAL TEST STATUS] : " & VacuumPSNFileInfo.FTStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[STATION 5 CHECK IN DATE] : " & VacuumPSNFileInfo.Stn5CheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[STATION 5 CHECK OUT DATE] : " & VacuumPSNFileInfo.Stn5CheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[STATION 5 STATUS] : " & VacuumPSNFileInfo.Stn5Status)
		PrintLine(FNum)
		PrintLine(FNum, "[VACUUM CHECK IN DATE] : " & VacuumPSNFileInfo.VacuumCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[VACUUM CHECK OUT DATE] : " & VacuumPSNFileInfo.VacummCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[VACUUM STATUS] : " & VacuumPSNFileInfo.VacuumStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[PACKAGING CHECK IN DATE] : " & VacuumPSNFileInfo.PackagingCheckIn)
		PrintLine(FNum)
		PrintLine(FNum, "[PACKAGING CHECK OUT DATE] : " & VacuumPSNFileInfo.PackagingCheckOut)
		PrintLine(FNum)
		PrintLine(FNum, "[PACKAGING STATUS] : " & VacuumPSNFileInfo.PackagingStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG STATION #10 STATUS] : " & VacuumPSNFileInfo.DebugStatus)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG COMMENTS] : " & VacuumPSNFileInfo.DebugComment)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG TECHNICIANS ID] : " & VacuumPSNFileInfo.DebugTechnican)
		PrintLine(FNum)
		PrintLine(FNum, "[DEBUG DATE REPAIRED] : " & VacuumPSNFileInfo.RepairDate)
		FileClose(FNum)

		Return True
		Exit Function
ErrorHandler:
		Return False
	End Function

	Public Function LOADPSNFILEVAC(ProductPSN As String) As Boolean
		Dim SectionHeading As String
		Dim pos1, pos2, pos3 As Integer

		FNum = FreeFile()
		If Dir(INIPSNFOLDERPATH & ProductPSN & ".Txt") = "" Then
			'SetDefaultINIValues
			'WriteINI
			Return False
			Exit Function
		Else
			FileOpen(FNum, INIPSNFOLDERPATH & ProductPSN & ".Txt", OpenMode.Input)

			Do While Not EOF(FNum)

				LineStr = LineInput(FNum)

				'Check for Section heading
				If InStr(LineStr, "[") > 0 And InStr(LineStr, "]") > 0 Then
					pos1 = InStr(LineStr, "[")
					pos2 = InStr(LineStr, "]")
					pos3 = InStr(LineStr, ":")

					SectionHeading = Mid(LineStr, pos1 + 1, pos2 - pos1 - 1)

					Select Case UCase(SectionHeading)
						Case "MODEL"
							VacuumPSNFileInfo.ModelName = Trim(Mid(LineStr, pos3 + 1))

						Case "DATE CREATED"
							VacuumPSNFileInfo.DateCreated = Trim(Mid(LineStr, pos3 + 1))

						Case "DATE COMPLETED"
							VacuumPSNFileInfo.DateCompleted = Trim(Mid(LineStr, pos3 + 1))

						Case "OPERATOR ID"
							VacuumPSNFileInfo.OperatorID = Trim(Mid(LineStr, pos3 + 1))

						Case "WORK ORDER NO"
							VacuumPSNFileInfo.WONos = Trim(Mid(LineStr, pos3 + 1))

						Case "MAIN PCBA S/N"
							VacuumPSNFileInfo.MainPCBA = Trim(Mid(LineStr, pos3 + 1))

						Case "SECONDARY PCBA S/N"
							VacuumPSNFileInfo.SecondaryPCBA = Trim(Mid(LineStr, pos3 + 1))

						Case "ELECTROMAGNET S/N"
							VacuumPSNFileInfo.ElectroMagnet = Trim(Mid(LineStr, pos3 + 1))

						Case "PSN"
							VacuumPSNFileInfo.PSN = Trim(Mid(LineStr, pos3 + 1))

						Case "BODY ASSY STATION CHECK IN DATE"
							VacuumPSNFileInfo.BodyAssyCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "BODY ASSY STATION CHECK OUT DATE"
							VacuumPSNFileInfo.BodyAssyCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "BODY ASSY STATION STATUS"
							VacuumPSNFileInfo.BodyAssyStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "SCREWING STATION CHECK IN DATE"
							VacuumPSNFileInfo.ScrewStnCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "SCREWING STATION CHECK OUT DATE"
							VacuumPSNFileInfo.ScrewStnCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "SCREWING STATION STATUS"
							VacuumPSNFileInfo.ScrewStnStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST CHECK IN DATE"
							VacuumPSNFileInfo.FTCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST CHECK OUT DATE"
							VacuumPSNFileInfo.FTCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST SYNCH MEASUREMENT"
							VacuumPSNFileInfo.FTSycMeas = Trim(Mid(LineStr, pos3 + 1))

						Case "FINAL TEST STATUS"
							VacuumPSNFileInfo.FTStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "STATION 5 CHECK IN DATE"
							VacuumPSNFileInfo.Stn5CheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "STATION 5 CHECK OUT DATE"
							VacuumPSNFileInfo.Stn5CheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "STATION 5 STATUS"
							VacuumPSNFileInfo.Stn5Status = Trim(Mid(LineStr, pos3 + 1))

						Case "VACUUM CHECK IN DATE"
							VacuumPSNFileInfo.VacuumCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "VACUUM CHECK OUT DATE"
							VacuumPSNFileInfo.VacummCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "VACUUM STATUS"
							VacuumPSNFileInfo.VacuumStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "PACKAGING CHECK IN DATE"
							VacuumPSNFileInfo.PackagingCheckIn = Trim(Mid(LineStr, pos3 + 1))

						Case "PACKAGING CHECK OUT DATE"
							VacuumPSNFileInfo.PackagingCheckOut = Trim(Mid(LineStr, pos3 + 1))

						Case "PACKAGING STATUS"
							VacuumPSNFileInfo.PackagingStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG STATION #10 STATUS"
							VacuumPSNFileInfo.DebugStatus = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG COMMENTS"
							VacuumPSNFileInfo.DebugComment = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG TECHNICIANS ID"
							VacuumPSNFileInfo.DebugTechnican = Trim(Mid(LineStr, pos3 + 1))

						Case "DEBUG DATE REPAIRED"
							VacuumPSNFileInfo.RepairDate = Trim(Mid(LineStr, pos3 + 1))

					End Select
				End If
			Loop
			FileClose(FNum)
			Return True
		End If
	End Function
End Module
