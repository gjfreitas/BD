Public Class Policia_Principal
    Private _Eid As String
    Private _ID As String
    Property Eid() As String
        Get
            Eid = _Eid
        End Get
        Set(ByVal value As String)
            _Eid = value
        End Set
    End Property

    Property ID() As String
        Get
            ID = _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

    Overrides Function ToString() As String
        If _Eid = "NOT EXISTS" Then
            Return ("Não é chefe de equipa")
        Else
            Return ("Equipa ID: " & _Eid)
        End If
    End Function

End Class
