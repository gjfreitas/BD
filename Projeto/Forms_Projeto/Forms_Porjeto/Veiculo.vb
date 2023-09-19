Public Class Veiculo
    Private _Count As String
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
        If _Count = "" Or _Count.ToUpper = IDnull.ToUpper Then
            Return ("Não há veiculos associados a esse crime")
        Else
            Return (_Count)
        End If
    End Function
End Class
