using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Init(object sender, EventArgs e) {
        if(CriteriaOperator.GetCustomFunction("MyNewFunction") == null)
            CriteriaOperator.RegisterCustomFunction(new MyFunction());
    }

    protected void Grid_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e) {
        if(e.Column.FieldName == "Numbers") {
            switch(e.Kind) {
                case GridViewAutoFilterEventKind.CreateCriteria:
                    CriteriaOperator co = CriteriaOperator.Parse(Grid.FilterExpression);
                    if(co is GroupOperator) {
                        GroupOperator go = co as GroupOperator;
                        CriteriaOperator operand = go.Operands.Find(op => op.LegacyToString().Contains("MyNewFunction"));
                        if(operand is CriteriaOperator)
                            go.Operands.Remove(operand);
                        Grid.FilterExpression = go.LegacyToString();
                    } else if(co is CriteriaOperator) {
                        string filter = co.LegacyToString();
                        if(filter.Contains("MyNewFunction"))
                            Grid.FilterExpression = string.Empty;
                    }
                    if(e.Value.Contains('-')) {
                        CriteriaOperator cop = new FunctionOperator(FunctionOperatorType.Custom, "MyNewFunction", e.Value, new OperandProperty("Numbers"));
                        e.Criteria = cop;
                    }
                    break;
                case GridViewAutoFilterEventKind.ExtractDisplayText:
                default:
                    break;
            }
        }
    }

    protected void Grid_AutoFilterCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e) {
        if(!string.IsNullOrEmpty(Grid.FilterExpression) && Grid.FilterExpression.Contains("MyNewFunction") && e.Column.FieldName == "Numbers") {
            CriteriaOperator co = CriteriaOperator.Parse(Grid.FilterExpression);
            CriteriaOperator operand = null;

            if(co is GroupOperator) {
                GroupOperator go = co as GroupOperator;
                operand = (go.Operands.Find(op => op.LegacyToString().Contains("MyNewFunction")) as FunctionOperator).Operands[1];
            } else {
                operand = (co as FunctionOperator).Operands[1];
            }

            if(!ReferenceEquals(operand, null))
                e.Editor.Value = (operand as OperandValue).Value.ToString();
        }
    }
}