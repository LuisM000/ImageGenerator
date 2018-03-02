using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
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
using ImageGenerator.Core.Model;
using ImageGenerator.Core.Services;
using ImageGenerator.Core.Utils;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace ImageGenerator.UI.Desktop
{
    public partial class MainWindow : Window
    {
        readonly ImageOrchestrator imageOrchestrator =
            new ImageOrchestrator(new FolderGenerator(), new ImageService());

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (openFileDialog.ShowDialog() == true)
            {
                ListBoxFiles.Items.Clear();
                foreach (var filename in openFileDialog.FileNames)
                    ListBoxFiles.Items.Add(filename);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var imageProperties in this.CreateImageProperties())
                {
                    imageOrchestrator.Generate(imageProperties);
                }
                Process.Start(this.TextBoxOutput.Text);
                this.ListBoxFiles.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ups..algo ha ocurrido. {ex.Message}");
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result==System.Windows.Forms.DialogResult.OK)
                {
                    this.TextBoxOutput.Text = dialog.SelectedPath;
                }
            }
        }


        private IEnumerable<ImageProperties> CreateImageProperties()
        {
            var imagesProperties = new List<ImageProperties>();
            foreach (string path in ListBoxFiles.Items)
            {
                imagesProperties.Add(new ImageProperties()
                {
                    FileName = Path.GetFileNameWithoutExtension(path),
                    Image = File.ReadAllBytes(path),
                    ImageOutputProperties = ImageOutputPropertiesFactory.CreateForXamarin(
                                    Path.GetExtension(path), this.TextBoxOutput.Text)

                });
            }
            return imagesProperties;
        }

       
    }
}
