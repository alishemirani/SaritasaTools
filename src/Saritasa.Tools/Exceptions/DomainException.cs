﻿//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Saritasa.Tools.Exceptions
{
    using System;

    /// <summary>
    /// Exception occurs in domain part of application. It can be logic or validation exception.
    /// </summary>
    [Serializable]
    public class DomainException : Exception
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public DomainException() : base()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        public DomainException(string message) : base(message)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
