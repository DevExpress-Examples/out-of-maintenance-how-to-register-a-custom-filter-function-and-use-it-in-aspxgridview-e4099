Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports DevExpress.Data.Filtering
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		If CriteriaOperator.GetCustomFunction("MyNewFunction") Is Nothing Then
			CriteriaOperator.RegisterCustomFunction(New MyFunction())
		End If
	End Sub

	Protected Sub Grid_ProcessColumnAutoFilter(ByVal sender As Object, ByVal e As ASPxGridViewAutoFilterEventArgs)
		If e.Column.FieldName = "Numbers" Then
			Select Case e.Kind
				Case GridViewAutoFilterEventKind.CreateCriteria
					Dim co As CriteriaOperator = CriteriaOperator.Parse(Grid.FilterExpression)
					If TypeOf co Is GroupOperator Then
						Dim go As GroupOperator = TryCast(co, GroupOperator)
						Dim operand As CriteriaOperator = go.Operands.Find(Function(op) op.LegacyToString().Contains("MyNewFunction"))
						If TypeOf operand Is CriteriaOperator Then
							go.Operands.Remove(operand)
						End If
						Grid.FilterExpression = go.LegacyToString()
					ElseIf TypeOf co Is CriteriaOperator Then
						Dim filter As String = co.LegacyToString()
						If filter.Contains("MyNewFunction") Then
							Grid.FilterExpression = String.Empty
						End If
					End If
					If e.Value.Contains("-"c) Then
						Dim cop As CriteriaOperator = New FunctionOperator(FunctionOperatorType.Custom, "MyNewFunction", e.Value, New OperandProperty("Numbers"))
						e.Criteria = cop
					End If
				Case Else
			End Select
		End If
	End Sub

	Protected Sub Grid_AutoFilterCellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs)
		If (Not String.IsNullOrEmpty(Grid.FilterExpression)) AndAlso Grid.FilterExpression.Contains("MyNewFunction") AndAlso e.Column.FieldName = "Numbers" Then
			Dim co As CriteriaOperator = CriteriaOperator.Parse(Grid.FilterExpression)
			Dim operand As CriteriaOperator = Nothing

			If TypeOf co Is GroupOperator Then
				Dim go As GroupOperator = TryCast(co, GroupOperator)
				operand = (TryCast(go.Operands.Find(Function(op) op.LegacyToString().Contains("MyNewFunction")), FunctionOperator)).Operands(1)
			Else
				operand = (TryCast(co, FunctionOperator)).Operands(1)
			End If

			If (Not ReferenceEquals(operand, Nothing)) Then
				e.Editor.Value = (TryCast(operand, OperandValue)).Value.ToString()
			End If
		End If
	End Sub
End Class