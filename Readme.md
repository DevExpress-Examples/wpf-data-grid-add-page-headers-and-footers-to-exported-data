<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128649497/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2608)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WPF Data Grid - Add Page Headers and Footers to Exported Data

This example exports the contents of our WPF [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl) with specified page headers and footers.

![image](https://user-images.githubusercontent.com/65009440/174618885-6e6885cc-3368-4fda-a43e-f75372172e77.png)

## WYSIWYG Technique

![image](https://user-images.githubusercontent.com/65009440/174618994-6110cfba-3621-4da1-9211-f7ec072ca0ba.png)

1. Create custom templates for headers and footers.
2. Create a new instance of the [PrintableControlLink](https://docs.devexpress.com/WPF/DevExpress.Xpf.Printing.PrintableControlLink) class.
3. Assign the templates to the [PageHeaderTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Printing.TemplatedLink.PageHeaderTemplate) and [PageFooterTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Printing.TemplatedLink.PageFooterTemplate) properties.
4. Print or export the WPF GridControl in WYSIWYG mode.

Refer to the following help topic for more information: [WYSIWYG Export](https://docs.devexpress.com/WPF/118842/controls-and-libraries/data-grid/printing-and-exporting/wysiwyg-export).

## Data-Aware Technique

![image](https://user-images.githubusercontent.com/65009440/174619950-bd8c9ca8-1a81-42f5-8f78-fda570ebdcac.png)

1. Create a new instance of the [XlsxExportOptionsEx](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx) class.
2. Handle both [XlsxExportOptionsEx.CustomizeSheetHeader](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx.CustomizeSheetHeader) and [XlsxExportOptionsEx.CustomizeSheetFooter](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptionsEx.CustomizeSheetFooter) events.
3. In the event handlers, specify custom page headers and footers.
4. Export the WPF GridControl in **XLSX** format.

Refer to the following help topic for more information: [Data-Aware Export](https://docs.devexpress.com/WPF/10018/controls-and-libraries/data-grid/printing-and-exporting/data-aware-export).

<!-- default file list -->

## Files to look at

* [Window1.xaml](./CS/GridPrint/Window1.xaml) (VB: [Window1.xaml](./VB/GridPrint/Window1.xaml))
* [Window1.xaml.cs](./CS/GridPrint/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/GridPrint/Window1.xaml.vb))

<!-- default file list end -->

## Documentation

* [Printing and Exporting](https://docs.devexpress.com/WPF/117296/controls-and-libraries/data-grid/printing-and-exporting)
* [Generate a Grid-Based Report](https://docs.devexpress.com/WPF/117300/controls-and-libraries/data-grid/printing-and-exporting/grid-based-report-generation)

## More Examples

* [WPF Data Grid - Customize the Print and Export Appearance](https://github.com/DevExpress-Examples/wpf-data-grid-customize-print-export-appearance)
* [WPF Data Grid - Export to a Native Excel Table](https://github.com/DevExpress-Examples/how-to-export-the-gridcontrol-into-a-native-excel-table-t466541)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-add-page-headers-and-footers-to-exported-data&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-add-page-headers-and-footers-to-exported-data&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
