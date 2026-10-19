namespace Entities.Concrete.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("Not Found!")
        {
        }
    }
}