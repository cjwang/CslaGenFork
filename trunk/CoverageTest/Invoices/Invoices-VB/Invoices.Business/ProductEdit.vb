Imports System
Imports Csla

Namespace Invoices.Business

    Public Partial Class ProductEdit

        #Region " OnDeserialized actions "

        ' ''' <summary>
        ' ''' This method is called on a newly deserialized object
        ' ''' after deserialization is complete.
        ' ''' </summary>
        ' ''' <param name="context">Serialization context object.</param>
        ' Protected Overrides Sub OnDeserialized(context As System.Runtime.Serialization.StreamingContext)
            ' MyBase.OnDeserialized(context)
            ' add your custom OnDeserialized actions here.
        ' End Sub

        #End Region

        #Region " ChildChanged Event Handler "

        ' ''' <summary>
        ' ''' Raises the ChildChanged event, indicating that a child object has been changed.
        ' ''' </summary>
        ' ''' <param name="e">ChildChangedEventArgs object.</param>
        ' Protected Overrides Sub OnChildChanged(Csla.Core.ChildChangedEventArgs e)
            ' MyBase.OnChildChanged(e);
            ' 
            ' '  uncomment the lines for child with properties relevant to business rules
            ' ' PropertyHasChanged(SuppliersProperty);
            ' '  uncomment if there is an object level business rule (introduced in Csla 4.2.0)
            ' ' CheckObjectRules();
        ' End Sub

        #End Region

        #Region " Implementation of DataPortal Hooks "

        ' Private Sub OnCreate(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnDeletePre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnDeletePost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnFetchPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnFetchPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnFetchRead(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnUpdatePre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnUpdatePost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnInsertPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnInsertPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

    End Class

End Namespace
