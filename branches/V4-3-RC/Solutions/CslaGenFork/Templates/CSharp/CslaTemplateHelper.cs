using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CslaGenerator;
using CslaGenerator.Metadata;
using CodeSmith.Engine;
using System.Collections.Generic;

namespace CslaGenerator.Util
{
	/// <summary>
	/// Summary description for CslaTemplateHelper.
	/// </summary>
	public class CslaTemplateHelper : CodeTemplate
	{
		public CslaTemplateHelper()
		{
		}

        private CslaGeneratorUnit _CurrentUnit;
        public CslaGeneratorUnit CurrentUnit
        {
            get
            {
                return _CurrentUnit;
            }
            set
            {
                _CurrentUnit = value;
            }
        }

        public CslaPropertyMode PropertyMode
        {
            get
            {
                var pm = _CurrentUnit.GenerationParams.PropertyMode;
                if (pm == CslaPropertyMode.Default)
                    switch (_CurrentUnit.GenerationParams.TargetFramework)
                    {
                        case TargetFramework.CSLA10:
                        case TargetFramework.CSLA20:
                            return CslaPropertyMode.Standard;
                        default:
                            return CslaPropertyMode.Managed;
                    }
                return pm;
            }
        }

		protected int _indentLevel = 0;

		[Browsable(false)]
		public int IndentLevel
		{
			get { return _indentLevel; }
			set { _indentLevel = value; }
		}

        private bool _DataSetLoadingScheme;
        public bool DataSetLoadingScheme
        {
            get
            {
                return _DataSetLoadingScheme;
            }
            set
            {
                _DataSetLoadingScheme = value;
            }
        }

		protected int _resultSetCount = 0;

		public string FormatFieldName(string name)
		{
			return CurrentUnit.Params.FieldNamePrefix + FormatCamel(name);
		}

		public string FormatDelegateName(string name)
		{
            return CurrentUnit.Params.DelegateNamePrefix + FormatCamel(name);
		}

		public string FormatCamel(string name)
		{
			if (name.Length == 2)
				return name.ToLower();
			if (name.Length > 0)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(Char.ToLower(name[0]));
				if (name.Length > 1)
					sb.Append(name.Substring(1));
				return sb.ToString();
			}
			return String.Empty;
		}

        public virtual string LoadProperty(ValueProperty prop, string value)
        {
            if (PropertyMode == CslaPropertyMode.Managed)
                return String.Format("LoadProperty({0}, {1});", FormatManaged(prop.Name), value);
            else
                return String.Format("{0} = {1};", FormatFieldName(prop.Name), value);
        }

        public virtual string ReadProperty(ValueProperty prop)
        {
            if (PropertyMode == CslaPropertyMode.Managed)
                return String.Format("ReadProperty({0})", FormatManaged(prop.Name));
            else
                return FormatFieldName(prop.Name);
        }


        public virtual string GetAttributesString(string[] attributes)
        {
            if (attributes == null || attributes.Length == 0)
                return string.Empty;

            return "[" + string.Join(", ", attributes) + "]";
        }

		public string FormatPascal(string name)
		{
			if (name.Length > 0)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(Char.ToUpper(name[0]));
				if (name.Length > 1)
					sb.Append(name.Substring(1));
				return sb.ToString();
			}
			return String.Empty;
		}

        public string FormatManaged(string name)
        {
            if (name.Length > 0)
            {
                return FormatPascal(name) + "Property";
            }
            return String.Empty;
        }

		public virtual string GetInitValue(TypeCodeEx typeCode)
		{
			if (typeCode == TypeCodeEx.Int16 || typeCode == TypeCodeEx.Int32 || typeCode == TypeCodeEx.Int64 || typeCode == TypeCodeEx.Double
				|| typeCode == TypeCodeEx.Decimal || typeCode == TypeCodeEx.Single) { return "0"; }
			else if (typeCode == TypeCodeEx.String) { return "String.Empty"; }
			else if (typeCode == TypeCodeEx.Boolean) { return "false"; }
			else if (typeCode == TypeCodeEx.Byte) { return "0"; }
			else if (typeCode == TypeCodeEx.Object) { return "null"; }
			else if (typeCode == TypeCodeEx.Guid) { return "Guid.Empty"; }
			else if (typeCode == TypeCodeEx.SmartDate) { return "new SmartDate(true)"; }
            else if (typeCode == TypeCodeEx.DateTime) { return "DateTime.Now"; }
			else if (typeCode == TypeCodeEx.Char) { return "Char.MinValue"; }
            else if (typeCode == TypeCodeEx.ByteArray) { return "new Byte[] {}"; }
            else { return String.Empty; }
		}

        public virtual string GetInitValue(ValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "null";
            else
                return GetInitValue(prop.PropertyType);
        }

		public virtual string GetReaderAssignmentStatement(ValueProperty prop)
		{
			return GetReaderAssignmentStatement(prop,false);
		}

		public virtual string GetReaderAssignmentStatement(ValueProperty prop, bool Structure)
		{
			string statement; 
			if (Structure)
				statement = "nfo." + prop.Name + " = ";
			else
				statement = FormatFieldName(prop.Name) + " = ";

			statement += GetDataReaderStatement(prop) + ";";

			return statement;
		}
        public virtual string GetDataReaderStatement(ValueProperty prop)
        {
            bool nullable = AllowNull(prop);
            string statement = string.Empty;

            if (nullable)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    statement += string.Format("!dr.IsDBNull(\"{0}\") ? new {1}(", prop.ParameterName, GetDataType(prop));
                else
                    statement += string.Format("!dr.IsDBNull(\"{0}\") ? ", prop.ParameterName);
            }
            statement += "dr.";

            if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                statement += GetReaderMethod(prop.PropertyType);
            else
                statement += GetReaderMethod(GetDbType(prop.DbBindColumn), prop.PropertyType);

            statement += "(\"" + prop.ParameterName + "\"";
            
            if (prop.PropertyType == TypeCodeEx.SmartDate)
                statement += ", true";

            statement += ")";
            if (nullable)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    statement += ")";
                statement += " : null";
            }
            if (prop.PropertyType == TypeCodeEx.ByteArray)
                statement = "(" + statement + ") as Byte[]";
            return statement;
        }
        public bool AllowNull(Property prop)
        {
            return (GeneratorController.Current.CurrentUnit.GenerationParams.NullableSupport && prop.Nullable && prop.PropertyType != TypeCodeEx.SmartDate);
        }
		public virtual string GetParameterSet(Property prop, bool Criteria)
		{
            bool nullable = AllowNull(prop);
			string propName;
			propName = (Criteria) ? "crit." + FormatPascal(prop.Name) : FormatFieldName(prop.Name);

            if (nullable && prop.PropertyType != TypeCodeEx.SmartDate)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    return string.Format("{0} == null ? (object)DBNull.Value : {0}.Value", propName);
                else
                    return string.Format("{0} == null ? (object)DBNull.Value : {0}", propName);
            }
			switch (prop.PropertyType)
			{
				case Metadata.TypeCodeEx.SmartDate:
					return propName + ".DBValue";
				case Metadata.TypeCodeEx.Guid:
					return propName + ".Equals(Guid.Empty) ? (object)DBNull.Value : " + propName;
				default:
					return propName;
			}
		}
		
		public virtual string GetParameterSet(Property prop)
		{
			return GetParameterSet(prop,false);
		}
		protected DbType GetDbType(DbBindColumn prop)
		{
			if (prop.NativeType == "real")
				return DbType.Single;
			return prop.DataType;
		}

		//public string GetParamInstanciation()
        public virtual string GetDataType(Property prop)
        {
            string type = GetDataType(prop.PropertyType);
            if (this.AllowNull(prop))
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    type += "?";
            }
            return type;
        }

        protected virtual string GetDataType(TypeCodeEx type)
        {
            if (type == TypeCodeEx.ByteArray)
                return "Byte[]";

            return type.ToString();
        }
		protected internal string GetReaderMethod(DbType dataType, TypeCodeEx propertyType)
		{
			switch (dataType)
			{
				case DbType.Byte: return "GetByte";
				case DbType.Int16: return "GetInt16";
				case DbType.Int32: return "GetInt32";
				case DbType.Int64: return "GetInt64";
				case DbType.AnsiStringFixedLength: return "GetChar";
				case DbType.AnsiString: return "GetString";
				case DbType.String: return "GetString";
				case DbType.StringFixedLength: return "GetString";
				case DbType.Boolean: return "GetBoolean";
				case DbType.Guid: return "GetGuid";
				case DbType.Currency: return "GetDecimal";
				case DbType.Decimal: return "GetDecimal";
                case DbType.DateTime:
                case DbType.Date: return (propertyType == TypeCodeEx.SmartDate) ? "GetSmartDate" : "GetDateTime";
				case DbType.Binary: return "GetValue";
				case DbType.Single: return "GetFloat";
				case DbType.Double: return "GetDouble";
				default: return "GetValue";
			}
		}

        public string GetReaderMethod(TypeCodeEx dataType)
        {
            switch (dataType)
            {
                case TypeCodeEx.Byte: return "GetByte";
                case TypeCodeEx.Int16: return "GetInt16";
                case TypeCodeEx.Int32: return "GetInt32";
                case TypeCodeEx.Int64: return "GetInt64";
                case TypeCodeEx.String: return "GetString";
                case TypeCodeEx.Boolean: return "GetBoolean";
                case TypeCodeEx.Guid: return "GetGuid";
                case TypeCodeEx.Decimal: return "GetDecimal";
                case TypeCodeEx.SmartDate: return "GetSmartDate";
                case TypeCodeEx.DateTime: return "GetDateTime";
                case TypeCodeEx.ByteArray: return "GetValue";
                case TypeCodeEx.Single: return "GetFloat";
                case TypeCodeEx.Double: return "GetDouble";
                case TypeCodeEx.Char: return "GetChar";
                default: return "GetValue";
            }
        }
        /// <summary>
        /// This one is only used for casting values that coume OUT of db command parameters (commonly identity keys).
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected internal virtual string GetLanguageVariableType(DbType dataType)
        {
            switch (dataType)
            {
                case DbType.AnsiString: return "string";
                case DbType.AnsiStringFixedLength: return "string";
                case DbType.Binary: return "byte[]";
                case DbType.Boolean: return "bool";
                case DbType.Byte: return "byte";
                case DbType.Currency: return "decimal";
                case DbType.Date:
                case DbType.DateTime: return "DateTime";
                case DbType.Decimal: return "decimal";
                case DbType.Double: return "double";
                case DbType.Guid: return "Guid";
                case DbType.Int16: return "short";
                case DbType.Int32: return "int";
                case DbType.Int64: return "long";
                case DbType.Object: return "object";
                case DbType.SByte: return "sbyte";
                case DbType.Single: return "float";
                case DbType.String: return "string";
                case DbType.StringFixedLength: return "string";
                case DbType.Time: return "TimeSpan";
                case DbType.UInt16: return "ushort";
                case DbType.UInt32: return "uint";
                case DbType.UInt64: return "ulong";
                case DbType.VarNumeric: return "decimal";
                default: return "__UNKNOWN__" + dataType.ToString();
            }
        }

		public string GetRelationStrings(CslaObjectInfo info)
		{
			if (IsCollectionType(info.ObjectType))
				info = FindChildInfo(info,info.ItemType);
	
			StringBuilder sb = new StringBuilder();
	
			foreach (ChildProperty child in info.ChildProperties)
				if (!child.LazyLoad)
				{
					sb.Append(GetRelationString(info,child));
					sb.Append(Environment.NewLine);
					CslaObjectInfo grandchildInfo = FindChildInfo(info,child.Name);
					if (grandchildInfo != null)
						sb.Append(GetRelationStrings(grandchildInfo));
				}
		
			foreach (ChildProperty child in info.InheritedChildProperties)
				if (!child.LazyLoad)
				{
					sb.Append(GetRelationString(info,child));
					sb.Append(Environment.NewLine);
					CslaObjectInfo grandchildInfo = FindChildInfo(info,child.Name);
					if (grandchildInfo != null)
						sb.Append(GetRelationStrings(grandchildInfo));
				}
	
			foreach (ChildProperty child in info.ChildCollectionProperties)
				if (!child.LazyLoad)
				{
					sb.Append(GetRelationString(info,child));
					sb.Append(Environment.NewLine);
					CslaObjectInfo grandchildInfo = FindChildInfo(info,child.Name);
					if (grandchildInfo != null)
						sb.Append(GetRelationStrings(grandchildInfo));
				}

			foreach (ChildProperty child in info.InheritedChildCollectionProperties)
				if (!child.LazyLoad)
				{
					sb.Append(GetRelationString(info,child));
					sb.Append(Environment.NewLine);
					CslaObjectInfo grandchildInfo = FindChildInfo(info,child.Name);
					if (grandchildInfo != null)
						sb.Append(GetRelationStrings(grandchildInfo));
				}
	
			return sb.ToString();
		}

		public virtual string GetRelationString(CslaObjectInfo info, ChildProperty child)
		{
			string indent = new string('\t', _indentLevel);

			StringBuilder sb = new StringBuilder();
			CslaObjectInfo childInfo = FindChildInfo(info,child.TypeName);
			string joinColumn = String.Empty;
			if (child.LoadParameters.Count > 0)
			{
				if (IsCollectionType(childInfo.ObjectType))
				{
					joinColumn = child.LoadParameters[0].Property.Name;
					childInfo = FindChildInfo(info,childInfo.ItemType);
				}
				if (joinColumn == String.Empty)
				{
					joinColumn = child.LoadParameters[0].Property.Name;	
				}
			}
	
			sb.Append(indent);
			sb.Append("ds.Relations.Add(\"");
			sb.Append(info.ObjectName);
			sb.Append(childInfo.ObjectName);
			sb.Append("\", ds.Tables[");
			sb.Append(_resultSetCount.ToString());
			sb.Append("].Columns[\"");
			sb.Append(joinColumn);
			sb.Append("\"], ds.Tables[");
			sb.Append((_resultSetCount + 1).ToString());
			sb.Append("].Columns[\"");
			sb.Append(joinColumn);
			sb.Append("\"], false);");
	
			_resultSetCount++;
			return sb.ToString();
		}

		public virtual string GetXmlCommentString(string xmlComment)
		{
			string indent = new string('\t', _indentLevel);

			// add leading indent and comment sign 
			xmlComment = indent + "/// " + xmlComment;

			return Regex.Replace(xmlComment, "\n", "\n" + indent + "/// ", RegexOptions.Multiline);
		}

		public virtual string GetUsingStatementsString(CslaObjectInfo info)
		{
			string[] usingNamespaces = GetNamespaces(info);

			string result = String.Empty;
			foreach (string namespaceName in usingNamespaces)
                result += "using " + namespaceName + ";" + Environment.NewLine;

            foreach (ValueProperty p in info.ValueProperties)
            {
                if (p.PropertyType == TypeCodeEx.ByteArray && AllowNull(p))
                    result += "using System.Linq; //Added for byte[] helpers" + Environment.NewLine;

            }
			return(result);
		}

		// Helper funcion for GetUsingStatementString method 
		protected string[] GetNamespaces(CslaObjectInfo info)
		{
			List<string> usingList = new List<string>();
			
			foreach (ChildProperty prop in info.ChildProperties) 
				if (prop.TypeName != info.ObjectName) 
				{
					CslaObjectInfo childInfo = FindChildInfo(info, prop.TypeName);
					if (childInfo != null) 
						if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace) 
							usingList.Add (childInfo.ObjectNamespace);
				}
			
			foreach (ChildProperty prop in info.InheritedChildProperties) 
				if (prop.TypeName != info.ObjectName) 
				{
					CslaObjectInfo childInfo = FindChildInfo(info, prop.TypeName);
					if (childInfo != null) 
						if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace) 
							usingList.Add (childInfo.ObjectNamespace);
				}

			foreach (ChildProperty prop in info.ChildCollectionProperties) 
				if (prop.TypeName != info.ObjectName) 
				{
					CslaObjectInfo childInfo = FindChildInfo(info, prop.TypeName);
					if (childInfo != null) 
						if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace) 
							usingList.Add (childInfo.ObjectNamespace);
				}

			foreach (ChildProperty prop in info.InheritedChildCollectionProperties) 
				if (prop.TypeName != info.ObjectName) 
				{
					CslaObjectInfo childInfo = FindChildInfo(info, prop.TypeName);
					if (childInfo != null) 
						if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace) 
							usingList.Add (childInfo.ObjectNamespace);
				}

			if (info.ItemType != String.Empty) 
			{
				CslaObjectInfo childInfo = FindChildInfo(info, info.ItemType);
				if (childInfo != null)
					if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace) 
						usingList.Add (childInfo.ObjectNamespace);
			}

			if (info.ParentType != String.Empty) 
			{
				CslaObjectInfo parentInfo = FindChildInfo(info, info.ParentType);
				if (parentInfo != null)
					if (!usingList.Contains(parentInfo.ObjectNamespace) && parentInfo.ObjectNamespace != info.ObjectNamespace) 
						usingList.Add (parentInfo.ObjectNamespace);
			}

            //string[] usingNamespaces = new string[usingList.Count];
            //usingList.CopyTo(0, usingNamespaces, 0, usingList.Count);
            //Array.Sort(usingNamespaces, new CaseInsensitiveComparer());
            if (usingList.Contains(string.Empty))
                usingList.Remove(string.Empty);
            usingList.Sort(string.Compare);
            

			return usingList.ToArray();
		}

		public bool LoadsChildren(CslaObjectInfo info)
		{
			if (IsCollectionType(info.ObjectType))
				info = FindChildInfo(info,info.ItemType);

			foreach (ChildProperty child in info.ChildProperties)
				if (!child.LazyLoad) { return true; }
	
			foreach (ChildProperty child in info.ChildCollectionProperties)
				if (!child.LazyLoad) { return true; }
	
			foreach (ChildProperty child in info.InheritedChildProperties)
				if (!child.LazyLoad) { return true; }
	
			foreach (ChildProperty child in info.InheritedChildCollectionProperties)
				if (!child.LazyLoad) { return true; }
	
			return false;
		}

		public bool IsCollectionType(CslaObjectType cslaType)
		{
			if (cslaType == CslaObjectType.EditableChildCollection ||
				cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.ReadOnlyCollection)
				return true;
			return false;
		}

		public bool IsEditableType(CslaObjectType cslaType)
		{
			if (cslaType == CslaObjectType.EditableChild || 
				cslaType == CslaObjectType.EditableChildCollection ||
				cslaType == CslaObjectType.EditableRoot ||
				cslaType == CslaObjectType.EditableRootCollection ||
				cslaType == CslaObjectType.EditableSwitchable)
				return true;
			return false;
		}

		public bool IsReadOnlyType(CslaObjectType cslaType)
		{
			if (cslaType == CslaObjectType.ReadOnlyCollection ||
				cslaType == CslaObjectType.ReadOnlyObject)
				return true;
			return false;
		}

		public bool IsChildType(CslaObjectType cslaType)
		{
			if (cslaType == CslaObjectType.EditableChild || 
				cslaType == CslaObjectType.EditableChildCollection)
				return true;
			return false;
		}

		public CslaObjectInfo FindChildInfo(CslaObjectInfo info, string name)
		{
			return info.Parent.CslaObjects.Find(name);
		}

        public CslaObjectInfo[] GetChildItems(CslaObjectInfo info)
        {
            List<CslaObjectInfo> list = new List<CslaObjectInfo>();
            foreach (ChildProperty cp in info.GetAllChildProperties())
            {
                CslaObjectInfo ci = FindChildInfo(info, cp.TypeName);
                if (ci != null)
                {
                    if (IsCollectionType(ci.ObjectType))
                    {
                        ci = FindChildInfo(info, ci.ItemType);
                    }
                    if (ci != null)
                        list.Add(ci);
                }
            }
            return list.ToArray();
        }
        public string[] GetAllChildItemsInHierarchy(CslaObjectInfo info)
        {
            List<String> list = new List<String>();
            foreach (CslaObjectInfo obj in GetChildItems(info))
            {
                list.Add(obj.ObjectName);
                list.AddRange(GetAllChildItemsInHierarchy(obj));
            }
            return list.ToArray();
        }

		public void Message(string msg)
		{
			MessageBox.Show(msg, "CSLA Generator");
		}

		public void Message(string msg, string caption)
		{
			MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

        protected internal string ParseNativeType(string nType)
        {
            try
            {
                object value = Enum.Parse(typeof(SqlDbType), nType, true);
                return value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        public string GetNativeType(ValueProperty prop)
        {
            string nativeType=null;
            if (!string.IsNullOrEmpty(prop.DbBindColumn.NativeType))
                nativeType = ParseNativeType(prop.DbBindColumn.NativeType);
            if (string.IsNullOrEmpty(nativeType))
            {
                CslaGenerator.Controls.OutputWindow.Current.AddOutputInfo(string.Format("{0}: Unable to parse database native type from DbBindColumn, infering type from property type.", prop.PropertyType));
                nativeType = TypeHelper.GetSqlDbType(prop.PropertyType).ToString();
            }
            return nativeType;
        }

	}
}
