using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERLevel;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E05_SubContinent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="E05_SubContinent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E05_SubContinent_ReChild : ReadOnlyBase<E05_SubContinent_ReChild>
    {

        #region State Fields

        private byte[] _rowVersion = new byte[] {};

        [NotUndoable]
        [NonSerialized]
        internal int subContinent_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "Countries Child Name");
        /// <summary>
        /// Gets the Countries Child Name.
        /// </summary>
        /// <value>The Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E05_SubContinent_ReChild"/> object from the given E05_SubContinent_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="E05_SubContinent_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E05_SubContinent_ReChild"/> object.</returns>
        internal static E05_SubContinent_ReChild GetE05_SubContinent_ReChild(E05_SubContinent_ReChildDto data)
        {
            E05_SubContinent_ReChild obj = new E05_SubContinent_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E05_SubContinent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E05_SubContinent_ReChild()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E05_SubContinent_ReChild"/> object from the given <see cref="E05_SubContinent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The E05_SubContinent_ReChildDto to use.</param>
        private void Fetch(E05_SubContinent_ReChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            _rowVersion = data.RowVersion;
            // parent properties
            subContinent_ID2 = data.Parent_SubContinent_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
