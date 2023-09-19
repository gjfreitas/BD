Public Class SuspNDet
    Private _Nome As String
    Private _Ncc As String
    Private _Codigo As String
    Property Nome() As String
        Get
            Nome = _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
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


    Property Codigo() As String
        Get
            Codigo = _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Overrides Function ToString() As String
        Dim IDnull As String
        IDnull = "Null"
        If _Nome Is Nothing Or _Nome.ToUpper = IDnull.ToUpper Or _Nome = "" Then
            Return ("Já foram todos detidos")
        Else
            Return (_Nome & ", Nº CC: " & _Ncc & ", Código do Crime: " & _Codigo)
        End If
    End Function

End Class
