////-----------------------------------------------------------------------
//// <copyright file="PersonCreateWorkflow.cs" company="Genesys Source">
////      Copyright (c) Genesys Source. All rights reserved.
////      All rights are reserved. Reproduction or transmission in whole or in part, in
////      any form or by any means, electronic, mechanical or otherwise, is prohibited
////      without the prior written consent of the copyright owner.
////  </copyright>
////-----------------------------------------------------------------------
//using System;
//using Genesys.Entity.Common;
//

//namespace Genesys.Entity.Person
//{
//    /// <summary>
//    /// Workflow to Create new Person
//    /// </summary>
//    [CLSCompliant(true), FlowBehavior(FlowBehaviors.GeneratesEntity)]
//    public class PersonCreateWorkflow : Workflow<PersonManager, PersonCreateWorkflow, IPerson, PersonInfo>
//    {
//        /// <summary>
//        /// Unique id of this workflow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("3C0217D8-33C1-4623-9D9E-1F615E936AAE"); } }
        
//        /// <summary>
//        /// BR for this workflow
//        /// </summary>
//        protected override void DoValidate()
//        {
//        }

//        /// <summary>
//        /// Does the work of this workflow
//        /// </summary>
//        protected override void DoExecute()
//        {
//            var newItem = new PersonInfo();
//            newItem = PersonInfo.Create(this.DataIn.FirstName, this.DataIn.MiddleName, this.DataIn.LastName, this.DataIn.BirthDate);            
//            OnEntityIDChanged(newItem.Key);
//            ReturnData(newItem);
//        }
//    }
//}