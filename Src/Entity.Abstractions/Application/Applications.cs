
using System;

namespace GoodToCode.Entity.Application
{
    /// <summary>
    /// Holds Ids of global records
    /// </summary>
    public struct Applications
    {
        /// <summary>
        /// Sandbox record, for general purpose use and testing. Not for Production Use!
        /// </summary>
        public static Guid Sandbox { get; } = new Guid("1EE3F6EC-59A7-4FD3-91D7-22AE3E20D412");
    }
}
