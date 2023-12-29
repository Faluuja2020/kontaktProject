using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Kontakt
{
    public partial class MainWindow : Window
    {
        private List<string> objectList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddObject(string obj)
        {
            objectList.Add(obj);
            RefreshListBox();
        }

        private void RemoveSelected()
        {
            if (objectListBox.SelectedIndex != -1)
            {
                objectList.RemoveAt(objectListBox.SelectedIndex);
                RefreshListBox();
            }
        }

        private void RefreshListBox()
        {
            objectListBox.ItemsSource = null;
            objectListBox.ItemsSource = objectList;
        }

        private void SaveToCsv(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();
            foreach (var obj in objectList)
            {
                csvContent.AppendLine(obj);
            }

            File.WriteAllText(filePath, csvContent.ToString());
        }

        private void LoadFromCsv(string filePath)
        {
            if (File.Exists(filePath))
            {
                objectList.Clear();
                var lines = File.ReadAllLines(filePath);
                objectList.AddRange(lines);
                RefreshListBox();
            }
        }

        private void OnAddObjectClicked(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow(this); 
            addItemWindow.ShowDialog();
        }

        private void OnRemoveSelectedClicked(object sender, RoutedEventArgs e)
        {
            RemoveSelected();
        }

        private void OnSaveToCsvClicked(object sender, RoutedEventArgs e)
        {
            var saveDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (saveDialog.ShowDialog() == true)
            {
                string filePath = saveDialog.FileName;
                SaveToCsv(filePath);
                MessageBox.Show($"Data har sparats till {filePath}.");
            }
        }

        private void OnLoadFromCsvClicked(object sender, RoutedEventArgs e)
        {
            var openDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (openDialog.ShowDialog() == true)
            {
                string filePath = openDialog.FileName;
                LoadFromCsv(filePath);
                MessageBox.Show($"Data har laddats från {filePath}.");
            }
        }
    }
}
