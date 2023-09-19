Public Class IdadeMed
    Private _IdadeMed As String
    Property IdadeMed() As String
        Get
            IdadeMed = _IdadeMed
        End Get
        Set(ByVal value As String)
            _IdadeMed = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return ("Idade Média: " & _IdadeMed)
    End Function

End Class
