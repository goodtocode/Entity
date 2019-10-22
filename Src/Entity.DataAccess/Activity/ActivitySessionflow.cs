
using GoodToCode.Extensions;
using GoodToCode.Extensions.Collections;

using GoodToCode.Extensions.Serialization;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Activity data on a transactional Sessionflow. Main activity record for any data committed to the system.
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoDelete)]
    public class ActivitySessionflow : ActiveRecordEntity<ActivitySessionflow>, IActivitySessionflow
    {
        /// <summary>
        /// Serialized sessionflow data from the database
        /// Important: Use SessionData.Add and SessionData.Remove to control this property.
        /// </summary>
        public string SessionflowData { get; protected set; } = Defaults.String;

        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivitySessionflow> CreateStoredProcedure
        => new StoredProcedure<ActivitySessionflow>()
        {
            StoredProcedureName = "ActivitySessionflowInsert",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Key),
                new SqlParameter("@FlowKey", FlowKey),
                new SqlParameter("@ApplicationKey", ApplicationKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@SessionflowData", SessionflowData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ActivitySessionflow> UpdateStoredProcedure
        => new StoredProcedure<ActivitySessionflow>()
        {
            StoredProcedureName = "ActivitySessionflowUpdate",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@FlowKey", FlowKey),
                new SqlParameter("@ApplicationKey", ApplicationKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@SessionflowData", SessionflowData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Does not support deletes
        /// </summary>
        public override StoredProcedure<ActivitySessionflow> DeleteStoredProcedure => throw new NotImplementedException();

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<ActivitySessionflow>> Rules()
        {
            return new List<IValidationRule<ActivitySessionflow>>()
            {
                new ValidationRule<ActivitySessionflow>(x => x.ApplicationKey != Defaults.Guid, "ApplicationKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivitySessionflow>(x => x.EntityKey != Defaults.Guid, "EntityKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)"),
                new ValidationRule<ActivitySessionflow>(x => x.FlowKey != Defaults.Guid, "FlowKey is required and cannot be emtpy (00000000-0000-0000-0000-000000000000)")
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
        /// De-serialized activity data
        /// </summary>
        public KeyValueListString SessionData() { return new JsonSerializer<KeyValueListString>().Deserialize(SessionflowData); }

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
        public ActivitySessionflow() : base() { }

        /// <summary>
        /// Saves data
        /// </summary>
        public new ActivitySessionflow Save()
        {
            using (var writer = new StoredProcedureWriter<ActivitySessionflow>())
            {
                ActivitySessionflow returnValue;
                if (this.CanExecute() == true)
                {
                    returnValue = writer.Save(this);
                }
                else
                {
                    throw new System.Exception("Sessionflow can not be processed.");
                }
                return returnValue;
            }            
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
