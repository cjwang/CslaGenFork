<%
if ((firstComment == null && string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)) ||
    (firstComment == true && !string.IsNullOrEmpty(Info.Parent.GenerationParams.ClassCommentFilenameSuffix)))
{
    firstComment = true;
    %>
    /// <summary>
    /// <%= string.IsNullOrEmpty(Info.ClassSummary) ? Info.ObjectName : Info.ClassSummary %> (<%= CslaStereotype(Info.ObjectType) %>).<br/>
    /// This is a base generated class of <see cref="<%=Info.ObjectName%>"/> business object.
    /// </summary>
    <%
    int indentLevel = (CurrentUnit.GenerationParams.UtilitiesNamespace.Length > 0) ? 1 : 0;
    string indent = new string(' ', indentLevel * 4);
    string xmlRemark = "/// ";
    // contained child collections
    if (Info.ChildCollectionProperties.Count > 0)
    {
        firstComment = false;
        xmlRemark += "This class contains " + Ordinal(Info.ChildCollectionProperties.Count) + " child collection" +
            (Info.ChildCollectionProperties.Count > 1 ? "s" : "") + ":<br/>\r\n";
        for (int collection = 0; collection < Info.ChildCollectionProperties.Count; collection++)
        {
            CslaObjectInfo childColl = FindChildInfo(Info, Info.ChildCollectionProperties[collection].TypeName);
            CslaObjectInfo associated = FindAssociated(Info, childColl);
            xmlRemark += "- <see cref=\"" + Info.ChildCollectionProperties[collection].Name + "\"/> of type <see cref=\"" + childColl.ObjectName +
                "\"/> (" + (associated == null ? "1" : "N") + " to N relation to <see cref=\"" + (associated == null ? childColl.ItemType : associated.ObjectName) + "\"/>)" + (collection != Info.ChildCollectionProperties.Count - 1 ? "<br/>\r\n" : "");
        }
    }
    // collection items
    if (!string.IsNullOrEmpty(Info.ParentType))
    {
        if (Info.ObjectType == CslaObjectType.EditableChild ||
            Info.ObjectType == CslaObjectType.EditableSwitchable ||
            Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
            Info.ObjectType == CslaObjectType.ReadOnlyObject)
        {
            if (firstComment == true) { firstComment = false; } else { xmlRemark += "<br/>\r\n"; }
            xmlRemark += "This class is an item of <see cref=\"" + Info.ParentType + "\"/> collection.";
        }
        else
        {
            if (firstComment == true) { firstComment = false; } else { xmlRemark += "<br/>\r\n"; }
            CslaObjectInfo parent = Info.FindParent(Info);
            xmlRemark += "This class is child of <see cref=\"" + Info.ParentType + "\"/> " + CslaStereotype(parent.ObjectType) + ".";
        }
    }
    // collections
    if (!string.IsNullOrEmpty(Info.ItemType) &&
        (Info.ObjectType == CslaObjectType.EditableRootCollection ||
        Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
        Info.ObjectType == CslaObjectType.EditableChildCollection ||
        Info.ObjectType == CslaObjectType.ReadOnlyCollection))
    {
        if (firstComment == true) { firstComment = false; } else { xmlRemark += "<br/>\r\n"; }
        xmlRemark += "The items of the collection are <see cref=\"" + Info.ItemType + "\"/> objects.";
    }
    if (firstComment == false)
    {
        xmlRemark = System.Text.RegularExpressions.Regex.Replace(xmlRemark, "\r\n", "\r\n" + indent + "/// ", System.Text.RegularExpressions.RegexOptions.Multiline);
        %>
    /// <remarks>
    <%= xmlRemark %>
    <%
        if (Info.ClassRemarks != string.Empty)
        {
            %>
    /// <%= Info.ClassRemarks %>
    <%
        }
        %>
    /// </remarks>
    <%
    }
}
    %>
