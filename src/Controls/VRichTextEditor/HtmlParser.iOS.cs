using System.Collections.Specialized;
using Foundation;
using UIKit;

namespace VControl.Controls
{
    public static class HtmlParser_iOS
    {
        internal static nfloat defaultSize = UIFont.SystemFontSize;

        internal static UIFont defaultFont;

        public static NSAttributedString HtmlToAttributedString(string htmlString)
        {
            var nsString = new NSString(htmlString);
            var data = nsString.Encode(NSStringEncoding.UTF8);
            var dictionary = new NSAttributedStringDocumentAttributes();
            dictionary.DocumentType = NSDocumentType.HTML;
            NSError error = new NSError();
            var attrString = new NSAttributedString(data, dictionary, ref error);
            var mutString = ResetFontSize(new NSMutableAttributedString(attrString));

            return mutString;
        }

        public static string AttributedStringToHtml(NSAttributedString attributedString)
        {
            var range = new NSRange(0, attributedString.Length);
            var dictionary = new NSAttributedStringDocumentAttributes();
            dictionary.DocumentType = NSDocumentType.HTML;
            NSError error = new NSError();
            var data = attributedString.GetDataFromRange(range, dictionary, ref error);
            var htmlString = new NSString(data, NSStringEncoding.UTF8);
            var cleanHtml = CleanHtml(htmlString);
            return cleanHtml;
        }

        internal static NSAttributedString ResetFontSize(NSMutableAttributedString attrString)
        {
            defaultFont = UIFont.SystemFontOfSize(defaultSize);

            attrString.EnumerateAttribute(
                UIStringAttributeKey.Font,
                new NSRange(0, attrString.Length),
                NSAttributedStringEnumeration.None,
                (NSObject value, NSRange range, ref bool stop) =>
                {
                    if (value != null)
                    {
                        var oldFont = (UIFont)value;
                        var oldDescriptor = oldFont.FontDescriptor;

                        var newDescriptor = defaultFont.FontDescriptor;

                        bool hasBoldFlag = false;
                        bool hasItalicFlag = false;

                        if (
                            oldDescriptor.SymbolicTraits.HasFlag(
                                UIFontDescriptorSymbolicTraits.Bold
                            )
                        )
                        {
                            hasBoldFlag = true;
                        }
                        if (
                            oldDescriptor.SymbolicTraits.HasFlag(
                                UIFontDescriptorSymbolicTraits.Italic
                            )
                        )
                        {
                            hasItalicFlag = true;
                        }

                        if (hasBoldFlag && hasItalicFlag)
                        {
                            uint traitsInt =
                                (uint)UIFontDescriptorSymbolicTraits.Bold
                                + (uint)UIFontDescriptorSymbolicTraits.Italic;
                            newDescriptor = newDescriptor.CreateWithTraits(
                                (UIFontDescriptorSymbolicTraits)traitsInt
                            );
                        }
                        else if (hasBoldFlag)
                        {
                            newDescriptor = newDescriptor.CreateWithTraits(
                                UIFontDescriptorSymbolicTraits.Bold
                            );
                        }
                        else if (hasItalicFlag)
                        {
                            newDescriptor = newDescriptor.CreateWithTraits(
                                UIFontDescriptorSymbolicTraits.Italic
                            );
                        }

                        var newFont = UIFont.FromDescriptor(newDescriptor, defaultSize);

                        attrString.RemoveAttribute(UIStringAttributeKey.Font, range);
                        attrString.AddAttribute(UIStringAttributeKey.Font, newFont, range);
                    }
                }
            );

            return attrString;
        }

        internal static string CleanHtml(string htmlString)
        {
            var collection = SplitIntoTags(htmlString);
            var styleAndBody = FindStyleAndBody(collection);
            var style = styleAndBody.Item1;
            var body = styleAndBody.Item2;
            var spans = FindSpans(style);

            var newString = ApplyStyleToBody(spans, body);

            return newString;
        }

        internal static OrderedDictionary SplitIntoTags(string htmlString)
        {
            bool inTag = false;
            string tag = "";
            string innerHtml = "";
            int repeatTag = 1;

            OrderedDictionary collection = new OrderedDictionary();

            foreach (char c in htmlString)
            {
                if (c == '<')
                {
                    if (collection.Contains(tag))
                    {
                        tag += repeatTag;
                        repeatTag++;
                    }
                    //Trim line breaks
                    innerHtml = innerHtml.Trim(new char[] { '\n', '\r' });
                    collection.Add(tag, innerHtml);
                    inTag = true;
                    tag = "";
                    innerHtml = "";
                }
                else if (inTag)
                {
                    if (c == '>')
                    {
                        inTag = false;
                    }
                    else
                    {
                        tag += c;
                    }
                }
                else
                {
                    innerHtml += c;
                }
            }

            collection.Add(tag, innerHtml);
            return collection;
        }

        internal static Tuple<string, OrderedDictionary> FindStyleAndBody(
            OrderedDictionary collection
        )
        {
            string[] tagCollection = new string[collection.Count];
            collection.Keys.CopyTo(tagCollection, 0);
            string[] innerHtmlCollection = new string[collection.Count];
            collection.Values.CopyTo(innerHtmlCollection, 0);

            string style = "";
            var body = new OrderedDictionary();

            var inBody = false;

            for (int i = 0; i < collection.Count; i++)
            {
                var tag = tagCollection[i];
                var innerHtml = innerHtmlCollection[i];

                if (tag.Contains("style"))
                {
                    style += innerHtml;
                }
                else if (tag.Contains("body"))
                {
                    if (!tag.Contains("/"))
                    {
                        inBody = true;
                    }
                    else
                    {
                        inBody = false;
                    }
                }
                else if (inBody)
                {
                    body.Add(tag, innerHtml);
                }
            }
            return new Tuple<string, OrderedDictionary>(style, body);
        }

        internal static Dictionary<string, List<string>> FindSpans(string style)
        {
            var spanDict = new Dictionary<string, List<string>>();

            var styleDefs = style.Split('\n');
            foreach (string span in styleDefs)
            {
                if (span.StartsWith("span.", StringComparison.CurrentCulture))
                {
                    var name = span.Substring(5, 2);
                    var list = new List<string>();
                    if (span.Contains("font-weight: bold"))
                    {
                        list.Add("b");
                    }
                    if (span.Contains("font-style: italic"))
                    {
                        list.Add("i");
                    }
                    if (span.Contains("text-decoration: underline"))
                    {
                        list.Add("u");
                    }
                    spanDict.Add(name, list);
                }
            }
            return spanDict;
        }

        internal static string ApplyStyleToBody(
            Dictionary<string, List<string>> spans,
            OrderedDictionary body
        )
        {
            string newHtmlString = "";

            string[] tagCollection = new string[body.Count];
            body.Keys.CopyTo(tagCollection, 0);
            string[] innerHtmlCollection = new string[body.Count];
            body.Values.CopyTo(innerHtmlCollection, 0);

            for (int i = 0; i < body.Count; i++)
            {
                var tag = tagCollection[i];
                var innerHtml = innerHtmlCollection[i];

                if (tag.StartsWith("p"))
                {
                    newHtmlString += "<p>" + innerHtml;
                }
                else if (tag.StartsWith("/p"))
                {
                    newHtmlString += "</p>" + innerHtml;
                }
                else if (tag.StartsWith("ul"))
                {
                    newHtmlString += "<ul>" + innerHtml;
                }
                else if (tag.StartsWith("/ul"))
                {
                    newHtmlString += "</ul>" + innerHtml;
                }
                else if (tag.StartsWith("li"))
                {
                    newHtmlString += "<li>" + innerHtml;
                }
                else if (tag.StartsWith("/li"))
                {
                    newHtmlString += "</li>" + innerHtml;
                }
                else if (tag.StartsWith("span"))
                {
                    var spanName = tag.Substring(tag.IndexOf("\"") + 1, 2);
                    if (spans.ContainsKey(spanName))
                    {
                        var newTags = spans[spanName];
                        for (int j = 0; j < newTags.Count; j++)
                        {
                            newHtmlString += "<" + newTags[j] + ">";
                        }
                        newHtmlString += innerHtml;
                        // add closing tags in reverse order
                        for (int k = newTags.Count - 1; k >= 0; k--)
                        {
                            newHtmlString += "</" + newTags[k] + ">";
                        }
                    }
                    else
                    {
                        newHtmlString += innerHtml;
                    }
                }
            }

            return newHtmlString;
        }
    }
}
