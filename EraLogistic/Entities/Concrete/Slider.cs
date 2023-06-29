using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Slider : EntityBase, IEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RedirectUrl { get; set; }
    }
}
