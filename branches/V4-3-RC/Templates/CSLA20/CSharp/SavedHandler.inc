<%
// Check if we are supposed to use the Updater or else skip over
if (Info.UpdaterType != string.Empty) {
    CslaObjectInfo childInfo3 = null;
    string identityName = string.Empty;
    string identitySourceName = string.Empty;
    // Check if there is an item on this collection
    if (Info.ItemType == string.Empty) {
        Errors.Append(Info.ObjectType + " is missing ItemType property." + Environment.NewLine);
    } else {
        childInfo3 = FindChildInfo(Info, Info.ItemType);
        if (childInfo3 == null) {
            Errors.Append("ItemType " + Info.ItemType + " doesn't exist." + Environment.NewLine);
        } else {
            identityName = string.Empty;
            // Is there something to update
            if (childInfo3.UpdateValueProperties.Count == 0) {
                Errors.Append("No UpdateValueProperties defined on " + childInfo3.ObjectName + "." + Environment.NewLine);
            }
        }
    }
    // Find the updater (we checked earlier that the property exists)
    CslaObjectInfo parentType2 = FindChildInfo(Info, Info.UpdaterType);
    if (parentType2 == null) {
        Errors.Append("UpdaterType " + Info.UpdaterType + " doesn't exist." + Environment.NewLine);
    } else {
        // Check the updater willing to update
        if (!parentType2.SupportUpdateProperties) {
            Errors.Append("SupportUpdateProperties is turned off in " + parentType2.ObjectName + "." + Environment.NewLine);
        }
    }
    // If all went well, find the Identity property
    if (Errors.Length == 0) {
        foreach (UpdateValueProperty vp in childInfo3.UpdateValueProperties) {
            if (vp.IsIdentity) {
                if (identityName != string.Empty) {
                    Errors.Append("IsIdentity is defined twice on UpdateValueProperties of " + childInfo3.ObjectName + "." + Environment.NewLine);
                } else {
                    identityName = vp.Name;
                    identitySourceName = vp.SourcePropertyName;
                }
            }
        }
        if (identityName == string.Empty) {
            Errors.Append("IsIdentity is not defined on UpdateValueProperties of " + childInfo3.ObjectName + "." + Environment.NewLine);
        }
    }
    if (Errors.Length == 0) {
%>

        #region Saved Event Handler

        /// <summary>
        /// Handle Saved events of <see cref="<%=Info.UpdaterType%>" /> to update chikd <see cref="<%=Info.ItemType%>" /> objects. event.
        /// </summary>
        private void <%=Info.UpdaterType%>SavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            // find item corresponding to sender
            // and update item with e.NewObject
            <%=Info.UpdaterType%> old = (<%=Info.UpdaterType%>)sender;
            if (old.IsNew)
            {
                // it is a new item
                IsReadOnly = false;
                Add(<%=Info.ItemType%>.LoadInfo((<%=Info.UpdaterType%>)e.NewObject));
                IsReadOnly = true;
            }
            else
            {
                // it is an existing item
                foreach (<%=Info.ItemType%> child in this)
                {
                    if (child.<%=identityName%> == old.<%=identitySourceName%>)
                    {
                        child.UpdatePropertiesOnSaved((<%=Info.UpdaterType%>)e.NewObject);
                        break;
                    }
                }
            }
        }

        #endregion
    <% } %>
<% } %>
