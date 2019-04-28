using System;
using System.Linq;
using MonoDevelop.Projects;

namespace ImageGenerator.VS4Mac.Utils
{
    public static class SolutionExtensions
    {
        public static bool ContainsAnyAndroidProject(this Solution solution)
        {
            return solution.GetAllProjects().Any(p=>p.IsAndroidProject());
        }

        public static bool ContainsAnyIOSProject(this Solution solution)
        {
            return solution.GetAllProjects().Any(p => p.IsIOSProject());
        }
    }
}
