//-----------------------------------------------------------------------
// <copyright file="" company="GoodToCode">
//      Copyright (c) 2017-2020 GoodToCode. All rights reserved.
//      Licensed to the Apache Software Foundation (ASF) under one or more 
//      contributor license agreements.  See the NOTICE file distributed with 
//      this work for additional information regarding copyright ownership.
//      The ASF licenses this file to You under the Apache License, Version 2.0 
//      (the 'License'); you may not use this file except in compliance with 
//      the License.  You may obtain a copy of the License at 
//       
//        http://www.apache.org/licenses/LICENSE-2.0 
//       
//       Unless required by applicable law or agreed to in writing, software  
//       distributed under the License is distributed on an 'AS IS' BASIS, 
//       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  
//       See the License for the specific language governing permissions and  
//       limitations under the License. 
// </copyright>
//-----------------------------------------------------------------------
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
        public Guid ActivityContextKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
