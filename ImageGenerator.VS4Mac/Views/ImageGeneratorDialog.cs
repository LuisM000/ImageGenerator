using System;
using System.IO;
using System.Threading.Tasks;
using ImageGenerator.Contracts;
using ImageGenerator.Services;
using ImageGenerator.Services.Utils;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using Xwt;

namespace ImageGenerator.VS4Mac.Views
{
    public class ImageGeneratorDialog : Dialog
    {
        readonly IImageOrchestrator imageOrchestrator = new ImageOrchestrator(new Services.FolderGenerator(), new Services.ImageService());

        VBox _mainBox;
        Label _imagesLabel;
        HBox _imagesBox;
        Button _imagesSelectorButton;        
        ListBox _imagesListBox;
        Label _outputFolderLabel;
        HBox _outputFolderBox;
        Button _outputFolderButton;
        TextEntry _outputFolderEntry;
        HBox _buttonBox;
        Button _generateButton;


        OpenFileDialog fileDialog;
        SelectFolderDialog folderDialog;


        public ImageGeneratorDialog()
        {
            Init();
            BuildGui();
            AttachEvents();
        }

        void Init()
        {
            Title = "Image Generator";


            _mainBox = new VBox
            {
                HeightRequest = 270,
                WidthRequest = 500
            };

            _imagesLabel = new Label("Select images:");
            _imagesBox = new HBox();
            _imagesListBox = new ListBox
            {
                WidthRequest = 460,
                HeightRequest = 120
            };
            _imagesSelectorButton = new Button("...")
            {
                ExpandVertical = false,
                VerticalPlacement = WidgetPlacement.Start
            };

            _outputFolderLabel = new Label("Select output folder:");

            _outputFolderBox = new HBox();
            _outputFolderEntry = new TextEntry
            {
                WidthRequest = 460,
                Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            _outputFolderButton = new Button("...");

            _buttonBox = new HBox();
            _generateButton = new Button("Generate")
            {
                BackgroundColor = Styles.BaseSelectionBackgroundColor,
                LabelColor = Styles.BaseSelectionTextColor,
                WidthRequest = 100
            };

            fileDialog = new OpenFileDialog("Select images");
            fileDialog.Multiselect = true;

            folderDialog = new SelectFolderDialog("Select output folder");
        }

        void BuildGui()
        {
            
            _buttonBox.PackEnd(_generateButton);

            _mainBox.PackStart(_imagesLabel);
            _imagesBox.PackStart(_imagesListBox, marginTop: 5);
            _imagesBox.PackEnd(_imagesSelectorButton);
            _mainBox.PackStart(_imagesBox);
            _mainBox.PackStart(_outputFolderLabel, marginTop: 15);
            _outputFolderBox.PackStart(_outputFolderEntry);
            _outputFolderBox.PackEnd(_outputFolderButton);
            _mainBox.PackStart(_outputFolderBox);
            _mainBox.PackEnd(_buttonBox);


            Content = _mainBox;
            Resizable = false;
        }

        void AttachEvents()
        {
            _generateButton.Clicked += OnGenerateClicked;
            _imagesSelectorButton.Clicked += OnFileDialogClicked;
            _outputFolderButton.Clicked += OnOutputFolderClicked;
        }

        private void OnOutputFolderClicked(object sender, EventArgs e)
        {
            if (folderDialog.Run(this))
                _outputFolderEntry.Text = folderDialog.Folder;

        }

        private void OnFileDialogClicked(object sender, EventArgs e)
        {
            if (fileDialog.Run(this))
            {
                _imagesListBox.Items.Clear();
                foreach (var fileName in fileDialog.FileNames)
                    _imagesListBox.Items.Add(fileName);
            }
        }

        void OnGenerateClicked(object sender, EventArgs args)
        {
            Task.Run(() => GenerateImages());
        }

        void Loading(bool isLoading)
        {
            _generateButton.Sensitive = !isLoading;
            _imagesSelectorButton.Sensitive = !isLoading;
            _outputFolderButton.Sensitive = !isLoading;
        }


        private void GenerateImages()
        {
            var progressMonitor = IdeApp.Workbench.ProgressMonitors.GetStatusProgressMonitor("Generating images...", Stock.StatusSolutionOperation, false, true, false);
            Loading(true);

            bool success = true;
            string outputFolder = _outputFolderEntry.Text;
            
            foreach (var path in fileDialog.FileNames)
            {
                try
                {

                    progressMonitor.Log.WriteLine($"Generating {Path.GetFileName(path)}...");

                    var outputProperties = ImageOutputPropertiesFactory.CreateForXamarin(Path.GetExtension(path), outputFolder);

                    var file = File.ReadAllBytes(path);

                    ImageProperties imageProperties = new ImageProperties()
                    {
                        FileName = Path.GetFileNameWithoutExtension(path),
                        Image = file,
                        ImageOutputProperties = outputProperties
                    };

                    imageOrchestrator.Generate(imageProperties);


                    progressMonitor.Log.WriteLine($"Generation complete. {Path.GetFileName(path)}");
                }
                catch (Exception ex)
                {
                    progressMonitor.Log.WriteLine($"An error occurred generating {Path.GetFileName(path)}: {ex.Message}");
                    success = false;
                }
            }                    

            progressMonitor.EndTask();
            Loading(false);

            if (success)
            {
                progressMonitor.ReportSuccess("Images generation successfully.");
            }
            else
            {
                progressMonitor.ReportWarning("Generation completed with errors :(");
            }
        }     

    }
}
