Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Data.Filtering

Public Class MyFunction
	Implements ICustomFunctionOperator
	Private Const FunctionName As String = "MyNewFunction"

    Public Function Evaluate(ByVal ParamArray operands() As Object) As Object Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Evaluate

        Dim res As Boolean = False

        Dim strContainerNumbers() As String = operands(0).ToString().Split("-"c)

        Dim strMinValue As Integer = Convert.ToInt32(strContainerNumbers(0))
        Dim strMaxValue As Integer = Convert.ToInt32(strContainerNumbers(1))

        Dim strNumbersInCell() As String = operands(1).ToString().Split(","c)
        For i As Integer = 0 To strNumbersInCell.Length - 1
            Dim val As Integer = Convert.ToInt32(strNumbersInCell(i).Trim())
            If strMinValue <= val AndAlso val <= strMaxValue Then
                res = True
                Return res
            End If
        Next i
        Return res
    End Function

    Public ReadOnly Property Name() As String Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Name
        Get
            Return FunctionName
        End Get
    End Property

    Public Function ResultType(ByVal ParamArray operands() As Type) As Type Implements DevExpress.Data.Filtering.ICustomFunctionOperator.ResultType
        Return GetType(Boolean)
    End Function
End Class