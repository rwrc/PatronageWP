using System;
using System.Dynamic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace PatronageWP.Model
{
    class NavigationService:INavigationService
    {
        private Frame _rootFrame;
        private static NavigationService _instance;

        private NavigationService()
        {
                
        }

        public void RegisterRootFrame(Frame f)
        {
            _rootFrame = f;
            _rootFrame.ContentTransitions = new TransitionCollection() { new NavigationThemeTransition() };
            Window.Current.Content = _rootFrame;
        }

        public void Navigate(Type t)
        {
            _rootFrame.Navigate(t);
        }

        public static NavigationService Instance
        {
            get{ return _instance ?? (_instance = new NavigationService());}
        }

        public void GoBack()
        {
         _rootFrame.GoBack(); 
        }
    }
}
