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
	public partial class Tareas : ContentPage
	{

		private IList<Tarea> TareasList { get; set; }
		public Tareas ()
		{
			InitializeComponent ();

            TareasList = new List<Tarea>
            {
                new Tarea
                {
                    Id = 1,
                    Description = "Tarea 1",
                    Timestamp = DateTime.Now,
                    State = "Pendiente"
                },
                new Tarea
                {
                    Id = 2,
                    Description = "Tarea 2",
                    Timestamp = DateTime.Now,
                    State = "Pendiente"
                },
                new Tarea
                {
                    Id = 2,
                    Description = "Tarea 3",
                    Timestamp = DateTime.Now,
                    State = "Pendiente"
                }
            };

            tareaList.ItemsSource = TareasList;
        }
	}
}