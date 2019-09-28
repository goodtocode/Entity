using System;

namespace GoodToCode.Entity.Common
{
    /// <summary>
    /// Behavior of a workflow (creating a new entity, etc.)
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class FlowBehavior : System.Attribute
    {
        /// <summary>
        /// Attribute decoration value
        /// </summary>
        public FlowBehaviors Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Value of the item</param>
        public FlowBehavior(FlowBehaviors value) : base()
        {
            Value = value;
        }
    }

    /// <summary>
    /// Enumeration to allow the attribute to use strongly-typed ID
    /// Note: This is a [Flags] decorated enum. Values MUST be bitwise friendly (1, 2, 4, 8, 16, 32, etc.) 
    ///     None must be 0, and excluded from bitwise operations
    /// </summary>
    [Flags]
    public enum FlowBehaviors
    {
        /// <summary>
        /// Normal behavior: Existing entityID, user is logged on to supply Name property
        /// </summary>
        Default = 0,

        /// <summary>
        /// Generates a EntityID: This workflow will generate a entityID, registering a user or creating a root record
        /// </summary>
        GeneratesEntity = 1,

        /// <summary>
        /// Anonymous: EntityID/User not known, and workflow will not generate a user or root record
        /// </summary>
        Anonymous = 2,

        /// <summary>
        /// NoTracking: Shuts off all tracking.
        /// </summary>
        NoTracking = 3
    }
}
