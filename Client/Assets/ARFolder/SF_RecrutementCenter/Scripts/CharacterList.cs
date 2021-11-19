using System.Collections.Generic;
using System.Linq;


/// <summary>
/// Contains a list of all available characters, with some basic filtering methods
/// </summary>
public class CharacterList : GenericList<Character>
{
    public static CharacterList instance;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerable<Character> GetByClass(string characterClass)
    {
        return list.Where(c => c.characterClass.name.Equals(characterClass));
    }
}