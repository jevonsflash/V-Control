using Android.Text;

namespace VControl.Controls
{
    public static class HtmlParser_Android
    {
        public static ISpanned HtmlToSpanned(string htmlString)
        {
            ISpanned spanned = Html.FromHtml(htmlString, FromHtmlOptions.ModeCompact);
            return spanned;
        }

        public static string SpannedToHtml(ISpanned spanned)
        {
            string htmlString = Html.ToHtml(spanned, ToHtmlOptions.ParagraphLinesIndividual);
            string cleanString = CleanHtml(htmlString);
            return cleanString;
        }

        public static FormattedString SpannedToFormatted(ISpanned spanned)
        {
            FormattedString formatted = (FormattedString)spanned;
            return formatted;
        }

        public static ISpanned FormattedToSpanned(FormattedString formatted)
        {
            ISpanned spanned = (ISpanned)formatted;
            return spanned;
        }

        internal static string CleanHtml(string htmlString)
        {
            bool inTag = false;
            bool pTag = false;
            string newString = "";

            foreach (char c in htmlString)
            {
                if (c == '<')
                {
                    inTag = true;
                    newString += c;
                    continue;
                }
                else if (inTag)
                {
                    if (!pTag)
                    {
                        if (c == 'p')
                        {
                            pTag = true;
                        }
                        newString += c;
                        continue;
                    }
                    if (c == '>')
                    {
                        inTag = false;
                        pTag = false;
                        newString += c;
                        continue;
                    }
                }
                else
                {
                    newString += c;
                }
            }
            return newString;
        }
    }
}
