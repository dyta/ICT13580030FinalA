using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ICT13580030FinalA.Models;
namespace ICT13580030FinalA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;
        }

        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EmpNewPage());
        }
        protected override void OnAppearing()
        {
            LoadData();
        }

        void LoadData()
        {
            empListView.ItemsSource = App.DbHelper.GetEmployees();
        }
        
    }
}
