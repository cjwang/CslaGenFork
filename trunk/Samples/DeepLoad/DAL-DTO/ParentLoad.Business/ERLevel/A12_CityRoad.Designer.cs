using System;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A12_CityRoad (editable child object).<br/>
    /// This is a generated base class of <see cref="A12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A12_CityRoad : BusinessBase<A12_CityRoad>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_City_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="CityRoad_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CityRoad_IDProperty = RegisterProperty<int>(p => p.CityRoad_ID, "City Road ID");
        /// <summary>
        /// Gets the City Road ID.
        /// </summary>
        /// <value>The City Road ID.</value>
        public int CityRoad_ID
        {
            get { return GetProperty(CityRoad_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CityRoad_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CityRoad_NameProperty = RegisterProperty<string>(p => p.CityRoad_Name, "City Road Name");
        /// <summary>
        /// Gets or sets the City Road Name.
        /// </summary>
        /// <value>The City Road Name.</value>
        public string CityRoad_Name
        {
            get { return GetProperty(CityRoad_NameProperty); }
            set { SetProperty(CityRoad_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A12_CityRoad"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="A12_CityRoad"/> object.</returns>
        internal static A12_CityRoad NewA12_CityRoad()
        {
            return DataPortal.CreateChild<A12_CityRoad>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A12_CityRoad"/> object from the given A12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="A12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A12_CityRoad"/> object.</returns>
        internal static A12_CityRoad GetA12_CityRoad(A12_CityRoadDto data)
        {
            A12_CityRoad obj = new A12_CityRoad();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A12_CityRoad()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="A12_CityRoad"/> object properties.
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
        /// Loads a <see cref="A12_CityRoad"/> object from the given <see cref="A12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The A12_CityRoadDto to use.</param>
        private void Fetch(A12_CityRoadDto data)
        {
            // Value properties
            LoadProperty(CityRoad_IDProperty, data.CityRoad_ID);
            LoadProperty(CityRoad_NameProperty, data.CityRoad_Name);
            // parent properties
            parent_City_ID = data.Parent_City_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="A12_CityRoad"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(A10_City parent)
        {
            var dto = new A12_CityRoadDto();
            dto.Parent_City_ID = parent.City_ID;
            dto.CityRoad_Name = CityRoad_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IA12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(CityRoad_IDProperty, resultDto.CityRoad_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="A12_CityRoad"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            var dto = new A12_CityRoadDto();
            dto.CityRoad_ID = CityRoad_ID;
            dto.CityRoad_Name = CityRoad_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IA12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="A12_CityRoad"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IA12_CityRoadDal>();
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
