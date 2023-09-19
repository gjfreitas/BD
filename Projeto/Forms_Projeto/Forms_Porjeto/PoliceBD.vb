<Serializable()> Public Class Contact
    '' Pessoa
    Private _Ncc As String
    Private _Nome As String
    Private _BDate As DateTime
    Private _Sexo As String
    Private _Morada As String
    '' Policia
    Private _ID As String
    Private _CC As String
    Private _Lugar As String
    Private _Ntelefone As String
    Private _IDEquipa As String
    '' Suspeitos
    Private _SuspCC As String
    Private _NCrimes As String
    Private _CodigoDet As String

    '' Pessoa
    Property Ncc As String
        Get
            Ncc = _Ncc
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("NºCC não pode ser nulo")
                Exit Property
            End If
            _Ncc = value
        End Set
    End Property


    Property Nome() As String
        Get
            Nome = _Nome
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Nome não pode ser nulo")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property

    Property BDate() As DateTime

        Get
            BDate = _BDate
        End Get
        Set(ByVal value As DateTime)
            _BDate = value
        End Set
    End Property

    Property Sexo() As String
        Get
            Sexo = _Sexo
        End Get
        Set(ByVal value As String)
            _Sexo = value
        End Set
    End Property

    Property Morada() As String
        Get
            Morada = _Morada
        End Get
        Set(ByVal value As String)
            _Morada = value
        End Set
    End Property

    '' Policia
    Property ID As String
        Get
            ID = _ID
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Id não pode ser nulo")
                Exit Property
            End If
            _ID = value
        End Set
    End Property

    Property CC() As String
        Get
            CC = _CC
        End Get
        Set(ByVal value As String)
            _CC = value
        End Set
    End Property

    Property Lugar() As String
        Get
            Lugar = _Lugar
        End Get
        Set(ByVal value As String)
            _Lugar = value
        End Set
    End Property

    Property IDEquipa() As String
        Get
            IDEquipa = _IDEquipa
        End Get
        Set(ByVal value As String)
            _IDEquipa = value
        End Set
    End Property

    Property Ntelefone() As String
        Get
            Ntelefone = _Ntelefone
        End Get
        Set(ByVal value As String)
            _Ntelefone = value
        End Set
    End Property

    '' Suspeitos
    Property SuspCC() As String
        Get
            SuspCC = _SuspCC
        End Get
        Set(ByVal value As String)
            _SuspCC = value
        End Set
    End Property
    Property NCrimes() As String
        Get
            NCrimes = _NCrimes
        End Get
        Set(ByVal value As String)
            _NCrimes = value
        End Set
    End Property

    Property CodigoDet() As String
        Get
            CodigoDet = _CodigoDet
        End Get
        Set(ByVal value As String)
            _CodigoDet = value
        End Set
    End Property

    Overrides Function ToString() As String
        '' Return _Ncc & "   " & _Nome
        Return _Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

End Class
