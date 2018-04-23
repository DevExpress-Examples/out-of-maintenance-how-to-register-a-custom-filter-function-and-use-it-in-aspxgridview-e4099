using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;

public class MyFunction : ICustomFunctionOperator {
    const string FunctionName = "MyNewFunction";

    public object Evaluate(params object[] operands) {

        bool res = false;

        string[] strContainerNumbers = operands[0].ToString().Split('-');

        int strMinValue = Convert.ToInt32(strContainerNumbers[0]);
        int strMaxValue = Convert.ToInt32(strContainerNumbers[1]);

        string[] strNumbersInCell = operands[1].ToString().Split(',');
        for(int i = 0; i < strNumbersInCell.Length; i++) {
            int val = Convert.ToInt32(strNumbersInCell[i].Trim());
            if(strMinValue <= val && val <= strMaxValue)
                return (res = true);
        }
        return res;
    }

    public string Name {
        get { return FunctionName; }
    }

    public Type ResultType(params Type[] operands) {
        return typeof(bool);
    }
}