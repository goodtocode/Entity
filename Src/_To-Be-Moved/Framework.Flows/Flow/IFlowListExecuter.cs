//using GoodToCode.Framework.Worker;
//using GoodToCode.Framework.Session;
//using GoodToCode.Entity.Activity;
//using System.Collections.Generic;

//namespace GoodToCode.Framework.Flow
//{
//    /// <summary>
//    /// Methods to create and execute a Flow
//    /// </summary>
//    public interface IFlowListExecuter<TDataInConcrete> : IList<ICrudflow<TDataInConcrete>>
//    {
//        /// <summary>
//        /// Activity record for this flow
//        /// </summary>
//        IActivityFlow Activity { get; }

//        /// <summary>
//        /// Constructs and performs the initial save of data, before processing
//        /// </summary>
//        /// <param name="context">Device, application, module and user info</param>
//        /// <param name="inputData">Data to process</param>
//        void Create(ISessionContext context, TDataInConcrete inputData);

//        /// <summary>
//        /// Executes the Flow
//        /// </summary>
//        /// <returns></returns>
//        List<WorkerResult> Execute();

//        /// <summary>
//        /// Results of the workflow
//        /// </summary>
//        List<WorkerResult> Results { get; }
//    }
//}
