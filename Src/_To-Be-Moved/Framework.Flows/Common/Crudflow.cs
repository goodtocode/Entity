//using GoodToCode.Extensions;
//using GoodToCode.Extensions.Collections;
//using GoodToCode.Framework.Entity;
//using GoodToCode.Framework.Worker;
//using GoodToCode.Framework.Session;
//using GoodToCode.Entity.Activity;

//using GoodToCode.Framework.Flow;
//using System;
//using System.Linq;

//namespace GoodToCode.Entity.Common
//{
//    /// <summary>
//    /// Base class required for all workflows
//    /// </summary>
//    [CLSCompliant(true)]
//    public abstract class Crudflow<TFlowClass, TCrudEntity> : ICrudflow<TCrudEntity>
//        where TFlowClass : Crudflow<TFlowClass, TCrudEntity>, new()
//        where TCrudEntity : CrudEntity<TCrudEntity>, new()
//    {
//        private FlowModes modeValue = FlowModes.ValidationAndSave;
//        private FlowModes previousModeValue = FlowModes.ValidationAndSave;

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
//        public TCrudEntity Entity { get; set; } = new TCrudEntity();

//        /// <summary>
//        /// Workflow Activity record associated with executing this workflow via Execute()
//        /// </summary>
//        public IActivityFlow Activity { get; protected set; } = new ActivityWorkflow();

//        /// <summary>
//        /// Results of the workflow
//        /// </summary>
//        public WorkerResult Result { get; set; } = new WorkerResult();

//        /// <summary>
//        /// Flow Mode: (ValidateAndSave, ValidateOnly, SaveOnly)
//        /// </summary>
//        public FlowModes Mode { get { return modeValue; } set { previousModeValue = modeValue; modeValue = value; } }

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
//        protected Crudflow() : base()
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
//        public static TFlowClass Construct(ISessionContext context, TCrudEntity dataIn)
//        {
//            var returnValue = new TFlowClass();
//            returnValue.Entity.Fill(dataIn);
//            returnValue.Context.Fill(context);
//            returnValue.Activity.Fill(context);
//            returnValue.Activity.FlowKey = returnValue.FlowKey;
//            returnValue.IsFlowDataComplete();
//            return returnValue;
//        }

//        /// <summary>
//        /// Executes the Create flow
//        /// </summary>
//        /// <returns>Saved object</returns>
//        public TCrudEntity Create()
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// Executes the Create flow
//        /// </summary>
//        /// <returns>Saved object</returns>
//        public TCrudEntity Read(Predicate<TCrudEntity> predicate)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// Executes the Create flow
//        /// </summary>
//        /// <returns>Saved object</returns>
//        public TCrudEntity Update()
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// Executes the Create flow
//        /// </summary>
//        /// <returns>Saved object</returns>
//        public TCrudEntity Delete()
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// Does the basic steps of a flow. The Process() function does the workflow-specific work.
//        /// </summary>
//        /// <returns></returns>
//        private WorkerResult Execute()
//        {
//            var returnValue = new WorkerResult();

//            //            OnFlowBegin();
//            //            try
//            //            {
//            //                Result.OnStart();
//            //                if (this.Mode != FlowModes.ValidationOnly && this.Behavior.Contains(FlowBehaviors.NoTracking) == false)
//            //                {
//            //                    Activity.Save();
//            //                }
//            //                IsFlowDataComplete();
//            //                DoValidate();
//            //                if (this.Result.FailedRules.Count == 0)
//            //                {
//            //                    if (this.Mode != FlowModes.ValidationOnly)
//            //                    {
//            //                        DoSave();
//            //                    }
//            //                    Activity.FlowStepKey = FlowInfo.Steps.Completed;
//            //                    Result.OnSuccess();
//            //                }
//            //            }
//            //            catch (System.Exception ex)
//            //            {
//            //                Activity.FlowStepKey = FlowInfo.Steps.FailedUnexpected;
//            //                Result.OnFail("An unexpected error occurred.");
//            //                ExceptionLogger.Create(ex, typeof(TFlowClass),
//            //                    String.Format("Workflow.Execute(). ItemToProcess: {0} {1}", this.GetType().FullName, this.ToString()), "DefaultConnection", "MiddleTier");
//            //#if DEBUG
//            //                System.Diagnostics.Debugger.Break();
//            //#endif
//            //            }
//            //            finally
//            //            {
//            //                if (this.Mode != FlowModes.ValidationOnly && this.Behavior.Contains(FlowBehaviors.NoTracking) == false)
//            //                {
//            //                    Activity.Save();
//            //                }
//            //            }
//            //            if (this.Result.FailedRules.Count == 0)
//            //            {
//            //                OnFlowComplete();
//            //            } else
//            //            {
//            //                OnFlowFailed();
//            //            }

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
