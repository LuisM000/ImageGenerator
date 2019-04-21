using System;
using ImageGenerator.VS4Mac.Views;
using MonoDevelop.Components.Commands;

namespace ImageGenerator.VS4Mac.Commands
{
    public class OpenGeneratorCommand : CommandHandler
    {
        protected override void Run()
        {
            using (var generateTextDialog = new ImageGeneratorDialog())
            {
                generateTextDialog.Run(Xwt.MessageDialog.RootWindow);
            }
        }

    }
}
