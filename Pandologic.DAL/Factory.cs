using DatabaseConnections;
using Pandologic.Entities;
using Processing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandologic.DAL
{
    public static class Factory
    {
        public static IFetcher<JobTitle, string> GetJobTitleFetcher()
        {
            return new JobTitlesRepository(
                connectionFactory: new SqlConnectionFactory(
                    connectionStringSource: new PandologicDBConnectionStringSource()));
        }

        public static IFetcher<Job, int> GetJobFetcher()
        {
            return new JobsRepository(
                connectionFactory: new SqlConnectionFactory(
                    connectionStringSource: new PandologicDBConnectionStringSource()));
        }
    }
}
