
using Articles.Core.Domain;
using Articles.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Articles.Domain.Entities
{
  public class Article : RootEntity<string>
  {
    public DateTime? CreateAt { get; set; }
    public string? CreatedBy { get; set; }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Content { get; private set; }

    private List<Comment> _comment = new List<Comment>();

    // artık bu sınıf sadece dışarıdan erişelebilir oldu dışarıdan set edilemez
    public IReadOnlyList<Comment> Comments  => _comment;


    public Article(string name, string description, string content)
    {
      this.SetName(name);
      this.Description = description;
      this.Content = content;
      this.CreateAt = DateTime.Now;
      Id = Guid.NewGuid().ToString();

    }

    public void SetName(string name)
    {
      if (name.Contains("0"))
      {
        //throw new Exception("Makale entity ismi boş geçilmiş");
        throw new ContainsDigitException();
      }
        

      this.Name = name.Trim();

    }

    public void SetDescription(string description)
    {

    }

    public void SetContent(string content)
    {

    }

    public void AddComment(Comment comment)
    {
      this._comment.Add(comment);
    }


  }
}
