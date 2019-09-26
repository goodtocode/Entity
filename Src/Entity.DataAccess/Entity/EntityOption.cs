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
using GoodToCode.Entity.Flow;
using GoodToCode.Entity.Option;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Data;
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
    /// EntityOption 
    /// </summary>
    [ConnectionStringName("DefaultConnection"), DatabaseSchemaName("EntityCode"), DataAccessBehavior(DataAccessBehaviors.NoUpdate)]
    public class EntityOption : ActiveRecordEntity<EntityOption>, IEntityOption
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> CreateStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> UpdateStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EntityKey", EntityKey),
                new SqlParameter("@OptionKey", OptionKey),
                new SqlParameter("@ActivityContextKey", ActivityContextKey)
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityOption> DeleteStoredProcedure
        => new StoredProcedure<EntityOption>()
        {
            StoredProcedureName = "EntityOptionDelete",
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
        public override IList<IValidationRule<EntityOption>> Rules()
        {
            return new List<IValidationRule<EntityOption>>()
            { };
        }

        /// <summary>
        /// EntityId regarding this Option
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
        /// Option Group key
        /// </summary>
        public Guid OptionGroupKey { get; set; } = Defaults.Guid;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityOption() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionKey">OptionId</param>
        /// <param name="entityKey">EntityId</param>
        public EntityOption(Guid entityKey, Guid optionKey)
            : base()
        {
            EntityKey = entityKey;
            OptionKey = optionKey;
        }

        /// <summary>
        /// Instantiates and saves one record
        /// </summary>
        /// <param name="OptionKey">OptionId</param>
        /// <param name="workflow">Workflow</param>
        public static EntityOption Create(Guid OptionKey, IFlowClass workflow)
        {
            var returnValue = new EntityOption(workflow.Context.EntityKey, OptionKey);
            returnValue.Save(workflow);
            return returnValue;
        }

        /// <summary>
        /// Instantiates and saves one record
        /// </summary>
        /// <param name="OptionKey">OptionId</param> 
        /// <param name="workflow">Workflow</param>

        public static EntityOption CreateOnePerGroup(Guid OptionKey, IFlowClass workflow)
        {
            var returnValue = new EntityOption(workflow.Context.EntityKey, OptionKey);
            EntityOption.Create(OptionKey, workflow);
            return returnValue;
        }

        /// <summary>
        /// Gets properties per entity
        /// </summary>
        /// <param name="EntityKey">EntityId</param>

        public static IQueryable<EntityOption> GetByEntity(Guid EntityKey)
        {
            using (var reader = new EntityReader<EntityOption>())
            {
                return reader.GetByWhere(x => x.EntityKey == EntityKey);
            }
        }

        /// <summary>
        /// Gets by Option and entity
        /// </summary>
        /// <param name="EntityKey">EntityId</param>
        /// <param name="OptionKey">OptionId</param>

        public static EntityOption GetByEntityOption(Guid EntityKey, Guid OptionKey)
        {
            var returnValue = new EntityOption();
            using (var reader = new EntityReader<EntityOption>())
            {
                var dataSelection = reader.GetByWhere(x => x.EntityKey == EntityKey && x.OptionKey == OptionKey);
                returnValue = dataSelection.FirstOrDefaultSafe();
                returnValue.EntityKey = EntityKey;
                returnValue.OptionKey = OptionKey;
            }
            return returnValue;
        }

        /// <summary>
        /// Gets by entity and group
        /// </summary>
        /// <param name="entityKey">EntityId</param>
        /// <param name="OptionGroupKey">OptionGroupId</param>
        public static IQueryable<EntityOption> GetByEntityOptionGroup(Guid entityKey, Guid OptionGroupKey)
        {
            using (var reader = new EntityReader<EntityOption>())
            {
                return reader.GetByWhere(x => x.EntityKey == entityKey & x.OptionGroupKey == OptionGroupKey);
            }
        }

        /// <summary>
        /// This resets and saves only 1 group of properties. 
        /// This will clear entire list if nothing is selected and fall-back to default
        /// </summary>
        /// <param name="OptionGroupKey">OptionGroupId</param>
        /// <param name="selectedProperties">SelectedProperties</param>
        /// <param name="workflow">Workflow processing this record</param>
        public static void Save(Guid OptionGroupKey,
            IEnumerable<EntityOption> selectedProperties, IFlowClass workflow)
        {
            // Start clean
            foreach (var conOption in EntityOption.GetByEntity(workflow.Activity.EntityKey).Where(x => x.OptionGroupKey == OptionGroupKey))
            {
                conOption.Delete(workflow);
            }
            // Add all selections
            foreach (var SelectedItem in selectedProperties)
            {
                EntityOption.Create(SelectedItem.OptionKey, workflow);
            }
        }

        /// <summary>
        /// This resets and saves only 1 group of properties
        /// This REQUIRES one Option to be selected for the group (i.e. Male/Female)
        /// </summary>
        /// <param name="workflow">Workflow processing this record</param>
        public void Save(IFlowClass workflow)
        {
            using (var reader = new EntityReader<EntityOption>())
            {
                var groupKey = reader.GetByKey(OptionKey).OptionGroupKey;
                foreach (var conOption in EntityOption.GetByEntity(workflow.Activity.EntityKey).Where(x => x.OptionGroupKey == groupKey))
                {
                    conOption.Delete(workflow);
                }
            }
            EntityOption.Create(OptionKey, workflow);
        }

        /// <summary>
        /// This resets and saves only 1 group of properties
        /// This REQUIRES one Option to be selected for the group (i.e. Male/Female)
        /// </summary>
        /// <param name="workflow">Workflow processing this record</param>
        public void Delete(IFlowClass workflow)
        {
            using (var writer = new StoredProcedureWriter<EntityOption>())
            {
                using (var reader = new EntityReader<EntityOption>())
                {
                    var groupKey = reader.GetByKey(OptionKey).OptionGroupKey;
                    foreach (var conOption in EntityOption.GetByEntity(workflow.Activity.EntityKey).Where(x => x.OptionGroupKey == groupKey))
                    {
                        conOption.ActivityContextKey = workflow.Activity.Key;
                        writer.Delete(conOption);
                    }
                }
            }
            EntityOption.Create(OptionKey, workflow);
        }
    }
}