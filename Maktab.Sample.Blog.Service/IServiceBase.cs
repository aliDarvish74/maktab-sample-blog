using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Domain.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service;

/*public interface IServiceBase<TEntity> where TEntity : BaseEntity
{
    TDto MapToDto<TDto>(TEntity entity);
    TEntity MapToEntity<TDto>(TDto dto);
    TDestination MapCustomDtos<TSource, TDestination>(TSource source);
}*/

/*public class SeviceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
{
    public TDestination MapCustomDtos<TSource, TDestination>(TSource source)
    {
        return source.Adapt<TDestination>();
    }

    public TDto MapToDto<TDto>(TEntity entity)
    {
        return entity.Adapt<TDto>();
    }

    public TEntity MapToEntity<TDto>(TDto dto)
    {
        return dto.Adapt<TEntity>();
    }
}*/

/*public class X : BaseEntity
{
    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}
public interface IService : IServiceBase<X>
{

}*/

/*public class Service : SeviceBase<X>
{

}*/
