using System;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B11_City_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="B11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B11_City_Child : BusinessBase<B11_City_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_Child_NameProperty = RegisterProperty<string>(p => p.City_Child_Name, "City Child Name");
        /// <summary>
        /// Gets or sets the City Child Name.
        /// </summary>
        /// <value>The City Child Name.</value>
        public string City_Child_Name
        {
            get { return GetProperty(City_Child_NameProperty); }
            set { SetProperty(City_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B11_City_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B11_City_Child"/> object.</returns>
        internal static B11_City_Child NewB11_City_Child()
        {
            return DataPortal.CreateChild<B11_City_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B11_City_Child"/> object from the given B11_City_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B11_City_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B11_City_Child"/> object.</returns>
        internal static B11_City_Child GetB11_City_Child(B11_City_ChildDto data)
        {
            B11_City_Child obj = new B11_City_Child();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B11_City_Child()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B11_City_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B11_City_Child"/> object from the given <see cref="B11_City_ChildDto"/>.
        /// </summary>
        /// <param name="data">The B11_City_ChildDto to use.</param>
        private void Fetch(B11_City_ChildDto data)
        {
            // Value properties
            LoadProperty(City_Child_NameProperty, data.City_Child_Name);
            // parent properties
            city_ID1 = data.Parent_City_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="B11_City_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B10_City parent)
        {
            var dto = new B11_City_ChildDto();
            dto.Parent_City_ID = parent.City_ID;
            dto.City_Child_Name = City_Child_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IB11_City_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B11_City_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(B10_City parent)
        {
            if (!IsDirty)
                return;

            var dto = new B11_City_ChildDto();
            dto.Parent_City_ID = parent.City_ID;
            dto.City_Child_Name = City_Child_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IB11_City_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B11_City_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(B10_City parent)
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IB11_City_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.City_ID);
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
