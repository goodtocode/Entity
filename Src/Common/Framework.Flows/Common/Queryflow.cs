////-----------------------------------------------------------------------
//// <copyright file="Queryflow.cs" company="GoodToCode">
////      Copyright (c) GoodToCode. All rights reserved.
////      All rights are reserved. Reproduction or transmission in whole or in part, in
////      any form or by any means, electronic, mechanical or otherwise, is prohibited
////      without the prior written consent of the copyright owner.
//// </copyright>
////-----------------------------------------------------------------------
//using System;
//using GoodToCode.Framework.Flow;

//using GoodToCode.Entity.Activity;

//namespace GoodToCode.Entity.Common
//{
//    /// <summary>
//    /// Base class required for all query flows
//    /// </summary>
//    [CLSCompliant(true)]
//    public abstract class Queryflow<TManager, IFlowClass, TDataInInterface, TDataInConcrete> : FlowExecuter<TManager, IFlowClass, TDataInInterface, TDataInConcrete>
//        where IFlowClass : Queryflow<TManager, IFlowClass, TDataInInterface, TDataInConcrete>, new()
//        where TManager : FlowInteropManager<TDataInInterface>, new()
//        where TDataInConcrete : class, TDataInInterface, new()
//    {
//        /// <summary>
//        /// Workflow Activity record associated with executing this workflow via Execute()
//        /// </summary>
//        public override IActivityFlow Activity { get; protected set; } = new ActivityQueryflow();

//        /// <summary>
//        /// Encourage use of Create() method over constructors for this class.
//        /// </summary>
//        protected Queryflow() : base()
//        {
//        }
//    }
//}
