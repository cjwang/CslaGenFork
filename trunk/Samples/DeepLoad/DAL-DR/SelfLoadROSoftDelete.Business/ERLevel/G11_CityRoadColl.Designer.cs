using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess.ERLevel;
using SelfLoadROSoftDelete.DataAccess;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G11_CityRoadColl (read only list).<br/>
    /// This is a generated base class of <see cref="G11_CityRoadColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G10_City"/> read only object.<br/>
    /// The items of the collection are <see cref="G12_CityRoad"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G11_CityRoadColl : ReadOnlyListBase<G11_CityRoadColl, G12_CityRoad>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="G12_CityRoad"/> item is in the collection.
        /// </summary>
        /// <param name="cityRoad_ID">The CityRoad_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G12_CityRoad is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int cityRoad_ID)
        {
            foreach (var g12_CityRoad in this)
            {
                if (g12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G11_CityRoadColl"/> object, based on given parameters.
        /// </summary>
        /// <param name="parent_City_ID">The Parent_City_ID parameter of the G11_CityRoadColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G11_CityRoadColl"/> object.</returns>
        internal static G11_CityRoadColl GetG11_CityRoadColl(int parent_City_ID)
        {
            return DataPortal.FetchChild<G11_CityRoadColl>(parent_City_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G11_CityRoadColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G11_CityRoadColl()
        {
            // Prevent direct creation

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G11_CityRoadColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        protected void Child_Fetch(int parent_City_ID)
        {
            var args = new DataPortalHookArgs(parent_City_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG11_CityRoadCollDal>();
                var data = dal.Fetch(parent_City_ID);
                LoadCollection(data);
            }
            OnFetchPost(args);
        }

        private void LoadCollection(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="G11_CityRoadColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(G12_CityRoad.GetG12_CityRoad(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}