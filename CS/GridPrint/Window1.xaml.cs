using System.Windows;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;

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

            gridControl1.ItemsSource = productList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var link = new PrintableControlLink((TableView)gridControl1.View);
            link.PageHeaderTemplate = (DataTemplate)Resources["PageHeader"];
            link.PageFooterTemplate = (DataTemplate)Resources["PageFooter"];

            DocumentPreviewWindow preview = new DocumentPreviewWindow()
            {
                Owner = this,
                Model = new LinkPreviewModel(link)
            };

            link.CreateDocument(true);
            preview.ShowDialog();
            
            //var preview = new PrintPreview();
            //preview.DataContext = link;
            
            //link.CreateDocument(true);

            //preview.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //preview.WindowState = WindowState.Maximized;

            //preview.ShowDialog();
        }
    }
}
