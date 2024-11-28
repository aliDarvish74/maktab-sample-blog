using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Posts.Contracts.Commands;

public class AddPostCommand
{
    public string Title { get; set; }
    public string PostText { get; set; }
    public string UserName { get; set; }
}
