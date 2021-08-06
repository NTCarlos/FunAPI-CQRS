using Common.DTO;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Settings
{
    public class GetSettingByIdQuery : IRequest<SettingDto>
    {
        public int Id { get; set; }
        public GetSettingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
