using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyCSharpWSA.Scripts
{
    class ImageEvent
    {
        public event EventHandler MyEvent;
        public ImageEventArgs MyEventArgs;
        public delegate void ImageEventHandler(ImageEvent imageEvent, EventArgs eventArgs);

        public ImageEvent()
        {
        }

        public void EventOccured() => MyEvent(this, MyEventArgs);

    }

    public class ImageEventArgs : EventArgs
    {
        int number;
    }
}
