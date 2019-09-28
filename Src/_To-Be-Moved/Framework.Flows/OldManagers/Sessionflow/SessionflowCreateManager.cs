
//using System;
//using GoodToCode.Framework.Session;

//namespace GoodToCode.Entity.Flow
//{
//    /// <summary>
//    /// Contains the cross-tier items that must be consistent, regardless of the tier or app type
//    /// </summary>

//    public class SessionflowCreateManager : FlowInteropManager<ISessionContext>
//    {
//        /// <summary>
//        /// External Route to this workflow's endpoint for native apps and distributed systems
//        /// </summary>
//        public override IFlowRoute WebServicesRoute { get; protected set; } = new WorkfloRoute("SessionflowCreateApp", "SessionflowApp/Create");

//        /// <summary>
//        /// In-domain Route to this workflow's endpoint for WebServices, MVC apps and any other presentation tier functionality.
//        /// </summary>
//        public override IFlowRoute MidServicesRoute { get; protected set; } = new WorkfloRoute("SessionflowCreateMid", "SessionflowMid/Create");

//        /// <summary>
//        /// Constructor
//        /// </summary>
//        public SessionflowCreateManager() : base() { }

//        /// <summary>
//        /// Constructor
//        /// </summary>
//        public SessionflowCreateManager(ISessionContext context, ISessionContext dataIn) : base(context, dataIn) { }

//        /// <summary>
//        /// Constructor with hydration
//        /// </summary>
//        /// <param name="rootUrl">Root Url of the service</param>
//        /// <param name="context">User, device and app context</param>
//        /// <param name="dataIn">Data to be sent</param>
//        public SessionflowCreateManager(string rootUrl, ISessionContext context, ISessionContext dataIn) : base(rootUrl, context, dataIn) { }
//    }
//}
