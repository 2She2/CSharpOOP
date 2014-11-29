using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ExcelDocument : OfficeDocument
{
    public ulong NumberOfRows { get; private set; }
    public ulong NumberOfColumns { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "cols")
        {
            this.NumberOfColumns = ulong.Parse(value);
        }
        else if (key == "rows")
        {
            this.NumberOfRows = ulong.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
        output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
        base.SaveAllProperties(output);
    }
}