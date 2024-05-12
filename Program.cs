using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        public static ColorChip[] ArrangeChips(List<ColorChip> chips)
        {
            List<ColorChip> arrangedChips = new List<ColorChip>();

            arrangedChips.Add(chips.FirstOrDefault(chip => chip.StartColor == Color.Blue));

            while (arrangedChips.Last().EndColor != Color.Green)
            {
                foreach (var chip in chips.ToList())
                {
                    if (chip.StartColor == arrangedChips.Last().EndColor)
                    {
                        arrangedChips.Add(chip);
                        chips.Remove(chip);
                    }
                }
            }
            
            return arrangedChips.ToArray();
        }
        static void Main(string[] args)
        {
            var Start = Color.Blue;
            var End = Color.Green;

            List<ColorChip> chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple)
            };

            #region Test
            //List<ColorChip> chips = new List<ColorChip>
            //{
            //    new ColorChip(Color.Red, Color.Yellow),
            //    new ColorChip(Color.Purple, Color.Orange),
            //    new ColorChip(Color.Blue, Color.Red),
            //    new ColorChip(Color.Yellow, Color.Purple),
            //    new ColorChip(Color.Orange, Color.Green)
            //};
            #endregion

            ColorChip[] arrangedChips = ArrangeChips(chips);

            Console.WriteLine(Start);
            arrangedChips.ToList().ForEach(i => Console.WriteLine("[" + i.ToString() + "]"));
            Console.WriteLine(End);
            Console.ReadKey();
        }
    }
}
