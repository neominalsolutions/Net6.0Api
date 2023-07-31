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
    private List<CommentDetail> _commentDetails = new List<CommentDetail>();
    public IReadOnlyList<CommentDetail> Details => _commentDetails;

    public void AddCommentDetail()
    {

    }

  }
}
