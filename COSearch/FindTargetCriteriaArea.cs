using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokemonPRNG.LCG32;
using PokemonStandardLibrary;
using PokemonStandardLibrary.Gen3;
using PokemonCoRNGLibrary;
using PokemonCoRNGLibrary.Criteria;

using static COSearch.Util;

namespace COSearch
{
    public partial class FindTargetCriteriaArea : UserControl
    {
        public FindTargetCriteriaArea()
        {
            InitializeComponent();

            natureBox.Initialize();
            hiddenPowerTypeBox.Initialize();
        }

        public ICriteria<GCIndividual> BuildCriteria(uint tsv, bool containsIVsCriteria = true)
        {
            var builder = new List<ICriteria<GCIndividual>>();
            if (checkAbility.Checked)
                builder.Add(new AbilityCriteria(abilityBox.Text));
            if (checkGCAbility.Checked)
                builder.Add(new GCAbilityCriteria(gcAbilityBox.Text));
            if (checkGender.Checked && genderBox.SelectedGender != Gender.Genderless)
                builder.Add(new GenderCriteria(genderBox.SelectedGender));
            if (checkNature.Checked)
                builder.Add(new NatureCriteria(natureBox.SelectedNature));
            if (checkOnlyShiny.Checked)
                builder.Add(new ShinyCriteria(tsv, ShinyType.Star | ShinyType.Square));

            if (checkHiddenPowerType.Checked)
                builder.Add(new HiddenPowerTypeCriteria(hiddenPowerTypeBox.SelectedType));
            if (checkHiddenPowerPower.Checked)
                builder.Add(new HiddenPowerPowerCriteria((uint)minHiddenPowerPowerBox.Value));

            if (containsIVsCriteria)
                builder.Add(new IVsCriteria(
                    new[] { minH, minA, minB, minC, minD, minS }.Select(GetValueDec).ToArray(),
                    new[] { maxH, maxA, maxB, maxC, maxD, maxS }.Select(GetValueDec).ToArray()
                ));

            return Criteria.AND(builder.ToArray());
        }
        public IEnumerable<(uint H, uint A, uint B, uint C, uint D, uint S)> EnumerateIVs()
        {
            for (uint H = GetValueDec(minH); H <= GetValueDec(maxH); H++)
                for (uint A = GetValueDec(minA); A <= GetValueDec(maxA); A++)
                    for (uint B = GetValueDec(minB); B <= GetValueDec(maxB); B++)
                        for (uint C = GetValueDec(minC); C <= GetValueDec(maxC); C++)
                            for (uint D = GetValueDec(minD); D <= GetValueDec(maxD); D++)
                                for (uint S = GetValueDec(minS); S <= GetValueDec(maxS); S++)
                                    yield return (H, A, B, C, D, S);
        }

        public void ResetItems(Pokemon.Species species)
        {
            abilityBox.ResetItems(species);
            gcAbilityBox.ResetItems(species);
            genderBox.ResetItems(species.GenderRatio);
        }

        public void MaximizeIVs()
        {
            (minH.Value, minA.Value, minB.Value, minC.Value, minD.Value, minS.Value)
                = (31, 31, 31, 31, 31, 31);
        }

        private void NumericUpDown_SelectValue(object sender, EventArgs e)
            => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

        private void Click__minimizeButtonH(object sender, EventArgs e) => (minH.Value, maxH.Value) = (0, 0);
        private void Click__maximizeButtonH(object sender, EventArgs e) => (minH.Value, maxH.Value) = (31, 31);
        private void Click__resetButtonH(object sender, EventArgs e) => (minH.Value, maxH.Value) = (0, 31);

        private void Click__minimizeButtonA(object sender, EventArgs e) => (minA.Value, maxA.Value) = (0, 0);
        private void Click__maximizeButtonA(object sender, EventArgs e) => (minA.Value, maxA.Value) = (31, 31);
        private void Click__resetButtonA(object sender, EventArgs e) => (minA.Value, maxA.Value) = (0, 31);

        private void Click__minimizeButtonB(object sender, EventArgs e) => (minB.Value, maxB.Value) = (0, 0);
        private void Click__maximizeButtonB(object sender, EventArgs e) => (minB.Value, maxB.Value) = (31, 31);
        private void Click__resetButtonB(object sender, EventArgs e) => (minB.Value, maxB.Value) = (0, 31);

        private void Click__minimizeButtonC(object sender, EventArgs e) => (minC.Value, maxC.Value) = (0, 0);
        private void Click__maximizeButtonC(object sender, EventArgs e) => (minC.Value, maxC.Value) = (31, 31);
        private void Click__resetButtonC(object sender, EventArgs e) => (minC.Value, maxC.Value) = (0, 31);

        private void Click__minimizeButtonD(object sender, EventArgs e) => (minD.Value, maxD.Value) = (0, 0);
        private void Click__maximizeButtonD(object sender, EventArgs e) => (minD.Value, maxD.Value) = (31, 31);
        private void Click__resetButtonD(object sender, EventArgs e) => (minD.Value, maxD.Value) = (0, 31);

        private void Click__minimizeButtonS(object sender, EventArgs e) => (minS.Value, maxS.Value) = (0, 0);
        private void Click__maximizeButtonS(object sender, EventArgs e) => (minS.Value, maxS.Value) = (31, 31);
        private void Click__resetButtonS(object sender, EventArgs e) => (minS.Value, maxS.Value) = (0, 31);
    }
}
