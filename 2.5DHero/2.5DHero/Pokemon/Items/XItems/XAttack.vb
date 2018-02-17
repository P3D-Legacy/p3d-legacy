Namespace Items.XItems

    <Item(49, "X Attack")>
    Public Class XAttack

        Inherits XItem

        Public Overrides ReadOnly Property PokeDollarPrice As Integer = 500
        Public Overrides ReadOnly Property Description As String = "An item that sharply boosts the Attack stat of a Pokémon during a battle. It wears off once the Pokémon is withdrawn."

        Public Sub New()
            _textureRectangle = New Rectangle(72, 48, 24, 24)
        End Sub

        Public Overrides Function UseOnPokemon(PokeIndex As Integer) As Boolean
            Dim foundBattleScreen As Boolean = True
            Dim s As Screen = Core.CurrentScreen
            While s.Identification <> Screen.Identifications.BattleScreen
                If s.PreScreen Is Nothing Then
                    foundBattleScreen = False
                    Exit While
                End If
                s = s.PreScreen
            End While

            If foundBattleScreen = True Then
                Dim p As Pokemon = CType(s, BattleSystem.BattleScreen).OwnPokemon

                If p.StatAttack < 6 Then
                    p.StatAttack += 2

                    Screen.TextBox.Show("Boosted " & p.GetDisplayName() & "'s~Attack!" & RemoveItem(), {}, False, False)
                    PlayerStatistics.Track("[53]Status booster used", 2)

                    Return True
                End If

                Screen.TextBox.Show("Cannot boost~ " & p.GetDisplayName() & "'s Attack!", {}, False, False)
                Return False
            Else
                Logger.Log(Logger.LogTypes.Warning, "XAttack.vb: Used outside of battle environment!")
                Return False
            End If
        End Function

    End Class

End Namespace
