using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WordDocument : OfficeDocument, IEditable
{
    public ulong NumberOfCharacters { get; private set; }

    public void ChangeContent(string newContent)
    {
        base.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.NumberOfCharacters = ulong.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));
        base.SaveAllProperties(output);
    }
}

