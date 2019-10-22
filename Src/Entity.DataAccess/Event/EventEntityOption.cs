
using GoodToCode.Extensions;

using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// EventEntity DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventEntityOption : ActiveRecordEntity<EventEntityOption>, IEventEntityOption
	{
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventEntityOption> CreateStoredProcedure
        => new StoredProcedure<EventEntityOption>()
        {
            StoredProcedureName = "EventEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventEntityOption> UpdateStoredProcedure
        => new StoredProcedure<EventEntityOption>()
        {
            StoredProcedureName = "EventEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventEntityOption> DeleteStoredProcedure
        => new StoredProcedure<EventEntityOption>()
        {
            StoredProcedureName = "EventEntityOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Key", Key),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EventEntityOption>> Rules()
        {
            return new List<IValidationRule<EventEntityOption>>()
            { };
        }

        /// <summary>
        /// EventKey
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// EntityKey
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Option key
        /// </summary>
        public Guid OptionKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Name
        /// </summary>
        public string OptionName { get; set; } = Defaults.String;

        /// <summary>
        /// Option Description
        /// </summary>
        public string OptionDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Data access heavy way of getting a list of Option from an Entity
        /// </summary>
        /// <param name="EntityKey">EntityId</param>
        public static IQueryable<EventEntityOption> GetByEntity(Guid EntityKey)
        {
            var reader = new EntityReader<EventEntityOption>();
            IQueryable<EventEntityOption> returnValue = reader.GetByWhere(x => x.EntityKey == EntityKey);
            return returnValue;
        }
    }
}
