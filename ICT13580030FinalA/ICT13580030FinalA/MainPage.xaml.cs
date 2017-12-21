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
        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Employee;
            Navigation.PushModalAsync(new EmpNewPage(product));
        }
        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Employee;
                App.DbHelper.DeleteEmployee(product);

                await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลสินค้าเรียบร้อย", "ตกลง");
                LoadData();
            }
        }

    }
}
