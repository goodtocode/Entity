using GoodToCode.Entity.Activity;
using GoodToCode.Entity.Application;
using GoodToCode.Extensions;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Session;
using System;

namespace GoodToCode.Entity.Flow
{
    /// <summary>
    /// Fake workflow class that simulates real workflow
    /// </summary>
    public sealed class WorkflowStub : IFlowClass
    {
        public IActivityFlow Activity
        {
            get
            {
                using (var reader = new EntityReader<ActivityWorkflow>())
                {
                    return reader.GetAll().FirstOrDefaultSafe();
                }
            }
        }

        public ISessionContext Context
        {
            get
            {
                return new SessionContext(this.ToString(), Applications.Sandbox.ToString(), Environment.UserName);
            }
        }

        public bool IsValidThrowsException { get; set; } = Defaults.Boolean;
        public Guid FlowKey
        {
            set { }
            get
            {
                return Activity.FlowKey;
            }
        }

        public Guid FlowStepKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PrincipalIP4Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ExecutingContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string IdentityUserName { get; set; } = $@"{Environment.UserDomainName}\{Environment.UserName}";
        public string DeviceUuid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ApplicationUuid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid ActivitySessionflowKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsNew => throw new NotImplementedException();

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime CreatedDate => throw new NotImplementedException();

        public DateTime ModifiedDate => throw new NotImplementedException();

        public Guid ApplicationKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid EntityKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }
    }
}
