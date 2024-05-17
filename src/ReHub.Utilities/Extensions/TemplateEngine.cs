using Scriban;

namespace ReHub.Utilities.Extensions
{
    public static class TemplateEngine
    {
        public static string ParseFile(this string sourceFileName, object context)
        {
            if (context == null) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(sourceFileName)) throw new ArgumentNullException(nameof(sourceFileName));
            if (!File.Exists(sourceFileName)) throw new FileNotFoundException($"Template file {sourceFileName} not found.");

            var source = File.ReadAllText(sourceFileName);
            var template =Template.Parse(source);
            var result = template.Render(context);

            return result;
        }
        public static string ParseString(this string source, object context)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException(nameof(source));

            var template =Template.Parse(source);
            var result = template.Render(context);

            return result;
        }
    }
}
