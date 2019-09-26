////***************************************************************************
////*   EventLocationTimeChange
////*   -------------------
////*   Copyright (c) vGo, Inc. All rights reserved.
////*
////*   All rights are reserved. Reproduction or transmission in whole or in part, in
////*   any form or by any means, electronic, mechanical or otherwise, is prohibited
////*   without the prior written consent of the copyright owner.
////* 
////***************************************************************************
//#region using
//using System;
//using Vgo.Extensions;
//using Vgo.Framework.Common;
//using Vgo.Framework.DataAccess;
//using Vgo.Extras.Collections;
//using Vgo.Framework.Validation;
//#endregion

//namespace GoodToCode.Entity.Event
//{
//    /// <summary>
//    /// Workflow to change event location and time
//    /// </summary>
//    /// <remarks></remarks>
//    [CLSCompliant(true)]
//    public class EventLocationTimeChange : WorkflowBase<EventLocationTimeChangeManager, EventLocationTimeChange, IEventLocationTime>
//    {
//        #region Properties
//        /// <summary>
//        /// Unique id of this workflow
//        /// </summary>
//        public override Guid WorkflowID { get { return new Guid("8083FF2D-1FBE-4B66-B64D-D4B1E1188AD2"); } }
//        #endregion

//        #region BusinessRules() and Process()
//        /// <summary>
//        /// BR for this workflow
//        /// </summary>
//        /// <param name="ItemToProcess"></param>
//        /// <returns></returns>
//        /// <remarks></remarks>
//        protected override void BusinessRules()
//        {
//            // Validate
//            if (this.Manager.Parameter.DataIn.BeginDate.Ticks > this.Manager.Parameter.DataIn.EndDate.Ticks)
//            {
//                this.Manager.Result.FailedRules.Add(new ValidationResult("End time must be later than begin time."));
//            }
//        }

//        /// <summary>
//        /// Does the work of this workflow
//        /// </summary>
//        /// <returns></returns>
//        /// <remarks></remarks>
//        protected override void Process()
//        {
//            // Initialize
//            EventInfo NewItem = EventInfo.GetByID(this.Manager.Parameter.DataIn.ID);

//            NewItem.FillByInterface(this.Manager.Parameter.DataIn);
//            NewItem.Save(this);
//        }
//        #endregion
//    }
//}