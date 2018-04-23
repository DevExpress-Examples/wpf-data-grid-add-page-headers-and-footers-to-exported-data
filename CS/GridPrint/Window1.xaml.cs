using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Printing.UI;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Grid;

namespace GridPrint
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private class Product
        {
            public string Group { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var productList = new Product[]
            {
                new Product { Group = "Group 1", Name = "Product 1", Price = 12.94m },
                new Product { Group = "Group 1", Name = "Product 2", Price = 35.42m },
                new Product { Group = "Group 2", Name = "Product 3", Price = 22.45m },
                new Product { Group = "Group 3", Name = "Product 4", Price = 36.99m },
                new Product { Group = "Group 3", Name = "Product 5", Price = 76.54m },
                new Product { Group = "Group 4", Name = "Product 6", Price = 98.65m }
            };

            gridControl1.DataSource = productList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var link = new VisualDataNodeLink((TableView)gridControl1.View);
            
            var preview = new PrintPreview();
            preview.DataContext = link;
            link.PageHeader = (ControlTemplate)Resources["PageHeader"];
            link.PageFooter = (ControlTemplate)Resources["PageFooter"];
            
            link.CreateDocument(true);

            preview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            preview.WindowState = WindowState.Maximized;

            preview.ShowDialog();
        }
    }
}
