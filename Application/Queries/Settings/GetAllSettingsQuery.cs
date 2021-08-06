using Common.DTO;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Settings
{
    public class GetAllSettingsQuery: IRequest<List<SettingDto>>
    {
    }
}
