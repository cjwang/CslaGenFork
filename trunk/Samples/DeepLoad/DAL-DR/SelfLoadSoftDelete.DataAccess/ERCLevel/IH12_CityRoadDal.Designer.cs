using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H12_CityRoad type
    /// </summary>
    public partial interface IH12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new H12_CityRoad object in the database.
        /// </summary>
        /// <param name="parent_City_ID">The parent Parent City ID.</param>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        void Insert(int parent_City_ID, out int cityRoad_ID, string cityRoad_Name);

        /// <summary>
        /// Updates in the database all changes made to the H12_CityRoad object.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        void Update(int cityRoad_ID, string cityRoad_Name);

        /// <summary>
        /// Deletes the H12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
