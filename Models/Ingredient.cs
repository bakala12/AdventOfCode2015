namespace AdventOfCode2015.Models
{
    public readonly record struct Ingredient(string Name, int Capacity, int Durability, int Flavour, int Texture, int Calories);
}