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
    /// Логика взаимодействия для PageAddEditTransport.xaml
    /// </summary>
    public partial class PageAddEditTransport : Page
    {
        public PageAddEditTransport()
        {
            InitializeComponent();
            UrbanTransportEntities.GetContext().Transport.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Transport transport = new Transport()
            {
                name = TxtName.Text,
                speed_km_h = int.Parse(TxtSpeed.Text)
            };
            UrbanTransportEntities.GetContext().Transport.Add(transport);
            UrbanTransportEntities.GetContext().SaveChanges();
            MessageBoxResult boxResult = MessageBox.Show("Данные добавлены. Добавить ещё?", "Сообщение", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                TxtName.Clear();
                TxtSpeed.Clear();
            }
            else
                BD.ClassFrame.frmObj.Navigate(new Pages.PageTransport());
        }
    }
}
