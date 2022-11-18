using Abp.Domain.Entities.Auditing;
using Boxfusion.Smartgov.Epm.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{

	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "Epm.IndicatorDefinition")]
	public class IndicatorDefinition: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListIndicatorDefinitionStatus? Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual UnitOfMeasure UnitOfMeasure { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(2000)]
		public virtual string Purpose { get; set; }

		/// <summary>
		/// Identifies whether the indicator is measuring inputs, activities, outputs, outcomes or impact, or some
		/// other dimension of performance such as efficiency, economy or equity.
		/// </summary>
		[StringLength(2000)]
		public virtual string WhatMeasured { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(2000)]
		public virtual string MethodOfCalculation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListIndicatorCalculationType? CalculationType { get; set; }
	}
}
