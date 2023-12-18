<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1026838)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF DiagramControl - Create Custom 

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

- link.cs (VB: link.vb)
- link.js
- ...
