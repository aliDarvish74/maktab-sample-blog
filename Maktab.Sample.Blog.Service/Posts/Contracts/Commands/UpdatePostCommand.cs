using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Posts.Contracts.Commands;

public class UpdatePostCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string PostText { get; set; }
}
