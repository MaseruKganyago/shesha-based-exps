
using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Migrations
{
	/// <summary>
	/// 
	/// </summary>
	[Migration(20221123094600)]
	public class M20221123094600 : Migration
	{
		/// <summary>
		/// 
		/// </summary>
		public override void Up()
		{
			Execute.Sql(@"
Create or ALTER   FUNCTION [dbo].[fn_Epm_GetNodePath] (@compId uniqueIdentifier)
RETURNS nvarchar(Max)
AS
BEGIN
declare @count int = 1;
declare @path nvarchar(Max) = '';

while @count = 1
begin

declare @name nvarchar(200);
declare @localParentId uniqueIdentifier;
select @name = Name, @localParentId = ParentId from Epm_Components where Id = @compId

set @path = CONCAT(@name, '/', @path);
if(@localParentId is NULL) set @count = 0;
set @compId = @localParentId
end

return @path
END");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		public override void Down()
		{
			throw new NotImplementedException();
		}
	}
}
