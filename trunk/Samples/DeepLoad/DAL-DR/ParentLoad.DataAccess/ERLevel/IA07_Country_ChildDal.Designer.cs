using System;
using System.Data;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A07_Country_Child type
    /// </summary>
    public partial interface IA07_Country_ChildDal
    {

        /// <summary>
        /// Inserts a new A07_Country_Child object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        
        void Insert(int country_ID, string country_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the A07_Country_Child object.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        
        void Update(int country_ID, string country_Child_Name);

        /// <summary>
        /// Deletes the A07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}