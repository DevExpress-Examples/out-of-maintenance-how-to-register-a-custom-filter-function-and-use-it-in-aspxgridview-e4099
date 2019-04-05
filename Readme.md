<!-- default file list -->
*Files to look at*:

* [MyFunction.cs](./CS/WebSite/App_Code/MyFunction.cs) (VB: [MyFunction.vb](./VB/WebSite/App_Code/MyFunction.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to register a custom filter function and use it in ASPxGridView


<p>Sometimes it is necessary to create a custom function that allows implementing your own logic for filtering data in an auto filter row.</p>
<p>To create this function, it is necessary to implement the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressDataFilteringICustomFunctionOperatorMembersTopicAll"><u>ICustomFunctionOperator</u></a> interface. Finally, to register a custom function, call the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressDataFilteringCriteriaOperator_RegisterCustomFunctiontopic"><u>CriteriaOperator.RegisterCustomFunction</u></a> method with your custom function instance at the application startup.</p>
<br />
<p>This example illustrates how to add a custom function that will determine whether or not numbers in a cell are contained within the filter range.</p>
<p><strong>See also:</strong><strong><br /><a href="https://www.devexpress.com/Support/Center/p/E4836">How to create a custom ASPxGridView's filter insensitive to the number of spaces and punctuation</a> <br /> </strong><a href="https://www.devexpress.com/Support/Center/p/E3514">How to register a custom filter function and use it in GridControl</a></p>

<br/>


