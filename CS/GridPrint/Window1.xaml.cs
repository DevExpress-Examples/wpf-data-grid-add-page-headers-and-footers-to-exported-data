using DevExpress.Export;
using DevExpress.Printing.ExportHelpers;
using DevExpress.Xpf.Printing;
using DevExpress.XtraPrinting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;

namespace GridPrint {
    public partial class Window1 : Window {
        private class Product {
            public string Group { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public Window1() {
            InitializeComponent();
            grid.ItemsSource = new ObservableCollection<Product>(GetData());
        }
        static IEnumerable<Product> GetData() {
            yield return new Product() { Group = "Group 1", Name = "Product 1", Price = 12.94 };
            yield return new Product() { Group = "Group 1", Name = "Product 2", Price = 35.42 };
            yield return new Product() { Group = "Group 2", Name = "Product 3", Price = 22.45 };
            yield return new Product() { Group = "Group 3", Name = "Product 4", Price = 36.99 };
            yield return new Product() { Group = "Group 3", Name = "Product 5", Price = 76.54 };
            yield return new Product() { Group = "Group 4", Name = "Product 6", Price = 98.65 };
        }

        // WYSIWYG Export
        void Button_ExportToPdf(object sender, RoutedEventArgs e) {
            var link = new PrintableControlLink(view);
            link.PageHeaderTemplate = (DataTemplate)Resources["PageHeader"];
            link.PageFooterTemplate = (DataTemplate)Resources["PageFooter"];
            link.ExportToPdf("GridExport.pdf");
            Process.Start("GridExport.pdf");
        }

        // Data-Aware Export
        void Button_ExportToExcel(object sender, RoutedEventArgs e) {
            XlsxExportOptionsEx options = new XlsxExportOptionsEx();
            options.CustomizeSheetHeader += options_CustomizeSheetHeader;
            options.CustomizeSheetFooter += options_CustomizeSheetFooter;
            view.ExportToXlsx("GridExportExcel.xlsx", options);
            Process.Start("GridExportExcel.xlsx");
        }

        void options_CustomizeSheetHeader(ContextEventArgs e) {
            CellObject row = new CellObject();
            row.Value = "Page Header";

            XlFormattingObject rowFormatting = new XlFormattingObject {
                BackColor = Color.Gray,
                Alignment = new DevExpress.Export.Xl.XlCellAlignment { HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Center }
            };

            row.Formatting = rowFormatting;
            e.ExportContext.AddRow(new[] { row });
            e.ExportContext.MergeCells(new DevExpress.Export.Xl.XlCellRange(new DevExpress.Export.Xl.XlCellPosition(0, 0), new DevExpress.Export.Xl.XlCellPosition(2, 0)));
        }

        void options_CustomizeSheetFooter(ContextEventArgs e) {
            e.ExportContext.AddRow();

            CellObject row = new CellObject();
            row.Value = "Page Footer";

            XlFormattingObject rowFormatting = new XlFormattingObject {
                Font = new XlCellFont { Size = 18, Bold = true },
                Alignment = new DevExpress.Export.Xl.XlCellAlignment { HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Left }
            };

            row.Formatting = rowFormatting;
            e.ExportContext.AddRow(new[] { row });
            e.ExportContext.MergeCells(new DevExpress.Export.Xl.XlCellRange(new DevExpress.Export.Xl.XlCellPosition(0, 9), new DevExpress.Export.Xl.XlCellPosition(2, 9)));
        }
    }
}
