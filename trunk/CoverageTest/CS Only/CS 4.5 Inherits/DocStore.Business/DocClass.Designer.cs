//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocClass
// ObjectType:  DocClass
// CSLAType:    EditableRoot

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using DocStore.Business.Security;
using UsingClass;

namespace DocStore.Business
{

    /// <summary>
    /// Classes of document (editable root object).<br/>
    /// This is a generated base class of <see cref="DocClass"/> business object.
    /// </summary>
    [Serializable]
    public partial class DocClass : BusinessBase<DocClass>, IHaveInterface, IHaveGenericInterface<DocClass>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocClassID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocClassIDProperty = RegisterProperty<int>(p => p.DocClassID, "Doc Class ID");
        /// <summary>
        /// use ID = -1 with empty Name for accepting optional specification
        /// </summary>
        /// <value>The Doc Class ID.</value>
        public int DocClassID
        {
            get { return GetProperty(DocClassIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocClassName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocClassNameProperty = RegisterProperty<string>(p => p.DocClassName, "Doc Class Name");
        /// <summary>
        /// Gets or sets the Doc Class Name.
        /// </summary>
        /// <value>The Doc Class Name.</value>
        public string DocClassName
        {
            get { return GetProperty(DocClassNameProperty); }
            set { SetProperty(DocClassNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Date of creation
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CreateUserIDProperty = RegisterProperty<int>(p => p.CreateUserID, "Create User ID");
        /// <summary>
        /// ID of the creating user
        /// </summary>
        /// <value>The Create User ID.</value>
        public int CreateUserID
        {
            get { return GetProperty(CreateUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ChangeDateProperty = RegisterProperty<SmartDate>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Date of last change
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ChangeUserIDProperty = RegisterProperty<int>(p => p.ChangeUserID, "Change User ID");
        /// <summary>
        /// ID of the last changing user
        /// </summary>
        /// <value>The Change User ID.</value>
        public int ChangeUserID
        {
            get { return GetProperty(ChangeUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RowVersion"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<byte[]> RowVersionProperty = RegisterProperty<byte[]>(p => p.RowVersion, "Row Version");
        /// <summary>
        /// Row version counter for concurrency control
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion
        {
            get { return GetProperty(RowVersionProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocClass"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocClass"/> object.</returns>
        public static DocClass NewDocClass()
        {
            return DataPortal.Create<DocClass>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocClass"/> object, based on given parameters.
        /// </summary>
        /// <param name="docClassID">The DocClassID parameter of the DocClass to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocClass"/> object.</returns>
        public static DocClass GetDocClass(int docClassID)
        {
            return DataPortal.Fetch<DocClass>(docClassID);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="DocClass"/> object, based on given parameters.
        /// </summary>
        /// <param name="docClassID">The DocClassID of the DocClass to delete.</param>
        public static void DeleteDocClass(int docClassID)
        {
            DataPortal.Delete<DocClass>(docClassID);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocClass"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewDocClass(EventHandler<DataPortalResult<DocClass>> callback)
        {
            DataPortal.BeginCreate<DocClass>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="DocClass"/> object, based on given parameters.
        /// </summary>
        /// <param name="docClassID">The DocClassID parameter of the DocClass to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetDocClass(int docClassID, EventHandler<DataPortalResult<DocClass>> callback)
        {
            DataPortal.BeginFetch<DocClass>(docClassID, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="DocClass"/> object, based on given parameters.
        /// </summary>
        /// <param name="docClassID">The DocClassID of the DocClass to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void DeleteDocClass(int docClassID, EventHandler<DataPortalResult<DocClass>> callback)
        {
            DataPortal.BeginDelete<DocClass>(docClassID, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocClass"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocClass()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DocClass"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(DocClassIDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="DocClass"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="docClassID">The Doc Class ID.</param>
        protected void DataPortal_Fetch(int docClassID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocClass", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocClassID", docClassID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, docClassID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="DocClass"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocClassIDProperty, dr.GetInt32("DocClassID"));
            LoadProperty(DocClassNameProperty, dr.GetString("DocClassName"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="DocClass"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddDocClass", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocClassID", ReadProperty(DocClassIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@DocClassName", ReadProperty(DocClassNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DocClassIDProperty, (int) cmd.Parameters["@DocClassID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocClass"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDocClass", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocClassID", ReadProperty(DocClassIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocClassName", ReadProperty(DocClassNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId);
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty));
            }
        }

        /// <summary>
        /// Self deletes the <see cref="DocClass"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(DocClassID);
        }

        /// <summary>
        /// Deletes the <see cref="DocClass"/> object from database.
        /// </summary>
        /// <param name="docClassID">The delete criteria.</param>
        protected void DataPortal_Delete(int docClassID)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteDocClass", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocClassID", docClassID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, docClassID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                ctx.Commit();
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
