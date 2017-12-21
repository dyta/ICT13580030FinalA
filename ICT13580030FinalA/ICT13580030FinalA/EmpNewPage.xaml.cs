
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ICT13580030FinalA.Models;
namespace ICT13580030FinalA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpNewPage : ContentPage
    {
        Employee employee;
        public EmpNewPage(Employee employee = null)
        {
            InitializeComponent();
            this.employee = employee;
            titleLabel.Text = employee == null ? "เพิ่มพนักงาน" : "แก้ไขข้อมูลพนักงาน";
            salaryEntry.ValueChanged += SalaryEntry_ValueChanged;

            childrenEntry.ValueChanged += ChildrenEntry_ValueChanged;


            genderPicker.Items.Add("ชาย");
            genderPicker.Items.Add("หญิง");

            sectionPicker.Items.Add("บัญชี");
            sectionPicker.Items.Add("การเงิน");
            sectionPicker.Items.Add("ไอที");

            cancelButton.Clicked += CancelButton_Clicked;
            saveButton.Clicked += SaveButton_Clicked;

            if (employee != null)
            {
                firstNameEntry.Text = employee.FirstName;
                lastNameEntry.Text = employee.LastName;
                ageEntry.Text = employee.Age.ToString();
                genderPicker.SelectedItem = employee.Gender;
                sectionPicker.SelectedItem = employee.Section;
                cellPhoneEntry.Text = employee.Telephone.ToString();
                emailEntry.Text = employee.Email;
                addressEditor.Text = employee.Address;
               
                childrenLabel.Text = employee.Children.ToString();
                salaryLabel.Text = employee.Salary.ToString();
            }
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                if (employee == null)
                {
                    employee = new Employee();
                    employee.FirstName = firstNameEntry.Text;
                    employee.LastName = lastNameEntry.Text;
                    employee.Age = int.Parse(ageEntry.Text);
                    employee.Gender = genderPicker.SelectedItem.ToString();
                    employee.Section = sectionPicker.SelectedItem.ToString();
                    employee.Telephone = int.Parse(cellPhoneEntry.Text);
                    employee.Email = emailEntry.Text;
                    employee.Address = addressEditor.Text;
                   
                    employee.Children = int.Parse(childrenLabel.Text);
                    employee.Salary = int.Parse(salaryLabel.Text);

                    var id = App.DbHelper.AddEmployee(employee);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                }
                else
                {
                    employee.FirstName = firstNameEntry.Text;
                    employee.LastName = lastNameEntry.Text;
                    employee.Age = int.Parse(ageEntry.Text);
                    employee.Gender = genderPicker.SelectedItem.ToString();
                    employee.Section = sectionPicker.SelectedItem.ToString();
                    employee.Telephone = int.Parse(cellPhoneEntry.Text);
                    employee.Email = emailEntry.Text;
                    employee.Address = addressEditor.Text;
                
                    employee.Children = int.Parse(childrenLabel.Text);
                    employee.Salary = int.Parse(salaryLabel.Text);

                    var id = App.DbHelper.UpdateEmployee(employee);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                }
                await Navigation.PopModalAsync();
            }
        }

        private void ChildrenEntry_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            childrenLabel.Text = e.NewValue.ToString("N0");
        }

        private void SalaryEntry_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            salaryLabel.Text = e.NewValue.ToString("N0");
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}