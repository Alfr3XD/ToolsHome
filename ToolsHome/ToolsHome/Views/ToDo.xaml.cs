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

    public partial class ToDo : ContentPage
    {
        private IList<Tarea> Tareas { get; set; }
        private IList<string> Indexes { get; set;  }

        private IList<Tarea> TareasCollection { get; set; }
        public ToDo()
        {
            InitializeComponent();

            Indexes = new List<string>();
            Indexes.Add("Index 4");
            Indexes.Add("Index 5");
            Indexes.Add("Index 6");

            ListaArray.ItemsSource = Indexes;

            Tareas = new List<Tarea>();
            Tareas.Add(new Tarea { 
                Id = 1,
                Description = "Tarea 1",
                Timestamp = DateTime.Now,
                State = "INCOMPLETE"
            });
            Tareas.Add(new Tarea
            {
                Id = 2,
                Description = "Tarea 2",
                Timestamp = DateTime.Now,
                State = "COMPLETE"
            });
            Tareas.Add(new Tarea
            {
                Id = 2,
                Description = "Tarea 3",
                Timestamp = DateTime.Now,
                State = "INCOMPLETE"
            });

            indexList.ItemsSource = Tareas;

            TareasCollection = new List<Tarea>();

            TareasCollection.Add(new Tarea
            {
                Id = 1,
                Description = "Tarea 4",
                Timestamp = DateTime.Now,
                State = "INCOMPLETE"
            });
            TareasCollection.Add(new Tarea
            {
                Id = 2,
                Description = "Tarea 5",
                Timestamp = DateTime.Now,
                State = "COMPLETE"
            });
            TareasCollection.Add(new Tarea
            {
                Id = 2,
                Description = "Tarea 6",
                Timestamp = DateTime.Now,
                State = "INCOMPLETE"
            });

            TareaCollectionView.ItemsSource = TareasCollection;
        }
    }
}