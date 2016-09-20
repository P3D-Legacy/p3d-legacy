Namespace Items.Standard

    <Item(149, "Comet Shard")>
    Public Class CometShard

        Inherits Item

        Public Overrides ReadOnly Property PokeDollarPrice As Integer = 120000
        Public Overrides ReadOnly Property CanBeUsedInBattle As Boolean = False
        Public Overrides ReadOnly Property CanBeUsed As Boolean = False

        Public Sub New()
            _textureRectangle = New Rectangle(24, 216, 24, 24)
        End Sub

    End Class

End Namespace
