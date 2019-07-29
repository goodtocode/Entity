////-----------------------------------------------------------------------
//// <copyright file="PersonInfoChangeWorkflow.cs" company="GoodToCode">
////      Copyright (c) GoodToCode. All rights reserved.
////      All rights are reserved. Reproduction or transmission in whole or in part, in
////      any form or by any means, electronic, mechanical or otherwise, is prohibited
////      without the prior written consent of the copyright owner.
//// </copyright>
////-----------------------------------------------------------------------
//using System;
//using GoodToCode.Extensions;
//using GoodToCode.Entity.Common;
//
//using GoodToCode.Framework.Validation;

//namespace GoodToCode.Entity.Person
//{
//    /// <summary>
//    /// Workflow to Create new Person
//    /// </summary>
//    [CLSCompliant(true)]
//    public class PersonUpdateWorkflow : Workflow<PersonManager, PersonUpdateWorkflow, IPerson, PersonInfo>
//    {
//        /// <summary>
//        /// Unique id of this workflow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("29EE0791-A757-40B8-A918-3B81C07AC880"); } }
        
//        /// <summary>
//        /// BR for this workflow
//        /// </summary>
//        protected override void DoValidate()
//        {
//            if (this.DataIn.FirstName == Defaults.String)
//            {
//                Result.FailedRules.Add(new ValidationResult("First Name is required."));
//            }
//            if (this.DataIn.LastName == Defaults.String)
//            {
//                Result.FailedRules.Add(new ValidationResult("Last Name is required."));
//            }
//        }

//        /// <summary>
//        /// Does the work of this workflow
//        /// </summary>
//        protected override void DoExecute()
//        {
//            int returnValue= Defaults.Integer;
//            var newItem = PersonInfo.GetByKey(this.Context.EntityKey);

//            newItem.Fill(this.DataIn);
//            newItem.Save(this.Activity);
//        }
//    }
//}