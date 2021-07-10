using FluentValidation;
using LessonMonitor.Core;

namespace LessonMonitor.BussinesLogic.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.Id).Empty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.YouTubeAccountId).NotEmpty();
        }
    }
}
