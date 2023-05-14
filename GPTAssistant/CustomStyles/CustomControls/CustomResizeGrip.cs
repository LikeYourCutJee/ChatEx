using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace GPTAssistant
{
    public class CustomResizeGrip : Thumb
    {
        public CustomResizeGrip()
        {
            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.VerticalAlignment = VerticalAlignment.Bottom;
            this.Width = 100;
            this.Height = 5;
            this.Background = Brushes.White;
            this.Cursor = Cursors.SizeNWSE;
            this.DragDelta += CustomResizeGrip_DragDelta;
        }

        private void CustomResizeGrip_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.Width += e.HorizontalChange;
                window.Height += e.VerticalChange;
            }
        }
    }
}
