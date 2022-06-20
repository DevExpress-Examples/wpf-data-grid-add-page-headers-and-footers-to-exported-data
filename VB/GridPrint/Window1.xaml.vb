Imports DevExpress.Export
Imports DevExpress.Printing.ExportHelpers
Imports DevExpress.Xpf.Printing
Imports DevExpress.XtraPrinting
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows

Namespace GridPrint

    Public Partial Class Window1
        Inherits Window

        Private Class Product

            Public Property Group As String

            Public Property Name As String

            Public Property Price As Double
        End Class

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = New ObservableCollection(Of Product)(GetData())
        End Sub

        Private Shared Iterator Function GetData() As IEnumerable(Of Product)
            Yield New Product() With {.Group = "Group 1", .Name = "Product 1", .Price = 12.94}
            Yield New Product() With {.Group = "Group 1", .Name = "Product 2", .Price = 35.42}
            Yield New Product() With {.Group = "Group 2", .Name = "Product 3", .Price = 22.45}
            Yield New Product() With {.Group = "Group 3", .Name = "Product 4", .Price = 36.99}
            Yield New Product() With {.Group = "Group 3", .Name = "Product 5", .Price = 76.54}
            Yield New Product() With {.Group = "Group 4", .Name = "Product 6", .Price = 98.65}
        End Function

        ' WYSIWYG Export
        Private Sub Button_ExportToPdf(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim link = New PrintableControlLink(Me.view)
            link.PageHeaderTemplate = CType(Resources("PageHeader"), DataTemplate)
            link.PageFooterTemplate = CType(Resources("PageFooter"), DataTemplate)
            link.ExportToPdf("GridExport.pdf")
            Call Process.Start("GridExport.pdf")
        End Sub

        ' Data-Aware Export
        Private Sub Button_ExportToExcel(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim options As XlsxExportOptionsEx = New XlsxExportOptionsEx()
            AddHandler options.CustomizeSheetHeader, AddressOf options_CustomizeSheetHeader
            AddHandler options.CustomizeSheetFooter, AddressOf options_CustomizeSheetFooter
            Me.view.ExportToXlsx("GridExportExcel.xlsx", options)
            Call Process.Start("GridExportExcel.xlsx")
        End Sub

        Private Sub options_CustomizeSheetHeader(ByVal e As ContextEventArgs)
            Dim row As CellObject = New CellObject()
            row.Value = "Page Header"
            Dim rowFormatting As XlFormattingObject = New XlFormattingObject With {.BackColor = Color.Gray, .Alignment = New Xl.XlCellAlignment With {.HorizontalAlignment = Xl.XlHorizontalAlignment.Center}}
            row.Formatting = rowFormatting
            e.ExportContext.AddRow({row})
            e.ExportContext.MergeCells(New Xl.XlCellRange(New Xl.XlCellPosition(0, 0), New Xl.XlCellPosition(2, 0)))
        End Sub

        Private Sub options_CustomizeSheetFooter(ByVal e As ContextEventArgs)
            e.ExportContext.AddRow()
            Dim row As CellObject = New CellObject()
            row.Value = "Page Footer"
            Dim rowFormatting As XlFormattingObject = New XlFormattingObject With {.Font = New XlCellFont With {.Size = 18, .Bold = True}, .Alignment = New Xl.XlCellAlignment With {.HorizontalAlignment = Xl.XlHorizontalAlignment.Left}}
            row.Formatting = rowFormatting
            e.ExportContext.AddRow({row})
            e.ExportContext.MergeCells(New Xl.XlCellRange(New Xl.XlCellPosition(0, 9), New Xl.XlCellPosition(2, 9)))
        End Sub
    End Class
End Namespace
