Public Class Policia_Lugar
    Private _lugar As String
    Property lugar() As String
        Get
            lugar = _lugar
        End Get
        Set(ByVal value As String)
            _lugar = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return (_lugar)
    End Function
End Class
