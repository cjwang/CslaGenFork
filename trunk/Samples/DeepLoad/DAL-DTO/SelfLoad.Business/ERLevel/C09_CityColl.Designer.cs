using System;
using System.Collections.Generic;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C09_CityColl (editable child list).<br/>
    /// This is a generated base class of <see cref="C09_CityColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="C08_Region"/> editable child object.<br/>
    /// The items of the collection are <see cref="C10_City"/> objects.
    /// </remarks>
    [Serializable]
    public partial class C09_CityColl : BusinessListBase<C09_CityColl, C10_City>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="C10_City"/> item from the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to be removed.</param>
        public void Remove(int city_ID)
        {
            foreach (var c10_City in this)
            {
                if (c10_City.City_ID == city_ID)
                {
                    Remove(c10_City);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="C10_City"/> item is in the collection.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C10_City is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int city_ID)
        {
            foreach (var c10_City in this)
            {
                if (c10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="C10_City"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="city_ID">The City_ID of the item to search for.</param>
        /// <returns><c>true</c> if the C10_City is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int city_ID)
        {
            foreach (var c10_City in DeletedList)
            {
                if (c10_City.City_ID == city_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="C10_City"/> item of the <see cref="C09_CityColl"/> collection, based on a given City_ID.
        /// </summary>
        /// <param name="city_ID">The City_ID.</param>
        /// <returns>A <see cref="C10_City"/> object.</returns>
        public C10_City FindC10_CityByCity_ID(int city_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].City_ID.Equals(city_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C09_CityColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="C09_CityColl"/> collection.</returns>
        internal static C09_CityColl NewC09_CityColl()
        {
            return DataPortal.CreateChild<C09_CityColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C09_CityColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent_Region_ID parameter of the C09_CityColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C09_CityColl"/> collection.</returns>
        internal static C09_CityColl GetC09_CityColl(int parent_Region_ID)
        {
            return DataPortal.FetchChild<C09_CityColl>(parent_Region_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C09_CityColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C09_CityColl()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C09_CityColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        protected void Child_Fetch(int parent_Region_ID)
        {
            var args = new DataPortalHookArgs(parent_Region_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<IC09_CityCollDal>();
                var data = dal.Fetch(parent_Region_ID);
                Fetch(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        /// <summary>
        /// Loads all <see cref="C09_CityColl"/> collection items from the given list of C10_CityDto.
        /// </summary>
        /// <param name="data">The list of <see cref="C10_CityDto"/>.</param>
        private void Fetch(List<C10_CityDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(C10_City.GetC10_City(dto));
            }
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region DataPortal Hooks

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
