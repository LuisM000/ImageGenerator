using System;
using System.Linq;
using ImageGenerator.VS4Mac.Utils;
using ImageGenerator.VS4Mac.Views;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace ImageGenerator.VS4Mac.Commands
{
    public class OpenImageAssetsGeneratorCommand : CommandHandler
    {
        protected override void Run()
        {
            using (var imageAssetsGenerator = new ImageAssetsGeneratorDialog(IdeApp.ProjectOperations.CurrentSelectedSolution))
            {
                imageAssetsGenerator.Run(Xwt.MessageDialog.RootWindow);
            }
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = CurrentSolutionContainsAndroidOrIOSProject();
        }

        private bool CurrentSolutionContainsAndroidOrIOSProject()
        {
            var currentSolution = IdeApp.ProjectOperations.CurrentSelectedSolution;
            return currentSolution.ContainsAnyAndroidProject() || currentSolution.ContainsAnyIOSProject();
        }
    }
}
