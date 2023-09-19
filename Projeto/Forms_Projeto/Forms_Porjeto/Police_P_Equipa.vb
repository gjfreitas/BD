Public Class Police_P_Equipa
    Private _IDE As String
    Private _Count As String
    Property IDE() As String
        Get
            IDE = _IDE
        End Get
        Set(ByVal value As String)
            _IDE = value
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
        Dim IDnull As String
        IDnull = "Null"
        If _IDE = "" Or _IDE.ToUpper = IDnull.ToUpper Then
            Return ("Sem Equipa" & _IDE & ", Nº de Policias: " & _Count)
        Else
            Return ("ID: " & _IDE & ", Nº de Policias: " & _Count)
        End If
    End Function
End Class
