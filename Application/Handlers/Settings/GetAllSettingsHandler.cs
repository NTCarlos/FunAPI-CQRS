using Application.Queries.Settings;
using Common.DTO;
using Data.Models;
using Data.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Settings
{
    public class GetAllSettingsHandler : IRequestHandler<GetAllSettingsQuery, List<SettingDto>>
    {
        private readonly IGenericRepository<Setting> _repo;
        public GetAllSettingsHandler(IGenericRepository<Setting> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        async Task<List<SettingDto>> IRequestHandler<GetAllSettingsQuery, List<SettingDto>>.Handle(GetAllSettingsQuery request, CancellationToken cancellationToken)
        {
            var settings = await _repo.GetAllAsync();
            var result = new List<SettingDto>();

            // Manual Map for now
            foreach (var item in settings)
            {
                result.Add(new SettingDto()
                {
                    Key = item.Key,
                    Value = item.Value
                });
            }
            return result;
        }
    }
}
