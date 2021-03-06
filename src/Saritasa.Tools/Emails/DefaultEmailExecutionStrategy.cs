﻿//
// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
//

namespace Saritasa.Tools.Emails
{
    using System;
    using System.Net.Mail;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;

    using NameValueDict = System.Collections.Generic.IDictionary<string, object>;

    /// <summary>
    /// This execution strategy does not retry any operations.
    /// </summary>
    public class DefaultEmailExecutionStrategy : IEmailExecutionStrategy
    {
        /// <inheritdoc />
        public Task Execute(Func<MailMessage, NameValueDict, Task> handler, MailMessage message, NameValueDict data, CancellationToken cancellationToken)
        {
            return handler(message, data);
        }
    }
}
