using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class ConnectorItem : ContentControl
    {
        #region Dependency Property/Event Definitions

        public static readonly DependencyProperty HotspotProperty =
            DependencyProperty.Register("Hotspot", typeof(Point), typeof(ConnectorItem));

        public static readonly DependencyProperty AncestorProperty =
            DependencyProperty.Register("Ancestor", typeof(FrameworkElement), typeof(ConnectorItem),
                new FrameworkPropertyMetadata(Ancestor_PropertyChanged));

        #endregion Dependency Property/Event Definitions

        public ConnectorItem()
        {
            //
            // By default, we don't want a connector to be focusable.
            //
            Focusable = false;

            //
            // Hook layout update to recompute 'Hotspot' when the layout changes.
            //
            this.LayoutUpdated += new EventHandler(ConnectorItem_LayoutUpdated);
            this.SizeChanged += new SizeChangedEventHandler(ConnectorItem_SizeChanged);
        }

        /// <summary>
        /// Automatically updated dependency property that specifies the hotspot (or center point) of the connector.
        /// These coordinates are relative to the parent control specified by the 'Ancestor' property.
        /// </summary>
        public Point Hotspot
        {
            get
            {
                return (Point)GetValue(HotspotProperty);
            }
            set
            {
                SetValue(HotspotProperty, value);
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Specifies the ancestor control used to calculate the connector hotspot.
        /// </summary>
        public FrameworkElement Ancestor
        {
            get
            {
                return (FrameworkElement)GetValue(AncestorProperty);
            }
            set
            {
                SetValue(AncestorProperty, value);
            }
        }

        #region Private Methods

        /// <summary>
        /// Event raised when 'Ancestor' property has changed.
        /// </summary>
        private static void Ancestor_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ConnectorItem c = (ConnectorItem)d;
            c.UpdateHotspot();
        }

        /// <summary>
        /// Event raised when the layout of the connector has been updated.
        /// </summary>
        private void ConnectorItem_LayoutUpdated(object sender, EventArgs e)
        {
            UpdateHotspot();
        }

        /// <summary>
        /// Event raised when the size of the connector has changed.
        /// </summary>
        private void ConnectorItem_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateHotspot();
        }

        /// <summary>
        /// Update the connector hotspot.
        /// </summary>
        private void UpdateHotspot()
        {
            if (this.Ancestor == null)
            {
                // 
                // Can't do anything if the ancestor hasn't been set.
                //
                return;
            }

            //
            // Calculate the center point (in local coordinates) of the connector.
            //
            var center = new Point(this.ActualWidth / 2, this.ActualHeight / 2);

            //
            // Transform the local center point so that it is the center of the connector relative
            // to the specified ancestor.
            //
            var centerRelativeToAncestor = this.TransformToAncestor(this.Ancestor).Transform(center);

            //
            // Assign the computed point to the 'Hotspot' property.  Data-binding will take care of 
            // pushing this value into the data-model.
            //
            this.Hotspot = centerRelativeToAncestor;
        }

        #endregion Private Methods
    }
}
