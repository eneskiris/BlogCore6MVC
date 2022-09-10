using Entities.Concrete;

namespace Business.Abstract;

public interface IAboutService
{
    List<About> GetList();
}