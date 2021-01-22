using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Constans;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMenuPage : Xamarin.Forms.TabbedPage
    {
        ToolbarItem ToolbarItem_DisconnectItem = new ToolbarItem()
        {
            Text = "Disconnect",
        };

        public TabbedMenuPage()
        {
            InitializeComponent();

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            MessagingCenter.Subscribe<HomePage>(this, Constants.RestaurantConnectedEventName, OnConnect);
        }

        private void ToolbarItem_DisconnectItem_Clicked(object sender, EventArgs e)
        {
            ToolbarItems.Remove(ToolbarItem_DisconnectItem);

            MessagingCenter.Send(this, Constants.RestaurantDisconnectedEventName);
        }

        private void OnConnect(HomePage homePage)
        {
            ToolbarItem_DisconnectItem.Clicked += ToolbarItem_DisconnectItem_Clicked;

            ToolbarItems.Add(ToolbarItem_DisconnectItem);
        }
    }
}