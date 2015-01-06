using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;

namespace PatronageWP
{
    interface INavigationService
    {
        void RegisterRootFrame(Frame f);
        void Navigate(Type t);
        void GoBack();
    }
}
