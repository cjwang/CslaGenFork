using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_Region_Child type
    /// </summary>
    public partial interface IG09_Region_ChildDal
    {
        /// <summary>
        /// Loads a G09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        /// <returns>A data reader to the G09_Region_Child.</returns>
        IDataReader Fetch(int region_ID1);

        /// <summary>
        /// Inserts a new G09_Region_Child object in the database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Insert(int region_ID1, string region_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the G09_Region_Child object.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Update(int region_ID1, string region_Child_Name);

        /// <summary>
        /// Deletes the G09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        void Delete(int region_ID1);
    }
}
