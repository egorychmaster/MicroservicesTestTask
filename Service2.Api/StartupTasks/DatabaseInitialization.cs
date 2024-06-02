﻿using Microsoft.EntityFrameworkCore;
using Service2.Infrastructure.Postgres;

namespace Service2.Api.StartupTasks
{
    internal class DatabaseInitialization : IHostedService
    {
        private readonly IDbContextFactory<Service2Context> _dbContextFactory;
        public DatabaseInitialization(IDbContextFactory<Service2Context> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();
                await _dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}