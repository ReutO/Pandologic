using Dapper;
using Pandologic.Entities;
using Processing;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pandologic.DAL
{
    public class JobsRepository : SourceBase, IFetcher<Job, int>
    {
        public JobsRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<Job> Fetch(int jobTitleId)
        {
            if (jobTitleId < 1)
            {
                throw new ArgumentNullException(nameof(jobTitleId));
            }

            var cacheKey = $"{nameof(JobsRepository)}::{nameof(Fetch)}::{nameof(jobTitleId)}:{jobTitleId}";

            const string query = @"SELECT j.[JobId] as [ID]
                                          ,j.[JobTitleId] as [JobTitleID]
                                          ,j.[CategoryId] as [CategoryID]
                                          ,j.[City]
                                          ,j.[State]
                                          ,j.[DescriptionLength]
                                          ,j.[EducationLevel]
                                          ,j.[Clicks]
                                          ,j.[Applicants]
                                          ,t.[JobTitleName]
                                          ,CONCAT(t.[JobTitleName],' in ',j.[City],', ',j.[State]) as [JobTitleDescription]
                                   FROM [Pandologic].[dbo].[Test_Jobs] j
                                   INNER JOIN [Pandologic].[dbo].[Test_JobTitles] t ON t.[JobTitleId] = j.[JobTitleId]
                                   WHERE j.[JobTitleId] = @JobTitleID";

            var parameters = new DynamicParameters();
            parameters.Add("@JobTitleID", jobTitleId, DbType.Int32);

            return Call((connection) =>
            {
                var result = connection.Query<Job>(query, parameters);

                return result;
            }, cacheKey);
        }
    }
}
