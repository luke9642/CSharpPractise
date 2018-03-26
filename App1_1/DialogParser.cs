namespace App1_1
{
    public class DialogParser : IDialogParser
    {
        private readonly Hero _hero;
        
        public DialogParser(Hero hero)
        {
            _hero = hero;
        }

        public string ParseDialog(IDialogPart dialogPart)
        {
            const string str = "#HERONAME#";
            var text = dialogPart.GetText();
            return text.Contains(str) ? text.Replace(str, _hero.HeroName) : text;
        }
    }
}