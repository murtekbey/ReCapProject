using Entities.Abstract;

namespace Entities.Concrete
{
    public class Color: IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
