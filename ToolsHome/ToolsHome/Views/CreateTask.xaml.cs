using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToolsHome.Models;

namespace ToolsHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTask : ContentPage
    {
        public CreateTask()
        {
            InitializeComponent();
        }

        private async void CrearTask(object sender, EventArgs e)
        {
            try
            {
                var task = new Tarea
                {
                    Description = TxtDescription.Text,
                    Timestamp = DateFecha.Date,
                    State = PickerState.SelectedItem.ToString()
                };

                var result = await App.DatabaseApplication.InsertItem(task);

                if(result == 1) {
                    await Navigation.PopAsync();
                } else
                {
                    await DisplayAlert("Error al crear la tarea", "intenta nuevamente", "cerrar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al crear la tarea", ex.Message, "cerrar");
            }
        }
    }
}