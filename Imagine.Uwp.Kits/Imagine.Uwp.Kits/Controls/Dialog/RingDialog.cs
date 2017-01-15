using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Imagine.Uwp.Kits.Controls.Dialog
{
    public class RingDialog
    {
        private Popup popup;

        public void Show() {
            if (popup == null)
                popup = new Popup();
            popup.Width = Window.Current.Bounds.Width;
            popup.Height = Window.Current.Bounds.Height;

        }

        public void Hide() {

        }
    }
}
