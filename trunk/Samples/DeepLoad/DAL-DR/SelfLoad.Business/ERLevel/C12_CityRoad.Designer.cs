using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C12_CityRoad (editable child object).<br/>
    /// This is a generated base class of <see cref="C12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="C11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C12_CityRoad : BusinessBase<C12_CityRoad>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="CityRoad_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CityRoad_IDProperty = RegisterProperty<int>(p => p.CityRoad_ID, "CityRoads ID");
        /// <summary>
        /// Gets the CityRoads ID.
        /// </summary>
        /// <value>The CityRoads ID.</value>
        public int CityRoad_ID
        {
            get { return GetProperty(CityRoad_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CityRoad_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CityRoad_NameProperty = RegisterProperty<string>(p => p.CityRoad_Name, "CityRoads Name");
        /// <summary>
        /// Gets or sets the CityRoads Name.
        /// </summary>
        /// <value>The CityRoads Name.</value>
        public string CityRoad_Name
        {
            get { return GetProperty(CityRoad_NameProperty); }
            set { SetProperty(CityRoad_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C12_CityRoad"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="C12_CityRoad"/> object.</returns>
        internal static C12_CityRoad NewC12_CityRoad()
        {
            return DataPortal.CreateChild<C12_CityRoad>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="C12_CityRoad"/> object.</returns>
        internal static C12_CityRoad GetC12_CityRoad(SafeDataReader dr)
        {
            C12_CityRoad obj = new C12_CityRoad();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C12_CityRoad()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="C12_CityRoad"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(CityRoad_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="C12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(CityRoad_IDProperty, dr.GetInt32("CityRoad_ID"));
            LoadProperty(CityRoad_NameProperty, dr.GetString("CityRoad_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="C12_CityRoad"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(C10_City parent)
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IC12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    int cityRoad_ID = -1;
                    dal.Insert(
                        parent.City_ID,
                        out cityRoad_ID,
                        CityRoad_Name
                        );
                    LoadProperty(CityRoad_IDProperty, cityRoad_ID);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="C12_CityRoad"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IC12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        CityRoad_ID,
                        CityRoad_Name
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="C12_CityRoad"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IC12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(CityRoad_IDProperty));
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
