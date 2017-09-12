using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;


namespace Champion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Participant : ContentPage
    {
        public Participant()
        {
            //InitializeComponent();
        }
    }
    class RepeaterView : StackLayout
    {
        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create<RepeaterView, DataTemplate>(
                p => p.ItemTemplate,
                default(DataTemplate));

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create<RepeaterView, IEnumerable>(
                p => p.ItemsSource,
                Enumerable.Empty<object>(),
                BindingMode.OneWay,
                null,
                ItemsChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private static void ItemsChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var repeater = (RepeaterView)bindable;
            repeater.Children.Clear();

            var dataTemplate = repeater.ItemTemplate;

            foreach (object viewModel in newvalue)
            {
                var content = dataTemplate.CreateContent();
                if (!(content is View) && !(content is ViewCell))
                {
                    //throw new InvalidVisualObjectException(content.GetType(), "Invalid visual object", nameof(content));
                }

                var view = (content is View) ? content as View : ((ViewCell)content).View;
                view.BindingContext = viewModel;

                repeater.Children.Add(view);
            }
        }
    }
}