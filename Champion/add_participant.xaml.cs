using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Champion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class add_participant : ContentPage
    {
        public add_participant()
        {
            InitializeComponent();
            gender.Items.Add("Male");
            gender.Items.Add("Female");
            gender.Items.Add("Others");
            type.Items.Add("Child");
            type.Items.Add("Parent");
            type.Items.Add("Relative");


            }
         


    }
}
