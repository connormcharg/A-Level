namespace PokemonOOP.classes
{
    internal class Ability
    {
        private string name;
        private string elementType;

        public Ability(string n, string t)
        {
            this.name = n;
            this.elementType = t;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetType()
        {
            return this.elementType;
        }
    }
}
