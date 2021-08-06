using Application.Queries.Settings;
using Common.DTO;
using Common.Exceptions.NotFound;
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
    public class GetSettingByIdHandler : IRequestHandler<GetSettingByIdQuery, SettingDto>
    {
        private readonly IGenericRepository<Setting> _repo;
        private readonly ILogger _logger;
        public GetSettingByIdHandler(IGenericRepository<Setting> repo, ILogger<GetSettingByIdHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }

        public async Task<SettingDto> Handle(GetSettingByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                _logger.LogError("Id argument cannot be null.");
                throw new ArgumentNullException(nameof(request));
            }

            var setting = await _repo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (setting == null)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }
            return new SettingDto { Key = setting.Key, Value = setting.Value };
        }
    }
}
