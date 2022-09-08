using FluentMigrator;
using Shesha.Domain;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220907124000)]
    public class M20220907124000 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"
CREATE or ALTER FUNCTION fn_His_GetProductCode (@ProductId uniqueIdentifier)
RETURNS nvarchar(255)
AS
BEGIN
	Declare @code nvarchar(255)

    select @code = [ProductCode]
	from entpr_Products where Id = @ProductId

	return @code
END
GO
");
		}

        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
