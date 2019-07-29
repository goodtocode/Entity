//-----------------------------------------------------------------------
// <copyright file="MyApplication.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
// 
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using GoodToCode.Extras.Configuration;

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
