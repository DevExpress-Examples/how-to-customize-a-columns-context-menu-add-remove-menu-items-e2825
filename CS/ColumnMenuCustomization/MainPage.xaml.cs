using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Bars;

namespace ColumnMenuCustomization {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.ItemsSource = new ProductList();
        }

        private void TableView_ShowGridMenu(object sender, DevExpress.Xpf.Grid.GridMenuEventArgs e) {
            // Check whether this event was raised for a column's context menu.
            if (e.MenuType != GridMenuType.Column) return;

            // Remove the Column Chooser menu item.
            e.Customizations.Add(new RemoveBarItemAndLinkAction() {
                ItemName = DefaultColumnMenuItemNames.ColumnChooser
            });

            // Create a custom menu item and add it to the context menu.
            BarButtonItem bi = new BarButtonItem();
            bi.Name = "customItem";
            bi.Content = "Custom Item";
            bi.ItemClick += new ItemClickEventHandler(customItem_ItemClick);
            e.Customizations.Add(bi);
        }

        private void customItem_ItemClick(object sender, ItemClickEventArgs e) {
            // Implement the custom action.
            // ...
        }
    }
}
