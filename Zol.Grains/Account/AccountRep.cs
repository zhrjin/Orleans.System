﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using Ray.Core.Internal;
using Ray.IGrains;
using Ray.IGrains.Actors;
using Ray.IGrains.States;

namespace Ray.Grain
{
    public sealed class AccountRep : ReplicaGrain<long, AccountState, MessageInfo>, IAccountRep
    {
        public AccountRep(ILogger<AccountRep> logger) : base(logger)
        {
        }
        public override long GrainId => this.GetPrimaryKeyLong();

        protected override ValueTask Apply(AccountState state, IEventBase<long> evt)
        {
            Account.EventHandle.Apply(state, evt);
            return new ValueTask(Task.CompletedTask);
        }

        public Task<decimal> GetBalance()
        {
            return Task.FromResult(State.Balance);
        }
    }
}
