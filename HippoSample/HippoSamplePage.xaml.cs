using Hippo.Abstraction;
using Xamarin.Forms;
using HippoSample.Models;

namespace HippoSample
{
    public partial class HippoSamplePage : ContentPage
    {
        public HippoSamplePage()
        {
            InitializeComponent();

            var manager = new StoreManager();

            var store = new BaseStore<Session>();

            manager.AddStore(store);
            manager.GetStore<Session>();


        }
    }
}
