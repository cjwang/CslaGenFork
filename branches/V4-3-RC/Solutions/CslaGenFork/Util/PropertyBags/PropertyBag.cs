/********************************************************************
*
*  PropertyBag.cs
*  --------------
*  Derived from PropertyBag.cs by Tony Allowatt
*  CodeProject: http://www.codeproject.com/cs/miscctrl/bending_property.asp
*  Last Update: 04/05/2005
*
********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Reflection;
using CslaGenerator.Attributes;
using CslaGenerator.CodeGen;
using CslaGenerator.Metadata;

namespace CslaGenerator.Util.PropertyBags
{
    // to set PropertyGrid Form height
    // PropertyCollectionForm.HandleFormCollectionType
    // 1 row = 16 pixels

    #region PropertySpec class

    /// <summary>
    /// Summary description for PropertySpec.
    /// </summary>
    public class PropertySpec
    {
        private Attribute[] attributes;
        private string name;
        private string category;
        private string description;
        private object defaultValue;
        private string type;
        private string editor;
        private string typeConverter;
        private Type targetClass;
        private object targetObject = null;
        private string targetProperty = "";
        private string helpTopic = "";
        private bool isReadonly = false;
        private bool isBrowsable = true;
        private string designerTypename = "";
        private bool isBindable = true;

        //public PropertySpec(string name, object type, object typeconverter, string category, string description, object defaultValue, object tarObject, string tarProperty, string helptopic)
        public PropertySpec(string name, string type, string category, string description, object defaultValue, string editor, string typeConverter, object tarObject, string tarProperty, string helptopic, bool isreadonly, bool isbrowsable, string designertypename, bool isbindable)
        {
            this.Name = name;
            this.TypeName = type;
            if (this.TypeName == "")
                throw new Exception("Unable to determine PropertySpec type.");
            this.category = category;
            this.description = description;
            this.defaultValue = defaultValue;
            this.editor = editor;
            this.typeConverter = typeConverter;
            this.targetObject = tarObject;
            this.targetProperty = tarProperty;
            this.helpTopic = helptopic;
            this.isReadonly = isreadonly;
            this.isBrowsable = isbrowsable;
            this.designerTypename = designertypename;
            this.isBindable = isbindable;
        }

        #region properties

        /// <summary>
        /// Gets or sets a collection of additional Attributes for this property.  This can
        /// be used to specify attributes beyond those supported intrinsically by the
        /// PropertySpec class, such as ReadOnly and Browsable.
        /// </summary>
        public Attribute[] Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        /// <summary>
        /// Gets or sets the category name of this property.
        /// </summary>
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        /// <summary>
        /// Gets or sets the fully qualified name of the type converter
        /// type for this property (as string).
        /// </summary>
        public string ConverterTypeName
        {
            get { return typeConverter; }
            set { typeConverter = value; }
        }

        /// <summary>
        /// Gets or sets the default value of this property.
        /// </summary>
        public object DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        /// <summary>
        /// Gets or sets the help text description of this property.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Gets or sets the fully qualified name of the editor type for
        /// this property (as string).
        /// </summary>
        public string EditorTypeName
        {
            get { return editor; }
            set { editor = value; }
        }

        /// <summary>
        /// Gets or sets the name of this property.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the fully qualfied name of the type of this
        /// property (as string).
        /// </summary>
        public string TypeName
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Gets or sets the boolean flag indicating if this property
        /// is readonly
        /// </summary>
        public bool ReadOnly
        {
            get { return isReadonly; }
            set { isReadonly = value; }
        }

        /// <summary>
        /// Gets or sets the boolean flag indicating if this property
        /// is browsable (i.e. visible in PropertyGrid
        /// </summary>
        public bool Browsable
        {
            get { return isBrowsable; }
            set { isBrowsable = value; }
        }

        /// <summary>
        /// Gets or sets the boolean flag indicating if this property
        /// is bindable
        /// </summary>
        public bool Bindable
        {
            get { return isBindable; }
            set { isBindable = value; }
        }

        /// <summary>
        /// Test
        ///
        /// </summary>
        public Type TargetClass
        {
            get { return targetClass; }
            set { targetClass = value; }
        }

        /// <summary>
        /// Gets or sets the target object which is the owner of the
        /// properties displayed in the PropertyGrid
        /// </summary>
        public object TargetObject
        {
            get { return targetObject; }
            set { targetObject = value; }
        }

        /// <summary>
        /// Gets or sets the target property in the target object
        /// associated with the PropertyGrid item
        /// </summary>
        public string TargetProperty
        {
            get { return targetProperty; }
            set { targetProperty = value; }
        }

        /// <summary>
        /// Gets or sets the help topic key associated with this
        /// PropertyGrid item
        /// </summary>
        public string HelpTopic
        {
            get { return helpTopic; }
            set { helpTopic = value; }
        }

        #endregion
    }

    /// <summary>
    /// Provides data for the GetValue and SetValue events of the PropertyBag class.
    /// </summary>
    public class PropertySpecEventArgs : EventArgs
    {
        private PropertySpec property;
        private object val;

        /// <summary>
        /// Initializes a new instance of the PropertySpecEventArgs class.
        /// </summary>
        /// <param name="property">The PropertySpec that represents the property whose
        /// value is being requested or set.</param>
        /// <param name="val">The current value of the property.</param>
        public PropertySpecEventArgs(PropertySpec property, object val)
        {
            this.property = property;
            this.val = val;
        }

        /// <summary>
        /// Gets the PropertySpec that represents the property whose value is being
        /// requested or set.
        /// </summary>
        public PropertySpec Property
        {
            get { return property; }
        }

        /// <summary>
        /// Gets or sets the current value of the property.
        /// </summary>
        public object Value
        {
            get { return val; }
            set { val = value; }
        }
    }

    /// <summary>
    /// Represents the method that will handle the GetValue and SetValue events of the
    /// PropertyBag class.
    /// </summary>
    public delegate void PropertySpecEventHandler(object sender, PropertySpecEventArgs e);


    #endregion

    /// <summary>
    /// Represents a collection of custom properties that can be selected into a
    /// PropertyGrid to provide functionality beyond that of the simple reflection
    /// normally used to query an object's properties.
    /// </summary>
    public class PropertyBag : ICustomTypeDescriptor
    {
        #region PropertySpecCollection class definition

        /// <summary>
        /// Encapsulates a collection of PropertySpec objects.
        /// </summary>
        [Serializable]
        public class PropertySpecCollection : IList
        {
            private ArrayList innerArray;

            /// <summary>
            /// Initializes a new instance of the PropertySpecCollection class.
            /// </summary>
            public PropertySpecCollection()
            {
                innerArray = new ArrayList();
            }

            /// <summary>
            /// Gets the number of elements in the PropertySpecCollection.
            /// </summary>
            /// <value>
            /// The number of elements contained in the PropertySpecCollection.
            /// </value>
            public int Count
            {
                get { return innerArray.Count; }
            }

            /// <summary>
            /// Gets a value indicating whether the PropertySpecCollection has a fixed size.
            /// </summary>
            /// <value>
            /// true if the PropertySpecCollection has a fixed size; otherwise, false.
            /// </value>
            public bool IsFixedSize
            {
                get { return false; }
            }

            /// <summary>
            /// Gets a value indicating whether the PropertySpecCollection is read-only.
            /// </summary>
            public bool IsReadOnly
            {
                get { return false; }
            }

            /// <summary>
            /// Gets a value indicating whether access to the collection is synchronized (thread-safe).
            /// </summary>
            /// <value>
            /// true if access to the PropertySpecCollection is synchronized (thread-safe); otherwise, false.
            /// </value>
            public bool IsSynchronized
            {
                get { return false; }
            }

            /// <summary>
            /// Gets an object that can be used to synchronize access to the collection.
            /// </summary>
            /// <value>
            /// An object that can be used to synchronize access to the collection.
            /// </value>
            object ICollection.SyncRoot
            {
                get { return null; }
            }

            /// <summary>
            /// Gets or sets the element at the specified index.
            /// In C#, this property is the indexer for the PropertySpecCollection class.
            /// </summary>
            /// <param name="index">The zero-based index of the element to get or set.</param>
            /// <value>
            /// The element at the specified index.
            /// </value>
            public PropertySpec this[int index]
            {
                get { return (PropertySpec)innerArray[index]; }
                set { innerArray[index] = value; }
            }

            /// <summary>
            /// Adds a PropertySpec to the end of the PropertySpecCollection.
            /// </summary>
            /// <param name="value">The PropertySpec to be added to the end of the PropertySpecCollection.</param>
            /// <returns>The PropertySpecCollection index at which the value has been added.</returns>
            public int Add(PropertySpec value)
            {
                int index = innerArray.Add(value);

                return index;
            }

            /// <summary>
            /// Adds the elements of an array of PropertySpec objects to the end of the PropertySpecCollection.
            /// </summary>
            /// <param name="array">The PropertySpec array whose elements should be added to the end of the
            /// PropertySpecCollection.</param>
            public void AddRange(PropertySpec[] array)
            {
                innerArray.AddRange(array);
            }

            /// <summary>
            /// Removes all elements from the PropertySpecCollection.
            /// </summary>
            public void Clear()
            {
                innerArray.Clear();
            }

            /// <summary>
            /// Determines whether a PropertySpec is in the PropertySpecCollection.
            /// </summary>
            /// <param name="item">The PropertySpec to locate in the PropertySpecCollection. The element to locate
            /// can be a null reference (Nothing in Visual Basic).</param>
            /// <returns>true if item is found in the PropertySpecCollection; otherwise, false.</returns>
            public bool Contains(PropertySpec item)
            {
                return innerArray.Contains(item);
            }

            /// <summary>
            /// Determines whether a PropertySpec with the specified name is in the PropertySpecCollection.
            /// </summary>
            /// <param name="name">The name of the PropertySpec to locate in the PropertySpecCollection.</param>
            /// <returns>true if item is found in the PropertySpecCollection; otherwise, false.</returns>
            public bool Contains(string name)
            {
                foreach (PropertySpec spec in innerArray)
                    if (spec.Name == name)
                        return true;

                return false;
            }

            /// <summary>
            /// Copies the entire PropertySpecCollection to a compatible one-dimensional Array, starting at the
            /// beginning of the target array.
            /// </summary>
            /// <param name="array">The one-dimensional Array that is the destination of the elements copied
            /// from PropertySpecCollection. The Array must have zero-based indexing.</param>
            public void CopyTo(PropertySpec[] array)
            {
                innerArray.CopyTo(array);
            }

            /// <summary>
            /// Copies the PropertySpecCollection or a portion of it to a one-dimensional array.
            /// </summary>
            /// <param name="array">The one-dimensional Array that is the destination of the elements copied
            /// from the collection.</param>
            /// <param name="index">The zero-based index in array at which copying begins.</param>
            public void CopyTo(PropertySpec[] array, int index)
            {
                innerArray.CopyTo(array, index);
            }

            /// <summary>
            /// Returns an enumerator that can iterate through the PropertySpecCollection.
            /// </summary>
            /// <returns>An IEnumerator for the entire PropertySpecCollection.</returns>
            public IEnumerator GetEnumerator()
            {
                return innerArray.GetEnumerator();
            }

            /// <summary>
            /// Searches for the specified PropertySpec and returns the zero-based index of the first
            /// occurrence within the entire PropertySpecCollection.
            /// </summary>
            /// <param name="value">The PropertySpec to locate in the PropertySpecCollection.</param>
            /// <returns>The zero-based index of the first occurrence of value within the entire PropertySpecCollection,
            /// if found; otherwise, -1.</returns>
            public int IndexOf(PropertySpec value)
            {
                return innerArray.IndexOf(value);
            }

            /// <summary>
            /// Searches for the PropertySpec with the specified name and returns the zero-based index of
            /// the first occurrence within the entire PropertySpecCollection.
            /// </summary>
            /// <param name="name">The name of the PropertySpec to locate in the PropertySpecCollection.</param>
            /// <returns>The zero-based index of the first occurrence of value within the entire PropertySpecCollection,
            /// if found; otherwise, -1.</returns>
            public int IndexOf(string name)
            {
                int i = 0;

                foreach (PropertySpec spec in innerArray)
                {
                    //if (spec.Name == name)
                    if (spec.TargetProperty == name)
                        return i;

                    i++;
                }

                return -1;
            }

            /// <summary>
            /// Inserts a PropertySpec object into the PropertySpecCollection at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which value should be inserted.</param>
            /// <param name="value">The PropertySpec to insert.</param>
            public void Insert(int index, PropertySpec value)
            {
                innerArray.Insert(index, value);
            }

            /// <summary>
            /// Removes the first occurrence of a specific object from the PropertySpecCollection.
            /// </summary>
            /// <param name="obj">The PropertySpec to remove from the PropertySpecCollection.</param>
            public void Remove(PropertySpec obj)
            {
                innerArray.Remove(obj);
            }

            /// <summary>
            /// Removes the property with the specified name from the PropertySpecCollection.
            /// </summary>
            /// <param name="name">The name of the PropertySpec to remove from the PropertySpecCollection.</param>
            public void Remove(string name)
            {
                int index = IndexOf(name);
                RemoveAt(index);
            }

            /// <summary>
            /// Removes the object at the specified index of the PropertySpecCollection.
            /// </summary>
            /// <param name="index">The zero-based index of the element to remove.</param>
            public void RemoveAt(int index)
            {
                innerArray.RemoveAt(index);
            }

            /// <summary>
            /// Copies the elements of the PropertySpecCollection to a new PropertySpec array.
            /// </summary>
            /// <returns>A PropertySpec array containing copies of the elements of the PropertySpecCollection.</returns>
            public PropertySpec[] ToArray()
            {
                return (PropertySpec[])innerArray.ToArray(typeof(PropertySpec));
            }

            #region Explicit interface implementations for ICollection and IList

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            void ICollection.CopyTo(Array array, int index)
            {
                CopyTo((PropertySpec[])array, index);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            int IList.Add(object value)
            {
                return Add((PropertySpec)value);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            bool IList.Contains(object obj)
            {
                return Contains((PropertySpec)obj);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            object IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    this[index] = (PropertySpec)value;
                }
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            int IList.IndexOf(object obj)
            {
                return IndexOf((PropertySpec)obj);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            void IList.Insert(int index, object value)
            {
                Insert(index, (PropertySpec)value);
            }

            /// <summary>
            /// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
            /// </summary>
            void IList.Remove(object value)
            {
                Remove((PropertySpec)value);
            }

            #endregion
        }

        #endregion

        #region PropertySpecDescriptor class definition

        private class PropertySpecDescriptor : PropertyDescriptor
        {
            private PropertyBag bag;
            private PropertySpec item;

            public PropertySpecDescriptor(PropertySpec item, PropertyBag bag, string name, Attribute[] attrs)
                :
            base(name, attrs)
            {
                this.bag = bag;
                this.item = item;
            }

            public override Type ComponentType
            {
                get { return item.GetType(); }
            }

            public override bool IsReadOnly
            {
                get { return (Attributes.Matches(ReadOnlyAttribute.Yes)); }
            }

            public override Type PropertyType
            {
                get { return Type.GetType(item.TypeName); }
            }

            public override bool CanResetValue(object component)
            {
                if (item.DefaultValue == null)
                    return false;

                return !GetValue(component).Equals(item.DefaultValue);
            }

            public override object GetValue(object component)
            {
                // Have the property bag raise an event to get the current value
                // of the property.

                PropertySpecEventArgs e = new PropertySpecEventArgs(item, null);
                bag.OnGetValue(e);
                return e.Value;
            }

            public override void ResetValue(object component)
            {
                SetValue(component, item.DefaultValue);
            }

            public override void SetValue(object component, object value)
            {
                // Have the property bag raise an event to set the current value
                // of the property.

                PropertySpecEventArgs e = new PropertySpecEventArgs(item, value);
                bag.OnSetValue(e);
            }

            public override bool ShouldSerializeValue(object component)
            {
                object val = this.GetValue(component);

                if (item.DefaultValue == null && val == null)
                    return false;

                return !val.Equals(item.DefaultValue);
            }
        }

        #endregion

        #region Properties and Events

        private string defaultProperty;
        private PropertySpecCollection _properties;
        private CslaObjectInfo[] _selectedObject;
        private PropertyContext _propertyContext;

        /// <summary>
        /// Initializes a new instance of the PropertyBag class.
        /// </summary>
        public PropertyBag()
        {
            defaultProperty = null;
            _properties = new PropertySpecCollection();
        }

        public PropertyBag(CslaObjectInfo obj)
            : this(new CslaObjectInfo[] { obj })
        { }

        public PropertyBag(CslaObjectInfo[] obj)
        {
            defaultProperty = null;
            _properties = new PropertySpecCollection();
            _selectedObject = obj;
            InitPropertyBag();
        }

        public PropertyBag(CslaObjectInfo obj, PropertyContext context)
            : this(new CslaObjectInfo[] { obj }, context)
        { }

        public PropertyBag(CslaObjectInfo[] obj, PropertyContext context)
        {
            defaultProperty = "ObjectName";
            _properties = new PropertySpecCollection();
            _selectedObject = obj;
            _propertyContext = context;
            InitPropertyBag();
        }

        /// <summary>
        /// Gets or sets the name of the default property in the collection.
        /// </summary>
        public string DefaultProperty
        {
            get { return defaultProperty; }
            set { defaultProperty = value; }
        }

        /// <summary>
        /// Gets or sets the name of the default property in the collection.
        /// </summary>
        public CslaObjectInfo[] SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                _selectedObject = value;
                InitPropertyBag();
            }
        }

        /// <summary>
        /// Gets or sets the property context.
        /// </summary>
        public PropertyContext PropertyContext
        {
            get { return _propertyContext; }
            set
            {
                _propertyContext = value;
            }
        }

        /// <summary>
        /// Gets the collection of properties contained within this PropertyBag.
        /// </summary>
        public PropertySpecCollection Properties
        {
            get { return _properties; }
        }

        /// <summary>
        /// Occurs when a PropertyGrid requests the value of a property.
        /// </summary>
        public event PropertySpecEventHandler GetValue;

        /// <summary>
        /// Occurs when the user changes the value of a property in a PropertyGrid.
        /// </summary>
        public event PropertySpecEventHandler SetValue;

        /// <summary>
        /// Raises the GetValue event.
        /// </summary>
        /// <param name="e">A PropertySpecEventArgs that contains the event data.</param>
        protected virtual void OnGetValue(PropertySpecEventArgs e)
        {
            if (e.Value != null)
                GetValue(this, e);
            e.Value = getProperty(e.Property.TargetObject, e.Property.TargetProperty, e.Property.DefaultValue);
        }

        /// <summary>
        /// Raises the SetValue event.
        /// </summary>
        /// <param name="e">A PropertySpecEventArgs that contains the event data.</param>
        protected virtual void OnSetValue(PropertySpecEventArgs e)
        {
            if (SetValue != null)
                SetValue(this, e);
            setProperty(e.Property.TargetObject, e.Property.TargetProperty, e.Value);
        }

        #endregion

        #region Initialize Propertybag

        private void InitPropertyBag()
        {
            PropertyInfo pi;
            Type t = typeof(CslaObjectInfo);// mSelectedObject.GetType();
            PropertyInfo[] props = t.GetProperties();
            // Display information for all properties.
            for (int i = 0; i < props.Length; i++)
            {
                pi = (PropertyInfo)props[i];
                Object[] myAttributes = pi.GetCustomAttributes(true);
                string category = "";
                string description = "";
                bool isreadonly = false;
                bool isbrowsable = true;
                object defaultvalue = null;
                string defaultproperty = "";
                string userfriendlyname = "";
                string typeconverter = "";
                string designertypename = "";
                string helptopic = "";
                bool bindable = true;
                string editor = "";
                for (int n = 0; n < myAttributes.Length; n++)
                {

                    Attribute a = (Attribute)myAttributes[n];
                    switch (a.GetType().ToString())
                    {
                        case "System.ComponentModel.CategoryAttribute":
                            category = ((CategoryAttribute)a).Category;
                            break;
                        case "System.ComponentModel.DescriptionAttribute":
                            description = ((DescriptionAttribute)a).Description;
                            break;
                        case "System.ComponentModel.ReadOnlyAttribute":
                            isreadonly = ((ReadOnlyAttribute)a).IsReadOnly;
                            break;
                        case "System.ComponentModel.BrowsableAttribute":
                            isbrowsable = ((BrowsableAttribute)a).Browsable;
                            break;
                        case "System.ComponentModel.DefaultValueAttribute":
                            defaultvalue = ((DefaultValueAttribute)a).Value;
                            break;
                        case "System.ComponentModel.DefaultPropertyAttribute":
                            defaultproperty = ((DefaultPropertyAttribute)a).Name;
                            break;
                        case "CslaGenerator.Attributes.UserFriendlyNameAttribute":
                            userfriendlyname = ((UserFriendlyNameAttribute)a).UserFriendlyName;
                            break;
                        case "CslaGenerator.Attributes.HelpTopicAttribute":
                            helptopic = ((HelpTopicAttribute)a).HelpTopic;
                            break;
                        case "System.ComponentModel.TypeConverterAttribute":
                            typeconverter = ((TypeConverterAttribute)a).ConverterTypeName;
                            break;
                        case "System.ComponentModel.DesignerAttribute":
                            designertypename = ((DesignerAttribute)a).DesignerTypeName;
                            break;
                        case "System.ComponentModel.BindableAttribute":
                            bindable = ((BindableAttribute)a).Bindable;
                            break;
                        case "System.ComponentModel.EditorAttribute":
                            editor = ((EditorAttribute)a).EditorTypeName;
                            break;
                    }
                }
                userfriendlyname = userfriendlyname.Length > 0 ? userfriendlyname : pi.Name;
                var types = new List<CslaObjectInfo>();
                foreach (CslaObjectInfo obj in _selectedObject)
                {
                    if (!types.Contains(obj))
                        types.Add(obj);
                }
                // here get rid of ComponentName and Parent
                bool IsValidProperty = (pi.Name != "Properties" && pi.Name != "ComponentName" && pi.Name != "Parent");
                if (IsValidProperty && IsBrowsable(types.ToArray(), pi.Name))
                {
                    // CR added missing parameters
                    //this.Properties.Add(new PropertySpec(userfriendlyname,pi.PropertyType.AssemblyQualifiedName,category,description,defaultvalue, editor, typeconverter, mSelectedObject, pi.Name,helptopic));
                    this.Properties.Add(new PropertySpec(userfriendlyname, pi.PropertyType.AssemblyQualifiedName, category, description, defaultvalue, editor, typeconverter, _selectedObject, pi.Name, helptopic, isreadonly, isbrowsable, designertypename, bindable));
                }
            }
        }

        #endregion

        private Dictionary<string, PropertyInfo> propertyInfoCache = new Dictionary<string, PropertyInfo>();

        private PropertyInfo GetPropertyInfoCache(string propertyName)
        {
            if (!propertyInfoCache.ContainsKey(propertyName))
            {
                propertyInfoCache.Add(propertyName, typeof(CslaObjectInfo).GetProperty(propertyName));
            }
            return propertyInfoCache[propertyName];
        }

        private bool IsEnumerable(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
                return false;
            Type[] interfaces = prop.PropertyType.GetInterfaces();
            foreach (Type typ in interfaces)
                if (typ.Name.Contains("IEnumerable"))
                    return true;
            return false;
        }

        #region IsBrowsable map objectType:propertyName -> true | false

        private bool IsBrowsable(CslaObjectInfo[] objectType, string propertyName)
        {
            try
            {
                // Use PropertyContext class to determine if the combination
                // objectType + propertyName should be shown in propertygrid
                // else default to true (show it)
                // objectType + propertyName --> true | false
                if (_propertyContext != null)
                {
                    foreach (var cslaObject in objectType)
                    {
                        var canHaveParentProperties = CslaTemplateHelperCS.CanHaveParentProperties(cslaObject);
                        var cslaParent = new CslaObjectInfo();
                        if (cslaObject.ParentType != string.Empty)
                            cslaParent = cslaObject.Parent.CslaObjects.Find(cslaObject.ParentType);

                        if (!GeneratorController.Current.CurrentUnit.GenerationParams.ActiveObjects &&
                            (propertyName == "PublishToChannel" ||
                            propertyName == "SubscribeToChannel"))
                            return false;
                        if ((GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == AuthorizationLevel.None ||
                            GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == AuthorizationLevel.PropertyLevel ||
                            ((cslaObject.AuthzProvider == AuthorizationProvider.Custom) &&
                            !GeneratorController.Current.CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider)) &&
                            (propertyName == "NewRoles" ||
                            propertyName == "GetRoles" ||
                            propertyName == "UpdateRoles" ||
                            propertyName == "DeleteRoles"))
                            return false;
                        if ((GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == AuthorizationLevel.None ||
                            GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == AuthorizationLevel.PropertyLevel ||
                            ((cslaObject.AuthzProvider == AuthorizationProvider.IsInRole ||
                            cslaObject.AuthzProvider == AuthorizationProvider.IsNotInRole) &&
                            !GeneratorController.Current.CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider) ||
                            GeneratorController.Current.CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider) &&
                            (propertyName == "NewAuthzRuleType" ||
                            propertyName == "GetAuthzRuleType" ||
                            propertyName == "UpdateAuthzRuleType" ||
                            propertyName == "DeleteAuthzRuleType"))
                            return false;
                        if (((GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == AuthorizationLevel.None ||
                            GeneratorController.Current.CurrentUnit.GenerationParams.GenerateAuthorization == AuthorizationLevel.PropertyLevel) || 
                            GeneratorController.Current.CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider) && 
                            propertyName == "AuthzProvider")
                            return false;
                        if ((!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All ||
                            (!GeneratorController.Current.CurrentUnit.GenerationParams.GenerateWinForms ||
                            !CslaTemplateHelperCS.IsCollectionType(cslaObject.ObjectType) ||
                            (string.IsNullOrEmpty(cslaObject.InheritedType.Type) &&
                            string.IsNullOrEmpty(cslaObject.InheritedType.ObjectName)))) &&
                            propertyName == "InheritedTypeWinForms")
                            return false;
                        if ((!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All ||
                            (CslaTemplateHelperCS.IsReadOnlyType(cslaObject.ObjectType) && !string.IsNullOrEmpty(cslaObject.ParentType))) &&
                            propertyName == "UseUnitOfWorkType")
                            return false;
                        if (GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All &&
                            !(cslaObject.ObjectType == CslaObjectType.DynamicEditableRoot ||
                            cslaObject.ObjectType == CslaObjectType.ReadOnlyObject) &&
                            propertyName == "AddParentReference")
                            return false;
                        if (GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All &&
                            (propertyName == "DbName" ||
                            propertyName == "HashcodeProperty" ||
                            propertyName == "EqualsProperty" ||
                            propertyName == "LazyLoad" ||
                            propertyName == "CacheResults"))
                            return false;
                        if (cslaObject.ObjectType != CslaObjectType.EditableChild &&
                            propertyName == "DeleteProcedureName")
                            return false;
                        if ((!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All ||
                            cslaObject.ObjectType != CslaObjectType.EditableChild) &&
                            propertyName == "DeleteUseTimestamp")
                            return false;
                        if ((!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All ||
                            cslaObject.ObjectType == CslaObjectType.UnitOfWork) &&
                            propertyName == "CommandTimeout")
                            return false;
                        if (((!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All ||
                            !(cslaObject.ObjectType == CslaObjectType.EditableChild &&
                            (cslaParent == null || CslaTemplateHelperCS.IsCollectionType(cslaParent.ObjectType))))) &&
                            propertyName == "RemoveItem")
                            return false;
                        if (GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All &&
                            (!canHaveParentProperties &&
                            (propertyName == "ParentProperties" || propertyName == "UseParentProperties")))
                            return false;
                        if (!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All &&
                            (propertyName == "ContainsItem" ||
                            propertyName == "UniqueItems" ||
                            propertyName == "SimpleCacheOptions" ||
                            propertyName == "InsertUpdateRunLocal"))
                            return false;
                        if (!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All &&
                            (propertyName == "SupportUpdateProperties" ||
                            propertyName == "UpdateValueProperties" ||
                            propertyName == "UpdaterType"))
                            return false;
                        if (cslaObject.ObjectType != CslaObjectType.UnitOfWork &&
                            (propertyName == "UnitOfWorkProperties" ||
                            propertyName == "UnitOfWorkType"))
                            return false;
                        if (!_propertyContext.ShowProperty(cslaObject.ObjectType.ToString(), propertyName))
                            return false;
                    }
                    if (_selectedObject.Length > 1 && IsEnumerable(GetPropertyInfoCache(propertyName)))
                        return false;
                    return true;
                }

                return true;
            }
            catch //(Exception e)
            {
                Debug.WriteLine(objectType + ":" + propertyName);
                return true;
            }
        }

        #endregion

        #region reflection functions

        private object getField(Type t, string name, object target)
        {
            object obj = null;
            Type tx;

            FieldInfo[] fields;
            //fields = target.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            fields = target.GetType().GetFields(BindingFlags.Public);

            tx = target.GetType();
            obj = tx.InvokeMember(name, BindingFlags.Default | BindingFlags.GetField, null, target, new object[] { });
            return obj;
        }

        private object setField(Type t, string name, object value, object target)
        {
            object obj;
            obj = t.InvokeMember(name, BindingFlags.Default | BindingFlags.SetField, null, target, new object[] { value });
            return obj;
        }

        private bool setProperty(object obj, string propertyName, object val)
        {
            try
            {
                // get a reference to the PropertyInfo, exit if no property with that
                // name
                PropertyInfo pi = typeof(CslaObjectInfo).GetProperty(propertyName);

                if (pi == null)
                    return false;
                // convert the value to the expected type
                val = Convert.ChangeType(val, pi.PropertyType);
                // attempt the assignment
                foreach (CslaObjectInfo bo in (CslaObjectInfo[])obj)
                    pi.SetValue(bo, val, null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private object getProperty(object obj, string propertyName, object defaultValue)
        {
            try
            {
                PropertyInfo pi = GetPropertyInfoCache(propertyName);
                if (!(pi == null))
                {
                    CslaObjectInfo[] objs = (CslaObjectInfo[])obj;
                    ArrayList valueList = new ArrayList();

                    foreach (CslaObjectInfo bo in objs)
                    {
                        object value = pi.GetValue(bo, null);
                        if (!valueList.Contains(value))
                        {
                            valueList.Add(value);
                        }
                    }
                    switch (valueList.Count)
                    {
                        case 1:
                            return valueList[0];
                        default:
                            return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // if property doesn't exist or throws
            return defaultValue;
        }

        #endregion

        #region ICustomTypeDescriptor explicit interface definitions

        // Most of the functions required by the ICustomTypeDescriptor are
        // merely pssed on to the default TypeDescriptor for this type,
        // which will do something appropriate.  The exceptions are noted
        // below.
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            // This function searches the property list for the property
            // with the same name as the DefaultProperty specified, and
            // returns a property descriptor for it.  If no property is
            // found that matches DefaultProperty, a null reference is
            // returned instead.

            PropertySpec propertySpec = null;
            if (defaultProperty != null)
            {
                int index = _properties.IndexOf(defaultProperty);
                propertySpec = _properties[index];
            }

            if (propertySpec != null)
                return new PropertySpecDescriptor(propertySpec, this, propertySpec.Name, null);
            else
                return null;
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            // Rather than passing this function on to the default TypeDescriptor,
            // which would return the actual properties of PropertyBag, I construct
            // a list here that contains property descriptors for the elements of the
            // Properties list in the bag.

            var props = new ArrayList();

            foreach (PropertySpec property in _properties)
            {
                var attrs = new ArrayList();

                // If a category, description, editor, or type converter are specified
                // in the PropertySpec, create attributes to define that relationship.
                if (property.Category != null)
                {
                    if (property.Category == "08. Insert & Update Options")
                    {
                        var cslaObject = (CslaObjectInfo)GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem;
                        if (!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All)
                        {
                            property.Category = "08. Stored Procedure Names";
                        }
                        else if (cslaObject.ObjectType == CslaObjectType.EditableChild)
                        {
                            property.Category = "08. Insert, Update, Delete Options";
                        }
                    }

                    if (!GeneratorController.Current.CurrentUnit.GenerationParams.TargetIsCsla4All &&
                        property.Category == "08. Insert & Update Options")
                        property.Category = "08. Stored Procedure Names";
                    attrs.Add(new CategoryAttribute(property.Category));
                }

                if (property.Description != null)
                    attrs.Add(new DescriptionAttribute(property.Description));

                if (property.EditorTypeName != null)
                    attrs.Add(new EditorAttribute(property.EditorTypeName, typeof(UITypeEditor)));

                if (property.ConverterTypeName != null)
                    attrs.Add(new TypeConverterAttribute(property.ConverterTypeName));

                // Additionally, append the custom attributes associated with the
                // PropertySpec, if any.
                if (property.Attributes != null)
                    attrs.AddRange(property.Attributes);

                if (property.DefaultValue != null)
                    attrs.Add(new DefaultValueAttribute(property.DefaultValue));

                attrs.Add(new BrowsableAttribute(property.Browsable));
                attrs.Add(new ReadOnlyAttribute(property.ReadOnly));
                attrs.Add(new BindableAttribute(property.Bindable));

                Attribute[] attrArray = (Attribute[])attrs.ToArray(typeof(Attribute));

                // Create a new property descriptor for the property item, and add
                // it to the list.
                PropertySpecDescriptor pd = new PropertySpecDescriptor(property,
                    this, property.Name, attrArray);
                props.Add(pd);
            }

            // Convert the list of PropertyDescriptors to a collection that the
            // ICustomTypeDescriptor can use, and return it.
            PropertyDescriptor[] propArray = (PropertyDescriptor[])props.ToArray(
            typeof(PropertyDescriptor));
            return new PropertyDescriptorCollection(propArray);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion

    }
}
