Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Printing.UI
Imports DevExpress.Xpf.Printing
Imports DevExpress.Xpf.Grid

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
			Private privateGroup As String
			Public Property Group() As String
				Get
					Return privateGroup
				End Get
				Set(ByVal value As String)
					privateGroup = value
				End Set
			End Property
			Private privateName As String
			Public Property Name() As String
				Get
					Return privateName
				End Get
				Set(ByVal value As String)
					privateName = value
				End Set
			End Property
			Private privatePrice As Decimal
			Public Property Price() As Decimal
				Get
					Return privatePrice
				End Get
				Set(ByVal value As Decimal)
					privatePrice = value
				End Set
			End Property
		End Class

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim productList = New Product() { New Product With {.Group = "Group 1", .Name = "Product 1", .Price = 12.94D}, New Product With {.Group = "Group 1", .Name = "Product 2", .Price = 35.42D}, New Product With {.Group = "Group 2", .Name = "Product 3", .Price = 22.45D}, New Product With {.Group = "Group 3", .Name = "Product 4", .Price = 36.99D}, New Product With {.Group = "Group 3", .Name = "Product 5", .Price = 76.54D}, New Product With {.Group = "Group 4", .Name = "Product 6", .Price = 98.65D} }

			gridControl1.DataSource = productList
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim link = New VisualDataNodeLink(CType(gridControl1.View, TableView))

			Dim preview = New PrintPreview()
			preview.DataContext = link
			link.PageHeader = CType(Resources("PageHeader"), ControlTemplate)
			link.PageFooter = CType(Resources("PageFooter"), ControlTemplate)

			link.CreateDocument(True)

			preview.WindowStartupLocation = WindowStartupLocation.CenterScreen
			preview.WindowState = WindowState.Maximized

			preview.ShowDialog()
		End Sub
	End Class
End Namespace
