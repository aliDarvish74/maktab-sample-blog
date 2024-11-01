using Maktab.Sample.Blog.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Abstraction.Service.Exceptions;

public class BaseServiceException : BaseException
{
    public BaseServiceException(string message) : base(message)
    {
        Code = "ServiceException_";
    }
}


public class ItemNotFoundException : BaseServiceException
{
    public ItemNotFoundException(string itemName) : base($"{itemName} not found.")
    {
        Code += 404;
    }
}

public class PermissionDeniedException : BaseServiceException
{
    public PermissionDeniedException() : base($"Permission denied! You can't perform this action.")
    {
        Code += 403;
    }
}