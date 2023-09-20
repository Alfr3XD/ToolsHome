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

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetCollectionViewItemsWithCollectionList();
        }

        private void SetCollectionViewItemsWithCollectionList()
        {

            Indexes = new List<string>
            {
                "Index 4",
                "Index 5",
                "Index 6"
            };

            ListaArray.ItemsSource = Indexes;

            Tareas = new List<Tarea>
            {
                new Tarea
                {
                    Id = 1,
                    Description = "Tarea 1",
                    Timestamp = DateTime.Now,
                    State = "INCOMPLETE"
                },
                new Tarea
                {
                    Id = 2,
                    Description = "Tarea 2",
                    Timestamp = DateTime.Now,
                    State = "COMPLETE"
                },
                new Tarea
                {
                    Id = 2,
                    Description = "Tarea 3",
                    Timestamp = DateTime.Now,
                    State = "INCOMPLETE"
                }
            };

            indexList.ItemsSource = Tareas;

            TareasCollection = new List<Tarea>
            {
                new Tarea
                {
                    Id = 1,
                    Description = "Tarea 4",
                    Timestamp = DateTime.Now,
                    State = "INCOMPLETE"
                },
                new Tarea
                {
                    Id = 2,
                    Description = "Tarea 5",
                    Timestamp = DateTime.Now,
                    State = "COMPLETE"
                },
                new Tarea
                {
                    Id = 2,
                    Description = "Tarea 6",
                    Timestamp = DateTime.Now,
                    State = "INCOMPLETE"
                }
            };

            TareaCollectionView.ItemsSource = TareasCollection;
        }

    }
}