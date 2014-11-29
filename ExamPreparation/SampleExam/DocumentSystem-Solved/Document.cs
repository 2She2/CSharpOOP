using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Document : IDocument
{
    public string Name { get; private set; }

    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        SaveAllProperties(properties);
        properties.Sort((a, b) => a.Key.CompareTo(b.Key));

        StringBuilder propsToString = new StringBuilder();

        propsToString.Append(this.GetType().Name);
        propsToString.Append('[');
        for (int i = 0; i < properties.Count; i++)
        {
            if (properties[i].Value != null && properties[i].Value.ToString() != "0") //  && properties[i].Value.ToString() != string.Empty
            {
                propsToString.AppendFormat("{0}={1}", properties[i].Key, properties[i].Value);

                if (i < properties.Count - 1)
                {
                    propsToString.Append(';');
                }
            }
        }

        if (propsToString[propsToString.Length - 1] == ';')
        {
            propsToString.Remove(propsToString.Length - 1, 1);
        }

        propsToString.Append(']');

        return propsToString.ToString();
    }
}