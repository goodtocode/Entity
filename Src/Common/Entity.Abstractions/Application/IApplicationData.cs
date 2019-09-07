////-----------------------------------------------------------------------
//// <copyright file="IApplicationData.cs" company="GoodToCode">
////      Copyright (c) GoodToCode. All rights reserved.
////      All rights are reserved. Reproduction or transmission in whole or in part, in
////      any form or by any means, electronic, mechanical or otherwise, is prohibited
////      without the prior written consent of the copyright owner.
//// </copyright>
////-----------------------------------------------------------------------
//using System;
//using GoodToCode.Extensions.Net;
//using GoodToCode.Framework.Session;
//using GoodToCode.Extensions.Configuration;
//using GoodToCode.Entity.Device;
//using GoodToCode.Framework.Device;

//namespace GoodToCode.Entity.Application
//{
//    /// <summary>
//    /// Global class containing application metadata, storage, device and application record
//    /// Often a singleton/static object, one per application project
//    /// </summary>    
//    public interface IApplicationData : IApplicationUuid
//    {
//        /// <summary>
//        /// Displays Application table Key column
//        /// </summary>
//        new string ApplicationUuid { get; }

//        /// <summary>
//        /// Config file data from app.config, web.config, appsettings.config, connectionstrings.config
//        /// </summary>
//        ConfigurationManagerSafe Configuration { get; }

//        /// <summary>
//        /// Local dictionary storage
//        /// </summary>
//        IApplicationDataContainerFull Data { get; }

//        /// <summary>
//        /// Context
//        /// </summary>
//        SessionContext Context { get; }

//        /// <summary>
//        /// MyWebService
//        /// </summary>
//        UrlInfo MyWebService { get; }
//    }
//}