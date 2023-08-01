using Articles.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Domain.Entities
{
  public class Comment:ChildEntity<string>
  {
    public string Text { get; init; }
    public string CommentBy { get; init; }

    public Comment(string text, string commentBy)
    {
      this.Text = text;
      this.CommentBy = commentBy;
    }
  }
}
