﻿/**
* Copyright (c) David Miller. All rights reserved.
* The use and distribution terms for this software are covered by the
* Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
* which can be found in the file epl-v10.html at the root of this distribution.
* By using this software in any fashion, you are agreeing to be bound by
* the terms of this license.
* You must not remove this notice, or any other, from this software.
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clojure.lang
{
    public interface ITransientMap : ITransientAssociative, Counted
    {
        /// <summary>
        /// Add a new key/value pair.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The value</param>
        /// <returns>A new map with key+value added.</returns>
        /// <remarks>Overwrites an exising value for the <paramref name="key"/>, if present.</remarks>
        ITransientMap assoc(object key, object val);

        /// <summary>
        /// Remove a key entry.
        /// </summary>
        /// <param name="key">The key to remove</param>
        /// <returns>A new map with the key removed (or the same map if the key is not contained).</returns>
        ITransientMap without(object key);

    }
}
