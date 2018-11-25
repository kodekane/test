using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Node : INotifyPropertyChanged
    {
        private ObservableCollection<Pin> pins = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> Pins
        {
            get
            {
                return pins;
            }
        }

        private ObservableCollection<ConnectorItem> connectorItems = new ObservableCollection<ConnectorItem>();
        public ObservableCollection<ConnectorItem> ConnectorItems
        {
            get
            {
                return connectorItems;
            }
        }


        private double x;
        /// <summary>
        /// The X coordinate of the location of the rectangle (in content coordinates).
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (x == value)
                {
                    return;
                }

                x = value;

                OnPropertyChanged("X");
            }
        }

        private double y;
        /// <summary>
        /// The Y coordinate of the location of the rectangle (in content coordinates).
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (y == value)
                {
                    return;
                }

                y = value;

                OnPropertyChanged("Y");
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
                OnPropertyChanged("Name");
            }
        }

        public Node(double x, double y)
        {
            X = x;
            Y = y;

            Pins.Add(new Pin() { Name = "p1" });
            Pins.Add(new Pin() { Name = "p2" });

            ConnectorItems.Add(new ConnectorItem() { Name = "c1" });
            ConnectorItems.Add(new ConnectorItem() { Name = "c1" });
            ConnectorItems.Add(new ConnectorItem() { Name = "c1" });


        }

        /// <summary>
        /// Raises the 'PropertyChanged' event when the value of a property of the view model has changed.
        /// </summary>
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// 'PropertyChanged' event that is raised when the value of a property of the view model has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
