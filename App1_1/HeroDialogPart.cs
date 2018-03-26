namespace App1_1
{
    public class HeroDialogPart : IDialogPart
    {
        private string Text { get; }
        public NpcDialogPart NpcDialogPart { get; }

        public HeroDialogPart(string text, NpcDialogPart npcDialogPart=null)
        {
            Text = text;
            NpcDialogPart = npcDialogPart;
        }
        
        public string GetText() => Text;
    }
}