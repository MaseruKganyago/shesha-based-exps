using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.ProgressReports
{
	public class ProgressReportValidator: AbstractValidator<ProgressReport>
	{
		public ProgressReportValidator()
		{
			RuleFor(a => a.PerformanceReport).NotEmpty().WithMessage("Testing fluent validations");
		}
	}
}
