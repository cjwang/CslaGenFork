using System;
using System.Collections.Generic;
using Csla;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E07_RegionColl (editable child list).<br/>
    /// This is a generated base class of <see cref="E07_RegionColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="E06_Country"/> editable child object.<br/>
    /// The items of the collection are <see cref="E08_Region"/> objects.
    /// </remarks>
    [Serializable]
    public partial class E07_RegionColl : BusinessListBase<E07_RegionColl, E08_Region>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="E08_Region"/> item from the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to be removed.</param>
        public void Remove(int region_ID)
        {
            foreach (var e08_Region in this)
            {
                if (e08_Region.Region_ID == region_ID)
                {
                    Remove(e08_Region);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="E08_Region"/> item is in the collection.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E08_Region is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int region_ID)
        {
            foreach (var e08_Region in this)
            {
                if (e08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="E08_Region"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="region_ID">The Region_ID of the item to search for.</param>
        /// <returns><c>true</c> if the E08_Region is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int region_ID)
        {
            foreach (var e08_Region in DeletedList)
            {
                if (e08_Region.Region_ID == region_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="E08_Region"/> item of the <see cref="E07_RegionColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="region_ID">The Region_ID.</param>
        /// <returns>A <see cref="E08_Region"/> object.</returns>
        public E08_Region FindE08_RegionByParentProperties(int region_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Region_ID.Equals(region_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E07_RegionColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="E07_RegionColl"/> collection.</returns>
        internal static E07_RegionColl NewE07_RegionColl()
        {
            return DataPortal.CreateChild<E07_RegionColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E07_RegionColl"/> object from the given list of E08_RegionDto.
        /// </summary>
        /// <param name="data">The list of <see cref="E08_RegionDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E07_RegionColl"/> object.</returns>
        internal static E07_RegionColl GetE07_RegionColl(List<E08_RegionDto> data)
        {
            E07_RegionColl obj = new E07_RegionColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E07_RegionColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E07_RegionColl()
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
        /// Loads all <see cref="E07_RegionColl"/> collection items from the given list of E08_RegionDto.
        /// </summary>
        /// <param name="data">The list of <see cref="E08_RegionDto"/>.</param>
        private void Fetch(List<E08_RegionDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(E08_Region.GetE08_Region(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="E08_Region"/> items on the E07_RegionObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="E05_CountryColl"/> collection.</param>
        internal void LoadItems(E05_CountryColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindE06_CountryByParentProperties(item.parent_Country_ID);
                var rlce = obj.E07_RegionObjects.RaiseListChangedEvents;
                obj.E07_RegionObjects.RaiseListChangedEvents = false;
                obj.E07_RegionObjects.Add(item);
                obj.E07_RegionObjects.RaiseListChangedEvents = rlce;
            }
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
