using Aquality.Selenium.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Utils;

namespace Task.Data
{
    public class TestData
    {
        private static ISettingsFile GetSettings = GetResourcesUtils.GetResources("testData");
        public static string formatEmail = GetSettings.GetValue<string>("formatEmail");
        public static string dayOfBD = GetSettings.GetValue<string>("dayOfBD");
        public static string monthOfBD = GetSettings.GetValue<string>("monthOfBD");
        public static string yearOfBD = GetSettings.GetValue<string>("yearOfBD");
    }
}
