using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PDFDocument : EncryptableBinaryDocument, IEncryptable
{
    public ulong NumberOfPages { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.NumberOfPages = ulong.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
        base.SaveAllProperties(output);
    }
}