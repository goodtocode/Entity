//using GoodToCode.Framework.Worker;
//using System;

//namespace GoodToCode.Framework.Flow
//{
//    /// <summary>
//    /// Interop for routes, data in and result of a Flow
//    /// </summary> 
//    public interface IFlowInteropManager<TDataIn>
//    {
//        /// <summary>
//        /// Root Url to services that accept these requests
//        /// </summary>
//        string RootUrl { get; set;  }

//        /// <summary>
//        /// Route to out-of-domain DMZ (external) app services
//        /// </summary>
//        IFlowRoute WebServicesRoute { get; }

//        /// <summary>
//        /// Route to in-domain mid services
//        /// </summary>
//        IFlowRoute MidServicesRoute { get; }

//        /// <summary>
//        /// Parameter in, encapsulates Context and DataIn
//        /// </summary>
//        IWorkerParameter<TDataIn> Parameter { get; set; }
//    }
//}
