﻿// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Saritasa.Tools.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Message repository interface.
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Add message.
        /// </summary>
        /// <param name="message">Message.</param>
        void Add(Message message);

        /// <summary>
        /// Get messages filtered by expression.
        /// </summary>
        /// <param name="selector">Expression.</param>
        /// <param name="assemblies">Assemblies for types loading.</param>
        /// <returns>Enumerable of messages.</returns>
        IEnumerable<Message> Get(Expression<Func<Message, bool>> selector, Assembly[] assemblies = null);

        /// <summary>
        /// Save internal state to dict. The methpd represents the ability of message repository to
        /// to save its internal state to dictionary. Also type should define static Create
        /// method to recreate itself from dict.
        /// </summary>
        /// <param name="dict">Dictionary of properties.</param>
        void SaveState(IDictionary<string, object> dict);
    }
}