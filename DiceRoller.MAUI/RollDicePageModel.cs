﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DiceRoller.MAUI
{
    public partial class RollDicePageModel : ObservableObject
    {
        public RollDicePageModel()
        {
            List<string> dice = [];
            foreach (uint num in DiceRoll.ValidSides.Order())
            {
                dice.Add($"d{num}");
            }
            Dice = dice.ToList().AsReadOnly();
        }

        [ObservableProperty]
        private ReadOnlyCollection<string> _dice = default!;
        [ObservableProperty]
        private string _selectedDie = default!;
        [ObservableProperty]
        private string _count = default!;
        [ObservableProperty]
        private string _modifier = default!;
        [ObservableProperty]
        private DiceRoll _diceRoller = default!;
        [ObservableProperty]
        private string _selectedDieWithCount = default!;
        [ObservableProperty]
        private string _rollsAsString = default!;
        [ObservableProperty]
        private string _rollTotal = default!;
        [ObservableProperty]
        private bool _d2d3D100IsSelected;

        private bool CanRollDice => SelectedDie != null && Count != null && Modifier != null;

        [RelayCommand]
        private void SelectedDieChanged()
        {
            D2d3D100IsSelected = SelectedDie == "d2" || SelectedDie == "d3" || SelectedDie == "d100";
            if (D2d3D100IsSelected)
            {
                Count = "1";
            }
        }
        [RelayCommand]
        private void RollDiceClicked()
        {
            if (!CanRollDice) { return; }

            (uint SidesNum, uint CountNum, int ModifierNum) GetNumbersFromStrings()
            {
                _ = uint.TryParse(SelectedDie.Replace("d", string.Empty), out uint sidesNum);
                _ = uint.TryParse(Count, out uint countNum);
                _ = int.TryParse(Modifier, out int modifierNum);

                return (sidesNum, countNum, modifierNum);
            }
            string RollsAsCommaSeparatedSttring(IEnumerable<uint> rolls) => string.Join(", ", rolls);

            SelectedDieWithCount = $"{Count}{SelectedDie}";

            (uint SidesNum, uint CountNum, int ModifierNum) = GetNumbersFromStrings();

            DiceRoller = new() { Sides = SidesNum, Count = CountNum, Modifier = ModifierNum };
            IEnumerable<uint> rolls = DiceRoller.Roll();

            RollsAsString = RollsAsCommaSeparatedSttring(rolls);
            RollTotal = ((int)(rolls.Sum(r => r)) + ModifierNum).ToString();
        }  //TODO: Enable/disable button 
    }
}
