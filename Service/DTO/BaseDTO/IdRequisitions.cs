using MediatR;
using System;

namespace MongoRedisFluentValidator.Service.DTO.BaseDTO
{
    public class IdRequisitions<T> : IRequest<T>
    {
        public Guid Id { get; set; }

        public IdRequisitions(Guid id)
        {
            Id = id;
        }
    }
}
