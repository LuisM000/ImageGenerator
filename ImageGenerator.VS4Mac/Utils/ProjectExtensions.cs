using System;
using MonoDevelop.Projects;

namespace ImageGenerator.VS4Mac.Utils
{
    public static class ProjectExtensions
    {
        public static bool IsAndroidProject(this Project project)
        {
            return project is DotNetProject dotNetProject && dotNetProject.TargetFramework.Name.Contains("Xamarin.Android");
        }

        public static bool IsIOSProject(this Project project)
        {
            return project is DotNetProject dotNetProject && dotNetProject.TargetFramework.Name.Contains("Xamarin.iOS");
        }

    }
}
