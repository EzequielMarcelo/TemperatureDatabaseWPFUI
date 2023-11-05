
using System.Reflection;

namespace TemperatureDataBaseWPF.Utility
{
    public static class AssemblyUtility
    {
        public static string GetAssemblyTitle()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];

            return titleAttribute.Title;
        }
        public static string GetAssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version?.ToString()
                ?? String.Empty;
        }
    }
}
