using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Task.Utils
{
    public static class GetResourcesUtils
    {
        public static ISettingsFile GetResources(string typeofdata) => new JsonSettingsFile
            (embededResourceName: $"Resources.settings.{typeofdata}.json", Assembly.GetCallingAssembly());
    }
}
