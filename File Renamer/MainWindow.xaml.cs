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
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace File_Renamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<File> Files = new ObservableCollection<File>();
        FileRenamer FileRenamer = new FileRenamer();
        public MainWindow()
        {
            InitializeComponent();
            list1.ItemsSource = Files;
          
        }

        //Select Folder button click
        private void button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = FolderBrowserDialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath))
            {
                //MessageBox.Show(FolderBrowserDialog.SelectedPath);
                //get all files under filepath
                var items = FileRenamer.GetFiles(FolderBrowserDialog.SelectedPath);
                foreach (File item in items)
                {
                    Files.Add(item);
                }
                Files.Add(new File() { FilePath = FolderBrowserDialog.SelectedPath, FileName = "123"});
                        
            }
      
        }

        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     
    }
}
