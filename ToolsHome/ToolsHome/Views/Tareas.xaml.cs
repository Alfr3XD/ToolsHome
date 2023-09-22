using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ToolsHome.Models;
using System.Threading;

namespace ToolsHome.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tareas : ContentPage
	{
		public Tareas ()
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
            var Taks = await App.DatabaseApplication.GetItemsAsync();
            tareaListDB.ItemsSource = Taks;
        }

        private async void ChangePageAddTask(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateTask());
        }

        private async void ChangePageEditTask(object sender, EventArgs e)
        {
            if (sender is Button verDetallesButton && verDetallesButton.BindingContext is Tarea selectedItem)
            {
                // Abre la página de detalles y pasa el objeto seleccionado como parámetro
                await Navigation.PushAsync(new EditPage(selectedItem));
            }
        }

        private async void ToolbarItem_DeleteTaksClicked(object sender, EventArgs e)
        {
            var elementosSeleccionados = tareaListDB.SelectedItems;

            foreach (var elemento in elementosSeleccionados)
            {
                try
                {

                    if (elemento is Tarea tarea)
                    {
                        var result = await App.DatabaseApplication.DeleteTaks(tarea.Id);

                        if (result == 1)
                        {
                            tareaListDB.ItemsSource = tareaListDB.ItemsSource.Cast<Tarea>().Where(item => item.Id != tarea.Id).ToList();
                        }
                        else
                        {
                            await DisplayAlert("Error al eliminar la tarea", "Intente nuevamente", "Cerrar");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error al eliminar la tarea", ex.Message, "cerrar");
                }
            }
        }
    }
}