Imports System.Windows
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Printing
Imports DevExpress.Xpf.Core

Namespace GridPrint
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Class Product
            Public Property Group() As String
            Public Property Name() As String
            Public Property Price() As Decimal
        End Class

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim productList = New Product() { _
                New Product With {.Group = "Group 1", .Name = "Product 1", .Price = 12.94D}, _
                New Product With {.Group = "Group 1", .Name = "Product 2", .Price = 35.42D}, _
                New Product With {.Group = "Group 2", .Name = "Product 3", .Price = 22.45D}, _
                New Product With {.Group = "Group 3", .Name = "Product 4", .Price = 36.99D}, _
                New Product With {.Group = "Group 3", .Name = "Product 5", .Price = 76.54D}, _
                New Product With {.Group = "Group 4", .Name = "Product 6", .Price = 98.65D} _
            }

            gridControl1.ItemsSource = productList
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim link = New PrintableControlLink(CType(gridControl1.View, TableView))
            link.PageHeaderTemplate = DirectCast(Resources("PageHeader"), DataTemplate)
            link.PageFooterTemplate = DirectCast(Resources("PageFooter"), DataTemplate)

            Dim wnd As New DocumentPreviewWindow()
            wnd.PreviewControl.DocumentSource = link
            link.CreateDocument()
            wnd.Show()
        End Sub
    End Class
End Namespace
