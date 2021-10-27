using Dapper;
using Pandologic.Entities;
using Processing;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pandologic.DAL
{
    public class JobTitlesRepository: SourceBase, IFetcher<JobTitle, string>
    {
        public JobTitlesRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public IEnumerable<JobTitle> Fetch(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                throw new ArgumentNullException(nameof(search));
            }

            var cacheKey = $"{nameof(JobTitlesRepository)}::{nameof(Fetch)}::{nameof(search)}:{search}";

            const string query = @"SELECT [JobTitleId] as [ID], [JobTitleName] as [Name], [CategoryId] as [CategoryID] 
                                   FROM [Pandologic].[dbo].[Test_JobTitles] 
                                   WHERE [JobTitleName] LIKE @Search + '%'";

            var parameters = new DynamicParameters();
            parameters.Add("@Search", search, DbType.String);

            return Call((connection) =>
            {
                var result = connection.Query<JobTitle>(query, parameters);

                return result;
            }, cacheKey);
        }
    }
}
