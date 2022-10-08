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

namespace WPFConsumeService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            service.ConsumerAPI consumer = service.ConsumerAPI.getObject();

            var getter = consumer.getAllCustomer();

            if (getter == null)
            {

                errorNotice.Text = "Error API, Cannot consume the API";

            }
            else {
                lbxCustomer.Items.Clear();
                foreach (string i in getter)
                {
                    lbxCustomer.Items.Add(i);
                }
            }

        
        }





    }
}
