<%
if (UseSimpleAuditTrail(Info))
{
    %>

        private void SimpleAuditTrail()
        {
    <%
    ValueProperty changedDateProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedDateColumn, ref changedDateProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedDateProperty, "DateTime.Now") %>;
        <%
        var convertedPropertyName = ConvertedPropertyName(Info, changedDateProperty);
        if (convertedPropertyName != string.Empty)
        {
            %>
            OnPropertyChanged("<%= convertedPropertyName %>");
        <%
        }
    }
    ValueProperty changedUserProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedUserColumn, ref changedUserProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedUserProperty, Info.Parent.Params.GetUserMethod) %>;
        <%
        var convertedPropertyName = ConvertedPropertyName(Info, changedUserProperty);
        if (convertedPropertyName != string.Empty)
        {
            %>
            OnPropertyChanged("<%= convertedPropertyName %>");
        <%
        }
    }
    if (IsCreationDateColumnPresent(Info) || IsCreationUserColumnPresent(Info))
    {
        %>
            if (IsNew)
            {
                <%
        ValueProperty creationDateProperty = new ValueProperty();
        if (GetValuePropertyByName(Info, Info.Parent.Params.CreationDateColumn, ref creationDateProperty))
        {
            if (IsChangedDateColumnPresent(Info))
            {
                %>
                <%= GetFieldLoaderStatement(creationDateProperty, GetFieldReaderStatement(changedDateProperty)) %>;
                        <%
            }
            else
            {
                %>
                <%= GetFieldLoaderStatement(creationDateProperty, "DateTime.Now") %>;
                        <%
            }
            var convertedPropertyName = ConvertedPropertyName(Info, creationDateProperty);
            if (convertedPropertyName != string.Empty)
            {
                %>
                OnPropertyChanged("<%= convertedPropertyName %>");
                        <%
            }
        }
        ValueProperty creationUserProperty = new ValueProperty();
        if (GetValuePropertyByName(Info, Info.Parent.Params.CreationUserColumn, ref creationUserProperty))
        {
            if (IsChangedUserColumnPresent(Info))
            {
                %>
                <%= GetFieldLoaderStatement(creationUserProperty, GetFieldReaderStatement(changedUserProperty)) %>;
                        <%
            }
            else
            {
                %>
                <%= GetFieldLoaderStatement(creationUserProperty, Info.Parent.Params.GetUserMethod) %>;
                        <%
            }
            var convertedPropertyName = ConvertedPropertyName(Info, creationUserProperty);
            if (convertedPropertyName != string.Empty)
            {
                %>
                OnPropertyChanged("<%= convertedPropertyName %>");
                        <%
            }
        }
        %>
            }
        <%
    }
    %>
        }
<%
}
%>
