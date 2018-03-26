namespace App1_1
{
    public class Factory
    {
        public static Location CreateLocationWithTwoNpcs()
        {
            var npcDialogPart1 = new NpcDialogPart("NPC: „Witaj, czy możesz mi pomóc dostać się do innego miasta?”", new[]
            {
                new HeroDialogPart("„Tak, chętnie pomogę”", new NpcDialogPart(
                    "„Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota”.", new[]
                    {
                        new HeroDialogPart("„Dam znać jak będę gotowy” <KONIEC>"),
                        new HeroDialogPart("„100 sztuk złota to za mało!”", new NpcDialogPart(
                            "„Niestety nie mam więcej. Jestem bardzo biedny”.", new[]
                            {
                                new HeroDialogPart("„OK, może być 100 sztuk złota.”",
                                    new NpcDialogPart("„Dziękuję.” <KONIEC>")),
                                new HeroDialogPart("„W takim razie radź sobie sam.” <KONIEC>")
                            }))
                    })),
                new HeroDialogPart("„Nie, nie pomogę, żegnaj.” <KONIEC>")
            });
            
            var npcDialogPart2 = new NpcDialogPart("„Hej czy to Ty jesteś tym słynnym #HERONAME# – pogromcą smoków?”", new[]
            {
                new HeroDialogPart("„Tak, jestem #HERONAME#”", new NpcDialogPart("„WOW! Miło poznać!”. <KONIEC>")),
                new HeroDialogPart("„Nie.” <KONIEC>")
            });
            
            var npc1 = new NonPlayerCharacter("Cain", npcDialogPart1);
            var npc2 = new NonPlayerCharacter("Deckard", npcDialogPart2);
            
            return new Location
            {
                Name = "Neverwinter",
                NonPlayerCharacters = new[] {npc1, npc2}
            };
        }
    }
}