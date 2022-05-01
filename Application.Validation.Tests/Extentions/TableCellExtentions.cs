using Gherkin.Ast;

namespace Application.Validation.Tests.Extentions
{
    public static class TableCellExtentions
    {
        public static void Deconstruct(
            this IEnumerable<string> cells,
            out string first,
            out IEnumerable<string> rest)
        {
            first = cells.FirstOrDefault();
            rest = cells.Skip(1);
        }

        public static void Deconstruct(
            this IEnumerable<string> cells,
            out string first,
            out string second,
            out IEnumerable<string> rest)
            => (first, (second, rest)) = cells;            
    }
}
