Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Collection of folders where this document is archived (read only list).<br/>
    ''' This is a generated base class of <see cref="DocFolderCollRO"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="DocRO"/> read only object.<br/>
    ''' The items of the collection are <see cref="DocFolderRO"/> objects.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable>
    Public Partial Class DocFolderCollRO
        Inherits ReadOnlyBindingListBase(Of DocFolderCollRO, DocFolderRO)
        Implements IHaveInterface
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="DocFolderRO"/> item is in the collection.
        ''' </summary>
        ''' <param name="folderID">The FolderID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocFolderRO is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(folderID As Integer) As Boolean
            For Each item As DocFolderRO In Me
                If item.FolderID = folderID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocFolderCollRO"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = False
            AllowEdit = False
            AllowRemove = False
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads all <see cref="DocFolderCollRO"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DataPortal.FetchChild(Of DocFolderRO)(dr))
            End While
            OnFetchPost(args)
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
