<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/733062861/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1206890)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF DiagramControl - Create Custom Context Menu

This example demonstrates how to customize context menus for shapes in the [Diagram Control](https://docs.devexpress.com/WPF/116103/controls-and-libraries/diagram-control/diagram-control).

Put a screenshot that illustrates the result here.

The Diagram Control doesn't have built-in API to customize the context menus for shapes. To accomplish this task, you can create a `DiagramControl` or `DiagramDesignerControl` class descendant and override the **CreateContextMenu** or **CreateContextToolBar** method and add a custom item there:

```cs
protected override IEnumerable<IBarManagerControllerAction> CreateContextToolBar() {
    if (SelectedItems != null && SelectedItems.Count > 0) {
        var item = new BarButtonItem() {
            Glyph = DXImageHelper.GetImageSource("Images/Arrows/Stop_16x16.png"),
        };
        item.ItemClick += SecondItem_ItemClick;
        yield return item;
    }
    foreach (IBarManagerControllerAction action in base.CreateContextMenu())
        yield return action;
}

protected override IEnumerable<IBarManagerControllerAction> CreateContextMenu() {
    if (SelectedItems != null && SelectedItems.Count > 0) {
        var item = new BarButtonItem() {
            Glyph = DXImageHelper.GetImageSource("Images/Arrows/Record_16x16.png"),
            Content = "Custom Item"
        };
        item.ItemClick += Item_ItemClick;
        yield return item;
    }
    foreach (IBarManagerControllerAction action in base.CreateContextMenu())
        yield return action;
}
```

## Files to Review

- [MainWindow.xaml.cs](./CS/WpfApp7/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApp7/MainWindow.xaml.vb))
