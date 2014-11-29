using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HtmlTable : HtmlElement, ITable
    {
        private const string tableName = "table";
        private const string tableContent = null;
        private IElement[,] tableElements;
        private int rows;
        private int cols;

        public HtmlTable(int rows, int cols)
            : base(tableName, tableContent)
        {
            this.Rows = rows;
            this.Cols = cols;
            tableElements = new HtmlElement[Rows, Cols];
        }

        public int Rows
        {
            get { return this.rows; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Table rows can't be negative!");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get { return this.cols; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Table cols can't be negative!");
                }

                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0)
                {
                    throw new ArgumentOutOfRangeException("Table rows cols can't be negative!"); // Separate method???????
                }
                return this.tableElements[row, col];
            }
            set
            {
                if (row < 0 || col < 0)
                {
                    throw new ArgumentOutOfRangeException("Table rows cols can't be negative!");
                }

                this.tableElements[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");

                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>");
                    if (tableElements[row, col] != null)
                    {
                        output.Append(tableElements[row, col]);
                    }

                    output.Append("</td>");
                }

                output.Append("</tr>");
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }
    }
}
