using SoT.Domain.Specification.Category;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Category
{
    public class CategoryIsVerifiedForRegistration : BaseSupervisor<Entities.Category>
    {
        public CategoryIsVerifiedForRegistration()
        {
            var isKeyNotNull             = new CategoryIsKeyNotNull();
            var isNameNotNullAndNotEmpty = new CategoryIsNameNotNullAndNotEmpty();
            var isNameValidLength        = new CategoryIsNameValidLength();
            var isElementNotNull         = new CategoryIsElementNotNull();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Category>(isKeyNotNull,
                $"{nameof(Entities.Category.CategoryId)} is required"));

            base.AddRule("IsNameNotNullAndNotEmpty", new Rule<Entities.Category>(isNameNotNullAndNotEmpty,
                $"{nameof(Entities.Category.Name)} is required"));

            base.AddRule("IsNameValidLength", new Rule<Entities.Category>(isNameValidLength,
                $"{nameof(Entities.Category.Name)} can not have more than 100 chars"));

            base.AddRule("IsElementNotNull", new Rule<Entities.Category>(isElementNotNull,
                $"{nameof(Entities.Category.Element)} is required"));
        }
    }
}
