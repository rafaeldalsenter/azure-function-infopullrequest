using System.Text.RegularExpressions;

namespace AzureFunctionGithub.CrossCutting.Extensions
{
    public static class CsProjRowExtensions
    {
        private const string _referenceIncludeText = "<Reference Include=\"";

        public static bool IsReferenceIncludePattern(this string row)
            => row != null ? new Regex($"{_referenceIncludeText}.*").IsMatch(row.RowWithoutAdditionSignal()) : false;

        public static string RowFormatReferenceInclude(this string row)
        {
            var rowSplit = row.RowWithoutAdditionSignal();

            if (rowSplit is null || rowSplit.Length < _referenceIncludeText.Length) return null;
            
            var rows = rowSplit.Substring(_referenceIncludeText.Length).Split(',');

            return rows.Length == 0 ? null : rows[0].Split('\"')[0];
        }

        public static bool IsRowAddition(this string row)
            => row != null && row.Length > 1 && row.Substring(0, 1).Equals("+");

        private static string RowWithoutAdditionSignal(this string row)
            => row.IsRowAddition() ? row.Remove(0, 1).TrimStart() : row;

        public static bool IsCsProjFile(this string name)
            => name != null ? new Regex("^.*\\.csproj").IsMatch(name) : false;
    }
}