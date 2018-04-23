Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Bars

Namespace ColumnMenuCustomization
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = New ProductList()
		End Sub

		Private Sub TableView_ShowGridMenu(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.GridMenuEventArgs)
			' Check whether this event was raised for a column's context menu.
			If e.MenuType <> GridMenuType.Column Then
				Return
			End If

			' Remove the Column Chooser menu item.
			e.Customizations.Add(New RemoveBarItemAndLinkAction() With {.ItemName = DefaultColumnMenuItemNames.ColumnChooser})

			' Create a custom menu item and add it to the context menu.
			Dim bi As New BarButtonItem()
			bi.Name = "customItem"
			bi.Content = "Custom Item"
			AddHandler bi.ItemClick, AddressOf customItem_ItemClick
			e.Customizations.Add(bi)
		End Sub

		Private Sub customItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			' Implement the custom action.
			' ...
		End Sub
	End Class
End Namespace
