Imports System
Imports Csla

Namespace TestProject.Business

    Partial Public Class DocRO

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

        #Region " Implementation of DataPortal Hooks "

        ' Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

    End Class

End Namespace