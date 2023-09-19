Public Class Pessoa
    Private _Nome As String
    Private _NCC As String
    Private _Cod As String

    Property Cod As String
        Get
            Cod = _Cod
        End Get
        Set(ByVal value As String)
            _Cod = value
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
    Property NCC() As String
        Get
            NCC = _NCC
        End Get
        Set(ByVal value As String)
            _NCC = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return (_Nome & ", Nº CC: " & _NCC)
    End Function

End Class
