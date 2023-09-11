Option Explicit On
Module modGeneral
    Public Sub GetLastConfig()
        Dim Filenum As Integer
        Filenum = FreeFile()
        Dim tempcode As String
        Dim pos1, pos2, pos3, pos4, pos5 As Integer

        FileOpen(Filenum, INISTATUSPATH, OpenMode.Input)
        tempcode = LineInput(Filenum)
        FileClose(Filenum)
        pos1 = InStr(1, tempcode, ",")
        pos2 = InStr(pos1 + 1, tempcode, ",")
        pos3 = InStr(pos2 + 1, tempcode, ",")
        pos4 = InStr(pos3 + 1, tempcode, ",")

        LoadWOfrRFID.JobNos = Mid(tempcode, 1, pos1 - 1)
        LoadWOfrRFID.JobModelName = Mid(tempcode, pos1 + 1, (pos2 - pos1) - 1)
        LoadWOfrRFID.JobQTy = CInt(Mid(tempcode, pos2 + 1, (pos3 - pos2) - 1))
        LoadWOfrRFID.JobArticle = Model2Article(LoadWOfrRFID.JobModelName)
        LoadWOfrRFID.JobRFIDTag = Mid(tempcode, pos3 + 1, (pos4 - pos3) - 1)
        LoadWOfrRFID.JobUnitaryCount = CInt(Mid(tempcode, pos4 + 1))
    End Sub

    Public Sub GetVacuumConfig()
        Dim Filenum As Integer
        Filenum = FreeFile()
        Dim tempcode As String
        Dim pos1, pos2, pos3, pos4, pos5 As Integer

        FileOpen(Filenum, INIVACUUMPATH, OpenMode.Input)
        tempcode = LineInput(Filenum)
        FileClose(Filenum)
        pos1 = InStr(1, tempcode, ",")
        pos2 = InStr(pos1 + 1, tempcode, ",")
        pos3 = InStr(pos2 + 1, tempcode, ",")
        pos4 = InStr(pos3 + 1, tempcode, ",")

        'LoadWOfrRFID.JobNos = Mid(tempcode, 1, pos1 - 1)
        'LoadWOfrRFID.JobModelName = Mid(tempcode, pos1 + 1, (pos2 - pos1) - 1)
        'LoadWOfrRFID.JobQTy = Mid(tempcode, pos2 + 1, (pos3 - pos2) - 1)
        'LoadWOfrRFID.JobArticle = Model2Article(LoadWOfrRFID.JobModelName)
        'LoadWOfrRFID.JobRFIDTag = Mid(tempcode, pos3 + 1, (pos4 - pos3) - 1)
        LoadWOfrRFID.JobVacuumCount = CShort(Mid(tempcode, pos4 + 1))
    End Sub

    Public Function Article2Model(ArtNos As String) As String
        Dim readqty As String
        Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ArticleNos = '" & ArtNos & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        readqty = dt.Rows(0).Item("ModelName")
        Return readqty
    End Function

    Public Function Model2Article(csmodel As String) As String
        Dim readqty As String
        Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        readqty = dt.Rows(0).Item("ArticleNos")
        Return readqty
    End Function

    Public Function NextCounter(LastCounter As String) As String
        Dim temp As String

        temp = CStr(CInt(LastCounter) + 1)

        If CInt(temp) >= 9999 Then
            MsgBox("Maximum counter 9999!", MsgBoxStyle.Critical)
            Exit Function
        End If

        If Len(temp) = 1 Then
            temp = "0000" & temp
        ElseIf Len(temp) = 2 Then
            temp = "000" & temp
        ElseIf Len(temp) = 3 Then
            temp = "00" & temp
        ElseIf Len(temp) = 4 Then
            temp = "0" & temp
        End If

        Return temp
    End Function

    Public Function VerifyPart1(csmodel As String, scannos As String) As Boolean
        Dim readqty As String
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        readqty = dt.Rows(0).Item("Accessory1")
        If readqty = scannos Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerifyPart2(csmodel As String, scannos As String) As Boolean
        Dim readqty As String
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        readqty = dt.Rows(0).Item("Accessory2")
        If readqty = scannos Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerifyPart3(csmodel As String, scannos As String) As Boolean
        Dim readqty As String
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        readqty = dt.Rows(0).Item("Accessory3")
        If readqty = scannos Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerifyPart4(csmodel As String, scannos As String) As Boolean
        Dim readqty As String
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        readqty = dt.Rows(0).Item("InstructionSheet")
        If readqty = scannos Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckTotalItem(csmodel As String) As Integer
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        Dim ItemCount As Integer

        If dt.Rows(0).Item("Accessory1") <> "" Then ItemCount = ItemCount + 1
        If dt.Rows(0).Item("Accessory2") <> "" Then ItemCount = ItemCount + 1
        If dt.Rows(0).Item("Accessory3") <> "" Then ItemCount = ItemCount + 1
        If dt.Rows(0).Item("InstructionSheet") <> "" Then ItemCount = ItemCount + 1

        Return ItemCount
    End Function

    Public Sub LogCompletedPSN(serialnos As String)
        Dim Filenum As Integer
        Filenum = FreeFile()

        FileOpen(Filenum, INIPRINTPATH & Mid(serialnos, 10, 4) & ".CSV", OpenMode.Append)
        With PSNFileInfo
            PrintLine(Filenum, "P" & .PSN & "," & .ModelName & "," & .DateCreated & "," & .DateCompleted & "," & .WONos & "," & .MainPCBA & "," & .SecondaryPCBA & "," & .ElectroMagnet & "," & .ScrewStnCheckIn & "," & .ScrewStnCheckOut & "," & .ScrewStnStatus & "," & .FTCheckIn & "," & .FTCheckOut & "," & .FTStatus & "," & .Stn5CheckIn & "," & .Stn5CheckOut & "," & .Stn5Status & "," & .VacuumCheckIn & "," & .VacummCheckOut & "," & .VacuumStatus & "," & .PackagingCheckIn & "," & .PackagingCheckOut & "," & .PackagingStatus & "," & .DebugStatus & "," & .DebugComment & "," & .DebugTechnican & "," & .RepairDate)
        End With
        FileClose(Filenum)
    End Sub

    Public Sub UpdateStnStatus()
        Dim Filenum1 As Integer
        Filenum1 = FreeFile()
        FileOpen(Filenum1, INISTATUSPATH, OpenMode.Output)
        PrintLine(Filenum1, LoadWOfrRFID.JobNos & "," & LoadWOfrRFID.JobModelName & "," & LoadWOfrRFID.JobQTy & "," & LoadWOfrRFID.JobRFIDTag & "," & LoadWOfrRFID.JobUnitaryCount)
        FileClose(Filenum1)
    End Sub

    Public Sub UpdateVacuumStatus()
        Dim Filenum1 As Integer
        Filenum1 = FreeFile()
        FileOpen(Filenum1, INIVACUUMPATH, OpenMode.Output)
        PrintLine(Filenum1, LoadWOfrRFID.JobNos & "," & LoadWOfrRFID.JobModelName & "," & LoadWOfrRFID.JobQTy & "," & LoadWOfrRFID.JobRFIDTag & "," & LoadWOfrRFID.JobVacuumCount)
        FileClose(Filenum1)
    End Sub
End Module
