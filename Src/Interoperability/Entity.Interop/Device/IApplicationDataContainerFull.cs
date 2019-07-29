//-----------------------------------------------------------------------
// <copyright file="IApplicationDataContainerFull.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace GoodToCode.Entity.Device
{
    /// <summary>
    /// Local/Device data storage for application. Dictionary of String, String items.
    /// Mimics: Windows.Storage.IApplicationDataContainer
    /// </summary> 
    public interface IApplicationDataContainerFull
    {
        /// <summary>
        /// Gets the child application settings containers of this application settings container.
        /// </summary>
        IReadOnlyDictionary<string, IApplicationDataContainerFull> Containers { get; }

        /// <summary>
        /// Gets the type (local or roaming) of the app data store that is associated with
        /// the current settings container. 0 = local, 1 = roaming.
        /// </summary>
        int Locality { get; }

        /// <summary>
        /// Gets the name of the current settings container.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets an object that represents the settings in this settings container.
        /// </summary>
        IDictionary<string, string> Values { get; }

        /// <summary>
        /// Creates or opens the specified settings container in the current settings container.
        /// </summary>
        /// <param name="name">Always returns the specified container. Creates the container if it does not exist</param>
        /// <returns></returns>
        IApplicationDataContainerFull CreateContainer(string name);

        /// <summary>
        /// Deletes the specified settings container, its subcontainers, and all application settings in the hierarchy.
        /// </summary>
        /// <param name="name">The name of the settings container.</param>
        void DeleteContainer(string name);

        /// <summary>
        /// Retrieves a value from the data store
        /// </summary>
        /// <param name="key">The unique Id of the item</param>
        /// <param name="notFoundValue"></param>
        /// <returns></returns>
        string GetValue(string key, string notFoundValue = "");

        /// <summary>
        /// Writes a value to the data store
        /// </summary>
        /// <param name="key">The unique Id of the item</param>
        /// <param name="value">Value of the item</param>
        void SetValue(string key, string value);

        /// <summary>
        /// Writes a collection of values to the data store
        /// </summary>
        /// <param name="values"></param>
        void SetValues(IDictionary<string, string> values);
    }
}