using System;
using System.Linq;

namespace App1_1
{
    public class Hero
    {
        public string HeroName { get; set; }
        public EHeroClass HeroClass { get; private set; }


        public void SetClass(string heroClassNum)
        {
            if (Enum.TryParse<EHeroClass>(heroClassNum, out var heroClass))
                HeroClass = heroClass;
            else
                throw new ApplicationException();
        }

        public static bool IsNameValid(string name) => name.Length >= 3 && name.All(char.IsLetter);
    }
}