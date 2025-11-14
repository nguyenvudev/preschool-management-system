
using FluentValidation;

namespace PreschoolManagementSystem.Application.Features.Students.Commands.CreateStudent
{
    public sealed class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {

        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Mã học sinh không được để trống.")
                .MaximumLength(20).WithMessage("Mã học sinh không được vượt quá 20 ký tự.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Họ và tên không được để trống.")
                .MaximumLength(100).WithMessage("Họ và tên không được vượt quá 100 ký tự.");

            RuleFor(x => x.DateOfBirth)
               .LessThan(DateTime.Now).WithMessage("Ngày sinh không hợp lệ")
               .GreaterThan(DateTime.Now.AddYears(-7)).WithMessage("Học sinh phải dưới 10 tuổi");

            RuleFor(x => x.Gender)
               .NotEmpty().WithMessage("Giới tính là bắt buộc")
               .Must(g => new[] { "Nam", "Nữ" }.Contains(g))
               .WithMessage("Giới tính không hợp lệ");

            When(x => !string.IsNullOrEmpty(x.ParentEmail), () =>
            {
                RuleFor(x => x.ParentEmail)
                    .EmailAddress().WithMessage("Email của phụ huynh không hợp lệ.");
            });

            When(x => !string.IsNullOrEmpty(x.ParentPhone), () =>
            {
                RuleFor(x => x.ParentPhone)
                    .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Số điện thoại của phụ huynh không hợp lệ.");
            });

        }
    }
}