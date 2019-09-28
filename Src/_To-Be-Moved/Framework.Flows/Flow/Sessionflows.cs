using System;

namespace GoodToCode.Framework.Flow
{
    /// <summary>
    /// Holds Ids of global records
    /// </summary>
    public struct Sessionflows
    {
        /// <summary>
        /// Sandbox record, for general purpose use and testing. Not for Production Use!
        /// </summary>
        public static Guid General { get; } = new Guid("6DA2EC13-99C9-41AA-BBBF-612136A47223");
    }
}