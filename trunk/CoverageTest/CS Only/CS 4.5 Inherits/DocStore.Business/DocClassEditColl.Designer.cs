//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocClassEditColl
// ObjectType:  DocClassEditColl
// CSLAType:    EditableRootCollection

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using UsingClass;

namespace DocStore.Business
{

    /// <summary>
    /// DocClassEditColl (editable root list).<br/>
    /// This is a generated base class of <see cref="DocClassEditColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DocClassEdit"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class DocClassEditColl : BusinessBindingListBase<DocClassEditColl, DocClassEdit>, IHaveInterface, IHaveGenericInterface<DocClassEditColl>
#else
    public partial class DocClassEditColl : BusinessListBase<DocClassEditColl, DocClassEdit>, IHaveInterface, IHaveGenericInterface<DocClassEditColl>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="DocClassEdit"/> item from the collection.
        /// </summary>
        /// <param name="docClassID">The DocClassID of the item to be removed.</param>
        public void Remove(int docClassID)
        {
            foreach (var docClassEdit in this)
            {
                if (docClassEdit.DocClassID == docClassID)
                {
                    Remove(docClassEdit);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="DocClassEdit"/> item is in the collection.
        /// </summary>
        /// <param name="docClassID">The DocClassID of the item to search for.</param>
        /// <returns><c>true</c> if the DocClassEdit is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int docClassID)
        {
            foreach (var docClassEdit in this)
            {
                if (docClassEdit.DocClassID == docClassID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="DocClassEdit"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="docClassID">The DocClassID of the item to search for.</param>
        /// <returns><c>true</c> if the DocClassEdit is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int docClassID)
        {
            foreach (var docClassEdit in DeletedList)
            {
                if (docClassEdit.DocClassID == docClassID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocClassEditColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocClassEditColl"/> collection.</returns>
        public static DocClassEditColl NewDocClassEditColl()
        {
            return DataPortal.Create<DocClassEditColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocClassEditColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="DocClassEditColl"/> collection.</returns>
        public static DocClassEditColl GetDocClassEditColl()
        {
            return DataPortal.Fetch<DocClassEditColl>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocClassEditColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewDocClassEditColl(EventHandler<DataPortalResult<DocClassEditColl>> callback)
        {
            DocClassEditCollGetter.NewDocClassEditCollGetter((o, e) =>
            {
                callback(o, new DataPortalResult<DocClassEditColl>(e.Object.DocClassEditColl, e.Error, null));
            });
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="DocClassEditColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetDocClassEditColl(EventHandler<DataPortalResult<DocClassEditColl>> callback)
        {
            DocClassEditCollGetter.GetDocClassEditCollGetter((o, e) =>
            {
                callback(o, new DataPortalResult<DocClassEditColl>(e.Object.DocClassEditColl, e.Error, null));
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocClassEditColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocClassEditColl()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads a <see cref="DocClassEditColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocClassEditColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="DocClassEditColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DocClassEdit.GetDocClassEdit(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocClassEditColl"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                base.Child_Update();
                ctx.Commit();
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
