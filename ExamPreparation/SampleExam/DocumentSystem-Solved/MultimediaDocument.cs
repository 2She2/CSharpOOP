using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class MultimediaDocument : BinaryDocument
{
    public ulong Length { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = ulong.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}