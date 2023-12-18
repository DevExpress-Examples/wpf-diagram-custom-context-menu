Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Diagram
Imports System.Collections.Generic
Imports System.Windows

Namespace WpfApp7

    Public Partial Class MainWindow

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class DiagramDesignerControlEx
        Inherits DiagramDesignerControl

        Protected Overrides Iterator Function CreateContextToolBar() As IEnumerable(Of IBarManagerControllerAction)
            If SelectedItems IsNot Nothing AndAlso SelectedItems.Count > 0 Then
                Dim item = New BarButtonItem() With {.Glyph = DXImageHelper.GetImageSource("Images/Arrows/Stop_16x16.png")}
                AddHandler item.ItemClick, AddressOf SecondItem_ItemClick
                Yield item
            End If

            For Each action As IBarManagerControllerAction In MyBase.CreateContextMenu()
                Yield action
            Next
        End Function

        Protected Overrides Iterator Function CreateContextMenu() As IEnumerable(Of IBarManagerControllerAction)
            If SelectedItems IsNot Nothing AndAlso SelectedItems.Count > 0 Then
                Dim item = New BarButtonItem() With {.Glyph = DXImageHelper.GetImageSource("Images/Arrows/Record_16x16.png"), .Content = "Custom Item"}
                AddHandler item.ItemClick, AddressOf Item_ItemClick
                Yield item
            End If

            For Each action As IBarManagerControllerAction In MyBase.CreateContextMenu()
                Yield action
            Next
        End Function

        Private Sub Item_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            MessageBox.Show("Custom item clicked!")
        End Sub

        Private Sub SecondItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            MessageBox.Show("Custom toolbar item clicked...")
        End Sub
    End Class
End Namespace
