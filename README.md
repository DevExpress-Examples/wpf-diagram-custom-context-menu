<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/733062861/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1206890)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF DiagramControl - Create Custom Context Menus

This example customizes shape context menus within the DevExpress [WPF Diagram Control](https://docs.devexpress.com/WPF/116103/controls-and-libraries/diagram-control/diagram-control).

![image](https://github.com/DevExpress-Examples/wpf-diagram-custom-context-menu/assets/65009440/869658cc-f78d-41d0-bca1-89dac35a5158)

The Diagram Control does not include built-in APIs to customize shape-related context menus. You can create a `DiagramControl` or `DiagramDesignerControl` class descendant and override the **CreateContextMenu** or **CreateContextToolBar** method to add custom menu items as needs dictate:

```cs
public class DiagramDesignerControlEx : DiagramDesignerControl {
    protected override IEnumerable<IBarManagerControllerAction> CreateContextToolBar() {
        if (SelectedItems != null && SelectedItems.Count > 0) {
            var item = new BarButtonItem() {
                Glyph = DXImageHelper.GetImageSource("Images/Arrows/Stop_16x16.png"),
            };
            item.ItemClick += OnContextToolBarItemClick;
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
            item.ItemClick += OnContextMenuItemClick;
            yield return item;
        }
        foreach (IBarManagerControllerAction action in base.CreateContextMenu())
            yield return action;
    }
}
```

## Files to Review

* [MainWindow.xaml.cs](./CS/WpfApp7/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApp7/MainWindow.xaml.vb))

## Documentation

* [Diagram Control](https://docs.devexpress.com/WPF/116103/controls-and-libraries/diagram-control/diagram-control)
* [The List of Bar Items and Links](https://docs.devexpress.com/WPF/6646/controls-and-libraries/ribbon-bars-and-menu/common-concepts/the-list-of-bar-items-and-links)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-diagram-custom-context-menu&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-diagram-custom-context-menu&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
