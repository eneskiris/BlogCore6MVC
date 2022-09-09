using Entities.Concrete;

namespace Business.Abstract;

public interface INewsLetterService
{
    void AddNewsLetter(NewsLetter newsLetter);
}