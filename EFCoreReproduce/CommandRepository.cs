﻿using AutoMapper.QueryableExtensions;
using EFCoreReproduce.Entities;

namespace EFCoreReproduce;

public class CommandRepository : RepositoryBase<CommandAuditLogEntry>
{
    public CommandRepository(DatabaseExtContext dbContext)
        : base(dbContext)
    {
    }

    public IEnumerable<CommandView> GetAllExecutedCommands(DateOnly date)
    {
        return DbSet
            // PaymentOrderInformation expression needs Context parameter -- https://docs.automapper.org/en/stable/Queryable-Extensions.html#parameterization
            .ProjectTo<CommandView>(MapperProfile.DefaultMapperConfiguration(), new { Context = DbContext })
            .ToList()
            ;
    }
}
