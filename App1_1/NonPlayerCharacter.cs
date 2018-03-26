namespace App1_1
{
    public class NonPlayerCharacter
    {
        public string Name { get; }
        private NpcDialogPart NpcDialogPart { get; }

        public NonPlayerCharacter(string name, NpcDialogPart npcDialogPart)
        {
            Name = name;
            NpcDialogPart = npcDialogPart;
        }

        public NpcDialogPart StartTalking() => NpcDialogPart;
    }
}