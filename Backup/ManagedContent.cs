using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DockingLibrary
{
    public abstract class ManagedContent : Window
    {
        protected Pane _containerPane = null;

        public DockManager DockManager;

        public ManagedContent(DockManager manager)
        {
            DockManager = manager;
        }

        public ManagedContent() { }

        public virtual new void Show()
        {
            
        }

        public virtual new void Close()
        {
            base.Close();
        }

        public Pane ContainerPane
        {
            get { return _containerPane; }
        }

        internal void SetContainerPane(Pane pane)
        {
            _containerPane = pane;
        }
    }
}
