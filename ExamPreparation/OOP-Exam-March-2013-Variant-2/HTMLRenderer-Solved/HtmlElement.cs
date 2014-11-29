using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HtmlElement : IElement
    {
        private IEnumerable<IElement> childElements;

        public HtmlElement(string name, string content = null)
        {
            this.Name = name;
            this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public string Name { get; set; }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get { return new List<IElement>(this.childElements); }
        }

        public void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element can't be null!");
            }

            (this.childElements as IList<IElement>).Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }


            if (!string.IsNullOrEmpty(this.TextContent))
            {
                string escapedSpecialCharacters = this.TextContent.Replace("&", "&amp;"); // "<", "&lt"
                escapedSpecialCharacters = escapedSpecialCharacters.Replace(">", "&gt;");
                escapedSpecialCharacters = escapedSpecialCharacters.Replace("<", "&lt;");

                output.Append(escapedSpecialCharacters);
            }

            foreach (IElement child in this.childElements)
            {
                child.Render(output);
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.Render(result);
            return result.ToString();
        }
    }
}
