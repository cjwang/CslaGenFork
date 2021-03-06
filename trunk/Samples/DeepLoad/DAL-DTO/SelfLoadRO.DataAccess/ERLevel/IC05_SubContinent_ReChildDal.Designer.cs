using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_SubContinent_ReChild type
    /// </summary>
    public partial interface IC05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C05_SubContinent_ReChildDto"/> object.</returns>
        C05_SubContinent_ReChildDto Fetch(int subContinent_ID2);
    }
}
