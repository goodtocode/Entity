//using GoodToCode.Extensions;
//using GoodToCode.Framework.Session;
//using GoodToCode.Entity.Common;
//

//namespace GoodToCode.Entity.Flow
//{
//    /// <summary>
//    /// Create new sessionflow. This record is required to call any other workflow.
//    /// </summary>

//    [CLSCompliant(true), FlowBehavior(FlowBehaviors.Anonymous)]
//    public class SessionflowCreateWorkflow : Workflow<SessionflowCreateManager, SessionflowCreateWorkflow, ISessionContext, SessionContext>
//    {
//        /// <summary>
//        /// Unique id of this workflow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("71C39399-6976-4620-9F24-CFC7FFA64B45"); } }

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
//            ActivitySessionflow newItem = new ActivitySessionflow();

//            newItem.Fill(this.Context);
//            newItem.Save(this.Activity);
//            ReturnData(newItem);
//        }
//    }
//}