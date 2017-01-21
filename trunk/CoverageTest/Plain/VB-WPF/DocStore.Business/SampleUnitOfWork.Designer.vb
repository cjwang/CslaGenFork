'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    SampleUnitOfWork
' ObjectType:  SampleUnitOfWork
' CSLAType:    UnitOfWork

Imports System
Imports Csla

Namespace DocStore.Business

    ''' <summary>
    ''' SampleUnitOfWork (creator and getter unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="SampleUnitOfWork"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Serializable()>
    Partial Public Class SampleUnitOfWork
        Inherits ReadOnlyBase(Of SampleUnitOfWork)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="Doc"/> property.
        ''' </summary>
        Public Shared ReadOnly DocProperty As PropertyInfo(Of Doc) = RegisterProperty(Of Doc)(Function(p) p.Doc, "Doc")
        ''' <summary>
        ''' Gets the Doc object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc.</value>
        Public Property Doc As Doc
            Get
                Return GetProperty(DocProperty)
            End Get
            Private Set(ByVal value As Doc)
                LoadProperty(DocProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="Folder"/> property.
        ''' </summary>
        Public Shared ReadOnly FolderProperty As PropertyInfo(Of Folder) = RegisterProperty(Of Folder)(Function(p) p.Folder, "Folder")
        ''' <summary>
        ''' Gets the Folder object (unit of work child property).
        ''' </summary>
        ''' <value>The Folder.</value>
        Public Property Folder As Folder
            Get
                Return GetProperty(FolderProperty)
            End Get
            Private Set(ByVal value As Folder)
                LoadProperty(FolderProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="DocList"/> property.
        ''' </summary>
        Public Shared ReadOnly DocListProperty As PropertyInfo(Of DocList) = RegisterProperty(Of DocList)(Function(p) p.DocList, "Doc List")
        ''' <summary>
        ''' Gets the Doc List object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc List.</value>
        Public Property DocList As DocList
            Get
                Return GetProperty(DocListProperty)
            End Get
            Private Set(ByVal value As DocList)
                LoadProperty(DocListProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="SampleUnitOfWork"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        Public Shared Function NewSampleUnitOfWork() As SampleUnitOfWork
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            Return DataPortal.Fetch(Of SampleUnitOfWork)(New Criteria1(true, New Integer(), true, New Integer()))
        End Function

        ''' <summary>
        ''' Factory method. Creates a new <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docListFilteredCriteria">The DocListFilteredCriteria of the SampleUnitOfWork to create.</param>
        ''' <returns>A reference to the created <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        Public Shared Function NewSampleUnitOfWork(docListFilteredCriteria As DocListFilteredCriteria) As SampleUnitOfWork
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            Return DataPortal.Fetch(Of SampleUnitOfWork)(New Criteria2(true, New Integer(), true, New Integer(), docListFilteredCriteria))
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        Public Shared Function GetSampleUnitOfWork(docID As Integer, folderID As Integer) As SampleUnitOfWork
            Return DataPortal.Fetch(Of SampleUnitOfWork)(New Criteria1(false, docID, false, folderID))
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="docListFilteredCriteria">The DocListFilteredCriteria parameter of the SampleUnitOfWork to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="SampleUnitOfWork"/> unit of objects.</returns>
        Public Shared Function GetSampleUnitOfWork(docID As Integer, folderID As Integer, docListFilteredCriteria As DocListFilteredCriteria) As SampleUnitOfWork
            Return DataPortal.Fetch(Of SampleUnitOfWork)(New Criteria2(false, docID, false, folderID, docListFilteredCriteria))
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="SampleUnitOfWork"/> unit of objects.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewSampleUnitOfWork(callback As EventHandler(Of DataPortalResult(Of SampleUnitOfWork)))
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch(Of SampleUnitOfWork)(New Criteria1(true, New Integer(), true, New Integer()), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docListFilteredCriteria">The DocListFilteredCriteria of the SampleUnitOfWork to create.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewSampleUnitOfWork(docListFilteredCriteria As DocListFilteredCriteria, callback As EventHandler(Of DataPortalResult(Of SampleUnitOfWork)))
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch(Of SampleUnitOfWork)(New Criteria2(true, New Integer(), true, New Integer(), docListFilteredCriteria), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetSampleUnitOfWork(docID As Integer, folderID As Integer, callback As EventHandler(Of DataPortalResult(Of SampleUnitOfWork)))
            DataPortal.BeginFetch(Of SampleUnitOfWork)(New Criteria1(false, docID, false, folderID), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="folderID">The FolderID parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="docListFilteredCriteria">The DocListFilteredCriteria parameter of the SampleUnitOfWork to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetSampleUnitOfWork(docID As Integer, folderID As Integer, docListFilteredCriteria As DocListFilteredCriteria, callback As EventHandler(Of DataPortalResult(Of SampleUnitOfWork)))
            DataPortal.BeginFetch(Of SampleUnitOfWork)(New Criteria2(false, docID, false, folderID, docListFilteredCriteria), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SampleUnitOfWork"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Criteria "

        ''' <summary>
        ''' Criteria1 criteria.
        ''' </summary>
        <Serializable()>
        Protected Class Criteria1
            Inherits CriteriaBase(Of Criteria1)

            ''' <summary>
            ''' Maintains metadata about <see cref="CreateDoc"/> property.
            ''' </summary>
            Public Shared ReadOnly CreateDocProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.CreateDoc, "Create Doc")
            ''' <summary>
            ''' Gets or sets the Create Doc.
            ''' </summary>
            ''' <value>The Create Doc.</value>
            Public Property CreateDoc As Boolean
                Get
                    Return ReadProperty(CreateDocProperty)
                End Get
                Set
                    LoadProperty(CreateDocProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="DocID"/> property.
            ''' </summary>
            Public Shared ReadOnly DocIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocID, "Doc ID")
            ''' <summary>
            ''' Gets or sets the Doc ID.
            ''' </summary>
            ''' <value>The Doc ID.</value>
            Public Property DocID As Integer
                Get
                    Return ReadProperty(DocIDProperty)
                End Get
                Set
                    LoadProperty(DocIDProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="CreateFolder"/> property.
            ''' </summary>
            Public Shared ReadOnly CreateFolderProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.CreateFolder, "Create Folder")
            ''' <summary>
            ''' Gets or sets the Create Folder.
            ''' </summary>
            ''' <value>The Create Folder.</value>
            Public Property CreateFolder As Boolean
                Get
                    Return ReadProperty(CreateFolderProperty)
                End Get
                Set
                    LoadProperty(CreateFolderProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="FolderID"/> property.
            ''' </summary>
            Public Shared ReadOnly FolderIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.FolderID, "Folder ID")
            ''' <summary>
            ''' Gets or sets the Folder ID.
            ''' </summary>
            ''' <value>The Folder ID.</value>
            Public Property FolderID As Integer
                Get
                    Return ReadProperty(FolderIDProperty)
                End Get
                Set
                    LoadProperty(FolderIDProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Initializes a new instance of the <see cref="Criteria1"/> class.
            ''' </summary>
            ''' <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
            Public Sub New()
            End Sub

            ''' <summary>
            ''' Initializes a new instance of the <see cref="Criteria1"/> class.
            ''' </summary>
            ''' <param name="p_createDoc">The CreateDoc.</param>
            ''' <param name="p_docID">The DocID.</param>
            ''' <param name="p_createFolder">The CreateFolder.</param>
            ''' <param name="p_folderID">The FolderID.</param>
            Public Sub New(p_createDoc As Boolean, p_docID As Integer, p_createFolder As Boolean, p_folderID As Integer)
                CreateDoc = p_createDoc
                DocID = p_docID
                CreateFolder = p_createFolder
                FolderID = p_folderID
            End Sub

            ''' <summary>
            ''' Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            ''' </summary>
            ''' <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            ''' <returns><c>True</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            Public Overrides Function Equals(obj As object) As Boolean
                If TypeOf obj Is Criteria1 Then
                    Dim c As Criteria1 = obj
                    If Not CreateDoc.Equals(c.CreateDoc) Then
                        Return False
                    End If
                    If Not DocID.Equals(c.DocID) Then
                        Return False
                    End If
                    If Not CreateFolder.Equals(c.CreateFolder) Then
                        Return False
                    End If
                    If Not FolderID.Equals(c.FolderID) Then
                        Return False
                    End If
                    Return True
                End If
                Return False
            End Function

            ''' <summary>
            ''' Returns a hash code for this instance.
            ''' </summary>
            ''' <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            Public Overrides Function GetHashCode() As Integer
                Return String.Concat("Criteria1", CreateDoc.ToString(), DocID.ToString(), CreateFolder.ToString(), FolderID.ToString()).GetHashCode()
            End Function
        End Class

        ''' <summary>
        ''' Criteria2 criteria.
        ''' </summary>
        <Serializable()>
        Protected Class Criteria2
            Inherits CriteriaBase(Of Criteria2)

            ''' <summary>
            ''' Maintains metadata about <see cref="CreateDoc"/> property.
            ''' </summary>
            Public Shared ReadOnly CreateDocProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.CreateDoc, "Create Doc")
            ''' <summary>
            ''' Gets or sets the Create Doc.
            ''' </summary>
            ''' <value>The Create Doc.</value>
            Public Property CreateDoc As Boolean
                Get
                    Return ReadProperty(CreateDocProperty)
                End Get
                Set
                    LoadProperty(CreateDocProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="DocID"/> property.
            ''' </summary>
            Public Shared ReadOnly DocIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocID, "Doc ID")
            ''' <summary>
            ''' Gets or sets the Doc ID.
            ''' </summary>
            ''' <value>The Doc ID.</value>
            Public Property DocID As Integer
                Get
                    Return ReadProperty(DocIDProperty)
                End Get
                Set
                    LoadProperty(DocIDProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="CreateFolder"/> property.
            ''' </summary>
            Public Shared ReadOnly CreateFolderProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.CreateFolder, "Create Folder")
            ''' <summary>
            ''' Gets or sets the Create Folder.
            ''' </summary>
            ''' <value>The Create Folder.</value>
            Public Property CreateFolder As Boolean
                Get
                    Return ReadProperty(CreateFolderProperty)
                End Get
                Set
                    LoadProperty(CreateFolderProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="FolderID"/> property.
            ''' </summary>
            Public Shared ReadOnly FolderIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.FolderID, "Folder ID")
            ''' <summary>
            ''' Gets or sets the Folder ID.
            ''' </summary>
            ''' <value>The Folder ID.</value>
            Public Property FolderID As Integer
                Get
                    Return ReadProperty(FolderIDProperty)
                End Get
                Set
                    LoadProperty(FolderIDProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="DocListFilteredCriteria"/> property.
            ''' </summary>
            Public Shared ReadOnly DocListFilteredCriteriaProperty As PropertyInfo(Of DocListFilteredCriteria) = RegisterProperty(Of DocListFilteredCriteria)(Function(p) p.DocListFilteredCriteria, "Doc List Filtered Criteria")
            ''' <summary>
            ''' Gets or sets the Doc List Filtered Criteria.
            ''' </summary>
            ''' <value>The Doc List Filtered Criteria.</value>
            Public Property DocListFilteredCriteria As DocListFilteredCriteria
                Get
                    Return ReadProperty(DocListFilteredCriteriaProperty)
                End Get
                Set
                    LoadProperty(DocListFilteredCriteriaProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Initializes a new instance of the <see cref="Criteria2"/> class.
            ''' </summary>
            ''' <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
            Public Sub New()
            End Sub

            ''' <summary>
            ''' Initializes a new instance of the <see cref="Criteria2"/> class.
            ''' </summary>
            ''' <param name="p_createDoc">The CreateDoc.</param>
            ''' <param name="p_docID">The DocID.</param>
            ''' <param name="p_createFolder">The CreateFolder.</param>
            ''' <param name="p_folderID">The FolderID.</param>
            ''' <param name="p_docListFilteredCriteria">The DocListFilteredCriteria.</param>
            Public Sub New(p_createDoc As Boolean, p_docID As Integer, p_createFolder As Boolean, p_folderID As Integer, p_docListFilteredCriteria As DocListFilteredCriteria)
                CreateDoc = p_createDoc
                DocID = p_docID
                CreateFolder = p_createFolder
                FolderID = p_folderID
                DocListFilteredCriteria = p_docListFilteredCriteria
            End Sub

            ''' <summary>
            ''' Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            ''' </summary>
            ''' <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            ''' <returns><c>True</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            Public Overrides Function Equals(obj As object) As Boolean
                If TypeOf obj Is Criteria2 Then
                    Dim c As Criteria2 = obj
                    If Not CreateDoc.Equals(c.CreateDoc) Then
                        Return False
                    End If
                    If Not DocID.Equals(c.DocID) Then
                        Return False
                    End If
                    If Not CreateFolder.Equals(c.CreateFolder) Then
                        Return False
                    End If
                    If Not FolderID.Equals(c.FolderID) Then
                        Return False
                    End If
                    If Not DocListFilteredCriteria.Equals(c.DocListFilteredCriteria) Then
                        Return False
                    End If
                    Return True
                End If
                Return False
            End Function

            ''' <summary>
            ''' Returns a hash code for this instance.
            ''' </summary>
            ''' <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            Public Overrides Function GetHashCode() As Integer
                Return String.Concat("Criteria2", CreateDoc.ToString(), DocID.ToString(), CreateFolder.ToString(), FolderID.ToString(), DocListFilteredCriteria.ToString()).GetHashCode()
            End Function
        End Class

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Creates or loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given criteria.
        ''' </summary>
        ''' <param name="crit">The create/fetch criteria.</param>
        Protected Overloads Sub DataPortal_Fetch(crit As Criteria1)
            If crit.CreateDoc Then
                LoadProperty(DocProperty, Doc.NewDoc())
            Else
                LoadProperty(DocProperty, Doc.GetDoc(crit.DocID))
            End If
            If crit.CreateFolder Then
                LoadProperty(FolderProperty, Folder.NewFolder())
            Else
                LoadProperty(FolderProperty, Folder.GetFolder(crit.FolderID))
            End If
            LoadProperty(DocListProperty, DocList.GetDocList())
        End Sub

        ''' <summary>
        ''' Creates or loads a <see cref="SampleUnitOfWork"/> unit of objects, based on given criteria.
        ''' </summary>
        ''' <param name="crit">The create/fetch criteria.</param>
        Protected Overloads Sub DataPortal_Fetch(crit As Criteria2)
            If crit.CreateDoc Then
                LoadProperty(DocProperty, Doc.NewDoc())
            Else
                LoadProperty(DocProperty, Doc.GetDoc(crit.DocID))
            End If
            If crit.CreateFolder Then
                LoadProperty(FolderProperty, Folder.NewFolder())
            Else
                LoadProperty(FolderProperty, Folder.GetFolder(crit.FolderID))
            End If
            LoadProperty(DocListProperty, DocList.GetDocList(crit.DocListFilteredCriteria))
        End Sub

        #End Region

    End Class
End Namespace
