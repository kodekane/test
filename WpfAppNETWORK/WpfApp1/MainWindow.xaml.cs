using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();

            _vm = new ViewModel();

            _vm.Nodes.Add(new Node(200, 200));
            

            DataContext = _vm;
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Thumb thumb = sender as Thumb;
            Node node = thumb.DataContext as Node;

            node.X += e.HorizontalChange;
            node.Y += e.VerticalChange;

            int g = 0;
        }

        private void ItemsControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            int a = 0;
        }

        private void Thumb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            int g = 0;
            var thumb = sender as Thumb;
            var pin = thumb.DataContext as Pin;

        }

        private void Pin_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            int g = 0;
            var thumb = sender as Pin;
        }

        private void ConnectorItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var ci = sender as ConnectorItem;
        }
    }
}
