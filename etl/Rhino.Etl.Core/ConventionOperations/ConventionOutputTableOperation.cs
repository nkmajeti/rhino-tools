using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Rhino.Etl.Core.Operations;

namespace Rhino.Etl.Core.ConventionOperations
{
	///<summary>
	/// Similar to <see cref="ConventionOutputCommandOperation"/>, only with this 
	/// operation you specify a table name instead of a command, and the operation 
	/// builds the insert command for you. The command is built using the row's 
	/// column names, so the output table's columns must match these names.
	///</summary>
	public class ConventionOutputTableOperation : OutputCommandOperation
	{
		private string tableName;

		///<summary>
		/// Initializes a new instance of the <see cref="ConventionOutputTableOperation"/> class.
		///</summary>
		///<param name="connectionStringName">Name of the connection string.</param>
		public ConventionOutputTableOperation(string connectionStringName)
			: base(connectionStringName)
		{ }

		///<summary>
		/// The name of the table where rows will be inserted.
		///</summary>
		public string TableName
		{
			get { return tableName; }
			set { tableName = value; }
		}

		/// <summary>
		/// Prepares the command for execution, set command text, parameters, etc
		/// </summary>
		/// <param name="cmd">The command.</param>
		/// <param name="row">The row.</param>
		protected override void PrepareCommand(IDbCommand cmd, Row row)
		{
			cmd.CommandText = CreateInsertCommand(tableName, row);
			CopyRowValuesToCommandParameters(cmd, row);
		}

		private string CreateInsertCommand(string table, Row row)
		{
			var cmd = new StringBuilder();
			cmd.AppendFormat("insert into {0} ({1}) values ({2})",
								 table,
								 CreateCsvString(row.Columns),
								 CreateCsvString("@", row.Columns)
			);
			return cmd.ToString();
		}

		private static string CreateCsvString(IEnumerable<string> strings)
		{
			return string.Join(",", strings.ToArray());
		}

		private static string CreateCsvString(string prependEach, IEnumerable<string> strings)
		{
			var prepended = new List<string>(strings.Count());
			foreach (var s in strings)
				prepended.Add(prependEach + s);

			return CreateCsvString(prepended);
		}
	}
}