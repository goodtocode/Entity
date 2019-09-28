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

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Venture detail
    /// </summary>

    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class VentureDetail : ActiveRecordEntity<VentureDetail>, IVentureDetail
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureDetail> CreateStoredProcedure
        => new StoredProcedure<VentureDetail>()
        {
            StoredProcedureName = "VentureDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@VentureKey", VentureKey),
                new SqlParameter("@DetailTypeKey", DetailTypeKey),
                new SqlParameter("@DetailData", DetailData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureDetail> UpdateStoredProcedure
        => new StoredProcedure<VentureDetail>()
        {
            StoredProcedureName = "VentureDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@VentureKey", VentureKey),
                new SqlParameter("@DetailTypeKey", DetailTypeKey),
                new SqlParameter("@DetailData", DetailData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<VentureDetail> DeleteStoredProcedure
        => new StoredProcedure<VentureDetail>()
        {
            StoredProcedureName = "VentureDetailDelete",
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
        public override IList<IValidationRule<VentureDetail>> Rules()
        {
            return new List<IValidationRule<VentureDetail>>()
            {
                new ValidationRule<VentureDetail>(x => x.DetailTypeKey != Defaults.Guid, "DetailTypeKey is required")
            };
        }

        /// <summary>
        /// VentureId
        /// </summary>
        public Guid VentureKey { get; set; } = Defaults.Guid;

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
        public VentureDetail()
            : base()
        {
        }

        /// <summary>
        /// Gets by Unique key
        /// </summary>
        /// <param name="VentureKey">Id of Venture</param>
        /// <param name="detailTypeKey">Type of detail to get</param>

        public static VentureDetail GetByVentureDetailType(Guid VentureKey, Guid detailTypeKey)
        {
            var reader = new EntityReader<VentureDetail>();
            var returnValue = new VentureDetail();
            var returnData = reader.GetByWhere(x => x.VentureKey == VentureKey & x.DetailTypeKey == detailTypeKey)
                .OrderByDescending(y => y.CreatedDate);
            returnValue = returnData.FirstOrDefaultSafe();
            returnValue.VentureKey = VentureKey;
            returnValue.DetailTypeKey = detailTypeKey;

            return returnValue;
        }

        /// <summary>
        /// Gets all details for a type of Venture
        /// </summary>
        /// <param name="VentureKey">Id of Venture</param>
        public static List<VentureDetail> GetByVenture(Guid VentureKey)
        {
            var reader = new EntityReader<VentureDetail>();
            var returnValue = reader.GetByWhere(a => a.VentureKey == VentureKey).ToList();
            var missingDetails = reader.GetByWhere(b => b.VentureKey == Defaults.Guid).ToList();
            missingDetails.RemoveAll(a => returnValue.Select(b => b.DetailTypeKey).Contains(a.DetailTypeKey));
            returnValue.AddRange(missingDetails);
            foreach (var item in returnValue)
            {
                item.VentureKey = VentureKey;
            }

            return returnValue;
        }

        /// <summary>
        /// Saves all items in a list and ensures they have an Id
        /// </summary>
        /// <param name="VentureKey">Venture to save</param>
        /// <param name="details">Details to attach to even</param>
        /// <param name="activity">Activity tracking this process.</param>
        public static void Save(Guid VentureKey, List<VentureDetail> details, IActivityContext activity)
        {
            var writer = new StoredProcedureWriter<VentureDetail>();
            foreach (var item in details)
            {
                if (item.VentureKey == Defaults.Guid)
                {
                    item.VentureKey = VentureKey;
                }
                item.ActivityContextKey = activity.ActivityContextKey;
                writer.Save(item);
            }
        }
    }
}
