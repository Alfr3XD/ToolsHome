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
    public partial class CalcularPage : ContentPage
    {
        public CalcularPage()
        {
            InitializeComponent();
        }
        private void CalcBtn(object sender, EventArgs e)
        {
            string Alto = txtAlto.Text;
            string Ancho = txtAncho.Text;

            if (!double.TryParse(Alto, out double altoNumero))
            {

                return;
            }

            if (!double.TryParse(Ancho, out double anchoNumero))
            {

                return;
            }

            double AltoN = Convert.ToDouble(Alto);
            double AnchoN = Convert.ToDouble(Ancho);

            double Value = AltoN * AnchoN;

            ValueM2.Text = "Respuesta: " + Value.ToString();
        }
    }
}