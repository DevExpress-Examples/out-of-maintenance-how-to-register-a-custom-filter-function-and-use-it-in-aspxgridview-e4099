<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128542149/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4099)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MyFunction.cs](./CS/WebSite/App_Code/MyFunction.cs) (VB: [MyFunction.vb](./VB/WebSite/App_Code/MyFunction.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to register a custom filter function and use it in ASPxGridView
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4099/)**
<!-- run online end -->


<p>Sometimes it is necessary to create a custom function that allows implementing your own logic for filtering data in an auto filter row.</p>
<p>To create this function, it is necessary to implement the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressDataFilteringICustomFunctionOperatorMembersTopicAll"><u>ICustomFunctionOperator</u></a> interface. Finally, to register a custom function, call the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressDataFilteringCriteriaOperator_RegisterCustomFunctiontopic"><u>CriteriaOperator.RegisterCustomFunction</u></a> method with your custom function instance at the application startup.</p>
<br />
<p>This example illustrates how to add a custom function that will determine whether or not numbers in a cell are contained within the filter range.</p>
<p><strong>See also:</strong><strong><br /><a href="https://www.devexpress.com/Support/Center/p/E4836">How to create a custom ASPxGridView's filter insensitive to the number of spaces and punctuation</a> <br /> </strong><a href="https://www.devexpress.com/Support/Center/p/E3514">How to register a custom filter function and use it in GridControl</a></p>

<br/>


