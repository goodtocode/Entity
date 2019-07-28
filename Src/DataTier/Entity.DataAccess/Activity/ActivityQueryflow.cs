//-----------------------------------------------------------------------
// <copyright file="ActivityQueryflow.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Extensions;
using Genesys.Extras.Data;
using Genesys.Framework.Data;
using Genesys.Framework.Repository;
using Genesys.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Genesys.Entity.Activity
{
    /// <summary>
    /// Activity data on a transactional Queryflow. Main activity record for any data committed to the system.
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoDelete)]
    public class ActivityQueryflow : ActiveRecordEntity<ActivityQueryflow>, IActivityQueryflow
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityQueryflow> CreateStoredProcedure
        => new StoredProcedure<ActivityQueryflow>()
        {
            StoredProcedureName = "ActivityQueryflowInsert",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Key),
                new SqlParameter("@FlowKey", FlowKey),
                new SqlParameter("@ApplicationKey", ApplicationKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@SqlStatement", SqlStatement),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivityQueryflow> UpdateStoredProcedure
        => new StoredProcedure<ActivityQueryflow>()
        {
            StoredProcedureName = "ActivityQueryflowUpdate",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@FlowKey", FlowKey),
                new SqlParameter("@ApplicationKey", ApplicationKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@SqlStatement", SqlStatement),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Does not support deletes
        /// </summary>
        public override StoredProcedure<ActivityQueryflow> DeleteStoredProcedure => throw new NotImplementedException();

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ActivityQueryflow>> Rules()
        { return new List<IValidationRule<ActivityQueryflow>>()
            {
                new ValidationRule<ActivityQueryflow>(x => x.ApplicationKey != Defaults.Guid, "ApplicationKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivityQueryflow>(x => x.EntityKey != Defaults.Guid, "EntityKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivityQueryflow>(x => x.FlowKey != Defaults.Guid, "FlowKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)")
            };
        }

        /// <summary>
        /// Application
        /// </summary>
        public Guid ApplicationKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Entity
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Flow being executed
        /// </summary>
        public Guid FlowKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Sql statement executed in this Queryflow
        /// </summary>
        public string SqlStatement { get; set; } = Defaults.String;

        /// <summary>
        /// Identity (username) of the entity inserting this record
        /// Readonly
        /// </summary>
        public string IdentityUserName { get; internal set; } = Defaults.String;

        /// <summary>
        /// Device Universal Id that is requesting the insert of this record
        /// Readonly
        /// </summary>
        public string DeviceUuid { get; internal set; } = Defaults.String;

        /// <summary>
        /// Application Universal Id that is requesting the insert of this record
        /// Readonly
        /// </summary>
        public string ApplicationUuid { get; internal set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ActivityQueryflow() : base() { }

        /// <summary>
        /// Saves data
        /// </summary>
        public new ActivityQueryflow Save()
        {
            var returnValue = new ActivityQueryflow();
            var writer = new StoredProcedureWriter<ActivityQueryflow>();

            if (this.CanExecute() == true)
            {
                returnValue = writer.Save(this);
            } else {
                throw new System.Exception("Queryflow can not be processed.");
            }

            return returnValue;
        }
        
        /// <summary>
        /// Determines if this flow can be processed
        /// </summary>
        public bool CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Can insert to DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CanInsert(IActivityFlow entity)
        {
            return true;
        }

        /// <summary>
        /// Can update DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CanUpdate(IActivityFlow entity)
        {
            return true;
        }
    }
}
