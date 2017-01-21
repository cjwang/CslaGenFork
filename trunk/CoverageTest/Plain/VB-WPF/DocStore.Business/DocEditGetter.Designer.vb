'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocEditGetter
' ObjectType:  DocEditGetter
' CSLAType:    UnitOfWork

Imports System
Imports Csla
Imports DocStore.Business.Admin

Namespace DocStore.Business

    ''' <summary>
    ''' DocEditGetter (creator and getter unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="DocEditGetter"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Serializable()>
    Partial Public Class DocEditGetter
        Inherits ReadOnlyBase(Of DocEditGetter)

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
        ''' Maintains metadata about unit of work (child) <see cref="DocClassNVL"/> property.
        ''' </summary>
        Public Shared ReadOnly DocClassNVLProperty As PropertyInfo(Of DocClassNVL) = RegisterProperty(Of DocClassNVL)(Function(p) p.DocClassNVL, "Doc Class NVL")
        ''' <summary>
        ''' Gets the Doc Class NVL object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc Class NVL.</value>
        Public Property DocClassNVL As DocClassNVL
            Get
                Return GetProperty(DocClassNVLProperty)
            End Get
            Private Set(ByVal value As DocClassNVL)
                LoadProperty(DocClassNVLProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="DocTypeNVL"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeNVLProperty As PropertyInfo(Of DocTypeNVL) = RegisterProperty(Of DocTypeNVL)(Function(p) p.DocTypeNVL, "Doc Type NVL")
        ''' <summary>
        ''' Gets the Doc Type NVL object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc Type NVL.</value>
        Public Property DocTypeNVL As DocTypeNVL
            Get
                Return GetProperty(DocTypeNVLProperty)
            End Get
            Private Set(ByVal value As DocTypeNVL)
                LoadProperty(DocTypeNVLProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="DocStatusNVL"/> property.
        ''' </summary>
        Public Shared ReadOnly DocStatusNVLProperty As PropertyInfo(Of DocStatusNVL) = RegisterProperty(Of DocStatusNVL)(Function(p) p.DocStatusNVL, "Doc Status NVL")
        ''' <summary>
        ''' Gets the Doc Status NVL object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc Status NVL.</value>
        Public Property DocStatusNVL As DocStatusNVL
            Get
                Return GetProperty(DocStatusNVLProperty)
            End Get
            Private Set(ByVal value As DocStatusNVL)
                LoadProperty(DocStatusNVLProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="UserNVL"/> property.
        ''' </summary>
        Public Shared ReadOnly UserNVLProperty As PropertyInfo(Of UserNVL) = RegisterProperty(Of UserNVL)(Function(p) p.UserNVL, "User NVL")
        ''' <summary>
        ''' Gets the User NVL object (unit of work child property).
        ''' </summary>
        ''' <value>The User NVL.</value>
        Public Property UserNVL As UserNVL
            Get
                Return GetProperty(UserNVLProperty)
            End Get
            Private Set(ByVal value As UserNVL)
                LoadProperty(UserNVLProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocEditGetter"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocEditGetter"/> unit of objects.</returns>
        Public Shared Function NewDocEditGetter() As DocEditGetter
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            Return DataPortal.Fetch(Of DocEditGetter)(New Criteria1(true, New Integer()))
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocEditGetter"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the DocEditGetter to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="DocEditGetter"/> unit of objects.</returns>
        Public Shared Function GetDocEditGetter(docID As Integer) As DocEditGetter
            Return DataPortal.Fetch(Of DocEditGetter)(New Criteria1(false, docID))
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocEditGetter"/> unit of objects.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewDocEditGetter(callback As EventHandler(Of DataPortalResult(Of DocEditGetter)))
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch(Of DocEditGetter)(New Criteria1(true, New Integer()), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                If Not DocClassNVL.IsCached Then
                    DocClassNVL.SetCache(e.Object.DocClassNVL)
                End If
                If Not DocTypeNVL.IsCached Then
                    DocTypeNVL.SetCache(e.Object.DocTypeNVL)
                End If
                If Not DocStatusNVL.IsCached Then
                    DocStatusNVL.SetCache(e.Object.DocStatusNVL)
                End If
                If Not UserNVL.IsCached Then
                    UserNVL.SetCache(e.Object.UserNVL)
                End If
                callback(o, e)
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocEditGetter"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the DocEditGetter to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocEditGetter(docID As Integer, callback As EventHandler(Of DataPortalResult(Of DocEditGetter)))
            DataPortal.BeginFetch(Of DocEditGetter)(New Criteria1(false, docID), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                If Not DocClassNVL.IsCached Then
                    DocClassNVL.SetCache(e.Object.DocClassNVL)
                End If
                If Not DocTypeNVL.IsCached Then
                    DocTypeNVL.SetCache(e.Object.DocTypeNVL)
                End If
                If Not DocStatusNVL.IsCached Then
                    DocStatusNVL.SetCache(e.Object.DocStatusNVL)
                End If
                If Not UserNVL.IsCached Then
                    UserNVL.SetCache(e.Object.UserNVL)
                End If
                callback(o, e)
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocEditGetter"/> class.
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
            Public Sub New(p_createDoc As Boolean, p_docID As Integer)
                CreateDoc = p_createDoc
                DocID = p_docID
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
                    Return True
                End If
                Return False
            End Function

            ''' <summary>
            ''' Returns a hash code for this instance.
            ''' </summary>
            ''' <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            Public Overrides Function GetHashCode() As Integer
                Return String.Concat("Criteria1", CreateDoc.ToString(), DocID.ToString()).GetHashCode()
            End Function
        End Class

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Creates or loads a <see cref="DocEditGetter"/> unit of objects, based on given criteria.
        ''' </summary>
        ''' <param name="crit">The create/fetch criteria.</param>
        Protected Overloads Sub DataPortal_Fetch(crit As Criteria1)
            If crit.CreateDoc Then
                LoadProperty(DocProperty, Doc.NewDoc())
            Else
                LoadProperty(DocProperty, Doc.GetDoc(crit.DocID))
            End If
            LoadProperty(DocClassNVLProperty, DocClassNVL.GetDocClassNVL())
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL())
            LoadProperty(DocStatusNVLProperty, DocStatusNVL.GetDocStatusNVL())
            LoadProperty(UserNVLProperty, UserNVL.GetUserNVL())
        End Sub

        #End Region

    End Class
End Namespace
