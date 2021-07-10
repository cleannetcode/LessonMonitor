using FluentValidation;
using LessonMonitor.Core;

namespace LessonMonitor.BusinessLogic.Validators
{
	public class MemberValidator : AbstractValidator<Member>
	{
		public MemberValidator()
		{
			RuleFor(x => x.Id).Empty();
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.YouTubeUserId).NotEmpty();
		}
	}
}
