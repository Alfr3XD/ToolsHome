using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsHome.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToolsHome.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
		private Tarea TareaProp;
		public EditPage (Tarea tarea)
		{
			InitializeComponent ();

			this.TareaProp = tarea;

			var Description = tarea.Description;
			var Time = tarea.Timestamp;
			var State = tarea.State;

            TxtDescription.Text = Description;
			DateFecha.Date = Time;
			PickerState.SelectedItem = State;

		}

		private async void EditTaksBtn(object sender, EventArgs e)
		{

			TareaProp.Description = TxtDescription.Text;

            TareaProp.Timestamp = DateFecha.Date;

            TareaProp.State = PickerState.SelectedItem.ToString();

            if (!string.IsNullOrWhiteSpace(TxtDescription.Text) && DateFecha.Date != DateTime.MinValue && PickerState.SelectedItem != null)
            {
                try
                {

                    var result = await App.DatabaseApplication.UpdateTaks(TareaProp);

                    if (result == 1)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error al crear la tarea", "intenta nuevamente", "cerrar");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error al crear la tarea", ex.Message, "cerrar");
                }
            }
            else
            {
                await DisplayAlert("Error al crear la tarea", "Te falta rellenar un campo", "cerrar");
                return;
            }
        }
    }
}