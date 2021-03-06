﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saritasa.Tools.Interfaces
{
    /// <summary>
    /// <see cref="ILoggerFactory"/> instances manufacture <see cref="ILogger"/>
    /// instances by name. These factory methods may create new instances
    /// or retrieve cached / pooled instances depending on the the
    /// name of the requested logger.
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Returns an appropriate <see cref="ILogger"/> instance as specified by the name parameter.
        /// </summary>
        /// <param name="name">The name of the logger to return.</param>
        ILogger GetLogger(string name);
    }
}
