//-----------------------------------------------------------------------
// <copyright file="ResourceItem.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Item;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
using GoodToCode.Extensions.Text.Cleansing;
using GoodToCode.Framework.Activity;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using GoodToCode.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace GoodToCode.Entity.Resource
{
    /// <summary>
    /// EntityItem
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class ResourceItem : ActiveRecordEntity<ResourceItem>, IItemInfo, IResourceInfo
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceItem> CreateStoredProcedure
        => new StoredProcedure<ResourceItem>()
        {
            StoredProcedureName = "ResourceItemSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ResourceName", ResourceName),
                new SqlParameter("@ResourceDescription", ResourceDescription),
                new SqlParameter("@ItemName", ItemName),
                new SqlParameter("@ItemDescription", ItemDescription),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceItem> UpdateStoredProcedure
        => new StoredProcedure<ResourceItem>()
        {
            StoredProcedureName = "ResourceItemSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@ResourceName", ResourceName),
                new SqlParameter("@ResourceDescription", ResourceDescription),
                new SqlParameter("@ItemName", ItemName),
                new SqlParameter("@ItemDescription", ItemDescription),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<ResourceItem> DeleteStoredProcedure
        => new StoredProcedure<ResourceItem>()
        {
            StoredProcedureName = "ResourceItemDelete",
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
        public override IList<IValidationRule<ResourceItem>> Rules()
        {
            return new List<IValidationRule<ResourceItem>>()
            {
                new ValidationRule<ResourceItem>(x => x.ResourceName.Length > 0, "ResourceName is required"),
                new ValidationRule<ResourceItem>(x => x.ItemName.Length > 0, "ItemName is required")
            };
        }


        /// <summary>
        /// ResourceKey
        /// </summary>
        public Guid ResourceKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// ResourceName
        /// </summary>
        public string ResourceName { get; set; } = Defaults.String;

        /// <summary>
        /// ResourceDescription
        /// </summary>
        public string ResourceDescription { get; set; } = Defaults.String;

        /// <summary>
        /// ItemKey
        /// </summary>
        public Guid ItemKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// ItemName
        /// </summary>
        public string ItemName { get; set; } = Defaults.String;

        /// <summary>
        /// ItemDescription
        /// </summary>
        public string ItemDescription { get; set; } = Defaults.String;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceItem()
            : base()
        {
        }

        /// <summary>
        /// Save the entity to the database. This method will auto-generate activity tracking.
        /// </summary>
        public new ResourceItem Save()
        {
            var writer = new StoredProcedureWriter<ResourceItem>();
            // Ensure data does not contain cross site scripting injection HTML/Js/SQL
            ResourceName = new HtmlUnsafeCleanser(ResourceName).Cleanse();
            ResourceDescription = new HtmlUnsafeCleanser(ResourceDescription).Cleanse();
            ItemName = new HtmlUnsafeCleanser(ItemName).Cleanse();
            ItemDescription = new HtmlUnsafeCleanser(ItemDescription).Cleanse();
            return writer.Save(this);
        }
    }
}
