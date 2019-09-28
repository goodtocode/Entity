
using System;
using GoodToCode.Extensions.Configuration;

namespace GoodToCode.Entity.Common
{
    /// <summary>
    /// Global info for all test methods
    /// </summary>
    /// <remarks></remarks>
    public class MyApplication
    {        
        public static String MyWebService { get { return new ConfigurationManagerCore(ApplicationTypes.Native).AppSettingValue("MyWebService"); } }
        
    }
}
