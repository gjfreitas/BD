Public Class Det_Ninser
    Private _DataDet As DateTime
    Private _Codigo As String

    Property DataDet() As DateTime
        Get
            DataDet = _DataDet
        End Get
        Set(ByVal value As DateTime)
            _DataDet = value
        End Set
    End Property
    Property Codigo() As String
        Get
            Codigo = _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Overrides Function ToString() As String
        If _Codigo = "NOT EXISTS" Then
            Return ("Já foram todas detenções inseridas")
        Else
            Return ("Codigo: " & _Codigo & ", Data de Dentenção: " & _DataDet)
        End If
    End Function
End Class
