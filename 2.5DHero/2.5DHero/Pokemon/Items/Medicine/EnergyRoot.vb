Namespace Items.Medicine

    <Item(122, "Energy Root")>
    Public Class EnergyRoot

        Inherits MedicineItem

        Public Overrides ReadOnly Property PokeDollarPrice As Integer = 800
        Public Overrides ReadOnly Property Description As String = "An extremely bitter medicinal root. When consumed, it restores up to 120 HP to an injured Pokémon."
        Public Overrides ReadOnly Property IsHealingItem As Boolean = True

        Public Sub New()
            _textureRectangle = New Rectangle(24, 120, 24, 24)
        End Sub

        Public Overrides Sub Use()
            If CBool(GameModeManager.GetGameRuleValue("CanUseHealItem", "1")) = False Then
                Screen.TextBox.Show("Cannot use heal items.", {}, False, False)
                Exit Sub
            End If
            Dim selScreen = New PartyScreen(Core.CurrentScreen, Me, AddressOf Me.UseOnPokemon, "Use " & Me.Name, True) With {.Mode = Screens.UI.ISelectionScreen.ScreenMode.Selection, .CanExit = True}
            AddHandler selScreen.SelectedObject, AddressOf UseItemhandler

            Core.SetScreen(selScreen)
        End Sub

        Public Overrides Function UseOnPokemon(ByVal PokeIndex As Integer) As Boolean
            Dim r As Boolean = HealPokemon(PokeIndex, 120)
            If r = True Then
                Core.Player.Pokemons(PokeIndex).ChangeFriendShip(Pokemon.FriendShipCauses.EnergyRoot)
            End If
            Return r
        End Function

    End Class

End Namespace
