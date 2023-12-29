using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kontakt
{
   
    public partial class AddItemWindow : Window
    {
        private MainWindow mainWnd;

        public AddItemWindow(MainWindow mainWnd)
        {
            InitializeComponent();
            this.mainWnd = mainWnd;
        }

        private void OnAddClicked(object sender, RoutedEventArgs e)
        {
            

            string name = txtName.Text;
            string age = txtAge.Text;
            string email = txtEmail.Text;

            mainWnd.AddObject($"{name}, {age}, {email}");   

            this.Close();
        }



        private void OnCancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

