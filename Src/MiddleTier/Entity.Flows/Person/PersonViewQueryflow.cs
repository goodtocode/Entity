////-----------------------------------------------------------------------
//// <copyright file="PersonViewQueryflow.cs" company="GoodToCode">
////      Copyright (c) GoodToCode. All rights reserved.
////      All rights are reserved. Reproduction or transmission in whole or in part, in
////      any form or by any means, electronic, mechanical or otherwise, is prohibited
////      without the prior written consent of the copyright owner.
//// </copyright>
////-----------------------------------------------------------------------
//using System;
//
//using GoodToCode.Entity.Common;

//namespace GoodToCode.Entity.Person
//{
//    /// <summary>
//    /// View Person Queryflow
//    ///// </summary>
//    [CLSCompliant(true)]
//    public class PersonViewQueryflow : Queryflow<PersonManager, PersonViewQueryflow, INameKey, NameKey>
//    {
//        /// <summary>
//        /// Unique id of this Query flow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("07079A37-0317-433D-9FDA-E29C42D123CA"); } }
        
//        /// <summary>
//        /// Does the work of this Query flow
//        /// </summary>        
//        protected override void DoExecute()
//        {
//            ReturnData(PersonInfo.GetByKey(this.DataIn.Key).Serialize());
//        }        
//    }
//}
