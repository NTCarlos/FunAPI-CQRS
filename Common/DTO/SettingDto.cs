using System.ComponentModel.DataAnnotations;

namespace Common.DTO
{
    public class SettingDto
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
