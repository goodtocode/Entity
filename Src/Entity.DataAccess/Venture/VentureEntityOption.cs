using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// VentureEntity DAO
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class VentureEntityOption : ActiveRecordEntity<VentureEntityOption>, IVentureEntityOption
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureEntityOption> CreateStoredProcedure
        => new StoredProcedure<VentureEntityOption>()
        {
            StoredProcedureName = "VentureEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VentureKey", VentureKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureEntityOption> UpdateStoredProcedure
        => new StoredProcedure<VentureEntityOption>()
        {
            StoredProcedureName = "VentureEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VentureKey", VentureKey),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureEntityOption> DeleteStoredProcedure
        => new StoredProcedure<VentureEntityOption>()
        {
            StoredProcedureName = "VentureEntityOptionDelete",
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
        public override IList<IValidationRule<VentureEntityOption>> Rules()
        {
            return new List<IValidationRule<VentureEntityOption>>()
            { };
        }

        /// <summary>
        /// VentureKey
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

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
        public static IQueryable<VentureEntityOption> GetByEntity(Guid EntityKey)
        {
            var reader = new EntityReader<VentureEntityOption>();
            IQueryable<VentureEntityOption> returnValue = reader.GetByWhere(x => x.EntityKey == EntityKey);
            return returnValue;
        }
    }
}
