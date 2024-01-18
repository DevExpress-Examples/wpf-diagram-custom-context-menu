using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Diagram;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp7 {
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
        }
    }

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

        private void OnContextMenuItemClick(object sender, ItemClickEventArgs e) {
            MessageBox.Show("Custom context menu item is clicked!");
        }

        private void OnContextToolBarItemClick(object sender, ItemClickEventArgs e) {
            MessageBox.Show("Custom context toolbar item is clicked...");
        }
    }
}
