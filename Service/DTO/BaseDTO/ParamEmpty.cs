using MediatR;

namespace MongoRedisFluentValidator.Service.DTO.BaseDTO
{
    public class ParamEmpty<T> : IRequest<T>
    {
    }
}
