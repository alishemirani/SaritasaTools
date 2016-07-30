﻿// Copyright (c) 2015-2016, Saritasa. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace Saritasa.Tools.Queries.QueryPipelineMIddlewares
{
    using System;
    using Messages;

    /// <summary>
    /// Executes query delegate.
    /// </summary>
    public class QueryExecutorMiddleware : IMessagePipelineMiddleware
    {
        /// <inheritdoc />
        public string Id
        {
            get { return "executor"; }
        }

        /// <inheritdoc />
        public void Handle(Message message)
        {
            var queryMessage = message as QueryMessage;
            if (queryMessage == null)
            {
                throw new NotSupportedException("Message should be QueryMessage type");
            }

            // invoke method and resolve parameters if needed
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                queryMessage.Result = queryMessage.Func.DynamicInvoke(queryMessage.Parameters);
                stopWatch.Stop();
                queryMessage.ExecutionDuration = (int)stopWatch.ElapsedMilliseconds;
                queryMessage.Status = Message.ProcessingStatus.Completed;
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                queryMessage.ExecutionDuration = (int)stopWatch.ElapsedMilliseconds;
                queryMessage.Status = Message.ProcessingStatus.Failed;
                var innerException = ex.InnerException;
                if (innerException != null)
                {
                    queryMessage.Error = innerException;
                    queryMessage.ErrorDispatchInfo = System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(innerException);
                }
            }
        }
    }
}