Public Class Local_Crime
    Private _local As String
    Private _Count As String
    Property local() As String
        Get
            local = _local
        End Get
        Set(ByVal value As String)
            _local = value
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
        Return ("Localização: " & _local & ", Nº de Crimes: " & _Count)
    End Function
End Class
