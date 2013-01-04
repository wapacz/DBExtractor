using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITSharp.ScheDEX.GUI
{
    public static class GUIHelper
    {
        //public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : Control
        //{
        //    if (control.InvokeRequired)
        //    {
        //        control.Invoke(new Action(() => action(control)));
        //    }
        //    else
        //    {
        //        action(control);
        //    }
        //}

        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
