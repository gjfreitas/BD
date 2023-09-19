Public Class Equipa
    Private _Eid As String
    Private _Count As String
    Property Eid() As String
        Get
            Eid = _Eid
        End Get
        Set(ByVal value As String)
            _Eid = value
        End Set
    End Property

    Property Count() As String
        Get
            Count = _Count
        End Get
        Set(ByVal value As String)
            _Count = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return ("ID: " & _Eid & ", Nº de Detenções: " & _Count)
    End Function

End Class
