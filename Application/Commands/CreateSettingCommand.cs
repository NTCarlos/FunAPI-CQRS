using Common.DTO;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands
{
    public class CreateSettingCommand: IRequest<SettingDto>
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
