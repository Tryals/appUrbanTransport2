using appUrbanTransport.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace appUrbanTransport.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddEdit.xaml
    /// </summary>
    public partial class PageAddEdit : Page
    {
        public PageAddEdit()
        {
            InitializeComponent();
            CmbTransport.ItemsSource = UrbanTransportEntities.GetContext().Transport.ToList();
            CmbTransport.SelectedValuePath = "id_transport";
            CmbTransport.DisplayMemberPath = "name";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Routes routes = new Routes()
            {
                number_of_cars = int.Parse(TxtNumCars.Text),
                price = float.Parse(TxtPrice.Text),
                number_of_passengers = int.Parse(TxtNumPas.Text),
                route_start = TxtRouteStart.Text,
                route_end = TxtRouteEnd.Text,
                id_transport = int.Parse(CmbTransport.SelectedValue.ToString())
            };
            UrbanTransportEntities.GetContext().Routes.Add(routes);
            UrbanTransportEntities.GetContext().SaveChanges();
            MessageBoxResult boxResult = MessageBox.Show("Данные добавлены. Добавить ещё?", "Сообщение", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                TxtNumCars.Clear();
                TxtPrice.Clear();
                TxtNumPas.Clear();
                TxtRouteStart.Clear();
                TxtRouteEnd.Clear();
            }
            else
                BD.ClassFrame.frmObj.Navigate(new Pages.PageRoutes());
        }
    }
}
