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
