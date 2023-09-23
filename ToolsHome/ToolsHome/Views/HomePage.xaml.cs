using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToolsHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private async void btn_changePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearTarea());
        }

        private async void btn_changePageToDo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDo());
        }
        private async void btn_changePageTareas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tareas());
        }

        private async void btn_changePageGastos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gastos());
        }

    }
}