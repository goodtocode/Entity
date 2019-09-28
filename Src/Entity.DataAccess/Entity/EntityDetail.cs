
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Entity detail
    /// </summary>

    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EntityDetail : ActiveRecordEntity<EntityDetail>, IEntityDetail
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityDetail> CreateStoredProcedure
        => new StoredProcedure<EntityDetail>()
        {
            StoredProcedureName = "EntityDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@DetailTypeKey", DetailTypeKey),
                new SqlParameter("@DetailData", DetailData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityDetail> UpdateStoredProcedure
        => new StoredProcedure<EntityDetail>()
        {
            StoredProcedureName = "EntityDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@DetailTypeKey", DetailTypeKey),
                new SqlParameter("@DetailData", DetailData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityDetail> DeleteStoredProcedure
        => new StoredProcedure<EntityDetail>()
        {
            StoredProcedureName = "EntityDetailDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Rules used by the validator for Data Validation and Business Validation
        /// </summary>
        public override IList<IValidationRule<EntityDetail>> Rules()
        {
            return new List<IValidationRule<EntityDetail>>()
            {
                new ValidationRule<EntityDetail>(x => x.DetailTypeKey != Defaults.Guid, "DetailTypeKey is required")
            };
        }

        /// <summary>
        /// EntityId
        /// </summary>
        public Guid EntityKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// DetailTypeId
        /// </summary>
        public Guid DetailTypeKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Detail (Type) Name
        /// </summary>
        public string Name { get; set; } = Defaults.String;

        /// <summary>
        /// Detail (Type) Description
        /// </summary>
        public string Description { get; set; } = Defaults.String;

        /// <summary>
        /// Detail Data
        /// </summary>
        public string DetailData { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityDetail()
            : base()
        {
        }

        /// <summary>
        /// Gets by Unique key
        /// </summary>
        /// <param name="EntityKey">Id of Entity</param>
        /// <param name="detailTypeKey">Type of detail to get</param>

        public static EntityDetail GetByEntityDetailType(Guid EntityKey, Guid detailTypeKey)
        {
            var reader = new EntityReader<EntityDetail>();
            var returnValue = new EntityDetail();
            var returnData = reader.GetByWhere(x => x.EntityKey == EntityKey & x.DetailTypeKey == detailTypeKey)
                .OrderByDescending(y => y.CreatedDate);
            returnValue = returnData.FirstOrDefaultSafe();
            returnValue.EntityKey = EntityKey;
            returnValue.DetailTypeKey = detailTypeKey;

            return returnValue;
        }

        /// <summary>
        /// Gets all details for a type of Entity
        /// </summary>
        /// <param name="EntityKey">Id of Entity</param>
        public static List<EntityDetail> GetByEntity(Guid EntityKey)
        {
            var reader = new EntityReader<EntityDetail>();
            var returnValue = reader.GetByWhere(a => a.EntityKey == EntityKey).ToList();
            var missingDetails = reader.GetByWhere(b => b.EntityKey == Defaults.Guid).ToList();
            missingDetails.RemoveAll(a => returnValue.Select(b => b.DetailTypeKey).Contains(a.DetailTypeKey));
            returnValue.AddRange(missingDetails);
            foreach (var item in returnValue)
            {
                item.EntityKey = EntityKey;
            }

            return returnValue;
        }

        /// <summary>
        /// Saves all items in a list and ensures they have an Id
        /// </summary>
        /// <param name="EntityKey">Entity to save</param>
        /// <param name="details">Details to attach to even</param>
        /// <param name="activity">Activity tracking this process.</param>
        public static void Save(Guid EntityKey, List<EntityDetail> details, IActivityContext activity)
        {
            var writer = new StoredProcedureWriter<EntityDetail>();
            foreach (var item in details)
            {
                if (item.EntityKey == Defaults.Guid)
                {
                    item.EntityKey = EntityKey;
                }
                item.ActivityContextKey = activity.ActivityContextKey;
                writer.Save(item);
            }
        }
    }
}
