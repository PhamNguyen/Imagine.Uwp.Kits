using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Imagine.Uwp.Kits.Controls.Dialog
{
    public class RingDialog
    {
        private static Popup popup;
        private static RingView ring;

        public RingDialog() {
            if (popup == null)
                popup = new Popup();
            if(ring == null)
                ring = new RingView();
        }

        public void Show()
        {
            Window.Current.SizeChanged -= Current_SizeChanged;

            Window.Current.SizeChanged += Current_SizeChanged;
            
            SizeChanged();

            popup.Child = ring;

            popup.IsOpen = true;
        }

        private void SizeChanged()
        {
            popup.Width = Window.Current.Bounds.Width;
            popup.Height = Window.Current.Bounds.Height;
            ring.Width = popup.Width;
            ring.Height = popup.Height;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            SizeChanged();
        }

        public void Hide()
        {
            popup.IsOpen = false;
        }
    }
}
