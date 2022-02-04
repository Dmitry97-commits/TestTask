using Aquality.Selenium.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Utils;

namespace Task.Data
{
    public class ConfigsData
    {
        private static ISettingsFile GetSettings = GetResourcesUtils.GetResources("configs");
        public static string mainUrl = GetSettings.GetValue<string>("mainUrl");
        public static string nameOfFile = GetSettings.GetValue<string>("nameOfFile");
    }
}
