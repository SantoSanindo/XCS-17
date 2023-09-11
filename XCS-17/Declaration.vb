Module Declaration
    Public LoadWOfrRFID As JobOrder
    Public RPrintLabel As JobOrder
	Public UnitMaterial As RackConfig
	Public TotalGrpCount As Integer
	Public LabelVar As LabelData 'Used in the main page
	Public ReprintLabelVar As LabelData 'Used in the reprint page
	Public UnitaryMaterial(60) As String 'Variable holding material info for the selected reference
	Public UnitaryMaterialFlag(60) As Boolean 'Truewhen part had successfully transfer to main bench
	Public Login As Boolean
	Public PSNFileInfo As PSNText
	Public VacuumPSNFileInfo As PSNText
	Public VacuumPara As UnitType
	Public Parameter As ControlSpec

	Public Structure JobOrder
		Dim JobNos As String
		Dim JobModelName As String
		Dim JobQTy As Integer
		Dim JobArticle As String
		Dim JobModelFW As String
		Dim JobModelAssy As String
		Dim JobInternalNos As String
		Dim JobRFIDTag As String
		Dim JobUnitaryCount As Integer
		Dim JobVacuumCount As Integer
		Dim JobModelMaterial() As String
		Dim JobItemCount As Integer
	End Structure

	Public Structure RackConfig
		Dim PartPLCWord() As Integer
		Dim PartNos() As String
	End Structure

	Public Structure LabelData
		Dim InternalNo As String
		Dim UnitModelName As String
		Dim UnitRefLogistique As String
		Dim UnitArticleNos As String
		Dim UnitCountry As String
		Dim UnitImage As String
		Dim UnitLabelTemplate As String
		Dim UnitGroupQty As Integer
		Dim GrpQty As Integer
		Dim GrpLabelTemplate As String
		Dim GrpLabelImage As String
		Dim UnitProductType As String
		Dim UnitSymbolType As String
		Dim UnitTension As String
		Dim UnitAccessory1 As String
		Dim UnitAccessory2 As String
		Dim UnitAccessory3 As String
		Dim UnitInstructionSheet As String
	End Structure

	Public Structure PSNText
		Dim ModelName As String
		Dim DateCreated As String
		Dim DateCompleted As String
		Dim OperatorID As String
		Dim WONos As String
		Dim MainPCBA As String
		Dim SecondaryPCBA As String
		Dim ElectroMagnet As String
		Dim PSN As String
		Dim BodyAssyCheckIn As String
		Dim BodyAssyCheckOut As String
		Dim BodyAssyStatus As String
		Dim ScrewStnCheckIn As String
		Dim ScrewStnCheckOut As String
		Dim ScrewStnStatus As String
		Dim FTCheckIn As String
		Dim FTCheckOut As String
		Dim FTSycMeas As String
		Dim FTStatus As String
		Dim Stn5CheckIn As String
		Dim Stn5CheckOut As String
		Dim Stn5Status As String
		Dim VacuumCheckIn As String
		Dim VacummCheckOut As String
		Dim VacuumStatus As String
		Dim PackagingCheckIn As String
		Dim PackagingCheckOut As String
		Dim PackagingStatus As String
		Dim DebugStatus As String
		Dim DebugComment As String
		Dim DebugTechnican As String
		Dim RepairDate As String
	End Structure

	Public Structure UnitType
		Dim UnitMaterial As String
		Dim UnitThread As String
		Dim UnitBtnOpt As String
	End Structure

	Public Structure ControlSpec
		Dim UnitTagNos As String
		Dim UnitPartNos As String
		Dim UnitModel As String
		Dim UnitType As String
		Dim UnitFunction As String
		Dim UnitTension As String
		Dim UnitContact1_WO_Trig As String
		Dim UnitContact2_WO_Trig As String
		Dim UnitContact3_WO_Trig As String
		Dim UnitContact4_WO_Trig As String
		Dim UnitContact5_WO_Trig As String
		Dim UnitContact6_WO_Trig As String
		Dim UnitContact_WO_Trig As Long
		Dim UnitContact1_W_Key As String
		Dim UnitContact2_W_Key As String
		Dim UnitContact3_W_Key As String
		Dim UnitContact4_W_Key As String
		Dim UnitContact5_W_Key As String
		Dim UnitContact6_W_Key As String
		Dim UnitContact_W_Key As Long

		Dim UnitContact1_W_Key_Ten As String
		Dim UnitContact2_W_Key_Ten As String
		Dim UnitContact3_W_Key_Ten As String
		Dim UnitContact4_W_Key_Ten As String
		Dim UnitContact5_W_Key_Ten As String
		Dim UnitContact6_W_Key_Ten As String
		Dim UnitContact_W_Key_Ten As Long
		Dim UnitLabelTemplate As String
		Dim UnitLabelPhoto As String
		Dim UnitSycUL As Double
		Dim UnitSycLL As Double
	End Structure
End Module
