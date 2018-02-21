namespace Arrow.Core
{
    public interface ISyntax
    {
        int Length { get; set; }
        string Name { get; }
        int Position { get; set; }

        bool TryParse(TokenStream stream, Scanner scanner);
    }
}