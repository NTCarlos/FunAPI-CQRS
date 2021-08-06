using Common.Exceptions.BadRequest;

namespace Common.Exceptions.NotFound
{
    public class SettingNotFound : BaseNotFoundException
    {
        public SettingNotFound() : base()
        {
            CustomMessage = "Setting Not Found.";
        }
    }
}
