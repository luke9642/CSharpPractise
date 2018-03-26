using System;

namespace App1_1
{
    public class NpcDialogPart : IDialogPart
    {
        private string Text { get; }
        public HeroDialogPart[] HeroDialogPart { get; }

        public NpcDialogPart(string text, HeroDialogPart[] heroDialogPart=null)
        {
            Text = text;
            HeroDialogPart = heroDialogPart;
        }

        public void PrintDialog(IDialogParser dialogParser)
        {
            var i = 0;
            foreach (var dialogPart in HeroDialogPart)
                Console.WriteLine("[" + i++ + "]: " + dialogParser.ParseDialog(dialogPart));
            Console.WriteLine("Wybierz odpowiedź...");
        }

        public string GetText() => Text;
    }
}