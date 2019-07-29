//-----------------------------------------------------------------------
// <copyright file="EventDetail.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Extensions;
using GoodToCode.Extras.Data;
using GoodToCode.Framework.Activity;
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
    /// Event detail
    /// </summary>

    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode")]
    public class EventDetail : ActiveRecordEntity<EventDetail>, IEventDetail
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventDetail> CreateStoredProcedure
        => new StoredProcedure<EventDetail>()
        {
            StoredProcedureName = "EventDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@DetailTypeKey", DetailTypeKey),
                new SqlParameter("@DetailData", DetailData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventDetail> UpdateStoredProcedure
        => new StoredProcedure<EventDetail>()
        {
            StoredProcedureName = "EventDetailSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Id),
                new SqlParameter("@Key", Key),
                new SqlParameter("@EventKey", EventKey),
                new SqlParameter("@DetailTypeKey", DetailTypeKey),
                new SqlParameter("@DetailData", DetailData),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventDetail> DeleteStoredProcedure
        => new StoredProcedure<EventDetail>()
        {
            StoredProcedureName = "EventDetailDelete",
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
        public override IList<IValidationRule<EventDetail>> Rules()
        {
            return new List<IValidationRule<EventDetail>>()
            {
                new ValidationRule<EventDetail>(x => x.DetailTypeKey != Defaults.Guid, "DetailTypeKey is required")
            };
        }

        /// <summary>
        /// EventId
        /// </summary>
        public Guid EventKey { get; set; } = Defaults.Guid;

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
        public EventDetail()
            : base()
        {
        }

        /// <summary>
        /// Gets by Unique key
        /// </summary>
        /// <param name="eventKey">Id of event</param>
        /// <param name="detailTypeKey">Type of detail to get</param>

        public static EventDetail GetByEventDetailType(Guid eventKey, Guid detailTypeKey)
        {
            var reader = new EntityReader<EventDetail>();
            var returnValue = new EventDetail();
            var returnData = reader.GetByWhere(x => x.EventKey == eventKey & x.DetailTypeKey == detailTypeKey)
                .OrderByDescending(y => y.CreatedDate);
            returnValue = returnData.FirstOrDefaultSafe();
            returnValue.EventKey = eventKey;
            returnValue.DetailTypeKey = detailTypeKey;

            return returnValue;
        }

        /// <summary>
        /// Gets all details for a type of event
        /// </summary>
        /// <param name="eventKey">Id of event</param>
        public static List<EventDetail> GetByEvent(Guid eventKey)
        {
            var reader = new EntityReader<EventDetail>();
            var returnValue = reader.GetByWhere(a => a.EventKey == eventKey).ToList();
            var missingDetails = reader.GetByWhere(b => b.EventKey == Defaults.Guid).ToList();
            missingDetails.RemoveAll(a => returnValue.Select(b => b.DetailTypeKey).Contains(a.DetailTypeKey));
            returnValue.AddRange(missingDetails);
            foreach (var item in returnValue)
            {
                item.EventKey = eventKey;
            }

            return returnValue;
        }

        /// <summary>
        /// Saves all items in a list and ensures they have an Id
        /// </summary>
        public new EventDetail Save()
        {
            var writer = new StoredProcedureWriter<EventDetail>();
            return writer.Save(this);
        }

        /// <summary>
        /// Saves all items in a list and ensures they have an Id
        /// </summary>
        /// <param name="eventKey">Event to save</param>
        /// <param name="details">Details to attach to even</param>
        /// <param name="activity">Activity tracking this process.</param>
        public static void Save(Guid eventKey, List<EventDetail> details, IActivityContext activity)
        {
            var writer = new StoredProcedureWriter<EventDetail>();
            foreach (var item in details)
            {
                if (item.EventKey == Defaults.Guid)
                {
                    item.EventKey = eventKey;
                }
                item.ActivityContextKey = activity.ActivityContextKey;
                writer.Save(item);
            }
        }
    }
}
