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
            return (string)obj.GetValue(MyPropertyProperty);
        }

        public static void SetMyProperty(DependencyObject obj, string value)
        {
            obj.SetValue(MyPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.RegisterAttached("MyProperty", typeof(string), typeof(LoadingEvents), new PropertyMetadata(null, LoadedEventChanged));

        private static void LoadedEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s1, s2) =>
                {
                    var viewModel = element.DataContext;
                    if (viewModel == null)
                        return;
                    var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null)
                        methodInfo.Invoke(viewModel, null);
                };
            }
        }
    }
}
