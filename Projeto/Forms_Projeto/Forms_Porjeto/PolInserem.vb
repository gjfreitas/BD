Public Class PolInserem
    Private _Nome As String
    Private _Ncc As String
    Private _ID As String
    Private _Count As String

    Property Count() As String
        Get
            Count = _Count
        End Get
        Set(ByVal value As String)
            _Count = value
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

    Property Ncc() As String
        Get
            Ncc = _Ncc
        End Get
        Set(ByVal value As String)
            _Ncc = value
        End Set
    End Property

    Property Nome() As String
        Get
            Nome = _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return (_Nome & ", Nº CC: " & _Ncc & ", Nº inserções: " & _Count)
    End Function
End Class
