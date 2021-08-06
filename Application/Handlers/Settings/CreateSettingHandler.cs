using Application.Commands;
using Common.DTO;
using Common.Exceptions.BadRequest;
using Data.Models;
using Data.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Settings
{
    class CreateSettingHandler : IRequestHandler<CreateSettingCommand, SettingDto>
    {
        private readonly IGenericRepository<Setting> _repo;
        private readonly ILogger _logger;
        public CreateSettingHandler(IGenericRepository<Setting> repo, ILogger<GetSettingByIdHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger;
        }
        public async Task<SettingDto> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                _logger.LogError("Setting argument cannot be null.");
                throw new ArgumentNullException(nameof(request));
            }

            var findSetting = _repo.FirstOrDefaultAsync(x => x.Key == request.Key).Result;
            if (findSetting != null)
            {
                _logger.LogError("A Setting with that Key already exist.");
                throw new KeyAlreadyExistException();
            }

            var newSetting = new Setting
            {
                Key = request.Key,
                Value = request.Value
            };

            _repo.Add(newSetting);
            await _repo.SaveChangesAsync();

            return new SettingDto { Id = newSetting.Id ,Key = newSetting.Key, Value = newSetting.Value };
        }
    }
}
