<!-- default file list -->
*Files to look at*:

* [PrintPreview.xaml](./CS/GridPrint/PrintPreview.xaml) (VB: [PrintPreview.xaml](./VB/GridPrint/PrintPreview.xaml))
* [PrintPreview.xaml.cs](./CS/GridPrint/PrintPreview.xaml.cs) (VB: [PrintPreview.xaml.vb](./VB/GridPrint/PrintPreview.xaml.vb))
* [Window1.xaml](./CS/GridPrint/Window1.xaml) (VB: [Window1.xaml](./VB/GridPrint/Window1.xaml))
* [Window1.xaml.cs](./CS/GridPrint/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/GridPrint/Window1.xaml.vb))
<!-- default file list end -->
# How to create the print page header and footer when exporting the GridControl


<p>To accomplish this task, create a PrintableControlLink class instance based on the GridControl. After that, assign your custom templates to the PageHeader and PageFooter properties of the PrintableControlLink object.<br><br>See also: <a href="https://documentation.devexpress.com/WPF/115300/Common-Concepts/MVVM-Framework/Services/Predefined-Set/Report-Services/GridReportManagerService">GridReportManagerService</a>.</p>

<br/>


