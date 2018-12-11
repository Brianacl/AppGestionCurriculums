using AppGestionCurriculums.ViewModels.Competencias;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionCurriculums.Views.Competencias
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCompetenciasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        private FicVmCompetenciasItem VmLoCompetenciasItem;
        
        private bool handle = true;
        private bool handle2 = true;
        public Int16 indexSeleccionado;
        public FicViCompetenciasItem (object navigationContext)
		{
			InitializeComponent ();
            FicLoParameter = navigationContext;
            BindingContext = App.FicVmLocator.FicVmCompetenciasItem;
            //VmLoCompetenciasItem = new FicVmCompetenciasItem();

        }
        /*
        private void ComboBox_DropDownClosed2(object sender, EventArgs e)
        {
            if (handle2) Handle();
            handle2 = true;
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            SfComboBox comboBox2 = sender as SfComboBox;
            handle2 = !comboBox2.IsDropDownOpen;
            Handle2();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SfComboBox comboBox = sender as SfComboBox;
            handle = !comboBox.IsDropDownOpen;
            Handle();
        }
        */
        /*private void Handle()
        {
            //indexSeleccionado= Int16.Parse(((int.Parse(comboBox.SelectedIndex.ToString())) + 1) + "");
            // new Page().DisplayAlert("ALERTA - ComboBox", "Indice seleccionado "+index, "OK");
*
                    new Page().DisplayAlert("ALERTA - ComboBox", "Primero seleccionado", "OK");
                    //Handle for the first combobox
                    break;
                case "2":
                    //Handle for the second combobox
                    break;
                case "3":
                    //Handle for the third combobox
                    break;
            }
        }

        private void Handle2()
        {
            switch (comboBox2.SelectedIndex.ToString())//.Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                //this.ComboBox1 = new System.Windows.Forms.ComboBox();
            

            
                case "1":
            
                    //Handle for the first combobox
                    break;
                case "2":
                    //Handle for the second combobox
                    break;
                case "3":
                    //Handle for the third combobox
                    break;
            }
        }*/
        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCompetenciasItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }
    }
}