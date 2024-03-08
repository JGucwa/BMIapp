using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMIapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BMIHistory : ContentPage
    {
        public BMIHistory()
        {
            InitializeComponent();
            InitializeData();
        }
        async void InitializeData()
        {
            Historylst.ItemsSource = App.database.GetAll();
        }
        void Remove(object sender, EventArgs e)
        {
            var btn = sender as Button;
            BMIResult result = btn.BindingContext as BMIResult;
            App.database.Remove(result);

            InitializeData();
        }
    }
}