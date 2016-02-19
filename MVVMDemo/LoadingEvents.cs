using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDemo
{
    public static class LoadingEvents
    {


        public static string GetMyProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(MyLoadedEvent);
        }

        public static void SetMyProperty(DependencyObject obj, int value)
        {
            obj.SetValue(MyLoadedEvent, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyLoadedEvent =
            DependencyProperty.RegisterAttached("MyProperty", typeof(int), typeof(LoadingEvents), new PropertyMetadata(null, SetMyLoadedEvent));

        private static void SetMyLoadedEvent(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if(element != null)
            {
                element.Loaded += (s1, s2) =>
                {
                    var viewModel = element.DataContext;
                    if (viewModel == null)
                        return;
                    var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                };

            }
        }

    }
}
