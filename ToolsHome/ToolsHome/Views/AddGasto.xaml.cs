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
	public partial class AddGasto : ContentPage
	{
		public AddGasto ()
		{
			InitializeComponent ();
		}

		private async void Btn_AddGasto(object sender, EventArgs e)
		{
            try
            {
                if (double.TryParse(Gasto_Double.Text, out double gastoValue))
                {
                    var gasto = new Gasto
                    {
                        Description = DescriptionEntry_Txt.Text,
                        Category = PickerCategory.SelectedItem.ToString(),
                        State = PickerState.SelectedItem.ToString(),
                        Date = DateFecha.Date,
                        Amount = gastoValue
                    };

                    await App.DatabaseApplication.InsertGastoAsync(gasto);
                    await Navigation.PopAsync();
                }
                else if(string.IsNullOrWhiteSpace(DescriptionEntry_Txt.Text) && 
                    DateFecha.Date == DateTime.MinValue && 
                    PickerState.SelectedItem == null &&
                    PickerCategory.SelectedItem == null
                )
                {
                    await DisplayAlert("Error", "Hay datos sin rellenar", "Volver");
                }
                else
                {
                    await DisplayAlert("Error", "El gassto asignado es incorrecto", "Volver");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Volver");
            }
        }
	}
}