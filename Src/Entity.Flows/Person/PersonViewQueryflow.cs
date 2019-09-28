//using System;
//
//using GoodToCode.Entity.Common;

//namespace GoodToCode.Entity.Person
//{
//    /// <summary>
//    /// View Person Queryflow
//    ///// </summary>
//    [CLSCompliant(true)]
//    public class PersonViewQueryflow : Queryflow<PersonManager, PersonViewQueryflow, INameKey, NameKey>
//    {
//        /// <summary>
//        /// Unique id of this Query flow
//        /// </summary>
//        public override Guid FlowKey { set{} get { return new Guid("07079A37-0317-433D-9FDA-E29C42D123CA"); } }

//        /// <summary>
//        /// Does the work of this Query flow
//        /// </summary>        
//        protected override void DoExecute()
//        {
//            ReturnData(PersonInfo.GetByKey(this.DataIn.Key).Serialize());
//        }        
//    }
//}
