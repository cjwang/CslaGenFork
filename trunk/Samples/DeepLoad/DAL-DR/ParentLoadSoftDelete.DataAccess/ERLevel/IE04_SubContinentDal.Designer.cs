using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E04_SubContinent type
    /// </summary>
    public partial interface IE04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new E04_SubContinent object in the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The parent Parent Continent ID.</param>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        /// <param name="subContinent_Name">The Sub Continent Name.</param>
        void Insert(int parent_Continent_ID, out int subContinent_ID, string subContinent_Name);

        /// <summary>
        /// Updates in the database all changes made to the E04_SubContinent object.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        /// <param name="subContinent_Name">The Sub Continent Name.</param>
        void Update(int subContinent_ID, string subContinent_Name);

        /// <summary>
        /// Deletes the E04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
