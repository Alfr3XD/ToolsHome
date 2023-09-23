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
	public partial class Gastos : ContentPage
	{
		public Gastos ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetCollectionViewItemsWithDatabse();
        }

        private async void SetCollectionViewItemsWithDatabse()
        {
            var Items = await App.DatabaseApplication.GetGastosAsync();
            CollectionViewGastos.ItemsSource = Items;
        }

        private async void ChangePageAddGasto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGasto());
        }

        private async void ToolbarItem_DeleteGasto(object sender, EventArgs e)
        {
            var elementosSeleccionados = CollectionViewGastos.SelectedItems;

            foreach (var elemento in elementosSeleccionados)
            {
                try
                {

                    if (elemento is Gasto gasto)
                    {
                        var result = await App.DatabaseApplication.DeleteGastoAsync(gasto);

                        if (result == 1)
                        {
                            CollectionViewGastos.ItemsSource = CollectionViewGastos.ItemsSource.Cast<Gasto>()
                                .Where(item => item.Id != gasto.Id)
                                .ToList();
                        }
                        else
                        {
                            await DisplayAlert("Error al eliminar", "Intente nuevamente", "Cerrar");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error al eliminar", ex.Message, "cerrar");
                }
            }
        }
    }
}