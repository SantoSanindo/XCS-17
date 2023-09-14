Option Explicit On
Imports System.IO
Imports System.Threading
Imports System.Net
Public Class frmMain
    Dim AssyBuf As String 'Comm Buffer for Barcode scanner for packaging
    Dim VacuumBuf As String 'Comm Buffer for Barcode scanner for Vacuum
    Dim ReadTagFlag As Boolean 'True when Timer1 is reading Tag
    Public Action As Integer
    Public Scanmode As Integer
    Dim AccessoryFlag(4) As Boolean
    Public ItemCount As Integer

    Private Sub cmd_quit_Click(sender As Object, e As EventArgs) Handles cmd_quit.Click
        CloseCodesoft()
        UpdateStnStatus()
        BarcodeScan_Comm.Close()
        Vacuumscan_Comm.Close()
        RFID_Comm.Close()
        End
    End Sub

    Private Sub cmd_testspec_Click(sender As Object, e As EventArgs) Handles cmd_testspec.Click
        Frm_labelspec.ShowDialog()
    End Sub

    Private Sub cmd_reprint_Click(sender As Object, e As EventArgs) Handles cmd_reprint.Click
        Scanmode = 3
        frmSelect.Show()
        frmSelect.Label2.Text = "Scan the product PSN for reprint..."
    End Sub

    Private Sub Cmd_Visual_Click(sender As Object, e As EventArgs) Handles Cmd_Visual.Click
        Scanmode = 2
        frmSelect.Show()
        frmSelect.Label2.Text = "Scan the product PSN for Visual Reject..."
    End Sub

    Private Sub Cmd_CloseTag_Click(sender As Object, e As EventArgs) Handles Cmd_CloseTag.Click
        Dim ReadTagID As String
        Cmd_CloseTag.Enabled = False
        Timer1.Enabled = False
        Thread.Sleep(20)
        Dim Feedback As Integer
        If Val(lbl_unitaryCount.Text) < Val(lbl_wocounter.Text) Then
            'MsgBox "WO Quantity not reached. Unable to close WO."
            Feedback = MsgBox("WO QUANTITY NOT REACHED.DO YOU WANT TO FORCE CLOSE?", MsgBoxStyle.YesNo)
            If Feedback = 6 Then 'YES
                MsgBox("Please place tag onto sensor...")
            ElseIf Feedback = 7 Then  'NO
                Timer1.Enabled = True
                Cmd_CloseTag.Enabled = True
                Exit Sub
            End If
        End If

        Txt_Msg.Text = Txt_Msg.Text & "Reading RFID Tag..." & vbCrLf
        Txt_Msg.Text = Txt_Msg.Text & "Please wait..." & vbCrLf
        'Dim ReadTagID As String
        RFID_Comm.DiscardInBuffer()
        ReadTagID = RD_MULTI_RFID("0040", 3) 'Read Tag ID

        If ReadTagID = "NOK" Then
            Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
            Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
            ReadTagFlag = False
            Timer1.Enabled = True
            Exit Sub
        End If
        If ReadTagID <> lbl_tagnos.Text Then
            Txt_Msg.Text = "--> 1 - Incorrect Tag - Tag is not conform to the WO" & vbCrLf
            Txt_Msg.Text = "Place the correct tag and click <Close Tag> to retry" & vbCrLf
            Txt_Msg.BackColor = Color.Red
            Timer1.Enabled = True
            Exit Sub
        End If
        Txt_Msg.Text = Txt_Msg.Text & "Writing actual quantity to RFID Tag..." & vbCrLf
        Txt_Msg.Text = Txt_Msg.Text & "Please wait..." & vbCrLf
        Thread.Sleep(10)
        Dim temp As String
        Dim templen As Integer

        templen = Len(lbl_unitaryCount.Text)
        temp = Mid("000000", 1, 6 - templen) & lbl_unitaryCount.Text
        If Not Wr_Tag(temp, "0046") Then
            Txt_Msg.Text = "2 --> Unable to write on RFID Tag - 0046" & vbCrLf
            Txt_Msg.Text = "Click <Close Tag> to retry" & vbCrLf
            Txt_Msg.BackColor = Color.Red
            Cmd_CloseTag.Enabled = True
            AssyBuf = ""
            Timer1.Enabled = True
            Exit Sub
        End If
        Txt_Msg.Text = Txt_Msg.Text & "Tag closed" & vbCrLf
        Cmd_CloseTag.Enabled = True
        Timer1.Enabled = True
    End Sub

    Private Sub cmd_Refresh_Click(sender As Object, e As EventArgs) Handles cmd_Refresh.Click
        Timer1.Enabled = False
        cmd_Refresh.Enabled = False
        GetLastConfig()
        LoadLabelParameter(LoadWOfrRFID.JobModelName)
        lbl_WOnos.Text = LoadWOfrRFID.JobNos
        lbl_currentref.Text = LoadWOfrRFID.JobModelName
        lbl_wocounter.Text = CStr(LoadWOfrRFID.JobQTy)
        lbl_unitaryCount.Text = CStr(LoadWOfrRFID.JobUnitaryCount)
        lbl_tagnos.Text = LoadWOfrRFID.JobRFIDTag
        lbl_groupCount.Text = CStr(TotalGrpCount)
        lbl_ArticleNos.Text = LoadWOfrRFID.JobArticle
        Reset_PLC()
        'Load Rack Material List
        If Not LoadRackMaterial() Then
            MsgBox("Unable to load Rack Materials")
            Timer1.Enabled = True
            cmd_Refresh.Enabled = True
            Exit Sub
        End If
        'Load Model Material
        If Not LoadModelMaterial(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Model Material")
            Timer1.Enabled = True
            cmd_Refresh.Enabled = True
            Exit Sub
        End If
        'Update Rack indicator
        If Not ActivateRackLED() Then
            MsgBox("Unable to communicate with PLC")
            Timer1.Enabled = True
            cmd_Refresh.Enabled = True
            Exit Sub
        End If

        Timer1.Enabled = True
        cmd_Refresh.Enabled = True
    End Sub

    Private Sub cmd_Modbus_Click(sender As Object, e As EventArgs) Handles cmd_Modbus.Click
        Modbus.ShowDialog()
    End Sub

    Private Sub ReferenceSelector_Click(sender As Object, e As EventArgs) Handles ReferenceSelector.Click
        If ReferenceSelector.Text = "Plastic" Then
            ReferenceSelector.Text = "Zamak M20"
            Modbus.tulisModbus(40400, 1)
        ElseIf ReferenceSelector.Text = "Zamak M20" Then
            ReferenceSelector.Text = "Zamak 1/2NPT"
            Modbus.tulisModbus(40400, 2)
        ElseIf ReferenceSelector.Text = "Zamak 1/2NPT" Then
            ReferenceSelector.Text = "E-Stop"
            Modbus.tulisModbus(40400, 3)
        ElseIf ReferenceSelector.Text = "E-Stop" Then
            ReferenceSelector.Text = "Plastic"
            Modbus.tulisModbus(40400, 0)
        End If
    End Sub

    Private Sub Command2_Click(sender As Object, e As EventArgs) Handles Command2.Click
        If Command2.Text = "PRINT" Then
            Command2.Text = "NO PRINT"
        Else
            Command2.Text = "PRINT"
        End If
    End Sub

    Private Sub Command3_Click(sender As Object, e As EventArgs) Handles Command3.Click
        Modbus.tulisModbus(40101, 10)
    End Sub

    Private Sub Command1_Click(sender As Object, e As EventArgs) Handles Command1.Click
        If Command1.Text = "Eye Open" Then
            If Not Modbus.tulisModbus(40109, 1) Then
                Txt_Msg.Text = "--> Unable to communicate with PLC - %MW109"
                Exit Sub
            End If
            Command1.Text = "Eye Close"

        ElseIf Command1.Text = "Eye Close" Then
            If Not Modbus.tulisModbus(40109, 0) Then
                Txt_Msg.Text = "--> Unable to communicate with PLC - %MW109"
                Exit Sub
            End If
            Command1.Text = "Eye Open"
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        If Command1.Visible = False Then
            Command1.Visible = True
            Command3.Visible = True
            Command2.Visible = True
            ReferenceSelector.Visible = True
        Else
            Command1.Visible = False
            Command2.Visible = False
            Command3.Visible = False
            ReferenceSelector.Visible = False
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fullPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim projectFolder As String = fullPath.Replace("\XCS-17\bin\Debug\", "").Replace("\XCS-17\bin\Release\", "")

        If Dir(projectFolder & "\Config\Config.INI") = "" Then 'This is to initalize the program during start up
            MsgBox("Config.INI is missing")
            End
        End If
        ReadINI(projectFolder & "\Config\Config.INI")

        GetLastConfig()
        GetVacuumConfig()
        'Modbus
        frmMsg.Show()
        frmMsg.Label1.Text = "Establishing link with PLC..."
        Modbus.Show()
        Modbus.Hide()
        If Modbus.lbl_status.Text <> "Connected" Then
            Ethernet.BackColor = Color.Red
            End
        End If
        frmMsg.Label1.Text = "Connection to PLC established"
        'frmMsg.Hide()
        Ethernet.BackColor = Color.Lime

        Dim strHostName As String = Dns.GetHostName()
        Dim hostname As IPHostEntry = Dns.GetHostByName(strHostName)
        Dim ip As IPAddress() = hostname.AddressList
        lbl_localhostname.Text = "PC Name : " & strHostName
        lbl_localip.Text = "PC IP Address : " & ip(0).ToString

        Thread.Sleep(10)
        Reset_PLC()

        frmMsg.Label1.Text = "Loading CodeSoft..."
        killLPPA()
        OpenCodesoft()

        frmMsg.Label1.Text = "Loading parameters..."
        'Load parameters
        LoadLabelParameter(LoadWOfrRFID.JobModelName)
        If Not LoadParameter(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load from database")
            End
        End If
        lbl_WOnos.Text = LoadWOfrRFID.JobNos
        lbl_currentref.Text = LoadWOfrRFID.JobModelName
        lbl_wocounter.Text = CStr(LoadWOfrRFID.JobQTy)
        lbl_unitaryCount.Text = CStr(LoadWOfrRFID.JobUnitaryCount)
        lbl_tagnos.Text = LoadWOfrRFID.JobRFIDTag
        lbl_groupCount.Text = CStr(TotalGrpCount)
        Label11.Text = CStr(LoadWOfrRFID.JobVacuumCount)
        lbl_ArticleNos.Text = LoadWOfrRFID.JobArticle
        LoadWOfrRFID.JobItemCount = CheckTotalItem(LoadWOfrRFID.JobModelName)
        ItemCount = LoadWOfrRFID.JobItemCount

        'Load Rack Material List
        If Not loadparameter2plc() Then
            MsgBox("Unable to communicate with PLC - MW400")
            End
        End If
        If Not LoadRackMaterial() Then
            MsgBox("Unable to load Rack Materials")
            End
        End If
        'Load Model Material
        If Not LoadModelMaterial(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Model Material")
            End
        End If
        'Update Rack indicator
        If Not ActivateRackLED() Then
            MsgBox("Unable to communicate with PLC")
            End
        End If

        frmMsg.Close()
        RFID_Comm.Open()
        BarcodeScan_Comm.Open()
        Vacuumscan_Comm.Open()
        Timer1.Enabled = True
    End Sub

    Private Sub Reset_PLC()
        Modbus.tulisModbus(40500, 1)
    End Sub

    Private Sub LoadLabelParameter(csmodel As String)
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        LabelVar.UnitModelName = "" & dt.Rows(0).Item("Unitary_Reference")
        LabelVar.UnitArticleNos = "" & dt.Rows(0).Item("ArticleNos")
        LabelVar.UnitImage = "" & dt.Rows(0).Item("Unitary_Img")
        LabelVar.UnitLabelTemplate = "" & dt.Rows(0).Item("Unitary_Template")
        LabelVar.GrpLabelImage = "" & dt.Rows(0).Item("Group_Img")
        LabelVar.GrpQty = CInt("" & dt.Rows(0).Item("Group_Qty"))
        LabelVar.GrpLabelTemplate = "" & dt.Rows(0).Item("Group_Template")
        LabelVar.UnitSymbolType = "" & dt.Rows(0).Item("Unitary_Symbol")
        LabelVar.UnitTension = "" & dt.Rows(0).Item("Unitary_Tension")
    End Sub

    Private Sub LoadReprintLabelParameter(csmodel As String)
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        ReprintLabelVar.UnitModelName = "" & dt.Rows(0).Item("Unitary_Reference")
        ReprintLabelVar.UnitArticleNos = "" & dt.Rows(0).Item("ArticleNos")
        ReprintLabelVar.UnitImage = "" & dt.Rows(0).Item("Unitary_Img")
        ReprintLabelVar.UnitLabelTemplate = "" & dt.Rows(0).Item("Unitary_Template")
        ReprintLabelVar.GrpLabelImage = "" & dt.Rows(0).Item("Group_Img")
        ReprintLabelVar.GrpQty = CInt("" & dt.Rows(0).Item("Group_Qty"))
        ReprintLabelVar.GrpLabelTemplate = "" & dt.Rows(0).Item("Group_Template")
        ReprintLabelVar.UnitSymbolType = "" & dt.Rows(0).Item("Unitary_Symbol")
        ReprintLabelVar.UnitTension = "" & dt.Rows(0).Item("Unitary_Tension")
    End Sub

    Private Function LoadParameter(csmodel As String) As Boolean
        Try
            Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & csmodel & "'"
            Dim dt = KoneksiDB.bacaData(query).Tables(0)

            VacuumPara.UnitMaterial = "" & dt.Rows(0).Item("MaterialType")
            VacuumPara.UnitThread = "" & dt.Rows(0).Item("BodyType")
            VacuumPara.UnitBtnOpt = "" & dt.Rows(0).Item("ButtonOpt")

            Return True
            Exit Function
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function loadparameter2plc() As Boolean
        If VacuumPara.UnitMaterial = "Plastic" Then
            Modbus.tulisModbus(40400, 0)
        ElseIf VacuumPara.UnitMaterial = "Zamak" Then
            If VacuumPara.UnitBtnOpt = "Yes" Then
                Modbus.tulisModbus(40400, 3)
            Else
                If VacuumPara.UnitThread = "M20" Then
                    Modbus.tulisModbus(40400, 1)
                ElseIf VacuumPara.UnitThread = "1/2 NPT" Then
                    Modbus.tulisModbus(40400, 2)
                End If
            End If
        End If
        Return True
    End Function

    Private Function LoadRackMaterial() As Boolean
        Dim filePath As String = INIMATERIALPATH & "Rack\" & "Station6"

        If File.Exists(filePath) Then
            Dim lines As String() = File.ReadAllLines(filePath)
            Dim lineArray As New List(Of String)()

            For Each line As String In lines
                lineArray.Add(line)
            Next
            UnitMaterial.PartNos = lineArray.ToArray()

            ReDim UnitMaterial.PartPLCWord(lines.Length - 1)
            For i As Integer = 0 To lines.Length - 1
                UnitMaterial.PartPLCWord(i) = 40200 + i
            Next

            Return True
        Else
            Return False
        End If
    End Function

    Private Function LoadModelMaterial(Unitname As String) As Boolean
        Dim filePath As String = INIMATERIALPATH & "Station6\" & Unitname & ".Txt"

        If File.Exists(filePath) Then
            Dim lines As String() = File.ReadAllLines(filePath)
            Dim lineArray As New List(Of String)()

            For Each line As String In lines
                lineArray.Add(line)
            Next
            LoadWOfrRFID.JobModelMaterial = lineArray.ToArray()
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ActivateRackLED() As Boolean
        Dim i As Integer
        Dim N As Integer

        For i = 0 To LoadWOfrRFID.JobModelMaterial.Length - 1
            If LoadWOfrRFID.JobModelMaterial(i) <> "" Then
                For N = 0 To UnitMaterial.PartNos.Length - 1
                    If LoadWOfrRFID.JobModelMaterial(i) = UnitMaterial.PartNos(N) Then
                        If Not Modbus.tulisModbus(UnitMaterial.PartPLCWord(N), 1) Then
                            GoTo ErrorHandler
                        End If
                    End If
                Next
            End If
        Next

        Return True
        Exit Function
ErrorHandler:
        Return False
    End Function

    Public Function CBoxNumber(Packed As Integer, QtyPBox As Integer) As Integer
        Dim Qloop, BNumber As Integer

        Qloop = QtyPBox
        BNumber = 1

        While Qloop < Packed
            Qloop = Qloop + QtyPBox
            BNumber = BNumber + 1
        End While

        Return BNumber
    End Function

    Public Sub PrintLabel()
        ActiveDoc.Variables.FormVariables.Item("Var0").Value = LabelVar.UnitModelName
        ActiveDoc.Variables.FormVariables.Item("Var1").Value = LabelVar.UnitArticleNos
        ActiveDoc.Variables.FormVariables.Item("Var2").Value = LabelVar.UnitImage
        ActiveDoc.Variables.FormVariables.Item("Var3").Value = LabelVar.UnitTension
        ActiveDoc.Variables.FormVariables.Item("Var6").Value = Mid(PSNFileInfo.PSN, 10, 4)
        ActiveDoc.Variables.FormVariables.Item("Var8").Value = INIPHOTOPATH & LabelVar.UnitSymbolType
        ActiveDoc.CopyToClipboard()
        Image_preview_unitary.Image = My.Computer.Clipboard.GetImage()

        Txt_Msg.Text = "Please Wait......" & vbCrLf & "Printing Unitary Label .... " & vbCrLf

        If PrintLab(1) = False Then
            MsgBox("Error. Can't to print...", MsgBoxStyle.Critical)
        End If
    End Sub

    Public Sub RePrintLabel(Datecode As String)
        ActiveDoc.Variables.FormVariables.Item("Var0").Value = ReprintLabelVar.UnitModelName
        ActiveDoc.Variables.FormVariables.Item("Var1").Value = ReprintLabelVar.UnitArticleNos
        ActiveDoc.Variables.FormVariables.Item("Var2").Value = ReprintLabelVar.UnitImage
        ActiveDoc.Variables.FormVariables.Item("Var3").Value = ReprintLabelVar.UnitTension
        ActiveDoc.Variables.FormVariables.Item("Var6").Value = Datecode
        ActiveDoc.Variables.FormVariables.Item("Var8").Value = INIPHOTOPATH & ReprintLabelVar.UnitSymbolType

        frmSelect.Label2.Text = "Please Wait......" & vbCrLf & "Printing Unitary Label .... " & vbCrLf

        If PrintLab(1) = False Then
            MsgBox("Error. Can't to print...", MsgBoxStyle.Critical)
        End If
    End Sub

    Public Sub PrintGrpLabel()
        ActiveDoc.Variables.FormVariables.Item("Var0").Value = LabelVar.UnitModelName
        ActiveDoc.Variables.FormVariables.Item("Var1").Value = LabelVar.UnitArticleNos
        ActiveDoc.Variables.FormVariables.Item("Var2").Value = LabelVar.GrpLabelImage
        ActiveDoc.Variables.FormVariables.Item("Var3").Value = LabelVar.UnitTension
        ActiveDoc.Variables.FormVariables.Item("Var6").Value = Mid(PSNFileInfo.PSN, 10, 4)
        ActiveDoc.Variables.FormVariables.Item("Var8").Value = INIPHOTOPATH & LabelVar.UnitSymbolType
        ActiveDoc.Variables.FormVariables.Item("PO").Value = lbl_WOnos.Text
        ActiveDoc.Variables.FormVariables.Item("BoxNumber").Value = CStr(CBoxNumber(Val(lbl_unitaryCount.Text), LabelVar.GrpQty))
        ActiveDoc.CopyToClipboard()

        Image_preview_group.Image = My.Computer.Clipboard.GetImage()

        lbl_msg.Text = "Please Wait......" & vbCrLf & "Printing Grouping Label .... " & vbCrLf

        If PrintLab(1) = False Then
            MsgBox("Error. Can't to print...", MsgBoxStyle.Critical)
        End If
    End Sub

    Public Sub RePrintGrpLabel(Datecode As String)
        ActiveDoc.Variables.FormVariables.Item("Var0").Value = ReprintLabelVar.UnitModelName
        ActiveDoc.Variables.FormVariables.Item("Var1").Value = ReprintLabelVar.UnitArticleNos
        ActiveDoc.Variables.FormVariables.Item("Var2").Value = ReprintLabelVar.GrpLabelImage
        ActiveDoc.Variables.FormVariables.Item("Var3").Value = ReprintLabelVar.UnitTension
        ActiveDoc.Variables.FormVariables.Item("Var6").Value = Datecode
        ActiveDoc.Variables.FormVariables.Item("Var8").Value = INIPHOTOPATH & ReprintLabelVar.UnitSymbolType

        frmSelect.Label2.Text = "Please Wait......" & vbCrLf & "Printing Grouping Label .... " & vbCrLf

        If PrintLab(1) = False Then
            MsgBox("Error. Can't to print...", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Function ValidiateWONos(strName As String) As String
        Try
            Dim temp As String
            Dim query = "SELECT * FROM TESE.dbo.CSUNIT WHERE WONOS = '" & strName & "'"
            Dim dt = KoneksiDB.bacaData(query).Tables(0)

            temp = dt.Rows(0).Item("STATUS")
            Return temp
        Catch ex As Exception
            Return "NOK"
        End Try
    End Function

    Private Function RefCheck(strName As String) As Boolean
        Dim query = "SELECT * FROM TESE.dbo.Label WHERE ModelName = '" & strName & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        If dt.Rows(0).Item("ModelName") = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub ClearScreen()
        Txt_Msg.Text = ""
        lbl_msg.Text = ""
        Image1.Image = Nothing
        Image_preview_unitary.Image = Nothing
        Image_preview_unitary.Visible = False
        Image_preview_group.Image = Nothing
        Image_preview_group.Visible = False
    End Sub

    Private Sub BarcodeScan_Comm_DataReceived(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles BarcodeScan_Comm.DataReceived
        AssyBuf = BarcodeScan_Comm.ReadExisting()
        Me.Invoke(Sub()
                      If InStr(1, AssyBuf, vbCrLf) <> 0 Then
                          If Scanmode = 0 Then
                              Txt_Msg.BackColor = Color.LightGray
                              Txt_Msg.Text = ""
                              lbl_msg.Text = ""
                              Image1.Image = Nothing
                              Image_preview_unitary.Image = Nothing
                              Image_preview_group.Image = Nothing
                              AssyBuf = Mid(AssyBuf, 1, InStr(1, AssyBuf, vbCr) - 1)
                              ClearScreen()

                              'Check if the Work Order Quantity is reached
                              If Val(lbl_unitaryCount.Text) >= LoadWOfrRFID.JobQTy Then
                                  Txt_Msg.Text = "WORK ORDER COMPLETED"
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              End If

                              If Microsoft.VisualBasic.Left(AssyBuf, 6) <> LoadWOfrRFID.JobArticle Then
                                  Txt_Msg.Text = "--> PSN - " & AssyBuf & " = wrong reference"
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              Else
                                  Txt_Msg.Text = "PSN - " & AssyBuf & vbCrLf
                              End If

                              Txt_Msg.Text = Txt_Msg.Text & "Loading" & AssyBuf & ".Txt..." & vbCrLf
                              If Dir(INIPSNFOLDERPATH & AssyBuf & ".Txt") = "" Then
                                  Txt_Msg.Text = "--> Unable to find " & AssyBuf & ".Txt" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                              If Not LOADPSNFILE(AssyBuf) Then
                                  Txt_Msg.Text = "--> Unable to load " & AssyBuf & ".Txt" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                              PSNFileInfo.PackagingCheckIn = Today & "," & TimeOfDay
                              PSNFileInfo.PSN = AssyBuf
                              Cmd_Visual.Enabled = False
                              Txt_Msg.Text = Txt_Msg.Text & "Verifying PSN..." & vbCrLf
                              If PSNFileInfo.VacuumStatus <> "PASS" Then
                                  Txt_Msg.Text = "--> PSN skip process" & vbCrLf & "--> Please go back to previous station" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              Else
                                  PSNFileInfo.PackagingCheckIn = Today & "," & TimeOfDay
                                  'If Not Write_PLC_Word(105, 1) Then
                                  '    Txt_Msg.Text = "--> Unable to communicate with PLC - MW105" & vbCrLf
                                  '   Txt_Msg.BackColor = vbRed
                                  '   AssyBuf = ""
                                  '   Exit Sub
                                  'End If
                              End If
                              Txt_Msg.Text = Txt_Msg.Text & "PSN Verified" & vbCrLf
                              lbl_msg.Text = "Please scan accessory and instruction sheet..."
                              Scanmode = 1
                              AssyBuf = ""
                          ElseIf Scanmode = 1 Then
                              AssyBuf = Mid(AssyBuf, 1, InStr(1, AssyBuf, vbCr) - 1)
                              If AccessoryFlag(1) = False Then
                                  If VerifyPart1(PSNFileInfo.ModelName, AssyBuf) Then
                                      AccessoryFlag(1) = True
                                      ItemCount = ItemCount - 1
                                      If ItemCount = 0 Then
                                          AccessoryFlag(1) = False
                                          AccessoryFlag(2) = False
                                          AccessoryFlag(3) = False
                                          AccessoryFlag(4) = False
                                          GoTo ProcessPSN
                                      End If
                                      AssyBuf = ""
                                      Exit Sub
                                  End If
                              End If
                              If AccessoryFlag(2) = False Then
                                  If VerifyPart2(PSNFileInfo.ModelName, AssyBuf) Then
                                      AccessoryFlag(2) = True
                                      ItemCount = ItemCount - 1
                                      If ItemCount = 0 Then
                                          AccessoryFlag(1) = False
                                          AccessoryFlag(2) = False
                                          AccessoryFlag(3) = False
                                          AccessoryFlag(4) = False
                                          GoTo ProcessPSN
                                      End If
                                      AssyBuf = ""
                                      Exit Sub
                                  End If
                              End If
                              If AccessoryFlag(3) = False Then
                                  If VerifyPart3(PSNFileInfo.ModelName, AssyBuf) Then
                                      AccessoryFlag(3) = True
                                      ItemCount = ItemCount - 1
                                      If ItemCount = 0 Then
                                          AccessoryFlag(1) = False
                                          AccessoryFlag(2) = False
                                          AccessoryFlag(3) = False
                                          AccessoryFlag(4) = False
                                          GoTo ProcessPSN
                                      End If
                                      AssyBuf = ""
                                      Exit Sub
                                  End If
                              End If
                              If AccessoryFlag(4) = False Then
                                  If VerifyPart4(PSNFileInfo.ModelName, AssyBuf) Then
                                      AccessoryFlag(4) = True
                                      ItemCount = ItemCount - 1
                                      If ItemCount = 0 Then
                                          AccessoryFlag(1) = False
                                          AccessoryFlag(2) = False
                                          AccessoryFlag(3) = False
                                          AccessoryFlag(4) = False
                                          GoTo ProcessPSN
                                      End If
                                      AssyBuf = ""
                                      Exit Sub
                                  End If
                              End If

                              AssyBuf = ""
                              Exit Sub
                          ElseIf Scanmode = 2 Then  'Visual Reject
                              AssyBuf = Mid(AssyBuf, 1, InStr(1, AssyBuf, vbCr) - 1)
                              frmSelect.Label2.Text = "Scan the product PSN for Visual Reject..."
                              frmSelect.Text1.Text = AssyBuf
                              If Dir(INIACHIEVEPATH & AssyBuf & ".Txt") = "" Then
                                  Txt_Msg.Text = "--> Unable to find " & AssyBuf & ".Txt" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                              FileCopy(INIACHIEVEPATH & AssyBuf & ".Txt", INIPSNFOLDERPATH & AssyBuf & ".Txt")
                              Kill((INIACHIEVEPATH & AssyBuf & ".Txt"))
                              If Not LOADPSNFILE(AssyBuf) Then
                                  Txt_Msg.Text = "--> Unable to load " & AssyBuf & ".Txt" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                              PSNFileInfo.PackagingStatus = "Visual Reject"
                              PSNFileInfo.PackagingCheckOut = Today & "," & TimeOfDay
                              PSNFileInfo.DateCompleted = ""
                              If Not WRITEPSNFILE(PSNFileInfo.PSN) Then
                                  Txt_Msg.Text = "--> Unable to access " & PSNFileInfo.PSN & ".Txt in the server" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                              lbl_unitaryCount.Text = CStr(Val(lbl_unitaryCount.Text) - 1)
                              AssyBuf = ""
                              UpdateStnStatus()
                              frmSelect.Close()
                              frmSelect.Hide()
                              Scanmode = 0
                          ElseIf Scanmode = 3 Then  'Reprint mode
                              AssyBuf = Mid(AssyBuf, 1, InStr(1, AssyBuf, vbCr) - 1)
                              frmSelect.Label2.Text = "Scan the product PSN for Reprint..."
                              frmSelect.Text1.Text = AssyBuf
                              If Dir(INIACHIEVEPATH & AssyBuf & ".Txt") = "" Then
                                  frmSelect.Label2.Text = "--> Product has not completed the cycle - " & AssyBuf & ".Txt" & vbCrLf
                                  AssyBuf = ""
                                  Exit Sub
                              End If

                              RPrintLabel.JobArticle = Microsoft.VisualBasic.Left(AssyBuf, 6)
                              RPrintLabel.JobModelName = Article2Model(RPrintLabel.JobArticle)
                              LoadReprintLabelParameter(RPrintLabel.JobModelName)

                              If ReprintLabelVar.UnitLabelTemplate <> "" Then 'If no define template, skip print unitary
                                  If Not OpenDocument(INITEMPLATEPATH & ReprintLabelVar.UnitLabelTemplate) Then
                                      frmSelect.Label2.Text = "--> Unable to open label template" & vbCrLf
                                      Exit Sub
                                  End If
                                  Thread.Sleep(20)
                                  If Not SetPrinter("Zebra 110XiIII Plus (600 dpi)", "USB003") Then
                                      frmSelect.Label2.Text = "--> Unable to select Printer" & vbCrLf
                                      AssyBuf = ""
                                      Exit Sub
                                  End If
                                  RePrintLabel(Mid(AssyBuf, 10, 4))
                                  CloseDocument()

                                  If Not OpenDocument(INITEMPLATEPATH & ReprintLabelVar.GrpLabelTemplate) Then
                                      frmSelect.Label2.Text = "--> Unable to open group label template" & vbCrLf
                                      Exit Sub
                                  End If
                                  If Not SetPrinter("Zebra TLP2844-Z", "USB002") Then
                                      frmSelect.Label2.Text = "--> Unable to switch to Grouping Printer" & vbCrLf
                                      Exit Sub
                                  End If
                                  RePrintGrpLabel(Mid(AssyBuf, 10, 4))
                                  CloseDocument()

                                  AssyBuf = ""
                                  frmSelect.Close()
                                  frmSelect.Hide()
                                  Scanmode = 0
                              End If
                          End If

                      End If

ProcessPSN:
                      'Print Unitary Label
                      lbl_msg.Text = "Please wait. Printing..."
                      If Command1.Text = "Eye Open" Then
                          If LabelVar.UnitLabelTemplate <> "" Then 'If no define template, skip print unitary
                              If Not OpenDocument(INITEMPLATEPATH & LabelVar.UnitLabelTemplate) Then
                                  Txt_Msg.Text = "--> Unable to open label template" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  Exit Sub
                              End If
                              Thread.Sleep(20)
                              If Not SetPrinter("Zebra 110XiIII Plus (600 dpi)", "USB003") Then
                                  Txt_Msg.Text = "--> Unable to select Printer" & vbCrLf
                                  Txt_Msg.BackColor = Color.Red
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                              Image_preview_unitary.Visible = True

                              If Command2.Text = "PRINT" Then
                                  PrintLabel()
                              End If
                              CloseDocument()

                              lbl_unitaryCount.Text = CStr(Val(lbl_unitaryCount.Text) + 1)
                              LoadWOfrRFID.JobUnitaryCount = Val(lbl_unitaryCount.Text)
                              UpdateStnStatus()
                          End If
                      End If

                      'Print Grouping label
                      If Command1.Text = "Eye Open" Then
                          If LabelVar.GrpLabelTemplate <> "" Then 'If no define Grp Template, skip print grp
                              If Val(lbl_unitaryCount.Text) = LoadWOfrRFID.JobQTy Then 'Last Grp print
                                  If Not OpenDocument(INITEMPLATEPATH & LabelVar.GrpLabelTemplate) Then
                                      Txt_Msg.Text = "--> Unable to open label template" & vbCrLf
                                      Txt_Msg.BackColor = Color.Red
                                      Exit Sub
                                  End If
                                  If Not SetPrinter("Zebra TLP2844-Z", "USB002") Then
                                      Txt_Msg.Text = "--> Unable to switch Printer" & vbCrLf
                                      Txt_Msg.BackColor = Color.Red
                                      Exit Sub
                                  End If
                                  Image_preview_group.Visible = True
                                  PrintGrpLabel()
                                  CloseDocument()
                                  lbl_groupCount.Text = CStr(Val(lbl_groupCount.Text) + 1)
                                  TotalGrpCount = Val(lbl_groupCount.Text)
                              End If
                          End If
                          If LabelVar.GrpLabelTemplate <> "" Then
                              If Val(lbl_unitaryCount.Text) Mod LabelVar.GrpQty = 0 Then 'If Grpqty is reach, print grp
                                  If Not OpenDocument(INITEMPLATEPATH & LabelVar.GrpLabelTemplate) Then
                                      Txt_Msg.Text = "--> Unable to open label template" & vbCrLf
                                      Txt_Msg.BackColor = Color.Red
                                      Exit Sub
                                  End If
                                  If Not SetPrinter("Zebra TLP2844-Z", "USB002") Then
                                      Txt_Msg.Text = "--> Unable to switch Printer" & vbCrLf
                                      Txt_Msg.BackColor = Color.Red
                                      Exit Sub
                                  End If
                                  Image_preview_group.Visible = True
                                  PrintGrpLabel()
                                  CloseDocument()
                                  lbl_groupCount.Text = CStr(Val(lbl_groupCount.Text) + 1)
                                  TotalGrpCount = Val(lbl_groupCount.Text)
                              End If
                          End If
                      End If
yap:
                      PSNFileInfo.PackagingStatus = "PASS"
                      PSNFileInfo.PackagingCheckOut = Today & "," & TimeOfDay
                      PSNFileInfo.DateCompleted = PSNFileInfo.PackagingCheckOut
                      Txt_Msg.Text = "Updating " & PSNFileInfo.PSN & ".Txt..." & vbCrLf
                      lbl_msg.Text = "Please wait..."
                      If Not WRITEPSNFILE(PSNFileInfo.PSN) Then
                          Txt_Msg.Text = "--> Unable to access " & PSNFileInfo.PSN & ".Txt in the server" & vbCrLf
                          Txt_Msg.BackColor = Color.Red
                          Image1.Image = XCS_17.My.Resources.Fail
                          Exit Sub
                      End If
                      LogCompletedPSN(PSNFileInfo.PSN)
                      Txt_Msg.Text = Txt_Msg.Text & PSNFileInfo.PSN & ".Txt updated" & vbCrLf
                      Txt_Msg.Text = Txt_Msg.Text & "Transfering PSN data to achieve..."
                      LogCompletedPSN(PSNFileInfo.PSN) 'log all data to the log file
                      FileCopy(INIPSNFOLDERPATH & PSNFileInfo.PSN & ".Txt", INIACHIEVEPATH & PSNFileInfo.PSN & ".Txt")
                      Kill((INIPSNFOLDERPATH & PSNFileInfo.PSN & ".Txt"))

                      If lbl_unitaryCount.Text = lbl_wocounter.Text Then
                          Txt_Msg.Text = "WO Quantity Reached - WO Completed." & vbCrLf & "Please Close RFID Tag" & vbCrLf
                          Text6.Text = "WO Quantity Reached - WO Completed." & vbCrLf
                          lbl_msg.Text = "STOP PROCESS"
                          Label10.Text = "STOP PROCESS"
                      End If
                      AccessoryFlag(1) = False
                      AccessoryFlag(2) = False
                      AccessoryFlag(3) = False
                      AccessoryFlag(4) = False
                      ItemCount = LoadWOfrRFID.JobItemCount

                      AssyBuf = ""
                      Scanmode = 0
                      lbl_msg.Text = "Please scan PSN barcode..."
                      Cmd_Visual.Enabled = True
                  End Sub)
    End Sub

    Private Sub Vacuumscan_Comm_DataReceived(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles Vacuumscan_Comm.DataReceived
        Dim CheckWO As String
        VacuumBuf = Vacuumscan_Comm.ReadExisting()
        If InStr(1, VacuumBuf, vbCrLf) <> 0 Then
            Me.Invoke(Sub()
                          Text6.BackColor = Color.LightGray
                          Text6.Text = ""
                          Label10.Text = ""
                          Image2.Image = Nothing
                          VacuumBuf = Mid(VacuumBuf, 1, InStr(1, VacuumBuf, vbCr) - 1)

                          If lbl_WOnos.Text <> "MASTER" Then
                              'Disable Test if WO is distrupted
                              CheckWO = ValidiateWONos((lbl_WOnos.Text))
                              'If CheckWO = "NOK" Then
                              '    Text6.Text = "Invalid WO - WO is not registered in Server"
                              '   VacuumBuf = ""
                              '   Exit Sub
                              'End If
                              If CheckWO <> "OPEN" Then
                                  '   Text6.BackColor = vbRed
                                  '   Text6.Text = "--> Current WO is " & CheckWO
                                  '   VacuumBuf = ""
                                  '  Exit Sub
                              Else
                                  'If Val(lbl_unitaryCount.Text) >= Val(lbl_wocounter.Text) Then
                                  '    Text6.Text = "WO Quantity reached - WO Completed"
                                  '    Label10.Text = "STOP PROCESS"
                                  '    VacuumBuf = ""
                                  '    Exit Sub
                                  'End If
                              End If
                          Else
                              If Val(lbl_unitaryCount.Text) >= Val(lbl_wocounter.Text) Then
                                  Text6.Text = "WO Quantity reached - WO Completed"
                                  Label10.Text = "STOP PROCESS"
                                  VacuumBuf = ""
                                  Exit Sub
                              End If
                          End If

                          'Check if the Work Order Quantity is reached
                          If Val(Label11.Text) = LoadWOfrRFID.JobQTy Then
                              Text6.Text = "WORK ORDER COMPLETED"
                              'Text6.BackColor = vbRed
                              'VacuumBuf = ""
                              'Exit Sub
                          End If

                          If Microsoft.VisualBasic.Left(VacuumBuf, 6) <> LoadWOfrRFID.JobArticle Then
                              Text6.Text = "--> PSN - " & VacuumBuf & " = wrong reference"
                              Text6.BackColor = Color.Red
                              VacuumBuf = ""
                              Exit Sub
                          Else
                              Text6.Text = "PSN - " & VacuumBuf & vbCrLf
                          End If

                          Text6.Text = Text6.Text & "Loading" & VacuumBuf & ".Txt..." & vbCrLf
                          If Dir(INIPSNFOLDERPATH & VacuumBuf & ".Txt") = "" Then
                              Text6.Text = "--> Unable to find " & VacuumBuf & ".Txt" & vbCrLf
                              Text6.BackColor = Color.Red
                              VacuumBuf = ""
                              Exit Sub
                          End If
                          If Not LOADPSNFILEVAC(VacuumBuf) Then
                              Text6.Text = "--> Unable to load " & VacuumBuf & ".Txt" & vbCrLf
                              Text6.BackColor = Color.Red
                              VacuumBuf = ""
                              Exit Sub
                          End If
                          VacuumPSNFileInfo.VacuumCheckIn = Today & "," & TimeOfDay
                          VacuumPSNFileInfo.PSN = VacuumBuf

                          Text6.Text = Text6.Text & "Verifying PSN..." & vbCrLf
                          If VacuumPSNFileInfo.Stn5Status <> "PASS" Then
                              Text6.Text = "--> PSN skip process" & vbCrLf & "--> Please go back to previous station" & vbCrLf
                              Text6.BackColor = Color.Red
                              VacuumBuf = ""
                              Exit Sub
                          Else
                              If Not Modbus.tulisModbus(40105, 1) Then
                                  Text6.Text = "--> Unable to communicate with PLC - MW105" & vbCrLf
                                  Text6.BackColor = Color.Red
                                  VacuumBuf = ""
                                  Exit Sub
                              End If
                          End If
                          Text6.Text = Text6.Text & "PSN Verified" & vbCrLf
                          VacuumBuf = ""
                      End Sub)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Tagref As String
        Dim Tagnos As String
        Dim TagQty As String
        Dim Tagid As String
        Dim CheckWO As String

        Ethernet.BackColor = Color.Black
        ReadTagFlag = True
        RFID_Comm.DiscardInBuffer()
        Tagnos = RD_MULTI_RFID("0000", 10)
        If Tagnos = "NOK" Then GoTo NoChange
        If Tagnos = "MASTER" Then
            If lbl_WOnos.Text <> "MASTER" Then
                If Val(lbl_unitaryCount.Text) <> Val(lbl_wocounter.Text) Then
                    Txt_Msg.Text = "Current WO is not complete. Change Series is not allowed"
                    GoTo NoChange
                End If
            ElseIf lbl_WOnos.Text = "MASTER" Then
                GoTo Change
            End If
        ElseIf Tagnos <> LoadWOfrRFID.JobNos Then
            If lbl_WOnos.Text <> "MASTER" Then
                'Checking Current WO first b4 Change Series is allowed. If WO status is open, check Quantity
                CheckWO = ValidiateWONos(lbl_WOnos.Text)
                If CheckWO = "NOK" Then
                    Txt_Msg.Text = "Invalid WO - WO is not registered in Server"
                    GoTo NoChange
                ElseIf CheckWO = "CLOSED" Then

                ElseIf CheckWO = "FORCED" Then

                ElseIf CheckWO = "OPEN" Then
                    If Command1.Text = "Eye Open" Then
                        If Val(lbl_unitaryCount.Text) <> Val(lbl_wocounter.Text) Then
                            Txt_Msg.Text = "Current WO is not complete. Change Series is not allowed"
                            GoTo NoChange
                        End If
                    End If
                ElseIf CheckWO = "DISTRUP" Then

                End If
            End If
Change:
            Txt_Msg.Text = "Changing Series..." & vbCrLf
            Txt_Msg.Text = Txt_Msg.Text & "Reading info from RFID Tag..." & vbCrLf
            LoadWOfrRFID.JobNos = Tagnos
            Tagref = RD_MULTI_RFID("0014", 10) 'Read WO Reference from Tag
            If Tagref = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            TagQty = RD_MULTI_RFID("0028", 10) 'Read WO Qty from Tag
            If TagQty = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            Tagid = RD_MULTI_RFID("0040", 3) 'Read Tag ID
            If Tagid = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            'Check if reference is valid from the database
            If Not RefCheck(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Invalid Reference" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            Txt_Msg.Text = Txt_Msg.Text & "loading parameters of new reference..." & vbCrLf
            If Not LoadModelMaterial(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load Model parameter" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            Reset_PLC()
            If Not ActivateRackLED() Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to communicate with PLC" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            lbl_WOnos.Text = Tagnos
            LoadWOfrRFID.JobNos = Tagnos
            lbl_currentref.Text = Tagref
            LoadWOfrRFID.JobModelName = Tagref
            lbl_wocounter.Text = TagQty
            LoadWOfrRFID.JobQTy = CInt(TagQty)
            lbl_tagnos.Text = Tagid
            LoadWOfrRFID.JobRFIDTag = Tagid
            LoadWOfrRFID.JobArticle = Model2Article(LoadWOfrRFID.JobModelName)
            lbl_ArticleNos.Text = LoadWOfrRFID.JobArticle
            Txt_Msg.Text = Txt_Msg.Text & "loading parameters of new reference..." & vbCrLf
            LoadLabelParameter(LoadWOfrRFID.JobModelName)
            If Not LoadParameter(LoadWOfrRFID.JobModelName) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load Model parameter" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            If Not loadparameter2plc() Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to communicate with PLC - MW400" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            lbl_unitaryCount.Text = "0"
            Label11.Text = "0"
            LoadWOfrRFID.JobUnitaryCount = Val(lbl_unitaryCount.Text)
            LoadWOfrRFID.JobVacuumCount = Val(Label11.Text)
            UpdateStnStatus()
            UpdateVacuumStatus()
            Text6.Text = ""
            Label10.Text = "Please scan PSN Barcode..."
            Txt_Msg.Text = Txt_Msg.Text & "Change Series completed" & vbCrLf
        End If
        ReadTagFlag = False

NoChange:
        Dim Station_status As Integer

        Station_status = Modbus.bacaModbus(40101)
        Ethernet.BackColor = Color.Lime
        Text4.Text = CStr(Station_status)
        'Exit Sub
        Select Case Station_status
            Case 0
                Label10.Text = "Please scan PSN Barcode..."
            Case 1
                Label10.Text = "Please load product into cavity and close door..."

            Case 2 'Vacuum Test
                Modbus.tulisModbus(40105, 0)
                Label10.Text = ""
                Image2.Image = Nothing
                Text6.Text = "Vacuum Test in progress..." & vbCrLf & "Please wait..."
                Text6.BackColor = Color.LightGray
            Case 3

            Case 4
                Label10.Text = ""
                If Modbus.bacaModbus(40102) = 1 Then 'Pass
                    If VacuumPSNFileInfo.VacuumStatus <> "PASS" Then
                        Label11.Text = CStr(Val(Label11.Text) + 1)
                        LoadWOfrRFID.JobVacuumCount = CInt(Label11.Text)
                        UpdateVacuumStatus()
                    End If
                    Image2.Image = XCS_17.My.Resources.Pass
                    VacuumPSNFileInfo.VacummCheckOut = Today & "," & TimeOfDay
                    VacuumPSNFileInfo.VacuumStatus = "PASS"
                    Text6.Text = "Updating PSN...."
                    If Not WRITEPSNFILEVAC(VacuumPSNFileInfo.PSN) Then
                        Text6.Text = "--> Unable to access " & VacuumPSNFileInfo.PSN & ".Txt in the server" & vbCrLf
                        Image2.Image = XCS_17.My.Resources.Fail
                        Exit Sub
                    End If
                    Text6.Text = "PSN updated"

                    If Not Modbus.tulisModbus(40101, 10) Then
                        Text6.Text = "--> Unable to communicate with PLC - %MW101"
                        Exit Sub
                    End If
                    Label10.Text = "Please scan PSN Barcode..."
                Else 'Fail
                    Image2.Image = XCS_17.My.Resources.Fail
                    Label10.Text = ""
                    VacuumPSNFileInfo.VacummCheckOut = Today & "," & TimeOfDay
                    VacuumPSNFileInfo.VacuumStatus = "FAIL"
                    If Not WRITEPSNFILEVAC(VacuumPSNFileInfo.PSN) Then
                        Text6.Text = "--> Unable to access " & VacuumPSNFileInfo.PSN & ".Txt in the server" & vbCrLf
                        Image2.Image = XCS_17.My.Resources.Fail
                        Exit Sub
                    End If
                    If Not Modbus.tulisModbus(40101, 10) Then
                        Text6.Text = "--> Unable to communicate with PLC - %MW101"
                        Exit Sub
                    End If
                    Action = 0
                End If
        End Select

        Select Case Action
            Case 0

            Case 1
                Image1.Image = XCS_17.My.Resources.Pass
                '==================== Unitary Printing Sequence ===================
                'If Command1.Caption = "Eye Open" Then
                If LabelVar.UnitLabelTemplate <> "" Then 'If no define template, skip print unitary
                    If Not OpenDocument(INITEMPLATEPATH & LabelVar.UnitLabelTemplate) Then
                        Txt_Msg.Text = "--> Unable to open label template" & vbCrLf
                        Txt_Msg.BackColor = Color.Red
                        Exit Sub
                    End If
                    If Not SetPrinter("Zebra 110XiIII Plus (600 dpi)", "USB003") Then
                        Txt_Msg.Text = "--> Unable to select Printer" & vbCrLf
                        Txt_Msg.BackColor = Color.Red
                        Exit Sub
                    End If
                    Image_preview_unitary.Visible = True
                    If Command2.Text = "PRINT" Then
                        PrintLabel()
                    End If
                    CloseDocument()
                    'lbl_unitaryCount.Caption = Val(lbl_unitaryCount.Caption) + 1
                End If
                'End If
                Action = 0
                '=====================S02 Printing Sequence ===================
                'If Command1.Caption = "Eye Open" Then
                '    If LabelVar.GrpLabelTemplate <> "" Then 'If no define Grp Template, skip print grp
                '        If Val(lbl_unitaryCount.Caption) = LoadWOfrRFID.JobQTy Then 'Last Grp print
                '            If Not OpenLab(INITEMPLATEPATH & LabelVar.GrpLabelTemplate) Then
                '                Txt_Msg.Text = "--> Unable to open label template" & vbCrLf
                '                Txt_Msg.BackColor = vbRed
                '                Exit Sub
                '            End If
                '            If Not SetPrinters("Zebra TLP2844-Z,USB002") Then
                '                Txt_Msg.Text = "--> Unable to switch Printer" & vbCrLf
                '                Txt_Msg.BackColor = vbRed
                '                Exit Sub
                '            End If
                '            Image_preview_group.Visible = True
                '            PrintGrpLabel
                '            CloseLab
                '            lbl_groupCount.Caption = Val(lbl_groupCount) + 1
                '            TotalGrpCount = Val(lbl_groupCount)
                '            GoTo ClosePSN
                '        End If
                '    End If

                '    If LabelVar.GrpLabelTemplate <> "" Then
                '        If Val(lbl_unitaryCount.Caption) Mod LabelVar.GrpQty = 0 Then 'If Grpqty is reach, print grp
                '            If Not OpenLab(INITEMPLATEPATH & LabelVar.GrpLabelTemplate) Then
                '                Txt_Msg.Text = "--> Unable to open label template" & vbCrLf
                '                Txt_Msg.BackColor = vbRed
                '                Exit Sub
                '            End If
                '            If Not SetPrinters("Zebra TLP2844-Z,USB002") Then
                '                Txt_Msg.Text = "--> Unable to switch Printer" & vbCrLf
                '                Txt_Msg.BackColor = vbRed
                '                Exit Sub
                '            End If
                '            Image_preview_group.Visible = True
                '            PrintGrpLabel
                '            CloseLab
                '            lbl_groupCount.Caption = Val(lbl_groupCount) + 1
                '            TotalGrpCount = Val(lbl_groupCount)
                '        End If
                '    End If
                'End If
ClosePSN:
                'If Command1.Caption = "Eye Open" Then
                PSNFileInfo.PackagingStatus = "PASS"
                PSNFileInfo.PackagingCheckOut = Today & "," & TimeOfDay
                PSNFileInfo.DateCompleted = PSNFileInfo.PackagingCheckOut
                Txt_Msg.Text = "Updating " & PSNFileInfo.PSN & ".Txt..." & vbCrLf
                lbl_msg.Text = "Please wait..."
                'If Not WRITEPSNFILE(PSNFileInfo.PSN) Then
                '    Txt_Msg.Text = "--> Unable to access " & PSNFileInfo.PSN & ".Txt in the server" & vbCrLf
                '    Txt_Msg.BackColor = vbRed
                '    Image1.Picture = LoadPicture(INIICONSPATH & "FAIL.Emf")
                '    If Not Write_PLC_Word(101, 10) Then 'Inform PLC that PC already read result
                '        Txt_Msg.Text = "--> Unable to communicate with PLC - MW101" & vbCrLf
                '        Txt_Msg.BackColor = vbRed
                '        Exit Sub
                '    End If
                '    Exit Sub
                'End If
                Txt_Msg.Text = Txt_Msg.Text & PSNFileInfo.PSN & ".Txt updated" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "Transfering PSN data to achieve..."
                LogCompletedPSN(PSNFileInfo.PSN) 'log all data to the log file
                'Call FileCopy(INIPSNFOLDERPATH & PSNFileInfo.PSN & ".Txt", INIACHIEVEPATH & PSNFileInfo.PSN & ".Txt")
                'Kill (INIPSNFOLDERPATH & PSNFileInfo.PSN & ".Txt")
                ' lbl_unitaryCount.Caption = Val(lbl_unitaryCount.Caption) + 1
                ' LoadWOfrRFID.JobUnitaryCount = Val(lbl_unitaryCount.Caption)
                ' UpdateStnStatus

                'End If
                'If Not Write_PLC_Word(101, 10) Then 'Inform PLC that PC already read result
                '    Txt_Msg.Text = "--> Unable to communicate with PLC - MW101" & vbCrLf
                '    Txt_Msg.BackColor = vbRed
                '    Exit Sub
                'End If
                Action = 0
                If Val(lbl_unitaryCount.Text) >= Val(lbl_wocounter.Text) Then
                    Txt_Msg.Text = "WO Quantity reached - WO Completed"
                    lbl_msg.Text = "STOP PROCESS"
                End If
        End Select
    End Sub
End Class