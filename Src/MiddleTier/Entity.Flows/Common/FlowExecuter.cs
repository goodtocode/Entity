////-----------------------------------------------------------------------
//// <copyright file="FlowExecuter.cs" company="GoodToCode">
////      Copyright (c) GoodToCode. All rights reserved.
////      All rights are reserved. Reproduction or transmission in whole or in part, in
////      any form or by any means, electronic, mechanical or otherwise, is prohibited
////      without the prior written consent of the copyright owner.
//// </copyright>
////-----------------------------------------------------------------------
//using System;
//using System.Linq;
//using System.Net.Http;
//using GoodToCode.Extensions;
//using GoodToCode.Extras.Collections;
//using GoodToCode.Framework.Worker;
//
//using GoodToCode.Entity.Flow;
//using GoodToCode.Entity.Activity;
//using GoodToCode.Framework.Session;
//using GoodToCode.Framework.Entity;
//using GoodToCode.Framework.Activity;

//namespace GoodToCode.Entity.Common
//{
//    /// <summary>
//    /// Base class required for all workflows
//    /// </summary>
//    [CLSCompliant(true)]
//    public abstract class FlowExecuter<TManager, TFlowClass, TDataInInterface, TDataInConcrete> : IFlowExecuter<TDataInConcrete>
//        where TFlowClass : FlowExecuter<TManager, TFlowClass, TDataInInterface, TDataInConcrete>, new()
//        where TManager : FlowInteropManager<TDataInInterface>, new()
//        where TDataInConcrete : class, TDataInInterface, new()
//    {
//        private FlowModes modeValue = FlowModes.ValidationAndSave;
//        private FlowModes previousModeValue = FlowModes.ValidationAndSave;

//        /// <summary>
//        ///ActivityFlow key for data returned from this workflow
//        /// </summary>
//        public const string ReturnDataKey = "ReturnData";

//        /// <summary>
//        /// Unique ID of the workflow
//        /// </summary>
//        public abstract Guid FlowKey { get; set; }

//        /// <summary>
//        /// If IsValid() == false, throw exception if this property set to true
//        /// </summary>
//        public bool ThrowException { get; set; } = Defaults.Boolean;

//        /// <summary>
//        /// User, device and app context
//        /// </summary>
//        public ISessionContext Context { get; protected set; } = new SessionContext();

//        /// <summary>
//        /// Data to be processed
//        /// </summary>
//        public TDataInConcrete DataIn { get; set; } = new TDataInConcrete();

//        /// <summary>
//        /// Results of the workflow
//        /// </summary>
//        public WorkerResult Result { get; set; } = new WorkerResult();

//        /// <summary>
//        /// This Flow activity
//        /// </summary>
//        public abstract IActivityFlow Activity { get; protected set; }

//        /// <summary>
//        /// Last flow mode: (ValidateAndSave, ValidateOnly, SaveOnly)
//        /// </summary>
//        public FlowModes LastMode { get { return previousModeValue; } }
        
//        /// <summary>
//        /// Flow Mode: (ValidateAndSave, ValidateOnly, SaveOnly)
//        /// </summary>
//        public FlowModes Mode { get { return modeValue; } set { previousModeValue = modeValue; modeValue = value; } }

//        /// <summary>
//        /// The Http method verb that called this flow (get, post, put or delete for CRUD operations)
//        /// </summary>
//        public HttpMethod Method { get; set; } = HttpMethod.Post;

//        /// <summary>
//        /// FlowBehavior flags assigned to this flow
//        /// </summary>
//        /// <returns>All flow behavior flags assigned to this flow</returns>
//        internal FlowBehaviors Behavior
//        {
//            get
//            {
//                FlowBehaviors returnValue = FlowBehaviors.Default;

//                foreach (var Item in typeof(TFlowClass).GetCustomAttributes(false))
//                {
//                    if ((Item is FlowBehavior) == true)
//                    {
//                        returnValue = ((FlowBehavior)Item).Value;
//                        break;
//                    }
//                }

//                return returnValue;
//            }
//        }

//        /// <summary>
//        /// Encourage use of Create() method over constructors for this class.
//        /// </summary>
//        protected FlowExecuter() : base()
//        {
//#if (DEBUG)
//            ThrowException = true;
//#endif
//        }

//        /// <summary>
//        /// Constructs and validates construction data
//        /// </summary>
//        /// <param name="context">Context of user, module, ActivitySessionflowID...everything needed to know critical data about caller</param>
//        /// <param name="dataIn">Data to process by the workflow</param>
//        public static TFlowClass Construct(ISessionContext context, TDataInInterface dataIn)
//        {
//            TFlowClass returnValue = new TFlowClass();
//            returnValue.DataIn.Fill(dataIn);
//            returnValue.Context.Fill(context);
//            returnValue.Activity.Fill(context);
//            returnValue.Activity.FlowKey = returnValue.FlowKey;
//            returnValue.IsFlowDataComplete();
//            return returnValue;
//        }

//        /// <summary>
//        /// For non-token based operations:
//        /// Initializes the object, validates that construction has required x.
//        ///     Equivalent to static Construct.
//        /// </summary>
//        public virtual void Create(ISessionContext context, TDataInConcrete dataIn)
//        {
//            this.Fill(FlowExecuter<TManager, TFlowClass, TDataInInterface, TDataInConcrete>.Construct(context, dataIn));
//            if (this.Mode != FlowModes.ValidationOnly) { Activity.Save(); }
//        }

//        /// <summary>
//        /// Does the workflow-specific work.
//        /// </summary>
//        /// <returns></returns>s
//        protected abstract void DoExecute();

//        /// <summary>
//        /// Does the basic steps of a workflow. The Process() function does the workflow-specific work.
//        /// </summary>
//        /// <returns>Results of the process, including created/updated key and data</returns>
//        public virtual WorkerResult Execute()
//        {
//            OnFlowBegin();
//            if (this.Activity.CanExecute() == false)
//            {
//                Result.OnFail("This process has already ran, and cant be executed twice.");
//                OnFlowAlreadyDone();
//            } else
//            {
//                try
//                {
//                    Activity.Save();
//                    Result.OnStart();
//                    IsFlowDataComplete();
//                    DoExecute();
//                    Activity.FlowStepKey = FlowInfo.Steps.Completed;
//                    Result.OnSuccess();
//                }
//                catch (System.Exception ex)
//                {
//                    Activity.FlowStepKey = FlowInfo.Steps.FailedUnexpected;
//                    Result.OnFail("An unexpected error occurred.");
//                    ExceptionLogger.Create(ex, typeof(TFlowClass), String.Format("FlowExecuter.Execute(). ItemToProcess: {0} {1}", this.GetType().FullName, this.ToString()));
//#if DEBUG
//                    System.Diagnostics.Debugger.Break();
//#endif
//                }
//                finally
//                {
//                    Activity.Save();
//                }
//            }
//            if (this.Result.FailedRules.Count == 0)
//            {
//                OnFlowComplete();
//            } else
//            {
//                OnFlowFailed();
//            }

//            return Result;
//        }

//        /// <summary>
//        /// Validates underlying data. If not valid, database will throw foreign key exception.
//        /// </summary>
//        /// <returns>True if FlowKey, ApplicationKey, EntityKey and Context.Name (username) have valid values.</returns>
//        public virtual bool IsFlowDataComplete()
//        {
//            bool IsDataIncomplete = Defaults.Boolean;
//            bool IsDataCorrupt = Defaults.Boolean;

//            if (this.Behavior.Contains(FlowBehaviors.NoTracking) == false)
//            {
//                // Check for valid IDs/Keys
//                if (!(this.IsFlowValid() && this.IsApplicationValid()))
//                {
//                    IsDataCorrupt = true;
//                    if (this.ThrowException == true) { throw new System.DataMisalignedException("Required ID are missing or corrupt: ApplicationKey and FlowKey must contain valid values."); }
//                }
//                // Check user data
//                if (!(this.IsUserContextValid() && this.IsEntityValid()))
//                {
//                    IsDataIncomplete = true;
//                    if (this.ThrowException == true) { throw new System.ArgumentOutOfRangeException("Required properties are missing data: EntityKey and Name must all contain valid values."); }
//                }
//            }

//            return !(IsDataCorrupt & IsDataIncomplete);
//        }

//        /// <summary>
//        /// Is this ID valid
//        /// </summary>
//        /// <returns>True for ID data valid</returns>
//        public bool IsApplicationValid()
//        {
//            bool returnValue = Defaults.Boolean;

//            // here on purpose to throw warning, to fix the lack of ApplicationKey in context. 
//            // Need to redo context to gel well with bearer token designs & Foundation owning common objects.
//            return true; 
//            return returnValue;
//        }

//        /// <summary>
//        /// Is this ID valid
//        /// </summary>
//        /// <returns>True for ID data valid</returns>
//        public virtual bool IsFlowValid()
//        {
//            bool returnValue = Defaults.Boolean;

//            if ((this.FlowKey != Defaults.Guid) && (this.FlowKey == this.Activity.FlowKey))
//            {
//                returnValue = true;
//            }

//            return returnValue;
//        }

//        /// <summary>
//        /// Is this Entity valid? Context.EntityKey must contain a valid key
//        /// </summary>
//        /// <returns>True for ID data valid</returns>
//        public virtual bool IsEntityValid()
//        {
//            bool returnValue = Defaults.Boolean;

//            if (this.Context.EntityKey != Defaults.Guid
//                || this.Behavior.Contains(FlowBehaviors.GeneratesEntity) == true
//                || this.Behavior.Contains(FlowBehaviors.Anonymous) == true)
//            {
//                returnValue = true;
//            }

//            return returnValue;
//        }

//        /// <summary>
//        /// Is this user valid. Context.Name must have a value, or the flow is an Anonymous flow
//        /// </summary>
//        /// <returns>True for ID data valid</returns>
//        public virtual bool IsUserContextValid()
//        {
//            bool returnValue = Defaults.Boolean;

//            if (this.Context.IdentityUserName != Defaults.String)
//            {
//                returnValue = true;
//            }

//            return returnValue;
//        }

//        /// <summary>
//        /// Sets EntityID for workflows that create new Entitys
//        /// </summary>
//        /// <param name="EntityKey"></param>        
//        private void EntityIDSet(Guid EntityKey)
//        {
//            Context.EntityKey = EntityKey;
//            Activity.EntityKey = EntityKey;
//            Activity.Save();
//        }

//        /// <summary>
//        /// Returns ID and Key and serialized data to caller
//        /// </summary>
//        /// <param name="entity">Entity containing ID (for internal use) and Key (for external use)</param>
//        /// <param name="serializedData">Serialized data to be returned via database (not returned directly)</param>
//        public void ReturnData(IEntity entity, string serializedData)
//        {
//            ReturnData(entity);
//            ReturnData(serializedData);
//        }

//        /// <summary>
//        /// Returns ID and Key to caller, no serialized data
//        /// </summary>
//        /// <param name="entityWithIDAndKey">Entity containing ID (for internal use) and Key (for external use)</param>
//        public void ReturnData(IEntity entityWithIDAndKey)
//        {
//            Result.ReturnID = entityWithIDAndKey.ID;
//            Result.ReturnKey = entityWithIDAndKey.Key;
//        }

//        /// <summary>
//        /// Returns serialized data, but not ID and Key
//        /// </summary>
//        /// <param name="serializedData">Serialized data to be returned via database (not returned directly)</param>
//        public void ReturnData(string serializedData)
//        {
//            Result.ReturnData = serializedData;
//        }

//        /// <summary>
//        /// Event handler
//        /// </summary>
//        public event FlowBeginEventHandler FlowBegin;

//        /// <summary>
//        /// Event method
//        /// </summary>
//        protected virtual void OnFlowBegin()
//        { if (this.FlowBegin != null) { FlowBegin(this, EventArgs.Empty); } }

//        /// <summary>
//        /// Event handler
//        /// </summary>
//        public event FlowAlreadyDoneEventHandler FlowAlreadyDone;

//        /// <summary>
//        /// Event method
//        /// </summary>
//        protected virtual void OnFlowAlreadyDone()
//        { if (this.FlowAlreadyDone != null) { FlowAlreadyDone(this, new FlowAlreadyDoneEventArgs() { BlockingActivityFlowID = Defaults.Integer }); } }

//        /// <summary>
//        /// Event handler
//        /// </summary>
//        public event FlowFailedEventHandler FlowFailed;

//        /// <summary>
//        /// Event method
//        /// </summary>
//        protected virtual void OnFlowFailed()
//        { if (this.FlowFailed != null) { FlowFailed(this, new FlowFailedEventArgs() { FailedRules = this.Result.FailedRules }); } }

//        /// <summary>
//        /// Event handler
//        /// </summary>
//        public event FlowCompleteEventHandler<WorkerResult> FlowComplete;

//        /// <summary>
//        /// Event method
//        /// </summary>
//        protected virtual void OnFlowComplete()
//        { if (this.FlowComplete != null) { FlowComplete(this, new FlowCompleteEventArgs<WorkerResult>() { DataOut = this.Result }); } }

//        /// <summary>
//        /// Event handler
//        /// </summary>
//        public event EntityIDChangedEventHandler EntityIDChanged;

//        /// <summary>
//        /// Event method
//        /// </summary>
//        /// <param name="EntityKey"></param>
//        protected virtual void OnEntityIDChanged(Guid EntityKey) { EntityIDSet(EntityKey); this.Result.ReturnKey = EntityKey; if ((this.EntityIDChanged != null) && (this.Context.EntityKey != EntityKey)) { EntityIDChanged(this, new EntityIDChangedEventArgs() { EntityKey = EntityKey }); } }

//        /// <summary>
//        /// Flow beginning. No custom to return.
//        /// </summary>
//        /// <param name="sender">Sender of event</param>
//        /// <param name="e">Arguments passed to the event handler</param>
//        public delegate void FlowBeginEventHandler(object sender, EventArgs e);

//        /// <summary>
//        /// Flow completed, with processed x.
//        /// </summary>
//        /// <param name="sender">Sender of event</param>
//        /// <param name="e">ReturnedID - Processed x. DataOutType - Type of data returned</param>
//        public delegate void FlowCompleteEventHandler<DataOutType>(object sender, FlowCompleteEventArgs<DataOutType> e);

//        /// <summary>
//        /// Flow completed, with processed x.
//        /// </summary>
//        /// <typeparam name="TDataOut"></typeparam>
//        public class FlowCompleteEventArgs<TDataOut> : EventArgs
//        {
//            /// <summary>
//            /// Data to be returned
//            /// </summary>
//            public TDataOut DataOut { get; set; }
//        }

//        /// <summary>
//        /// Flow Failed, with FailedRulesList
//        /// </summary>
//        /// <param name="sender">Sender of event</param>
//        /// <param name="e">FailedRulesList</param>
//        public delegate void FlowFailedEventHandler(object sender, FlowFailedEventArgs e);

//        /// <summary>
//        /// Flow Failed, with FailedRulesList
//        /// </summary>
//        public class FlowFailedEventArgs : EventArgs
//        {
//            /// <summary>
//            /// List of failed rules
//            /// </summary>
//            public KeyValueListString FailedRules { get; set; } = new KeyValueListString();
//        }

//        /// <summary>
//        /// Flow Already Completed, and unable to run twice. 
//        /// Returns ActivityWorkflowID that is blocking the execution of this workflow.
//        /// </summary>
//        /// <param name="sender">Sender of event</param>
//        /// <param name="e">ActivityWorkflowID that is blocking the execution of this workflow.</param>
//        public delegate void FlowAlreadyDoneEventHandler(object sender, FlowAlreadyDoneEventArgs e);

//        /// <summary>
//        /// Flow Already Completed, and unable to run twice. 
//        /// Returns ActivityWorkflowID that is blocking the execution of this workflow.
//        /// </summary>
//        public class FlowAlreadyDoneEventArgs : EventArgs
//        {
//            /// <summary>
//            /// Previously executed ActivityWorkflowID that is blocking this transaction from starting.
//            /// </summary>
//            public int BlockingActivityFlowID = Defaults.Integer;
//        }

//        /// <summary>
//        /// Flow generated or retrieved a EntityID
//        /// </summary>
//        /// <param name="sender">Sender of event</param>
//        /// <param name="e">Arguments passed to the event handler</param>
//        public delegate void EntityIDChangedEventHandler(object sender, EntityIDChangedEventArgs e);

//        /// <summary>
//        /// Flow generated or retrieved a EntityID
//        /// </summary>
//        public class EntityIDChangedEventArgs : EventArgs, IEntityKey
//        {
//            /// <summary>
//            /// Primary key of entity record
//            /// </summary>
//            public Guid EntityKey { get; set; }
//        }
//    }
//}
