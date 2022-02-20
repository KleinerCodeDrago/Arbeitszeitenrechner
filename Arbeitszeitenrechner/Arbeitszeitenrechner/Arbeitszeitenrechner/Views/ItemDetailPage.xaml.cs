using Arbeitszeitenrechner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Arbeitszeitenrechner.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}